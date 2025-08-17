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

[Table("hr_contract")]
//[Index("DateStart", Name = "hr_contract_date_start_index")]
//[Index("ResourceCalendarId", Name = "hr_contract_resource_calendar_id_index")]
public partial class HrContract: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("structure_type_id")]
    public Guid? StructureTypeId { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    [Column("department_id")]
    public Guid? DepartmentId { get; set; }

    [Column("job_id")]
    public Guid? JobId { get; set; }

    [Column("resource_calendar_id")]
    public Guid? ResourceCalendarId { get; set; }

    [Column("contract_type_id")]
    public Guid? ContractTypeId { get; set; }

    [Column("hr_responsible_id")]
    public Guid? HrResponsibleId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("kanban_state")]
    public string? KanbanState { get; set; }

    [Column("date_start")]
    public DateTime? DateStart { get; set; }

    [Column("date_end")]
    public DateTime? DateEnd { get; set; }

    [Column("trial_date_end")]
    public DateTime? TrialDateEnd { get; set; }

    [Column("notes")]
    public string? Notes { get; set; }

    [Column("wage")]
    public decimal? Wage { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("work_entry_source")]
    public string? WorkEntrySource { get; set; }

    [Column("last_generation_date")]
    public DateTime? LastGenerationDate { get; set; }

    [Column("date_generated_from", TypeName = "timestamp without time zone")]
    public DateTime? DateGeneratedFrom { get; set; }

    [Column("date_generated_to", TypeName = "timestamp without time zone")]
    public DateTime? DateGeneratedTo { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("HrContract")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("ContractTypeId")]
    // [InverseProperty("HrContract")] //Many2one
    public virtual HrContractType? ContractType { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("HrContractCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("DepartmentId")]
    // [InverseProperty("HrContract")] //Many2one
    public virtual HrDepartment? Department { get; set; }

    // [Many2one]
    [ForeignKey("EmployeeId")]
    // [InverseProperty("HrContract")] //Many2one
    public virtual HrEmployee? Employee { get; set; }

    // [One2many]
    [ForeignKey("ContractId")]
    [InverseProperty("Contract")]
    public virtual ICollection<HrEmployee> HrEmployee { get; set; }

    // [Many2one]
    [ForeignKey("HrResponsibleId")]
    // [InverseProperty("HrContractHrResponsible")] //Many2one
    public virtual ResUsers? HrResponsible { get; set; }

    // [One2many]
    [ForeignKey("ContractId")]
    [InverseProperty("Contract")]
    public virtual ICollection<HrWorkEntry> HrWorkEntry { get; set; }

    // [Many2one]
    [ForeignKey("JobId")]
    // [InverseProperty("HrContract")] //Many2one
    public virtual HrJob? Job { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("HrContract")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("ResourceCalendarId")]
    // [InverseProperty("HrContract")] //Many2one
    public virtual ResourceCalendar? ResourceCalendar { get; set; }

    // [Many2one]
    [ForeignKey("StructureTypeId")]
    // [InverseProperty("HrContract")] //Many2one
    public virtual HrPayrollStructureType? StructureType { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("HrContractWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
