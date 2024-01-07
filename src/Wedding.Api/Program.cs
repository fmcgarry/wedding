using Wedding.Api;
using Wedding.Infrastructure;
using Wedding.UseCases;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config => config.EnableAnnotations());

// Uses FeatureExtensions.cs
builder.Services.RegisterFeatures(builder.Configuration);
builder.Services.AddUseCasesServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Uses FeatureExtensions.cs
app.MapFeatureEndpoints();

app.Run();