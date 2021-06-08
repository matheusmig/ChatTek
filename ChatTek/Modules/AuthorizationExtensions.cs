using Application.Common;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ChatTek.Modules
{
    public static class AuthorizationExtensions
    {
        public static IServiceCollection AddAuthorizationCustom(this IServiceCollection serviceCollection)
        {
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            serviceCollection.AddAuthorization(x =>
            {
                x.AddPolicy("MarketingOnly", policy => policy.RequireClaim("Department", "Sales"));

                x.AddPolicy("ManagerFromMarketing", policy =>
                    policy.RequireAssertion(context =>
                        context.User.IsInRole("Manager") &&
                        context.User.HasClaim("Department", "Marketing")));
            });

            return serviceCollection;
        }
    }
}
