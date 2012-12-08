#include <stdio.h>
#include <winsock2.h>
#pragma comment(lib,"ws2_32.lib")

void GetNetworkInterfaces()
{
	WSADATA wsaData;
	SOCKET interfaceSocket;
	char szLocalHostName[MAX_PATH];
	struct hostent *hostAddr;
	struct in_addr addr;
	int i;
	WSAStartup(MAKEWORD(2,2),&wsaData);
	interfaceSocket=socket(AF_INET,SOCK_STREAM,IPPROTO_TCP);
	gethostname(szLocalHostName,MAX_PATH);
	hostAddr=gethostbyname(szLocalHostName);
	for(i=0;hostAddr->h_addr_list[i] != 0;i++)
	{
		memcpy(&addr, hostAddr->h_addr_list[i], sizeof(struct in_addr));
		printf("InterfaceNumber =%d \tAddress =%s \n",i,inet_ntoa(addr));
	}
	closesocket(interfaceSocket);
	WSACleanup();
}

int main()
{
	GetNetworkInterfaces();
	return 0;
}