
# Personal Store Builder

This project is a web application that allows users to create their own personal online store and manage their products.

## Technologies Used
- **ASP.NET Core** for building the web application.
- **PostgreSQL** as the database.

## Installation and Setup

To get this project running on your local machine, follow these steps:

### Prerequisites
- **.NET 6** or higher
- **PostgreSQL** (if using a local database or a remote database)
- **dotenv.net library** for loading environment variables from a `.env` file.

### Installation Steps

1. Clone this repository to your local machine:

   ```bash
   git clone https://github.com/amoy-81/ShopCreator.Core.git
   cd ShopCreator.Core
   ```

2. Set up the **`appsettings.json`** or **`.env`** file and add necessary values like **`CONNECTION_STRING`** and **`DATABASE_CA`**.

3. Install required packages:

   ```bash
   dotnet restore
   ```

4. Update the database using Migrations:

   ```bash
   dotnet ef database update
   ```

5. Run the application:

   ```bash
   dotnet run
   ```

   You can now access the application via **`http://localhost:80`** in your browser.

## Usage

Once the application is running, users can create their personal store through the web interface. To add products to the store, the user should enter product details and save them.

## Environmental Configuration

This project uses **dotenv.net** to load environment variables from the **`.env`** file. The **`.env`** file should contain variables like **`CONNECTION_STRING`** for database access and **`DATABASE_CA`** for the SSL certificate.

### Example of `.env` file:
```
CONNECTION_STRING="Host=your-database-host;Port=5432;Database=your-db-name;Username=your-username;Password=your-password;SSL Mode=require"
DATABASE_CA="your-ssl-certificate-in-base64"
```

## Contributing

If you'd like to contribute to this project, feel free to fork the repository and submit a **Pull Request** with your changes.

## License

This project is licensed under the **MIT License**.
