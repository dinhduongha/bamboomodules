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

[Table("account_reconcile_model_template")]
public partial class AccountReconcileModelTemplate: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("chart_template_id")]
    public Guid? ChartTemplateId { get; set; }

    [Column("sequence")]
    public long Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("rule_type")]
    public string? RuleType { get; set; }

    [Column("matching_order")]
    public string? MatchingOrder { get; set; }

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
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("match_amount_min")]
    public double? MatchAmountMin { get; set; }

    [Column("match_amount_max")]
    public double? MatchAmountMax { get; set; }

    [Column("payment_tolerance_param")]
    public double? PaymentToleranceParam { get; set; }

    [ForeignKey("ChartTemplateId")]
    //[InverseProperty("AccountReconcileModelTemplates")]
    [NotMapped]
    public virtual AccountChartTemplate? ChartTemplate { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountReconcileModelTemplateCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountReconcileModelTemplateWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Model")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModelLineTemplate> AccountReconcileModelLineTemplates { get; } = new List<AccountReconcileModelLineTemplate>();

    [ForeignKey("AccountReconcileModelTemplateId")]
    //[InverseProperty("AccountReconcileModelTemplates")]
    [NotMapped]
    public virtual ICollection<AccountJournal> AccountJournals { get; } = new List<AccountJournal>();

    [ForeignKey("AccountReconcileModelTemplateId")]
    //[InverseProperty("AccountReconcileModelTemplates")]
    [NotMapped]
    public virtual ICollection<ResPartnerCategory> ResPartnerCategories { get; } = new List<ResPartnerCategory>();

    [ForeignKey("AccountReconcileModelTemplateId")]
    //[InverseProperty("AccountReconcileModelTemplates")]
    [NotMapped]
    public virtual ICollection<ResPartner> ResPartners { get; } = new List<ResPartner>();
}
