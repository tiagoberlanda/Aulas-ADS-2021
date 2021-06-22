<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Desafio Formulário em PHP</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-+0n0xVW2eSR5OomGNYDnhzAbDsOXxcvSN1TPprVMTNDbiYZCxYbOOl7+AMvyTG2x" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.1/dist/js/bootstrap.bundle.min.js" integrity="sha384-gtEjrD/SeCtmISkJkNUaaKMoLD0//ElJ19smozuHV6z3Iehds+3Ulb9Bn9Plx0x4" crossorigin="anonymous"></script>
</head>

<body>
<div class="container">
        <h1>Validação Formulário PHP</h1>
        <form method="POST" action="validar.php">
            <div class="mb-2">
                <label for="nome" class="form-label">Nome</label>
                <input type="text" required class="form-control" name="nome" id="nome">
            </div>
            <div class="mb-2">
                <label for="email" class="form-label">E-mail</label>
                <input type="email" required class="form-control" name="email" id="email">
            </div>
            <div class="mb-2">
                <label for="senha" class="form-label">Senha</label>
                <input type="password" required class="form-control" name="senha" id="senha">
            </div>
            <div class="mb-2">
                <label for="telefone" class="form-label">Telefone</label>
                <input type="text" required class="form-control" name="telefone" id="telefone">
            </div>
            <button type="submit" class="btn btn-primary">Enviar</button>
        </form>
    </div>
</body>

</html>