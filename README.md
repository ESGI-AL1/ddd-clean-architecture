# DDD-CLEAN-ARCHITECTURE

Project developed during the first year of master degree at ESGI to learn about DDD and Hexagonal / Clean Architecture
in the Software Architecture lessons. The project is centered around a genuine case study.


### Roadmap & Different Architectures:
Different approaches and roadmap available here on this link:
[Roadmap & Different Architectures](https://miro.com/welcomeonboard/TWtzRGNQRnh4ak9OTEUyTE5WV1ZaTzlMUWdPWXpFWjV5ZnIyekxXbllLendrTHNKeThFTllPVFdtb091SDVsU3wzNDU4NzY0NTc5ODU2MTMwOTQwfDI=?share_link_id=520693164688)

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

