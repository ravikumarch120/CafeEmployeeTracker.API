# CafeEmployeeTracker.API

 # CafeEmployeeTracker

CafeEmployeeTracker is a .NET 9 application designed to manage cafes and their employees. This project uses ASP.NET Core for the API and Entity Framework Core for data access.

## Features

- Create, update, delete, and retrieve cafes.
- Create, update, delete, and retrieve employees.
- Track employees associated with cafes.

## Technologies Used

- .NET 9
- ASP.NET Core
- Entity Framework Core
- MediatR

## Getting Started

### Prerequisites

- .NET 9 SDK
- Visual Studio 2022

### Installation

1. Clone the repository:
git clone https://github.com/yourusername/CafeEmployeeTracker.git


2. Navigate to the project directory: cd CafeEmployeeTracker
3. Restore the dependencies: dotnet restore


### Database Setup

1. Update the connection string in `appsettings.json` to point to your database.
2. Apply migrations to create the database schema:

   dotnet ef database update
### Running the Application

1. Build the project:
    dotnet build
2. Run the project:
   dotnet run

## API Endpoints

### Cafes

- `GET /api/cafes` - Retrieve all cafes.
- `GET /api/cafes/by-location?location={location}` - Retrieve cafes by location.
- `POST /api/cafes/cafe` - Create a new cafe.
- `PUT /api/cafes/cafe` - Update an existing cafe.
- `DELETE /api/cafes/cafe/{id}` - Delete a cafe.

### Employees

- `POST /api/employees/employee` - Create a new employee.
- `PUT /api/employees/employee` - Update an existing employee.
- `DELETE /api/employees/employee/{id}` - Delete an employee.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request.

## License

This project is licensed under the MIT License.

## Contact

For any inquiries, please contact [your email].
    
    
