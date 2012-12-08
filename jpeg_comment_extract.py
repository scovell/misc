import sys

f=open(sys.argv[1])
data=f.read()
f.close()

comment_ident=chr(0xFF) + chr(0xFE)
found_comment=data.find(comment_ident)

if(found_comment != -1):
	hibyte_size=ord(data[found_comment+2])	
	lobyte_size=ord(data[found_comment+3])
	size=(hibyte_size<<8)+lobyte_size
	print data[found_comment+4:found_comment+3+size]
