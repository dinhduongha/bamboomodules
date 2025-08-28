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

[Table("theme_ir_ui_view")]
public partial class ThemeIrUiView: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("priority")]
    public long? Priority { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("key")]
    public string? Key { get; set; }

    [Column("type")]
    public string? Type { get; set; }

    [Column("mode")]
    public string? Mode { get; set; }

    [Column("arch_fs")]
    public string? ArchFs { get; set; }

    [Column("inherit_id")]
    public string? InheritId { get; set; }

    [JsonField]
    [Column("arch", TypeName = "jsonb")]
    public string? Arch { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("customize_show")]
    public bool? CustomizeShow { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ThemeTemplateId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ThemeTemplate")] // One2many
    public virtual ICollection<IrUiView> IrUiView { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ViewId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("View")] // One2many
    public virtual ICollection<ThemeWebsitePage> ThemeWebsitePage { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
