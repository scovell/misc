import urllib
import BeautifulSoup

u="http://freevideolectures.com/Course/2656/CSCI-E-2-Bits/"
h=BeautifulSoup.BeautifulSoup(urllib.urlopen(u).read())

for i in h.find('div',id='first').findAll('a'):
	d=BeautifulSoup.BeautifulSoup(urllib.urlopen(i['href']).read()).find('span',attrs={'class':'download'}).findAll('a')
	for j in d:
		print j["href"]

