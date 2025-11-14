using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("stock_location")]
//[Index("CompanyId", Name = "stock_location__company_id_index")]
//[Index("LocationId", Name = "stock_location__location_id_index")]
//[Index("ParentPath", Name = "stock_location__parent_path_index")]
//[Index("Usage", Name = "stock_location__usage_index")]
//[Index("Barcode", "CompanyId", Name = "stock_location_barcode_company_uniq", IsUnique = true)]
public partial class StockLocation
{
    [Column("return_location")]
    public bool? ReturnLocation { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LocationId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Location")] // One2many
    public virtual ICollection<RepairLine> RepairLineLocation { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LocationDestId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("LocationDest")] // One2many
    public virtual ICollection<RepairLine> RepairLineLocationDest { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LocationId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Location")] // One2many
    public virtual ICollection<RepairOrder> RepairOrder { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LocationId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Location")] // One2many
    public virtual ICollection<StockReturnPicking> StockReturnPickingLocation { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("OriginalLocationId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("OriginalLocation")] // One2many
    public virtual ICollection<StockReturnPicking> StockReturnPickingOriginalLocation { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ParentLocationId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("ParentLocation")] // One2many
    public virtual ICollection<StockReturnPicking> StockReturnPickingParentLocation { get; set; }
}
