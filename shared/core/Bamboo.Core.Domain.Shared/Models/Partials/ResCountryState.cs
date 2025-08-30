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

//[Table("res_country_state")]
//[Index("CountryId", "Code", Name = "res_country_state_name_code_uniq", IsUnique = true)]
public partial class ResCountryState
{

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResCountryStateId")] //Many2many // Hidden
    // [InverseProperty("ResCountryState")] //Many2many // Hidden
    public virtual ICollection<AccountFiscalPositionTemplate> AccountFiscalPositionTemplate { get; set; }
}
