using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("event_type")]
public partial class EventType
{
    [Column("auto_confirm")]
    public bool? AutoConfirm { get; set; }

    [Column("menu_register_cta")]
    public bool? MenuRegisterCta { get; set; }
}
