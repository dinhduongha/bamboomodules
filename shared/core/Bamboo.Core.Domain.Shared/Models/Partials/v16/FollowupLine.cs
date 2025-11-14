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

//[Table("followup_line")]
//[Index("FollowupId", "Delay", Name = "followup_line_days_uniq", IsUnique = true)]
public partial class FollowupLine
{
    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LatestFollowupLevelIdWithoutLit")]
    [NotMapped] // One2many // Peer relationship (ResPartner) is commented out
    // [InverseProperty("LatestFollowupLevelIdWithoutLitNavigation")] // One2many
    public virtual ICollection<ResPartner> ResPartner { get; set; }
}
