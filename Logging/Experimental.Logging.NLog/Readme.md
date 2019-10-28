# Sample implementation for NLog logging
This project is intended to introduce NLog logging into a ASP .NET Core application.
[Just followed the NLog tutorial...](https://github.com/NLog/NLog/wiki/Getting-started-with-ASP.NET-Core-3)

Little extensions: 
* Add logger in Startup.cs and trace warning if development environment is used
* Configure ColoredConsole as additional NLog target to get colored console logs (or even console logs at all)