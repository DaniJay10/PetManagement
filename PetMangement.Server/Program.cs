using PetMangement.Server.Repositories.Pet;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("ReactPolicy", policy =>
    {
        policy.WithOrigins("http://localhost:54518", "https://localhost:54518")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

//Repositories
builder.Services.AddScoped<IPetRepository, PetRepository>();


//Services

var app = builder.Build();

app.UseDefaultFiles();
app.MapStaticAssets();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
