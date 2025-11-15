using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

public partial class ResPartner
{
    [JsonField] // Properties
    [Column("properties", TypeName = "jsonb")]
    public JsonElement? Properties { get; set; }

    [Column("is_seo_optimized")]
    public bool? IsSeoOptimized { get; set; }

    [Column("suggest_days")]
    public long? SuggestDays { get; set; }

    [Column("suggest_percent")]
    public long? SuggestPercent { get; set; }

    [Column("suggest_based_on")]
    public string? SuggestBasedOn { get; set; }

    [Column("group_rfq")]
    public string? GroupRfq { get; set; }

    [Column("group_on")]
    public string? GroupOn { get; set; }

    // [JsonField] // PropertyDeliveryCarrierId
    // [Column("property_delivery_carrier_id", TypeName = "jsonb")]
    // public JsonElement? PropertyDeliveryCarrierId { get; set; }

    [Column("is_pickup_location")]
    public bool? IsPickupLocation { get; set; }

    [Column("l10n_latam_identification_type_id")]
    public Guid? L10nLatamIdentificationTypeId { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("MappedPartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MappedPartner")] // One2many // Peer relationship (AccountReconcileModel) is commented out
    // public virtual ICollection<AccountReconcileModel> AccountReconcileModel { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (AccountReconcileModelLine) is commented out
    // public virtual ICollection<AccountReconcileModelLine> AccountReconcileModelLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("CommercialPartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CommercialPartner")] // One2many // Peer relationship (CrmLead2opportunityPartner) is commented out
    // public virtual ICollection<CrmLead2opportunityPartner> CrmLead2opportunityPartnerCommercialPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("CommercialPartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CommercialPartner")] // One2many // Peer relationship (CrmLead2opportunityPartnerMass) is commented out
    // public virtual ICollection<CrmLead2opportunityPartnerMass> CrmLead2opportunityPartnerMassCommercialPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (CrmLead2opportunityPartnerMass) is commented out
    // public virtual ICollection<CrmLead2opportunityPartnerMass> CrmLead2opportunityPartnerMassPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (CrmLead2opportunityPartner) is commented out
    // public virtual ICollection<CrmLead2opportunityPartner> CrmLead2opportunityPartnerPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (DiscussChannelRtcSession) is commented out
    // public virtual ICollection<DiscussChannelRtcSession> DiscussChannelRtcSession { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("DriverId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Driver")] // One2many // Peer relationship (FleetVehicleOdometer) is commented out
    // public virtual ICollection<FleetVehicleOdometer> FleetVehicleOdometer { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (HrApplicant) is commented out
    // public virtual ICollection<HrApplicant> HrApplicant { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("WorkContactId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WorkContact")] // One2many // Peer relationship (HrEmployee) is commented out
    // public virtual ICollection<HrEmployee> HrEmployee { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("AddressId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Address")] // One2many // Peer relationship (HrVersion) is commented out
    // public virtual ICollection<HrVersion> HrVersion { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (ImLivechatChannelMemberHistory) is commented out
    // public virtual ICollection<ImLivechatChannelMemberHistory> ImLivechatChannelMemberHistory { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("L10nLatamIdentificationTypeId")]
    public virtual L10nLatamIdentificationType? L10nLatamIdentificationType { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (ProjectTemplateCreateWizard) is commented out
    // public virtual ICollection<ProjectTemplateCreateWizard> ProjectTemplateCreateWizard { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")] //Many2many // Hidden
    // [InverseProperty("ResPartner")] //Many2many // Hidden
    public virtual ICollection<AccountReconcileModel> AccountReconcileModelNavigation { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")] //Many2many // Hidden
    // [InverseProperty("ResPartnerNavigation")] //Many2many // Hidden
    public virtual ICollection<DiscussChannel> DiscussChannel1 { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")] //Many2many // Hidden
    // [InverseProperty("ResPartner1")] //Many2many // Hidden
    public virtual ICollection<DiscussChannel> DiscussChannel2 { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")] //Many2many // Hidden
    // [InverseProperty("ResPartner")] //Many2many // Hidden
    public virtual ICollection<DiscussChannel> DiscussChannelNavigation { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")] //Many2many // Hidden
    // [InverseProperty("ResPartner")] //Many2many // Hidden
    public virtual ICollection<MailFollowersEdit> MailFollowersEdit { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")] //Many2many // Hidden
    // [InverseProperty("ResPartner")] //Many2many // Hidden
    public virtual ICollection<PurchaseRequisitionCreateAlternative> PurchaseRequisitionCreateAlternative { get; set; }


    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")] //Many2many // Hidden
    // [InverseProperty("ResPartner")] //Many2many // Hidden
    public virtual ICollection<TaskShareWizard> TaskShareWizard { get; set; }

}