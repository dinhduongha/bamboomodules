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

public partial class ProductRibbon
{
    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("new_period")]
    public long? NewPeriod { get; set; }


    [Column("style")]
    public string? Style { get; set; }

    [Column("assign")]
    public string? Assign { get; set; }


}