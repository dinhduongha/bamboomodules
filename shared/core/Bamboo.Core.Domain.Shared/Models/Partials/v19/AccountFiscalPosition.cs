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

public partial class AccountFiscalPosition
{
    [Column("is_domestic")]
    public bool? IsDomestic { get; set; }

    // // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // // [One2many] [ForeignKey("DefaultFiscalPositionId")]
    // // [NotMapped] // One2many // Normal
    // // [InverseProperty("DefaultFiscalPosition")] // One2many
    // public virtual ICollection<PosConfig> PosConfigNavigation { get; set; }

    // // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // // [One2many] [ForeignKey("FiscalPositionId")]
    // // [NotMapped] // One2many // Normal
    // // [InverseProperty("FiscalPosition")] // One2many
    // public virtual ICollection<PosOrder> PosOrder { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("FiscalPositionId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("FiscalPosition")] // One2many
    public virtual ICollection<PosPreset> PosPreset { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("AccountPurchaseReceiptFiscalPositionId")]
    [NotMapped] // One2many // Peer relationship (ResCompany) is commented out
    // [InverseProperty("AccountPurchaseReceiptFiscalPosition")] // One2many
    public virtual ICollection<ResCompany> ResCompanyAccountPurchaseReceiptFiscalPosition { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("DomesticFiscalPositionId")]
    [NotMapped] // One2many // Peer relationship (ResCompany) is commented out
    // [InverseProperty("DomesticFiscalPosition")] // One2many
    public virtual ICollection<ResCompany> ResCompanyDomesticFiscalPosition { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("AccountFiscalPositionId")] // Many2many // Normal
    // [InverseProperty("AccountFiscalPosition")] // Many2many // Normal
    public virtual ICollection<AccountTax> AccountTax { get; set; }


}