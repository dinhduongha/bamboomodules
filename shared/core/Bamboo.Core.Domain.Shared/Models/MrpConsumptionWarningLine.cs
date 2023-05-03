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

[Table("mrp_consumption_warning_line")]
public partial class MrpConsumptionWarningLine: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("mrp_consumption_warning_id")]
    public Guid? MrpConsumptionWarningId { get; set; }

    [Column("mrp_production_id")]
    public Guid? MrpProductionId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("product_consumed_qty_uom")]
    public double? ProductConsumedQtyUom { get; set; }

    [Column("product_expected_qty_uom")]
    public double? ProductExpectedQtyUom { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MrpConsumptionWarningLineCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("MrpConsumptionWarningId")]
    //[InverseProperty("MrpConsumptionWarningLines")]
    [NotMapped]
    public virtual MrpConsumptionWarning? MrpConsumptionWarning { get; set; }

    [ForeignKey("MrpProductionId")]
    //[InverseProperty("MrpConsumptionWarningLines")]
    [NotMapped]
    public virtual MrpProduction? MrpProduction { get; set; }

    [ForeignKey("ProductId")]
    //[InverseProperty("MrpConsumptionWarningLines")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MrpConsumptionWarningLineWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
