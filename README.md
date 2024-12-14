ShopSphere Backend

ShopSphere Backend is an e-commerce platform developed using modern microservices architecture. This project consists of three core microservices: User Service, Order Service, and Product Service, built with .NET Core and various supporting technologies.

🚀 Project Features

Microservices Architecture: Independent and scalable services.

Entity Framework Core: Used for database operations.

API Gateway: Routing managed by Ocelot.

Unit Tests: Comprehensive tests written with xUnit and Moq.

PostgreSQL: Each microservice has its own database.

🛠️ Technologies Used

C# and .NET Core

PostgreSQL

Ocelot API Gateway

xUnit and Moq (for testing)

Clean Architecture principles

SOLID and other software development principles

📁 Project Structure

ShopSphereBackend/
├── ShopSphere.Gateway/        # API Gateway
├── ShopSphere.UserService/    # User Service
├── ShopSphere.OrderService/   # Order Service
├── ShopSphere.ProductService/ # Product Service
├── test/                      # Unit Test Projects
└── README.md                  # Project Description

🛠️ Setup and Run

Clone the Repository:

git clone https://github.com/yasarbudak/ShopSphereBackend.git
cd ShopSphereBackend

Database Configuration:

Update the PostgreSQL connection settings in each microservice's appsettings.json file.

Run the Services:

Start the microservices using the following commands:

dotnet run --project ShopSphere.UserService
dotnet run --project ShopSphere.OrderService
dotnet run --project ShopSphere.ProductService
dotnet run --project ShopSphere.Gateway

API Testing:

Use Postman or cURL to test the API:

User Service: http://localhost:5001/api/users

Order Service: http://localhost:5002/api/orders

Product Service: http://localhost:5003/api/products

📄 License

This project is open-source and can be used without any license restrictions.

🤝 Contributing

If you would like to contribute to this project:

Fork this repository.

Create a new branch:

git checkout -b feature/your-feature

Commit your changes:

git commit -m "Add new feature"

Push to your branch:

git push origin feature/your-feature

Open a Pull Request.

If you enjoyed working on this project, don't forget to leave a star! ⭐

