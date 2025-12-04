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

    [Column("roles", TypeName = "jsonb")]
    public List<string>? Roles { get; set; } = [];

    // Trạng thái thành viên (Active, Pending Invite, Suspended)
    [Column("status")]
    public virtual TenantMemberStatus Status { get; set; }

    [Column("is_active")]
    public bool? IsActive { get; set; } = true;

    [Column("is_accepted")]
    public bool? IsAccepted { get; set; } = false;

    [Column("is_rejected")]
    public bool? IsRejected { get; set; } = false;

    [Column("is_leaved")]
    public bool? IsLeaved { get; set; } = false;

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

    [Column("info", TypeName = "jsonb")]
    public virtual JsonElement? Info { get; set; }

    protected TenantMember()
    {

    }

    public TenantMember(Guid id, Guid tenantId, Guid userId, TenantMemberStatus status = TenantMemberStatus.Active,
            bool isOwner = false) : base(id)
    {
        TenantId = tenantId;
        UserId = userId;
        Roles = [];
        Status = status;
        IsOwner = isOwner;
    }

    public void AddRole(string role)
    {
        if (!Roles!.Contains(role)) Roles.Add(role);
    }
}

public enum TenantMemberStatus
{
    Active = 1,     // Đang hoạt động
    Invited = 2,    // Đã gửi email mời, chưa click link
    Suspended = 3   // Bị chặn khỏi Tenant này (nhưng user gốc vẫn sống)
}