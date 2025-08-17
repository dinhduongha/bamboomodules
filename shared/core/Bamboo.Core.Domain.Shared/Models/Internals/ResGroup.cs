using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bamboo.Core.Domain.Shared.Attributes;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

[Module("base")]
[Table("res_groups")]
//[Index("CategoryId", Name = "res_groups_category_id_index")]
//[Index("CategoryId", "Name", Name = "res_groups_name_uniq", IsUnique = true)]
[Model("res_group")]
public partial class ResGroup : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [Column("category_id")]
    public Guid? CategoryId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [JsonField]
    [Column("comment", TypeName = "jsonb")]
    public string? Comment { get; set; }

    [Column("share")]
    public bool? Share { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("api_key_duration")]
    public double? ApiKeyDuration { get; set; }

    // v16-Compat
    [ForeignKey("TenantId")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CategoryId")]
    //[InverseProperty("ResGroups")]
    [NotMapped]
    public virtual IrModuleCategory? Category { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ResGroupCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ResGroupWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    // RELATIONS BEGIN - MUST HAVE ?
    [ForeignKey("Gid")]
    [InverseProperty("Gids")]
    public virtual ICollection<ResUser> UidsNavigation { get; set; } 

    [ForeignKey("GroupId")]
    [InverseProperty("Groups")]
    //[NotMapped]
    public virtual ICollection<IrRule> RuleGroups { get; set; }
    // RELATIONS END
    
    /// TODO: DISABLE INVERSE COLLECTIONS
    //[InverseProperty("Group")]
    [NotMapped]
    public virtual ICollection<DigestTip> DigestTips { get; set; } 

    //[InverseProperty("GroupPublic")]
    [NotMapped]
    public virtual ICollection<MailChannel> MailChannels { get; set; } 

    //[InverseProperty("Group")]
    [NotMapped]
    public virtual ICollection<IrModelAccess> IrModelAccesses { get; set; } 

    //[InverseProperty("GroupPosManager")]
    [NotMapped]
    public virtual ICollection<PosConfig> PosConfigGroupPosManagers { get; set; } 

    //[InverseProperty("GroupPosUser")]
    [NotMapped]
    public virtual ICollection<PosConfig> PosConfigGroupPosUsers { get; set; } 

    [ForeignKey("Gid")]
    //[InverseProperty("Gids")]
    [NotMapped]
    public virtual ICollection<IrActServer> Acts { get; set; } 

    [ForeignKey("Gid")]
    //[InverseProperty("Gids")]
    [NotMapped]
    public virtual ICollection<IrActWindow> ActsNavigation { get; set; } 

    [ForeignKey("GroupId")]
    //[InverseProperty("Groups")]
    [NotMapped]
    public virtual ICollection<IrModelFields> Fields { get; set; } 

    [ForeignKey("Hid")]
    //[InverseProperty("Hids")]
    [NotMapped]
    public virtual ICollection<ResGroup> Gids { get; set; } 

    [ForeignKey("Gid")]
    //[InverseProperty("Gids")]
    [NotMapped]
    public virtual ICollection<ResGroup> Hids { get; set; } 

    [ForeignKey("ResGroupsId")]
    //[InverseProperty("ResGroups")]
    [NotMapped]
    public virtual ICollection<MailChannel> MailChannelsNavigation { get; set; } 

    [ForeignKey("Gid")]
    //[InverseProperty("Gids")]
    [NotMapped]
    public virtual ICollection<IrUiMenu> Menus { get; set; } 

    [ForeignKey("ResGroupsId")]
    //[InverseProperty("ResGroups")]
    [NotMapped]
    public virtual ICollection<SpreadsheetDashboard> SpreadsheetDashboards { get; set; } 

    [ForeignKey("Gid")]
    //[InverseProperty("Gids")]
    [NotMapped]
    public virtual ICollection<IrActReportXml> Uids { get; set; } 

    [ForeignKey("GroupId")]
    //[InverseProperty("Groups")]
    [NotMapped]
    public virtual ICollection<IrUiView> Views { get; set; } 
}
