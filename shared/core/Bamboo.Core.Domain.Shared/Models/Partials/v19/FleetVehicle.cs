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

public partial class FleetVehicle
{
    [Column("co2_emission_unit")]
    public string? Co2EmissionUnit { get; set; }

    [Column("range_unit")]
    public string? RangeUnit { get; set; }

    [Column("contract_date_start")]
    public DateTime? ContractDateStart { get; set; }

}