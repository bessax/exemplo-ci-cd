# 🚀 Projeto .NET com CI (GitHub Actions)

Este projeto demonstra a aplicação de **Integração Contínua (CI)** no contexto de DevOps, utilizando uma API em .NET, testes automatizados com xUnit e automação com GitHub Actions.

---

## 📌 Objetivo

Demonstrar na prática como:
- Automatizar o processo de build e testes
- Garantir qualidade contínua do código
- Integrar desenvolvimento com práticas DevOps

---

## 🔄 O que é CI (Integração Contínua)?

Integração Contínua (CI) é uma prática onde os desenvolvedores integram frequentemente seu código em um repositório compartilhado.

A cada alteração (commit ou pull request), um processo automatizado é executado para:
- Compilar o projeto
- Executar testes
- Validar a integridade do sistema

👉 Isso permite detectar erros rapidamente e manter o código sempre estável.

---

## 🧱 Estrutura do Projeto

```
MeuProjeto/
├── .github/
│ └── workflows/
│ └── ci.yml
├── my-app-example-ci/ # API .NET
├── my-app-exemplo-ci-tests/ # Testes (xUnit)
└── Dockerfile
```


---

## ⚙️ Tecnologias Utilizadas

- .NET 10
- xUnit (testes automatizados)
- GitHub Actions (CI)
- Docker (containerização)

---

## ⚙️ Pipeline de CI

O pipeline está configurado no arquivo:

```
.github/workflows/ci.yml
```


### 🔄 Fluxo do CI:

```
Commit / Pull Request
↓
GitHub Actions
↓
Restore → Build → Test → (Docker Build)
```

```

---

## 📄 Exemplo de Pipeline

```yaml
name: CI .NET

on:
  push:
    branches: [ "main" ]
  pull_request:

jobs:
  build-test:
    runs-on: ubuntu-latest

    steps:
    - uses: actions/checkout@v3

    - uses: actions/setup-dotnet@v4
      with:
        dotnet-version: '8.0.x'

    - run: dotnet restore

    - run: dotnet build --no-restore

    - run: dotnet test --no-build
```

## 🧪 Testes Automatizados

Os testes estão no projeto:

```
my-app-exemplo-ci-tests/
```

Utilizando xUnit, os testes garantem que a aplicação funciona corretamente a cada alteração no código.

## 🐳 Docker

O projeto também inclui um Dockerfile para empacotar a aplicação:

```
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish my-app-example-ci/my-app-example-ci.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "my-app-example-ci.dll"]
```

## 🚀 Como Executar Localmente

🔹 Rodar a API
```
dotnet run --project my-app-example-ci
```

🔹 Executar testes
```
dotnet test my-app-exemplo-ci-tests
```

🔹 Executar com Docker

```
docker build -t meu-projeto .
docker run -p 5000:80 meu-projeto
```