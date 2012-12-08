import hashlib
import os
import sys

d=sys.argv[1]

for i in os.listdir(d):
	if os.path.isfile(d+i):
		n=hashlib.md5(i).hexdigest()
		#print n
		os.rename(d+i,d+n)
