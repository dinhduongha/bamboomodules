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

[Table("hr_salary_rule")]
//[Index("AmountSelect", Name = "hr_salary_rule__amount_select_index")]
//[Index("ParentRuleId", Name = "hr_salary_rule__parent_rule_id_index")]
//[Index("Sequence", Name = "hr_salary_rule__sequence_index")]
public partial class HrSalaryRule: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("category_id")]
    public Guid? CategoryId { get; set; }

    [Column("parent_rule_id")]
    public Guid? ParentRuleId { get; set; }

    [Column("register_id")]
    public Guid? RegisterId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [Column("quantity")]
    public string? Quantity { get; set; }

    [Column("condition_select")]
    public string? ConditionSelect { get; set; }

    [Column("condition_range")]
    public string? ConditionRange { get; set; }

    [Column("amount_select")]
    public string? AmountSelect { get; set; }

    [Column("amount_percentage_base")]
    public string? AmountPercentageBase { get; set; }

    [JsonField(IsSparse = false)] // Name
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [Column("condition_python")]
    public string? ConditionPython { get; set; }

    [Column("amount_python_compute")]
    public string? AmountPythonCompute { get; set; }

    [Column("note")]
    public string? Note { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("appears_on_payslip")]
    public bool? AppearsOnPayslip { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("condition_range_min")]
    public double? ConditionRangeMin { get; set; }

    [Column("condition_range_max")]
    public double? ConditionRangeMax { get; set; }

    [Column("amount_fix")]
    public double? AmountFix { get; set; }

    [Column("amount_percentage")]
    public double? AmountPercentage { get; set; }

    [Column("analytic_account_id")]
    public Guid? AnalyticAccountId { get; set; }

    [Column("account_tax_id")]
    public Guid? AccountTaxId { get; set; }

    [Column("account_debit")]
    public Guid? AccountDebit { get; set; }

    [Column("account_credit")]
    public Guid? AccountCredit { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AccountCredit")]
    public virtual AccountAccount? AccountCreditNavigation { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AccountDebit")]
    public virtual AccountAccount? AccountDebitNavigation { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AccountTaxId")]
    public virtual AccountTax? AccountTax { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AnalyticAccountId")]
    public virtual AccountAnalyticAccount? AnalyticAccount { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CategoryId")]
    public virtual HrSalaryRuleCategory? Category { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ParentRuleId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ParentRule")] // One2many
    public virtual ICollection<HrPayslipLine> HrPayslipLineParentRule { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SalaryRuleId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SalaryRule")] // One2many
    public virtual ICollection<HrPayslipLine> HrPayslipLineSalaryRule { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("InputId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Input")] // One2many
    public virtual ICollection<HrRuleInput> HrRuleInput { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ParentRuleId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ParentRule")] // One2many
    public virtual ICollection<HrSalaryRule> InverseParentRule { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ParentRuleId")]
    public virtual HrSalaryRule? ParentRule { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("RegisterId")]
    public virtual HrContributionRegister? Register { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("RuleId")] //Many2many // Hidden
    // [InverseProperty("Rule")] //Many2many // Hidden
    public virtual ICollection<HrPayrollStructure> Struct { get; set; }
}
