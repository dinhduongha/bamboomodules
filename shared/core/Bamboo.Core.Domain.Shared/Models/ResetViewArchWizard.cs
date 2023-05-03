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

[Table("reset_view_arch_wizard")]
public partial class ResetViewArchWizard: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("view_id")]
    public Guid? ViewId { get; set; }

    [Column("compare_view_id")]
    public Guid? CompareViewId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("reset_mode")]
    public string? ResetMode { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CompareViewId")]
    //[InverseProperty("ResetViewArchWizardCompareViews")]
    [NotMapped]
    public virtual IrUiView? CompareView { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ResetViewArchWizardCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ViewId")]
    //[InverseProperty("ResetViewArchWizardViews")]
    [NotMapped]
    public virtual IrUiView? View { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ResetViewArchWizardWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
