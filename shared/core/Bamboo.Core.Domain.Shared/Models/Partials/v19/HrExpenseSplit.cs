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

public partial class HrExpenseSplit
{
    [Column("manager_id")]
    public Guid? ManagerId { get; set; }

    [Column("approval_state")]
    public string? ApprovalState { get; set; }

    [Column("approval_date", TypeName = "timestamp without time zone")]
    public DateTime? ApprovalDate { get; set; }


    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ManagerId")]
    public virtual ResUsers? Manager { get; set; }


}