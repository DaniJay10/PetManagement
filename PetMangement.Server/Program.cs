using PetMangement.Server.Repositories.Pet;
using PetMangement.Server.Services.Pet;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Swagger = probar api sin construir frontend
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
builder.Services.AddScoped<IPetService, PetService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseDefaultFiles();
app.MapStaticAssets();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
