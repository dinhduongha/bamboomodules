using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace Bamboo.Admin;

[Table("TenantMemberRole")]
public class TenantMemberRole : Entity<Guid>
{
    public virtual Guid? TenantId { get; set; }

    /// <summary>
    /// Gets or sets the primary key of the tenant member that is linked to a role.
    /// </summary>
    public virtual Guid TenantMemberId { get; protected set; }

    /// <summary>
    /// Gets or sets the primary key of the role that is linked to the user.
    /// </summary>
    public virtual Guid RoleId { get; protected set; }

    /// <summary>
    /// Navigation property for the role.
    /// </summary>
    public virtual Volo.Abp.Identity.IdentityRole? Role { get; set; }

    protected TenantMemberRole()
    {

    }

    protected internal TenantMemberRole(Guid id, Guid tenantMemberId, Guid roleId, Guid? tenantId)
        : base(id)
    {
        TenantMemberId = tenantMemberId;
        RoleId = roleId;
        TenantId = tenantId;
    }
}