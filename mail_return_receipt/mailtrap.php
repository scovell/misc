<?php

header('content-type:image/png');

function img($text)
{
	$image=imagecreate(200,30);
	$green=imagecolorallocate($image,200,225,100);
	$red=imagecolorallocate($image,200,0,100);
	imagestring($image,50,10,5,$text,$red);
	imagepng($image);
	imagedestroy($image);	
}

function mailshow($id)
{
	$connection=mysql_connect("localhost","root","");
	$db=mysql_select_db("testdb",$connection);
	$ip=$_SERVER["REMOTE_ADDR"];
	$t=date("H s D F d Y",time());
	$query="insert into mailtable values(\"".$id."\",\"".$ip."\",\"".$t."\");";
	mysql_query($query);
	mysql_close($connection);
}

$i=$_GET["id"];
mailshow($i);
img($i);

?>
