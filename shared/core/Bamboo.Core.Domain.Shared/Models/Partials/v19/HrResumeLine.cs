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

public partial class HrResumeLine
{
    [Column("duration")]
    public long? Duration { get; set; }

    [Column("course_type")]
    public string? CourseType { get; set; }

    [Column("external_url")]
    public string? ExternalUrl { get; set; }

    [Column("certificate_filename")]
    public string? CertificateFilename { get; set; }

    [JsonField] // ResumeLineProperties
    [Column("resume_line_properties", TypeName = "jsonb")]
    public JsonElement? ResumeLineProperties { get; set; }

    [Column("event_id")]
    public Guid? EventId { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("EventId")]
    public virtual EventEvent? Event { get; set; }


}