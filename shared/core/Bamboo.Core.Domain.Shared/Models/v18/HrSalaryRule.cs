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

[Table("hr_salary_rule")]
//[Index("AmountSelect", Name = "hr_salary_rule__amount_select_index")]
//[Index("ParentRuleId", Name = "hr_salary_rule__parent_rule_id_index")]
//[Index("Sequence", Name = "hr_salary_rule__sequence_index")]
public partial class HrSalaryRule: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("category_id")]
    public Guid? CategoryId { get; set; }

    [Column("parent_rule_id")]
    public Guid? ParentRuleId { get; set; }


    [Column("register_id")]
    public Guid? RegisterId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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

    [JsonField]
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
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

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

    [ForeignKey("AccountCredit")]
    //[InverseProperty("HrSalaryRuleAccountCreditNavigations")] //Many2One
    public virtual AccountAccount? AccountCreditNavigation { get; set; }

    [ForeignKey("AccountDebit")]
    //[InverseProperty("HrSalaryRuleAccountDebitNavigations")] //Many2One
    public virtual AccountAccount? AccountDebitNavigation { get; set; }

    [ForeignKey("AccountTaxId")]
    //[InverseProperty("HrSalaryRules")] //Many2One
    public virtual AccountTax? AccountTax { get; set; }

    [ForeignKey("AnalyticAccountId")]
    //[InverseProperty("HrSalaryRules")] //Many2One
    public virtual AccountAnalyticAccount? AnalyticAccount { get; set; }

    [ForeignKey("CategoryId")]
    //[InverseProperty("HrSalaryRules")] //Many2One
    public virtual HrSalaryRuleCategory? Category { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("HrSalaryRules")] //Many2One
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("HrSalaryRuleCreateUs")] //Many2One
    public virtual ResUser? CreateU { get; set; }

    [NotMapped]//Many2many
    //[InverseProperty("ParentRule") //Many2many
    public virtual ICollection<HrPayslipLine> HrPayslipLineParentRules { get; set; } = null;

    [NotMapped]//Many2many
    //[InverseProperty("SalaryRule") //Many2many
    public virtual ICollection<HrPayslipLine> HrPayslipLineSalaryRules { get; set; } = null;

    [NotMapped]//Many2many
    //[InverseProperty("Input") //Many2many
    public virtual ICollection<HrRuleInput> HrRuleInputs { get; set; } = null;

    [NotMapped]//Many2many
    //[InverseProperty("ParentRule") //Many2many
    public virtual ICollection<HrSalaryRule> InverseParentRule { get; set; } = null;

    [ForeignKey("ParentRuleId")]
    //[InverseProperty("InverseParentRule")] //Many2One
    public virtual HrSalaryRule? ParentRule { get; set; }

    [ForeignKey("RegisterId")]
    //[InverseProperty("HrSalaryRules")] //Many2One
    public virtual HrContributionRegister? Register { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrSalaryRuleWriteUs")] //Many2One
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("RuleId")]
    [NotMapped]//One2Many
    //[InverseProperty("Rules")] //One2Many
    public virtual ICollection<HrPayrollStructure> Structs { get; set; } = null;
}
