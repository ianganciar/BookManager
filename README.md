
# BookManager

API desenvolvida para o gerenciamento de emprestimos de livros.


## Funcionalidades

- CRUD Livros.
- CRUD Usuários.
- CRUD Empréstimos.
- Empréstimo só pode ser feito caso o livro esteja disponível em estoque.
- Consultar todos os empréstimos de um usuário.
- Consultar todos os empréstimos de um livro.
- Enviar um alerta com uma mensagem com os dias de atraso, quando for feita a devolução de um empréstimo com a data atual maior que data esperada de devolução.
- Ao realizar um empréstimo o estoque do livro relacionado é decrescido.
- Ao devolver um empréstimo o estoque do livro relacionado é acrescido.

## Tecnologias e Ferramentas

- Clean architecture
- Padrão Repository
- Entity Framework Core
- SQL Server
- .Net 6


## Autor

- [Ian Ganciar](https://www.linkedin.com/in/ianganciar/)

