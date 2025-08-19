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
//[Index("State", Name = "lunch_order__state_index")]
//[Index("SupplierId", Name = "lunch_order__supplier_id_index")]
//[Index("UserId", "ProductId", "Date", Name = "lunch_order_user_product_date")]
public partial class LunchOrder: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

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

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("date")]
    public DateTime? Date { get; set; }

    [JsonField]
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
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("quantity")]
    public double? Quantity { get; set; }

    // [Many2one]
    [ForeignKey("CategoryId")]
    // [InverseProperty("LunchOrder")] //Many2one
    public virtual LunchProductCategory? Category { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("LunchOrder")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("LunchOrderCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("CurrencyId")]
    // [InverseProperty("LunchOrder")] //Many2one
    public virtual ResCurrency? Currency { get; set; }

    // [Many2one]
    [ForeignKey("LunchLocationId")]
    // [InverseProperty("LunchOrder")] //Many2one
    public virtual LunchLocation? LunchLocation { get; set; }

    // [Many2one]
    [ForeignKey("ProductId")]
    // [InverseProperty("LunchOrder")] //Many2one
    public virtual LunchProduct? Product { get; set; }

    // [Many2one]
    [ForeignKey("SupplierId")]
    // [InverseProperty("LunchOrder")] //Many2one
    public virtual LunchSupplier? Supplier { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    // [InverseProperty("LunchOrderUser")] //Many2one
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("LunchOrderWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("OrderId")] //Many2many
    // [InverseProperty("Order")] //Many2many
    public virtual ICollection<LunchTopping> Topping { get; set; }
}
