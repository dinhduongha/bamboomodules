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
//[Index("CommercialPartnerId", Name = "res_partner__commercial_partner_id_index")]
//[Index("CompanyId", Name = "res_partner__company_id_index")]
//[Index("CompleteName", Name = "res_partner__complete_name_index")]
//[Index("Date", Name = "res_partner_date_index")]
//[Index("DisplayName", Name = "res_partner_display_name_index")]
//[Index("IsPublished", Name = "res_partner__is_published_index")]
//[Index("Name", Name = "res_partner__name_index")]
//[Index("ParentId", Name = "res_partner__parent_id_index")]
//[Index("Ref", Name = "res_partner__ref_index")]
//[Index("Vat", Name = "res_partner__vat_index")]
//[Index("WebsiteId", Name = "res_partner__website_id_index")]
public partial class ResPartner: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

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
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("complete_name")]
    public string? CompleteName { get; set; }

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

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("message_bounce")]
    public long? MessageBounce { get; set; }

    [Column("email_normalized")]
    public string? EmailNormalized { get; set; }

    [Column("signup_type")]
    public string? SignupType { get; set; }

    [Column("signup_expiration", TypeName = "timestamp without time zone")]
    public DateTime? SignupExpiration { get; set; }

    [Column("signup_token")]
    public string? SignupToken { get; set; }

    [JsonField]
    [Column("specific_property_product_pricelist", TypeName = "jsonb")]
    public string? SpecificPropertyProductPricelist { get; set; }

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

    [Column("invoice_warn_msg")]
    public string? InvoiceWarnMsg { get; set; }

    [Column("debit_limit")]
    public decimal? DebitLimit { get; set; }

    [Column("peppol_endpoint")]
    public string? PeppolEndpoint { get; set; }

    [Column("peppol_eas")]
    public string? PeppolEas { get; set; }

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

    [Column("calendar_last_notif_ack", TypeName = "timestamp without time zone")]
    public DateTime? CalendarLastNotifAck { get; set; }

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

    [Column("plan_to_change_car")]
    public bool? PlanToChangeCar { get; set; }

    [Column("plan_to_change_bike")]
    public bool? PlanToChangeBike { get; set; }

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

    [Column("associate_member")]
    public Guid? AssociateMember { get; set; }

    [Column("membership_state")]
    public string? MembershipState { get; set; }

    [Column("membership_start")]
    public DateTime? MembershipStart { get; set; }

    [Column("membership_stop")]
    public DateTime? MembershipStop { get; set; }

    [Column("membership_cancel")]
    public DateTime? MembershipCancel { get; set; }

    [Column("membership_amount")]
    public decimal? MembershipAmount { get; set; }

    [Column("free_member")]
    public bool? FreeMember { get; set; }

    [Column("city_id")]
    public Guid? CityId { get; set; }

    [Column("street_name")]
    public string? StreetName { get; set; }

    [Column("street_number")]
    public string? StreetNumber { get; set; }

    [Column("street_number2")]
    public string? StreetNumber2 { get; set; }

    [JsonField]
    [Column("property_stock_subcontractor", TypeName = "jsonb")]
    public string? PropertyStockSubcontractor { get; set; }

    [Column("date_localization")]
    public DateTime? DateLocalization { get; set; }

    [Column("partner_weight")]
    public long? PartnerWeight { get; set; }

    [Column("grade_id")]
    public Guid? GradeId { get; set; }

    [Column("grade_sequence")]
    public long? GradeSequence { get; set; }

    [Column("activation")]
    public Guid? Activation { get; set; }

    [Column("assigned_partner_id")]
    public Guid? AssignedPartnerId { get; set; }

    [Column("implemented_partner_count")]
    public long? ImplementedPartnerCount { get; set; }

    [Column("date_partnership")]
    public DateTime? DatePartnership { get; set; }

    [Column("date_review")]
    public DateTime? DateReview { get; set; }

    [Column("date_review_next")]
    public DateTime? DateReviewNext { get; set; }

    [Column("vies_valid")]
    public bool? ViesValid { get; set; }

    // [Column("city_id")]
    // public Guid? CityId { get; set; }

    [JsonField]
    [Column("peppol_verification_state", TypeName = "jsonb")]
    public string? PeppolVerificationState { get; set; }

    // [Column("street_name")]
    // public string? StreetName { get; set; }

    // [Column("street_number")]
    // public string? StreetNumber { get; set; }

    // [Column("street_number2")]
    // public string? StreetNumber2 { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<AccountAnalyticAccount> AccountAnalyticAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<AccountAnalyticDistributionModel> AccountAnalyticDistributionModel { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<AccountAnalyticLine> AccountAnalyticLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<AccountAssetAsset> AccountAssetAsset { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<AccountAutopostBillsWizard> AccountAutopostBillsWizard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<AccountBankStatementLine> AccountBankStatementLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("CommercialPartnerId")]
    // [InverseProperty("CommercialPartner")]
    // public virtual ICollection<AccountMove> AccountMoveCommercialPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<AccountMoveLine> AccountMoveLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<AccountMove> AccountMovePartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerShippingId")]
    // [InverseProperty("PartnerShipping")]
    // public virtual ICollection<AccountMove> AccountMovePartnerShipping { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<AccountPayment> AccountPayment { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<AccountPaymentRegister> AccountPaymentRegister { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<AccountReconcileModelPartnerMapping> AccountReconcileModelPartnerMapping { get; set; }

    // [Many2one]
    [ForeignKey("Activation")]
    // [InverseProperty("ResPartner")] //Many2one
    public virtual ResPartnerActivation? ActivationNavigation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("AuthorId")]
    // [InverseProperty("Author")]
    // public virtual ICollection<ApplicantSendMail> ApplicantSendMail { get; set; }

    // [Many2one]
    [ForeignKey("AssignedPartnerId")]
    // [InverseProperty("InverseAssignedPartner")] //Many2one
    public virtual ResPartner? AssignedPartner { get; set; }

    // [Many2one]
    [ForeignKey("AssociateMember")]
    // [InverseProperty("InverseAssociateMemberNavigation")] //Many2one
    public virtual ResPartner? AssociateMemberNavigation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("DstPartnerId")]
    // [InverseProperty("DstPartner")]
    // public virtual ICollection<BasePartnerMergeAutomaticWizard> BasePartnerMergeAutomaticWizard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<BillToPoWizard> BillToPoWizard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("AuthorId")]
    // [InverseProperty("Author")]
    // public virtual ICollection<BlogPost> BlogPost { get; set; }

    // [Many2one]
    [ForeignKey("BuyerId")]
    // [InverseProperty("ResPartnerBuyer")] //Many2one
    public virtual ResUsers? Buyer { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<CalendarAttendee> CalendarAttendee { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<CalendarFilters> CalendarFilters { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("AuthorId")]
    // [InverseProperty("Author")]
    // public virtual ICollection<CandidateSendMail> CandidateSendMail { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("OperatorPartnerId")]
    // [InverseProperty("OperatorPartner")]
    // public virtual ICollection<ChatbotScript> ChatbotScript { get; set; }

    // [Many2one]
    [ForeignKey("CityId")]
    // [InverseProperty("ResPartner")] //Many2one
    public virtual ResCity? CityNavigation { get; set; }

    // [Many2one]
    [ForeignKey("CommercialPartnerId")]
    // [InverseProperty("InverseCommercialPartner")] //Many2one
    public virtual ResPartner? CommercialPartner { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("ResPartner")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CountryId")]
    // [InverseProperty("ResPartner")] //Many2one
    public virtual ResCountry? Country { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("ResPartnerCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<CrmLead2opportunityPartner> CrmLead2opportunityPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<CrmLead2opportunityPartnerMass> CrmLead2opportunityPartnerMass { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerAssignedId")]
    // [InverseProperty("PartnerAssigned")]
    // public virtual ICollection<CrmLeadAssignation> CrmLeadAssignation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<CrmLeadForwardToPartner> CrmLeadForwardToPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<CrmLead> CrmLeadPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerAssignedId")]
    // [InverseProperty("PartnerAssigned")]
    // public virtual ICollection<CrmLead> CrmLeadPartnerAssigned { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<CrmQuotationPartner> CrmQuotationPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("LivechatOperatorId")]
    // [InverseProperty("LivechatOperator")]
    // public virtual ICollection<DiscussChannel> DiscussChannel { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<DiscussChannelMember> DiscussChannelMember { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<EventBooth> EventBooth { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<EventBoothRegistration> EventBoothRegistration { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("AddressId")]
    // [InverseProperty("Address")]
    // public virtual ICollection<EventEvent> EventEventAddress { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("OrganizerId")]
    // [InverseProperty("Organizer")]
    // public virtual ICollection<EventEvent> EventEventOrganizer { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<EventRegistration> EventRegistration { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<EventSponsor> EventSponsor { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<EventTrack> EventTrack { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<EventTrackVisitor> EventTrackVisitor { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("DriverId")]
    // [InverseProperty("Driver")]
    // public virtual ICollection<FleetVehicleAssignationLog> FleetVehicleAssignationLog { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("DriverId")]
    // [InverseProperty("Driver")]
    // public virtual ICollection<FleetVehicle> FleetVehicleDriver { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("FutureDriverId")]
    // [InverseProperty("FutureDriver")]
    // public virtual ICollection<FleetVehicle> FleetVehicleFutureDriver { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("InsurerId")]
    // [InverseProperty("Insurer")]
    // public virtual ICollection<FleetVehicleLogContract> FleetVehicleLogContract { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PurchaserId")]
    // [InverseProperty("Purchaser")]
    // public virtual ICollection<FleetVehicleLogServices> FleetVehicleLogServicesPurchaser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("VendorId")]
    // [InverseProperty("Vendor")]
    // public virtual ICollection<FleetVehicleLogServices> FleetVehicleLogServicesVendor { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("AuthorId")]
    // [InverseProperty("Author")]
    // public virtual ICollection<FleetVehicleSendMail> FleetVehicleSendMail { get; set; }

    // [Many2one]
    [ForeignKey("GradeId")]
    // [InverseProperty("ResPartner")] //Many2one
    public virtual ResPartnerGrade? Grade { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<HrCandidate> HrCandidate { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<HrContributionRegister> HrContributionRegister { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<HrApplicant> HrApplicant { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("AddressId")]
    // [InverseProperty("Address")]
    // public virtual ICollection<HrEmployee> HrEmployeeAddress { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("AddressHomeId")]
    // [InverseProperty("AddressHome")]
    // public virtual ICollection<HrEmployee> HrEmployeeAddressHome { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("WorkContactId")]
    // [InverseProperty("WorkContact")]
    // public virtual ICollection<HrEmployee> HrEmployeeWorkContact { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("VendorId")]
    // [InverseProperty("Vendor")]
    // public virtual ICollection<HrExpense> HrExpense { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("AddressId")]
    // [InverseProperty("Address")]
    // public virtual ICollection<HrExpenseSheet> HrExpenseSheet { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("AddressId")]
    // [InverseProperty("Address")]
    // public virtual ICollection<HrJob> HrJob { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("AddressId")]
    // [InverseProperty("Address")]
    // public virtual ICollection<HrWorkLocation> HrWorkLocation { get; set; }

    // [Many2one]
    [ForeignKey("IndustryId")]
    // [InverseProperty("ResPartner")] //Many2one
    public virtual ResPartnerIndustry? Industry { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("AssignedPartnerId")]
    // [InverseProperty("AssignedPartner")]
    // public virtual ICollection<ResPartner> InverseAssignedPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("AssociateMember")]
    // [InverseProperty("AssociateMemberNavigation")]
    // public virtual ICollection<ResPartner> InverseAssociateMemberNavigation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("CommercialPartnerId")]
    // [InverseProperty("CommercialPartner")]
    // public virtual ICollection<ResPartner> InverseCommercialPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("ParentId")]
    // [InverseProperty("Parent")]
    // public virtual ICollection<ResPartner> InverseParent { get; set; }

    // [Many2one]
    [ForeignKey("InvoiceTemplatePdfReportId")]
    // [InverseProperty("ResPartner")] //Many2one
    public virtual IrActReportXml? InvoiceTemplatePdfReport { get; set; }

    // [Many2one]
    [ForeignKey("LatestFollowupLevelIdWithoutLit")]
    // [InverseProperty("ResPartner")] //Many2one
    public virtual FollowupLine? LatestFollowupLevelIdWithoutLitNavigation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<LoyaltyCard> LoyaltyCard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<LunchSupplier> LunchSupplier { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("RequestPartnerId")]
    // [InverseProperty("RequestPartner")]
    // public virtual ICollection<MailActivity> MailActivity { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("LivechatOperatorId")]
    // [InverseProperty("LivechatOperator")]
    // public virtual ICollection<MailChannel> MailChannel { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<MailChannelMember> MailChannelMember { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("AuthorId")]
    // [InverseProperty("Author")]
    // public virtual ICollection<MailComposeMessage> MailComposeMessage { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<MailFollowers> MailFollowers { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<MailGroupMember> MailGroupMember { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("AuthorId")]
    // [InverseProperty("Author")]
    // public virtual ICollection<MailMessage> MailMessage { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<MailMessageReaction> MailMessageReaction { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("AuthorId")]
    // [InverseProperty("Author")]
    // public virtual ICollection<MailNotification> MailNotificationAuthor { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("ResPartnerId")]
    // [InverseProperty("ResPartner")]
    // public virtual ICollection<MailNotification> MailNotificationResPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<MailPushDevice> MailPushDevice { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("AuthorId")]
    // [InverseProperty("Author")]
    // public virtual ICollection<MailScheduledMessage> MailScheduledMessage { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<MailResendPartner> MailResendPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<MaintenanceEquipment> MaintenanceEquipment { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("Partner")]
    // [InverseProperty("PartnerNavigation")]
    // public virtual ICollection<MembershipMembershipLine> MembershipMembershipLine { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("ResPartner")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("SubcontractorId")]
    // [InverseProperty("Subcontractor")]
    // public virtual ICollection<MrpProduction> MrpProduction { get; set; }

    // [Many2one]
    [ForeignKey("ParentId")]
    // [InverseProperty("InverseParent")] //Many2one
    public virtual ResPartner? Parent { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<PaymentLinkWizard> PaymentLinkWizard { get; set; }

    // [Many2one]
    [ForeignKey("PaymentResponsibleId")]
    // [InverseProperty("ResPartnerPaymentResponsible")] //Many2one
    public virtual ResUsers? PaymentResponsible { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<PaymentToken> PaymentToken { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<PaymentTransaction> PaymentTransaction { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<PortalWizardUser> PortalWizardUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<PosOrder> PosOrder { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<ProcurementGroup> ProcurementGroup { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<ProductSupplierinfo> ProductSupplierinfo { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<ProductWishlist> ProductWishlist { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<ProjectCollaborator> ProjectCollaborator { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<ProjectCreateSaleOrder> ProjectCreateSaleOrder { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<ProjectProject> ProjectProject { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<ProjectShareCollaboratorWizard> ProjectShareCollaboratorWizard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<ProjectTask> ProjectTask { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("DestAddressId")]
    // [InverseProperty("DestAddress")]
    // public virtual ICollection<PurchaseOrder> PurchaseOrderDestAddress { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<PurchaseOrderLine> PurchaseOrderLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<PurchaseOrder> PurchaseOrderPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("VendorId")]
    // [InverseProperty("Vendor")]
    // public virtual ICollection<PurchaseRequisition> PurchaseRequisition { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<PurchaseRequisitionCreateAlternative> PurchaseRequisitionCreateAlternative { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<RatingRating> RatingRatingPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PublisherId")]
    // [InverseProperty("Publisher")]
    // public virtual ICollection<RatingRating> RatingRatingPublisher { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("RatedPartnerId")]
    // [InverseProperty("RatedPartner")]
    // public virtual ICollection<RatingRating> RatingRatingRatedPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<RecurringPayment> RecurringPayment { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<RecurringPaymentLine> RecurringPaymentLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<RepairOrder> RepairOrder { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("AddressId")]
    // [InverseProperty("Address")]
    // public virtual ICollection<RepairOrder> RepairOrderAddress { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<RepairOrder> RepairOrderPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerInvoiceId")]
    // [InverseProperty("PartnerInvoice")]
    // public virtual ICollection<RepairOrder> RepairOrderPartnerInvoice { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<ResCompany> ResCompany { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<ResPartnerAutocompleteSync> ResPartnerAutocompleteSync { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<ResPartnerBank> ResPartnerBank { get; set; }

    // [Many2one]
    // [InverseProperty("Partner")] //Many2one
    public virtual ResPartnerIap? ResPartnerIap { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<ResUsers> ResUsers { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("GuestId")]
    // [InverseProperty("Guest")]
    // public virtual ICollection<ResUsersSettingsVolumes> ResUsersSettingsVolumesGuest { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<ResUsersSettingsVolumes> ResUsersSettingsVolumesPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("AuthorId")]
    // [InverseProperty("Author")]
    // public virtual ICollection<SaleOrderCancel> SaleOrderCancel { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("OrderPartnerId")]
    // [InverseProperty("OrderPartner")]
    // public virtual ICollection<SaleOrderLine> SaleOrderLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<SaleOrder> SaleOrderPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerInvoiceId")]
    // [InverseProperty("PartnerInvoice")]
    // public virtual ICollection<SaleOrder> SaleOrderPartnerInvoice { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerShippingId")]
    // [InverseProperty("PartnerShipping")]
    // public virtual ICollection<SaleOrder> SaleOrderPartnerShipping { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<SlideChannelPartner> SlideChannelPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<SlideSlidePartner> SlideSlidePartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<SmsSms> SmsSms { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<SnailmailLetter> SnailmailLetter { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<SnailmailLetterMissingRequiredFields> SnailmailLetterMissingRequiredFields { get; set; }

    // [Many2one]
    [ForeignKey("StateId")]
    // [InverseProperty("ResPartner")] //Many2one
    public virtual ResCountryState? State { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("OwnerId")]
    // [InverseProperty("Owner")]
    // public virtual ICollection<StockMoveLine> StockMoveLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<StockMove> StockMovePartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("RestrictPartnerId")]
    // [InverseProperty("RestrictPartner")]
    // public virtual ICollection<StockMove> StockMoveRestrictPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("DriverId")]
    // [InverseProperty("Driver")]
    // public virtual ICollection<StockPickingBatch> StockPickingBatch { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("OwnerId")]
    // [InverseProperty("Owner")]
    // public virtual ICollection<StockPicking> StockPickingOwner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<StockPicking> StockPickingPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("OwnerId")]
    // [InverseProperty("Owner")]
    // public virtual ICollection<StockQuant> StockQuant { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerAddressId")]
    // [InverseProperty("PartnerAddress")]
    // public virtual ICollection<StockRule> StockRule { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("OwnerId")]
    // [InverseProperty("Owner")]
    // public virtual ICollection<StockScrap> StockScrap { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<StockWarehouse> StockWarehouse { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("ProductSupplierId")]
    // [InverseProperty("ProductSupplier")]
    // public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpointProductSupplier { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("VendorId")]
    // [InverseProperty("Vendor")]
    // public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpointVendor { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("VendorId")]
    // [InverseProperty("Vendor")]
    // public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpoint { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("AuthorId")]
    // [InverseProperty("Author")]
    // public virtual ICollection<SurveyInvite> SurveyInvite { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<SurveyUserInput> SurveyUserInput { get; set; }

    // [Many2one]
    [ForeignKey("TeamId")]
    // [InverseProperty("ResPartner")] //Many2one
    public virtual CrmTeam? Team { get; set; }

    // [Many2one]
    [ForeignKey("Title")]
    // [InverseProperty("ResPartner")] //Many2one
    public virtual ResPartnerTitle? TitleNavigation { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    // [InverseProperty("ResPartnerUser")] //Many2one
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("WebsiteId")]
    // [InverseProperty("ResPartner")] //Many2one
    public virtual Website? WebsiteNavigation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("LivechatOperatorId")]
    // [InverseProperty("LivechatOperator")]
    // public virtual ICollection<WebsiteVisitor> WebsiteVisitorLivechatOperator { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<WebsiteVisitor> WebsiteVisitorPartner { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("ResPartnerWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")]
    // [InverseProperty("ResPartner")]
    // public virtual ICollection<AccountAgedTrialBalance> AccountAgedTrialBalance { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")]
    // [InverseProperty("ResPartner")]
    // public virtual ICollection<AccountBalanceReport> AccountBalanceReport { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")]
    // [InverseProperty("ResPartner")]
    // public virtual ICollection<AccountCommonAccountReport> AccountCommonAccountReport { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")]
    // [InverseProperty("ResPartner")]
    // public virtual ICollection<AccountCommonPartnerReport> AccountCommonPartnerReport { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")]
    // [InverseProperty("ResPartner")]
    // public virtual ICollection<AccountMoveSendWizard> AccountMoveSendWizard { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")]
    // [InverseProperty("ResPartner")]
    // public virtual ICollection<AccountReconcileModel> AccountReconcileModel { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")]
    // [InverseProperty("ResPartner")]
    // public virtual ICollection<AccountReconcileModelTemplate> AccountReconcileModelTemplate { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")]
    // [InverseProperty("ResPartner")]
    // public virtual ICollection<AccountReportGeneralLedger> AccountReportGeneralLedger { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")]
    // [InverseProperty("ResPartner")]
    // public virtual ICollection<AccountReportPartnerLedger> AccountReportPartnerLedger { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")]
    // [InverseProperty("ResPartner")]
    // public virtual ICollection<BasePartnerMergeAutomaticWizard> BasePartnerMergeAutomaticWizardNavigation { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("ResPartnerId")] //Many2many
    // [InverseProperty("ResPartner")] //Many2many
    public virtual ICollection<CalendarEvent> CalendarEvent { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<ResPartnerCategory> Category { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<SurveyInvite> Invite { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")]
    // [InverseProperty("ResPartner")]
    // public virtual ICollection<IrActServer> IrActServer { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("PartnerId")]
    // [InverseProperty("PartnerNavigation")]
    // public virtual ICollection<CrmLead> Lead { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")]
    // [InverseProperty("ResPartner")]
    // public virtual ICollection<LoyaltyGenerateWizard> LoyaltyGenerateWizard { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")]
    // [InverseProperty("ResPartner")]
    // public virtual ICollection<MailMail> MailMail { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")]
    // [InverseProperty("ResPartnerNavigation")]
    // public virtual ICollection<MailMessage> MailMessage1 { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")]
    // [InverseProperty("ResPartner")]
    // public virtual ICollection<MailMessage> MailMessageNavigation { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")]
    // [InverseProperty("ResPartner")]
    // public virtual ICollection<MailScheduledMessage> MailScheduledMessageNavigation { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")]
    // [InverseProperty("ResPartner")]
    // public virtual ICollection<MailWizardInvite> MailWizardInvite { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<FleetVehicleModel> Model { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")]
    // [InverseProperty("ResPartner")]
    // public virtual ICollection<MrpBom> MrpBom { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")]
    // [InverseProperty("ResPartner")]
    // public virtual ICollection<PortalShare> PortalShare { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")]
    // [InverseProperty("ResPartner")]
    // public virtual ICollection<PortalWizard> PortalWizard { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")]
    // [InverseProperty("ResPartner")]
    // public virtual ICollection<ProductProduct> ProductProduct { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")]
    // [InverseProperty("ResPartner")]
    // public virtual ICollection<ProjectShareWizard> ProjectShareWizard { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")]
    // [InverseProperty("ResPartner")]
    // public virtual ICollection<SlideChannelInvite> SlideChannelInvite { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("PartnerId")] //Many2many
    // [InverseProperty("Partner")] //Many2many
    public virtual ICollection<ResPartnerTag> Tag { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("PartnerId")]
    // [InverseProperty("Partner")]
    // public virtual ICollection<MailComposeMessage> Wizard { get; set; }
}
