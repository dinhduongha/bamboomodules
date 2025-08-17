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

[Table("maintenance_request")]
//[Index("EquipmentId", Name = "maintenance_request_equipment_id_index")]
public partial class MaintenanceRequest: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("request_date")]
    public DateTime? RequestDate { get; set; }

    [Column("close_date")]
    public DateTime? CloseDate { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("archive")]
    public bool? Archive { get; set; }

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
    [ForeignKey("CategoryId")]
    // [InverseProperty("MaintenanceRequest")] //Many2one
    public virtual MaintenanceEquipmentCategory? Category { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("MaintenanceRequest")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("MaintenanceRequestCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("EmployeeId")]
    // [InverseProperty("MaintenanceRequest")] //Many2one
    public virtual HrEmployee? Employee { get; set; }

    // [Many2one]
    [ForeignKey("EquipmentId")]
    // [InverseProperty("MaintenanceRequest")] //Many2one
    public virtual MaintenanceEquipment? Equipment { get; set; }

    // [Many2one]
    [ForeignKey("MaintenanceTeamId")]
    // [InverseProperty("MaintenanceRequest")] //Many2one
    public virtual MaintenanceTeam? MaintenanceTeam { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MaintenanceRequest")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("OwnerUserId")]
    // [InverseProperty("MaintenanceRequestOwnerUser")] //Many2one
    public virtual ResUsers? OwnerUser { get; set; }

    // [Many2one]
    [ForeignKey("StageId")]
    // [InverseProperty("MaintenanceRequest")] //Many2one
    public virtual MaintenanceStage? Stage { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    // [InverseProperty("MaintenanceRequestUser")] //Many2one
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("MaintenanceRequestWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
