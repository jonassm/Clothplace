using System.Reflection;
using Backend.Repositories;
using Backend.Repositories.Interfaces;
using dotenv.net;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Load local settings without replacing variables supplied by the host.
DotEnv.Load(options: new DotEnvOptions(
    envFilePaths: [Path.Combine(builder.Environment.ContentRootPath, ".env")],
    overwriteExistingVars: false
)); //dotenv import skrevet af chat
builder.Configuration.AddEnvironmentVariables();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddCors(options =>
{
    options.AddPolicy("policy",
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseCors("policy");

app.UseAuthorization();

app.MapControllers();

app.Run();
