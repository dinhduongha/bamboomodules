using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bamboo.Core.Models;

[Table("restaurant_table")]
public partial class RestaurantTable: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("floor_id")]
    public Guid? FloorId { get; set; }

    [Column("table_number")]
    public long? TableNumber { get; set; }

    [Column("seats")]
    public long? Seats { get; set; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("shape")]
    public string? Shape { get; set; }

    [Column("color")]
    public string? Color { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("position_h")]
    public double? PositionH { get; set; }

    [Column("position_v")]
    public double? PositionV { get; set; }

    [Column("width")]
    public double? Width { get; set; }

    [Column("height")]
    public double? Height { get; set; }

    [Column("identifier")]
    public string? Identifier { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("RestaurantTableCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("FloorId")]
    //[InverseProperty("RestaurantTables")]
    [NotMapped]
    public virtual RestaurantFloor? Floor { get; set; }

    //[InverseProperty("Parent")]
    [NotMapped]
    public virtual ICollection<RestaurantTable> InverseParent { get; set; } = new List<RestaurantTable>();

    [ForeignKey("ParentId")]
    //[InverseProperty("InverseParent")]
    [NotMapped]
    public virtual RestaurantTable? Parent { get; set; }

    //[InverseProperty("Table")]
    [NotMapped]
    public virtual ICollection<PosOrder> PosOrders { get; set; } = new List<PosOrder>();

    [ForeignKey("LastModifierId")]
    //[InverseProperty("RestaurantTableWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
