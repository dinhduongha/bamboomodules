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

public partial class MrpProduction
{
    [Column("production_group_id")]
    public Guid? ProductionGroupId { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ProductionId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Production")] // One2many
    public virtual ICollection<MrpProductionSerials> MrpProductionSerials { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProductionGroupId")]
    public virtual MrpProductionGroup? ProductionGroup { get; set; }

    // [Many2many] // Hidden
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] //Many2many // Hidden
    // // [ForeignKey("MrpProductionId")] //Many2many // Hidden
    // // [InverseProperty("MrpProduction")] //Many2many // Hidden
    // public virtual ICollection<ExpiryPickingConfirmation> ExpiryPickingConfirmation { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("ProductionId")] // Many2many // Normal
    // [InverseProperty("Production")] // Many2many // Normal
    public virtual ICollection<AccountMove> Move { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("ProductionId")] // Many2many // Normal
    // [InverseProperty("Production")] // Many2many // Normal
    public virtual ICollection<StockReference> Reference { get; set; }


    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("MrpProductionId")] // Many2many // Normal
    // [InverseProperty("MrpProduction")] // Many2many // Normal
    public virtual ICollection<StockLot> StockLot { get; set; }


}