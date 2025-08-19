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

[Table("res_groups")]
//[Index("CategoryId", Name = "res_groups__category_id_index")]
//[Index("CategoryId", "Name", Name = "res_groups_name_uniq", IsUnique = true)]
public partial class ResGroups: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("category_id")]
    public Guid? CategoryId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [JsonField]
    [Column("comment", TypeName = "jsonb")]
    public string? Comment { get; set; }

    [Column("share")]
    public bool? Share { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("api_key_duration")]
    public double? ApiKeyDuration { get; set; }

    // [Many2one]
    [ForeignKey("CategoryId")]
    // [InverseProperty("ResGroups")] //Many2one
    public virtual IrModuleCategory? Category { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("ResGroupsCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("GroupId")]
    [InverseProperty("Group")]
    public virtual ICollection<DigestTip> DigestTip { get; set; }

    // [One2many]
    [ForeignKey("GroupPublicId")]
    [InverseProperty("GroupPublic")]
    public virtual ICollection<DiscussChannel> DiscussChannel { get; set; }

    // [One2many]
    [ForeignKey("AuthorizedGroupId")]
    [InverseProperty("AuthorizedGroup")]
    public virtual ICollection<ForumForum> ForumForum { get; set; }

    // [One2many]
    [ForeignKey("GroupId")]
    [InverseProperty("Group")]
    public virtual ICollection<IrModelAccess> IrModelAccess { get; set; }

    // [One2many]
    [ForeignKey("GroupPublicId")]
    [InverseProperty("GroupPublic")]
    public virtual ICollection<MailChannel> MailChannel { get; set; }

    // [One2many]
    [ForeignKey("AccessGroupId")]
    [InverseProperty("AccessGroup")]
    public virtual ICollection<MailGroup> MailGroup { get; set; }

    // [One2many]
    [ForeignKey("GroupPosManagerId")]
    [InverseProperty("GroupPosManager")]
    public virtual ICollection<PosConfig> PosConfigGroupPosManager { get; set; }

    // [One2many]
    [ForeignKey("GroupPosUserId")]
    [InverseProperty("GroupPosUser")]
    public virtual ICollection<PosConfig> PosConfigGroupPosUser { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("ResGroupsWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    [ForeignKey("Gid")]
    [InverseProperty("Gid")]
    public virtual ICollection<IrActServer> Act { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("Gid")]
    // [InverseProperty("Gid")]
    // public virtual ICollection<IrActWindow> ActNavigation { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("GroupId")]
    // [InverseProperty("Group")]
    // public virtual ICollection<SlideChannel> Channel { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResGroupsId")]
    // [InverseProperty("ResGroups")]
    // public virtual ICollection<DiscussChannel> DiscussChannelNavigation { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("GroupId")]
    // [InverseProperty("Group")]
    // public virtual ICollection<IrModelFields> Field { get; set; }

    // [Many2many] // Normal
    [NotMapped] //Many2many // Normal
    [ForeignKey("Hid")] //Many2many
    [InverseProperty("Hid")] //Many2many
    public virtual ICollection<ResGroups> Gid { get; set; }

    // [Many2many] // Normal
    [NotMapped] //Many2many // Normal
    [ForeignKey("Gid")] //Many2many
    [InverseProperty("Gid")] //Many2many
    public virtual ICollection<ResGroups> Hid { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResGroupsId")]
    // [InverseProperty("ResGroups")]
    // public virtual ICollection<IrEmbeddedActions> IrEmbeddedActions { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResGroupsId")]
    // [InverseProperty("ResGroups")]
    // public virtual ICollection<MailCannedResponse> MailCannedResponse { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResGroupsId")]
    // [InverseProperty("ResGroups")]
    // public virtual ICollection<MailChannel> MailChannelNavigation { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    [ForeignKey("Gid")]
    [InverseProperty("Gid")]
    public virtual ICollection<IrUiMenu> Menu { get; set; }

    // [Many2many] // ManyToMany Hidden
     [NotMapped] //Many2many // Hidden
    // [ForeignKey("GroupId")]
    // [InverseProperty("Group")]
     public virtual ICollection<IrRule> RuleGroup { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResGroupsId")]
    // [InverseProperty("ResGroups")]
    // public virtual ICollection<SlideChannel> SlideChannel { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResGroupsId")]
    // [InverseProperty("ResGroups")]
    // public virtual ICollection<SpreadsheetDashboard> SpreadsheetDashboard { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("Gid")]
    // [InverseProperty("Gid")]
    public virtual ICollection<IrActReportXml> Uid { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("Gid")] //Many2many
    // [InverseProperty("Gid")] //Many2many
    public virtual ICollection<ResUsers> UidNavigation { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    [ForeignKey("GroupId")]
    [InverseProperty("Group")]
    public virtual ICollection<IrUiView> View { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    [ForeignKey("ResGroupsId")]
    [InverseProperty("ResGroups")]
    public virtual ICollection<WebsiteMenu> WebsiteMenu { get; set; }
}
