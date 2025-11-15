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

[Table("maintenance_request")]
//[Index("EquipmentId", Name = "maintenance_request__equipment_id_index")]
public partial class MaintenanceRequest : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("owner_user_id")]
    public Guid? OwnerUserId { get; set; }

    [Column("category_id")]
    public Guid? CategoryId { get; set; }

    [Column("equipment_id")]
    public Guid? EquipmentId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("stage_id")]
    public Guid? StageId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("maintenance_team_id")]
    public Guid? MaintenanceTeamId { get; set; }

    [Column("repeat_interval")]
    public long? RepeatInterval { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("email_cc")]
    public string? EmailCc { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("priority")]
    public string? Priority { get; set; }

    [Column("kanban_state")]
    public string? KanbanState { get; set; }

    [Column("maintenance_type")]
    public string? MaintenanceType { get; set; }

    [Column("instruction_type")]
    public string? InstructionType { get; set; }

    [Column("instruction_google_slide")]
    public string? InstructionGoogleSlide { get; set; }

    [Column("repeat_unit")]
    public string? RepeatUnit { get; set; }

    [Column("repeat_type")]
    public string? RepeatType { get; set; }

    [Column("request_date")]
    public DateTime? RequestDate { get; set; }

    [Column("close_date")]
    public DateTime? CloseDate { get; set; }

    [Column("repeat_until")]
    public DateTime? RepeatUntil { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("instruction_text")]
    public string? InstructionText { get; set; }

    [Column("archive")]
    public bool? Archive { get; set; }

    [Column("recurring_maintenance")]
    public bool? RecurringMaintenance { get; set; }

    [Column("schedule_date", TypeName = "timestamp without time zone")]
    public DateTime? ScheduleDate { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("duration")]
    public double? Duration { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CategoryId")]
    public virtual MaintenanceEquipmentCategory? Category { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("EmployeeId")]
    public virtual HrEmployee? Employee { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("EquipmentId")]
    public virtual MaintenanceEquipment? Equipment { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("MaintenanceTeamId")]
    public virtual MaintenanceTeam? MaintenanceTeam { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("OwnerUserId")]
    public virtual ResUsers? OwnerUser { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("StageId")]
    public virtual MaintenanceStage? Stage { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("UserId")]
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
