using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using XuongMayBE.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using XuongMayBE.Repositories;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

// Configures the application's DbContext with a SQL Server database connection.
builder.Services.AddDbContext<GarmentFactoryContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GarmentFactory")));

// Sets up ASP.NET Core Identity with Entity Framework Core for storing user data.
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<GarmentFactoryContext>()
    .AddDefaultTokenProviders();

// Registers the AccountRepository with a scoped lifetime, ensuring a new instance is created per request.
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

// Configures authentication using JWT Bearer tokens.
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirects HTTP requests to HTTPS.
app.UseHttpsRedirection();

// Enables authorization middleware.
app.UseAuthorization();

// Maps controllers to endpoints.
app.MapControllers();

app.Run();
