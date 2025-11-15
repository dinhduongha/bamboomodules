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

public partial class PurchaseRequisitionCreateAlternative
{
    // // [Many2many] // Normal
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Peer relationship (ResPartner) is commented out
    // // [ForeignKey("PurchaseRequisitionCreateAlternativeId")] // Many2many // Normal
    // // [InverseProperty("PurchaseRequisitionCreateAlternative")] // Many2many // Normal
    // public virtual ICollection<ResPartner> ResPartner { get; set; }
}