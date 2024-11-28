🌟EventMaster🌟
EventMaster is a robust event management system designed to simplify the process of organizing, managing, and tracking events. 
This guide will walk you through the setup and usage of the project.

🛠️ Prerequisites: What You’ll Need to Get Started
Before getting started, make sure you have the following installed on your machine:

.NET SDK
A relational database server (e.g., SQL Server, MySQL)

🚀 Getting Started:
Follow these steps to set up and run the application:

1️⃣Clone the Repository:
Clone the repository to your local machine by running the following command in your terminal:
git clone https://github.com/ZinebYassine/EventMaster.git

2️⃣Navigate to the Project Directory:
Go to the project folder:
cd EventMaster

3️⃣Restore Project Dependencies:
Restore the project dependencies with the following command:
dotnet restore

4️⃣Configure Database Connection:
Open the appsettings.json file and update the connection string under the ConnectionStrings section. Replace YourConnectionStringHere with your actual database connection string

5️⃣Apply Database Migrations:
Run the following command to apply the necessary database migrations:
dotnet ef database update

6️⃣Run the Application:

Thank you for using EventMaster! 🎉
