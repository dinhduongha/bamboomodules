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

[Table("project_update")]
public partial class ProjectUpdate: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("progress")]
    public long? Progress { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("project_id")]
    public Guid? ProjectId { get; set; }

    [Column("task_count")]
    public long? TaskCount { get; set; }

    [Column("closed_task_count")]
    public long? ClosedTaskCount { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("email_cc")]
    public string? EmailCc { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("status")]
    public string? Status { get; set; }

    [Column("date")]
    public DateTime? Date { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("allocated_time")]
    public long? AllocatedTime { get; set; }

    [Column("timesheet_time")]
    public long? TimesheetTime { get; set; }

    [Column("uom_id")]
    public Guid? UomId { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("ProjectUpdateCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("ProjectUpdate")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("ProjectId")]
    // [InverseProperty("ProjectUpdate")] //Many2one
    public virtual ProjectProject? Project { get; set; }

    // [One2many]
    [ForeignKey("LastUpdateId")]
    [InverseProperty("LastUpdate")]
    public virtual ICollection<ProjectProject> ProjectProject { get; set; }

    // [Many2one]
    [ForeignKey("UomId")]
    // [InverseProperty("ProjectUpdate")] //Many2one
    public virtual UomUom? Uom { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    // [InverseProperty("ProjectUpdateUser")] //Many2one
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("ProjectUpdateWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
