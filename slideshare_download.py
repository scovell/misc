import hashlib
import urllib
import time
import sys
from xml.dom import minidom

def slideshare_url(link):
	api_key=""
	ts=str(int(time.time()))
	shared_secret=""

	hash=hashlib.sha1(shared_secret+ts).hexdigest()
	url="http://www.slideshare.net/api/2/get_slideshow"+"?slideshow_url="+link.rstrip()+"&ts="+ts+"&hash="+hash+"&api_key="+api_key
	xml=minidom.parseString(urllib.urlopen(url).read())
	if (xml.getElementsByTagName('DownloadUrl')):
		dl_link=xml.getElementsByTagName('DownloadUrl').item(0).toxml().replace('<DownloadUrl>','').replace('</DownloadUrl>','').replace('&amp;','&')
		file_name=link.rstrip().split('/')[-1]
		xml=minidom.parseString(urllib.urlopen(url).read())
		file_format=xml.getElementsByTagName('Format').item(0).toxml().replace('<Format>','').replace('</Format>','')
		print dl_link
		urllib.urlretrieve (dl_link,sys.argv[2]+file_name+"."+file_format)

for link in open(sys.argv[1],'r'):
	slideshare_url(link)
