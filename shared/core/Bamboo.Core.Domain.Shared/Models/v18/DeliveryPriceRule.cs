using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bamboo.Core.Models;

[Table("delivery_price_rule")]
public partial class DeliveryPriceRule: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("carrier_id")]
    public Guid? CarrierId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("variable")]
    public string? Variable { get; set; }

    [Column("operator")]
    public string? Operator { get; set; }

    [Column("variable_factor")]
    public string? VariableFactor { get; set; }

    [Column("list_base_price")]
    public decimal? ListBasePrice { get; set; }

    [Column("list_price")]
    public decimal? ListPrice { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("max_value")]
    public double? MaxValue { get; set; }

    [ForeignKey("CarrierId")]
    //[InverseProperty("DeliveryPriceRules")]
    [NotMapped]
    public virtual DeliveryCarrier? Carrier { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("DeliveryPriceRuleCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("DeliveryPriceRuleWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
