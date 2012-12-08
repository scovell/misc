#include <windows.h>
#include <stdio.h>

void print_mem(char *str,int len)
{
	int i;
	for(i=0;i<len;i++)
	printf("%c",str[i]);
	printf("\n");
}

int main(int argc,char *argv[])
{
	char strWndName[100];
	char strBuf[100];
	DWORD pid;
	DWORD numBytesRead;
	HWND hTarget;
	HANDLE handleTarget;	
	
	strcpy(strWndName,argv[1]);
	hTarget=FindWindow(NULL,strWndName);
	GetWindowThreadProcessId(hTarget,&pid);
	printf("Window PID = %d\n",pid);
	handleTarget=OpenProcess(PROCESS_VM_READ,TRUE,pid);
	//printf("%X %X %X %X\n",strBuf[0],strBuf[1],strBuf[2],strBuf[3]);

	memset(strBuf,0,100);
	ReadProcessMemory(handleTarget,(LPCVOID)0x004041BC ,strBuf,atoi(argv[2]),&numBytesRead);
	print_mem(strBuf,numBytesRead);

	memset(strBuf,0,100);
	ReadProcessMemory(handleTarget,(LPCVOID)0x0040422A,strBuf,atoi(argv[2]),&numBytesRead);
	print_mem(strBuf,numBytesRead);

	CloseHandle(handleTarget);
	return 0;
}
