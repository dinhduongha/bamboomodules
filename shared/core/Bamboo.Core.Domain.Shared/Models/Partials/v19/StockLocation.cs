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

public partial class StockLocation
{
    [Column("valuation_account_id")]
    public Guid? ValuationAccountId { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LocationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Location")] // One2many
    public virtual ICollection<MaintenanceEquipment> MaintenanceEquipment { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LocationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Location")] // One2many
    public virtual ICollection<StockPackage> StockPackage { get; set; }


    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LocationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Location")] // One2many
    public virtual ICollection<StockPackageHistory> StockPackageHistoryLocation { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LocationDestId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("LocationDest")] // One2many
    public virtual ICollection<StockPackageHistory> StockPackageHistoryLocationDest { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LocationDestId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("LocationDest")] // One2many
    public virtual ICollection<StockPutInPack> StockPutInPack { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ValuationAccountId")]
    public virtual AccountAccount? ValuationAccount { get; set; }
}