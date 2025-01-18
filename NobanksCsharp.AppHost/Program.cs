var builder = DistributedApplication.CreateBuilder(args);

var mongo = builder
    .AddMongoDB("mongo")
    .WithLifetime(ContainerLifetime.Persistent);

var mongodb = mongo.AddDatabase("mongodb");

var apiService =
    builder.AddProject<Projects.NobanksCsharp_ApiService>("apiservice")
        .WithReference(mongodb)
        .WaitFor(mongodb);

builder.AddProject<Projects.NobanksCsharp_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
