using Application.Common;
using Infrastructure.Identity;
using Infrastructure.Identity.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ChatTek.Modules
{
    public static class AuthenticationExtensions
    {
        public static IServiceCollection AddAuthenticationCustom(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(option =>
            {
                option.RequireHttpsMetadata = false;
                option.SaveToken = true;
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Settings.Secret)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


            serviceCollection.AddTransient<IUserRepository, InMemoryUserRepository>();
            serviceCollection.AddTransient<IAccessManager, AccessManager>();
            serviceCollection.AddTransient<IIdentityService, IdentityService>();

            return serviceCollection;
        }
    }
}
