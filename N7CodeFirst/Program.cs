using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using N7CodeFirst;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var s = builder.Configuration.GetConnectionString("SchoolDb");
builder.Services.AddDbContext<SchoolDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolDb"));
});


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

// Add this line to create an instance of DbContextOptions
var optionsBuilder = new DbContextOptionsBuilder<SchoolDbContext>();

// Pass the connection string to the options builder
optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("SchoolDb"));

// Create a new instance of the context using the options builder
using (var dbContext = new SchoolDbContext(optionsBuilder.Options))
{
    // Call the SeedData method to seed the database
    SchoolDbContext.SeedData(dbContext);
}

app.Run();
