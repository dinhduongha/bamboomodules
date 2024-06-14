using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

[Table("mail_resend_partner")]
public partial class MailResendPartner: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("resend_wizard_id")]
    public Guid? ResendWizardId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("message")]
    public string? Message { get; set; }

    [Column("resend")]
    public bool? Resend { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MailResendPartnerCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("PartnerId")]
    //[InverseProperty("MailResendPartners")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }

    [ForeignKey("ResendWizardId")]
    //[InverseProperty("MailResendPartners")]
    [NotMapped]
    public virtual MailResendMessage? ResendWizard { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MailResendPartnerWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
