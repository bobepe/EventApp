using EventApp.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace EventApp.Endpoints
{
    public static class AuthEndpointsExtensions
    {
        public static IEndpointRouteBuilder MapAuthEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/account/login", async (HttpContext http, AuthService authService) =>
            {
                var form = await http.Request.ReadFormAsync();

                var username = form["Username"].ToString();
                var password = form["Password"].ToString();
                var returnUrl = form["ReturnUrl"].ToString();

                var principal = await authService.AuthenticateAsync(username, password);

                if (principal == null)
                    return Results.Redirect("/login");

                await http.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    principal);

                if (string.IsNullOrWhiteSpace(returnUrl) || !Uri.IsWellFormedUriString(returnUrl, UriKind.Relative))
                {
                    returnUrl = "/";
                }

                return Results.Redirect(returnUrl);
            });

            app.MapPost("/account/logout", async (HttpContext http) =>
            {
                await http.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return Results.Redirect("/login");
            });

            return app;
        }
    }
}