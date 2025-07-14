using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bamboo.Core.Models;

[Table("slide_embed")]
//[Index("SlideId", Name = "slide_embed__slide_id_index")]
public partial class SlideEmbed: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("slide_id")]
    public Guid? SlideId { get; set; }

    [Column("count_views")]
    public long? CountViews { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("url")]
    public string? Url { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("SlideEmbedCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("SlideId")]
    //[InverseProperty("SlideEmbeds")]
    [NotMapped]
    public virtual SlideSlide? Slide { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("SlideEmbedWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
