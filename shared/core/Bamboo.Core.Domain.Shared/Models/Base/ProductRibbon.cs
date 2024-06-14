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

[Table("product_ribbon")]
public partial class ProductRibbon: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("bg_color")]
    public string? BgColor { get; set; }

    [Column("text_color")]
    public string? TextColor { get; set; }

    [Column("html_class")]
    public string? HtmlClass { get; set; }

    [Column("html", TypeName = "jsonb")]
    public string? Html { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ProductRibbonCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ProductRibbonWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Ribbon")]
    [NotMapped]
    public virtual ICollection<ProductTag> ProductTags { get; } = new List<ProductTag>();

    //[InverseProperty("WebsiteRibbon")]
    [NotMapped]
    public virtual ICollection<ProductTemplate> ProductTemplates { get; } = new List<ProductTemplate>();

}
