# Travel and Expense Items API C# ASP Backend

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
