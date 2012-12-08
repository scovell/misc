#!/usr/bin/python
from scapy.all import *

def ymsg_extract(pkt):
	tcp_payload=str(pkt[TCP].payload)
	#print tcp_payload
	if (tcp_payload[10:12]=="\x00\x06"):
		ymsg_payload=tcp_payload[20:len(tcp_payload)-20].split("\xc0\x80")
		d={}
		for i in range(0,len(ymsg_payload),2):
			d[ymsg_payload[i]]=ymsg_payload[i+1]
		#print d["1"],"->",d["5"],":",d["14"]
		msg=d["14"]
		src=d["1"] if d.has_key("1") else d["4"]	#(either d[1] or d[4])
		dst=d["5"]
		print src,"->",dst,":",msg
		
		
sniff(filter="tcp port 5050" , prn=ymsg_extract)
