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

[Table("im_livechat_channel")]
//[Index("IsPublished", Name = "im_livechat_channel_is_published_index")]
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

    [Column("button_text")]
    public string? ButtonText { get; set; }

    [Column("default_message")]
    public string? DefaultMessage { get; set; }

    [Column("input_placeholder")]
    public string? InputPlaceholder { get; set; }

    [Column("header_background_color")]
    public string? HeaderBackgroundColor { get; set; }

    [Column("title_color")]
    public string? TitleColor { get; set; }

    [Column("button_background_color")]
    public string? ButtonBackgroundColor { get; set; }

    [Column("button_text_color")]
    public string? ButtonTextColor { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [JsonField]
    [Column("website_description", TypeName = "jsonb")]
    public string? WebsiteDescription { get; set; }

    [Column("is_published")]
    public bool? IsPublished { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("ImLivechatChannelCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("ChannelId")]
    [InverseProperty("Channel")]
    public virtual ICollection<ImLivechatChannelRule> ImLivechatChannelRule { get; set; }

    // [One2many]
    [ForeignKey("LivechatChannelId")]
    [InverseProperty("LivechatChannel")]
    public virtual ICollection<MailChannel> MailChannel { get; set; }

    // [One2many]
    [ForeignKey("ChannelId")]
    [InverseProperty("Channel")]
    public virtual ICollection<Website> Website { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("ImLivechatChannelWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("ChannelId")] //Many2many
    // [InverseProperty("Channel")] //Many2many
    public virtual ICollection<ResUsers> User { get; set; }
}
