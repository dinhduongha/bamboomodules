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

public partial class ResBank
{
    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("BankId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Bank")] // One2many
    public virtual ICollection<L10nLatamCheck> L10nLatamCheck { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("BankId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Bank")] // One2many
    public virtual ICollection<L10nLatamPaymentRegisterCheck> L10nLatamPaymentRegisterCheck { get; set; }

}