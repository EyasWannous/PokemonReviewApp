# Pokemon Review App

The Pokemon Review App is a web application that allows users to review Pokémon. The application provides a set of APIs to manage Pokémon, categories, countries, owners, reviews, and reviewers.

## Features

- User registration and authentication
- CRUD operations for Pokémon, categories, countries, owners, reviews, and reviewers
- JWT token-based authentication
- Admin role management
- Profiling middleware

## Project Structure

- **Controllers**: Handles HTTP requests and responses
- **DTO (Data Transfer Objects)**: Defines the data structures for communication between client and server
- **Interfaces**: Defines the contract for the repositories
- **Migrations**: Handles database schema changes
- **Middlewares**: Custom middleware components
- **Models**: Represents the data structure of the application
- **Repositories**: Contains the data access logic
- **Services**: Provides additional business logic

## API Endpoints

### AccountController

- `POST /api/account/register`: Register a new user
- `POST /api/account/login`: Log in a user

### AdminController

- `GET /api/admin/users`: Get all users with their roles
- `PUT /api/admin/user/{userId}/role`: Update the role of a user

### CategoryController

- `GET /api/categories`: Get all categories
- `GET /api/categories/{categoryId}`: Get a category by ID
- `POST /api/categories`: Create a new category
- `PUT /api/categories/{categoryId}`: Update a category
- `DELETE /api/categories/{categoryId}`: Delete a category

### CountryController

- `GET /api/countries`: Get all countries
- `GET /api/countries/{countryId}`: Get a country by ID
- `POST /api/countries`: Create a new country
- `PUT /api/countries/{countryId}`: Update a country
- `DELETE /api/countries/{countryId}`: Delete a country

### OwnerController

- `GET /api/owners`: Get all owners
- `GET /api/owners/{ownerId}`: Get an owner by ID
- `POST /api/owners`: Create a new owner
- `PUT /api/owners/{ownerId}`: Update an owner
- `DELETE /api/owners/{ownerId}`: Delete an owner

### PokemonController

- `GET /api/pokemons`: Get all Pokémon
- `GET /api/pokemons/{pokemonId}`: Get a Pokémon by ID
- `POST /api/pokemons`: Create a new Pokémon
- `PUT /api/pokemons/{pokemonId}`: Update a Pokémon
- `DELETE /api/pokemons/{pokemonId}`: Delete a Pokémon

### ReviewController

- `GET /api/reviews`: Get all reviews
- `GET /api/reviews/{reviewId}`: Get a review by ID
- `POST /api/reviews`: Create a new review
- `PUT /api/reviews/{reviewId}`: Update a review
- `DELETE /api/reviews/{reviewId}`: Delete a review

### ReviewerController

- `GET /api/reviewers`: Get all reviewers
- `GET /api/reviewers/{reviewerId}`: Get a reviewer by ID
- `POST /api/reviewers`: Create a new reviewer
- `PUT /api/reviewers/{reviewerId}`: Update a reviewer
- `DELETE /api/reviewers/{reviewerId}`: Delete a reviewer

## Special Features

- **JWT Token-Based Authentication**: Ensures secure user authentication and authorization.
- **Role Management**: Admin can manage user roles, enhancing the application's security and flexibility.
- **Profiling Middleware**: Custom middleware to profile and log performance metrics, aiding in the optimization and monitoring of the application.

## Getting Started

### Prerequisites

- .NET SDK
- SQL Server

### Setup

1. Clone the repository
   ```bash
   git clone https://github.com/EyasWannous/PokemonReviewApp.git

2. Navigate to the project directory
   ```bash
   cd PokemonReviewApp

3. Update the database
   ```bash
   dotnet ef database update

4. Run the application
   ```bash
   dotnet run

##Configuration
The application configuration is managed through appsettings.json and appsettings.Development.json.

##Contributing
Contributions are welcome! Please fork the repository and submit a pull request.

##License
This project is licensed under the MIT License.
