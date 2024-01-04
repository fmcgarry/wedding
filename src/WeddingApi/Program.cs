using WeddingApi;
using WeddingApi.Infrastructure.Photos;
using WeddingApi.Photos;
using WeddingApi.SongRequests;

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
app.MapPhotoApi();
app.MapSongRequestApi();

// Uses ModuleExtensions.cs
app.MapModuleEndpoints();

app.Run();
