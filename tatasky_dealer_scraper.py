import urllib

#http://www.tatasky.com/dealerlocator/js/data/stateid/cityid/L/localityid
lines=urllib.urlopen("http://www.tatasky.com/dealerlocator/js/data/5/4625/localitylist.js").readlines()
base="http://www.tatasky.com/dealerlocator/js/data/5/4625/L/"
address=[]

for line in lines:
	if line.find("addLocality") <> -1:
		localityid=line.split('"')[1]
		url=base+localityid+"/dealerlist.js"
		ad=urllib.urlopen(url).readlines()
		for i in ad:
			if i.find("addDealer") <> -1:
				x=i.split("(")[1].split(")")[0].split(",")
				print x
