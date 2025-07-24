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

[Table("ir_module_category")]
//[Index("ParentId", Name = "ir_module_category_parent_id_index")]
public partial class IrModuleCategory: FullAuditedEntity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    //[Column("company_id")]
    //public Guid? TenantId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [JsonField]
    [Column("description", TypeName = "jsonb")]
    public StringDictionary? Description { get; set; }

    [Column("visible")]
    public bool? Visible { get; set; }

    [Column("exclusive")]
    public bool? Exclusive { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("IrModuleCategoryCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    //[InverseProperty("Parent")]
    [NotMapped]
    public virtual ICollection<IrModuleCategory> InverseParent { get; set; } = new List<IrModuleCategory>();

    //[InverseProperty("Category")]
    [NotMapped]
    public virtual ICollection<IrModuleModule> IrModuleModules { get; set; } = new List<IrModuleModule>();

    [ForeignKey("ParentId")]
    //[InverseProperty("InverseParent")]
    [NotMapped]
    public virtual IrModuleCategory? Parent { get; set; }

    //[InverseProperty("Category")]
    [NotMapped]
    public virtual ICollection<ResGroup> ResGroups { get; set; } = new List<ResGroup>();

    [ForeignKey("LastModifierId")]
    //[InverseProperty("IrModuleCategoryWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
