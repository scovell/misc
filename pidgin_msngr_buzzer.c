#include <windows.h>
#include <stdio.h>

int num_of_buzz;

BOOL CALLBACK findGDKChildWindow(HWND hwnd,LPARAM lParam)
{
	char strText[1024];
	int x,y,i;
	RECT size;
	
	memset(&size,0,sizeof(RECT));
	GetClientRect(hwnd,&size);
	x=size.right - size.left;
	y=size.bottom - size.top;

	if (x==78 && y==26)
	{
		printf("Buzzing %s %d times\n",(char *)lParam,num_of_buzz);		
		for(i=1;i<=num_of_buzz;i++)
		{
			SendMessage(hwnd,WM_LBUTTONDOWN,0,0);
			SendMessage(hwnd,WM_LBUTTONUP,0,0);
		}
	}

	return 1;
}

BOOL CALLBACK findGDKTopLevel(HWND hwnd,LPARAM lParam)
{
	char strText[1024];

	memset(strText,0,1024);
	GetClassName(hwnd,strText,1024);
	if (!(strcmp(strText,"gdkWindowToplevel")))
	{
		memset(strText,0,1024);
		GetWindowText(hwnd,strText,1024);
		if(!(strcmp(strText,(const char *)lParam)))
		EnumChildWindows(hwnd,findGDKChildWindow,lParam);
	}

	return 1;
}


int main(int argc,char *argv[])
{
	if (argc != 3)
	{printf("Usage : %s <userid> <number_of_buzzes>\n",argv[0]);return -1;}	
	num_of_buzz=atoi(argv[2]);
	EnumWindows(findGDKTopLevel,(LPARAM)argv[1]);
	return 0;
}
