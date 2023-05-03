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

[Table("project_milestone")]
public partial class ProjectMilestone: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("project_id")]
    public Guid? ProjectId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("deadline")]
    public DateTime? Deadline { get; set; }

    [Column("reached_date")]
    public DateTime? ReachedDate { get; set; }

    [Column("is_reached")]
    public bool? IsReached { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("sale_line_id")]
    public Guid? SaleLineId { get; set; }

    [Column("quantity_percentage")]
    public double? QuantityPercentage { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ProjectMilestoneCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("ProjectMilestones")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("ProjectId")]
    //[InverseProperty("ProjectMilestones")]
    [NotMapped]
    public virtual ProjectProject? Project { get; set; }

    [ForeignKey("SaleLineId")]
    //[InverseProperty("ProjectMilestones")]
    [NotMapped]
    public virtual SaleOrderLine? SaleLine { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ProjectMilestoneWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Milestone")]
    [NotMapped]
    public virtual ICollection<ProjectTask> ProjectTasks { get; } = new List<ProjectTask>();

}
