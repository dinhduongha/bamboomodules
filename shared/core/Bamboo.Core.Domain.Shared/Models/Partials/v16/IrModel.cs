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

//[Table("ir_model")]
//[Index("Model", Name = "ir_model_obj_name_uniq", IsUnique = true)]
public partial class IrModel
{
    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CallbackModelId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("CallbackModel")] // One2many
    public virtual ICollection<PaymentTransaction> PaymentTransaction { get; set; }
}
