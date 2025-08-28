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

//[Table("ir_cron")]
public partial class IrCron
{

    [Column("numbercall")]
    public long? Numbercall { get; set; }

    // [JsonField]
    // [Column("cron_name", TypeName = "jsonb")]
    // public string? CronName { get; set; }

    [Column("doall")]
    public bool? Doall { get; set; }
}
