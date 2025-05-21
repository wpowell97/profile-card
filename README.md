# ProfileCardApp

An ASP.NET Core 8 MVC project demonstrating a responsive profile card component, a contact form with validation, and SQL Server integration using Entity Framework Core.

---

## 🚀 Features

- ✅ ViewComponent-powered Profile Card  
- ✅ Partial View-based profile stats  
- ✅ Fully validated contact form (server + client-side)  
- ✅ Messages saved to SQL Server database via EF Core  
- ✅ Responsive Bootstrap 5 layout with side-by-side columns  
- ✅ Razor view, model binding, and TempData success messaging  

---

## 🛠️ Tech Stack

- ASP.NET Core 8 (MVC)
- Entity Framework Core
- SQL Server / LocalDB
- Bootstrap 5
- Razor View Engine
- Data Annotations

---

## 📁 Project Structure

```
ProfileCardApp/
│
├── Controllers/
│   └── HomeController.cs
│
├── Models/
│   ├── ContactFormViewModel.cs
│   └── ContactMessage.cs
│
├── Data/
│   └── ApplicationDbContext.cs
│
├── ViewComponents/
│   └── ProfileBoxViewComponent.cs
│
├── Views/
│   ├── Home/
│   │   └── Index.cshtml
│   └── Shared/
│       ├── _ProfileStats.cshtml
│       └── Components/
│           └── ProfileBox/
│               └── Default.cshtml
│
├── wwwroot/images/
│   └── profile.jpg
│
├── appsettings.json
├── Program.cs
└── ProfileCardApp.csproj
```

---

## ⚙️ Setup & Run Instructions

### ✅ Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [SQL Server or SQL Server Express](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- Visual Studio Code or Visual Studio

### 🔧 Configuration

**`appsettings.json`**

```json
{
    "ConnectionStrings": {
        "ProfilePage": "Server=YOUR_SERVER;Database=ProfilePageDb;Trusted_Connection=True;TrustServerCertificate=True"
    },
    "Logging": {
        "LogLevel": {
            "Default": "Information",
            "Microsoft.AspNetCore": "Warning"
        }
    },
    "AllowedHosts": "*"
}
```

Replace `YOUR_SERVER` with your actual SQL Server name or use `localhost`.

### 🏗️ Build & Run

```sh
# 1. Restore packages
dotnet restore

# 2. Apply EF migration to create the DB
dotnet ef migrations add InitialCreate
dotnet ef database update

# 3. Run the app
dotnet run
```

Then visit: [https://localhost:5001](https://localhost:5001) or [http://localhost:5000](http://localhost:5000)

---

## 💡 Future Ideas

- Admin panel to browse messages
- Export messages to CSV or Excel
- Add ReCAPTCHA or bot protection
- Deploy to Render / Azure App Service

---

## 🧑‍💻 Author

**Will Powell**  
Frontend Developer @ Plimsoll Publishing  
[LinkedIn](https://www.linkedin.com/in/wpowell97)

---

## 📄 License

<!-- Add your license text or badge here -->

---

## 📘 GitHub Repo Metadata

Here’s how to structure the **GitHub repo details**:

- **Repo name:** `ProfileCardApp`
- **Description:**  
    > ASP.NET Core 8 MVC project with profile card component, contact form, and database integration using EF Core.

- **Topics / Tags:**

```
aspnet-core mvc bootstrap entity-framework-core contact-form viewcomponent partialview sql-server
```
