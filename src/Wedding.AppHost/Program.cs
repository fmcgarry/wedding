var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.Wedding_Api>("wedding-api");

builder.AddProject<Projects.WeddingApp>("app")
    .WithReference(api);

builder.Build().Run();
