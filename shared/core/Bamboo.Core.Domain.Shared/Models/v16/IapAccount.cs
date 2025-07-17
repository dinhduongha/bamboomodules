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
public partial class IapAccount: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("service_id")]
    public Guid? ServiceId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    // v16-Compat
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
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("warning_threshold")]
    public double? WarningThreshold { get; set; }

    [Column("sender_name")]
    public string? SenderName { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("IapAccountCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ServiceId")]
    //[InverseProperty("IapAccounts")]
    [NotMapped]
    public virtual IapService? Service { get; set; }

    //[InverseProperty("Account")]
    [NotMapped]
    public virtual ICollection<SmsAccountCode> SmsAccountCodes { get; set; } = new List<SmsAccountCode>();

    //[InverseProperty("Account")]
    [NotMapped]
    public virtual ICollection<SmsAccountPhone> SmsAccountPhones { get; set; } = new List<SmsAccountPhone>();

    //[InverseProperty("Account")]
    [NotMapped]
    public virtual ICollection<SmsAccountSender> SmsAccountSenders { get; set; } = new List<SmsAccountSender>();

    [ForeignKey("LastModifierId")]
    //[InverseProperty("IapAccountWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("IapAccountId")]
    //[InverseProperty("IapAccounts")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanies { get; set; } = new List<ResCompany>();
}
