using Application.Common;
using System;

namespace Infrastructure.Identity
{
    public class IdentityService : IIdentityService
    {
        public Guid GetCurrentUserId()
        {
            return new Guid("378522FF-033B-4095-8CFD-AF292834FDD1");
        }
    }
}
