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

[Table("TenantMember")]
public class TenantMember : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    [Key]
    [Column("id")]
    //public Guid Id { get => base.Id; set => base.Id = value; }
    public override Guid Id { get; protected set; }

    [Column("tenant_id")]
    public Guid? TenantId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("tenant_name")]
    public string? TenantName { get; set; }

    [Column("is_active")]
    public bool? IsActive { get; set; }

    [Column("role")]
    public string? Role { get; set; }

    // Trạng thái thành viên (Active, Pending Invite, Suspended)
    [Column("status")]
    public virtual TenantMemberStatus Status { get; set; } = TenantMemberStatus.Active;

    // Trạng thái của quy trình mời
    [Column("invite_status")]
    public InvitationStatus InviteStatus { get; protected set; } = InvitationStatus.Pending;

    [Column("invited_at")]
    public DateTimeOffset? InvitedAt { get; set; }

    [Column("accepted_at")]
    public DateTimeOffset? AcceptedAt { get; set; }

    [Column("rejected_at")]
    public DateTimeOffset? RejectedAt { get; set; }

    [Column("leaved_at")]
    public DateTimeOffset? LeavedAt { get; set; }

    [Column("suspended_at")]
    public DateTimeOffset? SuspendedAt { get; set; }

    // Cờ đánh dấu chủ sở hữu (nếu cần logic đặc biệt cho owner)
    [Column("is_owner")]
    public virtual bool IsOwner { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("info", TypeName = "jsonb")]
    public virtual JsonElement? Info { get; set; }

    /// <summary>
    /// Navigation property for the roles this user belongs to.
    /// </summary>
    public virtual ICollection<TenantMemberRole> Roles { get; protected set; } = [];

    protected TenantMember()
    {

    }

    public TenantMember(Guid id, Guid tenantId, Guid userId, TenantMemberStatus status = TenantMemberStatus.Active,
            bool isOwner = false) : base(id)
    {
        TenantId = tenantId;
        UserId = userId;
        Roles = new List<TenantMemberRole>();
        Status = status;
        // Khi tạo trực tiếp, coi như lời mời đã được chấp nhận
        InviteStatus = InvitationStatus.Accepted;
        IsOwner = isOwner;
    }

    public TenantMember(Guid id, Guid tenantId, Guid userId, List<string> roles, TenantMemberStatus status = TenantMemberStatus.Active,
        bool isOwner = false) : base(id)
    {
        TenantId = tenantId;
        UserId = userId;
        Roles = new List<TenantMemberRole>();
        Status = status;
        // Khi tạo trực tiếp, coi như lời mời đã được chấp nhận
        InviteStatus = InvitationStatus.Accepted;
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

    public void AcceptInvitation()
    {
        if (InviteStatus != InvitationStatus.Pending)
        {
            // Hoặc throw exception
            return;
        }
        InviteStatus = InvitationStatus.Accepted; // Trạng thái lời mời
        Status = TenantMemberStatus.Active; // Kích hoạt thành viên
        AcceptedAt = DateTimeOffset.UtcNow;
    }

    public void RejectInvitation()
    {
        InviteStatus = InvitationStatus.Rejected;
        Status = TenantMemberStatus.Rejected;
        RejectedAt = DateTimeOffset.UtcNow;
    }

    public void UpdateInfo(bool isActive, TenantMemberStatus status, string description)
    {
        IsActive = isActive;
        Status = status;
        Description = description;
    }

    public bool IsInRole(Guid roleId)
    {
        return Roles.Any(r => r.RoleId == roleId);
    }
}