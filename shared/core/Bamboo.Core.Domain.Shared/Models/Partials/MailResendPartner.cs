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

//[Table("mail_resend_partner")]
public partial class MailResendPartner
{
    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    public virtual ResPartner? Partner { get; set; }
}
