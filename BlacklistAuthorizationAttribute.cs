// BlacklistAuthorizationAttribute.cs
using CarRental3._0.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

public class BlacklistAuthorizationAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
{
    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        var userManager = context.HttpContext.RequestServices.GetService<UserManager<AppUser>>();
        var user = await userManager.GetUserAsync(context.HttpContext.User);

        if (user != null && user.IsBlacklisted)
        {
            context.Result = new ForbidResult();
        }
    }
}
