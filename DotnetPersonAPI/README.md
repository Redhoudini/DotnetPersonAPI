# Dotnet Person API

A simple REST API built with ASP.NET Core Minimal API, Entity Framework Core, and PostgreSQL.

The project demonstrates a basic CRUD backend setup with Dockerized PostgreSQL and EF Core migrations.

## Features

- Create, read, update, and delete people
- ASP.NET Core Minimal API
- Entity Framework Core
- PostgreSQL database
- Docker for database setup
- Seed data on startup

## Tech Stack

- C#
- ASP.NET Core
- Entity Framework Core
- PostgreSQL
- Docker

## Project Structure

- `Models/` → domain models
- `Data/` → database context
- `Migrations/` → EF Core migrations
- `Program.cs` → API endpoints and app setup
- `docker-compose.yml` → PostgreSQL container setup

## How to run

### 1. Start PostgreSQL with Docker

```bash
docker compose -f docker-compose.yml up -d
```

### 2. Apply migrations

```bash
dotnet ef database update
```

### 3. Run the API

```bash
dotnet run
```

## Endpoints

### Get all people
```http
GET /people
```

### Get person by id
```http
GET /people/{id}
```

### Create Person
```http
POST /people
```
Example request body:
```json
{
  "name": "Christoffer",
  "age": 31
}
```
### Update person
```http
PUT /people/{id}
```

### Delete person
```http
DELETE /people/{id}
```

## What I learned
- Building a REST API with ASP.NET Core Minimal API
- Using Entity Framework Core with PostgreSQL
- Creating and applying migrations
- Running supporting services with Docker
- Structuring a simple backend project

## Future improvements

- Add Swagger / OpenAPI
- Add validation
- Add DTOs and service layer
- Run both API and database fully in Docker
