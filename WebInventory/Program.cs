using Application;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using WebInventory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<InventoryDBContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("Default")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// local dI
builder.Services.RegisterMapsterConfigure();
builder.Services.AddDependencyInyectionApplication();
builder.Services.AddDependencyInjection();
builder.Services.AddDependencyInjectionInfrastructure();

// handle exceptions
builder.Services.RegisterExceptionConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
// to use exceptions
app.UseExceptionHandler(_ => { });

app.Run();
