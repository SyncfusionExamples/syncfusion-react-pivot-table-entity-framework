# Sales Analytics: Interactive Pivot Table Dashboard with Entity Framework Core

**Binding and Perform CRUD Operations with Interactive Sales Analytics Using Entity Framework Core (SQL Server)**

**EF Core Pivot Table Dashboard** is a full-stack business intelligence application that seamlessly integrates a **React + TypeScript frontend** with an **ASP.NET Core backend** powered by **Entity Framework Core** and connected to a **SQL Server database**.

### 🔄 How It Works

The application uses **Syncfusion DataManager** to handle real-time CRUD operations (Create, Read, Update, Delete) on sales data through an interactive pivot table interface:

- **React Client (Frontend)**: Displays an interactive Syncfusion pivot table component that allows users to visualize, analyze, and manipulate sales data without writing SQL
- **DataManager**: The DataManager component in React communicates with backend API endpoints, automatically sending HTTP requests for fetch, insert, update, and delete operations
- **ASP.NET Core Backend**: Provides REST API endpoints (`/api/sales`) that handle all CRUD operations via the **SalesController**
- **Entity Framework Core**: Maps the `SalesData` entity to the `SalesData` table and executes strongly-typed LINQ queries for all CRUD operations
- **SQL Server Database**: Stores all sales transaction data with proper indexing for optimal query performance using the Microsoft SQL Server provider

The complete workflow: User interacts with pivot table → DataManager sends HTTP request → Backend processes via SalesController → EF Core translates to SQL → SQL Server executes query → Response updates UI instantly.

---

## 📋 Table of Contents

- [Quick Overview](#quick-overview)
- [Key Features & Capabilities](#key-features--capabilities)
- [Technology Stack](#technology-stack)
- [System Architecture](#system-architecture)
- [Installation & Setup](#installation--setup)
- [Configuration](#configuration)
- [Getting Started](#getting-started)
- [Project Structure](#project-structure)
- [Troubleshooting](#troubleshooting)
- [Contributing](#contributing)
- [License & support](#license--support)

---

## 🎯 Quick Overview

This application provides an intuitive interface for real-time sales data analysis and manipulation. Instead of complex SQL queries, users interact with an interactive pivot table to:

- **Visualize Data**: Organize sales data by country, product category, sales personnel, and time periods
- **Perform CRUD Operations**: Add new records, modify existing data, and delete entries directly through the pivot table interface
- **Drill-Through Analysis**: Click cells to view detailed records and edit them in-line
- **Customize Views**: Drag-and-drop fields to reorganize the pivot table layout
- **Real-time Sync**: All changes are immediately reflected across the application using DataManager and EF Core change tracking

### Why Choose This Stack?

- **Type-Safe Frontend**: TypeScript ensures fewer bugs in the React application
- **Robust Backend**: ASP.NET Core 10.0 provides enterprise-grade API performance
- **EF Core ORM**: Strongly-typed data access with automatic change tracking and migration support
- **Reliable Database**: Microsoft SQL Server delivers ACID compliance and enterprise-grade performance
- **Professional UI**: Syncfusion components deliver production-ready pivot tables
- **Seamless Integration**: DataManager bridges frontend and backend with automatic HTTP handling

---

## ✨ Key Features

### Core Capabilities

- **Interactive Pivot Tables**: Organize and summarize sales data by multiple dimensions with drag-and-drop field configuration
- **Complete CRUD Operations**: Create, read, update, and delete sales records directly from the pivot table editing UI
- **DataManager Integration**: Automatic HTTP communication with backend for seamless data synchronization
- **Drill-Through Analysis**: Click detailed cells to edit individual records with real-time validation
- **Sales Dimensions**: Analyze data by country, region, product category, sales person, and time periods
- **Responsive Design**: Works seamlessly on desktop and tablet devices
- **Real-time Updates**: All changes reflect immediately across the application
- **Date/Time Handling**: Automatic formatting for temporal fields with calendar picker support
- **EF Core Tracking**: Optimistic concurrency and `AsNoTracking` queries for read-heavy operations

---

## 🛠️ Technology Stack

### Frontend
| Technology | Version | Purpose |
|-----------|---------|---------|
| React | 19.2.8 | UI framework and component library |
| TypeScript | ~6.0.2 | Type-safe JavaScript development |
| Vite | 8.2.0 | Lightning-fast build tool |
| Syncfusion EJ2 | 34.2.2 | Professional pivot table component |
| React DOM | 19.2.8 | React rendering engine |

### Backend
| Technology | Version | Purpose |
|-----------|---------|---------|
| .NET | 10.0 | Framework for web APIs |
| ASP.NET Core | 10.0 | Web application framework |
| Entity Framework Core | 10.0.10 | ORM for data access |
| EF Core SQL Server Provider | 10.0.10 | SQL Server data access |
| Syncfusion EJ2 | 34.2.2 | Data management utilities |
| Microsoft.AspNetCore.OpenApi | 10.0.10 | OpenAPI/Swagger documentation |

### Database & DevOps
| Technology | Purpose |
|-----------|---------|
| Microsoft SQL Server | Primary relational database |
| EF Core Migrations | Schema management and versioning |

### Development Tools
| Tool | Purpose |
|-----|---------|
| ESLint | Code quality and style enforcement |
| TypeScript Compiler | Type checking and transpilation |
| Node.js | JavaScript runtime for frontend |
| .NET CLI | .NET project management |
| dotnet ef | EF Core command-line tools |

---

## 🏗️ System Architecture

### Architecture Overview

```
┌──────────────────────────────────────────────┐
│   React Frontend (TypeScript/Vite)           │
│  ┌──────────────────────────────────────┐   │
│  │  PivotViewComponent + DataManager    │   │
│  │  (Syncfusion)                        │   │
│  └──────────────────────────────────────┘   │
└──────────────────────────────────────────────┘
              ↓
         HTTP/HTTPS REST API
              ↓
┌──────────────────────────────────────────────┐
│   ASP.NET Core Backend (.NET 10.0)          │
│  ┌──────────────────────────────────────┐   │
│  │  SalesController                     │   │
│  │  /api/sales endpoints (CRUD)         │   │
│  └──────────────────────────────────────┘   │
│  ┌──────────────────────────────────────┐   │
│  │  SalesDbContext (EF Core)            │   │
│  │  DbSet<SalesData> + LINQ queries     │   │
│  └──────────────────────────────────────┘   │
└──────────────────────────────────────────────┘
              ↓
   EF Core SQL Server Provider
              ↓
┌──────────────────────────────────────────────┐
│   SQL Server Database (SalesDb)              │
│  ┌──────────────────────────────────────┐   │
│  │  SalesData table (orders, details)   │   │
│  └──────────────────────────────────────┘   │
└──────────────────────────────────────────────┘
```

### Data Flow with DataManager and EF Core

1. **User Interaction**: User manipulates pivot table in React (add, edit, delete, reorganize)
2. **DataManager Request**: DataManager automatically detects changes and sends HTTP request to backend
3. **Backend Processing**: SalesController receives request and routes to appropriate CRUD method
4. **EF Core Query**: `SalesDbContext` executes strongly-typed LINQ queries with change tracking
5. **SQL Translation**: EF Core translates LINQ to parameterized SQL commands
6. **Database Execution**: SQL Server executes the query against the `SalesData` table
7. **Response**: Backend returns JSON response with operation result
8. **UI Synchronization**: DataManager updates pivot table with fresh data, user sees changes instantly

### Key Integration Points

| Component | Role | Purpose |
|-----------|------|---------|
| **DataManager** | Frontend Bridge | Manages HTTP communication, caching, and data synchronization |
| **SalesController** | Backend API | Handles GET/POST requests and routes to CRUD operations |
| **SalesDbContext** | ORM Layer | Manages entity tracking, query translation, and change detection |
| **EF Core SQL Server Provider** | Data Provider | Executes queries against SQL Server with connection pooling |
| **Syncfusion PivotView** | UI Component | Renders interactive pivot table with drill-through editing |

---

## 📦 Installation & Setup

### Prerequisites

- **Backend**: .NET 10.0 SDK, SQL Server 2019+ (or SQL Server Express / LocalDB)
- **Frontend**: Node.js 18+, npm/yarn
- **System**: 4GB RAM, 500MB storage, Ports 7086, 5173 available

### Database Setup

1. **Create Database**
   ```sql
   CREATE DATABASE SalesDb;
   ```

2. **Create Table** - The `SalesData` entity is mapped to the `SalesData` table by EF Core. You can either let EF Core create it (via migrations or `EnsureCreated`) or run the following SQL schema:

   ```sql
   CREATE TABLE [dbo].[SalesData] (
       [OrderID]        INT             IDENTITY(1,1) NOT NULL PRIMARY KEY,
       [CustomerName]   NVARCHAR(200)   NULL,
       [Region]         NVARCHAR(100)   NULL,
       [Country]        NVARCHAR(100)   NULL,
       [ProductCategory] NVARCHAR(100)  NULL,
       [ProductName]    NVARCHAR(200)   NULL,
       [OrderDate]      DATETIME        NULL,
       [Quantity]       INT             NULL,
       [UnitPrice]      DECIMAL(18, 2)  NOT NULL,
       [TotalAmount]    DECIMAL(18, 2)  NOT NULL,
       [SalesPerson]    NVARCHAR(100)   NULL
   );
   ```

3. **(Optional) Seed Sample Data** - Insert test records into the table for development

### Backend Installation

#### Step 1: Navigate to Backend Directory

```bash
cd PivotTable_EFCore.Server
```

#### Step 2: Restore NuGet Dependencies

```bash
dotnet restore
```

#### Step 3: Update Connection String

Add the `ConnectionStrings` section to `appsettings.json` (or use User Secrets / environment variables) with your SQL Server credentials:

```json
{
  "ConnectionStrings": {
    "SalesDb": "Server=(localdb)\\MSSQLLocalDB;Database=SalesDb;Trusted_Connection=True;TrustServerCertificate=True;"
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

**Common SQL Server connection string examples:**

| Scenario | Connection String |
|----------|------------------|
| LocalDB (default) | `Server=(localdb)\MSSQLLocalDB;Database=SalesDb;Trusted_Connection=True;TrustServerCertificate=True;` |
| SQL Server Express | `Server=localhost\\SQLEXPRESS;Database=SalesDb;Trusted_Connection=True;TrustServerCertificate=True;` |
| SQL Server with credentials | `Server=localhost;Database=SalesDb;User Id=sa;Password=YourPassword;TrustServerCertificate=True;` |
| Remote SQL Server | `Server=tcp:servername.database.windows.net,1433;Database=SalesDb;User Id=username;Password=YourPassword;Encrypt=True;` |

**⚠️ Security Warning**: Never commit `appsettings.json` with actual credentials to version control. Use environment variables, User Secrets (`dotnet user-secrets`), or Azure Key Vault in production.

#### Step 4: Build the Backend

```bash
dotnet build
```

#### Step 5: Run the Backend

```bash
# Development mode with file watching
dotnet watch run

# Or standard run
dotnet run
```

Backend will start at: `https://localhost:7086`

### Frontend Installation

#### Step 1: Navigate to Frontend Directory

```bash
cd pivottable_efcore.client
```

#### Step 2: Install npm Dependencies

```bash
npm install
```

#### Step 3: Update API Endpoint (if needed)

Edit `src/App.tsx` to match your backend URL:

```typescript
let data: DataManager = new DataManager({
  url: 'https://localhost:7086/api/Sales',                    // Data retrieval endpoint
  insertUrl: 'https://localhost:7086/api/Sales/Insert',       // Called when user adds a new record
  updateUrl: 'https://localhost:7086/api/Sales/Update',       // Called when user edits an existing record
  removeUrl: 'https://localhost:7086/api/Sales/Remove',       // Called when user deletes a record
  adaptor: new UrlAdaptor                                     // Uses the standard URL adaptor for HTTP communication
});
```

#### Step 4: Start Development Server

```bash
npm run dev
```

Frontend will be available at: `http://localhost:5173`

#### Step 5: Build for Production

```bash
npm run build
```

---

## ⚙️ Configuration

### Backend Configuration (appsettings.json)

```json
{
  "ConnectionStrings": {
    "SalesDb": "Server=(localdb)\\MSSQLLocalDB;Database=SalesDb;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning",
      "Microsoft.EntityFrameworkCore": "Information"
    }
  },
  "AllowedHosts": "*",
  "Kestrel": {
    "Endpoints": {
      "Https": {
        "Url": "https://localhost:7086"
      },
      "Http": {
        "Url": "http://localhost:5000"
      }
    }
  }
}
```

### Environment Variables (Backend)

Set environment variables for sensitive configuration:

```bash
ASPNETCORE_ENVIRONMENT=Development
ConnectionString__SalesDb="Server=localhost;Database=SalesDb;User Id=sa;Password=YOUR_PASSWORD;TrustServerCertificate=True;"
```

Or use .NET User Secrets for development:

```bash
dotnet user-secrets set "ConnectionStrings:SalesDb" "Server=localhost;Database=SalesDb;User Id=sa;Password=YOUR_PASSWORD;TrustServerCertificate=True;"
```

### Frontend Configuration (vite.config.ts)

Current configuration supports React development:

```typescript
import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'

export default defineConfig({
  plugins: [react()],
  server: {
    port: 5173,
    proxy: {
      '/api': {
        target: 'https://localhost:7086',
        changeOrigin: true,
        rewrite: (path) => path.replace(/^\/api/, '/api')
      }
    }
  }
})
```

### Frontend Environment Variables

Create `.env` file in frontend root:

```
VITE_API_URL=https://localhost:7086
VITE_API_TIMEOUT=30000
```

---

## 🚀 Getting Started

### Quick Start (5 Minutes)

#### Prerequisites Met:
✅ SQL Server running (LocalDB, Express, or full instance)
✅ Database and table created
✅ Backend connection string configured
✅ Node.js installed

#### Steps:

**Terminal 1 - Start Backend:**
```bash
cd PivotTable_EFCore.Server
dotnet run
```

**Terminal 2 - Start Frontend:**
```bash
cd pivottable_efcore.client
npm install  # (First time only)
npm run dev
```

**Browser:**
Open `http://localhost:5173`

### First Success Checkpoint

You should see:
1. ✅ Pivot table interface loads
2. ✅ Sales data displays in the table
3. ✅ Field list panel appears on the right
4. ✅ You can drag fields to reorganize the pivot table
5. ✅ Click a cell to drill into detail records

### Next Steps for Learning

1. **Understand the Data Model**: Review [SalesData Model](#project-structure)
2. **Explore CRUD Operations**: Try adding, editing, and deleting records
3. **Configure Pivot Table**: Drag fields to customize the view
4. **Study the Code**: Examine `SalesController.cs`, `SalesDbContext.cs`, and `App.tsx`
5. **Add Features**: Implement filtering, sorting, export capabilities, or EF Core migrations

---

## 📁 Project Structure

### Directory Tree

```
EF-Core-Sales-Analytics/
├── README.md                              # This file
│
├── pivottable_efcore.client/              # React Frontend
│   ├── package.json                       # npm dependencies & scripts
│   ├── tsconfig.json                      # TypeScript configuration
│   ├── tsconfig.app.json                  # App-specific TS config
│   ├── tsconfig.node.json                 # Node-specific TS config
│   ├── vite.config.ts                     # Vite build configuration
│   ├── eslint.config.js                   # ESLint rules
│   ├── index.html                         # HTML entry point
│   │
│   └── src/
│       ├── main.tsx                       # React root
│       ├── App.tsx                        # Main component
│       ├── App.css                        # Component styles
│       ├── index.css                      # Global styles
│       └── assets/                        # Static assets
│
└── PivotTable_EFCore.Server/              # .NET Core Backend
    ├── Program.cs                         # Application entry point
    ├── PivotTable_EFCore.Server.csproj    # Project file
    ├── PivotTable_EFCore.Server.http      # HTTP test file
    ├── appsettings.json                   # Configuration
    ├── appsettings.Development.json       # Dev configuration
    │
    ├── Controllers/
    │   └── SalesController.cs             # API endpoints for CRUD
    │
    ├── Data/
    │   ├── SalesData.cs                   # Entity model
    │   └── SalesDbContext.cs              # EF Core DbContext
    │
    ├── Properties/
    │   └── launchSettings.json            # Launch configuration
    │
    ├── bin/                               # Compiled output
    │   └── Debug/
    │       └── net10.0/
    │
    └── obj/                               # Build artifacts
        └── Debug/
            └── net10.0/
```

### Key Files & Their Purposes

#### Frontend Key Files

| File | Purpose |
|------|---------|
| `src/App.tsx` | Main React component with PivotView and DataManager configuration |
| `src/main.tsx` | React application entry point and DOM mounting |
| `vite.config.ts` | Build tool configuration for development and production |
| `tsconfig.json` | TypeScript compiler settings |
| `package.json` | npm dependencies and build scripts |

#### Backend Key Files

| File | Purpose |
|------|---------|
| `Program.cs` | Application startup, services configuration (including EF Core), middleware setup |
| `Controllers/SalesController.cs` | REST API endpoints handling CRUD operations via DbContext |
| `Data/SalesData.cs` | Entity model mapped to the `SalesData` table |
| `Data/SalesDbContext.cs` | EF Core DbContext exposing `DbSet<SalesData>` |
| `appsettings.json` | Database connection string and configuration |
| `PivotTable_EFCore.Server.csproj` | Project dependencies (EF Core, SQL Server provider) |

---

## 🔧 Troubleshooting

### Common Issues & Solutions

#### Frontend Issues

**❌ "Cannot connect to server" error**
```
Error: Failed to fetch from https://localhost:7086/api/Sales
```

**✅ Solution:**
1. Verify backend is running: `dotnet run` in backend directory
2. Check port 7086 is not blocked by firewall
3. Verify CORS is enabled in Program.cs
4. Check browser console for exact error message

**❌ "TypeScript compilation error"**
```
error TS2307: Cannot find module '@syncfusion/ej2-react-pivotview'
```

**✅ Solution:**
1. Run `npm install` to install dependencies
2. Delete `node_modules` and `package-lock.json`
3. Run `npm install` again
4. Clear browser cache (Ctrl+Shift+Delete)

**❌ CORS blocked request**
```
Access to XMLHttpRequest blocked by CORS policy
```

**✅ Solution:**
1. Verify CORS is configured in backend Program.cs:
```csharp
app.UseCors("AllowAll");
```
2. Restart backend
3. Check frontend URL matches configured origin

#### Backend Issues

**❌ "Cannot connect to SQL Server"**
```
Microsoft.Data.SqlClient.SqlException: A network-related or instance-specific error occurred
```

**✅ Solution:**
1. Verify SQL Server is running:
   - LocalDB: Check `(localdb)\MSSQLLocalDB` instance
   - Express: Check `localhost\SQLEXPRESS` instance
   - Full SQL Server: Check SQL Server Configuration Manager
2. Check connection string in `appsettings.json`
3. Verify database exists: `sqlcmd -S . -Q "SELECT name FROM sys.databases"`
4. Test connection manually using SSMS or `sqlcmd`
5. Ensure TCP/IP protocol is enabled in SQL Server Configuration Manager

**❌ "Login failed for user" error**
```
System.Data.SqlClient.SqlException: Login failed for user 'sa'
```

**✅ Solution:**
1. Verify SQL Server authentication mode (Mixed Mode) is enabled
2. Check username and password in connection string
3. Use Windows Authentication (`Trusted_Connection=True`) if preferred
4. Reset SA password if necessary:
   ```sql
   ALTER LOGIN sa WITH PASSWORD = 'NewPassword';
   ```

**❌ "Database does not exist"**
```
Cannot open database "SalesDb" requested by the login
```

**✅ Solution:**
1. Create the database:
   ```sql
   CREATE DATABASE SalesDb;
   ```
2. Create the table (see Database Setup section)
3. Or enable automatic creation in Program.cs:
   ```csharp
   using (var scope = app.Services.CreateScope())
   {
       var db = scope.ServiceProvider.GetRequiredService<SalesDbContext>();
       db.Database.EnsureCreated();
   }
   ```

**❌ "Column does not exist" error**
```
Invalid column name 'SalesPerson'
```

**✅ Solution:**
1. Verify table schema matches `SalesData` model
2. Check SQL Server table structure:
   ```sql
   SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'SalesData';
   ```
3. Recreate table if needed (see Database Setup section)

**❌ Port 7086 already in use**
```
System.IO.IOException: Failed to bind to address
```

**✅ Solution:**
```powershell
# Find process using port (Windows PowerShell)
netstat -ano | findstr :7086

# Kill process (replace PID)
taskkill /PID <PID> /F

# Or use different port in launchSettings.json
```

#### Database Issues

**❌ "Trust certificate" error**
```
A connection was successfully established with the server, but then an error occurred during the login process.
```

**✅ Solution:**
1. Add `TrustServerCertificate=True;` to the connection string, or
2. Install the SQL Server certificate properly:
   ```powershell
   # For development, you can also use:
   dotnet dev-certs https --trust
   ```

**❌ "Permission denied" error**
```
The SELECT permission was denied on the object 'SalesData'
```

**✅ Solution:**
1. Grant the necessary permissions to your SQL Server user:
   ```sql
   USE SalesDb;
   GRANT SELECT, INSERT, UPDATE, DELETE ON SalesData TO [YourUser];
   ```

#### Performance Issues

**❌ Pivot table loads slowly**

**✅ Solutions:**
1. Create database indexes:
   ```sql
   CREATE INDEX idx_orderdate ON SalesData(OrderDate);
   CREATE INDEX idx_country ON SalesData(Country);
   CREATE INDEX idx_productcategory ON SalesData(ProductCategory);
   ```
2. Use `AsNoTracking()` for read-only queries (already implemented in the sample)
3. Reduce the number of rows in view
4. Use pagination instead of loading all data
5. Enable EF Core query splitting for complex queries

---

## 🤝 Contributing

### Contribution Guidelines

We welcome contributions! Here's how to get started:

1. **Fork the repository** (local development)
2. **Create a feature branch**:
   ```bash
   git checkout -b feature/your-feature-name
   ```
3. **Make your changes** with clear, descriptive commits
4. **Test thoroughly** before submitting
5. **Document your changes** in code comments

### Code Style & Standards

- Follow the existing code style (C# conventions, React/TypeScript best practices)
- Write meaningful commit messages
- Add comments for complex logic
- Test all CRUD operations
- Ensure no console errors
- Use EF Core migrations for schema changes

### Pull Request Process

1. Update documentation if needed
2. Test on both frontend and backend
3. Ensure all tests pass
4. Provide clear PR description

---

## 📜 License & support

This is a **commercial product** subject to the Syncfusion End User License Agreement (EULA).

**Free Community License** is available for qualifying users/organizations:
- Annual gross revenue < $1 million USD
- 5 or fewer total developers
- 10 or fewer total employees

The community license allows free use in both internal and commercial applications under these conditions.
No registration or approval is required — just comply with the terms.

**Paid Licenses** are required for:
- Larger organizations
- Teams exceeding the community license limits
- Priority support, custom patches, or on-premise deployment options

Purchase options and pricing: https://www.syncfusion.com/sales/products
30-day free trial (full features, no credit card required): https://www.syncfusion.com/downloads/essential-js2
Community License details & FAQ: https://www.syncfusion.com/products/communitylicense
Full EULA: https://www.syncfusion.com/eula/es/

© 2026 Syncfusion, Inc. All Rights Reserved.

