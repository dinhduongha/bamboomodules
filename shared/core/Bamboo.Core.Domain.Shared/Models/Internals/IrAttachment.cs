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
public partial class IrAttachment: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("res_id")]
    public Guid? ResId { get; set; }

    [Column("file_size")]
    public long? FileSize { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

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

    //[InverseProperty("MessageMainAttachment")]
    // [NotMapped]
    // public virtual ICollection<AccountMove> AccountMoves { get; set; } = new List<AccountMove>();

    //[InverseProperty("MessageMainAttachment")]
    // [NotMapped]
    // public virtual ICollection<AccountPayment> AccountPayments { get; set; } = new List<AccountPayment>();

    [ForeignKey("TenantId")]
    //[InverseProperty("IrAttachments")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("IrAttachmentCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    //[InverseProperty("Attachment")]
    [NotMapped]
    public virtual ICollection<DiscussVoiceMetadatum> DiscussVoiceMetadata { get; set; } = new List<DiscussVoiceMetadatum>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<AccountAccountTemplate> AccountAccountTemplates { get; } = new List<AccountAccountTemplate>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<AccountAccount> AccountAccounts { get; } = new List<AccountAccount>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticAccount> AccountAnalyticAccounts { get; } = new List<AccountAnalyticAccount>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<AccountAssetAsset> AccountAssetAssets { get; } = new List<AccountAssetAsset>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<AccountAssetCategory> AccountAssetCategories { get; } = new List<AccountAssetCategory>();

    //[InverseProperty("Attachment")]
    [NotMapped]
    public virtual ICollection<AccountEdiDocument> AccountEdiDocuments { get; set; } = new List<AccountEdiDocument>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<AccountJournal> AccountJournals { get; set; } = new List<AccountJournal>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<AccountMove> AccountMoves { get; set; } = new List<AccountMove>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<AccountPayment> AccountPayments { get; set; } = new List<AccountPayment>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModel> AccountReconcileModels { get; set; } = new List<AccountReconcileModel>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<CalendarEvent> CalendarEvents { get; set; } = new List<CalendarEvent>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<CrmLead> CrmLeads { get; set; } = new List<CrmLead>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<CrmTeamMember> CrmTeamMembers { get; set; } = new List<CrmTeamMember>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<CrmTeam> CrmTeams { get; set; } = new List<CrmTeam>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<CrossoveredBudget> CrossoveredBudgets { get; set; } = new List<CrossoveredBudget>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<FleetVehicleLogContract> FleetVehicleLogContracts { get; set; } = new List<FleetVehicleLogContract>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<FleetVehicleLogService> FleetVehicleLogServices { get; set; } = new List<FleetVehicleLogService>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<FleetVehicle> FleetVehicles { get; set; } = new List<FleetVehicle>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<HrApplicant> HrApplicants { get; set; } = new List<HrApplicant>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<HrCandidate> HrCandidates { get; set; } = new List<HrCandidate>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<HrContract> HrContracts { get; set; } = new List<HrContract>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<HrDepartment> HrDepartments { get; set; } = new List<HrDepartment>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployees { get; set; } = new List<HrEmployee>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<HrExpenseSheet> HrExpenseSheets { get; set; } = new List<HrExpenseSheet>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<HrExpense> HrExpenses { get; set; } = new List<HrExpense>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<HrJob> HrJobs { get; set; } = new List<HrJob>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<HrLeaveAllocation> HrLeaveAllocations { get; set; } = new List<HrLeaveAllocation>();

    //[InverseProperty("Icon")]
    [NotMapped]
    public virtual ICollection<HrLeaveType> HrLeaveTypes { get; set; } = new List<HrLeaveType>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<HrLeave> HrLeaves { get; set; } = new List<HrLeave>();

    //[InverseProperty("Original")]
    [NotMapped]
    public virtual ICollection<IrAttachment> InverseOriginal { get; set; } = new List<IrAttachment>();

    [ForeignKey("OriginalId")]
    //[InverseProperty("InverseOriginal")]
    [NotMapped]
    public virtual IrAttachment? Original { get; set; }

    //[InverseProperty("Attachment")]
    [NotMapped]
    public virtual ICollection<SnailmailLetter> SnailmailLetters { get; set; } = new List<SnailmailLetter>();

    [ForeignKey("ThemeTemplateId")]
    //[InverseProperty("IrAttachments")]
    [NotMapped]
    public virtual ThemeIrAttachment? ThemeTemplate { get; set; }

    [ForeignKey("WebsiteId")]
    //[InverseProperty("IrAttachments")]
    [NotMapped]
    public virtual Website? Website { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("IrAttachmentWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("IrAttachmentId")]
    //[InverseProperty("IrAttachments")]
    [NotMapped]
    public virtual ICollection<AccountBankStatement> AccountBankStatements { get; set; } = new List<AccountBankStatement>();

    [ForeignKey("AttachmentId")]
    //[InverseProperty("Attachments")]
    [NotMapped]
    public virtual ICollection<MailTemplate> EmailTemplates { get; set; } = new List<MailTemplate>();

    [ForeignKey("AttachmentId")]
    //[InverseProperty("Attachments")]
    [NotMapped]
    public virtual ICollection<MailMessage> Messages { get; set; } = new List<MailMessage>();


    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<LunchSupplier> LunchSuppliers { get; set; } = new List<LunchSupplier>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<MailBlacklist> MailBlacklists { get; set; } = new List<MailBlacklist>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<MailChannel> MailChannels { get; set; } = new List<MailChannel>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<MaintenanceEquipmentCategory> MaintenanceEquipmentCategories { get; set; } = new List<MaintenanceEquipmentCategory>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<MaintenanceEquipment> MaintenanceEquipments { get; set; } = new List<MaintenanceEquipment>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<MaintenanceRequest> MaintenanceRequests { get; set; } = new List<MaintenanceRequest>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<MrpBom> MrpBoms { get; set; } = new List<MrpBom>();

    //[InverseProperty("IrAttachment")]
    [NotMapped]
    public virtual ICollection<MrpDocument> MrpDocuments { get; set; } = new List<MrpDocument>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<MrpProduction> MrpProductions { get; set; } = new List<MrpProduction>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<MrpUnbuild> MrpUnbuilds { get; set; } = new List<MrpUnbuild>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<NoteNote> NoteNotes { get; set; } = new List<NoteNote>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<PhoneBlacklist> PhoneBlacklists { get; set; } = new List<PhoneBlacklist>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<PosSession> PosSessions { get; set; } = new List<PosSession>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<ProductProduct> ProductProducts { get; set; } = new List<ProductProduct>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<ProductTemplate> ProductTemplates { get; set; } = new List<ProductTemplate>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<ProjectMilestone> ProjectMilestones { get; set; } = new List<ProjectMilestone>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<ProjectProject> ProjectProjects { get; set; } = new List<ProjectProject>();

    //[InverseProperty("DisplayedImage")]
    [NotMapped]
    public virtual ICollection<ProjectTask> ProjectTaskDisplayedImages { get; set; } = new List<ProjectTask>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<ProjectTask> ProjectTaskMessageMainAttachments { get; set; } = new List<ProjectTask>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<ProjectUpdate> ProjectUpdates { get; set; } = new List<ProjectUpdate>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<RepairOrder> RepairOrders { get; set; } = new List<RepairOrder>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanies { get; set; } = new List<ResCompany>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<ResPartnerBank> ResPartnerBanks { get; set; } = new List<ResPartnerBank>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<ResPartner> ResPartners { get; set; } = new List<ResPartner>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<SaleOrder> SaleOrders { get; set; } = new List<SaleOrder>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<StockLot> StockLots { get; set; } = new List<StockLot>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<StockPicking> StockPickings { get; set; } = new List<StockPicking>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<StockScrap> StockScraps { get; set; } = new List<StockScrap>();

    [ForeignKey("IrAttachmentId")]
    //[InverseProperty("IrAttachments")]
    [NotMapped]
    public virtual ICollection<AccountBankStatementImport> AccountBankStatementImports { get; set; } = new List<AccountBankStatementImport>();

    [ForeignKey("IrAttachmentId")]
    //[InverseProperty("IrAttachments")]
    [NotMapped]
    public virtual ICollection<AccountTourUploadBill> AccountTourUploadBills { get; set; } = new List<AccountTourUploadBill>();

    [ForeignKey("AttachmentId")]
    //[InverseProperty("Attachments")]
    [NotMapped]
    public virtual ICollection<FleetVehicleSendMail> Wizards { get; set; } = new List<FleetVehicleSendMail>();

    //[InverseProperty("IrAttachment")]
    [NotMapped]
    public virtual ICollection<ProductDocument> ProductDocuments { get; set; } = new List<ProductDocument>();

    //[InverseProperty("DisplayedImage")]
    [NotMapped]
    public virtual ICollection<ProjectTask> ProjectTasks { get; set; } = new List<ProjectTask>();

    //[InverseProperty("IrAttachment")]
    [NotMapped]
    public virtual ICollection<QuotationDocument> QuotationDocuments { get; set; } = new List<QuotationDocument>();

    [ForeignKey("AttachmentId")]
    //[InverseProperty("Attachments")]
    [NotMapped]
    public virtual ICollection<MailActivity> Activities { get; set; } = new List<MailActivity>();

    [ForeignKey("IrAttachmentId")]
    //[InverseProperty("IrAttachments")]
    [NotMapped]
    public virtual ICollection<ApplicantSendMail> ApplicantSendMails { get; set; } = new List<ApplicantSendMail>();

    [ForeignKey("IrAttachmentId")]
    //[InverseProperty("IrAttachments")]
    [NotMapped]
    public virtual ICollection<CandidateSendMail> CandidateSendMails { get; set; } = new List<CandidateSendMail>();

    [ForeignKey("AttachmentId")]
    //[InverseProperty("Attachments")]
    [NotMapped]
    public virtual ICollection<MailingMailing> MassMailings { get; set; } = new List<MailingMailing>();

    [ForeignKey("IrAttachmentId")]
    //[InverseProperty("IrAttachments")]
    [NotMapped]
    public virtual ICollection<PosConfig> PosConfigs { get; set; } = new List<PosConfig>();

    [ForeignKey("AttachmentId")]
    //[InverseProperty("Attachments")]
    [NotMapped]
    public virtual ICollection<MailScheduledMessage> ScheduledMessages { get; set; } = new List<MailScheduledMessage>();

    [ForeignKey("IrAttachmentId")]
    //[InverseProperty("IrAttachments")]
    [NotMapped]
    public virtual ICollection<SlideChannelInvite> SlideChannelInvites { get; set; } = new List<SlideChannelInvite>();

    [ForeignKey("AttachmentId")]
    //[InverseProperty("Attachments")]
    [NotMapped]
    public virtual ICollection<SurveyInvite> Wizards1 { get; set; } = new List<SurveyInvite>();

    [ForeignKey("AttachmentId")]
    //[InverseProperty("Attachments")]
    [NotMapped]
    public virtual ICollection<MailComposeMessage> WizardsNavigation { get; set; } = new List<MailComposeMessage>();
}
