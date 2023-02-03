using Employee_Application.Handlers;
using Employee_Core.Repositories.Base;
using Employee_Core.Repositories;
using Employee_Infrastructure.Data;
using Employee_Infrastructure.Repositories.Base;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Employee_Core.Entities;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddAuthentication(opt => {
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,// Server that created issuer
            ValidateAudience = true,// receiver of the token is a valid recipient
            ValidateLifetime = true,// make sure that token is valid
            ValidateIssuerSigningKey = true,// ensure signing key is valid and is trusted by the server
            ValidIssuer = "https://localhost:7034",
            ValidAudience = "https://localhost:7034",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))
            //here we are providing values for issuer, audience and secret key so that it generates signature for jwt
        };
    });


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();





//void ConfigureServices(IServiceCollection services)
//{
builder.Services.AddControllers();
    
builder.Services.AddDbContext<EmployeeContext>(m => m.UseSqlServer(builder.Configuration.GetConnectionString("EmployeeDB")), ServiceLifetime.Singleton);


    //builder.Services.AddSwaggerGen(c => {
    //    c.SwaggerDoc("v1", new OpenApiInfo
    //    {
    //        Title = "Employee.API",
    //        Version = "v1"
    //    });
    //});


    
    builder.Services.AddMediatR(typeof(CreateEmployeeHandler).GetTypeInfo().Assembly);
    builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
    builder.Services.AddScoped<IAuthDataRepository<Login>, AuthServices>();
//}

builder.Services.AddAutoMapper(typeof(Program));




builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Employee JWT Token Authentication API",
        Description = "ASP.NET Core 6.0 Web API"
    });
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
    });
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
           new OpenApiSecurityScheme
           {
             Reference = new OpenApiReference
             {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
             }
           },
           new string[] { }
        }
    });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
