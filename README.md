# ♈ Horoscope API

Uma API REST simples desenvolvida em ASP.NET Core para fornecer previsões de horóscopo com base no signo do zodíaco.

---

## ✨ Funcionalidades

- 📅 Retorna o horóscopo diário, semanal ou mensal (a depender do plano do usuário) de um signo
- 🔀 Estrutura limpa com separação por camadas (Controller, Service, Entidade)

---

## 🚀 Como Executar

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download) ou superior
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
  "date": "2025-05-25",
  "horoscope_data": "Hoje é um ótimo dia para novos começos."
}
```

---

## 🗂️ Estrutura do Projeto

```
HoroscopeApi/
├── Controllers/        
│   ├── BronzeController.cs # Controlador do Plano Bronze (retorna previsão mensal)
│   ├── SilverController.cs # Controlador do Plano Prata (retorna previsão semanal)
│   └── GoldController.cs   # Controlador do Plano Ouro (retorna previsão diária)
├── Entidades/           
│   └── HoroscopoData/ # Acessa a mensagem da previsão e a data especificada pelo plano no arquivo Json da API
│       ├── BronzeData.cs # Recupera o mês e sua mensagem
│       ├── SilerData.cs  # Recupera a semana e sua mensagem
│       └── GoldData.cs   # Recupera o dia e sua mensagem
│   └── HoroscopoResponse/ # Usa o "TierData" e transforma em uma response para a API
│       ├── BronzeResponse.cs
│       ├── SilerResponse.cs
│       └── GoldResponse.cs
├── Services/           
│   └── HoroscopeService.cs # Lógica do négocio proposto
├── Program.cs           # Ponto de entrada da aplicação
├── Cliente/   
│   ├── templates/
│       ├── login.html # Página web do login
│       ├── register.html # Página web do cadastro
│       ├── menu.html # Página web do menu que permite pedir as mensagens
│       ├── result.html # Página web com o resultado da requisição
├── users.db # Banco SQLIte para guardar os usuários
└── app.py # Aplicação do cliente


```

---

## 🧠 Tecnologias Utilizadas

- C#
- ASP.NET Core Web API
- RESTful Architecture
- Python
- SQLite
- Flask

---
## 🖼️ Diagrama da Aplicação
![diagrama](https://github.com/henriquewaisman/HoroscopeApi/blob/main/diagrama.png)
