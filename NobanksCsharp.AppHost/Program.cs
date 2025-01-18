var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.NobanksCsharp_ApiService>("apiservice");

builder.AddProject<Projects.NobanksCsharp_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
