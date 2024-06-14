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

[Table("lunch_order")]
//[Index("State", Name = "lunch_order_state_index")]
//[Index("SupplierId", Name = "lunch_order_supplier_id_index")]
//[Index("UserId", "ProductId", "Date", Name = "lunch_order_user_product_date")]
public partial class LunchOrder: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("category_id")]
    public Guid? CategoryId { get; set; }

    [Column("supplier_id")]
    public Guid? SupplierId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("lunch_location_id")]
    public Guid? LunchLocationId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("currency_id")]
    public long? CurrencyId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("date")]
    public DateTime? Date { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("note")]
    public string? Note { get; set; }

    [Column("display_toppings")]
    public string? DisplayToppings { get; set; }

    [Column("price")]
    public decimal? Price { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("notified")]
    public bool? Notified { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("quantity")]
    public double? Quantity { get; set; }

    [ForeignKey("CategoryId")]
    //[InverseProperty("LunchOrders")]
    [NotMapped]
    public virtual LunchProductCategory? Category { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("LunchOrders")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("LunchOrderCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("CurrencyId")]
    //[InverseProperty("LunchOrders")]
    [NotMapped]
    public virtual ResCurrency? Currency { get; set; }

    [ForeignKey("LunchLocationId")]
    //[InverseProperty("LunchOrders")]
    [NotMapped]
    public virtual LunchLocation? LunchLocation { get; set; }

    [ForeignKey("ProductId")]
    //[InverseProperty("LunchOrders")]
    [NotMapped]
    public virtual LunchProduct? Product { get; set; }

    [ForeignKey("SupplierId")]
    //[InverseProperty("LunchOrders")]
    [NotMapped]
    public virtual LunchSupplier? Supplier { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("LunchOrderUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("LunchOrderWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("OrderId")]
    //[InverseProperty("Orders")]
    [NotMapped]
    public virtual ICollection<LunchTopping> Toppings { get; } = new List<LunchTopping>();
}
