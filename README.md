# backend-challange

## Solução
Foquei em manter a solução o mais simples possível dado o problema atualmente. Existem apenas duas camadas para a arquitetura, `controllers` e `services`, este último que ficou responsável pelas validações necessárias na senha recebida.

Durante o desenvolvimento percebi que a solução poderia ser resolvida também utilizando regex. Decidi manter as validações da forma que se encontra hoje por ter uma facilidade maior ao extender o código já que não possuo um bom domínio em regex para facilmente encontrar uma solução caso as validações evoluíssem.

## Como executar o projeto

### Instalações necessárias:
Baixar e instalar o dotnet core sdk 3.1 ou superior https://dotnet.microsoft.com/download/dotnet/3.1

### Como executar o código:
- No diretório do projeto, executar o seguinte comando utilizando dotnet CLI:
```
dotnet run --project PasswordValidator
```
- No browser, postman, curl ou qualquer outra ferramenta ou tecnologia de preferência, fazer uma requisição GET para o endereço `https://localhost:5001/api/password/{senha}/is-valid`

### Executar os testes:
O projeto possui testes de unitário e de integração. Executando o comando `dotnet test` no diretório do projeto, toda a suíte de testes será executada: 