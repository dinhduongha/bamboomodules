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

[Table("hr_version")]
//[Index("EmployeeId", Name = "hr_version__employee_id_index")]
public partial class HrVersion : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    [Column("last_modified_uid")]
    public Guid? LastModifiedUid { get; set; }

    [Column("country_id")]
    public Guid? CountryId { get; set; }

    [Column("private_state_id")]
    public Guid? PrivateStateId { get; set; }

    [Column("private_country_id")]
    public Guid? PrivateCountryId { get; set; }

    [Column("distance_home_work")]
    public long? DistanceHomeWork { get; set; }

    [Column("km_home_work")]
    public long? KmHomeWork { get; set; }

    [Column("children")]
    public long? Children { get; set; }

    [Column("department_id")]
    public Guid? DepartmentId { get; set; }

    [Column("job_id")]
    public Guid? JobId { get; set; }

    [Column("address_id")]
    public Guid? AddressId { get; set; }

    [Column("work_location_id")]
    public Guid? WorkLocationId { get; set; }

    [Column("departure_reason_id")]
    public Guid? DepartureReasonId { get; set; }

    [Column("resource_calendar_id")]
    public Guid? ResourceCalendarId { get; set; }

    [Column("contract_template_id")]
    public Guid? ContractTemplateId { get; set; }

    [Column("structure_type_id")]
    public Guid? StructureTypeId { get; set; }

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

    [Column("identification_id")]
    public string? IdentificationId { get; set; }

    [Column("ssnid")]
    public string? Ssnid { get; set; }

    [Column("passport_id")]
    public string? PassportId { get; set; }

    [Column("sex")]
    public string? Sex { get; set; }

    [Column("private_street")]
    public string? PrivateStreet { get; set; }

    [Column("private_street2")]
    public string? PrivateStreet2 { get; set; }

    [Column("private_city")]
    public string? PrivateCity { get; set; }

    [Column("private_zip")]
    public string? PrivateZip { get; set; }

    [Column("distance_home_work_unit")]
    public string? DistanceHomeWorkUnit { get; set; }

    [Column("marital")]
    public string? Marital { get; set; }

    [Column("spouse_complete_name")]
    public string? SpouseCompleteName { get; set; }

    [Column("employee_type")]
    public string? EmployeeType { get; set; }

    [Column("job_title")]
    public string? JobTitle { get; set; }

    [Column("date_version")]
    public DateTime? DateVersion { get; set; }

    [Column("passport_expiration_date")]
    public DateTime? PassportExpirationDate { get; set; }

    [Column("spouse_birthdate")]
    public DateTime? SpouseBirthdate { get; set; }

    [Column("departure_date")]
    public DateTime? DepartureDate { get; set; }

    [Column("contract_date_start")]
    public DateTime? ContractDateStart { get; set; }

    [Column("contract_date_end")]
    public DateTime? ContractDateEnd { get; set; }

    [Column("trial_date_end")]
    public DateTime? TrialDateEnd { get; set; }

    [Column("departure_description")]
    public string? DepartureDescription { get; set; }

    [Column("additional_note")]
    public string? AdditionalNote { get; set; }

    [Column("wage")]
    public decimal? Wage { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("is_custom_job_title")]
    public bool? IsCustomJobTitle { get; set; }

    [Column("is_flexible")]
    public bool? IsFlexible { get; set; }

    [Column("is_fully_flexible")]
    public bool? IsFullyFlexible { get; set; }

    [Column("last_modified_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModifiedDate { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("ruleset_id")]
    public Guid? RulesetId { get; set; }

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
    [ForeignKey("AddressId")]
    public virtual ResPartner? Address { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ContractTemplateId")]
    public virtual HrVersion? ContractTemplate { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ContractTypeId")]
    public virtual HrContractType? ContractType { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CountryId")]
    public virtual ResCountry? Country { get; set; }

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
    [ForeignKey("DepartureReasonId")]
    public virtual HrDepartureReason? DepartureReason { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("EmployeeId")]
    public virtual HrEmployee? Employee { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CurrentVersionId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("CurrentVersion")] // One2many
    public virtual ICollection<HrEmployee> HrEmployee { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("HrResponsibleId")]
    public virtual ResUsers? HrResponsible { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ContractTemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ContractTemplate")] // One2many
    public virtual ICollection<HrVersionWizard> HrVersionWizard { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("VersionId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Version")] // One2many
    public virtual ICollection<HrWorkEntry> HrWorkEntry { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ContractTemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ContractTemplate")] // One2many
    public virtual ICollection<HrVersion> InverseContractTemplate { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("JobId")]
    public virtual HrJob? Job { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifiedUid")]
    public virtual ResUsers? LastModifiedU { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PrivateCountryId")]
    public virtual ResCountry? PrivateCountry { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PrivateStateId")]
    public virtual ResCountryState? PrivateState { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ResourceCalendarId")]
    public virtual ResourceCalendar? ResourceCalendar { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("RulesetId")]
    public virtual HrAttendanceOvertimeRuleset? Ruleset { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("StructureTypeId")]
    public virtual HrPayrollStructureType? StructureType { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("WorkLocationId")]
    public virtual HrWorkLocation? WorkLocation { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
