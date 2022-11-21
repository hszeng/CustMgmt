# Summary:

This is a demo project which allows company to see customer information. It is developed with the following techniques and tools:
 - .Net Core 3.1 Web Api 
 - Sql Server 2019 developer version
 - Swagger 6.0.0
 - EF Core 5.0.17
 - Linq Synamic Core 1.2.23
 - NewtonSoftJson 3.1.31
 - AutoMapper 8.1.1
 - Visual Studio 2019 Community 

# How To Build and Run this Demo Project:*

  - Clone this repo to you local
  - Open the "CustMgmt.sln" solution with Visual Studio 2019
  - Create a database "CustMgmt" on your SQL server . 
  - Run the following script in this database to add new login user

		```
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
		```

  - Update the "ConnectionStrings.DefaultConnection" with the connection string to this new created database in the "appsettings.json" file under the "CustMgmt" project
  - Build the solution in your Visual Studio.
  - Open the "Package Manager Console" in your Visual Studio, then execute the following command in this console

  		```
		Update-Database
		```

  - Run Debugging in your Visual Studio. It will automatically open the Swagger UI.

	+ If you are using "IIS Express" or self-hosted option to do the debug, then you are ready to go.
	+ If you are using "Docker" option to do the debugging, you need to update the ConnectionStrings.DefaultConnection in appSettings.json -- Replace the “localhost” to the actual SQL server Ip address. 
  - Swagger UI
	![Swagger](CustMgmtSwagger.png)

# Key Implementations In this Demo Project

  - Restful Apis for:
	* Customer : Add, Edit, Delete, List(with filter and pagination), GetById
	* Note: Add, Edit, Delete, List(under a customer), GetById
  - Demostrated how to use the optimistic locking when modify an entity
	* Defined the concurrency token in both Customer and Note entity, it is handled in native database level(another option of Application-managed concurrency tokens is in app level:https://learn.microsoft.com/en-us/ef/core/saving/concurrency?tabs=data-annotations)

		```
		[Timestamp]
        public byte[] Version { get; set; }
		```
		
	* The corresponding exception "DbUpdateConcurrencyException" is handled in JsonExceptionFilter filter, it will return http status code 409 to inform front end for updating conflict.
  - This project took me about 8 hours to complete, which included at least 2 hours in testing.
  - If I have more time. I will improve some of the following aspects:
	* Add interface to manipulate the database since most of the opertions are quite similiar.
	* Add some wrapper repository to update the CreateAt,ModifyAt,DeletedAt in a unified place since those fields. 
	* Add Authentication and Authorization to this project since both are normally required by all systems. 
	* Other TBD 
