using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Admin;

[Table("tenant_member_organization_units")]
public class TenantMemberOrganizationUnit : AuditedEntity<Guid>, IMultiTenant
{
    public virtual Guid? TenantId { get; set; }

    /// <summary>
    /// Gets or sets the primary key of the tenant member that is linked to a role.
    /// </summary>
    public virtual Guid TenantMemberId { get; set; }

    /// <summary>
    /// Gets or sets the primary key of the role that is linked to the user.
    /// </summary>
    public virtual Guid? OrganizationUnitId { get; set; }

    /// <summary>
    /// Navigation property for the role.
    /// </summary>
    public virtual Volo.Abp.Identity.OrganizationUnit? OrganizationUnit { get; set; }

    protected TenantMemberOrganizationUnit()
    {

    }

    public TenantMemberOrganizationUnit(Guid id, Guid tenantMemberId, Guid ouId, Guid? tenantId = null)
        : base(id)
    {
        TenantMemberId = tenantMemberId;
        TenantId = tenantId;
        OrganizationUnitId = ouId;
    }
}