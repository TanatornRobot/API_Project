using Microsoft.EntityFrameworkCore;
using API_Project.Data;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// เชื่อมต่อฐานข้อมูล SQL Server ผ่าน ApplicationDbContext
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// เชื่อมต่อฐานข้อมูล PostgreSQL ผ่าน ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddControllers()
    .AddNewtonsoftJson(); // 👈 สำคัญมากสำหรับ JsonPatchDocument

var app = builder.Build();

// ตรวจสอบการเชื่อมต่อฐานข้อมูล
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    try
    {
        if (dbContext.Database.CanConnect())
        {
            Console.WriteLine("Database connection successful.");
        }
        else
        {
            Console.WriteLine("Database connection failed.");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Database connection error: {ex.Message}");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.UseHttpsRedirection();

app.UseAuthorization();

app.Run();
