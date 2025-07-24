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

[Table("mailing_filter")]
//[Index("CreateUid", Name = "mailing_filter__create_uid_index")]
public partial class MailingFilter: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("mailing_model_id")]
    public Guid? MailingModelId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("mailing_domain")]
    public string? MailingDomain { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MailingFilterCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    //[InverseProperty("MailingFilter")]
    [NotMapped]
    public virtual ICollection<MailingMailing> MailingMailings { get; set; } = new List<MailingMailing>();

    [ForeignKey("MailingModelId")]
    //[InverseProperty("MailingFilters")]
    [NotMapped]
    public virtual IrModel? MailingModel { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MailingFilterWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
