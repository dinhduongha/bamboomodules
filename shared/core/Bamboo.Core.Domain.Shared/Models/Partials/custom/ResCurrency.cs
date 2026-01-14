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

public partial class ResCurrency
{
    [Column("stable_coin")]
    public bool? StableCoin { get; set; } = false;

    [Column("network")]
    public string? Network { get; set; }

    [Column("contract_address")]
    public string? ContractAddress { get; set; }

    [Column("currency_id")]
    public Guid? CurrencyId { get; set; }


}
