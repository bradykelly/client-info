# The Client Info Assessment

#### Not Finished
Regretfully, I have a small issue with starting the Web App client, but it does build. 
Just when it runs, nearly all calls to the Web API result in a 404.
I also have not done addresses and contacts in the client, nor the export. 
I hope you can evaluate my skills just from the code provided.

### Environment
The solution was developed in Visual Studio and ASP.NET Core 2.0 using SQL Server 2017.
However I have scripted the database for MSSQL 2014. A script for creating the database
with data is present in the `Data` folder of the repo.

#### The Client
The solution comprises a web application for managing `Client` information. 
This uses a `DataClient` to make calls to a Web API via `HttpClient`.

#### The API
The API supplies CRUD services for The Client project.
The API controllers delegate their responsibility to a `DataServer` for data access 
and very little progress.
