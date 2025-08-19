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

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("category_id")]
    public Guid? CategoryId { get; set; }

    [Column("category_sequence")]
    public long? CategorySequence { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("is_published")]
    public bool? IsPublished { get; set; }

    // [Many2one]
    [ForeignKey("CategoryId")]
    // [InverseProperty("EventTag")] //Many2one
    public virtual EventTagCategory? Category { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("EventTagCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("WebsiteId")]
    // [InverseProperty("EventTag")] //Many2one
    public virtual Website? Website { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("EventTagWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("EventTagId")]
    // [InverseProperty("EventTag")]
    public virtual ICollection<EventEvent> EventEvent { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("EventTagId")]
    // [InverseProperty("EventTag")]
    public virtual ICollection<EventType> EventType { get; set; }
}
