import urllib2
import sys
import time
import BeautifulSoup as bs #not BS bs..

def slideshare_rip_urls(url):
	html=bs.BeautifulSoup(urllib2.urlopen(url).read())
	ul=html.find('ul',{'class':'bigList clearfix'})
	for i in ul.findAll('a'):
		print "http://www.slideshare.net"+i['href']

urls=open(sys.argv[1]).readlines()
for url in urls:
	slideshare_rip_urls(url.rstrip())
	time.sleep(20)
	
