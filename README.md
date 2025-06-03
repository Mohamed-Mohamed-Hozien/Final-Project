# Final Project Database

## Overview
This is an ASP.NET Core web application built with .NET 7.0. The project appears to be a web-based system that includes features for managing inventory and jobs, as indicated by the CSS files in the project structure.

## Prerequisites
- .NET 7.0 SDK or later
- SQL Server (based on the SQL Client dependencies)
- Visual Studio 2022 or Visual Studio Code with C# extensions

## Project Structure
```
Final Project/
├── Pages/           # Razor Pages for the web application
├── Models/          # Data models
├── wwwroot/         # Static files (CSS, JavaScript, images)
│   └── css/        # Stylesheets
│       ├── inventory.css
│       ├── jobs.css
│       ├── Layout.css
│       └── site.css
├── Properties/      # Project properties and configuration
├── Program.cs       # Application entry point
└── appsettings.json # Application configuration
```

## Dependencies
- Microsoft.Data.SqlClient (v5.1.2)
- System.Data.SqlClient (v4.8.5)

## Getting Started

1. Clone the repository
```bash
git clone [repository-url]
```

2. Navigate to the project directory
```bash
cd Final-Project
```

3. Restore dependencies
```bash
dotnet restore
```

4. Build the project
```bash
dotnet build
```

5. Run the application
```bash
dotnet run
```

The application should now be running at `https://localhost:5001` or `http://localhost:5000`.

## Features
- Inventory Management System
- Jobs Management System
- Responsive Web Design (based on CSS files)

## Development
This project uses:
- ASP.NET Core 7.0
- Razor Pages for the frontend
- SQL Server for data storage
- Custom CSS for styling

## Configuration
The application can be configured through:
- `appsettings.json` - Main configuration file
- `appsettings.Development.json` - Development-specific settings

## Contributing
1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request

## License
[Add your license information here]

## Contact
[Add your contact information here] 