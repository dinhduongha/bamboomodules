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

//[Table("mail_activity_type")]
//[Index("CreateUid", Name = "mail_activity_type__create_uid_index")]
public partial class MailActivityType
{
    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SaleActivityTypeId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("SaleActivityType")] // One2many
    public virtual ICollection<AccountJournal> AccountJournal { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ActivityTypeId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("ActivityType")] // One2many
    public virtual ICollection<HrPlanActivityType> HrPlanActivityType { get; set; }
}
