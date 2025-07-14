using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bamboo.Core.Models;

[Table("slide_slide_resource")]
public partial class SlideSlideResource: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("slide_id")]
    public Guid? SlideId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("resource_type")]
    public string? ResourceType { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("file_name")]
    public string? FileName { get; set; }

    [Column("link")]
    public string? Link { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("SlideSlideResourceCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("SlideId")]
    //[InverseProperty("SlideSlideResources")]
    [NotMapped]
    public virtual SlideSlide? Slide { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("SlideSlideResourceWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
