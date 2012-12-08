import urllib
import BeautifulSoup
from xml.dom import minidom

c="PracticalUnix"

d=urllib.urlopen("http://openclassroom.stanford.edu/MainFolder/CoursePage.php?course="+c).read()
h=BeautifulSoup.BeautifulSoup(d)

for i in h.findAll('h3'):
    x=i.findNext('ul')
    y=x.findAll('a')
    for j in y:
        if j['href'].find("VideoPage") <> -1:
	    xml=urllib.urlopen("http://openclassroom.stanford.edu/MainFolder/courses/"+c+"/videos/"+j['href'].split("&")[-2].split("=")[1]+".xml").read()
            print minidom.parseString(xml).getElementsByTagName('video')[0].childNodes[3].toxml(encoding='ASCII').replace("<videoFile>","").replace("</videoFile>","")
		
		
