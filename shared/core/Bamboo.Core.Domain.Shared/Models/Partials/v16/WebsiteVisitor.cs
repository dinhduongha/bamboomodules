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

//[Table("website_visitor")]
//[Index("AccessToken", Name = "website_visitor_access_token_unique", IsUnique = true)]
public partial class WebsiteVisitor
{
    // v16-Compat 
    // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LivechatVisitorId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("LivechatVisitor")] // One2many
    // public virtual ICollection<MailChannel> MailChannel { get; set; }
}
