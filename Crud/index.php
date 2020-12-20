<!DOCTYPE html>
<html lang="en">
<>
  <meta charset="UTF-8">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <title>PERSONAS</title>


  </head>

  <body>
    <?php
    include("conexion.php");
    $registros = $base->query("SELECT * FROM datos_personas")->fetchAll(PDO::FETCH_OBJ); //array de objeto

    if (isset($_POST["bot_insertar"])) {
      $nombre = $_POST["nombre"];
      $email = $_POST["email"];

      $sql = "INSERT INTO datos_personas (Nombre,email) VALUES (:nom,:email)"; //istruccion sql
      $resultado = $base->prepare($sql); //consulta preparada
      $resultado->execute(array(":nom" => $nombre, ":email" => $email));
      header("Location:index.php");
    }
    ?>

    <h1 align="center">Lista Personas </h1>
    <form action="<?php echo $_SERVER['PHP_SELF']; ?>" method="post">
      <table width="50%" border="0" align="center">
        <tr>
          <td class="primera_fila">Codigo</td>
          <td class="primera_fila">Nombre</td>
          <td class="primera_fila">Email</td>
        </tr>
        <?php
        foreach ($registros as $persona) : ?>

          <tr>
            <td><?php echo $persona->Codigo ?> </td>
            <td><?php echo $persona->Nombre ?> </td>
            <td><?php echo $persona->Email ?> </td>

            <td class='bot'><a href="borrar.php?cod=<?php echo $persona->Codigo ?>"><input type='button' name='del' id='del' value='Borrar'></a></td>
            <td class='bot'><a href="editar.php?cod=<?php echo $persona->Codigo ?> & nom=<?php echo $persona->Nombre ?> & email=<?php echo $persona->Email ?>"><input type='button' name='up' id='up' value='Actualizar'></a></td>
          </tr>
        <?php
        endforeach;

        ?>
        <tr>
          <td></td>
          <td><input type='text' name='nombre' size='10' class='centrado'></td>
          <td><input type='text' name='email' size='18' class='centrado'></td>
          <td class='bot'><input type='submit' name='bot_insertar' id='bot_insertar' value='Insertar'></td>
        </tr>
      </table>
    </form>
    <p></p>
  </body>

</html>