import md5
import subprocess

basemd5=md5.new()
basemd5.update(open('exports_base.arn','r').read())
basemd5=basemd5.hexdigest()

subprocess.Popen(['autoruns.exe','-a','exports_base_new.arn']).wait()
newmd5=md5.new()
newmd5.update(open('exports_base_new.arn','r').read())
newmd5=newmd5.hexdigest()

if basemd5==newmd5:
	print "basemd5 Match"
	subprocess.Popen(['cmd.exe','/C','del','exports_base_new.arn'])	
	
else:
	print "basemd5 !Match..Dumped into exports_base_new.arn"
	
