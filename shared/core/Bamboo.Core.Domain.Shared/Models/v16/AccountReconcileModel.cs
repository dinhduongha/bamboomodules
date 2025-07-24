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

[Table("account_reconcile_model")]
//[Index("Name", "TenantId", Name = "account_reconcile_model_name_unique", IsUnique = true)]
public partial class AccountReconcileModel: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("sequence")]
    public long Sequence { get; set; }

    // v16-Compat
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("past_months_limit")]
    public long? PastMonthsLimit { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    // v16-Compat json
    //[Column("name")]
    // TODO: JSON AS KEY
    [JsonField]
    [Column("name", TypeName = "jsonb")]
    //public Dictionary<string, string?>? Name { get; set; }
    public string? Name { get; set; }

    [Column("rule_type")]
    public string? RuleType { get; set; }

    [Column("matching_order")]
    public string? MatchingOrder { get; set; }

    [Column("counterpart_type")]
    public string? CounterpartType { get; set; }

    [Column("match_nature")]
    public string? MatchNature { get; set; }

    [Column("match_amount")]
    public string? MatchAmount { get; set; }

    [Column("match_label")]
    public string? MatchLabel { get; set; }

    [Column("match_label_param")]
    public string? MatchLabelParam { get; set; }

    [Column("match_note")]
    public string? MatchNote { get; set; }

    [Column("match_note_param")]
    public string? MatchNoteParam { get; set; }

    [Column("match_transaction_type")]
    public string? MatchTransactionType { get; set; }

    [Column("match_transaction_type_param")]
    public string? MatchTransactionTypeParam { get; set; }

    [Column("payment_tolerance_type")]
    public string? PaymentToleranceType { get; set; }

    [Column("decimal_separator")]
    public string? DecimalSeparator { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("auto_reconcile")]
    public bool? AutoReconcile { get; set; }

    [Column("to_check")]
    public bool? ToCheck { get; set; }

    [Column("match_text_location_label")]
    public bool? MatchTextLocationLabel { get; set; }

    [Column("match_text_location_note")]
    public bool? MatchTextLocationNote { get; set; }

    [Column("match_text_location_reference")]
    public bool? MatchTextLocationReference { get; set; }

    [Column("match_same_currency")]
    public bool? MatchSameCurrency { get; set; }

    [Column("allow_payment_tolerance")]
    public bool? AllowPaymentTolerance { get; set; }

    [Column("match_partner")]
    public bool? MatchPartner { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("match_amount_min")]
    public double? MatchAmountMin { get; set; }

    [Column("match_amount_max")]
    public double? MatchAmountMax { get; set; }

    [Column("payment_tolerance_param")]
    public double? PaymentToleranceParam { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("AccountReconcileModels")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountReconcileModelCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("AccountReconcileModels")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountReconcileModelWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("ReconcileModel")]
    [NotMapped]
    public virtual ICollection<AccountMoveLine> AccountMoveLines { get; set; } = new List<AccountMoveLine>();

    //[InverseProperty("Model")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModelLine> AccountReconcileModelLines { get; set; } = new List<AccountReconcileModelLine>();

    //[InverseProperty("Model")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModelPartnerMapping> AccountReconcileModelPartnerMappings { get; set; } = new List<AccountReconcileModelPartnerMapping>();

    [ForeignKey("AccountReconcileModelId")]
    //[InverseProperty("AccountReconcileModels")]
    [NotMapped]
    public virtual ICollection<AccountJournal> AccountJournals { get; set; } = new List<AccountJournal>();

    [ForeignKey("AccountReconcileModelId")]
    //[InverseProperty("AccountReconcileModels")]
    [NotMapped]
    public virtual ICollection<ResPartnerCategory> ResPartnerCategories { get; set; } = new List<ResPartnerCategory>();

    [ForeignKey("AccountReconcileModelId")]
    //[InverseProperty("AccountReconcileModels")]
    [NotMapped]
    public virtual ICollection<ResPartner> ResPartners { get; set; } = new List<ResPartner>();
}
