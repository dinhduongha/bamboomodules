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

[Table("mailing_mailing_schedule_date")]
public partial class MailingMailingScheduleDate: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("mass_mailing_id")]
    public Guid? MassMailingId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("schedule_date", TypeName = "timestamp without time zone")]
    public DateTime? ScheduleDate { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MailingMailingScheduleDateCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("MassMailingId")]
    //[InverseProperty("MailingMailingScheduleDates")]
    [NotMapped]
    public virtual MailingMailing? MassMailing { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MailingMailingScheduleDateWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
