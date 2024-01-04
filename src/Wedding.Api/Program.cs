using Wedding.Api;
using Wedding.Infrastructure.Photos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config => config.EnableAnnotations());

builder.Services.AddPhotoClient(builder.Configuration);

// Uses FeatureExtensions.cs
builder.Services.RegisterFeatureServices();

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
