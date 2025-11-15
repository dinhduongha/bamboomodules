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

public partial class IrModel
{

    [Column("fold_name")]
    public string? FoldName { get; set; }

    [Column("abstract")]
    public bool? Abstract { get; set; }

    // [JsonField(IsSparse = false)] // WebsiteFormLabel
    // [Column("website_form_label", TypeName = "jsonb")]
    // public StringDictionary? WebsiteFormLabel { get; set; }

}