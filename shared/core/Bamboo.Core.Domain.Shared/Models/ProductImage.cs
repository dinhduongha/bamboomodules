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

[Table("product_image")]
//[Index("ProductTmplId", Name = "product_image_product_tmpl_id_index")]
//[Index("ProductVariantId", Name = "product_image_product_variant_id_index")]
public partial class ProductImage: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("sequence")]
    public long Sequence { get; set; }

    [Column("product_tmpl_id")]
    public Guid? ProductTmplId { get; set; }

    [Column("product_variant_id")]
    public Guid? ProductVariantId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("video_url")]
    public string? VideoUrl { get; set; }

    [Column("can_image_1024_be_zoomed")]
    public bool? CanImage1024BeZoomed { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ProductImageCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ProductTmplId")]
    //[InverseProperty("ProductImages")]
    [NotMapped]
    public virtual ProductTemplate? ProductTmpl { get; set; }

    [ForeignKey("ProductVariantId")]
    //[InverseProperty("ProductImages")]
    [NotMapped]
    public virtual ProductProduct? ProductVariant { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ProductImageWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
