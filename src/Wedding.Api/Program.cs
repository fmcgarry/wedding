using Microsoft.EntityFrameworkCore;
using Wedding.Api;
using Wedding.Infrastructure;
using Wedding.Infrastructure.Data;
using Wedding.UseCases;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config => config.EnableAnnotations());

// Uses FeatureExtensions.cs
builder.Services.RegisterFeatures(builder.Configuration);

// Register Clean Architecture services
builder.Services.AddUseCasesServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    if (!builder.Configuration.GetValue<bool>("UseInMemoryDb"))
    {
        // Apply db migrations automatically for developers
        using (IServiceScope scope = app.Services.CreateScope())
        {
            ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
        }
    }
}

app.UseHttpsRedirection();

// Uses FeatureExtensions.cs
app.MapFeatureEndpoints();

app.Run();