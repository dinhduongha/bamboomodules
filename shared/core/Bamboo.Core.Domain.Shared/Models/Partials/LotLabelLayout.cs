using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("lot_label_layout")]
public partial class LotLabelLayout
{

    // v16-Compat
    // [Many2many] // Normal
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("LotLabelLayoutId")] // Many2many // Normal
    // [InverseProperty("LotLabelLayout")] // Many2many // Normal
    // public virtual ICollection<StockPicking> StockPicking { get; set; }

}
