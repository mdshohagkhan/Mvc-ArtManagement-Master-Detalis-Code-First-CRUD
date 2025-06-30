🎓 Art Management System: Master-Details CRUD with Code First ()
This repository contains the source code for a complete Art Management System built with ASP.NET MVC 5. It leverages a Master-Details architecture and the Entity Framework Code First approach to manage database operations, providing robust CRUD functionality.

✨ Key Features
Comprehensive CRUD for Sales & Details: Full functionality to Create, Read, Update, and Delete both master sales records and their associated detailed artwork items (e.g., specific art pieces sold, quantities).

Master-Details Data Management: A well-structured framework for managing master sale records alongside their subordinate detailed records (e.g., what art was sold, in what quantities) seamlessly.

Code First Database Design: The database schema is designed directly through C# model classes, enabling automatic database creation and migrations for easy setup and updates.

Image Upload Capability: Provides features to upload and display images relevant to each sales record.

Responsive User Interface: Built with Bootstrap 4, ensuring the application looks great and functions well across various screen sizes and devices.

🛠️ Technologies Used
Framework: ASP.NET MVC 5

Programming Language: C#

ORM (Object-Relational Mapper): Entity Framework 6 (Code First)

Database: SQL Server / LocalDB

UI Framework: Bootstrap 4

⚙️ Project Setup & Running Guide
Follow these steps to get this project up and running in your local development environment.

Prerequisites
Before you start, make sure you have the following software installed on your system:

Visual Studio 2019 or a later version.

SQL Server Express / LocalDB or any other preferred SQL Server instance.

.NET Framework 4.7.2 or a higher version.

Installation
Clone the Repository:
Open your terminal or command prompt and run this command to clone the repository to your local machine:

Bash

git clone https://github.com/mdshohagkhan/Mvc-ArtManagement-Master-Details-Code-First-CRUD.git
cd Mvc-ArtManagement-Master-Details-Code-First-CRUD
Running the Project
Open the Solution in Visual Studio:
Double-click the ArtManagementmvc.sln file to open the project solution in Visual Studio.

Restore NuGet Packages:
Right-click on the solution in the Solution Explorer and select Restore NuGet Packages. This will download all the necessary libraries for the project.

Apply Database Migrations:

Open the Package Manager Console (PMC) in Visual Studio: Go to Tools > NuGet Package Manager > Package Manager Console.

Ensure that the ArtManagementmvc project is selected in the Default project dropdown at the top right of the PMC window.

If migrations haven't been set up for this project before, run the following command:

PowerShell

Enable-Migrations
Next, run the command below to create the database or apply any pending changes to an existing one:

PowerShell

Update-Database
This will create your database and its required tables in your SQL Server instance.

Update Connection String:

Open the Web.config file within the ArtManagementmvc project.

Locate the <connectionStrings> section and update the connectionString named AppDbContext to point to your SQL Server instance.

For example:

XML

<add name="AppDbContext" connectionString="Data Source=YOUR_SERVER_NAME;Initial Catalog=ArtManagementDb;Integrated Security=True" providerName="System.Data.SqlClient" />
(Replace YOUR_SERVER_NAME with your actual SQL Server instance name, e.g., (localdb)\MSSQLLocalDB, ., or YOUR_PC_NAME\SQLEXPRESS).

Build the Solution:
Go to the Build menu and select Build Solution, or simply press Ctrl + Shift + B.

Run the Application:
Press F5 in Visual Studio or click the IIS Express button. This will launch the application in your default web browser.

📂 Project File Structure
Here's an overview of the key folders and files in the project:

/Controllers: Contains the MVC Controller files (e.g., SalesController.cs) responsible for handling application logic and user input.

/Models: Stores Entity Model classes (e.g., Sale.cs, SaleDetaile.cs, CustomerType.cs) mapped to database tables, along with ViewModels used for data transfer.

/Views: Holds the Razor View files (e.g., /Sales/Index.cshtml, /Sales/Create.cshtml) that define the user interface.

/Data: Defines the Entity Framework DbContext class (AppDbContext.cs), which is the main interface for database interaction.

/Migrations: Contains the Entity Framework Code First Migrations files, which track and apply database schema changes.

/Scripts: Includes JavaScript files that handle client-side logic and interactions.

/Content: Stores Bootstrap and custom CSS files that control the application's styling.

/images: The directory where uploaded images and other static image files are saved.

/App_Start: Contains configuration files for Routes, Bundles, and initial Entity Framework setup.

Web.config: Defines application-wide configuration settings, including the database connection string.

✅ License
This project is licensed under the MIT License. Please see the LICENSE file for more details.

🙋‍♀️ Contribution
We welcome your contributions to this project! If you'd like to add a new feature or fix a bug, please follow these steps:

Fork this repository.

.Create a new feature branch for your changes (git checkout -b feature/.your-awesome-feature).

.Commit your changes (git commit -m 'Add a new awesome feature').

.Push to your branch (git push origin feature/your-awesome-feature).

.Open a Pull Request, explaining your changes in detail.

