# Employee Management System - Backend

## 🚀 **Overview**

This is the **backend** for the Employee Management System. It is built with **ASP.NET API** and manages the application's core data and business logic. 
The backend exposes endpoints to handle CRUD operations for the following entities:
- **Role**
- **Designation**
- **Employee**
- **Client**
- **Project**

The entities are relationally mapped to allow effective management:
- Each **Project** has a lead (**Employee**) and is assigned to a **Client**.
- Each **Employee** is assigned a **Designation** and a **Role**.
- An **Employee** can work on one or more projects, but only one **lead** exists per project.

## 🔗 **Related Repository**

This backend works with the frontend project, built in **Angular**. Find it [here](https://github.com/Nourhan123Essam/Employee-Management-System-Angular).

---

## 🛠️ **Tech Stack**

- **Framework**: ASP.NET Core API  
- **Database**: SQL Server  
- **ORM**: Entity Framework Core  
- **Mapping**: AutoMapper  

---

## 🌟 **Features**

- CRUD operations for the following entities:
  - **Role**  
  - **Designation**  
  - **Employee**  
  - **Client**  
  - **Project**  
- Clear relationships between entities to reflect a real-world employee management structure.

---

## 🗃️ **Database Schema**

Here is the schema for the database showing the relationships between entities:  

![Database Schema](schema-screenshot.png)  

---

## 📖 **Endpoints**

Below is a sample of the key endpoints exposed by this API.  

| HTTP Method | Endpoint                | Description               |
|-------------|-------------------------|---------------------------|
| `POST`      | `/api/auth/login`       | Logs in the user.         |
| `POST`      | `/api/auth/logout`      | Logs out the user.        |
| `GET`       | `/api/employees`        | Retrieves all employees.  |
| `POST`      | `/api/employees`        | Creates a new employee.   |
| `PUT`       | `/api/employees/{id}`   | Updates an employee.      |
| `DELETE`    | `/api/employees/{id}`   | Deletes an employee.      |

For a complete list of endpoints, refer to the **Postman collection** or Swagger UI documentation.

---

## 💡 **How to Run**

### Prerequisites:
- Install **.NET 6 SDK**.  
- Install **SQL Server**.  

### Steps:
1. Clone the repository:  
   ```bash
   git clone https://github.com/Nourhan123Essam/Employee-Management-System-API-ASP.Net.git
   ```
2. Update the appsettings.json with your SQL Server connection string.
3. 
