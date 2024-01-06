using Wedding.Api;
using Wedding.UseCases;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config => config.EnableAnnotations());

// Uses FeatureExtensions.cs
builder.Services.RegisterFeatures(builder.Configuration);
builder.Services.AddApplicationServices();

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
