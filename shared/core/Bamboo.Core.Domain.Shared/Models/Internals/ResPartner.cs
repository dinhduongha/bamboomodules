using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bamboo.Core.Domain.Shared.Attributes;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

[Module("base")]
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
public partial class ResPartner: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("title")]
    public Guid? Title { get; set; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("state_id")]
    public Guid? StateId { get; set; }

    [Column("country_id")]
    public Guid? CountryId { get; set; }

    [Column("industry_id")]
    public Guid? IndustryId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("commercial_partner_id")]
    public Guid? CommercialPartnerId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("complete_name")]
    public string? CompleteName { get; set; }

    // v16-Compat
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

    [JsonField]
    [Column("barcode", TypeName = "jsonb")]
    public string? Barcode { get; set; }

    // v16-Compat
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
    public override DateTime? LastModificationTime { get; set; }

    // v16-Compat
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("message_bounce")]
    public long? MessageBounce { get; set; }

    [Column("email_normalized")]
    public string? EmailNormalized { get; set; }

    // v16-Compat
    [Column("signup_token")]
    public string? SignupToken { get; set; }

    [Column("signup_type")]
    public string? SignupType { get; set; }

    [JsonField]
    [Column("specific_property_product_pricelist", TypeName = "jsonb")]
    public string? SpecificPropertyProductPricelist { get; set; }

    // v16-Compat
    [Column("signup_expiration", TypeName = "timestamp without time zone")]
    public DateTime? SignupExpiration { get; set; }

    // v16-Compat
    [Column("team_id")]
    public Guid? TeamId { get; set; }

    [Column("partner_gid")]
    public Guid? PartnerGid { get; set; }

    [Column("additional_info")]
    public string? AdditionalInfo { get; set; }

    [Column("phone_sanitized")]
    public string? PhoneSanitized { get; set; }

    [Column("invoice_template_pdf_report_id")]
    public Guid? InvoiceTemplatePdfReportId { get; set; }

    [Column("supplier_rank")]
    public long? SupplierRank { get; set; }

    [Column("customer_rank")]
    public long? CustomerRank { get; set; }

    [Column("invoice_warn")]
    public string? InvoiceWarn { get; set; }

    [Column("autopost_bills")]
    public string? AutopostBills { get; set; }

    [JsonField]
    [Column("credit_limit", TypeName = "jsonb")]
    public string? CreditLimit { get; set; }

    [JsonField]
    [Column("property_account_payable_id", TypeName = "jsonb")]
    public string? PropertyAccountPayableId { get; set; }

    [JsonField]
    [Column("property_account_receivable_id", TypeName = "jsonb")]
    public string? PropertyAccountReceivableId { get; set; }

    [JsonField]
    [Column("property_account_position_id", TypeName = "jsonb")]
    public string? PropertyAccountPositionId { get; set; }

    [JsonField]
    [Column("property_payment_term_id", TypeName = "jsonb")]
    public string? PropertyPaymentTermId { get; set; }

    [JsonField]
    [Column("property_supplier_payment_term_id", TypeName = "jsonb")]
    public string? PropertySupplierPaymentTermId { get; set; }

    [JsonField]
    [Column("trust", TypeName = "jsonb")]
    public string? Trust { get; set; }

    [JsonField]
    [Column("ignore_abnormal_invoice_date", TypeName = "jsonb")]
    public string? IgnoreAbnormalInvoiceDate { get; set; }

    [JsonField]
    [Column("ignore_abnormal_invoice_amount", TypeName = "jsonb")]
    public string? IgnoreAbnormalInvoiceAmount { get; set; }

    [JsonField]
    [Column("invoice_sending_method", TypeName = "jsonb")]
    public string? InvoiceSendingMethod { get; set; }

    [JsonField]
    [Column("invoice_edi_format_store", TypeName = "jsonb")]
    public string? InvoiceEdiFormatStore { get; set; }

    [JsonField]
    [Column("property_outbound_payment_method_line_id", TypeName = "jsonb")]
    public string? PropertyOutboundPaymentMethodLineId { get; set; }

    [JsonField]
    [Column("property_inbound_payment_method_line_id", TypeName = "jsonb")]
    public string? PropertyInboundPaymentMethodLineId { get; set; }

    // v16-Compat
    //[Column("invoice_warn_msg")]
    //public string? InvoiceWarnMsg { get; set; }

    // v16-Compat
    //[Column("debit_limit")]
    //public decimal? DebitLimit { get; set; }

    [Column("invoice_warn_msg")]
    public string? InvoiceWarnMsg { get; set; }

    [Column("debit_limit")]
    public decimal? DebitLimit { get; set; }

    [Column("peppol_endpoint")]
    public string? PeppolEndpoint { get; set; }

    [Column("peppol_eas")]
    public string? PeppolEas { get; set; }

    [Column("payment_responsible_id")]
    public Guid? PaymentResponsibleId { get; set; }

    [Column("latest_followup_sequence")]
    public long? LatestFollowupSequence { get; set; }

    [Column("payment_next_action_date")]
    public DateTime? PaymentNextActionDate { get; set; }

    [Column("payment_note")]
    public string? PaymentNote { get; set; }

    [Column("payment_next_action")]
    public string? PaymentNextAction { get; set; }

    [Column("calendar_last_notif_ack", TypeName = "timestamp without time zone")]
    public DateTime? CalendarLastNotifAck { get; set; }

    // v16-Compat
    [Column("last_time_entries_checked", TypeName = "timestamp without time zone")]
    public DateTime? LastTimeEntriesChecked { get; set; }

    [Column("sale_warn")]
    public string? SaleWarn { get; set; }

    [Column("sale_warn_msg")]
    public string? SaleWarnMsg { get; set; }

    [Column("picking_warn")]
    public string? PickingWarn { get; set; }

    [JsonField]
    [Column("property_stock_customer", TypeName = "jsonb")]
    public string? PropertyStockCustomer { get; set; }

    [JsonField]
    [Column("property_stock_supplier", TypeName = "jsonb")]
    public string? PropertyStockSupplier { get; set; }

    [Column("picking_warn_msg")]
    public string? PickingWarnMsg { get; set; }

    [Column("buyer_id")]
    public Guid? BuyerId { get; set; }

    [Column("purchase_warn")]
    public string? PurchaseWarn { get; set; }

    [JsonField]
    [Column("property_purchase_currency_id", TypeName = "jsonb")]
    public string? PropertyPurchaseCurrencyId { get; set; }

    [JsonField]
    [Column("receipt_reminder_email", TypeName = "jsonb")]
    public string? ReceiptReminderEmail { get; set; }

    [JsonField]
    [Column("reminder_date_before_receipt", TypeName = "jsonb")]
    public string? ReminderDateBeforeReceipt { get; set; }

    [Column("purchase_warn_msg")]
    public string? PurchaseWarnMsg { get; set; }

    [Column("plan_to_change_car")]
    public bool? PlanToChangeCar { get; set; }

    [Column("plan_to_change_bike")]
    public bool? PlanToChangeBike { get; set; }

    // v16-Compat
    //[Column("purchase_warn_msg")]
    //public string? PurchaseWarnMsg { get; set; }

    // v16-Compat
    //[Column("payment_responsible_id")]
    //public Guid? PaymentResponsibleId { get; set; }

    // v16-Compat
    //[Column("latest_followup_sequence")]
    //public long? LatestFollowupSequence { get; set; }

    // v16-Compat
    [Column("latest_followup_level_id_without_lit")]
    public Guid? LatestFollowupLevelIdWithoutLit { get; set; }

    // v16-Compat
    //[Column("payment_next_action_date")]
    //public DateTime? PaymentNextActionDate { get; set; }

    // v16-Compat
    //[Column("payment_note")]
    //public string? PaymentNote { get; set; }

    // v16-Compat
    //[Column("payment_next_action")]
    //public string? PaymentNextAction { get; set; }

    // v16-Compat
    //[Column("calendar_last_notif_ack", TypeName = "timestamp without time zone")]
    //public DateTime? CalendarLastNotifAck { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("is_published")]
    public bool? IsPublished { get; set; }

    [JsonField]
    [Column("property_delivery_carrier_id", TypeName = "jsonb")]
    public string? PropertyDeliveryCarrierId { get; set; }

    [Column("website_meta_og_img")]
    public string? WebsiteMetaOgImg { get; set; }

    [JsonField]
    [Column("website_meta_title", TypeName = "jsonb")]
    public string? WebsiteMetaTitle { get; set; }

    [JsonField]
    [Column("website_meta_description", TypeName = "jsonb")]
    public string? WebsiteMetaDescription { get; set; }

    [JsonField]
    [Column("website_meta_keywords", TypeName = "jsonb")]
    public string? WebsiteMetaKeywords { get; set; }

    [JsonField]
    [Column("seo_name", TypeName = "jsonb")]
    public string? SeoName { get; set; }

    [JsonField]
    [Column("website_description", TypeName = "jsonb")]
    public string? WebsiteDescription { get; set; }

    [JsonField]
    [Column("website_short_description", TypeName = "jsonb")]
    public string? WebsiteShortDescription { get; set; }

    // v16-Compat
    // [Column("plan_to_change_car")]
    // public bool? PlanToChangeCar { get; set; }

    // v16-Compat
    // [Column("plan_to_change_bike")]
    // public bool? PlanToChangeBike { get; set; }

    // v16-Compat
    [ForeignKey("CommercialPartnerId")]
    //[InverseProperty("InverseCommercialPartner")]
    [NotMapped]
    public virtual ResPartner? CommercialPartner { get; set; }

    // v16-Compat
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

    // v16-Compat
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

    // v16-Compat
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
    public virtual ICollection<AccountAnalyticAccount> AccountAnalyticAccounts { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticDistributionModel> AccountAnalyticDistributionModels { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLines { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<AccountAssetAsset> AccountAssetAssets { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<AccountBankStatementLine> AccountBankStatementLines { get; set; } 

    //[InverseProperty("CommercialPartner")]
    [NotMapped]
    public virtual ICollection<AccountMove> AccountMoveCommercialPartners { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<AccountMoveLine> AccountMoveLines { get; set; } 

    //[InverseProperty("PartnerShipping")]
    [NotMapped]
    public virtual ICollection<AccountMove> AccountMovePartnerShippings { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<AccountMove> AccountMovePartners { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<AccountPaymentRegister> AccountPaymentRegisters { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<AccountPayment> AccountPayments { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModelPartnerMapping> AccountReconcileModelPartnerMappings { get; set; } 

    //[InverseProperty("Author")]
    [NotMapped]
    public virtual ICollection<ApplicantSendMail> ApplicantSendMails { get; set; } 

    //[InverseProperty("DstPartner")]
    [NotMapped]
    public virtual ICollection<BasePartnerMergeAutomaticWizard> BasePartnerMergeAutomaticWizards { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<CalendarAttendee> CalendarAttendees { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<CalendarFilters> CalendarFilters { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<CrmLead2opportunityPartnerMass> CrmLead2opportunityPartnerMasses { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<CrmLead2opportunityPartner> CrmLead2opportunityPartners { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<CrmLead> CrmLeads { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<CrmQuotationPartner> CrmQuotationPartners { get; set; } 

    //[InverseProperty("Driver")]
    [NotMapped]
    public virtual ICollection<FleetVehicleAssignationLog> FleetVehicleAssignationLogs { get; set; } 

    //[InverseProperty("Driver")]
    [NotMapped]
    public virtual ICollection<FleetVehicle> FleetVehicleDrivers { get; set; } 

    //[InverseProperty("FutureDriver")]
    [NotMapped]
    public virtual ICollection<FleetVehicle> FleetVehicleFutureDrivers { get; set; } 

    //[InverseProperty("Insurer")]
    [NotMapped]
    public virtual ICollection<FleetVehicleLogContract> FleetVehicleLogContracts { get; set; } 

    //[InverseProperty("Purchaser")]
    [NotMapped]
    public virtual ICollection<FleetVehicleLogServices> FleetVehicleLogServicePurchasers { get; set; } 

    //[InverseProperty("Vendor")]
    [NotMapped]
    public virtual ICollection<FleetVehicleLogServices> FleetVehicleLogServiceVendors { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<HrApplicant> HrApplicants { get; set; } 

    //[InverseProperty("AddressHome")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployeeAddressHomes { get; set; } 

    //[InverseProperty("Address")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployeeAddresses { get; set; } 

    //[InverseProperty("WorkContact")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployeeWorkContacts { get; set; } 

    //[InverseProperty("Address")]
    [NotMapped]
    public virtual ICollection<HrExpenseSheet> HrExpenseSheets { get; set; } 

    //[InverseProperty("Address")]
    [NotMapped]
    public virtual ICollection<HrJob> HrJobs { get; set; } 

    //[InverseProperty("Address")]
    [NotMapped]
    public virtual ICollection<HrWorkLocation> HrWorkLocations { get; set; } 

    //[InverseProperty("CommercialPartner")]
    [NotMapped]
    public virtual ICollection<ResPartner> InverseCommercialPartner { get; set; } 

    //[InverseProperty("Parent")]
    [NotMapped]
    public virtual ICollection<ResPartner> InverseParent { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<LunchSupplier> LunchSuppliers { get; set; } 

    //[InverseProperty("RequestPartner")]
    [NotMapped]
    public virtual ICollection<MailActivity> MailActivities { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<MailChannelMember> MailChannelMembers { get; set; } 

    //[InverseProperty("Author")]
    [NotMapped]
    public virtual ICollection<MailComposeMessage> MailComposeMessages { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<MailFollower> MailFollowers { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<MailMessageReaction> MailMessageReactions { get; set; } 

    //[InverseProperty("Author")]
    [NotMapped]
    public virtual ICollection<MailMessage> MailMessages { get; set; } 

    //[InverseProperty("Author")]
    [NotMapped]
    public virtual ICollection<MailNotification> MailNotificationAuthors { get; set; } 

    //[InverseProperty("ResPartner")]
    [NotMapped]
    public virtual ICollection<MailNotification> MailNotificationResPartners { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<MailResendPartner> MailResendPartners { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<MaintenanceEquipment> MaintenanceEquipments { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<PaymentLinkWizard> PaymentLinkWizards { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<PaymentToken> PaymentTokens { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<PaymentTransaction> PaymentTransactions { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<PortalWizardUser> PortalWizardUsers { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<PosOrder> PosOrders { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<ProcurementGroup> ProcurementGroups { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<ProductSupplierinfo> ProductSupplierinfos { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<ProjectCollaborator> ProjectCollaborators { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<ProjectProject> ProjectProjects { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<ProjectTask> ProjectTasks { get; set; } 

    //[InverseProperty("DestAddress")]
    [NotMapped]
    public virtual ICollection<PurchaseOrder> PurchaseOrderDestAddresses { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<PurchaseOrder> PurchaseOrderPartners { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<RatingRating> RatingRatingPartners { get; set; } 

    //[InverseProperty("Publisher")]
    [NotMapped]
    public virtual ICollection<RatingRating> RatingRatingPublishers { get; set; } 

    //[InverseProperty("RatedPartner")]
    [NotMapped]
    public virtual ICollection<RatingRating> RatingRatingRatedPartners { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<RecurringPaymentLine> RecurringPaymentLines { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<RecurringPayment> RecurringPayments { get; set; } 

    //[InverseProperty("Address")]
    [NotMapped]
    public virtual ICollection<RepairOrder> RepairOrderAddresses { get; set; } 

    //[InverseProperty("PartnerInvoice")]
    [NotMapped]
    public virtual ICollection<RepairOrder> RepairOrderPartnerInvoices { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<RepairOrder> RepairOrderPartners { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanies { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<ResPartnerAutocompleteSync> ResPartnerAutocompleteSyncs { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<ResPartnerBank> ResPartnerBanks { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<ResUser> ResUsers { get; set; } 

    //[InverseProperty("Guest")]
    [NotMapped]
    public virtual ICollection<ResUsersSettingsVolumes> ResUsersSettingsVolumeGuests { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<ResUsersSettingsVolumes> ResUsersSettingsVolumePartners { get; set; } 

    //[InverseProperty("Author")]
    [NotMapped]
    public virtual ICollection<SaleOrderCancel> SaleOrderCancels { get; set; } 

    //[InverseProperty("OrderPartner")]
    [NotMapped]
    public virtual ICollection<SaleOrderLine> SaleOrderLines { get; set; } 

    //[InverseProperty("PartnerInvoice")]
    [NotMapped]
    public virtual ICollection<SaleOrder> SaleOrderPartnerInvoices { get; set; } 

    //[InverseProperty("PartnerShipping")]
    [NotMapped]
    public virtual ICollection<SaleOrder> SaleOrderPartnerShippings { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<SaleOrder> SaleOrderPartners { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<SmsSms> SmsSms { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<SnailmailLetterMissingRequiredField> SnailmailLetterMissingRequiredFields { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<SnailmailLetter> SnailmailLetters { get; set; } 

    //[InverseProperty("Owner")]
    [NotMapped]
    public virtual ICollection<StockMoveLine> StockMoveLines { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<StockMove> StockMovePartners { get; set; } 

    //[InverseProperty("RestrictPartner")]
    [NotMapped]
    public virtual ICollection<StockMove> StockMoveRestrictPartners { get; set; } 

    //[InverseProperty("Owner")]
    [NotMapped]
    public virtual ICollection<StockPicking> StockPickingOwners { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<StockPicking> StockPickingPartners { get; set; } 

    //[InverseProperty("Owner")]
    [NotMapped]
    public virtual ICollection<StockQuant> StockQuants { get; set; } 

    //[InverseProperty("PartnerAddress")]
    [NotMapped]
    public virtual ICollection<StockRule> StockRules { get; set; } 

    //[InverseProperty("Owner")]
    [NotMapped]
    public virtual ICollection<StockScrap> StockScraps { get; set; } 

    //[InverseProperty("Vendor")]
    [NotMapped]
    public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpoints { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<StockWarehouse> StockWarehouses { get; set; } 

    //[InverseProperty("Partner")]
    [NotMapped]
    public virtual ICollection<WebsiteVisitor> WebsiteVisitors { get; set; } 

    [ForeignKey("ResPartnerId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ICollection<AccountAgedTrialBalance> AccountAgedTrialBalances { get; set; } 

    [ForeignKey("ResPartnerId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ICollection<AccountBalanceReport> AccountBalanceReports { get; set; } 

    [ForeignKey("ResPartnerId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ICollection<AccountCommonAccountReport> AccountCommonAccountReports { get; set; } 

    [ForeignKey("ResPartnerId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ICollection<AccountCommonPartnerReport> AccountCommonPartnerReports { get; set; } 

    [ForeignKey("ResPartnerId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModelTemplate> AccountReconcileModelTemplates { get; set; } 

    [ForeignKey("ResPartnerId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ICollection<AccountReconcileModel> AccountReconcileModels { get; set; } 

    [ForeignKey("ResPartnerId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ICollection<AccountReportGeneralLedger> AccountReportGeneralLedgers { get; set; } 

    [ForeignKey("ResPartnerId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ICollection<AccountReportPartnerLedger> AccountReportPartnerLedgers { get; set; } 

    [ForeignKey("ResPartnerId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ICollection<BasePartnerMergeAutomaticWizard> BasePartnerMergeAutomaticWizardsNavigation { get; set; } 

    [ForeignKey("ResPartnerId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ICollection<CalendarEvent> CalendarEvents { get; set; } 

    [ForeignKey("PartnerId")]
    //[InverseProperty("Partners")]
    [NotMapped]
    public virtual ICollection<ResPartnerCategory> Categories { get; set; } 

    [ForeignKey("ResPartnerId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ICollection<IrActServer> IrActServers { get; set; } 

    [ForeignKey("ResPartnerId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ICollection<MailMail> MailMails { get; set; } 

    [ForeignKey("ResPartnerId")]
    //[InverseProperty("ResPartnersNavigation")]
    [NotMapped]
    public virtual ICollection<MailMessage> MailMessages1 { get; set; } 

    [ForeignKey("ResPartnerId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ICollection<MailMessage> MailMessagesNavigation { get; set; } 

    [ForeignKey("ResPartnerId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ICollection<MailWizardInvite> MailWizardInvites { get; set; } 

    [ForeignKey("PartnerId")]
    //[InverseProperty("Partners")]
    [NotMapped]
    public virtual ICollection<FleetVehicleModel> Models { get; set; } 

    [ForeignKey("ResPartnerId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ICollection<PortalShare> PortalShares { get; set; } 

    [ForeignKey("ResPartnerId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ICollection<PortalWizard> PortalWizards { get; set; } 

    [ForeignKey("ResPartnerId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ICollection<ProductProduct> ProductProducts { get; set; } 

    [ForeignKey("ResPartnerId")]
    //[InverseProperty("ResPartners")]
    [NotMapped]
    public virtual ICollection<ProjectShareWizard> ProjectShareWizards { get; set; } 

    [ForeignKey("PartnerId")]
    //[InverseProperty("Partners")]
    [NotMapped]
    public virtual ICollection<MailComposeMessage> Wizards { get; set; } 
   
}
