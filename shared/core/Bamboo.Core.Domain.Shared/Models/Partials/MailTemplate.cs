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

//[Table("mail_template")]
//[Index("Model", Name = "mail_template__model_index")]
public partial class MailTemplate
{
    [Column("report_template")]
    public Guid? ReportTemplate { get; set; }

    [JsonField]
    [Column("report_name", TypeName = "jsonb")]
    public string? ReportName { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("TemplateId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Template")] // One2many
    public virtual ICollection<AccountInvoiceSend> AccountInvoiceSend { get; set; }

    // [Many2one]
    [ForeignKey("ReportTemplate")]
    public virtual IrActReportXml? ReportTemplateNavigation { get; set; }
}
