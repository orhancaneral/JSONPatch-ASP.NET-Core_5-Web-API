# JSON Patch in an ASP.NET Core 5 Web API
Demo to show you as use **JSON Patch** in an *ASP.NET Core 5 Web API*

## .NET 5
This sample code use .NET 5 and C# as programming language.

You will find the last [.NET 5 SDK version here](https://dotnet.microsoft.com/download/dotnet/5.0)

## NuGet Packages needed
- [Microsoft.AspNetCore.Mvc.NewtonsoftJson](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.NewtonsoftJson/)

> Note that there is another package that is used here, **Microsoft.AspNetCore.JsonPatch**, however, this package is a reference of **Microsoft.AspNetCore.Mvc.NewtonsoftJson**.

## Testing the Web API

Start the Web API and execute the next operations:

### Create new Employee
**POST** operation to the endpoint **https://localhost:44372/api/employee/**

JSON payload in the *Body*

```csharp
{
    "Name": "Charles",
    "Age": 22
}
```

The response will be a **200 OK** with a *Guid* value that will be the **id** of the employee


### Get an Employee by Id
**GET** operation to the endpoint **https://localhost:44372/api/employee/{id}** where *{id}* is the *Guid* created in the **POST** operation

You will receive a **200 OK** with a JSON information like:

```csharp
{
    "id": "93a5f5e3-dfcf-40dc-9d85-2d0757302d52",
    "name": "Charles",
    "age": 22
}
```


### Get all the employees
**GET** operation to the endpoint **https://localhost:44372/api/employee/**

You will receive a **200 OK** with all the employees, with a JSON information like:

```csharp
[
    {
        "id": "93a5f5e3-dfcf-40dc-9d85-2d0757302d52",
        "name": "Frank",
        "age": 37
    }
]
```


### Update some data of an existing employee
**PATCH** operation to the endpoint **https://localhost:44372/api/employee/update/{id}** where *{id}* is the *Guid* created in the **POST** operation

To call to this operation, you will have to send a payload with an arry with each operation that you want to do.

If you want to modify the *Name* and *Age* of an employee, you will have to send two operations in the payload like:

```csharp
[
    {"op" : "replace", "path" : "/Name", "value" : "Frank"},
    {"op" : "replace", "path" : "/Age", "value" : "37"}
]
```

You will receive a **200 OK** with the employee modified:

```csharp
{
    "id": "93a5f5e3-dfcf-40dc-9d85-2d0757302d52",
    "name": "Frank",
    "age": 37
}
```

## References
[RFC-6902](https://tools.ietf.org/html/rfc6902)
