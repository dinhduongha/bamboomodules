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

public partial class ResCurrency
{
    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many // Peer relationship (AccountBankStatement) is commented out
    // public virtual ICollection<AccountBankStatement> AccountBankStatement { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("SourceCurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("SourceCurrency")] // One2many // Peer relationship (AccountPaymentRegisterWithholdingLine) is commented out
    // public virtual ICollection<AccountPaymentRegisterWithholdingLine> AccountPaymentRegisterWithholdingLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("SourceCurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("SourceCurrency")] // One2many // Peer relationship (AccountPaymentWithholdingLine) is commented out
    // public virtual ICollection<AccountPaymentWithholdingLine> AccountPaymentWithholdingLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCurrency'
    // [One2many] [ForeignKey("CurrencyId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Currency")] // One2many // Peer relationship (PosConfig) is commented out
    // public virtual ICollection<PosConfig> PosConfig { get; set; }

}