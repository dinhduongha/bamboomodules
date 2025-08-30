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

//[Table("restaurant_floor")]
public partial class RestaurantFloor
{
    [Column("pos_config_id")]
    public Guid? PosConfigId { get; set; }

    // [Many2one]
    // [ForeignKey("PosConfigId")]
    // public virtual PosConfig? PosConfig { get; set; }

}
