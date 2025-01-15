# Car Management System

## Overview

The Car Management System is a comprehensive application designed to streamline the management of company-owned vehicles. Built with **ASP.NET**, **MySQL**, and **React**, this system enables efficient handling of vehicle inventory, employee checkouts, and vital operational insights. It provides a dashboard for statistics, urgent notifications (e.g., fines, renewals, and services), and analytics to enhance decision-making.

---

## Features

- **Vehicle Management:**

  - Add, edit, view, and track vehicles.
  - Categorize vehicles by type (e.g., trucks, cars).
  - Monitor registration status, mileage, and availability.

- **Checkout Requests:**

  - Employees can request vehicles for company purposes.
  - Approve, deny, or complete vehicle checkouts.

- **Dashboard:**

  - Displays vehicle usage statistics.
  - Alerts for urgent matters such as upcoming renewals, overdue services, and unpaid fines.
  - Visual analytics with charts.

- **Role-Based Access Control:**

  - Admin, Manager, and Employee roles for secure access management.

- **Notifications:**

  - Alerts for overdue fines, vehicle service due dates, and registration renewals.

---

## Technologies Used

### Backend:

- **ASP.NET Core**
  - RESTful API development.
  - Razor Pages for internal admin views (optional).
- **Entity Framework Core**
  - Database ORM for MySQL.
- **MySQL**
  - Relational database for data storage.

### Frontend:

- **React**
  - Dynamic user interface.
  - Integration with backend APIs.
- **Tailwind CSS**
  - Responsive and modern styling.

### Tools:

- **Postman**: API testing.
- **JWT**: Authentication and authorization.
- **Docker** (optional): Containerized deployments.

---

## Folder Structure

```
src/
│
├── Controllers/          # API controllers for backend endpoints
├── Models/               # Entity definitions for database
├── Services/             # Business logic
├── Repositories/         # Data access layer
├── Data/                 # Database context and seed data
├── DTOs/                 # Data Transfer Objects
├── Utilities/            # Helper classes and utilities
└── Client/               # React frontend source code
```

---

## Installation

### Prerequisites:

- [Node.js](https://nodejs.org/)
- [.NET SDK](https://dotnet.microsoft.com/)
- [MySQL](https://www.mysql.com/)

### Backend Setup:

1. Clone the repository:

   ```bash
   git clone https://github.com/your-username/CarManagementSystem.git
   cd CarManagementSystem
   ```

2. Configure the database connection in `appsettings.json`:

   ```json
   "ConnectionStrings": {
       "DefaultConnection": "Server=localhost;Database=CarManagementDB;User=root;Password=yourpassword;"
   }
   ```

3. Apply database migrations:

   ```bash
   dotnet ef database update
   ```

4. Run the backend:

   ```bash
   dotnet run
   ```

### Frontend Setup:

1. Navigate to the frontend directory:

   ```bash
   cd Client
   ```

2. Install dependencies:

   ```bash
   npm install
   ```

3. Start the React development server:

   ```bash
   npm start
   ```

---

## Usage

1. Access the system by navigating to the frontend URL (e.g., `http://localhost:3000`).
2. Login with appropriate credentials based on your role (Admin, Manager, Employee).
3. Use the dashboard to view vehicle stats, manage checkout requests, and address urgent matters.
4. Add or update vehicles, process employee requests, and track vehicle usage and service records.

---

## API Endpoints

### Vehicle Management

- **GET /api/vehicles**: Retrieve a list of all vehicles.
- **POST /api/vehicles**: Add a new vehicle.
- **PUT /api/vehicles/{id}**: Update vehicle details.
- **DELETE /api/vehicles/{id}**: Remove a vehicle.

### Checkout Requests

- **POST /api/checkout**: Submit a new vehicle checkout request.
- **GET /api/checkout/{id}**: Retrieve details of a specific checkout request.
- **PUT /api/checkout/{id}**: Update the status of a checkout request.

### Dashboard

- **GET /api/dashboard**: Retrieve aggregated statistics and urgent matters.

---

## Contact

For any questions or issues, please contact:

- **Email**: [ahmed.e.moein@gmail.com](mailto\:ahmed.e.moein@gmail.com)
- **GitHub**: aemoein