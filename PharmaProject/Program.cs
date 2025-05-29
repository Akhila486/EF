using Microsoft.EntityFrameworkCore;
using PharmaProject.Data;
using PharmaProject.Services;
using PharmaProject.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MedicineDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("HospitalConnection")));

builder.Services.AddTransient<IMedicine, MedicineService>();
builder.Services.AddControllers();

// 🔽 Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

// 🔽 Enable Swagger in development (or always)

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage(); // Add this for detailed errors
}
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();
app.Run();
