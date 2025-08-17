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

[Table("hr_payslip_input")]
//[Index("PayslipId", Name = "hr_payslip_input__payslip_id_index")]
//[Index("Sequence", Name = "hr_payslip_input__sequence_index")]
public partial class HrPayslipInput: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("payslip_id")]
    public Guid? PayslipId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("contract_id")]
    public Guid? ContractId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("amount")]
    public double? Amount { get; set; }

    // [Many2one]
    [ForeignKey("ContractId")]
    // [InverseProperty("HrPayslipInput")] //Many2one
    public virtual HrContract? Contract { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("HrPayslipInputCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("PayslipId")]
    // [InverseProperty("HrPayslipInput")] //Many2one
    public virtual HrPayslip? Payslip { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("HrPayslipInputWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
