# Portfolio

- Deployed WebApp link: https://jobshadowjournal20251203131522-f6amdhe2e6aedpcp.canadacentral-01.azurewebsites.net/ 
- GitHubLink: https://github.com/Thand0F/Portfolio.git
- SQL Server logins: Admin1
- -------------------Password1!

## Job Shadow Journal – Web Application

A simple and modern ASP.NET Core MVC web application designed to help students or interns track and record what they’ve learned during job shadowing sessions.
The app provides a clean user interface and full CRUD (Create, Read, Update, Delete) functionality to manage journal entries. I have also deployed it using the Azure platform to ensure it doesnt just run as a LocalHost. 

## Features
Journal Entry Management

Create journal entries with:

- Title
- Content
- Date created (automatic)
- Edit existing entries
- Delete entries
- View all entries in a clean card-style layout

Modern UI

- Bootstrap 5 styling
- Responsive layout
- Navigation bar for quick access
- Clean and user-friendly design

Database Integration

- Uses SQL Server / LocalDB
- Entity Framework Core for database access

Technologies Used

- Technology                              Purpose
                                      
- ASP.NET Core MVC: 	                    Web framework and routing
- C#: 	                                  Backend logic
- Entity Framework Core	:                 Data access (ORM)
- SQL Server / LocalDB: 	                Database
- Bootstrap 5: 	                          Frontend styling
- HTML, CSS, Razor Views:  	              UI rendering

## How the App Works
1. User Interface (Views)

  Users interact with Razor views containing Bootstrap-styled pages:

- Index.cshtml: Shows all journal entries

- Create.cshtml: Form for adding new entries

- Edit.cshtml: Allows modifying an entry

- Delete.cshtml: Confirms deletion

These views send form data to the controller.



2. Routing and Logic (Controllers)

  The JournalController contains all CRUD actions:

- Index() → Displays all entries

- Create() + Create(entry) → Add a new entry

- Edit(id) + Edit(entry) → Update an entry

- Delete(id) → Remove an entry

  The controller uses AppDbContext to communicate with the database.



3. Data Layer (EF Core + SQL Server)

- The app uses AppDbContext:

  public DbSet<JournalEntry> JournalEntries { get; set; }

  This maps the JournalEntry model to a database table using SQL Server.

- The database connection string is stored in appsettings.json, example:

  "ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=JobShadowJournalDB;Trusted_Connection=True;"
    }
