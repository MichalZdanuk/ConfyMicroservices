# 🏛️ Confy (Conference Management App)
### Microservices Architecture

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

![use_cases_for_experiments](https://github.com/user-attachments/assets/93db488d-7dfe-4088-bb81-8c754a5068f1)

---

## 🚀 Microservices Availability

Below is a table specifying which microservices or the API Gateway are available on specific ports, either for **localhost** or when running in **Docker**:

| Service                       | Local Env     | Docker Env   | Description                                        |
|-------------------------------|---------------|--------------|----------------------------------------------------|
| **Authentication Service**    | 5000 - 5050   | 6000 - 6060  | Handles user authentication and JWT generation     |
| **Conference Management**     | 5001 - 5051   | 6001 - 6061  | Manages conferences, lectures, and schedules       |
| **Registration Service**      | 5002 - 5052   | 6002 - 6062  | Handles participant registration and cancellations |
| **Notification Service**      | 5003 - 5053   | 6003 - 6063  | Sends event notifications to users                 |
| **API Gateway**               | 5004 - 5054   | 6004 - 6064  | Central entry point for routing and authentication |
| **RabbitMQ (Message Broker)** | N/A           | 5672         | Message broker for communication between services  |

**Note:**
- Convention is that first port number is HTTP and second is HTTPS.
- The **Local Env** are the default ports when running the services locally.  
- The **Docker Env** are ports available when running the services within Docker.

---

## 🏃 How to Run the Application

To run the entire microservices system locally using **Docker**, execute the following commands:

```bash
git clone https://github.com/MichalZdanuk/ConfyMicroservices.git
```
```bash
cd ConfyMicroservices/src
```
```bash
docker-compose -f docker-compose.yml -f docker-compose.override.yml up
```

---

## 🔗 Related Projects

👉 Check out the [Monolithic version here](https://github.com/MichalZdanuk/ConfyMonolith) for comparison.

👉 Performance analysis can be found here [Performance analysis](https://github.com/MichalZdanuk/ArchitecturesAnalysis).

---

## 📄 License

This project is part of an academic research thesis and intended for educational purposes.
