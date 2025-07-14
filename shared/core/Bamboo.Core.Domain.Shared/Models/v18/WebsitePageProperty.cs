using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bamboo.Core.Models;

[Table("website_page_properties")]
public partial class WebsitePageProperty: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("target_model_id")]
    public Guid? TargetModelId { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("old_url")]
    public string? OldUrl { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("WebsitePagePropertyCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("TargetModelId")]
    //[InverseProperty("WebsitePageProperties")]
    [NotMapped]
    public virtual WebsitePage? TargetModel { get; set; }

    [ForeignKey("WebsiteId")]
    //[InverseProperty("WebsitePageProperties")]
    [NotMapped]
    public virtual Website? Website { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("WebsitePagePropertyWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
