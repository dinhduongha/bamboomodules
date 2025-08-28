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

//[Table("mrp_workcenter")]
//[Index("CompanyId", Name = "mrp_workcenter__company_id_index")]
//[Index("ResourceCalendarId", Name = "mrp_workcenter__resource_calendar_id_index")]
//[Index("ResourceId", Name = "mrp_workcenter__resource_id_index")]
public partial class MrpWorkcenter
{
    [Column("costs_hour_account_id")]
    public Guid? CostsHourAccountId { get; set; }

    // [Many2one]
    [ForeignKey("CostsHourAccountId")]
    public virtual AccountAnalyticAccount? CostsHourAccount { get; set; }
}
