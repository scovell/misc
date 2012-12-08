import sys
import urllib

ua="Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.2.18) Gecko/20110614 Firefox/3.6.18"

def conv(s,t):
	if (t==1):
		return str(s) + " bytes"
	if (t==2):
		return str((s/1000)) + " KB"
	if (t==3):
		return str((s/(1000*1000))) + " MB"

def size(l):
	
	class custom(urllib.FancyURLopener):
		version=ua
	opener=custom()
	h=opener.open(l).headers
	return int(h['Content-Length'])

print conv(size("http://unfccc.int/resource/docs/convkp/kpeng.pdf"),2)
