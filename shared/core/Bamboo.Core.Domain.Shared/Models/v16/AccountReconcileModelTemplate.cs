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
public partial class AccountReconcileModelTemplate: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("chart_template_id")]
    public Guid? ChartTemplateId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

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
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("match_amount_min")]
    public double? MatchAmountMin { get; set; }

    [Column("match_amount_max")]
    public double? MatchAmountMax { get; set; }

    [Column("payment_tolerance_param")]
    public double? PaymentToleranceParam { get; set; }

    // [One2many]
    [ForeignKey("ModelId")]
    [InverseProperty("Model")]
    public virtual ICollection<AccountReconcileModelLineTemplate> AccountReconcileModelLineTemplate { get; set; }

    // [Many2one]
    [ForeignKey("ChartTemplateId")]
    // [InverseProperty("AccountReconcileModelTemplate")] //Many2one
    public virtual AccountChartTemplate? ChartTemplate { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("AccountReconcileModelTemplateCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("AccountReconcileModelTemplateWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("AccountReconcileModelTemplateId")] //Many2many
    // [InverseProperty("AccountReconcileModelTemplate")] //Many2many
    public virtual ICollection<AccountJournal> AccountJournal { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("AccountReconcileModelTemplateId")] //Many2many
    // [InverseProperty("AccountReconcileModelTemplate")] //Many2many
    public virtual ICollection<ResPartner> ResPartner { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("AccountReconcileModelTemplateId")] //Many2many
    // [InverseProperty("AccountReconcileModelTemplate")] //Many2many
    public virtual ICollection<ResPartnerCategory> ResPartnerCategory { get; set; }
}
