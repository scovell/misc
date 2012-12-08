import sys

d=open(sys.argv[1],"r").readlines()

for i in range(0,len(d),1):
	if d[i].find("Nmap scan report for") <> -1:
		if d[i+1].find("latency") <> -1:
			print d[i].split(" ")[-1].rstrip()+"\t",
			i=i+1
			while d[i].find("Nmap scan report for") == -1:
				if d[i].find("Read data") <> -1:
					exit()
				if d[i].find("open ") <> -1:
					print d[i].split(" ")[0].rstrip().replace("/tcp","").replace("/udp",""),
				i=i+1
			print
		else:
			print d[i].split(" ")[-1].rstrip()+"\t","closed"
		
