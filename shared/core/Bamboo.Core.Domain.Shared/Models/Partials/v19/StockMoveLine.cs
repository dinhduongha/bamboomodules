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

public partial class StockMoveLine
{
    [Column("package_history_id")]
    public Guid? PackageHistoryId { get; set; }

    [Column("is_entire_pack")]
    public bool? IsEntirePack { get; set; }

    [Column("removal_date", TypeName = "timestamp without time zone")]
    public DateTime? RemovalDate { get; set; }

    // // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("PackageId")]
    // public virtual StockPackage? Package { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PackageHistoryId")]
    public virtual StockPackageHistory? PackageHistory { get; set; }

    // // [Many2one]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [ForeignKey("ResultPackageId")]
    // public virtual StockPackage? ResultPackage { get; set; }


    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("StockMoveLineId")] //Many2many // Hidden
    // [InverseProperty("StockMoveLine")] //Many2many // Hidden
    public virtual ICollection<StockPackageDestination> StockPackageDestination { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("StockMoveLineId")] //Many2many // Hidden
    // [InverseProperty("StockMoveLine")] //Many2many // Hidden
    public virtual ICollection<StockPutInPack> StockPutInPack { get; set; }

}