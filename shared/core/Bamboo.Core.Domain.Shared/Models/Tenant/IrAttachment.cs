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
//[Index("Checksum", Name = "ir_attachment_checksum_index")]
//[Index("ResModel", "ResId", Name = "ir_attachment_res_idx")]
//[Index("StoreFname", Name = "ir_attachment_store_fname_index")]
public partial class IrAttachment: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("res_id")]
    public Guid? ResId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

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
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("db_datas")]
    public byte[]? DbDatas { get; set; }

    [Column("original_id")]
    public Guid? OriginalId { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("theme_template_id")]
    public long? ThemeTemplateId { get; set; }

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
    public virtual ICollection<AccountEdiDocument> AccountEdiDocuments { get; } = new List<AccountEdiDocument>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<AccountJournal> AccountJournals { get; } = new List<AccountJournal>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<AccountMove> AccountMoves { get; } = new List<AccountMove>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<AccountPayment> AccountPayments { get; } = new List<AccountPayment>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModel> AccountReconcileModels { get; } = new List<AccountReconcileModel>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<CalendarEvent> CalendarEvents { get; } = new List<CalendarEvent>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<CrmLead> CrmLeads { get; } = new List<CrmLead>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<CrmTeamMember> CrmTeamMembers { get; } = new List<CrmTeamMember>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<CrmTeam> CrmTeams { get; } = new List<CrmTeam>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<CrossoveredBudget> CrossoveredBudgets { get; } = new List<CrossoveredBudget>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<FleetVehicleLogContract> FleetVehicleLogContracts { get; } = new List<FleetVehicleLogContract>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<FleetVehicleLogService> FleetVehicleLogServices { get; } = new List<FleetVehicleLogService>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<FleetVehicle> FleetVehicles { get; } = new List<FleetVehicle>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<HrApplicant> HrApplicants { get; } = new List<HrApplicant>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<HrContract> HrContracts { get; } = new List<HrContract>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<HrDepartment> HrDepartments { get; } = new List<HrDepartment>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployees { get; } = new List<HrEmployee>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<HrExpenseSheet> HrExpenseSheets { get; } = new List<HrExpenseSheet>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<HrExpense> HrExpenses { get; } = new List<HrExpense>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<HrJob> HrJobs { get; } = new List<HrJob>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<HrLeaveAllocation> HrLeaveAllocations { get; } = new List<HrLeaveAllocation>();

    //[InverseProperty("Icon")]
    [NotMapped]
    public virtual ICollection<HrLeaveType> HrLeaveTypes { get; } = new List<HrLeaveType>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<HrLeave> HrLeaves { get; } = new List<HrLeave>();

    //[InverseProperty("Original")]
    [NotMapped]
    public virtual ICollection<IrAttachment> InverseOriginal { get; } = new List<IrAttachment>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<LunchSupplier> LunchSuppliers { get; } = new List<LunchSupplier>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<MailBlacklist> MailBlacklists { get; } = new List<MailBlacklist>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<MailChannel> MailChannels { get; } = new List<MailChannel>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<MaintenanceEquipmentCategory> MaintenanceEquipmentCategories { get; } = new List<MaintenanceEquipmentCategory>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<MaintenanceEquipment> MaintenanceEquipments { get; } = new List<MaintenanceEquipment>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<MaintenanceRequest> MaintenanceRequests { get; } = new List<MaintenanceRequest>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<MrpBom> MrpBoms { get; } = new List<MrpBom>();

    //[InverseProperty("IrAttachment")]
    [NotMapped]
    public virtual ICollection<MrpDocument> MrpDocuments { get; } = new List<MrpDocument>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<MrpProduction> MrpProductions { get; } = new List<MrpProduction>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<MrpUnbuild> MrpUnbuilds { get; } = new List<MrpUnbuild>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<NoteNote> NoteNotes { get; } = new List<NoteNote>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<PhoneBlacklist> PhoneBlacklists { get; } = new List<PhoneBlacklist>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<PosSession> PosSessions { get; } = new List<PosSession>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<ProductProduct> ProductProducts { get; } = new List<ProductProduct>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<ProductTemplate> ProductTemplates { get; } = new List<ProductTemplate>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<ProjectMilestone> ProjectMilestones { get; } = new List<ProjectMilestone>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<ProjectProject> ProjectProjects { get; } = new List<ProjectProject>();

    //[InverseProperty("DisplayedImage")]
    [NotMapped]
    public virtual ICollection<ProjectTask> ProjectTaskDisplayedImages { get; } = new List<ProjectTask>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<ProjectTask> ProjectTaskMessageMainAttachments { get; } = new List<ProjectTask>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<ProjectUpdate> ProjectUpdates { get; } = new List<ProjectUpdate>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; } = new List<PurchaseOrder>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<RepairOrder> RepairOrders { get; } = new List<RepairOrder>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanies { get; } = new List<ResCompany>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<ResPartnerBank> ResPartnerBanks { get; } = new List<ResPartnerBank>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<ResPartner> ResPartners { get; } = new List<ResPartner>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<SaleOrder> SaleOrders { get; } = new List<SaleOrder>();

    //[InverseProperty("Attachment")]
    [NotMapped]
    public virtual ICollection<SnailmailLetter> SnailmailLetters { get; } = new List<SnailmailLetter>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<StockLot> StockLots { get; } = new List<StockLot>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<StockPicking> StockPickings { get; } = new List<StockPicking>();

    //[InverseProperty("MessageMainAttachment")]
    [NotMapped]
    public virtual ICollection<StockScrap> StockScraps { get; } = new List<StockScrap>();

    [ForeignKey("IrAttachmentId")]
    //[InverseProperty("IrAttachments")]
    [NotMapped]
    public virtual ICollection<AccountBankStatementImport> AccountBankStatementImports { get; } = new List<AccountBankStatementImport>();

    [ForeignKey("IrAttachmentId")]
    //[InverseProperty("IrAttachments")]
    [NotMapped]
    public virtual ICollection<AccountBankStatement> AccountBankStatements { get; } = new List<AccountBankStatement>();

    [ForeignKey("IrAttachmentId")]
    //[InverseProperty("IrAttachments")]
    [NotMapped]
    public virtual ICollection<AccountTourUploadBill> AccountTourUploadBills { get; } = new List<AccountTourUploadBill>();

    [ForeignKey("AttachmentId")]
    //[InverseProperty("Attachments")]
    [NotMapped]
    public virtual ICollection<MailTemplate> EmailTemplates { get; } = new List<MailTemplate>();

    [ForeignKey("AttachmentId")]
    //[InverseProperty("Attachments")]
    [NotMapped]
    public virtual ICollection<MailMessage> Messages { get; } = new List<MailMessage>();

    [ForeignKey("AttachmentId")]
    //[InverseProperty("Attachments")]
    [NotMapped]
    public virtual ICollection<MailComposeMessage> Wizards { get; } = new List<MailComposeMessage>();

}
