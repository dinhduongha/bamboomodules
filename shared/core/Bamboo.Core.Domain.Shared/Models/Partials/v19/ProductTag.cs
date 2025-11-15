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

public partial class ProductTag
{
    [Column("visible_to_customers")]
    public bool? VisibleToCustomers { get; set; }

    [JsonField(IsSparse = false)] // PosDescription
    [Column("pos_description", TypeName = "jsonb")]
    public StringDictionary? PosDescription { get; set; }


}