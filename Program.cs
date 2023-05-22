using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using On_Demand_Car_Wash_ApiV2.Context;
using On_Demand_Car_Wash_ApiV2.IRepository;
using On_Demand_Car_Wash_ApiV2.Repository;
using On_Demand_Car_Wash_ApiV2.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//adding cors 
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

//adding dbcontext 
builder.Services.AddDbContext<CarDbContext>(option => {
    option.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection"));
});



builder.Services.AddScoped<IUserDetail, UserDetailRepository>();
builder.Services.AddScoped<UserDetailService, UserDetailService>();

//builder.Services.AddScoped<ICar, CarRepository>();
//builder.Services.AddScoped<CarService, CarService>();

builder.Services.AddScoped<IPackage, PackageRepository>();
builder.Services.AddScoped<PackageService, PackageService>();


builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is the secret key we will use to generate token for the project")),
        ValidateAudience = false,
        ValidateIssuer = false,
        ClockSkew=TimeSpan.Zero   // to change default time 5 minute
    };

});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
