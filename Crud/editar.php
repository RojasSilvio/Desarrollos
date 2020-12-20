<!DOCTYPE html>
<html lang="en">
<>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">

<title>PERSONAS</title>


</head>

<body>


<h1 align="center">Actualizar DATOS</h1>
<?php
    include("conexion.php");
    if (!isset($_POST["bot_actualizar"])) {//si no pulso el boton actualizar 
      $cod=$_GET["cod"];
      $nom=$_GET["nom"];
      $email=$_GET["email"];
    }else {
      $cod=$_POST["cod"];
      $nom=$_POST["nom"];
      $email=$_POST["email"];

      $sql="UPDATE datos_personas SET Nombre=:nom, Email=:email WHERE Codigo=:cod";//utilizamos marcadores, para continuar con una consulta preparada y evitar inyeccion sql.
      $resultado=$base->prepare($sql);
      $resultado->execute(array(":cod"=>$cod,":nom"=>$nom,":email"=>$email));

      header("Location:index.php");

    }
    
?>
<p>
 
</p>
<p></p>
<form name="form1" method="post" action="<?php echo $_SERVER['PHP_SELF'];//La informacion del formulario se envia a la misma pagina editar.php ?>">
  <table width="25%" border="0" align="center">
    <tr>
      <td></td>
      <td><label for="cod"></label>
      <input type="hidden" name="cod" id="cod" value="<?php echo $cod  ?>"></td>
    </tr>
    <tr>
      <td>Nombre</td>
      <td><label for="nom"></label>
      <input type="text" name="nom" id="nom" value="<?php echo $nom  ?>"></td>
    </tr>
    <tr>
      <td>Email</td>
      <td><label for="email"></label>
      <input type="text" name="email" id="email" value="<?php echo $email  ?>"></td>
    </tr>
    <tr>
      <td colspan="2"><input type="submit" name="bot_actualizar" id="bot_actualizar" value="Actualizar"></td>
    </tr>
  </table>
</form>
<p></p>
</body>
</html>