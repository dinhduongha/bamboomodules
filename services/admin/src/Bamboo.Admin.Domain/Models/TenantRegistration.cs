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

/// <summary>
/// Global users có thể đăng ký 1 hoặc nhiều tenants, và chờ sự chấp thuận của host.
/// Host review và tạo link cho user
/// User create tenant với link đã cấp.
/// </summary>
[Table("tenant_registrations")]
public class TenantRegistration : FullAuditedAggregateRoot<Guid>
{
    [Key]
    //public Guid Id { get => base.Id; set => base.Id = value; }
    public override Guid Id { get; protected set; }

    public virtual Guid? UserId { get; set; }

    // Đây là tenant id sau khi tạo tenant.
    public virtual Guid? TenantId { get; set; }

    // User cần confirm việc tạo tenant bằng link code này.
    public virtual Guid? CreateLinkId { get; set; }

    public virtual string? Name { get; set; }

    public virtual string? Email { get; set; }

    public virtual string? Description { get; set; }

    public virtual string? TaxCode { get; set; }

    public virtual string? DunCode { get; set; }

    public virtual string? Address { get; set; }

    public virtual string? Phone { get; set; }

    public virtual string? Contact { get; set; }

    public virtual string? CountryCode { get; set; }

    public virtual string? CurrencyCode { get; set; }

    public virtual TenantRegistrationStatus Status { get; set; } = TenantRegistrationStatus.Draft;

    public virtual bool? IsActive { get; set; } = true;

    public virtual bool? IsApproved { get; set; } = false;

    public virtual bool? IsCreated { get; set; } = false;

    public virtual bool? IsDisabled { get; set; } = false;

    public virtual DateTimeOffset? RegistrationAt { get; set; }

    public virtual DateTimeOffset? ApprovedAt { get; set; }

    public virtual Guid? ApprovedBy { get; set; }

    public virtual DateTimeOffset? CreatedAt { get; set; }

    public virtual DateTimeOffset? RejectedAt { get; set; }

    public virtual Guid? RejectedBy { get; set; }

    public virtual string? RejectedReason { get; set; }

    public virtual DateTimeOffset? DisableAt { get; set; }

    [Column(TypeName = "jsonb")]
    public virtual JsonElement? Info { get; set; }

    protected TenantRegistration()
    {

    }

    public TenantRegistration(Guid id, Guid userId, string name, string email, TenantRegistrationStatus status = TenantRegistrationStatus.Draft) : base(id)
    {
        UserId = userId;
        Name = name;
        Email = email;
        Status = status;
    }
}

public enum TenantRegistrationStatus
{
    Draft = 0,
    Pending = 1,
    Approved = 2,
    Rejected = 3,
    Disabled = 4,
}