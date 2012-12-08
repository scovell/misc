#include <windows.h>
#include <stdio.h>

#define cmdFileName "Output.txt"

void Cmd2File(char *szCmd)
{
	HANDLE hFile;
	SECURITY_ATTRIBUTES secAttributes;
	PROCESS_INFORMATION pInfo;
	STARTUPINFO startup;
	
	secAttributes.bInheritHandle=TRUE;
	secAttributes.lpSecurityDescriptor =NULL;
	secAttributes.nLength =sizeof(SECURITY_ATTRIBUTES);
	
	hFile=CreateFile(cmdFileName,GENERIC_WRITE,FILE_SHARE_READ|FILE_SHARE_WRITE,&secAttributes,CREATE_NEW,FILE_ATTRIBUTE_NORMAL,NULL);

	ZeroMemory(&startup, sizeof(STARTUPINFO));
	startup.cb=sizeof(STARTUPINFO);
	startup.dwFlags =STARTF_USESTDHANDLES|STARTF_USESHOWWINDOW;
	startup.hStdOutput =hFile;
	startup.wShowWindow =SW_HIDE;
	
	CreateProcess(NULL,szCmd,NULL,NULL,TRUE,NORMAL_PRIORITY_CLASS,NULL,NULL,&startup,&pInfo);
	WaitForSingleObject(pInfo.hProcess ,INFINITE);
	
	CloseHandle(hFile);
	CloseHandle(pInfo.hProcess);
	CloseHandle(pInfo.hThread );
}

int main(int argc ,char *argv[])
{
	char szArg[MAX_PATH];int i;
	strcpy(szArg,argv[1]);
	if(argc>2)
	{
		for(i=2;i<argc;i++)
		{
			strcat(szArg,"\x20");
			strcat(szArg,argv[i]);
			
		}
		
	}
	Cmd2File(szArg);
	return 0;
}
