using Application.Common;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        public IdentityService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Guid GetCurrentUserId()
        {
            ClaimsPrincipal user = this._httpContextAccessor
                 .HttpContext
                 .User;

             string id = user.FindFirst("nameid")?.Value!;
             return new Guid(id);
        }
    }
}
