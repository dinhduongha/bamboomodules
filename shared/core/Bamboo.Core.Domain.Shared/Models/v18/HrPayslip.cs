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

[Table("hr_payslip")]
//[Index("State", Name = "hr_payslip__state_index")]
public partial class HrPayslip: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("struct_id")]
    public Guid? StructId { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    [Column("contract_id")]
    public Guid? ContractId { get; set; }

    [Column("payslip_run_id")]
    public Guid? PayslipRunId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("number")]
    public string? Number { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("date_from")]
    public DateTime? DateFrom { get; set; }

    [Column("date_to")]
    public DateTime? DateTo { get; set; }

    [Column("note")]
    public string? Note { get; set; }

    [Column("paid")]
    public bool? Paid { get; set; }

    [Column("credit_note")]
    public bool? CreditNote { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("journal_id")]
    public Guid? JournalId { get; set; }

    [Column("move_id")]
    public Guid? MoveId { get; set; }

    [Column("date")]
    public DateTime? Date { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("ContractId")]
    public virtual HrContract? Contract { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("EmployeeId")]
    public virtual HrEmployee? Employee { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("PayslipId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Payslip")] // One2many
    public virtual ICollection<HrPayslipInput> HrPayslipInput { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("SlipId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Slip")] // One2many
    public virtual ICollection<HrPayslipLine> HrPayslipLine { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("PayslipId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Payslip")] // One2many
    public virtual ICollection<HrPayslipWorkedDays> HrPayslipWorkedDays { get; set; }

    // [Many2one]
    [ForeignKey("JournalId")]
    public virtual AccountJournal? Journal { get; set; }

    // [Many2one]
    [ForeignKey("MoveId")]
    public virtual AccountMove? Move { get; set; }

    // [Many2one]
    [ForeignKey("PayslipRunId")]
    public virtual HrPayslipRun? PayslipRun { get; set; }

    // [Many2one]
    [ForeignKey("StructId")]
    public virtual HrPayrollStructure? Struct { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
