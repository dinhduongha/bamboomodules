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

//[Table("chatbot_script_step")]
public partial class ChatbotScriptStep
{
    // v16-Compat    
    // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ChatbotCurrentStepId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ChatbotCurrentStep")] // One2many
    // public virtual ICollection<MailChannel> MailChannel { get; set; }
}
