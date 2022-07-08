# Escola

## [Turma](https://escola20220707233702.azurewebsites.net/api/turmas)
* **GET**
  - Todas as Turmas
    [https://escola20220707233702.azurewebsites.net/api/turmas](https://escola20220707233702.azurewebsites.net/api/turmas)
  - Turma 1
    [https://escola20220707233702.azurewebsites.net/api/turmas/1](https://escola20220707233702.azurewebsites.net/api/turmas/1)

* **POST**
  - Incluir uma Turma
    [https://escola20220707233702.azurewebsites.net/api/turmas](https://escola20220707233702.azurewebsites.net/api/turmas)
{
  "nome": "Eletricidade e Magnetismo",
  "ativo": true
}

* **PUT**
  - Atualizar a Turma 1
  [https://escola20220707233702.azurewebsites.net/api/turmas/1](https://escola20220707233702.azurewebsites.net/api/turmas/1)
{
  "id": 1,
  "nome": "Eletricidade e Magnetismo II",
  "ativo": true
}

* **DELETE**
  - Deletar a Turma 1
    [https://escola20220707233702.azurewebsites.net/api/turmas/1](https://escola20220707233702.azurewebsites.net/api/turmas/1)

## [Aluno](https://escola20220707233702.azurewebsites.net/api/alunos/)
* **GET**
  - Todas os Alunos
    [https://escola20220707233702.azurewebsites.net/api/alunos](https://escola20220707233702.azurewebsites.net/api/alunos)
  - Aluno 1
    [https://escola20220707233702.azurewebsites.net/api/alunos/1](https://escola20220707233702.azurewebsites.net/api/alunos/1)

* **POST**
  - Incluir um Aluno
    [https://escola20220707233702.azurewebsites.net/api/alunos](https://escola20220707233702.azurewebsites.net/api/alunos)
{
  "nome": "Marina",
  "dataNascimento": "2022-07-08T16:17:23.963Z",
  "sexo": "F",
  "totalFaltas": 4,
  "turmaId": 2
}

* **PUT**
  - Atualizar o Aluno 1
  [https://escola20220707233702.azurewebsites.net/api/alunos/1](https://escola20220707233702.azurewebsites.net/api/alunos/1)
{
  "id": 1,
  "nome": "Marina",
  "dataNascimento": "2022-07-08T16:17:23.963Z",
  "sexo": "F",
  "totalFaltas": 4,
  "turmaId": 2
}

* **DELETE**
  - Deletar o Aluno 1
    [https://escola20220707233702.azurewebsites.net/api/alunos/1](https://escola20220707233702.azurewebsites.net/api/alunos/1)
