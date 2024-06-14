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

[Table("crm_lead_scoring_frequency_field")]
public partial class CrmLeadScoringFrequencyField: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("field_id")]
    public Guid? FieldId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("CrmLeadScoringFrequencyFieldCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("FieldId")]
    //[InverseProperty("CrmLeadScoringFrequencyFields")]
    [NotMapped]
    public virtual IrModelField? Field { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("CrmLeadScoringFrequencyFieldWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("CrmLeadScoringFrequencyFieldId")]
    //[InverseProperty("CrmLeadScoringFrequencyFields")]
    [NotMapped]
    public virtual ICollection<CrmLeadPlsUpdate> CrmLeadPlsUpdates { get; } = new List<CrmLeadPlsUpdate>();
}
