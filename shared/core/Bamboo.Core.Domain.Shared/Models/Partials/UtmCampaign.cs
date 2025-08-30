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

//[Table("utm_campaign")]
//[Index("Name", Name = "utm_campaign_unique_name", IsUnique = true)]
public partial class UtmCampaign
{
    [Column("ab_testing_total_pc")]
    public long? AbTestingTotalPc { get; set; }
}
