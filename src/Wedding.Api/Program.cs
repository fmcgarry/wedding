using Wedding.Api;
using Wedding.Api.SongRequests;
using Wedding.Infrastructure.Photos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(config => config.EnableAnnotations());

builder.Services.AddPhotoClient(builder.Configuration);

// Uses ModuleExtensions.cs
builder.Services.RegisterModuleServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Uses my way
app.MapSongRequestApi();

// Uses ModuleExtensions.cs
app.MapModuleEndpoints();

app.Run();
