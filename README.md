# Survivor API

Survivor API is a .NET 8 web API project designed to manage competitors and categories for a Survivor-like competition. This API allows you to perform CRUD operations on competitors and categories.

## Table of Contents

- [Features](#features)
- [Technologies](#technologies)
- [Getting Started](#getting-started)
- [Endpoints](#endpoints)
- [Contributing](#contributing)
- [License](#license)

## Features

- Manage competitors and categories.
- Perform CRUD operations on competitors and categories.
- Retrieve competitors by category.

## Technologies

- .NET 8
- Entity Framework Core
- ASP.NET Core Web API

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) or any other compatible database

### Installation

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/AhmetSulu/Survivor.git
2.  **Navigate to the Project Directory**:
    ```bash
    cd Survivor

3. Update the database connection string in `appsettings.json`:
   ```bash
    "ConnectionStrings": {
    "DefaultConnection": "Server=your_server;Database=SurvivorDb;User Id=your_user;Password=your_password;"
    }


4. Apply the migrations and update the database:
   ```bash
    dotnet ef database update
   
6.  **Run the Application**:
    ```bash
    dotnet run
   
## Endpoints

### Competitors

- **GET /api/competitors**: Retrieve all competitors.
- **GET /api/competitors/{id}**: Retrieve a competitor by ID.
- **GET /api/competitors/categories/{categoryId}**: Retrieve competitors by category ID.
- **POST /api/competitors**: Create a new competitor.
- **PUT /api/competitors/{id}**: Update an existing competitor.
- **DELETE /api/competitors/{id}**: Delete a competitor.

### Categories

- **GET /api/categories**: Retrieve all categories.
- **GET /api/categories/{id}**: Retrieve a category by ID.
- **POST /api/categories**: Create a new category.
- **PUT /api/categories/{id}**: Update an existing category.
- **DELETE /api/categories/{id}**: Delete a category.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request for any changes.

1. Fork the repository.
2. Create a new branch (`git checkout -b feature/your-feature`).
3. Commit your changes (`git commit -am 'Add some feature'`).
4. Push to the branch (`git push origin feature/your-feature`).
5. Create a new Pull Request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contact

For any questions or support, please email ahmet.sulu1993@gmail.com
