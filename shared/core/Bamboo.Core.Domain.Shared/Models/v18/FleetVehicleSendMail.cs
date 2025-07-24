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

[Table("fleet_vehicle_send_mail")]
public partial class FleetVehicleSendMail: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("template_id")]
    public Guid? TemplateId { get; set; }

    [Column("author_id")]
    public Guid? AuthorId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("lang")]
    public string? Lang { get; set; }

    [Column("subject")]
    public string? Subject { get; set; }

    [Column("body")]
    public string? Body { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [ForeignKey("AuthorId")]
    //[InverseProperty("FleetVehicleSendMails")]
    [NotMapped]
    public virtual ResPartner? Author { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("FleetVehicleSendMailCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("TemplateId")]
    //[InverseProperty("FleetVehicleSendMails")]
    [NotMapped]
    public virtual MailTemplate? Template { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("FleetVehicleSendMailWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("WizardId")]
    //[InverseProperty("Wizards")]
    [NotMapped]
    public virtual ICollection<IrAttachment> Attachments { get; set; } = new List<IrAttachment>();

    [ForeignKey("FleetVehicleSendMailId")]
    //[InverseProperty("FleetVehicleSendMails")]
    [NotMapped]
    public virtual ICollection<FleetVehicle> FleetVehicles { get; set; } = new List<FleetVehicle>();
}
