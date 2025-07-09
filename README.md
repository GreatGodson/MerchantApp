# 🏪 Merchant Management API

A cleanly architected ASP.NET Core Web API for managing **Merchants** at Go Tap. This service implements **CRUD operations**, **CQRS with MediatR**, and validates **country information** using an external API.

---

## 🚀 Features

- ✅ Create, Read, Update, and Delete merchants
- ✅ Clean Architecture with clear separation of concerns
- ✅ CQRS pattern using MediatR
- ✅ External API integration to validate merchant's country
- ✅ Asynchronous programming with `async/await`
- ✅ Testable and maintainable codebase
- ✅ JSON Enum support for `Status`

---

## 📦 Technologies

- .NET 8 / ASP.NET Core
- MediatR
- FluentValidation
- HttpClientFactory
- Swagger / Swashbuckle (API Docs)

---

## 🧱 Architecture Overview

This project follows **Clean Architecture** principles and includes the following layers:

├── Domain → Entities and Enums (pure business logic)
├── Application → CQRS (Commands/Queries), Interfaces, DTOs, Validators
├── Infrastructure → External API services, EF Core repository implementations
├── WebAPI → API controllers, DI configuration, middleware
└── Tests → Unit tests for Application logic (handlers, services)

---

## 🧾 Merchant Entity

```csharp
public class Merchant : IdentityUser
{
    public string BusinessName { get; set; }
    public string Country { get; set; }
    public MerchantStatus Status { get; set; }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum MerchantStatus
{
    Pending,
    Active,
    Inactive
}
```

📡 External API Integration

Before creating or updating a merchant with a country, the API validates the country using:

🔗 https://restcountries.com/v3.1/name/{country}
• ✅ 200 OK → Valid country
• ❌ 404 Not Found → Returns 400 Bad Request with message: "Invalid country provided."

🛣️ API Endpoints

🔍 Get Merchant by ID
GET /api/merchants/{id}
• ✅ 200 OK → Merchant found
• ❌ 404 Not Found → Merchant not found

📃 Get All Merchants
GET /api/merchants
• ✅ 200 OK → List of merchants

POST /api/merchants
• Validates country before creation
• ❌ 400 Bad Request → Duplicate email or invalid country
• ✅ 201 Created → Merchant created

PUT /api/merchants/{id}
• Accepts only updatable fields (e.g., PhoneNumber, BusinessName, Country, Status)
• Ignores Id from body (only in URL)
• ❌ 400 Bad Request → Invalid country
• ✅ 204 No Content

DELETE /api/merchants/{id}
• ✅ 204 No Content → Deleted successfully
• ❌ 404 Not Found → Merchant doesn’t exist

🔧 Getting Started

1. Clone the repo
   git clone https://github.com/your-org/merchant-api.git

2. Restore packages
   dotnet restore

3. Run the API
   dotnet run --project MerchantApp.WebAPI

4. Visit Swagger UI
   https://localhost:<port>/swagger

💡 Best Practices Followed
• ✅ Clean Architecture
• ✅ CQRS + MediatR
• ✅ Async/await for I/O operations
• ✅ Dependency injection everywhere
• ✅ Resilient external API calls
• ✅ Clear validation and error handling
