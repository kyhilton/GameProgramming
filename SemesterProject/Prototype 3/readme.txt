Install MAMP Server

Once installed, run then click start servers.

If sql server doesn't turn green, use task manager to end sql taks then try to start servers again.

Open your web browser and navigate to localhost/phpmyadmin/

Create a new database called fretboardfrenzy then use the sql code below in the sql feature to create a new table.



CREATE TABLE scores
(
    level INT(11) NOT NULL DEFAULT '0',
    score INT(11) NOT NULL DEFAULT '0'
)
ENGINE=InnoDB;


Place the addscore.php and display.php files in the htdocs (or WWW in some cases) folder within the MAMP folder on your pc.

Update the url string variables with the appropriate file path in the ManageStaffandFrets.cs script.