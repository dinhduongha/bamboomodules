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

[Table("website_rewrite")]
//[Index("UrlFrom", Name = "website_rewrite_url_from_index")]
//[Index("WebsiteId", Name = "website_rewrite_website_id_index")]
public partial class WebsiteRewrite: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("route_id")]
    public Guid? RouteId { get; set; }

    [Column("sequence")]
    public long Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("url_from")]
    public string? UrlFrom { get; set; }

    [Column("url_to")]
    public string? UrlTo { get; set; }

    [Column("redirect_type")]
    public string? RedirectType { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("WebsiteRewriteCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("RouteId")]
    //[InverseProperty("WebsiteRewrites")]
    [NotMapped]
    public virtual WebsiteRoute? Route { get; set; }

    [ForeignKey("WebsiteId")]
    //[InverseProperty("WebsiteRewrites")]
    [NotMapped]
    public virtual Website? Website { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("WebsiteRewriteWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
