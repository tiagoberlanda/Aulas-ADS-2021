<?php 
 
echo '<head>
<meta charset="UTF-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-+0n0xVW2eSR5OomGNYDnhzAbDsOXxcvSN1TPprVMTNDbiYZCxYbOOl7+AMvyTG2x" crossorigin="anonymous">
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-gtEjrD/SeCtmISkJkNUaaKMoLD0//ElJ19smozuHV6z3Iehds+3Ulb9Bn9Plx0x4" crossorigin="anonymous"></script>
<title>PHP Post</title>
</head>';
 
$invalido = false;
$nome = $_POST['nome'];
$email = $_POST['email'];
$senha = $_POST['senha'];
$telefone = $_POST['telefone'];

if(strlen($nome) < 10){
    echo '<div class="alert alert-danger" role="alert">
    Esse nome é muito pequeno, tente outro!
  </div>';
  $invalido = true;
} elseif (!filter_var($email, FILTER_VALIDATE_EMAIL)) {
    echo '<div class="alert alert-danger" role="alert">
    Esse e-mail é inválido, tente novamente!
  </div>';
  $invalido = true;
} elseif ( strlen($senha) <= 8 ){
    echo '<div class="alert alert-danger" role="alert">
    A senha não atende aos requisitos mínimos de senha segura, tente novamente!
  </div>';
  $invalido = true;
} elseif (strlen ($telefone) <= 10) {
    echo '<div class="alert alert-danger" role="alert">
    O Número de telefone deve ter pelo ou menos 10 dígitos!
  </div>';
  $invalido = true;
}
 
if (!$invalido) {
    echo '<div class="alert alert-success" role="alert">
    Usuário criado com sucesso!
  </div>';
}
 
echo '<a href="formulario.php" class="btn btn-primary">Voltar</a>';
?>
