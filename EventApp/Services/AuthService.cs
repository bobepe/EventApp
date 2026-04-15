using EventApp.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EventApp.Services
{
    public class AuthService
    {
        private readonly EventAppDbContext _db;

        public AuthService(EventAppDbContext db)
        {
            _db = db;
        }

        public async Task<ClaimsPrincipal?> AuthenticateAsync(string username, string password)
        {
            var user = await _db.People
                .FirstOrDefaultAsync(u => u.Name == username && u.Password == password);

            if (user == null)
                return null;

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var identity = new ClaimsIdentity(
                claims,
                "Cookies");

            return new ClaimsPrincipal(identity);
        }
    }
}