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

[Table("hr_attendance_overtime_rule")]
//[Index("RulesetId", Name = "hr_attendance_overtime_rule__ruleset_id_index")]
public partial class HrAttendanceOvertimeRule : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("resource_calendar_id")]
    public Guid? ResourceCalendarId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("ruleset_id")]
    public Guid? RulesetId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("base_off")]
    public string? BaseOff { get; set; }

    [Column("timing_type")]
    public string? TimingType { get; set; }

    [Column("quantity_period")]
    public string? QuantityPeriod { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("expected_hours_from_contract")]
    public bool? ExpectedHoursFromContract { get; set; }

    [Column("paid")]
    public bool? Paid { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("timing_start")]
    public double? TimingStart { get; set; }

    [Column("timing_stop")]
    public double? TimingStop { get; set; }

    [Column("expected_hours")]
    public double? ExpectedHours { get; set; }

    [Column("amount_rate")]
    public double? AmountRate { get; set; }

    [Column("employee_tolerance")]
    public double? EmployeeTolerance { get; set; }

    [Column("employer_tolerance")]
    public double? EmployerTolerance { get; set; }

    [Column("compensable_as_leave")]
    public bool? CompensableAsLeave { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

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
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("HrAttendanceOvertimeRuleId")] //Many2many // Hidden
    // [InverseProperty("HrAttendanceOvertimeRule")] //Many2many // Hidden
    public virtual ICollection<HrAttendanceOvertimeLine> HrAttendanceOvertimeLine { get; set; }
}
