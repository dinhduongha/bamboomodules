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

[Table("repair_fee")]
//[Index("TenantId", Name = "repair_fee_company_id_index")]
//[Index("Name", Name = "repair_fee_name_index")]
//[Index("RepairId", Name = "repair_fee_repair_id_index")]
public partial class RepairFee: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("repair_id")]
    public Guid? RepairId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("product_uom")]
    public Guid? ProductUom { get; set; }

    [Column("invoice_line_id")]
    public Guid? InvoiceLineId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("product_uom_qty")]
    public decimal? ProductUomQty { get; set; }

    [Column("price_unit")]
    public decimal? PriceUnit { get; set; }

    [Column("price_subtotal")]
    public decimal? PriceSubtotal { get; set; }

    [Column("price_total")]
    public decimal? PriceTotal { get; set; }

    [Column("invoiced")]
    public bool? Invoiced { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("RepairFees")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("RepairFeeCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("InvoiceLineId")]
    //[InverseProperty("RepairFees")]
    [NotMapped]
    public virtual AccountMoveLine? InvoiceLine { get; set; }

    [ForeignKey("ProductId")]
    //[InverseProperty("RepairFees")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    [ForeignKey("ProductUom")]
    //[InverseProperty("RepairFees")]
    [NotMapped]
    public virtual UomUom? ProductUomNavigation { get; set; }

    [ForeignKey("RepairId")]
    //[InverseProperty("RepairFees")]
    [NotMapped]
    public virtual RepairOrder? Repair { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("RepairFeeWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("RepairFeeLineId")]
    //[InverseProperty("RepairFeeLines")]
    [NotMapped]
    public virtual ICollection<AccountTax> Taxes { get; } = new List<AccountTax>();
}
