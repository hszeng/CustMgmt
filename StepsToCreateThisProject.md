# This Project was Created with the Following Steps:
1. In VS 2019, Create a .net core 3.1 api project
2. Add Swagger support
	 - Add nuget package Swashbuckle.AspNetCore: Install-Package Swashbuckle.AspNetCore -Version 6.4.0
	 - Add and configure Swagger middleware
	 - The the API document is at http://localhost:<port>/swagger/v1/swagger.json
	 - The Swagger UI is at http://localhost:<port>/swagger
3. Add EF Core related packages 
     - Microsoft.EntityFrameworkCore
	 - Microsoft.EntityFrameworkCore.SqlServer
	 - Microsoft.EntityFrameworkCore.Tools
4. Create a new database in Sql Server : CustMgmt, and setup a login user
		
		USE master
		GO

		CREATE LOGIN demouser WITH PASSWORD = 'demouser@CustMgmt'
		GO

		Create Database [CustMgmt]
		GO

		Use [CustMgmt]
		GO

		  IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'demouser')
		  BEGIN
			CREATE USER [demouser] FOR LOGIN [demouser]
			EXEC sp_addrolemember N'db_owner', N'demouser'
		  END;
		 GO


5. Add database connect string to the appsettings.json 
	Data Source=localhost;Initial Catalog=CustMgmt;User ID=demouser;Password=demouser@CustMgmt

6. Define the CustMgmt Database Context and and the Database Migration(Code first )
	- Add seed data and data migration
	- Execute "Add-Migration InitialCreation" in the Package Manager Console
	- Execute "Update-Database" in the Package Manager Console
7. Add "Data Transfer Object" for defined entities previously
8. Add AutoMapper nuget package
	- Define the Profile file
	- "AddAutoMapper" in StartUp 
9. Add Microsoft.AspNetCore.Mvc.NewtonsoftJson(Newtonsoft.Json) nuget package
	- Add json formatter in ConfigureServices
10. Add System.Linq.Dynamic.Core 
    - Add LINQ extensions
11. Implement APIs
	- Customer CRUD
	- Note CRUD
	- Add Api filter such as  api error handler(JsonExceptionFilter) and RESTful resource filter(CheckCustomerExistFilterAttribute)
