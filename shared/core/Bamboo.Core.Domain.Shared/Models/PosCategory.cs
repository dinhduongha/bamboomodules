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
public partial class PosCategory: Entity<long>, IEntityDto<long>
{
    [Key]
    [Column("id")]
    public long Id { get => base.Id; set => base.Id = value; }

    [Column("parent_id")]
    public long? ParentId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("PosCategoryCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

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
    public virtual ICollection<PosCategory> InverseParent { get; } = new List<PosCategory>();

    //[InverseProperty("IfaceStartCateg")]
    [NotMapped]
    public virtual ICollection<PosConfig> PosConfigsNavigation { get; } = new List<PosConfig>();

    //[InverseProperty("PosCateg")]
    [NotMapped]
    public virtual ICollection<ProductTemplate> ProductTemplates { get; } = new List<ProductTemplate>();

    //[InverseProperty("PosIfaceStartCateg")]
    [NotMapped]
    public virtual ICollection<ResConfigSetting> ResConfigSettingsNavigation { get; } = new List<ResConfigSetting>();

    [ForeignKey("PosCategoryId")]
    //[InverseProperty("PosCategories")]
    [NotMapped]
    public virtual ICollection<PosConfig> PosConfigs { get; } = new List<PosConfig>();

    [ForeignKey("PosCategoryId")]
    //[InverseProperty("PosCategories")]
    [NotMapped]
    public virtual ICollection<ResConfigSetting> ResConfigSettings { get; } = new List<ResConfigSetting>();
}
