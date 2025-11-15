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

public partial class ApplicantGetRefuseReason
{
    [Column("lang")]
    public string? Lang { get; set; }

    [Column("subject")]
    public string? Subject { get; set; }

    [Column("scheduled_date")]
    public string? ScheduledDate { get; set; }

    [Column("body")]
    public string? Body { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("ApplicantGetRefuseReasonId")] // Many2many // Normal
    // [InverseProperty("ApplicantGetRefuseReasonNavigation")] // Many2many // Normal
    public virtual ICollection<HrApplicant> HrApplicantNavigation { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] // Many2many // Peer relationship (IrAttachment) is commented out
    // [ForeignKey("ApplicantGetRefuseReasonId")] // Many2many // Normal
    // [InverseProperty("ApplicantGetRefuseReason")] // Many2many // Normal
    public virtual ICollection<IrAttachment> IrAttachment { get; set; }
}