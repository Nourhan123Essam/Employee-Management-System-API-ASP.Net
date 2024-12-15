# Employee Management System - Backend

## 🚀 Overview

The **Employee Management System Backend** is built using **ASP.NET Core API** and handles core data and business logic for managing employees, roles, designations, clients, and projects. This API enables seamless CRUD operations with real-world relational mappings.

### Key Entity Relationships:
- Each **Project** is led by an **Employee** and assigned to a **Client**.
- Each **Employee** has a specific **Designation** and **Role**.
- An **Employee** can work on multiple **Projects**, but only one **Lead Employee** exists per project.
- Deleting a **Client** automatically removes all related **Projects**.

---

## 🔗 Related Repository

The frontend for this project is built in **Angular** with responsive UI using **Bootstrap**. Check it out [here](https://github.com/Nourhan123Essam/Employee-Management-System-Angular).

---

## 🛠️ Tech Stack

- **Framework**: ASP.NET Core API  
- **Database**: SQL Server  
- **ORM**: Entity Framework Core  
- **Mapping Tool**: AutoMapper  

---

## 🌟 Features

- **CRUD operations** for five key entities:
  - **Role**
  - **Designation**
  - **Employee**
  - **Client**
  - **Project**
- Robust entity relationships for real-world employee management:
  - Automatic cascading deletions (e.g., deleting a client removes all related projects).
- Authentication with **Local Storage** and **Guards** to prevent unauthorized access in the frontend.

---

## 🗃️ Database Schema

Below is a diagram of the database schema, showing entity relationships:

![Database Schema](Employee-System-Backend/Project%20Screens/Database%20Diagram.png)  

---

## 📖 API Endpoints

Screenshots of the exposed API endpoints via Swagger UI:  

![Swagger UI 1](Employee-System-Backend/Project%20Screens/Swagger%20Ui%201.png)  
![Swagger UI 2](Employee-System-Backend/Project%20Screens/Swagger%20Ui%202.png)  
![Swagger UI 3](Employee-System-Backend/Project%20Screens/Swagger%20Ui%203.png)  
![Swagger UI 4](Employee-System-Backend/Project%20Screens/Swagger%20Ui%204.png)  

---

## How to Run the Project

### Prerequisites
Ensure you have the following installed:
- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or later)
- SQL Server
- Visual Studio or any preferred IDE
- Postman or similar API testing tools (optional)

---

## 💡 **How to Run**

### Steps:
1. Clone the repository:  
   
    ```bash
     git clone https://github.com/Nourhan123Essam/Employee-Management-System-API-ASP.Net.git

2. Update the appsettings.json with your SQL Server connection string in this format:
  in the appsetting.json put your database name, and server name in the DefaultConnection:
    
    ```appsetting.json
    "ConnectionStrings": {
    "DefaultConnection": "Server=your-server-name;Database=your-database-name;Trusted_Connection=True;TrustServerCertificate=True"
    }
3.Apply Migrations
 - Open the terminal and navigate to the project folder where the .csproj file is located.
 - Run the following command to create the database and apply migrations:
    ```bash
      dotnet ef database update
  
4. Open the the folder using Visual Studio then run the project

###📬 Let's Connect
- [LinkedIn](https://www.linkedin.com/in/nourhan-essam123/)  
- [LeetCode](https://leetcode.com/u/norhan123/)  
- [GitHub](https://github.com/Nourhan123Essam)
- [Gmail](nourhan.essam.makhlouf@gmail.com)
---
