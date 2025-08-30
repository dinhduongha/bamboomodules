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

//[Table("mailing_trace")]
//[Index("MassMailingId", Name = "mailing_trace__mass_mailing_id_index")]
public partial class MailingTrace
{
    [Column("sms_sms_id")]
    public Guid? SmsSmsId { get; set; }

    [Column("sms_sms_id_int")]
    public Guid? SmsSmsIdInt { get; set; }

    // [Many2one]
    [ForeignKey("SmsSmsId")]
    public virtual SmsSms? SmsSms { get; set; }
}
