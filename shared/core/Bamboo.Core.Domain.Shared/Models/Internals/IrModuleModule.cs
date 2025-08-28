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

[Table("ir_module_module")]
//[Index("CategoryId", Name = "ir_module_module__category_id_index")]
//[Index("State", Name = "ir_module_module__state_index")]
//[Index("Name", Name = "ir_module_module_name_uniq", IsUnique = true)]
public partial class IrModuleModule: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("website")]
    public string? Website { get; set; }

    [JsonField]
    [Column("summary", TypeName = "jsonb")]
    public string? Summary { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("author")]
    public string? Author { get; set; }

    [Column("icon")]
    public string? Icon { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("latest_version")]
    public string? LatestVersion { get; set; }

    [JsonField]
    [Column("shortdesc", TypeName = "jsonb")]
    public string? Shortdesc { get; set; }

    [Column("category_id")]
    public Guid? CategoryId { get; set; }

    [JsonField]
    [Column("description", TypeName = "jsonb")]
    public string? Description { get; set; }

    [Column("application")]
    public bool? Application { get; set; }

    [Column("demo")]
    public bool? Demo { get; set; }

    [Column("web")]
    public bool? Web { get; set; }

    [Column("license")]
    public string? License { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("auto_install")]
    public bool? AutoInstall { get; set; }

    [Column("to_buy")]
    public bool? ToBuy { get; set; }

    [Column("maintainer")]
    public string? Maintainer { get; set; }

    [Column("published_version")]
    public string? PublishedVersion { get; set; }

    [Column("url")]
    public string? Url { get; set; }

    [Column("contributors")]
    public string? Contributors { get; set; }

    [Column("menus_by_module")]
    public string? MenusByModule { get; set; }

    [Column("reports_by_module")]
    public string? ReportsByModule { get; set; }

    [Column("views_by_module")]
    public string? ViewsByModule { get; set; }

    [Column("module_type")]
    public string? ModuleType { get; set; }

    [Column("imported")]
    public bool? Imported { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ModuleId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Module")] // One2many
    public virtual ICollection<BaseModuleInstallRequest> BaseModuleInstallRequest { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ModuleId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Module")] // One2many
    public virtual ICollection<BaseModuleInstallReview> BaseModuleInstallReview { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ModuleId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Module")] // One2many
    public virtual ICollection<BaseModuleUninstall> BaseModuleUninstall { get; set; }

    // [Many2one]
    [ForeignKey("CategoryId")]
    public virtual IrModuleCategory? Category { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ModuleId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Module")] // One2many
    public virtual ICollection<IrDemoFailure> IrDemoFailure { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("Module")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ModuleNavigation")] // One2many
    public virtual ICollection<IrModelConstraint> IrModelConstraint { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("Module")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ModuleNavigation")] // One2many
    public virtual ICollection<IrModelRelation> IrModelRelation { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ModuleId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Module")] // One2many
    public virtual ICollection<IrModuleModuleDependency> IrModuleModuleDependency { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ModuleId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Module")] // One2many
    public virtual ICollection<IrModuleModuleExclusion> IrModuleModuleExclusion { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ModuleId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Module")] // One2many
    public virtual ICollection<PaymentProvider> PaymentProvider { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ModuleId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Module")] // One2many
    public virtual ICollection<WebsiteConfiguratorFeature> WebsiteConfiguratorFeature { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ThemeId")]
    [NotMapped] // One2many // Peer relationship (Website) is commented out
    // [InverseProperty("Theme")] // One2many
    public virtual ICollection<Website> WebsiteNavigation { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [NotMapped] // Many2many // Peer relationship (ResCountry) is commented out
    // [ForeignKey("ModuleId")] // Many2many // Normal
    // [InverseProperty("Module")] // Many2many // Normal
    public virtual ICollection<ResCountry> Country { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ModuleId")] //Many2many // Hidden
    // [InverseProperty("Module")] //Many2many // Hidden
    public virtual ICollection<BaseLanguageExport> Wiz { get; set; }
}
