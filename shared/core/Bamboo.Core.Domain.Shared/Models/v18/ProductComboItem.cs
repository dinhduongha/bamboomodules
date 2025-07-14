using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bamboo.Core.Models;

[Table("product_combo_item")]
public partial class ProductComboItem: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("combo_id")]
    public Guid? ComboId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("extra_price")]
    public decimal? ExtraPrice { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("ComboId")]
    //[InverseProperty("ProductComboItems")]
    [NotMapped]
    public virtual ProductCombo? Combo { get; set; }

    [ForeignKey("CompanyId")]
    //[InverseProperty("ProductComboItems")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ProductComboItemCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    //[InverseProperty("ComboItem")]
    [NotMapped]
    public virtual ICollection<PosOrderLine> PosOrderLines { get; set; } = new List<PosOrderLine>();

    [ForeignKey("ProductId")]
    //[InverseProperty("ProductComboItems")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    //[InverseProperty("ComboItem")]
    [NotMapped]
    public virtual ICollection<SaleOrderLine> SaleOrderLines { get; set; } = new List<SaleOrderLine>();

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ProductComboItemWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
