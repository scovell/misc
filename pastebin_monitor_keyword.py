#!/usr/bin/python

import urllib2
import time
import sys
import BeautifulSoup

#http://pythonadventures.wordpress.com/2012/09/02/print-unicode-text-to-the-terminal/
reload(sys)
sys.setdefaultencoding("utf-8")

realtime_url="http://pastebin.com/archive"
raw_url="http://pastebin.com/raw.php?i="

def realtime_paste(keyword):
	tr=BeautifulSoup.BeautifulSoup(urllib2.urlopen(realtime_url).read()).find("table","maintable").findAll("tr")
	for r in tr:
		if r.find("a") == None: continue
		paste_id=r.find("a")["href"].replace("/","")
		raw=urllib2.urlopen(raw_url+paste_id).read()
		if raw.find(keyword) <> -1:
			print 'http://pastebin.com/'+paste_id," ",time.asctime()

	
while(1):
	realtime_paste(sys.argv[1])
	time.sleep(2)
	
