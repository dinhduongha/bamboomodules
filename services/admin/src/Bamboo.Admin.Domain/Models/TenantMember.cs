using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;

using Bamboo.Admin.Domain.Shared.Enums;
using Volo.Abp.Guids;
using Volo.Abp;
using System.Linq;

namespace Bamboo.Admin;

[Table("tenant_members")]
public class TenantMember : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    [Key]
    //public Guid Id { get => base.Id; set => base.Id = value; }
    public override Guid Id { get; protected set; }

    public Guid? TenantId { get; set; }

    public Guid? UserId { get; set; }

    public string? TenantName { get; set; }

    public bool? IsActive { get; set; }

    public string? Role { get; set; }

    // Trạng thái thành viên (Active, Pending Invite, Suspended)
    public virtual TenantMemberStatus Status { get; set; } = TenantMemberStatus.Active;

    // Trạng thái của quy trình mời
    public InvitationStatus InviteStatus { get; protected set; } = InvitationStatus.Pending;

    public DateTimeOffset? InvitedAt { get; set; }

    public DateTimeOffset? AcceptedAt { get; set; }

    public DateTimeOffset? RejectedAt { get; set; }

    public DateTimeOffset? LeavedAt { get; set; }

    public DateTimeOffset? SuspendedAt { get; set; }

    // Cờ đánh dấu chủ sở hữu (nếu cần logic đặc biệt cho owner)
    public virtual bool IsOwner { get; set; }

    public string? Description { get; set; }

    [Column(TypeName = "jsonb")]
    public virtual JsonElement? Info { get; set; }

    /// <summary>
    /// Navigation property for the roles this user belongs to.
    /// </summary>
    public virtual ICollection<TenantMemberRole> Roles { get; protected set; } = [];

    /// <summary>
    /// Navigation property for the roles this user belongs to.
    /// </summary>
    public virtual ICollection<TenantMemberOrganizationUnit> OrganizationUnits { get; protected set; } = [];

    protected TenantMember()
    {

    }

    public TenantMember(Guid id, Guid tenantId, Guid userId, TenantMemberStatus status = TenantMemberStatus.Pending,
            InvitationStatus invitationStatus = InvitationStatus.Pending, bool isOwner = false) : base(id)
    {
        TenantId = tenantId;
        UserId = userId;
        Roles = new List<TenantMemberRole>();
        OrganizationUnits = new List<TenantMemberOrganizationUnit>();
        Status = status;
        InviteStatus = invitationStatus;
        IsOwner = isOwner;
    }

    public TenantMember(Guid id, Guid tenantId, Guid userId, List<TenantMemberRole> roles, List<TenantMemberOrganizationUnit>? organizationUnits = null, TenantMemberStatus status = TenantMemberStatus.Active,
        InvitationStatus invitationStatus = InvitationStatus.Pending, bool isOwner = false
   ) : base(id)
    {
        TenantId = tenantId;
        UserId = userId;
        Roles = [.. roles];

        if (organizationUnits != null)
        {
            foreach (var ou in organizationUnits)
            {
                OrganizationUnits.Add(ou);
            }
        }
        Status = status;
        InviteStatus = invitationStatus;
        IsOwner = isOwner;
    }

    public void AddRole(Guid roleId, IGuidGenerator guidGenerator)
    {
        Check.NotNull(guidGenerator, nameof(guidGenerator));

        if (IsInRole(roleId))
        {
            return;
        }
        Roles?.Add(new TenantMemberRole(guidGenerator.Create(), Id, roleId, TenantId));
    }

    public void RemoveRole(Guid roleId)
    {
        var roleToRemove = Roles?.FirstOrDefault(r => r.RoleId == roleId);
        if (roleToRemove != null)
        {
            Roles?.Remove(roleToRemove);
        }
    }

    public void SetRoles(IEnumerable<Guid> roleIds, IGuidGenerator guidGenerator)
    {
        Roles?.Clear();
        foreach (var roleId in roleIds)
        {
            AddRole(roleId, guidGenerator);
        }
    }

    public void AddOrganizationUnit(Guid ouId, IGuidGenerator guidGenerator)
    {
        Check.NotNull(guidGenerator, nameof(guidGenerator));

        if (IsInOrganizationUnit(ouId))
        {
            return;
        }
        OrganizationUnits?.Add(new TenantMemberOrganizationUnit(guidGenerator.Create(), Id, ouId, TenantId));
    }

    public void RemoveOrganizationUnit(Guid ouId)
    {
        var ouIdToRemove = OrganizationUnits?.FirstOrDefault(r => r.OrganizationUnitId == ouId);
        if (ouIdToRemove != null)
        {
            OrganizationUnits?.Remove(ouIdToRemove);
        }
    }

    public void SetOrganizationUnit(IEnumerable<Guid> ouIds, IGuidGenerator guidGenerator)
    {
        OrganizationUnits?.Clear();
        foreach (var ouId in ouIds)
        {
            AddOrganizationUnit(ouId, guidGenerator);
        }
    }

    public bool IsInOrganizationUnit(Guid ouId)
    {
        return OrganizationUnits.Any(r => r.OrganizationUnitId == ouId);
    }
    public bool IsInRole(Guid roleId)
    {
        return Roles.Any(r => r.RoleId == roleId);
    }

    public void AcceptInvitation()
    {
        if (InviteStatus != InvitationStatus.Pending)
        {
            // Hoặc throw exception
            return;
        }
        IsActive = true;
        InviteStatus = InvitationStatus.Accepted; // Trạng thái lời mời
        Status = TenantMemberStatus.Active; // Kích hoạt thành viên
        AcceptedAt = DateTimeOffset.UtcNow;
    }

    public void RejectInvitation()
    {
        InviteStatus = InvitationStatus.Rejected;
        Status = TenantMemberStatus.Pending;
        RejectedAt = DateTimeOffset.UtcNow;
    }

    public void UpdateInfo(bool isActive, TenantMemberStatus? status, InvitationStatus? invitationStatus, string? description)
    {
        IsActive = isActive;
        if (invitationStatus != null)
            InviteStatus = (InvitationStatus)invitationStatus;
        if (status != null)
            Status = (TenantMemberStatus)status;
        Description = description;
    }

}