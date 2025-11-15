using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

[Table("hr_contract")]
//[Index("DateStart", Name = "hr_contract__date_start_index")]
//[Index("EmployeeId", Name = "hr_contract__employee_id_index")]
//[Index("ResourceCalendarId", Name = "hr_contract__resource_calendar_id_index")]
//[Index("SchedulePay", Name = "hr_contract__schedule_pay_index")]
public partial class HrContract : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

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

    [Column("struct_id")]
    public Guid? StructId { get; set; }

    [Column("type_id")]
    public Guid? TypeId { get; set; }

    [Column("schedule_pay")]
    public string? SchedulePay { get; set; }

    [Column("hra")]
    public decimal? Hra { get; set; }

    [Column("travel_allowance")]
    public decimal? TravelAllowance { get; set; }

    [Column("da")]
    public decimal? Da { get; set; }

    [Column("meal_allowance")]
    public decimal? MealAllowance { get; set; }

    [Column("medical_allowance")]
    public decimal? MedicalAllowance { get; set; }

    [Column("other_allowance")]
    public decimal? OtherAllowance { get; set; }

    [Column("analytic_account_id")]
    public Guid? AnalyticAccountId { get; set; }

    [Column("journal_id")]
    public Guid? JournalId { get; set; }

    [Column("work_entry_source")]
    public string? WorkEntrySource { get; set; }

    [Column("last_generation_date")]
    public DateTime? LastGenerationDate { get; set; }

    [Column("date_generated_from", TypeName = "timestamp without time zone")]
    public DateTime? DateGeneratedFrom { get; set; }

    [Column("date_generated_to", TypeName = "timestamp without time zone")]
    public DateTime? DateGeneratedTo { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AnalyticAccountId")]
    public virtual AccountAnalyticAccount? AnalyticAccount { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ContractTypeId")]
    public virtual HrContractType? ContractType { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("DepartmentId")]
    public virtual HrDepartment? Department { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("EmployeeId")]
    public virtual HrEmployee? Employee { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ContractId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Contract")] // One2many
    public virtual ICollection<HrEmployee> HrEmployee { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ContractId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Contract")] // One2many
    public virtual ICollection<HrPayslip> HrPayslip { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ContractId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Contract")] // One2many
    public virtual ICollection<HrPayslipInput> HrPayslipInput { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ContractId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Contract")] // One2many
    public virtual ICollection<HrPayslipLine> HrPayslipLine { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ContractId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Contract")] // One2many
    public virtual ICollection<HrPayslipWorkedDays> HrPayslipWorkedDays { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("HrResponsibleId")]
    public virtual ResUsers? HrResponsible { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ContractId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Contract")] // One2many
    public virtual ICollection<HrWorkEntry> HrWorkEntry { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("JobId")]
    public virtual HrJob? Job { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("JournalId")]
    public virtual AccountJournal? Journal { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ResourceCalendarId")]
    public virtual ResourceCalendar? ResourceCalendar { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("StructId")]
    public virtual HrPayrollStructure? Struct { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("StructureTypeId")]
    public virtual HrPayrollStructureType? StructureType { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TypeId")]
    public virtual HrContractType? Type { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
