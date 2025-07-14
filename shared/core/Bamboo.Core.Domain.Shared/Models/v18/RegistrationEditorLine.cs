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

[Table("registration_editor_line")]
public partial class RegistrationEditorLine: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("editor_id")]
    public Guid? EditorId { get; set; }

    [Column("sale_order_line_id")]
    public Guid? SaleOrderLineId { get; set; }

    [Column("event_id")]
    public Guid? EventId { get; set; }

    [Column("registration_id")]
    public Guid? RegistrationId { get; set; }

    [Column("event_ticket_id")]
    public Guid? EventTicketId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [Column("phone")]
    public string? Phone { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("RegistrationEditorLineCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("EditorId")]
    //[InverseProperty("RegistrationEditorLines")]
    [NotMapped]
    public virtual RegistrationEditor? Editor { get; set; }

    [ForeignKey("EventId")]
    //[InverseProperty("RegistrationEditorLines")]
    [NotMapped]
    public virtual EventEvent? Event { get; set; }

    [ForeignKey("EventTicketId")]
    //[InverseProperty("RegistrationEditorLines")]
    [NotMapped]
    public virtual EventEventTicket? EventTicket { get; set; }

    [ForeignKey("RegistrationId")]
    //[InverseProperty("RegistrationEditorLines")]
    [NotMapped]
    public virtual EventRegistration? Registration { get; set; }

    [ForeignKey("SaleOrderLineId")]
    //[InverseProperty("RegistrationEditorLines")]
    [NotMapped]
    public virtual SaleOrderLine? SaleOrderLine { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("RegistrationEditorLineWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
