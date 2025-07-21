# Projeto: Repositório GitHub Viewer

Este projeto consiste em uma aplicação que consome a API do GitHub e permite visualizar repositórios públicos, com funcionalidades como favoritar, desfavoritar e buscar repositórios relevantes.

## Tecnologias utilizadas

- **Angular** (Frontend)
- **.NET Core / ASP.NET** (Backend)
- **GitHub REST API**
- **TypeScript / C#**
- **Node.js / NPM**

---

## Estrutura do Projeto

O projeto está dividido em duas partes principais:

**repositorio-api-net7**: onde está a API desenvolvida em ASP.NET Core. Nessa parte ficam os controllers, services, models e demais configurações relacionadas ao backend. A organização segue uma estrutura baseada em princípios do Domain-Driven Design (DDD).

**repositorio-web-angular**: onde está o frontend feito em Angular. Aqui estão os componentes, interfaces, serviços e tudo que envolve a interface visual e interação com o usuário.

---

## Como executar o projeto localmente
### Pré-requisitos
Antes de começar, você vai precisar ter instalado em sua máquina:

- **Node.js v22.17.0**
- **Angular**
- **.NET SDK**
- **Um editor como Visual Studio Code ou outro de sua preferência**
- **Visual Studio 2022 (com suporte a .NET)**

---

## Inicializando o Frontend (Angular)

```text
cd repositorio-web-angular
npm install
npm start
```
Depois de iniciar, o projeto Angular ficará disponível em: http://localhost:4200

---

## Inicializando o Backend (ASP.NET Core)

1. Abra o Visual Studio
2. Vá em Arquivo > Abrir > Projeto/Solução e selecione o item de inicialização "RepositorioApi.API"
3. Pressione F5 ou clique em Iniciar Depuração para executar a API

A API estará disponível por padrão em: https://localhost:7132
(Verifique se a porta pode variar conforme seu perfil de execução)
