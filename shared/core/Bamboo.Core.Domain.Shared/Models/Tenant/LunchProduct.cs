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

[Table("lunch_product")]
public partial class LunchProduct: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("category_id")]
    public Guid? CategoryId { get; set; }

    [Column("supplier_id")]
    public Guid? SupplierId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("new_until")]
    public DateTime? NewUntil { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("description", TypeName = "jsonb")]
    public string? Description { get; set; }

    [Column("price")]
    public decimal? Price { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CategoryId")]
    //[InverseProperty("LunchProducts")]
    [NotMapped]
    public virtual LunchProductCategory? Category { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("LunchProducts")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("LunchProductCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("SupplierId")]
    //[InverseProperty("LunchProducts")]
    [NotMapped]
    public virtual LunchSupplier? Supplier { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("LunchProductWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Product")]
    [NotMapped]
    public virtual ICollection<LunchOrder> LunchOrders { get; } = new List<LunchOrder>();

    [ForeignKey("ProductId")]
    //[InverseProperty("Products")]
    [NotMapped]
    public virtual ICollection<ResUser> Users { get; } = new List<ResUser>();
}
