# milesbellaireBE

Backend API for [milesbellaire.com](https://milesbellaire.com) - A personal portfolio website.

## Technologies

- **.NET 8.0** - Runtime and framework
- **ASP.NET Core Web API** - RESTful API framework
- **Entity Framework Core 8.0** - ORM
- **MySQL with Pomelo provider** - Database
- **AutoMapper** - Object-to-object mapping
- **Swashbuckle** - Swagger/OpenAPI documentation
- **Docker** - Containerization

## Project Structure

```
milesbellaireBE/
├── milesbellaireBE/
│   ├── Api/                    # API controllers and DTOs
│   │   ├── Controllers/        # REST controllers
│   │   │   ├── ContactMeController.cs
│   │   │   ├── PersonalProjectController.cs
│   │   │   └── WorkExperienceController.cs
│   │   └── Dtos/               # Data transfer objects
│   ├── EntityFramework/        # Data layer
│   │   ├── Models/             # EF Core models
│   │   │   ├── BaseEntity.cs
│   │   │   ├── Experience.cs
│   │   │   ├── PersonalProject.cs
│   │   │   ├── WorkExperience.cs
│   │   │   ├── Message.cs
│   │   │   └── Tag.cs
│   │   └── DatabaseContext.cs  # DbContext configuration
│   ├── Program.cs              # Application entry point
│   ├── appsettings.json        # Configuration
│   └── mbCore.csproj          # Project file
├── dockerfile                  # Docker build configuration
└── milesbellaireBE.sln        # Solution file
```

## Database Models

| Entity | Description |
|--------|-------------|
| `WorkExperience` | Work history with position, dates, and image |
| `PersonalProject` | Personal projects with tags and images |
| `Message` | Contact form messages from users |
| `Tag` | Tags for categorizing projects and experiences |

## API Endpoints

### Personal Projects
- `GET /api/personal-project` - List all personal projects (ordered by priority)
- `POST /api/personal-project` - Create a new personal project
- `PUT /api/personal-project/{id}` - Update a personal project
- `DELETE /api/personal-project/{id}` - Delete a personal project
- `POST /api/personal-project/file/{id}` - Upload project image

### Work Experience
- `GET /api/work-experience` - List all work experiences (ordered by priority)
- `POST /api/work-experience` - Create a new work experience
- `PUT /api/work-experience/{id}` - Update a work experience
- `DELETE /api/work-experience/{id}` - Delete a work experience

### Contact Messages
- `POST /api/contact-me` - Submit a contact message

## Development

### Prerequisites

- .NET 8.0 SDK
- MySQL 8.0+
- Docker (for containerized development)

### Local Development

1. Clone the repository
2. Update `appsettings.json` with your MySQL connection string:
```json
{
  "ConnectionStrings": {
    "mysql": "Server=localhost;Database=milesbellairedb;User=your_user;Password=your_password;"
  }
}
```

3. Create the MySQL database
4. Run migrations:
```bash
dotnet ef database update
```

5. Run the application:
```bash
dotnet run
```

The API will be available at `https://localhost:7000` (or `http://localhost:5084` in development).

6. Access Swagger UI at `https://localhost:7000/swagger` for interactive API documentation.

### Docker

Build and run using Docker:
```bash
docker build -t milesbellairebe .
docker run -p 8080:8080 milesbellairebe
```

The API will be available at `http://localhost:8080`.

### Project Settings

- **Port**: Development uses HTTPS on port 7000
- **CORS**: Configured for localhost:3001, 5084, 7229
- **Database**: Auto-migration on startup
- **Image Storage**: Images stored as byte arrays in the database

## Configuration

The application uses the following configuration sections in `appsettings.json`:

| Setting | Description |
|---------|-------------|
| `ConnectionStrings.mysql` | MySQL database connection string |
| `AllowedOrigins` | Array of allowed CORS origins |

## Building the Project

```bash
# Restore dependencies
dotnet restore

# Build
dotnet build

# Build release
dotnet build --configuration Release
```

## Running Tests

```bash
dotnet test
```