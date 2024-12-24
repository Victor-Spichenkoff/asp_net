using System.Text;
using Estudo1.Data;
using Estudo1.Interfaces;
using Estudo1.Repositories;
using Estudo1.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Estudo1.Helpers;

public static class BuilderExtensions
{
    // passava apenas services.AddScoped()...
        // public static void ConfigureBuilder(this IServiceCollection services)
    public static void ConfigureBuilder(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        // builder.Services.AddEndpointsApiExplorer();
        // builder.Services.AddSwaggerGen(c =>
        //     {
        //         c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        //         {
        //             Name = "Authorization",
        //             In = ParameterLocation.Header,
        //             Type = SecuritySchemeType.ApiKey,
        //             Scheme = "Bearer"
        //         });
        //
        //         c.AddSecurityRequirement(new OpenApiSecurityRequirement()
        //         {
        //             {
        //                 new OpenApiSecurityScheme
        //                 {
        //                     Reference = new OpenApiReference
        //                     {
        //                         Type = ReferenceType.SecurityScheme,
        //                         Id = "Bearer"
        //                     },
        //                     Scheme = "oauth2",
        //                     Name = "Bearer",
        //                     In = ParameterLocation.Header,
        //                 },
        //                 new List<string>()
        //             }
        //         });
        //     }
        // );

        builder.Services.ConfigureSwagger();
        
        builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }) //definir a descriptografia
            .AddJwtBearer(options =>
            {
                //tbm precisa da sequencia de bytes
                var key = Encoding.UTF8.GetBytes(Settings.Secret);

                options.RequireHttpsMetadata = false; //não precisa ser HTTPs
                options.SaveToken = true;

                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    // ValidateIssuer = true,
                    // ValidateAudience = true,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });

        //DI
        builder.Services.AddDbContext<DataContext>(opt =>
            opt.UseSqlite("Data Source=Data/dev.db"));
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IAuthRepository, AuthRepository>();
        builder.Services.AddSingleton<IEmailService, EmailService>();
    }
}