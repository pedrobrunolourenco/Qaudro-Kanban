# Qaudro-Kanban
 Desafio-LetsCode

1) Definir como Set As Startup Project o projeto Api-Quadro-Kanban, disponibilizado na pasta lógica 1-API-REST.

2) Sobre este mesmo projeto, clicar com o botão direito do mouse e selecionar Manage User Secrets.

3) Em secrets.json gravar a seguinte estrutura:

 "Acesso": {
    "login": "xxxxxxx",
    "senha": "yyyyyyy"
  }

4) Caso não se queira trabalhar com o Secrets.Json, a mesma estrutura de acesso está disponível em AppSettings.Json,
caso o Secrets.Json não for definido, o sistema irá levar em conta, o login e senha definido no grupo ACESSO de AppSettings.Json ou
em Secrets.Json, sendo que Secrets.Json é prioritário caso exista.

5) Ao levantar o sistema, na sessão SEGURANCA do Swagger, executar o método Post Gerar-Token, passando o Login e Senha defindos
nas etapas anteriores. Um Token será gerado.

6) No Botão Authorize do Swagger, no campo Value digitar a palavra Bearer um espaco e colar o Token adquirido no item 5.

7) O restante dos métodos estão disponíveis na Sessão QUADRO do Swagger. Todos os métodos desta sessão exigem ser autenticados através
   do token. A Autenticação é feita pelo decorator Authorize.

   


















