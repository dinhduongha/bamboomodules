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

//[Table("account_report")]
public partial class AccountReport
{
    [Column("chart_template_id")]
    public Guid? ChartTemplateId { get; set; }

    // [Column("filter_account_type")]
    // public bool? FilterAccountType { get; set; }

    // [Many2one]
    [ForeignKey("ChartTemplateId")]
    public virtual AccountChartTemplate? ChartTemplateObject { get; set; }

}
