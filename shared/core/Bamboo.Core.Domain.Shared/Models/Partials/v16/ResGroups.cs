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

//[Table("res_groups")]
//[Index("CategoryId", Name = "res_groups__category_id_index")]
//[Index("CategoryId", "Name", Name = "res_groups_name_uniq", IsUnique = true)]
public partial class ResGroups
{
    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("GroupPublicId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("GroupPublic")] // One2many
    public virtual ICollection<MailChannel> MailChannel { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResGroupsId")] //Many2many // Hidden
    // [InverseProperty("ResGroups")] //Many2many // Hidden
    public virtual ICollection<MailChannel> MailChannelNavigation { get; set; }
}
