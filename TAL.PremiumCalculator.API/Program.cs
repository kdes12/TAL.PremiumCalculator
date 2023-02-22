using Microsoft.EntityFrameworkCore;
using TAL.PremiumCalculator.API;
using TAL.PremiumCalculator.Business;
using TAL.PremiumCalculator.Business.Abstractions;
using TAL.PremiumCalculator.Business.Mappers;
using TAL.PremiumCalculator.Business.Objects;
using TAL.PremiumCalculator.Data;
using TAL.PremiumCalculator.Data.Abstractions;
using TAL.PremiumCalculator.Data.Models;

var builder = WebApplication.CreateBuilder(args);

// add services to the container
builder.Services.AddControllers();

builder.Services.AddSingleton<IMapper<Occupation, OccupationResponse>, OccupationMapper>();

builder.Services.AddScoped<IOccupationRepository, OccupationRepository>();
builder.Services.AddScoped<IOccupationManager, OccupationManager>();
builder.Services.AddScoped<IPremiumManager, PremiumManager>();

// add swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add db context
builder.Services.AddDbContext<PremiumCalculatorContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString(Constants.CONNECTION_STRING)));

var app = builder.Build();

// enable swagger (for development and prod)
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    // allow all hosts for dev
    app.UseCors(policy => policy
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed(origin => true));
}
else
{
    // restrict hosts in prod
    app.UseCors(policy => policy
        .AllowAnyMethod()
        .AllowAnyHeader()
        .WithOrigins((builder.Configuration.GetValue<string>("AllowedHosts")?.ToString() ?? string.Empty).Split(";")));
}

app.Run();