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

[Table("slide_channel_tag")]
//[Index("GroupId", Name = "slide_channel_tag__group_id_index")]
//[Index("GroupSequence", Name = "slide_channel_tag__group_sequence_index")]
//[Index("Sequence", Name = "slide_channel_tag__sequence_index")]
public partial class SlideChannelTag: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("sequence")]
    public long Sequence { get; set; }

    [Column("group_id")]
    public Guid? GroupId { get; set; }

    [Column("group_sequence")]
    public long? GroupSequence { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("SlideChannelTagCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("GroupId")]
    //[InverseProperty("SlideChannelTags")]
    [NotMapped]
    public virtual SlideChannelTagGroup? Group { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("SlideChannelTagWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("TagId")]
    //[InverseProperty("Tags")]
    [NotMapped]
    public virtual ICollection<SlideChannel> Channels { get; set; } = new List<SlideChannel>();
}
