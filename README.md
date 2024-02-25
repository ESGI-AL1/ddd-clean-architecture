# DDD-CLEAN-ARCHITECTURE

Project developed during the first year of master degree at ESGI to learn about DDD and Hexagonal / Clean Architecture
in the Software Architecture lessons. The project is centered around a genuine case study.

## Run in Docker
Requirement: Docker
```bash
  git clone https://github.com/xororist/ddd-clean-architecture
  cd ddd-clean-architecture
  docker compose up --build -d
```
Open the browser to the swagger index
```bash
  http://localhost:8080/swagger
```

## Run Locally
Requirement: .NET Core 8.0 / Nuget
```bash
  git clone https://github.com/xororist/ddd-clean-architecture
  cd ddd-clean-architecture
  dotnet restore
  cd ddd-clean-architecture/SportPourTous.Web
  dotnet run 
```

Open the browser to the swagger index
```bash
  http://localhost:5291/swagger
```

