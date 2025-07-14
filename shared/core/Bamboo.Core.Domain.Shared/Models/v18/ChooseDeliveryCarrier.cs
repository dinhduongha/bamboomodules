using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bamboo.Core.Models;

[Table("choose_delivery_carrier")]
public partial class ChooseDeliveryCarrier: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("order_id")]
    public Guid? OrderId { get; set; }

    [Column("carrier_id")]
    public Guid? CarrierId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("weight_uom_name")]
    public string? WeightUomName { get; set; }

    [Column("delivery_message")]
    public string? DeliveryMessage { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("delivery_price")]
    public double? DeliveryPrice { get; set; }

    [Column("display_price")]
    public double? DisplayPrice { get; set; }

    [ForeignKey("CarrierId")]
    //[InverseProperty("ChooseDeliveryCarriers")]
    [NotMapped]
    public virtual DeliveryCarrier? Carrier { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ChooseDeliveryCarrierCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("OrderId")]
    //[InverseProperty("ChooseDeliveryCarriers")]
    [NotMapped]
    public virtual SaleOrder? Order { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ChooseDeliveryCarrierWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
