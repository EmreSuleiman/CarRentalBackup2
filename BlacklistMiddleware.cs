using CarRental3._0.Models;
using Microsoft.AspNetCore.Identity;

public class BlacklistMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<BlacklistMiddleware> _logger;
    private static readonly List<string> _allowedPaths = new List<string>
    {
        "/Account/Logout",
        "/Account/Blacklisted",
        "/Account/AccessDenied",
        "/Error",
        "/favicon.ico",
        "/lib/",
        "/css/",
        "/js/",
        "/_framework/",
        "/Identity/"
    };

    public BlacklistMiddleware(RequestDelegate next, ILogger<BlacklistMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, UserManager<AppUser> userManager)
    {
        var path = context.Request.Path.Value ?? string.Empty;

        // Skip middleware for allowed paths
        if (_allowedPaths.Any(p => path.StartsWith(p, StringComparison.OrdinalIgnoreCase)))
        {
            await _next(context);
            return;
        }

        // Only check authenticated users
        if (context.User.Identity?.IsAuthenticated == true)
        {
            var user = await userManager.GetUserAsync(context.User);

            if (user?.IsBlacklisted == true && !path.Equals("/Account/Blacklisted", StringComparison.OrdinalIgnoreCase))
            {
                _logger.LogWarning($"Потребителят {user.Email} от Ченият списък се опита да достъпи {path}");
                context.Response.Redirect("/Account/Blacklisted");
                return;
            }
        }

        await _next(context);
    }
}