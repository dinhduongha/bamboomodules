using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace Bamboo.Core.Models;

public partial class ProductProduct
{
    [Column("volume_m3")]
    public decimal? VolumeM3 { get; set; }

    [Column("weight_kg")]
    public decimal? WeightKg { get; set; }

    [Column("is_deliverable")]
    public bool? IsDeliverable { get; set; } = true;

}