using Microsoft.EntityFrameworkCore;
using TAL.PremiumCalculator.Data;
using TAL.PremiumCalculator.Data.Abstractions;

var builder = WebApplication.CreateBuilder(args);

// add services to the container
builder.Services.AddControllers();

// add swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add db context
builder.Services.AddDbContext<IPremiumCalculatorContext, PremiumCalculatorContext>(options => options.UseSqlServer("PremiumCalculatorConnectionString"));

var app = builder.Build();

// enable swagger (for development and prod)
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();