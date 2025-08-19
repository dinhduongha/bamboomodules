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
public partial class MailingFilter: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("mailing_model_id")]
    public Guid? MailingModelId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("mailing_domain")]
    public string? MailingDomain { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("MailingFilterCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("MailingFilterId")]
    [InverseProperty("MailingFilter")]
    public virtual ICollection<MailingMailing> MailingMailing { get; set; }

    // [Many2one]
    [ForeignKey("MailingModelId")]
    // [InverseProperty("MailingFilter")] //Many2one
    public virtual IrModel? MailingModel { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("MailingFilterWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
