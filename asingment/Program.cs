using asingment.Model;
using BusinessLogicLayer.IRepository;
using BusinessLogicLayer.Repository;
using DataAccessLayer.IRepository;
using DataAccessLayer.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<ITaskRepo, TaskRepo>();
builder.Services.AddScoped<IHelperRepo, HelperRepo>();
builder.Services.AddScoped<IFilterRepo, FilterRepo>();
builder.Services.AddScoped<IPersonRepo, PersonRepo>();

builder.Services.AddScoped<IPersonBLL, PersonBLL>();
builder.Services.AddScoped<ITasksBLL, TasksBLL>();
builder.Services.AddScoped<IHelperBLL, HelperBLL>();
builder.Services.AddScoped<IFilterBLL, FilterBLL>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
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

app.Run();
