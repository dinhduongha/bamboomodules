using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Users;

public static class UserContextExtensions
{
    public static bool IsTenantUser(this ICurrentUser user)
        => user.FindClaim("tenant_user")?.Value == "true";
    // tenant id (built-in)
    public static Guid? GetTenantId(this ICurrentUser user)
        => user.TenantId;

    // tenant name (custom claim)
    public static string? GetTenantName(this ICurrentUser user)
        => user.FindClaim("tenant_name")?.Value;

    public static IReadOnlyList<Guid> GetOrganizationUnitIds(this ICurrentUser user)
    {
        var value = user.FindClaim("ous")?.Value;
        if (string.IsNullOrWhiteSpace(value))
            return Array.Empty<Guid>();

        return value
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(Guid.Parse)
            .ToList();
    }

    public static bool IsInRoleIgnoreCase(this ICurrentUser user, string role)
    => user.Roles?.Any(r =>
        string.Equals(r, role, StringComparison.OrdinalIgnoreCase)
    ) == true;


    public static IReadOnlyList<string> GetRoles(this ICurrentUser user)
        => user.Roles?.ToList() ?? new();
}
