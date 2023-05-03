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

[Table("product_supplierinfo")]
//[Index("TenantId", Name = "product_supplierinfo_company_id_index")]
//[Index("ProductTmplId", Name = "product_supplierinfo_product_tmpl_id_index")]
public partial class ProductSupplierinfo: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("sequence")]
    public long Sequence { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("currency_id")]
    public long? CurrencyId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("product_tmpl_id")]
    public Guid? ProductTmplId { get; set; }

    [Column("delay")]
    public long? Delay { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("product_name")]
    public string? ProductName { get; set; }

    [Column("product_code")]
    public string? ProductCode { get; set; }

    [Column("date_start")]
    public DateTime? DateStart { get; set; }

    [Column("date_end")]
    public DateTime? DateEnd { get; set; }

    [Column("min_qty")]
    public decimal? MinQty { get; set; }

    [Column("price")]
    public decimal? Price { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("ProductSupplierinfos")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ProductSupplierinfoCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("CurrencyId")]
    //[InverseProperty("ProductSupplierinfos")]
    [NotMapped]
    public virtual ResCurrency? Currency { get; set; }

    [ForeignKey("PartnerId")]
    //[InverseProperty("ProductSupplierinfos")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }

    [ForeignKey("ProductId")]
    //[InverseProperty("ProductSupplierinfos")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    [ForeignKey("ProductTmplId")]
    //[InverseProperty("ProductSupplierinfos")]
    [NotMapped]
    public virtual ProductTemplate? ProductTmpl { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ProductSupplierinfoWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Supplier")]
    [NotMapped]
    public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpoints { get; } = new List<StockWarehouseOrderpoint>();

    [ForeignKey("ProductSupplierinfoId")]
    //[InverseProperty("ProductSupplierinfos")]
    [NotMapped]
    public virtual ICollection<StockReplenishmentInfo> StockReplenishmentInfos { get; } = new List<StockReplenishmentInfo>();
}
