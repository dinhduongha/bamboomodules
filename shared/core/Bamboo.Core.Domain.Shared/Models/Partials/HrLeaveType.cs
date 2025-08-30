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

//[Table("hr_leave_type")]
public partial class HrLeaveType
{
    [Column("responsible_id")]
    public Guid? ResponsibleId { get; set; }

    [Column("color_name")]
    public string? ColorName { get; set; }

    // [Many2one]
    [ForeignKey("ResponsibleId")]
    public virtual ResUsers? Responsible { get; set; }
}
