#include <windows.h>
#include <stdio.h>
#pragma comment(lib,"user32.lib")

int main()
{
	DWORD UpTime;
	int uptimeSec,uptimeMin,uptimeHour,uptimeDays;
	char szTime[MAX_PATH];

	UpTime=GetTickCount()/1000;//GetTickCount()(in millisenconds)
	
	uptimeDays=UpTime/(24*3600);//Days
	if(uptimeDays>0)
	UpTime=UpTime-(24*3600*uptimeDays);//DaysAdjustemnt

	uptimeHour=UpTime/3600;//Hour
	if(uptimeHour>0)
	UpTime=UpTime-(3600*uptimeHour);//HourAdjustemnt

	uptimeMin=UpTime/60;//Minutes

	uptimeSec=UpTime%60;//Seconds

	wsprintf(szTime,"UpTime = %d Days %d Hours %d Minutes %d Seconds\n",uptimeDays,uptimeHour,uptimeMin,uptimeSec );
	printf("***********************************************");
	printf("\n%s",szTime);
	printf("***********************************************");
	return 0;
}