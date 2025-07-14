using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bamboo.Core.Models;

[Table("event_event_configurator")]
public partial class EventEventConfigurator: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("event_id")]
    public Guid? EventId { get; set; }

    [Column("event_ticket_id")]
    public Guid? EventTicketId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("EventEventConfiguratorCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("EventId")]
    //[InverseProperty("EventEventConfigurators")]
    [NotMapped]
    public virtual EventEvent? Event { get; set; }

    [ForeignKey("EventTicketId")]
    //[InverseProperty("EventEventConfigurators")]
    [NotMapped]
    public virtual EventEventTicket? EventTicket { get; set; }

    [ForeignKey("ProductId")]
    //[InverseProperty("EventEventConfigurators")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("EventEventConfiguratorWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
