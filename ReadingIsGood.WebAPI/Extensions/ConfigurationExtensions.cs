using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ReadingIsGood.Core.Utilities.Security.Encyption;
using ReadingIsGood.Core.Utilities.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadingIsGood.WebAPI.Extensions
{
    public static class ConfigurationExtensions
    {
        public static void AddJwtAuthentication(this IServiceCollection service, TokenOptions tokenOptions)
        {
            service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });
        }

        public static void AddFileLogger(this IServiceCollection service,IConfiguration configuration)
        {
            service.AddLogging(builder => builder.AddFile(options =>
            {
                options.FileName = configuration["Logging:Options:FilePrefix"];
                options.LogDirectory = configuration["Logging:Options:LogDirectory"];
                options.FileSizeLimit = int.Parse(configuration["Logging:Options:FileSizeLimit"]);
            }));
        }

    }
}
