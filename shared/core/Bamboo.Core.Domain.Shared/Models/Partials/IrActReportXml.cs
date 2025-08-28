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

//[Table("ir_act_report_xml")]
public partial class IrActReportXml
{
    // v16-Compat
    // [One2many]
    // [One2many] [ForeignKey("ReportTemplate")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ReportTemplateNavigation")] // One2many
    // public virtual ICollection<MailTemplate> MailTemplate { get; set; }
}
