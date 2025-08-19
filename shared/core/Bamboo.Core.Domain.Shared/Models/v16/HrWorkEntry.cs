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

[Table("hr_work_entry")]
//[Index("EmployeeId", Name = "hr_work_entry__employee_id_index")]
//[Index("WorkEntryTypeId", Name = "hr_work_entry__work_entry_type_id_index")]
//[Index("DateStart", "DateStop", Name = "hr_work_entry_date_start_date_stop_index")]
public partial class HrWorkEntry: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    [Column("work_entry_type_id")]
    public Guid? WorkEntryTypeId { get; set; }

    [Column("department_id")]
    public Guid? DepartmentId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("conflict")]
    public bool? Conflict { get; set; }

    [Column("date_start", TypeName = "timestamp without time zone")]
    public DateTime? DateStart { get; set; }

    [Column("date_stop", TypeName = "timestamp without time zone")]
    public DateTime? DateStop { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("duration")]
    public double? Duration { get; set; }

    [Column("contract_id")]
    public Guid? ContractId { get; set; }

    [Column("leave_id")]
    public Guid? LeaveId { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("HrWorkEntry")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("ContractId")]
    // [InverseProperty("HrWorkEntry")] //Many2one
    public virtual HrContract? Contract { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("HrWorkEntryCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("DepartmentId")]
    // [InverseProperty("HrWorkEntry")] //Many2one
    public virtual HrDepartment? Department { get; set; }

    // [Many2one]
    [ForeignKey("EmployeeId")]
    // [InverseProperty("HrWorkEntry")] //Many2one
    public virtual HrEmployee? Employee { get; set; }

    // [Many2one]
    [ForeignKey("LeaveId")]
    // [InverseProperty("HrWorkEntry")] //Many2one
    public virtual HrLeave? Leave { get; set; }

    // [Many2one]
    [ForeignKey("WorkEntryTypeId")]
    // [InverseProperty("HrWorkEntry")] //Many2one
    public virtual HrWorkEntryType? WorkEntryType { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("HrWorkEntryWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
