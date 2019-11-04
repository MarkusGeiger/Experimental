# Experimental
Collection of some experiments, Proof-of-concept and others...

## ASP .NET Core
Goal is to implement all neccesary features for a WebAPI in single increments.
Steps are cropped as small as possible, to provide flexibility in learning.
Current targets:

#### [Experimental.Static](Experimental.Static)
Serving static files with ASP .NET Core

#### [Experimental.Swagger](Experimental.Swagger)
##### Sample implementation for swashbuckle
This project is configured to serve a full-featured swagger UI and swagger API description.
[Just followed the MSDN tutorial...](https://docs.microsoft.com/de-de/aspnet/core/tutorials/getting-started-with-swashbuckle)


## Logging

#### [Experimental.Logging.BuiltIn](Logging/Experimental.Logging.BuiltIn)
##### Sample implementation of the builtin logging system
This project demonstrates the usage of builtin logging in ASP .NET Core
[Just followed the tutorial on MSDN...](https://docs.microsoft.com/de-de/aspnet/core/fundamentals/logging/?view=aspnetcore-3.0)

#### [Experimental.Logging.NLog](Logging/Experimental.Logging.NLog)
##### Sample implementation for NLog logging
This project is intended to introduce NLog logging into a ASP .NET Core application.
[Just followed the NLog tutorial...](https://github.com/NLog/NLog/wiki/Getting-started-with-ASP.NET-Core-3)

Little extensions: 
* Add logger in Startup.cs and trace warning if development environment is used
* Configure ColoredConsole as additional NLog target to get colored console logs (or even console logs at all)

## Database

#### [Experimental.TodoApi](Experimental.TodoApi)
##### Tutorial implementation of the ASP .NET Core TodoApp
* [Tutorial: Create a web API with ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-3.0&tabs=visual-studio)
* [Tutorial: Call an ASP.NET Core web API with JavaScript](https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-javascript?view=aspnetcore-3.0)

#### [Experimental.TodoApiMongoDB](Experimental.TodoApiMongoDB)
##### Tutorial implementation of the ASP .NET Core TodoApp and MongoDB
Replace the SQL InMemory Database with MongoDB following the MongoDB tutorial

###### Todo Tutorials
* [Tutorial: Create a web API with ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-3.0&tabs=visual-studio)
* [Tutorial: Call an ASP.NET Core web API with JavaScript](https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-javascript?view=aspnetcore-3.0)

###### MongoDB Tutorial
* [Create a WebAPI with ASP .Net Core and MongoDB](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-3.0&tabs=visual-studio)
* [MongoDB download page](https://www.mongodb.com/download-center/community)

## Telegram Bots
#### [Experimental.EchoBot](Experimental.EchoBot)
* [Global exception handling in ASP.NET Core](http://www.herlitz.nu/2019/05/05/global-exception-handling-asp.net-core/)
* [.NET Client for Telegram Bot API](https://github.com/TelegramBots/Telegram.Bot)
* [Safe storage of app secrets in development in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-3.0&tabs=windows)

## Metrics
#### AppMetrics
## IdentityServer4
## Frontend
#### Angular
