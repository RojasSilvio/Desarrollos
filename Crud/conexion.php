<?php
    try {
      $base=new PDO ('mysql:host=localhost; dbname=lab4','root','');
      $base->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    } catch (Exception $e) {
      echo 'ERROR '. $e->getMesange();
    }
?>