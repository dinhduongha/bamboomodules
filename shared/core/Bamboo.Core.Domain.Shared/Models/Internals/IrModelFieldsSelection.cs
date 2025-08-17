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

[Table("ir_model_fields_selection")]
//[Index("FieldId", Name = "ir_model_fields_selection__field_id_index")]
//[Index("FieldId", "Value", Name = "ir_model_fields_selection_selection_field_uniq", IsUnique = true)]
public partial class IrModelFieldsSelection: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("field_id")]
    public Guid? FieldId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("value")]
    public string? Value { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [One2many]
    [ForeignKey("TrgSelectionFieldId")]
    [InverseProperty("TrgSelectionField")]
    public virtual ICollection<BaseAutomation> BaseAutomation { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("IrModelFieldsSelectionCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("FieldId")]
    // [InverseProperty("IrModelFieldsSelection")] //Many2one
    public virtual IrModelFields? Field { get; set; }

    // [One2many]
    [ForeignKey("SelectionValue")]
    [InverseProperty("SelectionValueNavigation")]
    public virtual ICollection<IrActServer> IrActServer { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("IrModelFieldsSelectionWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
