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

[Table("procurement_group")]
public partial class ProcurementGroup: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("move_type")]
    public string? MoveType { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("pos_order_id")]
    public Guid? PosOrderId { get; set; }

    [Column("sale_id")]
    public Guid? SaleId { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ProcurementGroupCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("PartnerId")]
    //[InverseProperty("ProcurementGroups")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }

    [ForeignKey("PosOrderId")]
    //[InverseProperty("ProcurementGroups")]
    [NotMapped]
    public virtual PosOrder? PosOrder { get; set; }

    [ForeignKey("SaleId")]
    //[InverseProperty("ProcurementGroups")]
    [NotMapped]
    public virtual SaleOrder? Sale { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ProcurementGroupWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("ProcurementGroup")]
    [NotMapped]
    public virtual ICollection<MrpProduction> MrpProductions { get; } = new List<MrpProduction>();

    //[InverseProperty("ProcurementGroup")]
    [NotMapped]
    public virtual ICollection<PosOrder> PosOrders { get; } = new List<PosOrder>();

    //[InverseProperty("Group")]
    [NotMapped]
    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; } = new List<PurchaseOrder>();

    //[InverseProperty("ProcurementGroup")]
    [NotMapped]
    public virtual ICollection<SaleOrder> SaleOrders { get; } = new List<SaleOrder>();

    //[InverseProperty("Group")]
    [NotMapped]
    public virtual ICollection<StockMove> StockMoves { get; } = new List<StockMove>();

    //[InverseProperty("Group")]
    [NotMapped]
    public virtual ICollection<StockPicking> StockPickings { get; } = new List<StockPicking>();

    //[InverseProperty("Group")]
    [NotMapped]
    public virtual ICollection<StockRule> StockRules { get; } = new List<StockRule>();

    //[InverseProperty("Group")]
    [NotMapped]
    public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpoints { get; } = new List<StockWarehouseOrderpoint>();

}
