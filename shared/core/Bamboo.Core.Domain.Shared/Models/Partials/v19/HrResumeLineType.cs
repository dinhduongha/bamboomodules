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

public partial class HrResumeLineType
{

    [JsonField] // ResumeLineTypePropertiesDefinition
    [Column("resume_line_type_properties_definition", TypeName = "jsonb")]
    public JsonElement? ResumeLineTypePropertiesDefinition { get; set; }

    [Column("is_course")]
    public bool? IsCourse { get; set; }

}