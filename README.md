# Inventory Management API

ASP.NET Core Web API for managing products, categories, and inventory stock.

## Tech Stack
- ASP.NET Core Web API
- Entity Framework Core
- In-Memory Database
- RESTful API design
- Global Exception Handling

## Features
- Category & Product management
- Stock increase/decrease with validation
- DTO-based API responses
- Global exception handling
- Clean service-layer architecture

## API Endpoints
- POST /api/categories
- GET /api/categories
- POST /api/products
- PUT /api/products/{id}
- PATCH /api/products/{id}/stock

## How to Run
```bash
dotnet restore
dotnet run
