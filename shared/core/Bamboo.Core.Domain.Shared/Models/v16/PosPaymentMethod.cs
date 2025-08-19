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
public partial class PosPaymentMethod: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("outstanding_account_id")]
    public Guid? OutstandingAccountId { get; set; }

    [Column("receivable_account_id")]
    public Guid? ReceivableAccountId { get; set; }

    [Column("journal_id")]
    public Guid? JournalId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("use_payment_terminal")]
    public string? UsePaymentTerminal { get; set; }

    [Column("payment_method_type")]
    public string? PaymentMethodType { get; set; }

    [Column("qr_code_method")]
    public string? QrCodeMethod { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("is_cash_count")]
    public bool? IsCashCount { get; set; }

    [Column("split_transactions")]
    public bool? SplitTransactions { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("is_online_payment")]
    public bool? IsOnlinePayment { get; set; }

    // [One2many]
    [ForeignKey("PosPaymentMethodId")]
    [InverseProperty("PosPaymentMethod")]
    public virtual ICollection<AccountPayment> AccountPayment { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("PosPaymentMethod")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("PosPaymentMethodCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("JournalId")]
    // [InverseProperty("PosPaymentMethod")] //Many2one
    public virtual AccountJournal? Journal { get; set; }

    // [Many2one]
    [ForeignKey("OutstandingAccountId")]
    // [InverseProperty("PosPaymentMethodOutstandingAccount")] //Many2one
    public virtual AccountAccount? OutstandingAccount { get; set; }

    // [One2many]
    [ForeignKey("SelfOrderOnlinePaymentMethodId")]
    [InverseProperty("SelfOrderOnlinePaymentMethod")]
    public virtual ICollection<PosConfig> PosConfig { get; set; }

    // [One2many]
    [ForeignKey("PaymentMethodId")]
    [InverseProperty("PaymentMethod")]
    public virtual ICollection<PosMakePayment> PosMakePayment { get; set; }

    // [One2many]
    [ForeignKey("PaymentMethodId")]
    [InverseProperty("PaymentMethod")]
    public virtual ICollection<PosPayment> PosPayment { get; set; }

    // [Many2one]
    [ForeignKey("ReceivableAccountId")]
    // [InverseProperty("PosPaymentMethodReceivableAccount")] //Many2one
    public virtual AccountAccount? ReceivableAccount { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("PosPaymentMethodWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("PosPaymentMethodId")] //Many2many
    // [InverseProperty("PosPaymentMethod")] //Many2many
    public virtual ICollection<PaymentProvider> PaymentProvider { get; set; }

    // [Many2many] // ManyToMany Hidden
    //[NotMapped] //Many2many // Hidden
    // [ForeignKey("PosPaymentMethodId")]
    // [InverseProperty("PosPaymentMethod")]
    //public virtual ICollection<PosConfig> PosConfig { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("PosPaymentMethodId")]
    // [InverseProperty("PosPaymentMethod")]
    public virtual ICollection<PosConfig> PosConfigNavigation { get; set; }
}
