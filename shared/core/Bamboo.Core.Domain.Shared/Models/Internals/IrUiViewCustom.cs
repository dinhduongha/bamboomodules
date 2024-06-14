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
//[Index("RefId", Name = "ir_ui_view_custom_ref_id_index")]
//[Index("UserId", Name = "ir_ui_view_custom_user_id_index")]
//[Index("UserId", "RefId", Name = "ir_ui_view_custom_user_id_ref_id")]
public partial class IrUiViewCustom: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("ref_id")]
    public Guid? RefId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("arch")]
    public string? Arch { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("IrUiViewCustomCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("RefId")]
    //[InverseProperty("IrUiViewCustoms")]
    [NotMapped]
    public virtual IrUiView? Ref { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("IrUiViewCustomUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("IrUiViewCustomWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
