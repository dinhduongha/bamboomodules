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
public partial class HrContract: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("structure_type_id")]
    public long? StructureTypeId { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    [Column("department_id")]
    public Guid? DepartmentId { get; set; }

    [Column("job_id")]
    public Guid? JobId { get; set; }

    [Column("resource_calendar_id")]
    public Guid? ResourceCalendarId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("contract_type_id")]
    public long? ContractTypeId { get; set; }

    [Column("hr_responsible_id")]
    public Guid? HrResponsibleId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("HrContracts")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("ContractTypeId")]
    //[InverseProperty("HrContracts")]
    [NotMapped]
    public virtual HrContractType? ContractType { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("HrContractCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("DepartmentId")]
    //[InverseProperty("HrContracts")]
    [NotMapped]
    public virtual HrDepartment? Department { get; set; }

    [ForeignKey("EmployeeId")]
    //[InverseProperty("HrContracts")]
    [NotMapped]
    public virtual HrEmployee? Employee { get; set; }

    [ForeignKey("HrResponsibleId")]
    //[InverseProperty("HrContractHrResponsibles")]
    [NotMapped]
    public virtual ResUser? HrResponsible { get; set; }

    [ForeignKey("JobId")]
    //[InverseProperty("HrContracts")]
    [NotMapped]
    public virtual HrJob? Job { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("HrContracts")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("ResourceCalendarId")]
    //[InverseProperty("HrContracts")]
    [NotMapped]
    public virtual ResourceCalendar? ResourceCalendar { get; set; }

    [ForeignKey("StructureTypeId")]
    //[InverseProperty("HrContracts")]
    [NotMapped]
    public virtual HrPayrollStructureType? StructureType { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrContractWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Contract")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployees { get; } = new List<HrEmployee>();


}
