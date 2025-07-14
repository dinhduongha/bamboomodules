using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bamboo.Core.Models;

[Table("event_type_ticket")]
public partial class EventTypeTicket: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("event_type_id")]
    public Guid? EventTypeId { get; set; }

    [Column("seats_max")]
    public long? SeatsMax { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("description", TypeName = "jsonb")]
    public string? Description { get; set; }

    [Column("seats_limited")]
    public bool? SeatsLimited { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("price")]
    public decimal? Price { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("EventTypeTicketCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("EventTypeId")]
    //[InverseProperty("EventTypeTickets")]
    [NotMapped]
    public virtual EventType? EventType { get; set; }

    [ForeignKey("ProductId")]
    //[InverseProperty("EventTypeTickets")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("EventTypeTicketWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
