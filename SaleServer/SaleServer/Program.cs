using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Orders.BL;
using Orders.Dal;
using SaleServer.BL;
using SaleServer.DAL;
using SaleServer.Middleware;
using SaleServer.Models;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Numerics;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using SaleServer;
using Microsoft.AspNetCore.Authentication;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<Igifts, giftsBL>();
builder.Services.AddScoped<IgiftsDal, giftDal>();
builder.Services.AddScoped<IuserBL, UserBL>();
builder.Services.AddScoped<IuserDal, UserDal>();
builder.Services.AddScoped<IorderBL, OrderBl>();
builder.Services.AddScoped<IorderDal, OrderDal>();
builder.Services.AddScoped<Idonor, donorBL>();
builder.Services.AddScoped<IdonorDal, donorDal>();
builder.Services.AddScoped<IWinnerBl, WinnerBl>();
builder.Services.AddScoped<IWinnerDal, WinnerDal>();
builder.Services.AddControllers();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true
    };
});
builder.Services.AddAuthorization();
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true )
    .AddEnvironmentVariables();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SaleContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("SaleContext")));
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", 
                  builder =>
                  {
                      builder.WithOrigins("http://localhost:4200",
                                           "development web site")
                                          .AllowAnyHeader()
                                          .AllowAnyMethod()
                                          ;
                  });

});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                    Array.Empty<string>()
                }
            });

    c.OperationFilter<SecurityRequirementsOperationFilter>();
});


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseRouting(); 

app.UseAuthentication();
app.UseAuthorization();

app.UseWhen(context => !context.Request.Path.StartsWithSegments("/api/Login")&& !context.Request.Path.StartsWithSegments("/api/User/register"), orderApp =>
{
    orderApp.Use(async (context, next) =>
    {
        if (context.Request.Headers.ContainsKey("Authorization"))
        {
            var authorizationHeader = context.Request.Headers["Authorization"].ToString();
            if (authorizationHeader.StartsWith("Bearer "))
            {
                context.Request.Headers["Authorization"] = authorizationHeader.Substring("Bearer ".Length);
            }
        }

        await next();
    });
    orderApp.UseMiddleware<SaleServer.Middleware.AuthenticationMiddleware>();
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();