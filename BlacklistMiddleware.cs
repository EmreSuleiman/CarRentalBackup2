using CarRental3._0.Models;
using Microsoft.AspNetCore.Identity;

public class BlacklistMiddleware
{
    private readonly RequestDelegate _next;

    public BlacklistMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, UserManager<AppUser> userManager)
    {
        if (context.User.Identity.IsAuthenticated)
        {
            var user = await userManager.GetUserAsync(context.User);
            if (user != null && user.IsBlacklisted)
            {
                // Don't allow access to any page except the logout page
                if (!context.Request.Path.StartsWithSegments("/Account/Logout"))
                {
                    context.Response.Redirect("/Account/Blacklisted");
                    return;
                }
            }
        }

        await _next(context);
    }
}