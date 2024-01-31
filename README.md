# Dotnet7-Store
This project was generated with Dotnet v7, entity framework, local ms database connection

## Development server
After connecting to a Database (I connected using a local ms sqllocaldb) run the migration to populate your database with the required tables `dotnet ef database update`. You should see 3 tables Product, Customer, Purchase. 
To run the webapi run `dotnet run` and open the local swagger to view the available apis.  For example 'http://localhost:5013/swagger/index.html'.

## Code Explanation
Once the backend starts, I connect to the defined database. You should define it inside `appsettings.json` and in `StoreContext.cs`. In the `StoreContext.cs` I define all the tables and their columns. Each entity has it's own controller, 
where I have some basic apis(create, edit, delete). On create I compare their `Name` column even though it may not be unique. The edit and delete are working by finding the Ids. The Purchase api is a little more complicated, since the payload is an array/List.

