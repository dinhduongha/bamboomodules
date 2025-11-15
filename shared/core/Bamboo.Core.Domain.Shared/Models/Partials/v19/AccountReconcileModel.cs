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

public partial class AccountReconcileModel
{
    [Column("next_activity_type_id")]
    public Guid? NextActivityTypeId { get; set; }

    [Column("mapped_partner_id")]
    public Guid? MappedPartnerId { get; set; }

    [Column("trigger")]
    public string? Trigger { get; set; }

    [Column("can_be_proposed")]
    public bool? CanBeProposed { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("MappedPartnerId")]
    public virtual ResPartner? MappedPartner { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("NextActivityTypeId")]
    public virtual MailActivityType? NextActivityType { get; set; }

}