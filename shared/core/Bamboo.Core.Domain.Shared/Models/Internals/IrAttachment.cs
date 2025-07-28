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

[Module("base")]
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
    public DateTime CreationTime { get; set; }

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

    [ForeignKey("TenantId")]
    //[InverseProperty("IrAttachments")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("IrAttachmentCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("OriginalId")]
    //[InverseProperty("InverseOriginal")]
    [NotMapped]
    public virtual IrAttachment? Original { get; set; }

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


    //[InverseProperty("MessageMainAttachment")]
    // [NotMapped]
    // public virtual ICollection<AccountMove> AccountMoves { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    // [NotMapped]
    // public virtual ICollection<AccountPayment> AccountPayments { get; set; } 

    //[InverseProperty("Attachment")]
    //[NotMapped]
    //public virtual ICollection<DiscussVoiceMetadatum> DiscussVoiceMetadata { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<AccountAccountTemplate> AccountAccountTemplates { get; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<AccountAccount> AccountAccounts { get; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticAccount> AccountAnalyticAccounts { get; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<AccountAssetAsset> AccountAssetAssets { get; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<AccountAssetCategory> AccountAssetCategories { get; } 

    //[InverseProperty("Attachment")]
    [NotMapped]
    public virtual ICollection<AccountEdiDocument> AccountEdiDocuments { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<AccountJournal> AccountJournals { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<AccountMove> AccountMoves { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<AccountPayment> AccountPayments { get; set; } 

    //[InverseProperty("Attachment")]
    [NotMapped]
    public virtual ICollection<DiscussVoiceMetadatum> DiscussVoiceMetadata { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModel> AccountReconcileModels { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<CalendarEvent> CalendarEvents { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<CrmLead> CrmLeads { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<CrmTeamMember> CrmTeamMembers { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<CrmTeam> CrmTeams { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<CrossoveredBudget> CrossoveredBudgets { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<FleetVehicleLogContract> FleetVehicleLogContracts { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<FleetVehicleLogService> FleetVehicleLogServices { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<FleetVehicle> FleetVehicles { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<HrApplicant> HrApplicants { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<HrCandidate> HrCandidates { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<HrContract> HrContracts { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<HrDepartment> HrDepartments { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployees { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<HrExpenseSheet> HrExpenseSheets { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<HrExpense> HrExpenses { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<HrJob> HrJobs { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<HrLeaveAllocation> HrLeaveAllocations { get; set; } 

    //[InverseProperty("Icon")]
    [NotMapped]
    public virtual ICollection<HrLeaveType> HrLeaveTypes { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<HrLeave> HrLeaves { get; set; } 

    //[InverseProperty("Original")]
    [NotMapped]
    public virtual ICollection<IrAttachment> InverseOriginal { get; set; } 

    //[InverseProperty("Attachment")]
    [NotMapped]
    public virtual ICollection<SnailmailLetter> SnailmailLetters { get; set; } 

    [ForeignKey("IrAttachmentId")]
    //[InverseProperty("IrAttachments")]
    [NotMapped]
    public virtual ICollection<AccountBankStatement> AccountBankStatements { get; set; } 

    [ForeignKey("AttachmentId")]
    //[InverseProperty("Attachments")]
    [NotMapped]
    public virtual ICollection<MailTemplate> EmailTemplates { get; set; } 

    [ForeignKey("AttachmentId")]
    //[InverseProperty("Attachments")]
    [NotMapped]
    public virtual ICollection<MailMessage> Messages { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<LunchSupplier> LunchSuppliers { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<MailBlacklist> MailBlacklists { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<MailChannel> MailChannels { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<MaintenanceEquipmentCategory> MaintenanceEquipmentCategories { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<MaintenanceEquipment> MaintenanceEquipments { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<MaintenanceRequest> MaintenanceRequests { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<MrpBom> MrpBoms { get; set; } 

    //[InverseProperty("IrAttachment")]
    [NotMapped]
    public virtual ICollection<MrpDocument> MrpDocuments { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<MrpProduction> MrpProductions { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<MrpUnbuild> MrpUnbuilds { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<NoteNote> NoteNotes { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<PhoneBlacklist> PhoneBlacklists { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<PosSession> PosSessions { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<ProductProduct> ProductProducts { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<ProductTemplate> ProductTemplates { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<ProjectMilestone> ProjectMilestones { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<ProjectProject> ProjectProjects { get; set; } 

    //[InverseProperty("DisplayedImage")]
    [NotMapped]
    public virtual ICollection<ProjectTask> ProjectTaskDisplayedImages { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<ProjectTask> ProjectTaskMessageMainAttachments { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<ProjectUpdate> ProjectUpdates { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<RepairOrder> RepairOrders { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanies { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<ResPartnerBank> ResPartnerBanks { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<ResPartner> ResPartners { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<SaleOrder> SaleOrders { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<StockLot> StockLots { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<StockPicking> StockPickings { get; set; } 

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<StockScrap> StockScraps { get; set; } 

    [ForeignKey("IrAttachmentId")]
    //[InverseProperty("IrAttachments")]
    [NotMapped]
    public virtual ICollection<AccountBankStatementImport> AccountBankStatementImports { get; set; } 

    [ForeignKey("IrAttachmentId")]
    //[InverseProperty("IrAttachments")]
    [NotMapped]
    public virtual ICollection<AccountTourUploadBill> AccountTourUploadBills { get; set; } 

    [ForeignKey("AttachmentId")]
    //[InverseProperty("Attachments")]
    [NotMapped]
    public virtual ICollection<FleetVehicleSendMail> Wizards { get; set; } 

    //[InverseProperty("IrAttachment")]
    [NotMapped]
    public virtual ICollection<ProductDocument> ProductDocuments { get; set; } 

    //[InverseProperty("DisplayedImage")]
    [NotMapped]
    public virtual ICollection<ProjectTask> ProjectTasks { get; set; } 

    //[InverseProperty("IrAttachment")]
    [NotMapped]
    public virtual ICollection<QuotationDocument> QuotationDocuments { get; set; } 

    [ForeignKey("AttachmentId")]
    //[InverseProperty("Attachments")]
    [NotMapped]
    public virtual ICollection<MailActivity> Activities { get; set; } 

    [ForeignKey("IrAttachmentId")]
    //[InverseProperty("IrAttachments")]
    [NotMapped]
    public virtual ICollection<ApplicantSendMail> ApplicantSendMails { get; set; } 

    [ForeignKey("IrAttachmentId")]
    //[InverseProperty("IrAttachments")]
    [NotMapped]
    public virtual ICollection<CandidateSendMail> CandidateSendMails { get; set; } 

    [ForeignKey("AttachmentId")]
    //[InverseProperty("Attachments")]
    [NotMapped]
    public virtual ICollection<MailingMailing> MassMailings { get; set; } 

    [ForeignKey("IrAttachmentId")]
    //[InverseProperty("IrAttachments")]
    [NotMapped]
    public virtual ICollection<PosConfig> PosConfigs { get; set; } 

    [ForeignKey("AttachmentId")]
    //[InverseProperty("Attachments")]
    [NotMapped]
    public virtual ICollection<MailScheduledMessage> ScheduledMessages { get; set; } 

    [ForeignKey("IrAttachmentId")]
    //[InverseProperty("IrAttachments")]
    [NotMapped]
    public virtual ICollection<SlideChannelInvite> SlideChannelInvites { get; set; } 

    [ForeignKey("AttachmentId")]
    //[InverseProperty("Attachments")]
    [NotMapped]
    public virtual ICollection<SurveyInvite> Wizards1 { get; set; } 

    [ForeignKey("AttachmentId")]
    //[InverseProperty("Attachments")]
    [NotMapped]
    public virtual ICollection<MailComposeMessage> WizardsNavigation { get; set; } 
}
