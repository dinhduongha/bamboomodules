using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Admin.HttpApi.Filters
{
    public class HostOnlyAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var currentTenant = context.HttpContext.RequestServices
                .GetRequiredService<ICurrentTenant>();

            // If tenant context exists → reject
            if (currentTenant.IsAvailable)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
