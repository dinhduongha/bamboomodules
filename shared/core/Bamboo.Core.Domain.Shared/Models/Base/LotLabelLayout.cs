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

[Table("lot_label_layout")]
public partial class LotLabelLayout: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("label_quantity")]
    public string? LabelQuantity { get; set; }

    [Column("print_format")]
    public string? PrintFormat { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("LotLabelLayoutCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("LotLabelLayoutWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("LotLabelLayoutId")]
    //[InverseProperty("LotLabelLayouts")]
    [NotMapped]
    public virtual ICollection<StockPicking> StockPickings { get; } = new List<StockPicking>();
}
