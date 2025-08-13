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

[Table("hr_payroll_structure")]
public partial class HrPayrollStructure: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }


    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [Column("note")]
    public string? Note { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("HrPayrollStructures")] //Many2One
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("HrPayrollStructureCreateUs")] //Many2One
    public virtual ResUser? CreateU { get; set; }

    [NotMapped]//Many2many
    //[InverseProperty("Struct") //Many2many
    public virtual ICollection<HrContract> HrContracts { get; set; } = null;

    [NotMapped]//Many2many
    //[InverseProperty("Struct") //Many2many
    public virtual ICollection<HrPayslip> HrPayslips { get; set; } = null;

    [NotMapped]//Many2many
    //[InverseProperty("Parent") //Many2many
    public virtual ICollection<HrPayrollStructure> InverseParent { get; set; } = null;

    [ForeignKey("ParentId")]
    //[InverseProperty("InverseParent")] //Many2One
    public virtual HrPayrollStructure? Parent { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrPayrollStructureWriteUs")] //Many2One
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("StructId")]
    [NotMapped]//One2Many
    //[InverseProperty("Structs")] //One2Many
    public virtual ICollection<HrSalaryRule> Rules { get; set; } = null;
}
