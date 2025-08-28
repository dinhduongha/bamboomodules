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

[Table("blog_post")]
//[Index("IsPublished", Name = "blog_post__is_published_index")]
//[Index("WebsiteId", Name = "blog_post__website_id_index")]
public partial class BlogPost: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("author_id")]
    public Guid? AuthorId { get; set; }

    [Column("blog_id")]
    public Guid? BlogId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("visits")]
    public long? Visits { get; set; }

    [Column("website_meta_og_img")]
    public string? WebsiteMetaOgImg { get; set; }

    [Column("author_name")]
    public string? AuthorName { get; set; }

    [JsonField]
    [Column("website_meta_title", TypeName = "jsonb")]
    public string? WebsiteMetaTitle { get; set; }

    [JsonField]
    [Column("website_meta_description", TypeName = "jsonb")]
    public string? WebsiteMetaDescription { get; set; }

    [JsonField]
    [Column("website_meta_keywords", TypeName = "jsonb")]
    public string? WebsiteMetaKeywords { get; set; }

    [JsonField]
    [Column("seo_name", TypeName = "jsonb")]
    public string? SeoName { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [JsonField]
    [Column("subtitle", TypeName = "jsonb")]
    public string? Subtitle { get; set; }

    [JsonField]
    [Column("content", TypeName = "jsonb")]
    public string? Content { get; set; }

    [JsonField]
    [Column("teaser_manual", TypeName = "jsonb")]
    public string? TeaserManual { get; set; }

    [Column("cover_properties")]
    public string? CoverProperties { get; set; }

    [Column("is_published")]
    public bool? IsPublished { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("published_date", TypeName = "timestamp without time zone")]
    public DateTime? PublishedDate { get; set; }

    [Column("post_date", TypeName = "timestamp without time zone")]
    public DateTime? PostDate { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("AuthorId")]
    public virtual ResPartner? Author { get; set; }

    // [Many2one]
    [ForeignKey("BlogId")]
    public virtual BlogBlog? Blog { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("WebsiteId")]
    public virtual Website? Website { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("BlogPostId")] //Many2many // Hidden
    // [InverseProperty("BlogPost")] //Many2many // Hidden
    public virtual ICollection<BlogTag> BlogTag { get; set; }
}
