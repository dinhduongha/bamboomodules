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

[Table("hr_payslip_line")]
//[Index("AmountSelect", Name = "hr_payslip_line__amount_select_index")]
//[Index("ContractId", Name = "hr_payslip_line__contract_id_index")]
//[Index("ParentRuleId", Name = "hr_payslip_line__parent_rule_id_index")]
//[Index("Sequence", Name = "hr_payslip_line__sequence_index")]
public partial class HrPayslipLine: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("slip_id")]
    public Guid? SlipId { get; set; }

    [Column("salary_rule_id")]
    public Guid? SalaryRuleId { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    [Column("contract_id")]
    public Guid? ContractId { get; set; }

    [Column("code")]
    public string? Code { get; set; }

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
    public string? Name { get; set; }

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

    [Column("quantity")]
    public double? Quantity { get; set; }

    [Column("condition_range_min")]
    public double? ConditionRangeMin { get; set; }

    [Column("condition_range_max")]
    public double? ConditionRangeMax { get; set; }

    [Column("amount_fix")]
    public double? AmountFix { get; set; }

    [Column("amount_percentage")]
    public double? AmountPercentage { get; set; }

    [Column("rate")]
    public double? Rate { get; set; }

    [Column("amount")]
    public double? Amount { get; set; }

    [Column("analytic_account_id")]
    public Guid? AnalyticAccountId { get; set; }

    [Column("account_tax_id")]
    public Guid? AccountTaxId { get; set; }

    [Column("account_debit")]
    public Guid? AccountDebit { get; set; }

    [Column("account_credit")]
    public Guid? AccountCredit { get; set; }

    // [Many2one]
    [ForeignKey("AccountCredit")]
    // [InverseProperty("HrPayslipLineAccountCreditNavigation")] //Many2one
    public virtual AccountAccount? AccountCreditNavigation { get; set; }

    // [Many2one]
    [ForeignKey("AccountDebit")]
    // [InverseProperty("HrPayslipLineAccountDebitNavigation")] //Many2one
    public virtual AccountAccount? AccountDebitNavigation { get; set; }

    // [Many2one]
    [ForeignKey("AccountTaxId")]
    // [InverseProperty("HrPayslipLine")] //Many2one
    public virtual AccountTax? AccountTax { get; set; }

    // [Many2one]
    [ForeignKey("AnalyticAccountId")]
    // [InverseProperty("HrPayslipLine")] //Many2one
    public virtual AccountAnalyticAccount? AnalyticAccount { get; set; }

    // [Many2one]
    [ForeignKey("CategoryId")]
    // [InverseProperty("HrPayslipLine")] //Many2one
    public virtual HrSalaryRuleCategory? Category { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("HrPayslipLine")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("ContractId")]
    // [InverseProperty("HrPayslipLine")] //Many2one
    public virtual HrContract? Contract { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("HrPayslipLineCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("EmployeeId")]
    // [InverseProperty("HrPayslipLine")] //Many2one
    public virtual HrEmployee? Employee { get; set; }

    // [Many2one]
    [ForeignKey("ParentRuleId")]
    // [InverseProperty("HrPayslipLineParentRule")] //Many2one
    public virtual HrSalaryRule? ParentRule { get; set; }

    // [Many2one]
    [ForeignKey("RegisterId")]
    // [InverseProperty("HrPayslipLine")] //Many2one
    public virtual HrContributionRegister? Register { get; set; }

    // [Many2one]
    [ForeignKey("SalaryRuleId")]
    // [InverseProperty("HrPayslipLineSalaryRule")] //Many2one
    public virtual HrSalaryRule? SalaryRule { get; set; }

    // [Many2one]
    [ForeignKey("SlipId")]
    // [InverseProperty("HrPayslipLine")] //Many2one
    public virtual HrPayslip? Slip { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("HrPayslipLineWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
