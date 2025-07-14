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

[Table("event_tag")]
//[Index("IsPublished", Name = "event_tag__is_published_index")]
//[Index("WebsiteId", Name = "event_tag__website_id_index")]
public partial class EventTag: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("category_id")]
    public Guid? CategoryId { get; set; }

    [Column("category_sequence")]
    public long? CategorySequence { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("is_published")]
    public bool? IsPublished { get; set; }

    [ForeignKey("CategoryId")]
    //[InverseProperty("EventTags")]
    [NotMapped]
    public virtual EventTagCategory? Category { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("EventTagCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("WebsiteId")]
    //[InverseProperty("EventTags")]
    [NotMapped]
    public virtual Website? Website { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("EventTagWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("EventTagId")]
    //[InverseProperty("EventTags")]
    [NotMapped]
    public virtual ICollection<EventEvent> EventEvents { get; set; } = new List<EventEvent>();

    [ForeignKey("EventTagId")]
    //[InverseProperty("EventTags")]
    [NotMapped]
    public virtual ICollection<EventType> EventTypes { get; set; } = new List<EventType>();
}
