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

public partial class ResCountryState
{
    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResCountryState'
    // [One2many] [ForeignKey("PrivateStateId")]
    // [NotMapped] // One2many 
    // [InverseProperty("PrivateState")] // One2many // Peer relationship (HrVersion) is commented out
    // public virtual ICollection<HrVersion> HrVersion { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResCountryStateId")] //Many2many // Hidden
    // [InverseProperty("ResCountryState")] //Many2many // Hidden
    public virtual ICollection<ResCountryGroup> ResCountryGroup { get; set; }


}