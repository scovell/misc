import urllib
import BeautifulSoup
import sys


#http://www.rootninja.com/python-get-unique-elements-in-a-list-sorted-or-unsorted/
def uniq(list):
	set = {}
	return [ set.setdefault(x,x) for x in list if x not in set ]

def post_extract(link):
	links=[]
	html=BeautifulSoup.BeautifulSoup(urllib.urlopen(link).read())
	t=html.findAll('ul',attrs={'class' : 'posts'})
	for i in t:
		for x in i.findAll('a'):
			links.append(x['href'])
	return links

def blogspot_archive(link,log):
	links=[]
	posts=[]
	html=BeautifulSoup.BeautifulSoup(urllib.urlopen(link).read())
	t=html.findAll('a',attrs={'class' : 'post-count-link'})
	for i in t:
		if i['href'].find('search') == -1:
			links.append(post_extract(i['href']))

	for i in links:
		for x in i:
			posts.append(x)

	posts.sort()
	posts=uniq(posts)
	
	f=open(log,"w")
	f.write("<html><head><title>blogspot dump of "+link+"</title></head><body>")
	for i in posts:
		f.write("<a href=\""+i+"\">"+i+"<br>")
	f.write("</body></html>")
	f.close()
	

if len(sys.argv) != 3:
	print "usage: python "+sys.argv[0]+" blog logifile"
	exit(-1)

if len(sys.argv) == 3:
	blogspot_archive(sys.argv[1],sys.argv[2])
