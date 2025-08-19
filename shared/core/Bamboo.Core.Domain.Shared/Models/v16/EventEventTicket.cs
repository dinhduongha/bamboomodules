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
public partial class EventEventTicket: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("event_type_id")]
    public Guid? EventTypeId { get; set; }

    [Column("seats_max")]
    public long? SeatsMax { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("event_id")]
    public Guid? EventId { get; set; }

    [Column("color")]
    public string? Color { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [JsonField]
    [Column("description", TypeName = "jsonb")]
    public string? Description { get; set; }

    [Column("seats_limited")]
    public bool? SeatsLimited { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("start_sale_datetime", TypeName = "timestamp without time zone")]
    public DateTime? StartSaleDatetime { get; set; }

    [Column("end_sale_datetime", TypeName = "timestamp without time zone")]
    public DateTime? EndSaleDatetime { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("price")]
    public decimal? Price { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("EventEventTicketCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("EventId")]
    // [InverseProperty("EventEventTicket")] //Many2one
    public virtual EventEvent? Event { get; set; }

    // [One2many]
    [ForeignKey("EventTicketId")]
    [InverseProperty("EventTicket")]
    public virtual ICollection<EventEventConfigurator> EventEventConfigurator { get; set; }

    // [One2many]
    [ForeignKey("EventTicketId")]
    [InverseProperty("EventTicket")]
    public virtual ICollection<EventRegistration> EventRegistration { get; set; }

    // [Many2one]
    [ForeignKey("EventTypeId")]
    // [InverseProperty("EventEventTicket")] //Many2one
    public virtual EventType? EventType { get; set; }

    // [One2many]
    [ForeignKey("EventTicketId")]
    [InverseProperty("EventTicket")]
    public virtual ICollection<PosOrderLine> PosOrderLine { get; set; }

    // [Many2one]
    [ForeignKey("ProductId")]
    // [InverseProperty("EventEventTicket")] //Many2one
    public virtual ProductProduct? Product { get; set; }

    // [One2many]
    [ForeignKey("EventTicketId")]
    [InverseProperty("EventTicket")]
    public virtual ICollection<RegistrationEditorLine> RegistrationEditorLine { get; set; }

    // [One2many]
    [ForeignKey("EventTicketId")]
    [InverseProperty("EventTicket")]
    public virtual ICollection<SaleOrderLine> SaleOrderLine { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("EventEventTicketWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
