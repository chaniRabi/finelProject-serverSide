using AutoMapper;
using BL;
using DAL;
using DAL.Models;
using Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors();//איפשור גישה מצד לקוח לשרת 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//הזרקת תלויות - מודיע לראשי שהולך להשתמש בכמה תלויות, שכבות

builder.Services.AddScoped<ICategoryBL, CategoryBL>();
builder.Services.AddScoped<ICategoryDL, CategoryDL>();
builder.Services.AddScoped<IOrdersProductBL, OrdersProductBL>();
builder.Services.AddScoped<IOrdersProductDL, OrdersProductDL>();
builder.Services.AddScoped<IOrderBL, OrderBL>();
builder.Services.AddScoped<IOrderDL, OrderDL>();
builder.Services.AddScoped<ILookupBL, LookupBL>();
builder.Services.AddScoped<ILookupDL, LookupDL>();
builder.Services.AddScoped<IProductBL, ProductBL>();
builder.Services.AddScoped<IProductDL, ProductDL>();
builder.Services.AddScoped<IProductInCartBL, ProductInCartBL>();
builder.Services.AddScoped<IProductInCartDL, ProductInCartDL>();
builder.Services.AddScoped<IUserBL, UserBL>();
builder.Services.AddScoped<IUserDL, UserDL>();

builder.Services.AddAutoMapper(typeof(AutoMapping));
//services.AddAutoMapper(typeof(IUserBL));

builder.Services.AddDbContext<ShinestockContext>(options =>
    options.UseSqlServer("Server=MC-BJFUI18K5Y9V;Database=SHINESTOCK;Trusted_Connection=True;TrustServerCertificate=True;"));

//איפשור גישה מצד לקוח לשרת לפי כתובת מסויימת
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: MyAllowSpecificOrigins,
//                      policy =>
//                      {
//                          policy.WithOrigins("http://localhost:3000/");
//                      });
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.MapControllers();

app.Run();
