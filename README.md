# 📝 ToDo App - Clean Architecture + CQRS (.NET 8)

A modular and scalable ToDo management API built with **ASP.NET Core**, following **Clean Architecture** principles and the **CQRS** pattern.  
This project is a demonstration of building a maintainable, testable, and domain-driven backend service using modern .NET best practices.

---

## 📐 Architecture

- **Clean Architecture**:
  - `Domain`: Core business logic and entities.
  - `Application`: CQRS commands/queries + validation + handlers.
  - `Infrastructure`: Database & external service implementations (EF Core).
  - `API`: RESTful controllers + DI setup.

- **CQRS**:
  - Commands and Queries separated using `MediatR`.
  - Clear separation between write and read operations.

---

## 🧱 Tech Stack

- ASP.NET Core 8 (Web API)
- Entity Framework Core
- MediatR (CQRS handler)
- xUnit, Moq, FluentAssertions (Unit Testing)
- FluentValidation (optional)
- SQL Server / SQLite (via EF Core)

---

## 🧪 Features

- ✅ CRUD operations on `ToDoItem` (Id, Title, Description, Status)
- ✅ CQRS implementation with MediatR
- ✅ Unit tested command and query handlers
- ✅ Exception handling and `NotFound()` responses
- ✅ Clean & modular folder structure

---

## 🚀 Getting Started

1. Clone the repo  
   ```bash
   git clone https://github.com/your-username/todo-clean-architecture.git
   cd todo-clean-architecture
