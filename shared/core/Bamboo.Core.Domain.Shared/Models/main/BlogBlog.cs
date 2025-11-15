using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

[Table("blog_blog")]
//[Index("WebsiteId", Name = "blog_blog__website_id_index")]
public partial class BlogBlog : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("website_meta_og_img")]
    public string? WebsiteMetaOgImg { get; set; }

    [JsonField(IsSparse = false)] // WebsiteMetaTitle
    [Column("website_meta_title", TypeName = "jsonb")]
    public StringDictionary? WebsiteMetaTitle { get; set; }

    [JsonField(IsSparse = false)] // WebsiteMetaDescription
    [Column("website_meta_description", TypeName = "jsonb")]
    public StringDictionary? WebsiteMetaDescription { get; set; }

    [JsonField] // WebsiteMetaKeywords
    [Column("website_meta_keywords", TypeName = "jsonb")]
    public JsonElement? WebsiteMetaKeywords { get; set; }

    [JsonField(IsSparse = false)] // SeoName
    [Column("seo_name", TypeName = "jsonb")]
    public StringDictionary? SeoName { get; set; }

    [JsonField(IsSparse = false)] // Name
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [JsonField] // Subtitle
    [Column("subtitle", TypeName = "jsonb")]
    public JsonElement? Subtitle { get; set; }

    [JsonField] // Content
    [Column("content", TypeName = "jsonb")]
    public JsonElement? Content { get; set; }

    [Column("cover_properties")]
    public string? CoverProperties { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("BlogId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Blog")] // One2many
    public virtual ICollection<BlogPost> BlogPost { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("WebsiteId")]
    public virtual Website? Website { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
