# ♈ Horoscope API

Uma API REST simples desenvolvida em ASP.NET Core para fornecer previsões diárias de horóscopo com base no signo do zodíaco.

---

## ✨ Funcionalidades

- 📅 Retorna o horóscopo diário de um signo
- 🔀 Estrutura limpa com separação por camadas (Controller, Service, Entidade)
- 🧩 Pronto para extensão futura com mais funcionalidades (ex: horóscopo semanal, compatibilidade, etc)

---

## 🚀 Como Executar

### Pré-requisitos

- [.NET 6 SDK](https://dotnet.microsoft.com/download) ou superior
- Git

### Passos

```bash
# Clone o repositório
git clone https://github.com/henriquewaisman/HoroscopeApi.git

# Acesse a pasta do projeto
cd HoroscopeApi

# Restaure as dependências
dotnet restore

# Execute a aplicação
dotnet run
```

A API estará disponível por padrão em:

```
https://localhost:5001
http://localhost:5000
```

---

## 📌 Exemplo de Requisição

### GET /horoscope/{sign}

**Exemplo:**

```
GET /horoscope/aries
```

**Resposta:**

```json
{
  "sign": "aries",
  "date": "2025-05-25",
  "prediction": "Hoje é um ótimo dia para novos começos."
}
```

---

## 🗂️ Estrutura do Projeto

```
HoroscopeApi/
├── Controllers/         # Controladores da API
│   └── HoroscopeController.cs
├── Entidades/           # Modelos de dados
│   └── Horoscope.cs
├── Services/            # Lógica de negócio
│   ├── IHoroscopeService.cs
│   └── HoroscopeService.cs
├── Program.cs           # Ponto de entrada da aplicação
├── appsettings.json     # Arquivo de configuração
└── dev.http             # Exemplos de requisições HTTP
```

---

## 🧠 Tecnologias Utilizadas

- C#
- ASP.NET Core Web API
- RESTful Architecture

---

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

---

## 👤 Autor

Henrique Waisman  
[GitHub](https://github.com/henriquewaisman)
