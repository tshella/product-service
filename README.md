# 🛍️ Product API (.NET 8, Docker, NGINX, Swagger)

A production-ready, containerized RESTful API built with **.NET 8** that integrates with [restful-api.dev](https://restful-api.dev).  
This API supports full **CRUD operations**, **model validation**, **logging**, and **Swagger documentation** — all behind an **NGINX reverse proxy**.

---

## 📦 Features

- ✅ Full CRUD: `GET`, `POST`, `PUT`, `DELETE`
- 🔍 Filter products by name (substring) + pagination
- 🧾 OpenAPI docs via Swagger UI
- 🛡️ Model validation using FluentValidation
- 📊 Structured logging via Serilog
- 🌐 Reverse-proxied with NGINX (ideal for Docker deployment)
- ⚙️ Compatible with [https://restful-api.dev](https://restful-api.dev)

---

## 🏗️ Technologies

- [.NET 8.0](https://dotnet.microsoft.com/)
- Docker & Docker Compose
- NGINX
- FluentValidation
- Serilog
- Swagger / Swashbuckle

---

## 🚀 Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/your-username/product-api.git
cd product-api

2. Build & Run with Docker

docker compose up --build

Your API will be available at:
📍 http://localhost:8080/swagger
🧪 API Endpoints
Method	Endpoint	Description
GET	/api/Products	List products (with filter)
GET	/api/Products/{id}	Get product by ID
POST	/api/Products	Add new product
PUT	/api/Products/{id}	Update product
DELETE	/api/Products/{id}	Delete product
🧾 Sample Request (POST)

POST /api/Products
Content-Type: application/json

{
  "name": "Laptop",
  "description": "Slim and powerful",
  "price": 1999.99
}

⚙️ Project Structure

.
├── Controllers/         # API endpoints
├── Services/            # Integration with restful-api.dev
├── Models/              # DTOs
├── Validators/          # FluentValidation rules
├── Middlewares/         # Global error handling
├── nginx/               # NGINX reverse proxy config
├── Program.cs           # App startup
├── docker-compose.yml   # Docker Compose services
├── Dockerfile           # API container
└── README.md            # This file

📖 Swagger UI

Once running, access:

http://localhost:8080/swagger

You'll see:

    Interactive API documentation

    JSON schema validation

    Try-it-out functionality

📚 Further Improvements (Suggestions)

    🔐 Add JWT authentication

    📈 Add Prometheus metrics and Grafana dashboards

    🧪 Reintroduce unit tests (xUnit + Moq)

    ☁️ Deploy to cloud (Azure App Service, AWS ECS, etc.)

    🛂 Add rate limiting or caching (Redis)

🧑‍💻 Author

Anthony Raphasha
💼 Full-Stack Developer | Microservice Architect
🌍 Johannesburg, South Africa
📄 License

