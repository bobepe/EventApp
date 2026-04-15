using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace EventApp.Services
{
    public class UserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string? GetUserName()
        {
            return _httpContextAccessor.HttpContext?.User?.Identity?.Name;
        }

        public int? GetUserId()
        {
            var user = _httpContextAccessor.HttpContext?.User;

            var idClaim = user?.FindFirst(ClaimTypes.NameIdentifier);

            if (idClaim == null)
                return null;

            return int.Parse(idClaim.Value);
        }

        public bool IsAuthenticated()
        {
            return _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
        }
    }
}