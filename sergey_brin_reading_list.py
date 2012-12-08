import urllib2
import BeautifulSoup

d=str(BeautifulSoup.BeautifulSoup(urllib2.urlopen("http://infolab.stanford.edu/~sergey/booklist.html").read()).find("body"))
d=d.split("</i><br />")[:-2]
d[0]=d[0].split("-->")[-1]
x={}
y={}

for i in d:
	l=i.split(" - <i>")
	x[l[0].lstrip()]=0
	y[l[0].lstrip()]='|'

for i in d:
	l=i.split(" - <i>")
	x[l[0].lstrip()]+=1
	y[l[0].lstrip()]+=l[1]+'|'

for i in sorted(x,key=x.get,reverse=True):
	print i,"++",x[i],"++",y[i].split("|")[1:-1]
