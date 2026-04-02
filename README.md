ApiControleDeEstoque
📦 Descrição

A ApiControleDeEstoque é uma API RESTful desenvolvida em .NET 9.0 utilizando Entity Framework Core e PostgreSQL para gerenciamento de produtos em um sistema de estoque.
Permite operações completas de CRUD (Create, Read, Update, Delete) e suporta atualizações parciais (PATCH) para facilitar a manutenção de produtos.

O projeto foi desenvolvido como exercício prático de implementação de APIs profissionais, seguindo boas práticas de arquitetura, separação de camadas e documentação via Swagger.

⚙️ Tecnologias Utilizadas
C# / .NET 9.0
Entity Framework Core
PostgreSQL
Swagger / OpenAPI (para documentação e testes)
Git & GitHub (para versionamento)
VSCode / Visual Studio (IDE)
🛠️ Instalação e Configuração
Clone o repositório:
git clone https://github.com/GabrielCrespin/ApiControleDeEstoque.git
cd ApiControleDeEstoque/ControleDeEstoque
Instale os pacotes necessários:
dotnet restore
Configure a string de conexão com o PostgreSQL no arquivo appsettings.json:
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=ControleEstoque;Username=postgres;Password=senha"
}
Crie o banco de dados e aplique as migrations:
dotnet ef database update
Execute a API:
dotnet run
🚀 Endpoints da API

Todos os endpoints estão documentados via Swagger, acessível em:

http://localhost:<porta>/swagger
Produtos
Método	Endpoint	Descrição
GET	/api/produto	Lista todos os produtos
GET	/api/produto/{id}	Consulta um produto pelo ID
POST	/api/produto	Cria um novo produto
PUT	/api/produto/{id}	Atualiza um produto inteiro
PATCH	/api/produto/{id}	Atualiza parcialmente um produto
DELETE	/api/produto/{id}	Remove um produto do estoque

Nota: O ID do produto é gerado automaticamente pelo sistema, não é necessário enviar no POST.

📌 Boas Práticas Implementadas
Arquitetura em camadas: Controllers, Services, Models, DbContext.
Injeção de dependência do AppDbContext e do ProdutoService.
Async/Await para operações com banco de dados, garantindo performance.
PATCH para atualizações parciais de recursos.
.gitignore configurado corretamente para ignorar arquivos binários, pastas temporárias e secrets.
🔐 Próximos Passos / Melhorias
Validações de entrada e tratamento de exceções na API.
Autenticação e autorização para proteger endpoints.
Testes unitários e integração.
Implementação de logs avançados e monitoramento.
📄 Licença

Este projeto é open source. Sinta-se à vontade para utilizar, modificar e contribuir.
