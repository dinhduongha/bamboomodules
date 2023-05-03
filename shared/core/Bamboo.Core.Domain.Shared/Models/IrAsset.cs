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

[Table("ir_asset")]
public partial class IrAsset: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("sequence")]
    public long Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("bundle")]
    public string? Bundle { get; set; }

    [Column("directive")]
    public string? Directive { get; set; }

    [Column("path")]
    public string? Path { get; set; }

    [Column("target")]
    public string? Target { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("theme_template_id")]
    public long? ThemeTemplateId { get; set; }

    [Column("key")]
    public string? Key { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("IrAssetCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ThemeTemplateId")]
    //[InverseProperty("IrAssets")]
    [NotMapped]
    public virtual ThemeIrAsset? ThemeTemplate { get; set; }

    [ForeignKey("WebsiteId")]
    //[InverseProperty("IrAssets")]
    [NotMapped]
    public virtual Website? Website { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("IrAssetWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
