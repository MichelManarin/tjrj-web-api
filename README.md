# WEBAPI
Utilizando .NET 8, desenvolvi uma solução composta por uma web API para gerenciar livros, assuntos, autores e precificação. A solução contém dois projetos: um para a web API e outro para testes unitários dos controllers. No mundo real, apenas a web API seria publicada, enquanto os testes são para verificação interna.

O Entity Framework Core é usado para criar e gerenciar todos os objetos do banco de dados, incluindo views, adotando a estratégia code-first, o que facilita a implementação do modelo de dados.

A arquitetura da API está dividida em três camadas: Core, Infrastructure e Presentation, cada uma com responsabilidades específicas:

Core: Contém serviços que abstraem a lógica de negócios.
Infrastructure: Gerencia o acesso aos dados via ORM.
Presentation: Define os controladores e DTOs (view models).
O fluxo de requisição começa no controller, onde o ViewModel valida a entrada via DataAnnotations. Em seguida, o serviço executa a lógica de negócios e chama o repositório. Utilizei o padrão Repository para facilitar a manutenção e testes.

No método ConfigureServices da classe Program.cs, configurei a injeção de dependências para serviços e repositórios, seguindo os princípios SOLID.

Para geração de relatórios, utilizei o iTextSharp, que, embora não seja um gerador de relatórios específico, cumpre a função com eficiência e simplicidade.

# Unit Tests e TDD
O projeto CloudBook.UnitTests referencia a API e realiza testes mockados nos controllers e serviços, garantindo a segurança para futuras implementações. Focalizei os testes nos controllers de assuntos, autores e livros, totalizando 27 testes unitários.

Essa abordagem garante uma estrutura bem organizada, facilitando a manutenção, a expansão do projeto e a garantia de qualidade através dos testes automatizados.

![image](https://github.com/user-attachments/assets/f781a8ea-3c47-437e-a340-e0dfa3a121a3)
![image](https://github.com/user-attachments/assets/c720bae2-2f88-46dc-b554-b208f0123c75)
