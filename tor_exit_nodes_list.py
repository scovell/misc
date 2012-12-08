#!/usr/bin/python
import urllib2
#http://packages.python.org/pygeoip/
import pygeoip


url="http://128.31.0.34:9031/tor/status/all"
d=urllib2.urlopen(url).readlines()
c=pygeoip.GeoIP('GeoIP.dat',pygeoip.MEMORY_CACHE)
n={}

for i in range(0,len(d)):
        if d[i][0]=='r':
                a1=d[i].rstrip().split(" ")
                a2=d[i+1].rstrip().split(" ")
                a3=d[i+2].rstrip().split(" ")
                #print a1[1],a1[6],''.join(a2[1:]),''.join(a3[2:])
                print ''.join(a2[1:]),a1[6],c.country_code_by_addr(a1[6])

