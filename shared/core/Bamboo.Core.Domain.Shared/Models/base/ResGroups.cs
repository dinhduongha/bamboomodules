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

[Table("res_groups")]
//[Index("CategoryId", Name = "res_groups__category_id_index")]
//[Index("CategoryId", "Name", Name = "res_groups_name_uniq", IsUnique = true)]
public partial class ResGroups: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [JsonField(IsSparse = false)] // Name
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [Column("category_id")]
    public Guid? CategoryId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [JsonField] // Comment
    [Column("comment", TypeName = "jsonb")]
    public JsonElement? Comment { get; set; }

    [Column("share")]
    public bool? Share { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("api_key_duration")]
    public double? ApiKeyDuration { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CategoryId")]
    public virtual IrModuleCategory? Category { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("GroupId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Group")] // One2many
    public virtual ICollection<DigestTip> DigestTip { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("GroupPublicId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("GroupPublic")] // One2many
    public virtual ICollection<DiscussChannel> DiscussChannel { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("AuthorizedGroupId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("AuthorizedGroup")] // One2many
    public virtual ICollection<ForumForum> ForumForum { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("GroupId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Group")] // One2many
    public virtual ICollection<IrModelAccess> IrModelAccess { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("AccessGroupId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("AccessGroup")] // One2many
    public virtual ICollection<MailGroup> MailGroup { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("GroupPosManagerId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("GroupPosManager")] // One2many
    public virtual ICollection<PosConfig> PosConfigGroupPosManager { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("GroupPosUserId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("GroupPosUser")] // One2many
    public virtual ICollection<PosConfig> PosConfigGroupPosUser { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("Gid")] //Many2many // Hidden
    // [InverseProperty("Gid")] //Many2many // Hidden
    public virtual ICollection<IrActServer> Act { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("Gid")] //Many2many // Hidden
    // [InverseProperty("Gid")] //Many2many // Hidden
    public virtual ICollection<IrActWindow> ActNavigation { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("GroupId")] //Many2many // Hidden
    // [InverseProperty("Group")] //Many2many // Hidden
    public virtual ICollection<SlideChannel> Channel { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResGroupsId")] //Many2many // Hidden
    // [InverseProperty("ResGroups")] //Many2many // Hidden
    public virtual ICollection<DiscussChannel> DiscussChannelNavigation { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("GroupId")] //Many2many // Hidden
    // [InverseProperty("Group")] //Many2many // Hidden
    public virtual ICollection<IrModelFields> Field { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("Hid")] // Many2many // Normal
    // [InverseProperty("Hid")] // Many2many // Normal
    public virtual ICollection<ResGroups> Gid { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("Gid")] // Many2many // Normal
    // [InverseProperty("Gid")] // Many2many // Normal
    public virtual ICollection<ResGroups> Hid { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResGroupsId")] //Many2many // Hidden
    // [InverseProperty("ResGroups")] //Many2many // Hidden
    public virtual ICollection<IrEmbeddedActions> IrEmbeddedActions { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResGroupsId")] //Many2many // Hidden
    // [InverseProperty("ResGroups")] //Many2many // Hidden
    public virtual ICollection<MailCannedResponse> MailCannedResponse { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("Gid")] //Many2many // Hidden
    // [InverseProperty("Gid")] //Many2many // Hidden
    public virtual ICollection<IrUiMenu> Menu { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("GroupId")] //Many2many // Hidden
    // [InverseProperty("Group")] //Many2many // Hidden
    public virtual ICollection<IrRule> RuleGroup { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResGroupsId")] //Many2many // Hidden
    // [InverseProperty("ResGroups")] //Many2many // Hidden
    public virtual ICollection<SlideChannel> SlideChannel { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResGroupsId")] //Many2many // Hidden
    // [InverseProperty("ResGroups")] //Many2many // Hidden
    public virtual ICollection<SpreadsheetDashboard> SpreadsheetDashboard { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("Gid")] //Many2many // Hidden
    // [InverseProperty("Gid")] //Many2many // Hidden
    public virtual ICollection<IrActReportXml> Uid { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] // Many2many // Peer relationship (ResUsers) is commented out
    // [ForeignKey("Gid")] // Many2many // Normal
    // [InverseProperty("Gid")] // Many2many // Normal
    public virtual ICollection<ResUsers> UidNavigation { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("GroupId")] //Many2many // Hidden
    // [InverseProperty("Group")] //Many2many // Hidden
    public virtual ICollection<IrUiView> View { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResGroupsId")] //Many2many // Hidden
    // [InverseProperty("ResGroups")] //Many2many // Hidden
    public virtual ICollection<WebsiteMenu> WebsiteMenu { get; set; }
}
