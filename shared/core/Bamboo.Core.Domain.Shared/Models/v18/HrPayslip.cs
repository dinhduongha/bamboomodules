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
public partial class HrPayslip: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("struct_id")]
    public Guid? StructId { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }


    [Column("contract_id")]
    public Guid? ContractId { get; set; }

    [Column("payslip_run_id")]
    public Guid? PayslipRunId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("journal_id")]
    public Guid? JournalId { get; set; }

    [Column("move_id")]
    public Guid? MoveId { get; set; }

    [Column("date")]
    public DateTime? Date { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("HrPayslips")] //Many2One
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("ContractId")]
    //[InverseProperty("HrPayslips")] //Many2One
    public virtual HrContract? Contract { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("HrPayslipCreateUs")] //Many2One
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("EmployeeId")]
    //[InverseProperty("HrPayslips")] //Many2One
    public virtual HrEmployee? Employee { get; set; }

    [NotMapped]//Many2many
    //[InverseProperty("Payslip") //Many2many
    public virtual ICollection<HrPayslipInput> HrPayslipInputs { get; set; } = null;

    [NotMapped]//Many2many
    //[InverseProperty("Slip") //Many2many
    public virtual ICollection<HrPayslipLine> HrPayslipLines { get; set; } = null;

    [NotMapped]//Many2many
    //[InverseProperty("Payslip") //Many2many
    public virtual ICollection<HrPayslipWorkedDay> HrPayslipWorkedDays { get; set; } = null;

    [ForeignKey("JournalId")]
    //[InverseProperty("HrPayslips")] //Many2One
    public virtual AccountJournal? Journal { get; set; }

    [ForeignKey("MoveId")]
    //[InverseProperty("HrPayslips")] //Many2One
    public virtual AccountMove? Move { get; set; }

    [ForeignKey("PayslipRunId")]
    //[InverseProperty("HrPayslips")] //Many2One
    public virtual HrPayslipRun? PayslipRun { get; set; }

    [ForeignKey("StructId")]
    //[InverseProperty("HrPayslips")] //Many2One
    public virtual HrPayrollStructure? Struct { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrPayslipWriteUs")] //Many2One
    public virtual ResUser? WriteU { get; set; }
}
