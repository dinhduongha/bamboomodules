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

public partial class StockPackageType
{
    [Column("sequence_id")]
    public Guid? SequenceId { get; set; }

    [Column("package_use")]
    public string? PackageUse { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SequenceId")]
    public virtual IrSequence? SequenceNavigation { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PackageTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PackageType")] // One2many
    public virtual ICollection<StockPackage> StockPackage { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PackageTypeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PackageType")] // One2many
    public virtual ICollection<StockPutInPack> StockPutInPack { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PackageTypeId")]
    [NotMapped] // One2many // Peer relationship (UomUom) is commented out
    // [InverseProperty("PackageType")] // One2many
    public virtual ICollection<UomUom> UomUom { get; set; }


    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("StockPackageTypeId")] // Many2many // Normal
    // [InverseProperty("StockPackageType")] // Many2many // Normal
    public virtual ICollection<StockRoute> StockRoute { get; set; }


}