#Youtube Downloader
#dont whine done in one night
#youtube dld url valid for 2hrs
#q={'5':'flvlow','34':'flvmed','6':'flvmed2','35':'flvhigh','18':'mp4high','22':'mp4hd','37':'mp4hd2','38':'mp4hd3'}

import os
import sys
import time
import urllib
import BeautifulSoup

wget="c:\\cygwin\\bin\\wget.exe"
ua="Mozilla/5.0 (Windows; U; Windows NT 5.1; en-US; rv:1.9.2.18) Gecko/20110614 Firefox/3.6.18"
output_dir=sys.argv[2]

def url_title(u):
	video_id=u.split("=")[1]
	info_url="http://www.youtube.com/get_video_info?video_id=" + video_id
	socket=urllib.urlopen(info_url)
	data=socket.read()
	socket.close()	
	res=urllib.unquote(data)
	title=safe(res.split('title=')[1].split("&")[0])
	return safe(title)

def playlist_title(p):
	
	h=BeautifulSoup.BeautifulSoup(urllib.urlopen(p).read())
	t=h.find('div',{'class':'playlist-reference'}).find("h1")
	return safe(t.getText())

def playlist_parse(p):

	h=BeautifulSoup.BeautifulSoup(urllib.urlopen(p).read())
	a=h.findAll('a',{'class':'tile-link-block video-tile'})
	r=[]
	for i in a:
		r.append("http://www.youtube.com"+i['href'].split("&")[0])
	return r

def url_size(u):
	s=int(urllib.urlopen(youtube_dl_url(u)).headers['Content-Length'])	
	return s
	
def playlist_size(p):
	
	h=BeautifulSoup.BeautifulSoup(urllib.urlopen(p).read())
	a=h.findAll('a',{'class':'tile-link-block video-tile'})
	r=[]
	total=0
	
	for i in a:
		s=int(urllib.urlopen(youtube_dl_url("http://www.youtube.com"+i['href'].split("&")[0])).headers['Content-Length'])
		total+=s
	
	#return str(total/(1000*1000)) + " MB"
	return total
		
def safe(s):
	n=s.replace("*","").replace("|","").replace("\\","").replace("/","").replace(":","").replace("\"","").replace("<","").replace(">","").replace("?","").replace(" ","").replace("+"," ")
	return n

def youtube_dl_url(url):
	video_id=url.split("=")[1]
	info_url="http://www.youtube.com/get_video_info?video_id=" + video_id
	socket=urllib.urlopen(info_url)
	data=socket.read()
	socket.close()	
	res=urllib.unquote(data)
	
	dl={5:[],34:[],6:[],35:[],18:[],22:[],37:[],38:[]}
	title=safe(res.split('title=')[1].split("&")[0])
	
	
	x=res.split('url_encoded_fmt_stream_map=')[1].split(",")
	for i in x:
		if i.find('itag=38') <> -1:
			dl[38].append(urllib.unquote(i.split("&")[0].split("=")[1]))
			#dl[38].append(time.strftime("%Y-%m-%d %H:%M:%S",time.localtime(int(dl[38][0].split("expire=")[1].split('&')[0]))))
			dl[38].append(".mp4")
		if i.find('itag=37') <> -1:
			dl[37].append(urllib.unquote(i.split("&")[0].split("=")[1]))
			#dl[37].append(time.strftime("%Y-%m-%d %H:%M:%S",time.localtime(int(dl[37][0].split("expire=")[1].split('&')[0]))))
			dl[37].append(".mp4")
		if i.find('itag=22') <> -1:
			dl[22].append(urllib.unquote(i.split("&")[0].split("=")[1]))
			#dl[22].append(time.strftime("%Y-%m-%d %H:%M:%S",time.localtime(int(dl[22][0].split("expire=")[1].split('&')[0]))))
			dl[22].append(".mp4")
		if i.find('itag=18') <> -1:
			dl[18].append(urllib.unquote(i.split("&")[0].split("=")[1]))
			#dl[18].append(time.strftime("%Y-%m-%d %H:%M:%S",time.localtime(int(dl[18][0].split("expire=")[1].split('&')[0]))))
			dl[18].append(".mp4")
		if i.find('itag=35') <> -1:
			dl[35].append(urllib.unquote(i.split("&")[0].split("=")[1]))
			#dl[35].append(time.strftime("%Y-%m-%d %H:%M:%S",time.localtime(int(dl[35][0].split("expire=")[1].split('&')[0]))))
			dl[35].append(".flv")
		if i.find('itag=6') <> -1:
			dl[6].append(urllib.unquote(i.split("&")[0].split("=")[1]))
			#dl[6].append(time.strftime("%Y-%m-%d %H:%M:%S",time.localtime(int(dl[6][0].split("expire=")[1].split('&')[0]))))
			dl[6].append(".flv")
		if i.find('itag=34') <> -1:
			dl[34].append(urllib.unquote(i.split("&")[0].split("=")[1]))
			#dl[34].append(time.strftime("%Y-%m-%d %H:%M:%S",time.localtime(int(dl[34][0].split("expire=")[1].split('&')[0]))))
			dl[34].append(".flv")
		if i.find('itag=5') <> -1:
			dl[5].append(urllib.unquote(i.split("&")[0].split("=")[1]))
			#dl[5].append(time.strftime("%Y-%m-%d %H:%M:%S",time.localtime(int(dl[5][0].split("expire=")[1].split('&')[0]))))
			dl[5].append(".flv")
	
	for i in 38,37,22,18,35,6,34,5:
		if len(dl[i]) <> 0:
			#return dl[i][0]
			wq=wget + " -nc -U \"" + ua + "\" -O \"" + (output_dir+"\\"+title+dl[i][2]) + "\" \"" + dl[i][0] + "\""
			print "Expires on " + dl[i][1]
			os.system(wq)
			return
			
def youtube_dl(url,p):

	video_id=url.split("=")[1]
	info_url="http://www.youtube.com/get_video_info?video_id=" + video_id
	socket=urllib.urlopen(info_url)
	data=socket.read()
	socket.close()	
	res=urllib.unquote(data)
		
	dl={5:[],34:[],6:[],35:[],18:[],22:[],37:[],38:[]}
	title=safe(res.split('title=')[1].split("&")[0])
	print title
	
	x=res.split('url_encoded_fmt_stream_map=')[1].split(",")
	for i in x:
		if i.find('itag=38') <> -1:
			dl[38].append(urllib.unquote(i.split("&")[0].split("=")[1]))
			#dl[38].append(time.strftime("%Y-%m-%d %H:%M:%S",time.localtime(int(dl[38][0].split("expire=")[1].split('&')[0]))))
			dl[38].append(" ")
			dl[38].append(".mp4")
		if i.find('itag=37') <> -1:
			dl[37].append(urllib.unquote(i.split("&")[0].split("=")[1]))
			#dl[37].append(time.strftime("%Y-%m-%d %H:%M:%S",time.localtime(int(dl[37][0].split("expire=")[1].split('&')[0]))))
			dl[37].append(" ")
			dl[37].append(".mp4")
		if i.find('itag=22') <> -1:
			dl[22].append(urllib.unquote(i.split("&")[0].split("=")[1]))
			#dl[22].append(time.strftime("%Y-%m-%d %H:%M:%S",time.localtime(int(dl[22][0].split("expire=")[1].split('&')[0]))))
			dl[22].append(" ")
			dl[22].append(".mp4")
		if i.find('itag=18') <> -1:
			dl[18].append(urllib.unquote(i.split("&")[0].split("=")[1]))
			#dl[18].append(time.strftime("%Y-%m-%d %H:%M:%S",time.localtime(int(dl[18][0].split("expire=")[1].split('&')[0]))))
			dl[18].append(" ")
			dl[18].append(".mp4")
		if i.find('itag=35') <> -1:
			dl[35].append(urllib.unquote(i.split("&")[0].split("=")[1]))
			#dl[35].append(time.strftime("%Y-%m-%d %H:%M:%S",time.localtime(int(dl[35][0].split("expire=")[1].split('&')[0]))))
			dl[35].append(" ")
			dl[35].append(".flv")
		if i.find('itag=6') <> -1:
			dl[6].append(urllib.unquote(i.split("&")[0].split("=")[1]))
			#dl[6].append(time.strftime("%Y-%m-%d %H:%M:%S",time.localtime(int(dl[6][0].split("expire=")[1].split('&')[0]))))
			dl[6].append(" ")
			dl[6].append(".flv")
		if i.find('itag=34') <> -1:
			dl[34].append(urllib.unquote(i.split("&")[0].split("=")[1]))
			#dl[34].append(time.strftime("%Y-%m-%d %H:%M:%S",time.localtime(int(dl[34][0].split("expire=")[1].split('&')[0]))))
			dl[34].append(" ")
			dl[34].append(".flv")
		if i.find('itag=5') <> -1:
			dl[5].append(urllib.unquote(i.split("&")[0].split("=")[1]))
			#dl[5].append(time.strftime("%Y-%m-%d %H:%M:%S",time.localtime(int(dl[5][0].split("expire=")[1].split('&')[0]))))
			dl[5].append(" ")
			dl[5].append(".flv")	
	
	
	for i in 38,37,22,18,35,6,34,5:
		if len(dl[i]) <> 0:
			wq=wget + " -nc -U \"" + ua + "\" -O \"" + (output_dir+playlist_title(p)+"\\"+title+dl[i][2]) + "\" \"" + dl[i][0] + "\""
			print "Expires on " + dl[i][1]
			os.system(wq)
			return
			
	print "No mp4 or flv Links for " + url
	
def main():

	#total=0
	for p in open(sys.argv[1],'r'):
		if p.rstrip().find('playlist') <> -1:
			u=[]
			#print p.rstrip(),playlist_title(p),playlist_size(p)
			#print playlist_title(p)
			#total=total+playlist_size(p)		
			os.mkdir(output_dir+playlist_title(p))
			u=playlist_parse(p)
			for i in u:
				youtube_dl(i,p)
		else:
			#print url_title(p)
			#total=total+url_size(p)
			youtube_dl_url(p)
	#print str(total/(1000*1000)) + " MB"

main()
