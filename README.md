# Bulky (Study Project)

This repository is a study project implementing a small e-commerce-like sample using Clean Architecture principles. The goal is educational: to explore layered architecture, domain-driven design, repository/service patterns, and integration with Entity Framework Core and Razor Pages / MVC views.

## Key goals
- Learn and practice Clean Architecture separation: Domain, Application, Infrastructure, UI layers.
- Use Ardalis.Specification for query specifications and repository abstractions.
- Implement repositories, domain services, application services and simple view models.
- Practice EF Core configuration (TypeConfiguration classes) and migrations.
- Provide a small CRUD UI using Razor Pages / MVC-style controllers and views.

## Projects and structure
- Bulky.Domain: Entities, domain interfaces and domain services.
- Bulky.Application: Application-level models (AppModel) and application services.
- Bulky.Infra (or Bulky.Infra/Repository): EF Core TypeConfigurations, repositories, DbContext and migrations.
- Bulky.UI: Web project (Razor Pages / MVC controllers & views) that hosts the UI and bootstraps DI.

> Note: This workspace was built as a learning exercise; expect simplified implementations and manual mappings between models.

## Prerequisites
- .NET 8 SDK
- A supported database for EF Core (SQLite, SQL Server, etc.) — the project is configured for EF Core migrations.
- Optional: Visual Studio 2022/2026 or VS Code for editing and debugging.

## Getting started
1. Restore packages:
   dotnet restore

2. Build the solution:
   dotnet build

3. Update the database (adjust connection string in Bulky.Infra/AppDbContext or appsettings):
   dotnet ef database update --project Bulky.Infra --startup-project Bulky.UI

4. Run the UI project (from solution root):
   dotnet run --project Bulky.UI

5. Open the browser at the URL printed by the run command (typically https://localhost:5001).

## Notes and tips
- The repository uses Ardalis.Specification + Ardalis.Specification.EntityFrameworkCore; ensure the EF integration package is installed for SpecificationEvaluator usage.
- ViewModels were aligned with Application AppModel classes to keep mapping simple for study.
- Some types and configurations (for example decimal vs double for price) were chosen for clarity in EF mappings; feel free to refactor as you learn.

## Contributing / Learning
This is a personal study repository; contributions are welcome as exercises. If you fork or modify, keep changes scoped and document lessons learned in the README or new md files.

## License
MIT — feel free to reuse the code for learning and experimentation.

---
This project is intended for studying Clean Architecture and related patterns; it is not production-ready. Adjustments (validation, error handling, security, DI registration, automated tests) are expected next steps when evolving the sample.