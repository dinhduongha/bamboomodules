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

//[Table("mrp_workcenter_productivity")]
//[Index("CompanyId", Name = "mrp_workcenter_productivity__company_id_index")]
//[Index("WorkcenterId", Name = "mrp_workcenter_productivity__workcenter_id_index")]
//[Index("WorkorderId", Name = "mrp_workcenter_productivity__workorder_id_index")]
public partial class MrpWorkcenterProductivity
{
    [Column("cost_already_recorded")]
    public bool? CostAlreadyRecorded { get; set; }
}
