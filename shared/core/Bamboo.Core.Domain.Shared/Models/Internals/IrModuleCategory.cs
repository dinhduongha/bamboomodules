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
//[Index("ParentId", Name = "ir_module_category__parent_id_index")]
public partial class IrModuleCategory: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IAuditedObject
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

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [JsonField]
    [Column("description", TypeName = "jsonb")]
    public string? Description { get; set; }

    [Column("visible")]
    public bool? Visible { get; set; }

    [Column("exclusive")]
    public bool? Exclusive { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("IrModuleCategoryCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("ParentId")]
    [InverseProperty("Parent")]
    public virtual ICollection<IrModuleCategory> InverseParent { get; set; }

    // [One2many]
    [ForeignKey("CategoryId")]
    [InverseProperty("Category")]
    public virtual ICollection<IrModuleModule> IrModuleModule { get; set; }

    // [Many2one]
    [ForeignKey("ParentId")]
    // [InverseProperty("InverseParent")] //Many2one
    public virtual IrModuleCategory? Parent { get; set; }

    // [One2many]
    [ForeignKey("CategoryId")]
    [InverseProperty("Category")]
    public virtual ICollection<ResGroups> ResGroups { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("IrModuleCategoryWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
