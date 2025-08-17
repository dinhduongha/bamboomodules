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

[Table("crm_lead_assignation")]
public partial class CrmLeadAssignation: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("forward_id")]
    public Guid? ForwardId { get; set; }

    [Column("lead_id")]
    public Guid? LeadId { get; set; }

    [Column("partner_assigned_id")]
    public Guid? PartnerAssignedId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("lead_location")]
    public string? LeadLocation { get; set; }

    [Column("partner_location")]
    public string? PartnerLocation { get; set; }

    [Column("lead_link")]
    public string? LeadLink { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("CrmLeadAssignationCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("ForwardId")]
    // [InverseProperty("CrmLeadAssignation")] //Many2one
    public virtual CrmLeadForwardToPartner? Forward { get; set; }

    // [Many2one]
    [ForeignKey("LeadId")]
    // [InverseProperty("CrmLeadAssignation")] //Many2one
    public virtual CrmLead? Lead { get; set; }

    // [Many2one]
    [ForeignKey("PartnerAssignedId")]
    // [InverseProperty("CrmLeadAssignation")] //Many2one
    public virtual ResPartner? PartnerAssigned { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("CrmLeadAssignationWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
