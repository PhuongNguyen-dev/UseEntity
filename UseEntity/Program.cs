using Microsoft.EntityFrameworkCore;
using UseEntity.Entities;
using UseEntity.Helpers;
using UseEntity.Interfaces;
using UseEntity.Repositories;
using Yoong.WebShopping.Application.Interfaces;
using Yoong.WebShopping.Application.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<WebShopContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebShop"));
});

builder.Services.AddAutoMapper(config=>
{
    config.AddProfile<ApplicationMapper>();
});



builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICartRepository, CartRepository>();

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
