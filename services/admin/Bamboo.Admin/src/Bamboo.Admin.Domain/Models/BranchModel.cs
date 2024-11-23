using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Admin;

[Table("Branch")]
public class Branch : FullAuditedAggregateRoot<Guid>, IMultiTenant, IHasEntityVersion
{
    public virtual Guid? TenantId { get; protected set; }

    public virtual Guid? ParentId { get; set; }

    public virtual string Name { get; set; }

    public virtual string DisplayName { get; set; }

    public virtual int EntityVersion { get; set; }

    public virtual ICollection<BranchOrganizationUnitRole> Roles { get; protected set; }
        
    public Branch()
    {

    }

    public Branch(Guid id, string displayName, Guid? parentId = null, Guid? tenantId = null)
        : base(id)
    {
        TenantId = tenantId;
        DisplayName = displayName;
        ParentId = parentId;
        Roles = new Collection<BranchOrganizationUnitRole>();
    }

    public virtual void AddRole(Guid roleId)
    {
        Check.NotNull(roleId, nameof(roleId));

        if (IsInRole(roleId))
        {
            return;
        }

        Roles.Add(new BranchOrganizationUnitRole(roleId, Id, TenantId));
    }

    public virtual void RemoveRole(Guid roleId)
    {
        Check.NotNull(roleId, nameof(roleId));

        if (!IsInRole(roleId))
        {
            return;
        }

        Roles.RemoveAll(r => r.RoleId == roleId);
    }

    public virtual bool IsInRole(Guid roleId)
    {
        Check.NotNull(roleId, nameof(roleId));

        return Roles.Any(r => r.RoleId == roleId);
    }

}

[Table("AbpOrganizationUnits")]
public class BranchOrganizationUnit : OrganizationUnit
{
    public Guid? BranchId { get; set; }
}

[Table("AbpOrganizationUnitRoles")]
public class BranchOrganizationUnitRole : OrganizationUnitRole
{
    public BranchOrganizationUnitRole(Guid roleId, Guid organizationUnitId, Guid? tenantId = null) 
        : base(roleId, organizationUnitId, tenantId)
    {
    }

    public Guid? BranchId { get; set; }

    public override object[] GetKeys()
    {
        return new object[] { OrganizationUnitId, RoleId };
    }
}

[Table("AbpUsers")]
public class BranchUser: IdentityUser
{
    public Guid? BranchId { get; set;}
}

[Table("AbpUserOrganizationUnits")]
public class BranchUserOrganizationUnit : IdentityUserOrganizationUnit
{
    public Guid? BranchId { get; set; }
}

[Table("AbpUserClaims")]
public class BranchUserClaim : IdentityUserClaim
{
    public Guid? BranchId { get; set; }
}


