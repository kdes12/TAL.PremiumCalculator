using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TAL.PremiumCalculator.API;
using TAL.PremiumCalculator.Business;
using TAL.PremiumCalculator.Business.Abstractions;
using TAL.PremiumCalculator.Business.Mappers;
using TAL.PremiumCalculator.Business.Objects;
using TAL.PremiumCalculator.Data;
using TAL.PremiumCalculator.Data.Abstractions;
using TAL.PremiumCalculator.Data.Models;
using ConfigurationManager = TAL.PremiumCalculator.Business.ConfigurationManager;

var builder = WebApplication.CreateBuilder(args);

// add services to the container
builder.Services.AddControllers();

builder.Services.AddSingleton<IMapper<Occupation, OccupationResponse>, OccupationMapper>();

builder.Services.AddScoped<IOccupationRepository, OccupationRepository>();
builder.Services.AddScoped<IOccupationManager, OccupationManager>();

builder.Services.AddScoped<IConfigurationRepository, ConfigurationRepository>();
builder.Services.AddScoped<IConfigurationManager, ConfigurationManager>();

builder.Services.AddScoped<IPremiumManager, PremiumManager>();

// add swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add db context
builder.Services.AddDbContext<PremiumCalculatorContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString(Constants.CONNECTION_STRING_KEY)));

// add production CORS policy
builder.Services.AddCors(options =>
{
    // get allowed origins as list of strings
    string[] allowedOrigins = (builder.Configuration.GetValue<string>(Constants.CORS_ORIGINS_KEY) ?? string.Empty)
                                .Split(Constants.CORS_ORIGINS_DELIMITER);

    // add origins to CORS policy
    options.AddPolicy(name: Constants.CORS_POLICY_NAME,
        policy =>
        {
            policy
                .WithOrigins(allowedOrigins)
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

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
    app.UseCors(Constants.CORS_POLICY_NAME);
}

app.Run();
