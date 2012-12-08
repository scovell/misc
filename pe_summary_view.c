#include <windows.h>
#include <stdio.h>

//Variables Declared
HANDLE hFile,hMap;
HMODULE peFile;
LPVOID mapFile;
char name[20];
DWORD highSize,lowSize,i,RAW;
IMAGE_DOS_HEADER *pDosHeader;
IMAGE_NT_HEADERS *pImageNTHeader;
IMAGE_FILE_HEADER *pFileheader;
IMAGE_OPTIONAL_HEADER *pImageOptionalHeader;
IMAGE_SECTION_HEADER *sectionHeader;
IMAGE_SECTION_HEADER section;
IMAGE_NT_HEADERS nt_headers;
DWORD dwPE_Offset,SectionOffset;
IMAGE_IMPORT_DESCRIPTOR *importDLL;
IMAGE_THUNK_DATA *thunkData;
IMAGE_IMPORT_BY_NAME *importName;
DWORD Image_Base;
char *DataDirectoryNames[15]={"Export Directory",
	   					      "Import Directory",
							  "Resource Directory",
							  "Exception Directory",
							  "Security Directory",
							  "Base Relocation Directory",
							  "Base Relocation Directory",
							  "Copyright Note",
							  "Global Pointer",
							  "Thread Local Storage Directory",
							  "Load Configuration Directory",
							  "Bound Import Directory",
							  "Import Address Table",
							  "Delay Import Directory",
							  "COM Header"};

//Ripped From y0da Crypter _ImageRvaToSection AND RVA2Offset
//Return IMAGE_SECTION_HEADER containing the RVA
PIMAGE_SECTION_HEADER _ImageRvaToSection(char* Base,DWORD dwRVA)
{
	
	CopyMemory(&dwPE_Offset,Base+0x3c,4);
	CopyMemory(&nt_headers,Base+dwPE_Offset,sizeof(IMAGE_NT_HEADERS));
	SectionOffset=dwPE_Offset+sizeof(IMAGE_NT_HEADERS);
	for(i=0;i<nt_headers.FileHeader.NumberOfSections;i++)
	{
		CopyMemory(&section,Base+SectionOffset+i*0x28,sizeof(IMAGE_SECTION_HEADER));
		if((dwRVA>=section.VirtualAddress) && (dwRVA<=(section.VirtualAddress+section.SizeOfRawData)))
		{
			
			return ((PIMAGE_SECTION_HEADER)&section);
		}
	}
	return(NULL);
}
//Return RAW Offset from the RVA
DWORD RVA2Offset(char* Base,DWORD dwRVA)
{
	DWORD _offset;
	PIMAGE_SECTION_HEADER section;
	section=_ImageRvaToSection(Base,dwRVA);
	if(section==NULL)
	{
		return(0);
	}
	_offset=dwRVA+section->PointerToRawData-section->VirtualAddress;
	return(_offset);
}


//EntryPoint
int main(int argc, char *argv[])
{
	//Check CmdLine Param
	if(argc !=2)
	{
		printf("Usage peview <FileName.exe>\n",argv[0]);
		return 0;
	}
	//Opening File 
	hFile=CreateFile(argv[1],GENERIC_READ,0,NULL,OPEN_EXISTING,FILE_ATTRIBUTE_NORMAL,NULL);
	if(hFile == INVALID_HANDLE_VALUE)
	{
		printf("[+]Error Opening File\n");
		return 0;
	}
	//Getting FileSize	
	lowSize=GetFileSize(hFile,&highSize);
	//Creating File Mapping	
	hMap=CreateFileMapping(hFile,NULL,PAGE_READONLY,highSize,lowSize,"MapFile");
	if(hFile == NULL)
	{
		printf("[+]Error Creating FileMap Object\n");
		return 0;
	}
	//Creating MapView in Memory
	mapFile=MapViewOfFile(hMap,FILE_MAP_READ,0,0,0);
	if(hFile == NULL)
	{
		printf("[+]Error Mapping File\n");
		return 0;
	}
	
	//Intialising Value of PE Structres
	peFile=(HMODULE)mapFile;
	pDosHeader=(IMAGE_DOS_HEADER*)peFile;
	pImageNTHeader=(IMAGE_NT_HEADERS*)((LPBYTE)peFile+pDosHeader->e_lfanew);
	pFileheader=&pImageNTHeader->FileHeader;
	pImageOptionalHeader=&pImageNTHeader->OptionalHeader;
	sectionHeader=(IMAGE_SECTION_HEADER*)((LPBYTE)pImageOptionalHeader+pFileheader->SizeOfOptionalHeader);
	//CopyMemory(&peMagic,(LPVOID)((LPBYTE)pImageNTHeader+0x06),2);

	//Dumping PE File Characterisitcs
	printf("==================================================================\n");
	printf("PE FILE CHARACTERISTICS\n");
	printf("==================================================================\n");
	printf("Magic PE Bytes = %X\n",pDosHeader->e_magic);
	printf("PE NT_SIGNATURE Bytes = %X\n",pImageNTHeader->Signature);
	printf("Number of Sections = %d\n",pImageNTHeader->FileHeader.NumberOfSections);
	printf("Time Stamp = %X\n",pFileheader->TimeDateStamp);
	printf("Entry Point = %X\n",pImageOptionalHeader->AddressOfEntryPoint);
	printf("Image Base = %X\n",pImageOptionalHeader->ImageBase);
	printf("Image Size = %X\n",pImageOptionalHeader->SizeOfImage);
	printf("Section Alignment = %X\n",pImageOptionalHeader->SectionAlignment);
	printf("File Alignment = %X\n",pImageOptionalHeader->FileAlignment);
	//Dumping PE File Data Directories
	printf("==================================================================\n");
	printf("DATA DIRECTORY\n");
	printf("==================================================================\n");
	for(i=0;i<15;i++)
	{
		if(pImageOptionalHeader->DataDirectory[i].Size !=0)
		{
			printf("Data Directory Name = %s\n",DataDirectoryNames[i]);
			printf("Data Directory RVA = %X\n",pImageOptionalHeader->DataDirectory[i].VirtualAddress);
			printf("Data Directory Size = %X\n",pImageOptionalHeader->DataDirectory[i].Size);
			printf("------------------------------------------------------------------\n");
		}
	}
	//Dumping PE File Section Table
	printf("==================================================================\n");
	printf("SECTION TABLE\n");
	printf("==================================================================\n");
	for(i=0;i<pFileheader->NumberOfSections;i++)
	{
		printf("Section Name = %s\n",sectionHeader->Name );
		printf("Virtual Offset = %X\n",sectionHeader->VirtualAddress);
		printf("Virtual Size = %X\n",sectionHeader->Misc.VirtualSize);
		printf("Raw Offset = %X\n",sectionHeader->PointerToRawData );
		printf("Raw Size = %X\n",sectionHeader->SizeOfRawData);
		printf("Characteristics = %X\n",sectionHeader->Characteristics );
		printf("------------------------------------------------------------------\n");
		//sectionHeader=(IMAGE_SECTION_HEADER*)((LPBYTE)sectionHeader + 0x28);
		sectionHeader++;
	}
	//Dumping PE File Imports
	printf("==================================================================\n");
	printf("IMPORT VIEWER\n");
	printf("==================================================================\n");
	RAW=RVA2Offset((char*)peFile,pImageOptionalHeader->DataDirectory[1].VirtualAddress);
	importDLL=(IMAGE_IMPORT_DESCRIPTOR*)((DWORD)pDosHeader+RAW);
	do
	{	
		//Dumping PE File DLL Names
		RAW=RVA2Offset((char*)peFile,importDLL->Name);
		printf("DLL = %s\n",(DWORD)pDosHeader+RAW);
		printf("------------------------------------------------------------------\n");
		RAW=RVA2Offset((char*)peFile,importDLL->OriginalFirstThunk);
		thunkData=(IMAGE_THUNK_DATA*)((DWORD)pDosHeader+RAW);
		//Dumping DLL Functions
		do
		{
			
			RAW=RVA2Offset((char*)peFile,(DWORD)thunkData->u1.AddressOfData);
			importName=(IMAGE_IMPORT_BY_NAME*)((DWORD)pDosHeader+RAW);
			printf("Function = %s\n",importName->Name);
			thunkData++;
		}while(thunkData->u1.AddressOfData != NULL);

		importDLL++;
		printf("------------------------------------------------------------------\n");
	}while(importDLL->FirstThunk !=0);

	CloseHandle(hFile);
	CloseHandle(hMap);
	return 0;
	
}