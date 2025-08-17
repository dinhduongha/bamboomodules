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

[Table("pos_category")]
//[Index("ParentId", Name = "pos_category_parent_id_index")]
public partial class PosCategory: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

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

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("PosCategoryCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("ParentId")]
    [InverseProperty("Parent")]
    public virtual ICollection<PosCategory> InverseParent { get; set; }

    // [Many2one]
    [ForeignKey("ParentId")]
    // [InverseProperty("InverseParent")] //Many2one
    public virtual PosCategory? Parent { get; set; }

    // [One2many]
    [ForeignKey("IfaceStartCategId")]
    [InverseProperty("IfaceStartCateg")]
    public virtual ICollection<PosConfig> PosConfigNavigation { get; set; }

    // [One2many]
    [ForeignKey("PosCategId")]
    [InverseProperty("PosCateg")]
    public virtual ICollection<ProductTemplate> ProductTemplate { get; set; }

    // [One2many]
    [ForeignKey("PosIfaceStartCategId")]
    [InverseProperty("PosIfaceStartCateg")]
    public virtual ICollection<ResConfigSettings> ResConfigSettingsNavigation { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("PosCategoryWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("PosCategoryId")]
    // [InverseProperty("PosCategory")]
    // public virtual ICollection<PosConfig> PosConfig { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("CategoryId")]
    // [InverseProperty("Category")]
    // public virtual ICollection<RestaurantPrinter> Printer { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("PosCategoryId")]
    // [InverseProperty("PosCategory")]
    // public virtual ICollection<ResConfigSettings> ResConfigSettings { get; set; }
}
