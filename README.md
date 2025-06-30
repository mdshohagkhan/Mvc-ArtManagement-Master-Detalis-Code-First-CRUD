🎨 Art Management System - Master-Details CRUD (Code First)
A complete Art Management System built with ASP.NET MVC 5, using a Master-Details architecture and Entity Framework (Code First) for robust CRUD operations.

✨ Key Features
🧾 Full CRUD Functionality

Create, Read, Update, Delete operations for both master sales records and their associated artwork details.

📄 Master-Details Architecture

Seamless management of sales with detailed line items (e.g., artworks sold, quantities, prices).

⚙️ Code First Approach

Database schema created directly from C# classes. Easy database creation & migration.

🖼️ Image Upload

Upload and display images associated with each artwork or sale.

📱 Responsive Design

Built with Bootstrap 4 for a clean, responsive interface across devices.

🛠️ Technologies Used
Layer	Technology
Framework	ASP.NET MVC 5
Language	C#
ORM	Entity Framework 6
Database	SQL Server / LocalDB
UI Framework	Bootstrap 4
.NET Version	.NET Framework 4.7.2+

⚙️ Getting Started
✅ Prerequisites
Visual Studio 2019 or later

SQL Server Express / LocalDB

.NET Framework 4.7.2+

📥 Installation
bash
Copy
Edit
git clone https://github.com/mdshohagkhan/Mvc-ArtManagement-Master-Details-Code-First-CRUD.git
cd Mvc-ArtManagement-Master-Details-Code-First-CRUD
▶️ Running the Project
1. Open in Visual Studio
Open the solution file ArtManagementmvc.sln.

2. Restore NuGet Packages
Right-click on the solution > Restore NuGet Packages.

3. Apply Migrations
Open the Package Manager Console:

mathematica
Copy
Edit
Tools > NuGet Package Manager > Package Manager Console
In the console, run:

powershell
Copy
Edit
Enable-Migrations   # Only if not already enabled
Update-Database     # Creates the database
4. Configure Connection String
In Web.config, find and update the connection string:

xml
Copy
Edit
<connectionStrings>
  <add name="AppDbContext" 
       connectionString="Data Source=YOUR_SERVER_NAME;Initial Catalog=ArtManagementDB;Integrated Security=True;" 
       providerName="System.Data.SqlClient" />
</connectionStrings>
Replace YOUR_SERVER_NAME with:

(localdb)\MSSQLLocalDB

.

YOUR_PC_NAME\SQLEXPRESS

5. Build and Run
Build: Ctrl + Shift + B

Run: Press F5 or click IIS Express

📂 Project Structure
Folder/File	Description
/Controllers	Handles business logic and user interactions. (SalesController.cs)
/Models	Entity and ViewModel classes (Sale.cs, SaleDetail.cs)
/Views	Razor views (Index.cshtml, Create.cshtml)
/Data	EF DbContext (AppDbContext.cs)
/Migrations	Code First migrations
/Scripts	JavaScript files
/Content	CSS and Bootstrap styles
/images	Uploaded and static images
/App_Start	RouteConfig, BundleConfig, EF setup
Web.config	App settings & connection strings

🧾 License
This project is licensed under the MIT License.
See LICENSE for more details.

🙋‍♀️ Contribution Guide
We welcome contributions! Here's how to contribute:

Fork the repository.

Create a branch:
git checkout -b feature/your-feature-name

Commit your changes:
git commit -m "Add your awesome feature"

Push to GitHub:
git push origin feature/your-feature-name

Open a Pull Request with a detailed description.

🔗 Repository
GitHub Repo:
Mvc-ArtManagement-Master-Details-Code-First-CRUD

