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

[Table("product_label_layout")]
public partial class ProductLabelLayout : FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("custom_quantity")]
    public long? CustomQuantity { get; set; }

    [Column("pricelist_id")]
    public Guid? PricelistId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("print_format")]
    public string? PrintFormat { get; set; }

    [Column("extra_html")]
    public string? ExtraHtml { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("move_quantity")]
    public string? MoveQuantity { get; set; }

    // v16-Compat
    [Column("picking_quantity")]
    public string? PickingQuantity { get; set; }

    // v16-Compat
    [ForeignKey("TenantId")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ProductLabelLayoutCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("PricelistId")]
    //[InverseProperty("ProductLabelLayouts")]
    [NotMapped]
    public virtual ProductPricelist? Pricelist { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ProductLabelLayoutWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("ProductLabelLayoutId")]
    //[InverseProperty("ProductLabelLayouts")]
    [NotMapped]
    public virtual ICollection<ProductProduct> ProductProducts { get; set; } = new List<ProductProduct>();

    [ForeignKey("ProductLabelLayoutId")]
    //[InverseProperty("ProductLabelLayouts")]
    [NotMapped]
    public virtual ICollection<ProductTemplate> ProductTemplates { get; set; } = new List<ProductTemplate>();

    [ForeignKey("ProductLabelLayoutId")]
    //[InverseProperty("ProductLabelLayouts")]
    [NotMapped]
    public virtual ICollection<StockMoveLine> StockMoveLines { get; set; } = new List<StockMoveLine>();
}
