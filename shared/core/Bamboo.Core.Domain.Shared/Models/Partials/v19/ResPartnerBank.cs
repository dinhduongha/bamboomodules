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

public partial class ResPartnerBank
{
    [Column("clearing_number")]
    public string? ClearingNumber { get; set; }

    [Column("note")]
    public string? Note { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("BankAccountId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("BankAccount")] // One2many
    public virtual ICollection<HrBankAccountAllocationWizardLine> HrBankAccountAllocationWizardLine { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("BankAccountId")] //Many2many // Hidden
    // [InverseProperty("BankAccount")] //Many2many // Hidden
    public virtual ICollection<HrEmployee> Employee { get; set; }

}