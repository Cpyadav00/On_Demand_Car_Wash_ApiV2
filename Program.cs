using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

//builder.Services.Configureservices.Configure<AuthMessageSenderOptions>(Configuration);

builder.Services.AddTransient<IUserDetail, UserDetailRepository>();
builder.Services.AddTransient<UserDetailService, UserDetailService>();

builder.Services.AddTransient<ISubscriber, SubscriberRepository>();
builder.Services.AddTransient<SubscriberService, SubscriberService>();

builder.Services.AddTransient<IContactUs, ContactUsRepository>();
builder.Services.AddTransient<ContactUsService, ContactUsService>();

builder.Services.AddScoped<IOrderSendingData, OrderSendingDataRepository>();
builder.Services.AddScoped<OrderSendingDataService, OrderSendingDataService>();

builder.Services.AddScoped<ICar, CarRepository>();
builder.Services.AddScoped<CarService, CarService>();

builder.Services.AddTransient<IEmail, EmailRepository>();
builder.Services.AddTransient<EmailService, EmailService>();

builder.Services.AddScoped<IRating, RatingRepository>();
builder.Services.AddScoped<RatingService, RatingService>();

builder.Services.AddScoped<IPackage, PackageRepository>();
builder.Services.AddScoped<PackageService, PackageService>();


builder.Services.AddScoped<IAddress, AddressRepository>();
builder.Services.AddScoped<AddressService, AddressService>();

builder.Services.AddScoped<IOrder, OrderRepository>();
builder.Services.AddScoped<OrderService, OrderService>();

builder.Services.AddScoped<IPayment, PaymentRepository>();
builder.Services.AddScoped<PaymentService, PaymentService>();


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
