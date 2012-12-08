f=open("Thumbs.db","rb")
content=f.read()
f.close()
strHeader=chr(0xFF) + chr(0xD8) + chr(0xFF) + chr(0xE0) + chr(0x00) + chr(0x10) + chr(0x4A) + chr(0x46) + chr(0x49) + chr(0x46) + chr(0x00)
images=content.split(strHeader)
print "Number of Images = ",len(images)
for index in range(len(images)):
	if index != 0 :
		filename=str(index)+".jpg"
		print filename," xtracting...."
		n=open(filename,"wb")
		n.write(strHeader)
		n.write(images[index])
		n.close()
		print "Done"
