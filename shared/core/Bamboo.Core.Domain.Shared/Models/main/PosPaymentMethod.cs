using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

[Table("pos_payment_method")]
public partial class PosPaymentMethod : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

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

    [JsonField(IsSparse = false)] // Name
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

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
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PosPaymentMethodId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PosPaymentMethod")] // One2many
    public virtual ICollection<AccountPayment> AccountPayment { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("JournalId")]
    public virtual AccountJournal? Journal { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("OutstandingAccountId")]
    public virtual AccountAccount? OutstandingAccount { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SelfOrderOnlinePaymentMethodId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SelfOrderOnlinePaymentMethod")] // One2many
    public virtual ICollection<PosConfig> PosConfig { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PaymentMethodId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PaymentMethod")] // One2many
    public virtual ICollection<PosMakePayment> PosMakePayment { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PaymentMethodId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PaymentMethod")] // One2many
    public virtual ICollection<PosPayment> PosPayment { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ReceivableAccountId")]
    public virtual AccountAccount? ReceivableAccount { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("PosPaymentMethodId")] // Many2many // Normal
    // [InverseProperty("PosPaymentMethod")] // Many2many // Normal
    public virtual ICollection<PaymentProvider> PaymentProvider { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("PosPaymentMethodId")] //Many2many // Hidden
    // [InverseProperty("PosPaymentMethod")] //Many2many // Hidden
    public virtual ICollection<PosConfig> PosConfigNavigation { get; set; }
}
