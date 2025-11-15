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

public partial class AccountMoveSendWizard
{
    [Column("template_id")]
    public Guid? TemplateId { get; set; }

    [Column("lang")]
    public string? Lang { get; set; }

    [Column("subject")]
    public string? Subject { get; set; }

    [Column("model")]
    public string? Model { get; set; }

    [Column("template_name")]
    public string? TemplateName { get; set; }

    [Column("body")]
    public string? Body { get; set; }

    [Column("res_ids")]
    public string? ResIds { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TemplateId")]
    public virtual MailTemplate? Template { get; set; }


}