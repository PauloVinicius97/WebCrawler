# WebCrawler
Prova da Data Lawyer. WebCrawler de coleta de processos do Tribunal de Justiça da Bahia e CRUD destes mesmos processos, tudo via API.

## Para rodar no Visual Studio

Abra o **Console de Gerenciador de Pacotes**, mude o projeto padrão para **Libraries/WebCrawler.Data** e execute o seguinte comando:

``
Update-Database -Context WebCrawlerContext
``

Um banco de dados SQLite será criado dentro de **WebCrawler.API**.

![image](https://user-images.githubusercontent.com/29510126/234105444-d9ee0a27-f038-4ef0-b2e2-9d68d4c73cc1.png)

Defina **WebCrawler.API** como projeto de inicialização e execute-o. 

## Notas sobre o código

- Dividi a tarefa de coletar o processo do site do TJBA e fazer o CRUD em dois AppServicesm, considerando que um AppService seja um caso de uso;
- Repositórios não estão sendo utilizados.

## To-dos

Assim como um [livro nunca é terminado, mas sim abandonado](https://www.goodreads.com/quotes/192509-a-book-is-never-finished-it-s-abandoned), creio que sempre existam pontos de evolução e melhoria de um programa. Eis alguns pontos que gostaria de explorar no futuro:

- Implementar padrão Repository;
- Implementar padrão UnitOfWork;
- Implementar inversão de controle com injeção de dependência;
- Mensagens de erro mais amigáveis para alguns casos de uso da API;
- Mudar chave da entidade Processo para um ID e não o código do processo.
