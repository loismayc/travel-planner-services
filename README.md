# Travel Expenses Planner ASP.NET Backend

##Set-up

1. Please see files under "Controllers" folder to check available endpoints.
2. Edit the connection strings file configuration to connect to server
3. Navigate to project directory in CMD and type "dotnet run".

Note: This is connected to the frontend project I made here:
You can edit the api URL for each service under "Services" folder to integrate with the back-end application

## Commands for Testing (via curl)

### Fetching all Expense Items

```
curl http://localhost:5137/expense_items | jq
```

### Saving a New Expense Item from file `payloads/expenseItem.json`

```
curl -X POST -H "Content-Type: application/json" -d @payloads/expenseItem.json http://localhost:5137/expense_items | jq
```

### Fetching all Travel Items

```
curl http://localhost:5137/travel_items | jq
```

### Saving a New Travel Item from file `payloads/travelItem.json`

```
curl -X POST -H "Content-Type: application/json" -d @payloads/travelItem.json http://localhost:5137/travel_items | jq
```

### delete using id

```
curl -X DELETE http://localhost:5137/travel_items/{}
```

### dotnet ef commands

```
dotnet ef migrations add ""
```

```
dotnet ef database update
```

## Database Setup

### Add SQLServer Dependencies for EntityFramework

```
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```

### Add EntityFrameworkCore Design Package

```
dotnet add package Microsoft.EntityFrameworkCore.Design
```

### Add the Dotnet EF Tool

```
dotnet tool install --global dotnet-ef
```

```
dotnet-ef --version
```
