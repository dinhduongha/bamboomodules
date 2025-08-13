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

[Table("hr_payslip_worked_days")]
//[Index("PayslipId", Name = "hr_payslip_worked_days__payslip_id_index")]
//[Index("Sequence", Name = "hr_payslip_worked_days__sequence_index")]
public partial class HrPayslipWorkedDay: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("payslip_id")]
    public Guid? PayslipId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("contract_id")]
    public Guid? ContractId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("number_of_days")]
    public double? NumberOfDays { get; set; }

    [Column("number_of_hours")]
    public double? NumberOfHours { get; set; }

    [ForeignKey("ContractId")]
    //[InverseProperty("HrPayslipWorkedDays")] //Many2One
    public virtual HrContract? Contract { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("HrPayslipWorkedDayCreateUs")] //Many2One
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("PayslipId")]
    //[InverseProperty("HrPayslipWorkedDays")] //Many2One
    public virtual HrPayslip? Payslip { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrPayslipWorkedDayWriteUs")] //Many2One
    public virtual ResUser? WriteU { get; set; }
}
