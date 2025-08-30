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

[Table("im_livechat_channel")]
//[Index("IsPublished", Name = "im_livechat_channel__is_published_index")]
public partial class ImLivechatChannel: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("header_background_color")]
    public string? HeaderBackgroundColor { get; set; }

    [Column("title_color")]
    public string? TitleColor { get; set; }

    [Column("button_background_color")]
    public string? ButtonBackgroundColor { get; set; }

    [Column("button_text_color")]
    public string? ButtonTextColor { get; set; }

    [JsonField] // ButtonText
    [Column("button_text", TypeName = "jsonb")]
    public JsonElement? ButtonText { get; set; }

    [JsonField(IsSparse = false)] // DefaultMessage
    [Column("default_message", TypeName = "jsonb")]
    public StringDictionary? DefaultMessage { get; set; }

    [JsonField] // InputPlaceholder
    [Column("input_placeholder", TypeName = "jsonb")]
    public JsonElement? InputPlaceholder { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [JsonField(IsSparse = false)] // WebsiteDescription
    [Column("website_description", TypeName = "jsonb")]
    public StringDictionary? WebsiteDescription { get; set; }

    [Column("is_published")]
    public bool? IsPublished { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LivechatChannelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("LivechatChannel")] // One2many
    public virtual ICollection<DiscussChannel> DiscussChannel { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ChannelId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Channel")] // One2many
    public virtual ICollection<ImLivechatChannelRule> ImLivechatChannelRule { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ChannelId")]
    [NotMapped] // One2many // Peer relationship (Website) is commented out
    // [InverseProperty("Channel")] // One2many
    public virtual ICollection<Website> Website { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] // Many2many // Peer relationship (ResUsers) is commented out
    // [ForeignKey("ChannelId")] // Many2many // Normal
    // [InverseProperty("Channel")] // Many2many // Normal
    public virtual ICollection<ResUsers> User { get; set; }
}
