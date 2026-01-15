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

public partial class MrpWorkcenter
{
    [Column("status")]
    public long? Status { get; set; }

    [Column("categ_id")]
    public Guid? CategId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CategId")]
    public virtual MrpWorkcenterCategory? Categ { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] // Many2many // Normal
    // [ForeignKey("StockPickingTypeId")] // Many2many // Normal
    // [InverseProperty("StockPickingType")] // Many2many // Normal
    public virtual ICollection<MrpWorkcenterCategory> WorkcenterCategory { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("UserId")]
    public virtual ResUsers? User { get; set; }

}
