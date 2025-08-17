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

[Table("delivery_price_rule")]
public partial class DeliveryPriceRule: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("carrier_id")]
    public Guid? CarrierId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

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
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("max_value")]
    public double? MaxValue { get; set; }

    // [Many2one]
    [ForeignKey("CarrierId")]
    // [InverseProperty("DeliveryPriceRule")] //Many2one
    public virtual DeliveryCarrier? Carrier { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("DeliveryPriceRuleCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("DeliveryPriceRuleWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
