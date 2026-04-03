using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

public class TenantTokenGuardMiddleware
{
    private readonly RequestDelegate _next;
    private readonly Guid? _allowedTenantId;

    public TenantTokenGuardMiddleware(
        RequestDelegate next,
        IConfiguration config)
    {
        _next = next;

        // null = allow host
        _allowedTenantId = config["App:AllowedTenantId"] == null
            ? null
            : Guid.Parse(config["App:AllowedTenantId"]);
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var tenantClaim = context.User.FindFirst("tenantid")?.Value;

        // Host user
        if (tenantClaim == null)
        {
            await _next(context);
            return;
        }

        if (!Guid.TryParse(tenantClaim, out var tokenTenantId))
        {
            context.Response.StatusCode = 403;
            return;
        }

        if (_allowedTenantId != null && tokenTenantId != _allowedTenantId)
        {
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync("Access denied: Invalid tenant for this instance.");
            return;
        }

        await _next(context);
    }
}
