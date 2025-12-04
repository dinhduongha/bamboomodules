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
[Table("TenantRegistration")]
public class TenantRegistration : FullAuditedAggregateRoot<Guid>
{
    [Key]
    [Column("id")]
    //public Guid Id { get => base.Id; set => base.Id = value; }
    public override Guid Id { get; protected set; }

    [Column("user_id")]
    public virtual Guid? UserId { get; set; }

    // Đây là tenant id sau khi tạo tenant.
    [Column("tenant_id")]
    public virtual Guid? TenantId { get; set; }

    // User cần confirm việc tạo tenant bằng link code này.
    [Column("create_link_id")]
    public virtual Guid? CreateLinkId { get; set; }

    [Column("name")]
    public virtual string? Name { get; set; }

    [Column("email")]
    public virtual string? Email { get; set; }

    [Column("description")]
    public virtual string? Description { get; set; }

    [Column("tax_code")]
    public virtual string? TaxCode { get; set; }

    [Column("dun_code")]
    public virtual string? DunCode { get; set; }

    [Column("address")]
    public virtual string? Address { get; set; }

    [Column("phone")]
    public virtual string? Phone { get; set; }

    [Column("contact")]
    public virtual string? Contact { get; set; }

    [Column("country_code")]
    public virtual string? CountryCode { get; set; }

    [Column("currency_code")]
    public virtual string? CurrencyCode { get; set; }

    [Column("status")]
    public virtual TenantRegistrationStatus Status { get; set; } = TenantRegistrationStatus.Draft;

    [Column("active")]
    public virtual bool? IsActive { get; set; } = true;

    [Column("is_approved")]
    public virtual bool? IsApproved { get; set; } = false;

    [Column("is_created")]
    public virtual bool? IsCreated { get; set; } = false;

    [Column("is_disabled")]
    public virtual bool? IsDisabled { get; set; } = false;

    [Column("registration_at")]
    public virtual DateTimeOffset? RegistrationAt { get; set; }

    [Column("approved_at")]
    public virtual DateTimeOffset? ApprovedAt { get; set; }

    [Column("approved_by")]
    public virtual Guid? ApprovedBy { get; set; }

    [Column("created_at")]
    public virtual DateTimeOffset? CreatedAt { get; set; }

    [Column("rejected_at")]
    public virtual DateTimeOffset? RejectedAt { get; set; }

    [Column("rejected_by")]
    public virtual Guid? RejectedBy { get; set; }

    [Column("rejected_reason")]
    public virtual string? RejectedReason { get; set; }

    [Column("disabled_at")]
    public virtual DateTimeOffset? DisableAt { get; set; }


    [Column("info", TypeName = "jsonb")]
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