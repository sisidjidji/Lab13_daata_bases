# Lab13_daata_bases

# Lab 13: Async Inn Management System
## The Problem Domain
Now that you have a solid understanding of your database schema for your hotel management system, today you will build off of your initial web application from lab 12 and integrate into it our database tables from our ERD.

## Application Specifications
Your application should include the following upon completion:

## Startup File
Explicit routing of MVC
 MVC dependency in ConfigureServices
DBContext registered in ConfigureServices Data
DBContext present and properly configured
DB Tables for each entity model (DbSet<T>)
Composite key association present in OnModelCreating override.
appsettings.json file present with name of database updated
Default data seeded
Models
Each Entity from the DB Table converted into a Model
Proper naming conventions of Primary keys
Navigation properties present in each Model where required
Enum present in appropriate model
##Guidance
Using your ERD Diagram, convert each entity into a model within your newly created MVC web application.

Within your DbContext, declare your Database tables and set your composite keys for the required tables

Add default data to your database by seeding your database. Be sure have at least:
5 default Hotel Locations
6 Room Types
5 Amenities.
Don’t forget to add a new migration and update your database when completed!
##Steps:
For each Entity that you have in your ERD, create a new class in your Models folder.
Inside your DbContext, create a new table/DbSet<T> for each of your created entity classes
Add your composite key associations to your overridden OnModelCreating method.
Run the command add-migration {nameOfMigration}
Run the command Update-database and confirm your database now has the appropriate tables.
Add Summary comments to your code where necessary.

