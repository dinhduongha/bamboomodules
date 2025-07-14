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

[Table("event_event_ticket")]
public partial class EventEventTicket: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
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

    [Column("event_id")]
    public Guid? EventId { get; set; }

    [Column("color")]
    public string? Color { get; set; }

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

    [Column("start_sale_datetime", TypeName = "timestamp without time zone")]
    public DateTime? StartSaleDatetime { get; set; }

    [Column("end_sale_datetime", TypeName = "timestamp without time zone")]
    public DateTime? EndSaleDatetime { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("price")]
    public decimal? Price { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("EventEventTicketCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("EventId")]
    //[InverseProperty("EventEventTickets")]
    [NotMapped]
    public virtual EventEvent? Event { get; set; }

    //[InverseProperty("EventTicket")]
    [NotMapped]
    public virtual ICollection<EventEventConfigurator> EventEventConfigurators { get; set; } = new List<EventEventConfigurator>();

    //[InverseProperty("EventTicket")]
    [NotMapped]
    public virtual ICollection<EventRegistration> EventRegistrations { get; set; } = new List<EventRegistration>();

    [ForeignKey("EventTypeId")]
    //[InverseProperty("EventEventTickets")]
    [NotMapped]
    public virtual EventType? EventType { get; set; }

    //[InverseProperty("EventTicket")]
    [NotMapped]
    public virtual ICollection<PosOrderLine> PosOrderLines { get; set; } = new List<PosOrderLine>();

    [ForeignKey("ProductId")]
    //[InverseProperty("EventEventTickets")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    //[InverseProperty("EventTicket")]
    [NotMapped]
    public virtual ICollection<RegistrationEditorLine> RegistrationEditorLines { get; set; } = new List<RegistrationEditorLine>();

    //[InverseProperty("EventTicket")]
    [NotMapped]
    public virtual ICollection<SaleOrderLine> SaleOrderLines { get; set; } = new List<SaleOrderLine>();

    [ForeignKey("LastModifierId")]
    //[InverseProperty("EventEventTicketWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
