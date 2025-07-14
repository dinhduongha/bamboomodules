using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bamboo.Core.Models;

[Table("mail_push_device")]
//[Index("PartnerId", Name = "mail_push_device__partner_id_index")]
//[Index("Endpoint", Name = "mail_push_device_endpoint_unique", IsUnique = true)]
public partial class MailPushDevice: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("endpoint")]
    public string? Endpoint { get; set; }

    [Column("keys")]
    public string? Keys { get; set; }

    [Column("expiration_time", TypeName = "timestamp without time zone")]
    public DateTime? ExpirationTime { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MailPushDeviceCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    //[InverseProperty("MailPushDevice")]
    [NotMapped]
    public virtual ICollection<MailPush> MailPushes { get; set; } = new List<MailPush>();

    [ForeignKey("PartnerId")]
    //[InverseProperty("MailPushDevices")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MailPushDeviceWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
