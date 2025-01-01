# SpectreTablesStart

SpectreTablesStart is a C# console application designed to manage products using Entity Framework Core and SQL Server. This project allows users to perform CRUD operations on products, view and manage product categories, and display the product information.

## Features


- **CRUD Operations**: Add, update, delete, and view products.
- **Category Management**: Products are categorized into predefined categories like Kitchen, Cleaning, PersonalCare, and Home.
- **Database Integration**: Uses Entity Framework Core for data access with SQL Server as the database.
- **Console UI**: Uses Spectre.Console for building a beautiful console interface with tables and user prompts.

## This project uses the following NuGet packages:
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools
Microsoft.Extensions.Configuration.json

## Prerequisites

To run this project, you'll need:

- [Visual Studio](https://visualstudio.microsoft.com/) or any other C# development environment.
- [.NET SDK](https://dotnet.microsoft.com/download/dotnet) installed.
- A **SQL Server** instance running (local or remote) for database access.

## Installation

1. Clone this repository:

    ```bash
    git clone https://github.com/yourusername/SpectreTablesStart.git
    ```

2. Navigate to the project directory:

    ```bash
    cd SpectreTablesStart
    ```

3. Restore the dependencies:

    ```bash
    dotnet restore
    ```

4. Set up the database connection in the `appsettings.json` file:

    ```json
    {
      "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Database=SpectreDb;Trusted_Connection=True;TrustServerCertificate=True;"
      }
    }
    ```

5. Apply migrations and seed the database:

    ```bash
    dotnet ef database update
    ```

6. Run the application:

    ```bash
    dotnet run
    ```
  ```bash
