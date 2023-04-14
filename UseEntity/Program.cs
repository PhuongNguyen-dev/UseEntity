using Microsoft.EntityFrameworkCore;
using UseEntity.Entities;
using UseEntity.Helpers;
using UseEntity.Interfaces;
using UseEntity.Repositories;
using Yoong.WebShopping.Application.Interfaces;
using Yoong.WebShopping.Application.Repositories;
using Yoong.WebShopping.DAO.InterfacesDAO;
using Yoong.WebShopping.DAO.ServiceDAO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<WebShopContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebShop"));
});

builder.Services.AddAutoMapper(config=>
{
    config.AddProfile<ApplicationMapper>();
});



builder.Services.AddScoped<IUserRepository, UserService>();
builder.Services.AddScoped<IProductRepository, ProductService>();
builder.Services.AddScoped<ICartRepository, CartService>();
builder.Services.AddScoped<IProductDAO, ProductDAO>();
builder.Services.AddScoped<IUserDAO, UserDAO>();
builder.Services.AddScoped<ICartDAO, CartDAO>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("corsapp");

app.MapControllers();

app.Run();
