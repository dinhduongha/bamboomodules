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

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

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
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [Column("phone")]
    public string? Phone { get; set; }

    [Column("mobile")]
    public string? Mobile { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("RegistrationEditorLineCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("EditorId")]
    // [InverseProperty("RegistrationEditorLine")] //Many2one
    public virtual RegistrationEditor? Editor { get; set; }

    // [Many2one]
    [ForeignKey("EventId")]
    // [InverseProperty("RegistrationEditorLine")] //Many2one
    public virtual EventEvent? Event { get; set; }

    // [Many2one]
    [ForeignKey("EventTicketId")]
    // [InverseProperty("RegistrationEditorLine")] //Many2one
    public virtual EventEventTicket? EventTicket { get; set; }

    // [Many2one]
    [ForeignKey("RegistrationId")]
    // [InverseProperty("RegistrationEditorLine")] //Many2one
    public virtual EventRegistration? Registration { get; set; }

    // [Many2one]
    [ForeignKey("SaleOrderLineId")]
    // [InverseProperty("RegistrationEditorLine")] //Many2one
    public virtual SaleOrderLine? SaleOrderLine { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("RegistrationEditorLineWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
