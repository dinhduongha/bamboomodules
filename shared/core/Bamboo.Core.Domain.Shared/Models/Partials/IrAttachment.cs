using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("ir_attachment")]
//[Index("Checksum", Name = "ir_attachment_checksum_index")]
//[Index("StoreFname", Name = "ir_attachment__store_fname_index")]
//[Index("ResModel", "ResId", Name = "ir_attachment_res_idx")]
public partial class IrAttachment
{

    [Column("product_downloadable")]
    public bool? ProductDownloadable { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many
    // public virtual ICollection<AccountAccount> AccountAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (AccountAccountTemplate) is commented out
    // public virtual ICollection<AccountAccountTemplate> AccountAccountTemplate { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (AccountAnalyticAccount) is commented out
    // public virtual ICollection<AccountAnalyticAccount> AccountAnalyticAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (AccountAssetAsset) is commented out
    // public virtual ICollection<AccountAssetAsset> AccountAssetAsset { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (AccountAssetCategory) is commented out
    // public virtual ICollection<AccountAssetCategory> AccountAssetCategory { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (AccountJournal) is commented out
    // public virtual ICollection<AccountJournal> AccountJournal { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (AccountPayment) is commented out
    // public virtual ICollection<AccountPayment> AccountPayment { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (AccountReconcileModel) is commented out
    // public virtual ICollection<AccountReconcileModel> AccountReconcileModel { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (BlogBlog) is commented out
    // public virtual ICollection<BlogBlog> BlogBlog { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (BlogPost) is commented out
    // public virtual ICollection<BlogPost> BlogPost { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (CalendarEvent) is commented out
    // public virtual ICollection<CalendarEvent> CalendarEvent { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (CrmLead) is commented out
    // public virtual ICollection<CrmLead> CrmLead { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (CrmTeam) is commented out
    // public virtual ICollection<CrmTeam> CrmTeam { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (CrmTeamMember) is commented out
    // public virtual ICollection<CrmTeamMember> CrmTeamMember { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (CrossoveredBudget) is commented out
    // public virtual ICollection<CrossoveredBudget> CrossoveredBudget { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (EventBooth) is commented out
    // public virtual ICollection<EventBooth> EventBooth { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (EventEvent) is commented out
    // public virtual ICollection<EventEvent> EventEvent { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (EventRegistration) is commented out
    // public virtual ICollection<EventRegistration> EventRegistration { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (EventSponsor) is commented out
    // public virtual ICollection<EventSponsor> EventSponsor { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (EventTrack) is commented out
    // public virtual ICollection<EventTrack> EventTrack { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (FleetVehicle) is commented out
    // public virtual ICollection<FleetVehicle> FleetVehicle { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (FleetVehicleLogContract) is commented out
    // public virtual ICollection<FleetVehicleLogContract> FleetVehicleLogContract { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (FleetVehicleLogServices) is commented out
    // public virtual ICollection<FleetVehicleLogServices> FleetVehicleLogServices { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (ForumForum) is commented out
    // public virtual ICollection<ForumForum> ForumForum { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (ForumPost) is commented out
    // public virtual ICollection<ForumPost> ForumPost { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (ForumTag) is commented out
    // public virtual ICollection<ForumTag> ForumTag { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (GamificationBadge) is commented out
    // public virtual ICollection<GamificationBadge> GamificationBadge { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (GamificationChallenge) is commented out
    // public virtual ICollection<GamificationChallenge> GamificationChallenge { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (HrContract) is commented out
    // public virtual ICollection<HrContract> HrContract { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (HrDepartment) is commented out
    // public virtual ICollection<HrDepartment> HrDepartment { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (HrJob) is commented out
    // public virtual ICollection<HrJob> HrJob { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (HrLeaveAllocation) is commented out
    // public virtual ICollection<HrLeaveAllocation> HrLeaveAllocation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (LoyaltyCard) is commented out
    // public virtual ICollection<LoyaltyCard> LoyaltyCard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (LunchSupplier) is commented out
    // public virtual ICollection<LunchSupplier> LunchSupplier { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (MailBlacklist) is commented out
    // public virtual ICollection<MailBlacklist> MailBlacklist { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (MailChannel) is commented out
    // public virtual ICollection<MailChannel> MailChannel { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (MailingContact) is commented out
    // public virtual ICollection<MailingContact> MailingContact { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (MailingMailing) is commented out
    // public virtual ICollection<MailingMailing> MailingMailing { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (MaintenanceEquipment) is commented out
    // public virtual ICollection<MaintenanceEquipment> MaintenanceEquipment { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (MaintenanceEquipmentCategory) is commented out
    // public virtual ICollection<MaintenanceEquipmentCategory> MaintenanceEquipmentCategory { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (MaintenanceRequest) is commented out
    // public virtual ICollection<MaintenanceRequest> MaintenanceRequest { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (MrpBom) is commented out
    // public virtual ICollection<MrpBom> MrpBom { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("IrAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("IrAttachment")] // One2many // Peer relationship (MrpDocument) is commented out
    // public virtual ICollection<MrpDocument> MrpDocument { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (MrpProduction) is commented out
    // public virtual ICollection<MrpProduction> MrpProduction { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (MrpUnbuild) is commented out
    // public virtual ICollection<MrpUnbuild> MrpUnbuild { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (NoteNote) is commented out
    // public virtual ICollection<NoteNote> NoteNote { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (PhoneBlacklist) is commented out
    // public virtual ICollection<PhoneBlacklist> PhoneBlacklist { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (PosSession) is commented out
    // public virtual ICollection<PosSession> PosSession { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many
    // public virtual ICollection<ProductProduct> ProductProduct { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (ProductTemplate) is commented out
    // public virtual ICollection<ProductTemplate> ProductTemplate { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (ProjectMilestone) is commented out
    // public virtual ICollection<ProjectMilestone> ProjectMilestone { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (ProjectProject) is commented out
    // public virtual ICollection<ProjectProject> ProjectProject { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("DisplayedImageId")]
    // [NotMapped] // One2many 
    // [InverseProperty("DisplayedImage")] // One2many // Peer relationship (ProjectTask) is commented out
    // public virtual ICollection<ProjectTask> ProjectTaskDisplayedImage { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (ProjectTask) is commented out
    // public virtual ICollection<ProjectTask> ProjectTaskMessageMainAttachment { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (ProjectUpdate) is commented out
    // public virtual ICollection<ProjectUpdate> ProjectUpdate { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (PurchaseOrder) is commented out
    // public virtual ICollection<PurchaseOrder> PurchaseOrder { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (PurchaseRequisition) is commented out
    // public virtual ICollection<PurchaseRequisition> PurchaseRequisition { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (RepairOrder) is commented out
    // public virtual ICollection<RepairOrder> RepairOrder { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many
    // public virtual ICollection<ResCompany> ResCompany { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many
    // public virtual ICollection<ResPartner> ResPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (ResPartnerBank) is commented out
    // public virtual ICollection<ResPartnerBank> ResPartnerBank { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (SaleOrder) is commented out
    // public virtual ICollection<SaleOrder> SaleOrder { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (SlideChannel) is commented out
    // public virtual ICollection<SlideChannel> SlideChannel { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (SlideSlide) is commented out
    // public virtual ICollection<SlideSlide> SlideSlide { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (StockLandedCost) is commented out
    // public virtual ICollection<StockLandedCost> StockLandedCost { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (StockLot) is commented out
    // public virtual ICollection<StockLot> StockLot { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (StockPicking) is commented out
    // public virtual ICollection<StockPicking> StockPicking { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (StockPickingBatch) is commented out
    // public virtual ICollection<StockPickingBatch> StockPickingBatch { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (StockScrap) is commented out
    // public virtual ICollection<StockScrap> StockScrap { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (SurveySurvey) is commented out
    // public virtual ICollection<SurveySurvey> SurveySurvey { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [One2many] [ForeignKey("MessageMainAttachmentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("MessageMainAttachment")] // One2many // Peer relationship (SurveyUserInput) is commented out
    // public virtual ICollection<SurveyUserInput> SurveyUserInput { get; set; }



    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("IrAttachmentId")] //Many2many // Hidden
    // [InverseProperty("IrAttachment")] //Many2many // Hidden
    public virtual ICollection<AccountBankStatementImport> AccountBankStatementImport { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("IrAttachmentId")] //Many2many // Hidden
    // [InverseProperty("IrAttachment")] //Many2many // Hidden
    public virtual ICollection<AccountTourUploadBill> AccountTourUploadBill { get; set; }

    // [Many2many] // Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("AttachmentId")] //Many2many // Hidden
    // [InverseProperty("Attachment")] //Many2many // Hidden
    // public virtual ICollection<MailComposeMessage> Wizard { get; set; }

    // [Many2many] // Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("AttachmentId")] //Many2many // Hidden
    // [InverseProperty("Attachment")] //Many2many // Hidden
    // public virtual ICollection<SurveyInvite> WizardNavigation { get; set; }
}
