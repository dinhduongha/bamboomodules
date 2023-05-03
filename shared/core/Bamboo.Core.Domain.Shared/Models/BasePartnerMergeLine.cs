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

[Table("base_partner_merge_line")]
public partial class BasePartnerMergeLine: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("wizard_id")]
    public Guid? WizardId { get; set; }

    [Column("min_id")]
    public Guid? MinId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("aggr_ids")]
    public string? AggrIds { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("BasePartnerMergeLineCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("WizardId")]
    //[InverseProperty("BasePartnerMergeLines")]
    [NotMapped]
    public virtual BasePartnerMergeAutomaticWizard? Wizard { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("BasePartnerMergeLineWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("CurrentLine")]
    [NotMapped]
    public virtual ICollection<BasePartnerMergeAutomaticWizard> BasePartnerMergeAutomaticWizards { get; } = new List<BasePartnerMergeAutomaticWizard>();

}
