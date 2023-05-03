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

[Table("pos_payment_method")]
public partial class PosPaymentMethod: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("outstanding_account_id")]
    public Guid? OutstandingAccountId { get; set; }

    [Column("receivable_account_id")]
    public Guid? ReceivableAccountId { get; set; }

    [Column("journal_id")]
    public Guid? JournalId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("use_payment_terminal")]
    public string? UsePaymentTerminal { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("is_cash_count")]
    public bool? IsCashCount { get; set; }

    [Column("split_transactions")]
    public bool? SplitTransactions { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("PosPaymentMethods")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("PosPaymentMethodCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("JournalId")]
    //[InverseProperty("PosPaymentMethods")]
    [NotMapped]
    public virtual AccountJournal? Journal { get; set; }

    [ForeignKey("OutstandingAccountId")]
    //[InverseProperty("PosPaymentMethodOutstandingAccounts")]
    [NotMapped]
    public virtual AccountAccount? OutstandingAccount { get; set; }

    [ForeignKey("ReceivableAccountId")]
    //[InverseProperty("PosPaymentMethodReceivableAccounts")]
    [NotMapped]
    public virtual AccountAccount? ReceivableAccount { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("PosPaymentMethodWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("PosPaymentMethod")]
    [NotMapped]
    public virtual ICollection<AccountPayment> AccountPayments { get; } = new List<AccountPayment>();

    //[InverseProperty("PaymentMethod")]
    [NotMapped]
    public virtual ICollection<PosMakePayment> PosMakePayments { get; } = new List<PosMakePayment>();

    //[InverseProperty("PaymentMethod")]
    [NotMapped]
    public virtual ICollection<PosPayment> PosPayments { get; } = new List<PosPayment>();

    [ForeignKey("PosPaymentMethodId")]
    //[InverseProperty("PosPaymentMethods")]
    [NotMapped]
    public virtual ICollection<PosConfig> PosConfigs { get; } = new List<PosConfig>();
}
