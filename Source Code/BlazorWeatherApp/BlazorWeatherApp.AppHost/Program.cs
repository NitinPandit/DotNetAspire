
using Aspire.Hosting;
using Aspire.Hosting.ApplicationModel;

var builder = DistributedApplication.CreateBuilder(args);

//var sql = builder.AddSqlServer("sql",port:1455)
//                 .WithLifetime(ContainerLifetime.Persistent);
IResourceBuilder<ParameterResource>? dbPassword= builder.AddParameter("dbPassword",true);

var sql = builder.AddSqlServer("sql",dbPassword,1455)
                 .WithLifetime(ContainerLifetime.Persistent);

var db = sql.AddDatabase("database");

var MyAPI = builder.AddProject<Projects.BlazorWeatherApp_API>("api")
    .WithReference(db);

var MyFrontEnd = builder.AddProject<Projects.BlazorWeatherApp_WebApp>("myweatherapp")
    .WithReference(MyAPI)
    .WithExternalHttpEndpoints();

builder.Build().Run();


