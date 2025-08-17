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

[Table("ir_attachment")]
//[Index("StoreFname", Name = "ir_attachment__store_fname_index")]
//[Index("Checksum", Name = "ir_attachment_checksum_index")]
//[Index("ResModel", "ResId", Name = "ir_attachment_res_idx")]
public partial class IrAttachment: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("res_id")]
    public Guid? ResId { get; set; }

    [Column("file_size")]
    public long? FileSize { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("res_model")]
    public string? ResModel { get; set; }

    [Column("res_field")]
    public string? ResField { get; set; }

    [Column("type")]
    public string? Type { get; set; }

    [Column("url")]
    public string? Url { get; set; }

    [Column("access_token")]
    public string? AccessToken { get; set; }

    [Column("store_fname")]
    public string? StoreFname { get; set; }

    [Column("checksum")]
    public string? Checksum { get; set; }

    [Column("mimetype")]
    public string? Mimetype { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("index_content")]
    public string? IndexContent { get; set; }

    [Column("public")]
    public bool? Public { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("db_datas")]
    public byte[]? DbDatas { get; set; }

    [Column("original_id")]
    public Guid? OriginalId { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("theme_template_id")]
    public Guid? ThemeTemplateId { get; set; }

    [Column("key")]
    public string? Key { get; set; }

    [Column("product_downloadable")]
    public bool? ProductDownloadable { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<AccountAccount> AccountAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<AccountAccountTemplate> AccountAccountTemplate { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<AccountAnalyticAccount> AccountAnalyticAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<AccountAssetAsset> AccountAssetAsset { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<AccountAssetCategory> AccountAssetCategory { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("AttachmentId")]
    // [InverseProperty("Attachment")]
    // public virtual ICollection<AccountEdiDocument> AccountEdiDocument { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<AccountJournal> AccountJournal { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<AccountMove> AccountMove { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<AccountPayment> AccountPayment { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<AccountReconcileModel> AccountReconcileModel { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<BlogBlog> BlogBlog { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<BlogPost> BlogPost { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<CalendarEvent> CalendarEvent { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("IrAttachment")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("IrAttachmentCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<CrmLead> CrmLead { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<CrmTeam> CrmTeam { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<CrmTeamMember> CrmTeamMember { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<CrossoveredBudget> CrossoveredBudget { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("AttachmentId")]
    // [InverseProperty("Attachment")]
    // public virtual ICollection<DiscussVoiceMetadata> DiscussVoiceMetadata { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<EventBooth> EventBooth { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<EventEvent> EventEvent { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<EventRegistration> EventRegistration { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<EventSponsor> EventSponsor { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<EventTrack> EventTrack { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<FleetVehicle> FleetVehicle { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<FleetVehicleLogContract> FleetVehicleLogContract { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<FleetVehicleLogServices> FleetVehicleLogServices { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<ForumForum> ForumForum { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<ForumPost> ForumPost { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<ForumTag> ForumTag { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<GamificationBadge> GamificationBadge { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<GamificationChallenge> GamificationChallenge { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<HrApplicant> HrApplicant { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<HrCandidate> HrCandidate { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<HrContract> HrContract { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<HrDepartment> HrDepartment { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<HrEmployee> HrEmployee { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<HrExpense> HrExpense { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<HrExpenseSheet> HrExpenseSheet { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<HrJob> HrJob { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<HrLeave> HrLeave { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<HrLeaveAllocation> HrLeaveAllocation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("IconId")]
    // [InverseProperty("Icon")]
    // public virtual ICollection<HrLeaveType> HrLeaveType { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("OriginalId")]
    // [InverseProperty("Original")]
    // public virtual ICollection<IrAttachment> InverseOriginal { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("IrAttachmentId")]
    // [InverseProperty("IrAttachment")]
    // public virtual ICollection<ProductDocument> ProductDocument { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<LoyaltyCard> LoyaltyCard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<LunchSupplier> LunchSupplier { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<MailBlacklist> MailBlacklist { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<MailChannel> MailChannel { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<MailingContact> MailingContact { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<MailingMailing> MailingMailing { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<MaintenanceEquipment> MaintenanceEquipment { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<MaintenanceEquipmentCategory> MaintenanceEquipmentCategory { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<MaintenanceRequest> MaintenanceRequest { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<MrpBom> MrpBom { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("IrAttachmentId")]
    // [InverseProperty("IrAttachment")]
    // public virtual ICollection<MrpDocument> MrpDocument { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<MrpProduction> MrpProduction { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<MrpUnbuild> MrpUnbuild { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<NoteNote> NoteNote { get; set; }

    // [Many2one]
    [ForeignKey("OriginalId")]
    // [InverseProperty("InverseOriginal")] //Many2one
    public virtual IrAttachment? Original { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<PhoneBlacklist> PhoneBlacklist { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<PosSession> PosSession { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("IrAttachmentId")]
    // [InverseProperty("IrAttachment")]
    // public virtual ICollection<ProductDocument> ProductDocument { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<ProductProduct> ProductProduct { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<ProductTemplate> ProductTemplate { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<ProjectMilestone> ProjectMilestone { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<ProjectProject> ProjectProject { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("DisplayedImageId")]
    // [InverseProperty("DisplayedImage")]
    // public virtual ICollection<ProjectTask> ProjectTask { get; set; }
    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("DisplayedImageId")]
    // [InverseProperty("DisplayedImage")]
    // public virtual ICollection<ProjectTask> ProjectTaskDisplayedImage { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<ProjectTask> ProjectTaskMessageMainAttachment { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<ProjectUpdate> ProjectUpdate { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<PurchaseOrder> PurchaseOrder { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<PurchaseRequisition> PurchaseRequisition { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("IrAttachmentId")]
    // [InverseProperty("IrAttachment")]
    // public virtual ICollection<QuotationDocument> QuotationDocument { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<RepairOrder> RepairOrder { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<ResCompany> ResCompany { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<ResPartner> ResPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<ResPartnerBank> ResPartnerBank { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<SaleOrder> SaleOrder { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<SlideChannel> SlideChannel { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<SlideSlide> SlideSlide { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("AttachmentId")]
    // [InverseProperty("Attachment")]
    // public virtual ICollection<SnailmailLetter> SnailmailLetter { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<StockLandedCost> StockLandedCost { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<StockLot> StockLot { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<StockPicking> StockPicking { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<StockPickingBatch> StockPickingBatch { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<StockScrap> StockScrap { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<SurveySurvey> SurveySurvey { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'IrAttachment'
    // [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("MessageMainAttachment")]
    // public virtual ICollection<SurveyUserInput> SurveyUserInput { get; set; }

    // [Many2one]
    [ForeignKey("ThemeTemplateId")]
    // [InverseProperty("IrAttachment")] //Many2one
    public virtual ThemeIrAttachment? ThemeTemplate { get; set; }

    // [Many2one]
    [ForeignKey("WebsiteId")]
    // [InverseProperty("IrAttachment")] //Many2one
    public virtual Website? Website { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("IrAttachmentWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("IrAttachmentId")]
    // [InverseProperty("IrAttachment")]
    // public virtual ICollection<AccountBankStatement> AccountBankStatement { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("AttachmentId")]
    // [InverseProperty("Attachment")]
    // public virtual ICollection<MailActivity> Activity { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("IrAttachmentId")]
    // [InverseProperty("IrAttachment")]
    // public virtual ICollection<AccountBankStatementImport> AccountBankStatementImport { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("IrAttachmentId")]
    // [InverseProperty("IrAttachment")]
    // public virtual ICollection<ApplicantSendMail> ApplicantSendMail { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("IrAttachmentId")]
    // [InverseProperty("IrAttachment")]
    // public virtual ICollection<AccountTourUploadBill> AccountTourUploadBill { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("IrAttachmentId")]
    // [InverseProperty("IrAttachment")]
    // public virtual ICollection<CandidateSendMail> CandidateSendMail { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("AttachmentId")]
    // [InverseProperty("Attachment")]
    // public virtual ICollection<MailTemplate> EmailTemplate { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("AttachmentId")]
    // [InverseProperty("Attachment")]
    // public virtual ICollection<MailingMailing> MassMailing { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("AttachmentId")]
    // [InverseProperty("Attachment")]
    // public virtual ICollection<MailMessage> Message { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("IrAttachmentId")]
    // [InverseProperty("IrAttachment")]
    // public virtual ICollection<PosConfig> PosConfig { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("AttachmentId")]
    // [InverseProperty("Attachment")]
    // public virtual ICollection<MailScheduledMessage> ScheduledMessage { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("IrAttachmentId")]
    // [InverseProperty("IrAttachment")]
    // public virtual ICollection<SlideChannelInvite> SlideChannelInvite { get; set; }

    // v16-Compat - Removed
    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("AttachmentId")]
    // [InverseProperty("Attachment")]
    // public virtual ICollection<MailComposeMessage> Wizard { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("AttachmentId")]
    // [InverseProperty("Attachment")]
    // public virtual ICollection<FleetVehicleSendMail> Wizard { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("AttachmentId")]
    // [InverseProperty("Attachment")]
    // public virtual ICollection<SurveyInvite> Wizard1 { get; set; }

    // v16-Compat - Removed
    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("AttachmentId")]
    // [InverseProperty("Attachment")]
    // public virtual ICollection<SurveyInvite> WizardNavigation { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("AttachmentId")]
    // [InverseProperty("Attachment")]
    // public virtual ICollection<MailComposeMessage> WizardNavigation { get; set; }
}
