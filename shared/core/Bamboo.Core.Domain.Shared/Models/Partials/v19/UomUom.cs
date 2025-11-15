using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

public partial class UomUom
{
    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("relative_uom_id")]
    public Guid? RelativeUomId { get; set; }

    [Column("parent_path")]
    public string? ParentPath { get; set; }

    [Column("relative_factor")]
    public decimal? RelativeFactor { get; set; }

    [Column("package_type_id")]
    public Guid? PackageTypeId { get; set; }

    [Column("is_pos_groupable")]
    public bool? IsPosGroupable { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'UomUom'
    // [One2many] [ForeignKey("RelativeUomId")]
    // [NotMapped] // One2many 
    // [InverseProperty("RelativeUom")] // One2many
    // public virtual ICollection<UomUom> InverseRelativeUom { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'UomUom'
    // [One2many] [ForeignKey("ProductUomId")]
    // [NotMapped] // One2many 
    // [InverseProperty("ProductUom")] // One2many // Peer relationship (MrpWorkcenterCapacity) is commented out
    // public virtual ICollection<MrpWorkcenterCapacity> MrpWorkcenterCapacity { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PackageTypeId")]
    public virtual StockPackageType? PackageType { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'UomUom'
    // [One2many] [ForeignKey("ProductUomId")]
    // [NotMapped] // One2many 
    // [InverseProperty("ProductUom")] // One2many // Peer relationship (ProductSupplierinfo) is commented out
    // public virtual ICollection<ProductSupplierinfo> ProductSupplierinfo { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'UomUom'
    // [One2many] [ForeignKey("UomId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Uom")] // One2many // Peer relationship (ProductTemplate) is commented out
    // public virtual ICollection<ProductTemplate> ProductTemplate { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'UomUom'
    // [One2many] [ForeignKey("UomId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Uom")] // One2many // Peer relationship (ProductUom) is commented out
    // public virtual ICollection<ProductUom> ProductUom { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("RelativeUomId")]
    public virtual UomUom? RelativeUom { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'UomUom'
    // [One2many] [ForeignKey("ProductUomId")]
    // [NotMapped] // One2many 
    // [InverseProperty("ProductUom")] // One2many // Peer relationship (StockMoveLine) is commented out
    // public virtual ICollection<StockMoveLine> StockMoveLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'UomUom'
    // [One2many] [ForeignKey("PackagingUomId")]
    // [NotMapped] // One2many 
    // [InverseProperty("PackagingUom")] // One2many // Peer relationship (StockMove) is commented out
    // public virtual ICollection<StockMove> StockMovePackagingUom { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'UomUom'
    // [One2many] [ForeignKey("ProductUom")]
    // [NotMapped] // One2many 
    // [InverseProperty("ProductUomNavigation")] // One2many // Peer relationship (StockMove) is commented out
    // public virtual ICollection<StockMove> StockMoveProductUomNavigation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'UomUom'
    // [One2many] [ForeignKey("ProductUomId")]
    // [NotMapped] // One2many 
    // [InverseProperty("ProductUom")] // One2many // Peer relationship (StockScrap) is commented out
    // public virtual ICollection<StockScrap> StockScrap { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'UomUom'
    // [One2many] [ForeignKey("ReplenishmentUomId")]
    // [NotMapped] // One2many 
    // [InverseProperty("ReplenishmentUom")] // One2many // Peer relationship (StockWarehouseOrderpoint) is commented out
    // public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpoint { get; set; }


    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("UomUomId")] //Many2many // Hidden
    // [InverseProperty("UomUom")] //Many2many // Hidden
    public virtual ICollection<ProductTemplate> ProductTemplateNavigation { get; set; }

}