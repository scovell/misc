import urllib2
import re

stat_url="http://192.168.1.1/statsadsl.html"
#user_name=""
#pass_word=""

password_manager=urllib2.HTTPPasswordMgrWithDefaultRealm()
password_manager.add_password(None,stat_url,user_name,pass_word)
auth_handler=urllib2.HTTPBasicAuthHandler(password_manager)
opener=urllib2.build_opener(auth_handler)
urllib2.install_opener(opener)
page_text=urllib2.urlopen(stat_url).read()

splitz=re.split(r"\n",re.split(r"<\/tr>",re.split(r"<td class='hd'>SNR Margin \(dB\):<\/td>",page_text)[1])[0])
downstream_snr=splitz[1].replace(" ","").replace("<td>","").replace("</td>","").replace("&nbsp;","")
upstream_snr=splitz[2].replace(" ","").replace("<td>","").replace("</td>","").replace("&nbsp;","")
print "Downstream SNR = ",downstream_snr,"\n","Upstream SNR = ",upstream_snr
