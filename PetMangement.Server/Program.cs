using PetMangement.Server.Repositories.Consultation;
using PetMangement.Server.Repositories.Pet;
using PetMangement.Server.Repositories.Shower;
using PetMangement.Server.Repositories.Vaccine;
using PetMangement.Server.Services.Consultation;
using PetMangement.Server.Services.Pet;
using PetMangement.Server.Services.Shower;
using PetMangement.Server.Services.Vaccine;

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
builder.Services.AddScoped<IConsultationRepository, ConsultationRepository>();
builder.Services.AddScoped<IVaccineRepository, VaccineRepository>();
builder.Services.AddScoped<IShowerRepository, ShowerRepository>();



//Services
builder.Services.AddScoped<IPetService, PetService>();
builder.Services.AddScoped<IConsultationService, ConsultationService>();
builder.Services.AddScoped<IVaccineService, VaccineService>();
builder.Services.AddScoped<IShowerService, ShowerService>();



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
