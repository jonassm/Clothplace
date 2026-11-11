using dotenv.net;

var builder = WebApplication.CreateBuilder(args);

// Load local settings without replacing variables supplied by the host.
DotEnv.Load(options: new DotEnvOptions(
    envFilePaths: [Path.Combine(builder.Environment.ContentRootPath, ".env")],
    overwriteExistingVars: false
));
builder.Configuration.AddEnvironmentVariables();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
