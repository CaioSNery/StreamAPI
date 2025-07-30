# 🎬 StreamAPI

Uma API desenvolvida com ASP.NET Core para gerenciamento de um sistema de streaming **fictício**, com funcionalidades como cadastro de clientes, controle de assinaturas, envio de confirmação por e-mail, e permissões para assistir conteúdos com base na assinatura.

---

## ⚙️ Tecnologias Utilizadas

- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- Injeção de Dependência
- Swagger
- Envio de E-mail com SMTP
- Regras de negócio personalizadas
- Mapeamento de objetos com AutoMapper 🔄
- Autenticação com JWT 🔐 
- Deploy no Azure App Service🚀

  
---

## 📌 Funcionalidades

### ✅ Funcionalidades já implementadas:

- 📧 **Cadastro de Cliente com envio de e-mail** de confirmação de assinatura.
- 🔐 **Restrição de acesso**: Clientes sem assinatura ativa (`assinatura == false`) não conseguem acessar os endpoints de visualização.
- 🎥 **CRUD de Filmes**
- 📺 **CRUD de Séries**, com:
  - 📚 Adição de Temporadas
  - 🎞️ Cadastro de Episódios por Temporada
- 👤 **CRUD de Clientes**

---

## 📬 Envio de E-mail

- Ao cadastrar um novo cliente, é enviado um e-mail confirmando o registro e a ativação da assinatura.

---

## 🔒 Regras de Negócio

- **Clientes sem assinatura ativa não podem consumir conteúdos**, como visualizar filmes ou episódios.
- Essa validação é aplicada em todos os endpoints de visualização.

---

## 🔄 Endpoints Disponíveis

Todos os endpoints seguem o padrão REST e estão documentados via Swagger:

📎 Acesse a documentação interativa:  
`https://streamapi.azurewebsites.net/swagger`

### Exemplos:

- `POST /api/cliente` → Cadastra um cliente e envia e-mail  
- `GET /api/filme` → Lista todos os filmes (restrito a assinantes)  
- `POST /api/serie` → Cadastra uma série  
- `POST /api/serie/{id}/temporada` → Adiciona uma temporada  
- `POST /api/temporada/{id}/episodio` → Adiciona um episódio  

---

## 🧪 Finalidade do Projeto

> Este projeto foi desenvolvido com **fins de aprendizado**.  
> Os dados utilizados são fictícios e armazenados em banco SQL Server local ou em nuvem.

---

## 🔜 Funcionalidades Futuras

- [ ] Autenticação com **JWT**
- [ ] Integração com **Twilio** para envio de SMS
- [ ] Implementação de **AutoMapper**

---




