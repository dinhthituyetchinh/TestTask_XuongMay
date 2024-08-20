using Microsoft.EntityFrameworkCore;
using XuongMayBE.Data;
using XuongMayBE.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddDbContext<GarmentFactoryContext>(option =>
{ option.UseSqlServer(builder.Configuration.GetConnectionString("GarmentFactory")); });

// Đăng kí sử dụng AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

//Đăng kí class ProductRepository implement cho IProductRepository
builder.Services.AddScoped<IProductRepository, ProductRepository>();
//
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

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
