using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

[Table("iap_account")]
public partial class IapAccount: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("service_id")]
    public Guid? ServiceId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("service_name")]
    public string? ServiceName { get; set; }

    [Column("account_token")]
    public string? AccountToken { get; set; }

    [Column("balance")]
    public string? Balance { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("service_locked")]
    public bool? ServiceLocked { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("warning_threshold")]
    public double? WarningThreshold { get; set; }

    [Column("sender_name")]
    public string? SenderName { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("IapAccountCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("ServiceId")]
    // [InverseProperty("IapAccount")] //Many2one
    public virtual IapService? Service { get; set; }

    // [One2many]
    [ForeignKey("AccountId")]
    [InverseProperty("Account")]
    public virtual ICollection<SmsAccountCode> SmsAccountCode { get; set; }

    // [One2many]
    [ForeignKey("AccountId")]
    [InverseProperty("Account")]
    public virtual ICollection<SmsAccountPhone> SmsAccountPhone { get; set; }

    // [One2many]
    [ForeignKey("AccountId")]
    [InverseProperty("Account")]
    public virtual ICollection<SmsAccountSender> SmsAccountSender { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("IapAccountWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("IapAccountId")] //Many2many
    // [InverseProperty("IapAccount")] //Many2many
    public virtual ICollection<ResCompany> ResCompany { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("IapAccountId")] //Many2many
    // [InverseProperty("IapAccount")] //Many2many
    public virtual ICollection<ResUsers> ResUsers { get; set; }
}
