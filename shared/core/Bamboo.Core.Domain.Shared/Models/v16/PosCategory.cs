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
public partial class PosCategory : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("hour_until")]
    public double? HourUntil { get; set; }

    [Column("hour_after")]
    public double? HourAfter { get; set; }

    // v16-Compat
    [ForeignKey("TenantId")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("PosCategoryCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    //[InverseProperty("Parent")]
    // [NotMapped]
    // public virtual ICollection<PosCategory> InverseParent { get; set; } = new List<PosCategory>();

    [ForeignKey("ParentId")]
    //[InverseProperty("InverseParent")]
    [NotMapped]
    public virtual PosCategory? Parent { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("PosCategoryWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Parent")]
    [NotMapped]
    public virtual ICollection<PosCategory> InverseParent { get; set; } = new List<PosCategory>();

    //[InverseProperty("IfaceStartCateg")]
    [NotMapped]
    public virtual ICollection<PosConfig> PosConfigsNavigation { get; set; } = new List<PosConfig>();

    //[InverseProperty("PosCateg")]
    [NotMapped]
    public virtual ICollection<ProductTemplate> ProductTemplates { get; set; } = new List<ProductTemplate>();

    //[InverseProperty("PosIfaceStartCateg")]
    [NotMapped]
    public virtual ICollection<ResConfigSetting> ResConfigSettingsNavigation { get; set; } = new List<ResConfigSetting>();

    [ForeignKey("PosCategoryId")]
    //[InverseProperty("PosCategories")]
    [NotMapped]
    public virtual ICollection<PosConfig> PosConfigs { get; set; } = new List<PosConfig>();

    [ForeignKey("PosCategoryId")]
    //[InverseProperty("PosCategories")]
    [NotMapped]
    public virtual ICollection<ResConfigSetting> ResConfigSettings { get; set; } = new List<ResConfigSetting>();
}
