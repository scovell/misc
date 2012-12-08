#!/usr/bin/python

import mechanize
import cookielib
import BeautifulSoup
import sys

c=cookielib.LWPCookieJar()
b=mechanize.Browser()

b.set_cookiejar(c)
b.set_handle_equiv(True)
b.set_handle_redirect(True)
b.set_handle_referer(True)
b.set_handle_robots(False)
b.set_handle_refresh(mechanize._http.HTTPRefreshProcessor(), max_time=1)
b.addheaders = [('User-agent', 'Mozilla/5.0 (X11; U; Linux i686; en-US; rv:1.9.0.1) Gecko/2008071615 Fedora/3.0.1-1.fc9 Firefox/3.0.1')]

b.open("http://mail.google.com")
f=b.forms().next()
f['Email']=sys.argv[1]
f['Passwd']=sys.argv[2]
b.form=f
b.submit()

d=BeautifulSoup.BeautifulSoup(str(b.response().read()))
x=''

for i in d.findAll('script'):
	if i.getText().find("GLOBALS") <> -1 :
		x=i.getText()

id=x.split(';')[0].split(',')[9].replace('\"','')
details="https://mail.google.com/mail/?ui=2&ik="+id+"&view=ac"
ipdetails=BeautifulSoup.BeautifulSoup(b.open(details).read())
#print b.response().read()
table=ipdetails.find('table',{'width':'100%','border':'1'})
tr=ipdetails.findAll('tr',{'class':'fs'})

listOFip=[]
for i in tr:
	for j in i.findAll('td'):
		listOFip.append(str(j.getText()))
listOFip=listOFip[9:-17]
CurrentLogin=listOFip[0:2]
listOFip=listOFip[2:]

print CurrentLogin[0],CurrentLogin[1]
for i in range(0,len(listOFip)-1,3):
	print listOFip[i],listOFip[i+1],listOFip[i+2]

b.back()
#for i in b.links():
#	print i.text

#ip=b.click_link(text='Details')
#b.open(ip)
#string=b.response().read()
#print string

signout=b.click_link(text='Sign out')
b.open(signout)
#print string
