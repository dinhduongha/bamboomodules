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

public partial class ResLang
{
    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LivechatLangId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("LivechatLang")] // One2many
    public virtual ICollection<DiscussChannel> DiscussChannel { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LangId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Lang")] // One2many
    public virtual ICollection<ProductFeed> ProductFeed { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("LangId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Lang")] // One2many
    public virtual ICollection<SurveyUserInput> SurveyUserInput { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResLangId")] //Many2many // Hidden
    // [InverseProperty("ResLang")] //Many2many // Hidden
    public virtual ICollection<SurveySurvey> SurveySurvey { get; set; }

}