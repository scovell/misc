<?php

$id=$_GET['id'];
$connection=mysql_connect('localhost','root','');
$db=mysql_select_db('testdb',$connection);
$query="select * from mailtable where id=\"".$id."\";";
$result=mysql_query($query);
while($r=mysql_fetch_row($result))
{
	for($i=0;$i<sizeof($r);$i++)
	{
		echo $r[$i]." ";
	}
	echo '<br/>';
}
mysql_close($connection);

?>
