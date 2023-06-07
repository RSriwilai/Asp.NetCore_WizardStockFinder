using Microsoft.EntityFrameworkCore;
using WizardStockFinder.DataAccess.DataContext;
using WizardStockFinder.WebApi.App_Start;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<WizardStockFinderDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("WizardStockFinderConnection"));
});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
// Add services to the container.
builder.Services.LoadServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
