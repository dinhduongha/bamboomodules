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

[Table("res_partner")]
//[Index("CommercialPartnerId", Name = "res_partner_commercial_partner_id_index")]
//[Index("TenantId", Name = "res_partner_company_id_index")]
//[Index("Date", Name = "res_partner_date_index")]
//[Index("DisplayName", Name = "res_partner_display_name_index")]
//[Index("IsPublished", Name = "res_partner_is_published_index")]
//[Index("Name", Name = "res_partner_name_index")]
//[Index("ParentId", Name = "res_partner_parent_id_index")]
//[Index("Ref", Name = "res_partner_ref_index")]
//[Index("Vat", Name = "res_partner_vat_index")]
//[Index("WebsiteId", Name = "res_partner_website_id_index")]
public partial class ResPartner: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("title")]
    public long? Title { get; set; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("state_id")]
    public long? StateId { get; set; }

    [Column("country_id")]
    public long? CountryId { get; set; }

    [Column("industry_id")]
    public long? IndustryId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("commercial_partner_id")]
    public Guid? CommercialPartnerId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("display_name")]
    public string? DisplayName { get; set; }

    [Column("ref")]
    public string? Ref { get; set; }

    [Column("lang")]
    public string? Lang { get; set; }

    [Column("tz")]
    public string? Tz { get; set; }

    [Column("vat")]
    public string? Vat { get; set; }

    [Column("company_registry")]
    public string? CompanyRegistry { get; set; }

    [Column("website")]
    public string? Website { get; set; }

    [Column("function")]
    public string? Function { get; set; }

    [Column("type")]
    public string? Type { get; set; }

    [Column("street")]
    public string? Street { get; set; }

    [Column("street2")]
    public string? Street2 { get; set; }

    [Column("zip")]
    public string? Zip { get; set; }

    [Column("city")]
    public string? City { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [Column("phone")]
    public string? Phone { get; set; }

    [Column("mobile")]
    public string? Mobile { get; set; }

    [Column("commercial_company_name")]
    public string? CommercialCompanyName { get; set; }

    [Column("company_name")]
    public string? CompanyName { get; set; }

    [Column("date")]
    public DateTime? Date { get; set; }

    [Column("comment")]
    public string? Comment { get; set; }

    [Column("partner_latitude")]
    public decimal? PartnerLatitude { get; set; }

    [Column("partner_longitude")]
    public decimal? PartnerLongitude { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("employee")]
    public bool? Employee { get; set; }

    [Column("is_company")]
    public bool? IsCompany { get; set; }

    [Column("partner_share")]
    public bool? PartnerShare { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("message_bounce")]
    public long? MessageBounce { get; set; }

    [Column("email_normalized")]
    public string? EmailNormalized { get; set; }

    [Column("signup_token")]
    public string? SignupToken { get; set; }

    [Column("signup_type")]
    public string? SignupType { get; set; }

    [Column("signup_expiration", TypeName = "timestamp without time zone")]
    public DateTime? SignupExpiration { get; set; }

    [Column("team_id")]
    public Guid? TeamId { get; set; }

    [Column("partner_gid")]
    public Guid? PartnerGid { get; set; }

    [Column("additional_info")]
    public string? AdditionalInfo { get; set; }

    [Column("phone_sanitized")]
    public string? PhoneSanitized { get; set; }

    [Column("supplier_rank")]
    public long? SupplierRank { get; set; }

    [Column("customer_rank")]
    public long? CustomerRank { get; set; }

    [Column("invoice_warn")]
    public string? InvoiceWarn { get; set; }

    [Column("invoice_warn_msg")]
    public string? InvoiceWarnMsg { get; set; }

    [Column("debit_limit")]
    public decimal? DebitLimit { get; set; }

    [Column("last_time_entries_checked", TypeName = "timestamp without time zone")]
    public DateTime? LastTimeEntriesChecked { get; set; }

    [Column("sale_warn")]
    public string? SaleWarn { get; set; }

    [Column("sale_warn_msg")]
    public string? SaleWarnMsg { get; set; }

    [Column("picking_warn")]
    public string? PickingWarn { get; set; }

    [Column("picking_warn_msg")]
    public string? PickingWarnMsg { get; set; }

    [Column("purchase_warn")]
    public string? PurchaseWarn { get; set; }

    [Column("purchase_warn_msg")]
    public string? PurchaseWarnMsg { get; set; }

    [Column("payment_responsible_id")]
    public Guid? PaymentResponsibleId { get; set; }

    [Column("latest_followup_sequence")]
    public long? LatestFollowupSequence { get; set; }

    [Column("latest_followup_level_id_without_lit")]
    public Guid? LatestFollowupLevelIdWithoutLit { get; set; }

    [Column("payment_next_action_date")]
    public DateTime? PaymentNextActionDate { get; set; }

    [Column("payment_note")]
    public string? PaymentNote { get; set; }

    [Column("payment_next_action")]
    public string? PaymentNextAction { get; set; }

    [Column("calendar_last_notif_ack", TypeName = "timestamp without time zone")]
    public DateTime? CalendarLastNotifAck { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("is_published")]
    public bool? IsPublished { get; set; }

    [Column("plan_to_change_car")]
    public bool? PlanToChangeCar { get; set; }

    [Column("plan_to_change_bike")]
    public bool? PlanToChangeBike { get; set; }

    [ForeignKey("CommercialPartnerId")]
    //[InverseProperty("InverseCommercialPartner")]
    [NotMapped]
    public virtual ResPartner? CommercialPartner { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CountryId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ResCountry? Country { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("ResPartnerCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("IndustryId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ResPartnerIndustry? Industry { get; set; }

    [ForeignKey("LatestFollowupLevelIdWithoutLit")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual FollowupLine? LatestFollowupLevelIdWithoutLitNavigation { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("ParentId")]
    //[InverseProperty("InverseParent")]
    [NotMapped]
    public virtual ResPartner? Parent { get; set; }

    [ForeignKey("PaymentResponsibleId")]
    //[InverseProperty("ResPartnerPaymentResponsibles")]
    [NotMapped]
    public virtual ResUser? PaymentResponsible { get; set; }

    [ForeignKey("StateId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ResCountryState? State { get; set; }

    [ForeignKey("TeamId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual CrmTeam? Team { get; set; }

    [ForeignKey("Title")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ResPartnerTitle? TitleNavigation { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("ResPartnerUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("WebsiteId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual Website? WebsiteNavigation { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("ResPartnerWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    /// TODO: DISABLE INVERSE
    
    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticAccount> AccountAnalyticAccounts { get; } = new List<AccountAnalyticAccount>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticDistributionModel> AccountAnalyticDistributionModels { get; } = new List<AccountAnalyticDistributionModel>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLines { get; } = new List<AccountAnalyticLine>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<AccountAssetAsset> AccountAssetAssets { get; } = new List<AccountAssetAsset>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<AccountBankStatementLine> AccountBankStatementLines { get; } = new List<AccountBankStatementLine>();

    //[InverseProperty("CommercialPartner")]
    [NotMapped]
    public virtual ICollection<AccountMove> AccountMoveCommercialPartners { get; } = new List<AccountMove>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<AccountMoveLine> AccountMoveLines { get; } = new List<AccountMoveLine>();

    //[InverseProperty("PartnerShipping")]
    [NotMapped]
    public virtual ICollection<AccountMove> AccountMovePartnerShippings { get; } = new List<AccountMove>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<AccountMove> AccountMovePartners { get; } = new List<AccountMove>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<AccountPaymentRegister> AccountPaymentRegisters { get; } = new List<AccountPaymentRegister>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<AccountPayment> AccountPayments { get; } = new List<AccountPayment>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModelPartnerMapping> AccountReconcileModelPartnerMappings { get; } = new List<AccountReconcileModelPartnerMapping>();

    //[InverseProperty("Author")]
    [NotMapped]
    public virtual ICollection<ApplicantSendMail> ApplicantSendMails { get; } = new List<ApplicantSendMail>();

    //[InverseProperty("DstPartner")]
    [NotMapped]
    public virtual ICollection<BasePartnerMergeAutomaticWizard> BasePartnerMergeAutomaticWizards { get; } = new List<BasePartnerMergeAutomaticWizard>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<CalendarAttendee> CalendarAttendees { get; } = new List<CalendarAttendee>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<CalendarFilter> CalendarFilters { get; } = new List<CalendarFilter>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<CrmLead2opportunityPartnerMass> CrmLead2opportunityPartnerMasses { get; } = new List<CrmLead2opportunityPartnerMass>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<CrmLead2opportunityPartner> CrmLead2opportunityPartners { get; } = new List<CrmLead2opportunityPartner>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<CrmLead> CrmLeads { get; } = new List<CrmLead>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<CrmQuotationPartner> CrmQuotationPartners { get; } = new List<CrmQuotationPartner>();

    //[InverseProperty("Driver")]
    [NotMapped]
    public virtual ICollection<FleetVehicleAssignationLog> FleetVehicleAssignationLogs { get; } = new List<FleetVehicleAssignationLog>();

    //[InverseProperty("Driver")]
    [NotMapped]
    public virtual ICollection<FleetVehicle> FleetVehicleDrivers { get; } = new List<FleetVehicle>();

    //[InverseProperty("FutureDriver")]
    [NotMapped]
    public virtual ICollection<FleetVehicle> FleetVehicleFutureDrivers { get; } = new List<FleetVehicle>();

    //[InverseProperty("Insurer")]
    [NotMapped]
    public virtual ICollection<FleetVehicleLogContract> FleetVehicleLogContracts { get; } = new List<FleetVehicleLogContract>();

    //[InverseProperty("Purchaser")]
    [NotMapped]
    public virtual ICollection<FleetVehicleLogService> FleetVehicleLogServicePurchasers { get; } = new List<FleetVehicleLogService>();

    //[InverseProperty("Vendor")]
    [NotMapped]
    public virtual ICollection<FleetVehicleLogService> FleetVehicleLogServiceVendors { get; } = new List<FleetVehicleLogService>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<HrApplicant> HrApplicants { get; } = new List<HrApplicant>();

    //[InverseProperty("AddressHome")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployeeAddressHomes { get; } = new List<HrEmployee>();

    //[InverseProperty("Address")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployeeAddresses { get; } = new List<HrEmployee>();

    //[InverseProperty("WorkContact")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployeeWorkContacts { get; } = new List<HrEmployee>();

    //[InverseProperty("Address")]
    [NotMapped]
    public virtual ICollection<HrExpenseSheet> HrExpenseSheets { get; } = new List<HrExpenseSheet>();

    //[InverseProperty("Address")]
    [NotMapped]
    public virtual ICollection<HrJob> HrJobs { get; } = new List<HrJob>();

    //[InverseProperty("Address")]
    [NotMapped]
    public virtual ICollection<HrWorkLocation> HrWorkLocations { get; } = new List<HrWorkLocation>();

    //[InverseProperty("CommercialPartner")]
    [NotMapped]
    public virtual ICollection<ResPartner> InverseCommercialPartner { get; } = new List<ResPartner>();

    //[InverseProperty("Parent")]
    [NotMapped]
    public virtual ICollection<ResPartner> InverseParent { get; } = new List<ResPartner>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<LunchSupplier> LunchSuppliers { get; } = new List<LunchSupplier>();

    //[InverseProperty("RequestPartner")]
    [NotMapped]
    public virtual ICollection<MailActivity> MailActivities { get; } = new List<MailActivity>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<MailChannelMember> MailChannelMembers { get; } = new List<MailChannelMember>();

    //[InverseProperty("Author")]
    [NotMapped]
    public virtual ICollection<MailComposeMessage> MailComposeMessages { get; } = new List<MailComposeMessage>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<MailFollower> MailFollowers { get; } = new List<MailFollower>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<MailMessageReaction> MailMessageReactions { get; } = new List<MailMessageReaction>();

    //[InverseProperty("Author")]
    [NotMapped]
    public virtual ICollection<MailMessage> MailMessages { get; } = new List<MailMessage>();

    //[InverseProperty("Author")]
    [NotMapped]
    public virtual ICollection<MailNotification> MailNotificationAuthors { get; } = new List<MailNotification>();

    //[InverseProperty("ResPartner")]
    [NotMapped]
    public virtual ICollection<MailNotification> MailNotificationResPartners { get; } = new List<MailNotification>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<MailResendPartner> MailResendPartners { get; } = new List<MailResendPartner>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<MaintenanceEquipment> MaintenanceEquipments { get; } = new List<MaintenanceEquipment>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<PaymentLinkWizard> PaymentLinkWizards { get; } = new List<PaymentLinkWizard>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<PaymentToken> PaymentTokens { get; } = new List<PaymentToken>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<PaymentTransaction> PaymentTransactions { get; } = new List<PaymentTransaction>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<PortalWizardUser> PortalWizardUsers { get; } = new List<PortalWizardUser>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<PosOrder> PosOrders { get; } = new List<PosOrder>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<ProcurementGroup> ProcurementGroups { get; } = new List<ProcurementGroup>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<ProductSupplierinfo> ProductSupplierinfos { get; } = new List<ProductSupplierinfo>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<ProjectCollaborator> ProjectCollaborators { get; } = new List<ProjectCollaborator>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<ProjectProject> ProjectProjects { get; } = new List<ProjectProject>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<ProjectTask> ProjectTasks { get; } = new List<ProjectTask>();

    //[InverseProperty("DestAddress")]
    [NotMapped]
    public virtual ICollection<PurchaseOrder> PurchaseOrderDestAddresses { get; } = new List<PurchaseOrder>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; } = new List<PurchaseOrderLine>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<PurchaseOrder> PurchaseOrderPartners { get; } = new List<PurchaseOrder>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<RatingRating> RatingRatingPartners { get; } = new List<RatingRating>();

    //[InverseProperty("Publisher")]
    [NotMapped]
    public virtual ICollection<RatingRating> RatingRatingPublishers { get; } = new List<RatingRating>();

    //[InverseProperty("RatedPartner")]
    [NotMapped]
    public virtual ICollection<RatingRating> RatingRatingRatedPartners { get; } = new List<RatingRating>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<RecurringPaymentLine> RecurringPaymentLines { get; } = new List<RecurringPaymentLine>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<RecurringPayment> RecurringPayments { get; } = new List<RecurringPayment>();

    //[InverseProperty("Address")]
    [NotMapped]
    public virtual ICollection<RepairOrder> RepairOrderAddresses { get; } = new List<RepairOrder>();

    //[InverseProperty("PartnerInvoice")]
    [NotMapped]
    public virtual ICollection<RepairOrder> RepairOrderPartnerInvoices { get; } = new List<RepairOrder>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<RepairOrder> RepairOrderPartners { get; } = new List<RepairOrder>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanies { get; } = new List<ResCompany>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<ResPartnerAutocompleteSync> ResPartnerAutocompleteSyncs { get; } = new List<ResPartnerAutocompleteSync>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<ResPartnerBank> ResPartnerBanks { get; } = new List<ResPartnerBank>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<ResUser> ResUsers { get; } = new List<ResUser>();

    //[InverseProperty("Guest")]
    [NotMapped]
    public virtual ICollection<ResUsersSettingsVolume> ResUsersSettingsVolumeGuests { get; } = new List<ResUsersSettingsVolume>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<ResUsersSettingsVolume> ResUsersSettingsVolumePartners { get; } = new List<ResUsersSettingsVolume>();

    //[InverseProperty("Author")]
    [NotMapped]
    public virtual ICollection<SaleOrderCancel> SaleOrderCancels { get; } = new List<SaleOrderCancel>();

    //[InverseProperty("OrderPartner")]
    [NotMapped]
    public virtual ICollection<SaleOrderLine> SaleOrderLines { get; } = new List<SaleOrderLine>();

    //[InverseProperty("PartnerInvoice")]
    [NotMapped]
    public virtual ICollection<SaleOrder> SaleOrderPartnerInvoices { get; } = new List<SaleOrder>();

    //[InverseProperty("PartnerShipping")]
    [NotMapped]
    public virtual ICollection<SaleOrder> SaleOrderPartnerShippings { get; } = new List<SaleOrder>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<SaleOrder> SaleOrderPartners { get; } = new List<SaleOrder>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<SmsSm> SmsSms { get; } = new List<SmsSm>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<SnailmailLetterMissingRequiredField> SnailmailLetterMissingRequiredFields { get; } = new List<SnailmailLetterMissingRequiredField>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<SnailmailLetter> SnailmailLetters { get; } = new List<SnailmailLetter>();

    //[InverseProperty("Owner")]
    [NotMapped]
    public virtual ICollection<StockMoveLine> StockMoveLines { get; } = new List<StockMoveLine>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<StockMove> StockMovePartners { get; } = new List<StockMove>();

    //[InverseProperty("RestrictPartner")]
    [NotMapped]
    public virtual ICollection<StockMove> StockMoveRestrictPartners { get; } = new List<StockMove>();

    //[InverseProperty("Owner")]
    [NotMapped]
    public virtual ICollection<StockPicking> StockPickingOwners { get; } = new List<StockPicking>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<StockPicking> StockPickingPartners { get; } = new List<StockPicking>();

    //[InverseProperty("Owner")]
    [NotMapped]
    public virtual ICollection<StockQuant> StockQuants { get; } = new List<StockQuant>();

    //[InverseProperty("PartnerAddress")]
    [NotMapped]
    public virtual ICollection<StockRule> StockRules { get; } = new List<StockRule>();

    //[InverseProperty("Owner")]
    [NotMapped]
    public virtual ICollection<StockScrap> StockScraps { get; } = new List<StockScrap>();

    //[InverseProperty("Vendor")]
    [NotMapped]
    public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpoints { get; } = new List<StockWarehouseOrderpoint>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehouses { get; } = new List<StockWarehouse>();

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<WebsiteVisitor> WebsiteVisitors { get; } = new List<WebsiteVisitor>();

    [ForeignKey("ResPartnerId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ICollection<AccountAgedTrialBalance> AccountAgedTrialBalances { get; } = new List<AccountAgedTrialBalance>();

    [ForeignKey("ResPartnerId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ICollection<AccountBalanceReport> AccountBalanceReports { get; } = new List<AccountBalanceReport>();

    [ForeignKey("ResPartnerId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ICollection<AccountCommonAccountReport> AccountCommonAccountReports { get; } = new List<AccountCommonAccountReport>();

    [ForeignKey("ResPartnerId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ICollection<AccountCommonPartnerReport> AccountCommonPartnerReports { get; } = new List<AccountCommonPartnerReport>();

    [ForeignKey("ResPartnerId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModelTemplate> AccountReconcileModelTemplates { get; } = new List<AccountReconcileModelTemplate>();

    [ForeignKey("ResPartnerId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModel> AccountReconcileModels { get; } = new List<AccountReconcileModel>();

    [ForeignKey("ResPartnerId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ICollection<AccountReportGeneralLedger> AccountReportGeneralLedgers { get; } = new List<AccountReportGeneralLedger>();

    [ForeignKey("ResPartnerId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ICollection<AccountReportPartnerLedger> AccountReportPartnerLedgers { get; } = new List<AccountReportPartnerLedger>();

    [ForeignKey("ResPartnerId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ICollection<BasePartnerMergeAutomaticWizard> BasePartnerMergeAutomaticWizardsNavigation { get; } = new List<BasePartnerMergeAutomaticWizard>();

    [ForeignKey("ResPartnerId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ICollection<CalendarEvent> CalendarEvents { get; } = new List<CalendarEvent>();

    [ForeignKey("PartnerId")]
    //[InverseProperty("Partners")]
    [NotMapped]
    public virtual ICollection<ResPartnerCategory> Categories { get; } = new List<ResPartnerCategory>();

    [ForeignKey("ResPartnerId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ICollection<IrActServer> IrActServers { get; } = new List<IrActServer>();

    [ForeignKey("ResPartnerId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ICollection<MailMail> MailMails { get; } = new List<MailMail>();

    [ForeignKey("ResPartnerId")]
    //[InverseProperty("ResPartnersNavigation")]
    [NotMapped]
    public virtual ICollection<MailMessage> MailMessages1 { get; } = new List<MailMessage>();

    [ForeignKey("ResPartnerId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ICollection<MailMessage> MailMessagesNavigation { get; } = new List<MailMessage>();

    [ForeignKey("ResPartnerId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ICollection<MailWizardInvite> MailWizardInvites { get; } = new List<MailWizardInvite>();

    [ForeignKey("PartnerId")]
    //[InverseProperty("Partners")]
    [NotMapped]
    public virtual ICollection<FleetVehicleModel> Models { get; } = new List<FleetVehicleModel>();

    [ForeignKey("ResPartnerId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ICollection<PortalShare> PortalShares { get; } = new List<PortalShare>();

    [ForeignKey("ResPartnerId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ICollection<PortalWizard> PortalWizards { get; } = new List<PortalWizard>();

    [ForeignKey("ResPartnerId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ICollection<ProductProduct> ProductProducts { get; } = new List<ProductProduct>();

    [ForeignKey("ResPartnerId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ICollection<ProjectShareWizard> ProjectShareWizards { get; } = new List<ProjectShareWizard>();

    [ForeignKey("PartnerId")]
    //[InverseProperty("Partners")]
    [NotMapped]
    public virtual ICollection<MailComposeMessage> Wizards { get; } = new List<MailComposeMessage>();
    
}
