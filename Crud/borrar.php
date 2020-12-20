<?php
    include("conexion.php");
    $cod=$_GET["cod"];
    $base->query("DELETE FROM datos_personas WHERE Codigo='$cod'");
    header("Location: index.php");
?>