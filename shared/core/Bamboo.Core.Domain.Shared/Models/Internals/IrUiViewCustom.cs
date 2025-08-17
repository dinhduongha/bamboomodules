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

[Table("ir_ui_view_custom")]
//[Index("RefId", Name = "ir_ui_view_custom__ref_id_index")]
//[Index("UserId", Name = "ir_ui_view_custom__user_id_index")]
//[Index("UserId", "RefId", Name = "ir_ui_view_custom_user_id_ref_id")]
public partial class IrUiViewCustom: FullAuditedEntity<Guid>, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("ref_id")]
    public Guid? RefId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("arch")]
    public string? Arch { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("IrUiViewCustomCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("RefId")]
    // [InverseProperty("IrUiViewCustom")] //Many2one
    public virtual IrUiView? Ref { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    // [InverseProperty("IrUiViewCustomUser")] //Many2one
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("IrUiViewCustomWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
