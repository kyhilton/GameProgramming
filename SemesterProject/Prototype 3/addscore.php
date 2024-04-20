<?php

$hostname = 'localhost';
$username = 'root';
$password = 'root';
$database = 'fretboardfrenzy';
$secretKey = "mySecretKey";
 
try 
{
	$dbh = new PDO('mysql:host='. $hostname .';dbname='. $database, 
           $username, $password);
} 
catch(PDOException $e) 
{
	echo '<h1>An error has ocurred.</h1><pre>', $e->getMessage() 
            ,'</pre>';
}
 
$hash = $_GET['hash'];
$realHash = hash('sha256', $_GET['level'] . $_GET['score'] . $secretKey);
	
if($realHash == $hash) 
{ 
	$sth = $dbh->prepare('INSERT INTO scores VALUES (:level
            , :score)');
	try 
	{
		$sth->bindParam(':level', $_GET['level'], 
                  PDO::PARAM_INT);
		$sth->bindParam(':score', $_GET['score'], 
                  PDO::PARAM_INT);
		$sth->execute();
	}
	catch(Exception $e) 
	{
		echo '<h1>An error has ocurred.</h1><pre>', 
                 $e->getMessage() ,'</pre>';
	}
}
?>