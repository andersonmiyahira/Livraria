# Livraria 

Simple Book APP built using .Net Core and Angular Framework.
## Getting Started

### Prerequisites

* .NET Core 2.1
* Node v8.9.4
* npm 
* Angular CLI

## Running project

### Checkout this repository 

```
git clone https://github.com/andersonmiyahira/Livraria.git
```

### Database setup
Run the script located at `sql/Script_Livraria_18112018` on your SQL Server.

### Setup your connection string
On file located at `src\Livraria.API\appsettings.json`, change connection string with your database params.

### Backend 

On the root path, run the following commands:

```
1 - dotnet restore
2 - dotnet run -p src\Livraria.WebApi
```

API will run at http://localhost:49180

### Frontend

On the root path, run the following commands:

```
cd src/Livraria.APP
npm install 
npm start
```

Frontend application will run at http://localhost:4200

## Running the tests

On the root path, run the following command:

```
dotnet test src/Test
```


## Built With

* [.NET Core](https://www.microsoft.com/net/learn/get-started/) - DDD, Entity Framework Core, DI, AutoMapper
* [Angular 6](https://angular.io/)
* [Bootstrap 4](https://getbootstrap.com/docs/4.1/getting-started/introduction/)
* [Visual Studio Code](https://rometools.github.io/rome/) 

## Author

* **Anderson Miyahira** 
