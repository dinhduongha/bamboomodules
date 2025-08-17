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

[Table("mail_push_device")]
//[Index("PartnerId", Name = "mail_push_device__partner_id_index")]
//[Index("Endpoint", Name = "mail_push_device_endpoint_unique", IsUnique = true)]
public partial class MailPushDevice: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("endpoint")]
    public string? Endpoint { get; set; }

    [Column("keys")]
    public string? Keys { get; set; }

    [Column("expiration_time", TypeName = "timestamp without time zone")]
    public DateTime? ExpirationTime { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("MailPushDeviceCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("MailPushDeviceId")]
    [InverseProperty("MailPushDevice")]
    public virtual ICollection<MailPush> MailPush { get; set; }

    // [Many2one]
    [ForeignKey("PartnerId")]
    // [InverseProperty("MailPushDevice")] //Many2one
    public virtual ResPartner? Partner { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("MailPushDeviceWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
