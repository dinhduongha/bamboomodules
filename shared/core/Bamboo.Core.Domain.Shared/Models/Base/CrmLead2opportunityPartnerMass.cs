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

[Table("crm_lead2opportunity_partner_mass")]
public partial class CrmLead2opportunityPartnerMass: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("lead_id")]
    public Guid? LeadId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("team_id")]
    public Guid? TeamId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("action")]
    public string? Action { get; set; }

    [Column("force_assignment")]
    public bool? ForceAssignment { get; set; }

    [Column("deduplicate")]
    public bool? Deduplicate { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("CrmLead2opportunityPartnerMassCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LeadId")]
    //[InverseProperty("CrmLead2opportunityPartnerMassesNavigation")]
    [NotMapped]
    public virtual CrmLead? Lead { get; set; }

    [ForeignKey("PartnerId")]
    //[InverseProperty("CrmLead2opportunityPartnerMasses")]
    [NotMapped]
    public virtual ResPartner? Partner { get; set; }

    [ForeignKey("TeamId")]
    //[InverseProperty("CrmLead2opportunityPartnerMasses")]
    [NotMapped]
    public virtual CrmTeam? Team { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("CrmLead2opportunityPartnerMassUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("CrmLead2opportunityPartnerMassWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[ForeignKey("CrmLead2opportunityPartnerMassId")]
    //[InverseProperty("CrmLead2opportunityPartnerMasses")]
    [NotMapped]
    public virtual ICollection<CrmLead> CrmLeads { get; } = new List<CrmLead>();

    //[ForeignKey("CrmLead2opportunityPartnerMassId")]
    //[InverseProperty("CrmLead2opportunityPartnerMasses1")]
    [NotMapped]
    public virtual ICollection<CrmLead> CrmLeadsNavigation { get; } = new List<CrmLead>();

    [ForeignKey("CrmLead2opportunityPartnerMassId")]
    //[InverseProperty("CrmLead2opportunityPartnerMasses")]
    [NotMapped]
    public virtual ICollection<ResUser> ResUsers { get; } = new List<ResUser>();
}
