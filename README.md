# 🏛️ Confy = Conference Management App – Microservices Architecture

This repository contains the **microservices-based version** of a backend application created as part of my master's thesis project focused on **comparing performance between monolithic and microservices architectures**.

📌 **[Click here to see the Monolithic version](https://github.com/MichalZdanuk/ConfyMonolith)**

---

## 📚 Project Overview

This is a simplified MVP backend application that allows conference organizers, lecturers and attendees to:

- Create and manage conferences 📝  
- Add and edit lectures within conferences 🎤  
- Register for events as a participant 🙋
- Receive notifications about registrations and updates related to their conferences 📣
- Authenticate users via email & password 🔐

Features are encapsulated in its own servicse, promoting separation of concerns and scalability.

---

## 🧠 Part of Master's Thesis

This application is part of my thesis exploring:

> **"Comparison of Monolithic Architecture and Microservices-Based Architecture"**

This version implements the same use cases as the monolith, but distributed across multiple services.

---

## 🧩 Microservices Breakdown

1. 🛡️ **API Gateway**  
   - Handles routing, authentication, and JWT validation  
   - Built with `YARP` reverse proxy  

2. 🔐 **Authentication Service**  
   - User registration & login (email, password, role)  
   - JWT token generation & validation  

3. 🏛️ **ConferenceManagement Service**  
   - Create/edit/view conferences  
   - Add/edit lectures and assign speakers  

4. 📝 **Registration Service**  
   - Participant registration  
   - View/cancel registrations  
   - Lists for organizers and users  

5. 📣 **Notification Service**  
   - Logs and stores notifications  
   - Simulates event-driven messaging (simplified storing notifications and mocked sending)
   - Displays notification history for user

---

## 🏗️ Architecture  

This microservices-based application follows **Clean Architecture** and **Domain-Driven Design (DDD)** principles to ensure modularity, scalability, and maintainability. The system is built around several architectural patterns:  

- **Gateway/Reverse Proxy Pattern** – Uses an API Gateway to route requests, manage authentication, and act as a single entry point for clients.  
- **CQRS (Command Query Responsibility Segregation)** – Separates read and write operations to optimize performance and maintain data consistency.  
- **Transactional Outbox Pattern** – Ensures reliable event propagation between services using **MassTransit**, preventing data inconsistencies.  
- **Event-Driven Pub/Sub Messaging** – Implements **RabbitMQ with MassTransit** for asynchronous inter-service communication and eventual consistency.  

![microservicesArchitecture](https://github.com/user-attachments/assets/7053efe7-9a3d-46b2-be93-1c00c005456d)

*High-level architecture of the microservices-based system.* 

---

## 🔧 Technologies Used

### ⚙️ Backend:
- .NET Core Web API / Web App
- .NET Class Library
- MassTransit 
- YARP Reverse Proxy
- Mediatr
- Entity Framework Core
- Microsoft.AspNetCore.Authentication.JwtBearer
- AspNetCore.HealthChecks
- BCrypt.Net-Next

### 📡 Messaging:
- RabbitMQ

### 🛢️ Infrastructure:
- MSSQL Server
- Docker

### 🧪 Tools:
- Visual Studio
- Postman
- SSMS (SQL Server Management Studio)
- NBomber (for performance testing)

---

## 🧪 Use Cases for Performance Testing

These are the **six core use cases** selected for benchmarking with [NBomber](https://nbomber.com/):

1. ✅ Create a new conference  
2. ✏️ Edit an existing conference  
3. 🔍 Browse conferences (filters & pagination)  
4. 📄 Get conference details  
5. ➕ Add a lecture to a conference  
6. 🛠️ Edit a lecture

![UseCases](https://github.com/user-attachments/assets/442e0567-a6ac-4d53-9f2d-d52f605fe7ba)

---

## 🔗 Related Projects

👉 Check out the [Monolithic version here](https://github.com/MichalZdanuk/ConfyMonolith) for comparison.

---

## 📄 License

This project is part of an academic research thesis and intended for educational purposes.
