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

[Table("res_partner")]
//[Index("CommercialPartnerId", Name = "res_partner__commercial_partner_id_index")]
//[Index("CompanyId", Name = "res_partner__company_id_index")]
//[Index("CompleteName", Name = "res_partner__complete_name_index")]
//[Index("IsPublished", Name = "res_partner__is_published_index")]
//[Index("Name", Name = "res_partner__name_index")]
//[Index("ParentId", Name = "res_partner__parent_id_index")]
//[Index("Ref", Name = "res_partner__ref_index")]
//[Index("Vat", Name = "res_partner__vat_index")]
//[Index("WebsiteId", Name = "res_partner__website_id_index")]
public partial class ResPartner : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

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

    [JsonField] // Barcode
    [Column("barcode", TypeName = "jsonb")]
    public JsonElement? Barcode { get; set; }

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

    [Column("message_bounce")]
    public long? MessageBounce { get; set; }

    [Column("email_normalized")]
    public string? EmailNormalized { get; set; }

    [Column("signup_type")]
    public string? SignupType { get; set; }

    [JsonField] // SpecificPropertyProductPricelist
    [Column("specific_property_product_pricelist", TypeName = "jsonb")]
    public JsonElement? SpecificPropertyProductPricelist { get; set; }

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

    [JsonField] // CreditLimit
    [Column("credit_limit", TypeName = "jsonb")]
    public JsonElement? CreditLimit { get; set; }

    [JsonField] // PropertyAccountPayableId
    [Column("property_account_payable_id", TypeName = "jsonb")]
    public JsonElement? PropertyAccountPayableId { get; set; }

    [JsonField] // PropertyAccountReceivableId
    [Column("property_account_receivable_id", TypeName = "jsonb")]
    public JsonElement? PropertyAccountReceivableId { get; set; }

    [JsonField] // PropertyAccountPositionId
    [Column("property_account_position_id", TypeName = "jsonb")]
    public JsonElement? PropertyAccountPositionId { get; set; }

    [JsonField] // PropertyPaymentTermId
    [Column("property_payment_term_id", TypeName = "jsonb")]
    public JsonElement? PropertyPaymentTermId { get; set; }

    [JsonField] // PropertySupplierPaymentTermId
    [Column("property_supplier_payment_term_id", TypeName = "jsonb")]
    public JsonElement? PropertySupplierPaymentTermId { get; set; }

    [JsonField] // Trust
    [Column("trust", TypeName = "jsonb")]
    public JsonElement? Trust { get; set; }

    [JsonField] // IgnoreAbnormalInvoiceDate
    [Column("ignore_abnormal_invoice_date", TypeName = "jsonb")]
    public JsonElement? IgnoreAbnormalInvoiceDate { get; set; }

    [JsonField] // IgnoreAbnormalInvoiceAmount
    [Column("ignore_abnormal_invoice_amount", TypeName = "jsonb")]
    public JsonElement? IgnoreAbnormalInvoiceAmount { get; set; }

    [JsonField] // InvoiceSendingMethod
    [Column("invoice_sending_method", TypeName = "jsonb")]
    public JsonElement? InvoiceSendingMethod { get; set; }

    [JsonField] // InvoiceEdiFormatStore
    [Column("invoice_edi_format_store", TypeName = "jsonb")]
    public JsonElement? InvoiceEdiFormatStore { get; set; }

    [JsonField] // PropertyOutboundPaymentMethodLineId
    [Column("property_outbound_payment_method_line_id", TypeName = "jsonb")]
    public JsonElement? PropertyOutboundPaymentMethodLineId { get; set; }

    [JsonField] // PropertyInboundPaymentMethodLineId
    [Column("property_inbound_payment_method_line_id", TypeName = "jsonb")]
    public JsonElement? PropertyInboundPaymentMethodLineId { get; set; }

    [Column("invoice_warn_msg")]
    public string? InvoiceWarnMsg { get; set; }

    [Column("debit_limit")]
    public decimal? DebitLimit { get; set; }

    [Column("peppol_endpoint")]
    public string? PeppolEndpoint { get; set; }

    [Column("peppol_eas")]
    public string? PeppolEas { get; set; }

    [Column("sale_warn")]
    public string? SaleWarn { get; set; }

    [Column("sale_warn_msg")]
    public string? SaleWarnMsg { get; set; }

    [Column("picking_warn")]
    public string? PickingWarn { get; set; }

    [JsonField] // PropertyStockCustomer
    [Column("property_stock_customer", TypeName = "jsonb")]
    public JsonElement? PropertyStockCustomer { get; set; }

    [JsonField] // PropertyStockSupplier
    [Column("property_stock_supplier", TypeName = "jsonb")]
    public JsonElement? PropertyStockSupplier { get; set; }

    [Column("picking_warn_msg")]
    public string? PickingWarnMsg { get; set; }

    [Column("calendar_last_notif_ack", TypeName = "timestamp without time zone")]
    public DateTime? CalendarLastNotifAck { get; set; }

    [Column("buyer_id")]
    public Guid? BuyerId { get; set; }

    [Column("purchase_warn")]
    public string? PurchaseWarn { get; set; }

    [JsonField] // PropertyPurchaseCurrencyId
    [Column("property_purchase_currency_id", TypeName = "jsonb")]
    public JsonElement? PropertyPurchaseCurrencyId { get; set; }

    [JsonField] // ReceiptReminderEmail
    [Column("receipt_reminder_email", TypeName = "jsonb")]
    public JsonElement? ReceiptReminderEmail { get; set; }

    [JsonField] // ReminderDateBeforeReceipt
    [Column("reminder_date_before_receipt", TypeName = "jsonb")]
    public JsonElement? ReminderDateBeforeReceipt { get; set; }

    [Column("purchase_warn_msg")]
    public string? PurchaseWarnMsg { get; set; }

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

    [Column("plan_to_change_car")]
    public bool? PlanToChangeCar { get; set; }

    [Column("plan_to_change_bike")]
    public bool? PlanToChangeBike { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("is_published")]
    public bool? IsPublished { get; set; }

    [JsonField] // PropertyDeliveryCarrierId
    [Column("property_delivery_carrier_id", TypeName = "jsonb")]
    public JsonElement? PropertyDeliveryCarrierId { get; set; }

    [Column("website_meta_og_img")]
    public string? WebsiteMetaOgImg { get; set; }

    [JsonField(IsSparse = false)] // WebsiteMetaTitle
    [Column("website_meta_title", TypeName = "jsonb")]
    public StringDictionary? WebsiteMetaTitle { get; set; }

    [JsonField(IsSparse = false)] // WebsiteMetaDescription
    [Column("website_meta_description", TypeName = "jsonb")]
    public StringDictionary? WebsiteMetaDescription { get; set; }

    [JsonField] // WebsiteMetaKeywords
    [Column("website_meta_keywords", TypeName = "jsonb")]
    public JsonElement? WebsiteMetaKeywords { get; set; }

    [JsonField(IsSparse = false)] // SeoName
    [Column("seo_name", TypeName = "jsonb")]
    public StringDictionary? SeoName { get; set; }

    [JsonField(IsSparse = false)] // WebsiteDescription
    [Column("website_description", TypeName = "jsonb")]
    public StringDictionary? WebsiteDescription { get; set; }

    [JsonField(IsSparse = false)] // WebsiteShortDescription
    [Column("website_short_description", TypeName = "jsonb")]
    public StringDictionary? WebsiteShortDescription { get; set; }

    [Column("slug")]
    public string? Slug { get; set; }

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

    [JsonField] // PropertyStockSubcontractor
    [Column("property_stock_subcontractor", TypeName = "jsonb")]
    public JsonElement? PropertyStockSubcontractor { get; set; }

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

    [JsonField] // PeppolVerificationState
    [Column("peppol_verification_state", TypeName = "jsonb")]
    public JsonElement? PeppolVerificationState { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (AccountAnalyticAccount) is commented out
    // public virtual ICollection<AccountAnalyticAccount> AccountAnalyticAccount { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (AccountAnalyticDistributionModel) is commented out
    // public virtual ICollection<AccountAnalyticDistributionModel> AccountAnalyticDistributionModel { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (AccountAnalyticLine) is commented out
    // public virtual ICollection<AccountAnalyticLine> AccountAnalyticLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (AccountAssetAsset) is commented out
    // public virtual ICollection<AccountAssetAsset> AccountAssetAsset { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (AccountAutopostBillsWizard) is commented out
    // public virtual ICollection<AccountAutopostBillsWizard> AccountAutopostBillsWizard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (AccountBankStatementLine) is commented out
    // public virtual ICollection<AccountBankStatementLine> AccountBankStatementLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("CommercialPartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CommercialPartner")] // One2many // Peer relationship (AccountMove) is commented out
    // public virtual ICollection<AccountMove> AccountMoveCommercialPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (AccountMoveLine) is commented out
    // public virtual ICollection<AccountMoveLine> AccountMoveLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (AccountMove) is commented out
    // public virtual ICollection<AccountMove> AccountMovePartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerShippingId")]
    // [NotMapped] // One2many 
    // [InverseProperty("PartnerShipping")] // One2many // Peer relationship (AccountMove) is commented out
    // public virtual ICollection<AccountMove> AccountMovePartnerShipping { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (AccountPayment) is commented out
    // public virtual ICollection<AccountPayment> AccountPayment { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (AccountPaymentRegister) is commented out
    // public virtual ICollection<AccountPaymentRegister> AccountPaymentRegister { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (AccountReconcileModelPartnerMapping) is commented out
    // public virtual ICollection<AccountReconcileModelPartnerMapping> AccountReconcileModelPartnerMapping { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("Activation")]
    public virtual ResPartnerActivation? ActivationNavigation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("AuthorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Author")] // One2many // Peer relationship (ApplicantSendMail) is commented out
    // public virtual ICollection<ApplicantSendMail> ApplicantSendMail { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AssignedPartnerId")]
    public virtual ResPartner? AssignedPartner { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("AssociateMember")]
    public virtual ResPartner? AssociateMemberNavigation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("DstPartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("DstPartner")] // One2many // Peer relationship (BasePartnerMergeAutomaticWizard) is commented out
    // public virtual ICollection<BasePartnerMergeAutomaticWizard> BasePartnerMergeAutomaticWizard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (BillToPoWizard) is commented out
    // public virtual ICollection<BillToPoWizard> BillToPoWizard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("AuthorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Author")] // One2many // Peer relationship (BlogPost) is commented out
    // public virtual ICollection<BlogPost> BlogPost { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("BuyerId")]
    public virtual ResUsers? Buyer { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (CalendarAttendee) is commented out
    // public virtual ICollection<CalendarAttendee> CalendarAttendee { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (CalendarFilters) is commented out
    // public virtual ICollection<CalendarFilters> CalendarFilters { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("AuthorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Author")] // One2many // Peer relationship (CandidateSendMail) is commented out
    // public virtual ICollection<CandidateSendMail> CandidateSendMail { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("OperatorPartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("OperatorPartner")] // One2many // Peer relationship (ChatbotScript) is commented out
    // public virtual ICollection<ChatbotScript> ChatbotScript { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CityId")]
    public virtual ResCity? CityNavigation { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CommercialPartnerId")]
    public virtual ResPartner? CommercialPartner { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CountryId")]
    public virtual ResCountry? Country { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (CrmLead2opportunityPartner) is commented out
    // public virtual ICollection<CrmLead2opportunityPartner> CrmLead2opportunityPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (CrmLead2opportunityPartnerMass) is commented out
    // public virtual ICollection<CrmLead2opportunityPartnerMass> CrmLead2opportunityPartnerMass { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerAssignedId")]
    // [NotMapped] // One2many 
    // [InverseProperty("PartnerAssigned")] // One2many // Peer relationship (CrmLeadAssignation) is commented out
    // public virtual ICollection<CrmLeadAssignation> CrmLeadAssignation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (CrmLeadForwardToPartner) is commented out
    // public virtual ICollection<CrmLeadForwardToPartner> CrmLeadForwardToPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (CrmLead) is commented out
    // public virtual ICollection<CrmLead> CrmLeadPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerAssignedId")]
    // [NotMapped] // One2many 
    // [InverseProperty("PartnerAssigned")] // One2many // Peer relationship (CrmLead) is commented out
    // public virtual ICollection<CrmLead> CrmLeadPartnerAssigned { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (CrmQuotationPartner) is commented out
    // public virtual ICollection<CrmQuotationPartner> CrmQuotationPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("LivechatOperatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("LivechatOperator")] // One2many // Peer relationship (DiscussChannel) is commented out
    // public virtual ICollection<DiscussChannel> DiscussChannel { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (DiscussChannelMember) is commented out
    // public virtual ICollection<DiscussChannelMember> DiscussChannelMember { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (EventBooth) is commented out
    // public virtual ICollection<EventBooth> EventBooth { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (EventBoothRegistration) is commented out
    // public virtual ICollection<EventBoothRegistration> EventBoothRegistration { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("AddressId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Address")] // One2many // Peer relationship (EventEvent) is commented out
    // public virtual ICollection<EventEvent> EventEventAddress { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("OrganizerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Organizer")] // One2many // Peer relationship (EventEvent) is commented out
    // public virtual ICollection<EventEvent> EventEventOrganizer { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (EventRegistration) is commented out
    // public virtual ICollection<EventRegistration> EventRegistration { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (EventSponsor) is commented out
    // public virtual ICollection<EventSponsor> EventSponsor { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (EventTrack) is commented out
    // public virtual ICollection<EventTrack> EventTrack { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (EventTrackVisitor) is commented out
    // public virtual ICollection<EventTrackVisitor> EventTrackVisitor { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("DriverId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Driver")] // One2many // Peer relationship (FleetVehicleAssignationLog) is commented out
    // public virtual ICollection<FleetVehicleAssignationLog> FleetVehicleAssignationLog { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("DriverId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Driver")] // One2many // Peer relationship (FleetVehicle) is commented out
    // public virtual ICollection<FleetVehicle> FleetVehicleDriver { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("FutureDriverId")]
    // [NotMapped] // One2many 
    // [InverseProperty("FutureDriver")] // One2many // Peer relationship (FleetVehicle) is commented out
    // public virtual ICollection<FleetVehicle> FleetVehicleFutureDriver { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("InsurerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Insurer")] // One2many // Peer relationship (FleetVehicleLogContract) is commented out
    // public virtual ICollection<FleetVehicleLogContract> FleetVehicleLogContract { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PurchaserId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Purchaser")] // One2many // Peer relationship (FleetVehicleLogServices) is commented out
    // public virtual ICollection<FleetVehicleLogServices> FleetVehicleLogServicesPurchaser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("VendorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Vendor")] // One2many // Peer relationship (FleetVehicleLogServices) is commented out
    // public virtual ICollection<FleetVehicleLogServices> FleetVehicleLogServicesVendor { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("AuthorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Author")] // One2many // Peer relationship (FleetVehicleSendMail) is commented out
    // public virtual ICollection<FleetVehicleSendMail> FleetVehicleSendMail { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("GradeId")]
    public virtual ResPartnerGrade? Grade { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (HrCandidate) is commented out
    // public virtual ICollection<HrCandidate> HrCandidate { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (HrContributionRegister) is commented out
    // public virtual ICollection<HrContributionRegister> HrContributionRegister { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("AddressId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Address")] // One2many // Peer relationship (HrEmployee) is commented out
    // public virtual ICollection<HrEmployee> HrEmployeeAddress { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("WorkContactId")]
    // [NotMapped] // One2many 
    // [InverseProperty("WorkContact")] // One2many // Peer relationship (HrEmployee) is commented out
    // public virtual ICollection<HrEmployee> HrEmployeeWorkContact { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("VendorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Vendor")] // One2many // Peer relationship (HrExpense) is commented out
    // public virtual ICollection<HrExpense> HrExpense { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("AddressId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Address")] // One2many // Peer relationship (HrJob) is commented out
    // public virtual ICollection<HrJob> HrJob { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("AddressId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Address")] // One2many // Peer relationship (HrWorkLocation) is commented out
    // public virtual ICollection<HrWorkLocation> HrWorkLocation { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("IndustryId")]
    public virtual ResPartnerIndustry? Industry { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("AssignedPartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("AssignedPartner")] // One2many
    // public virtual ICollection<ResPartner> InverseAssignedPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("AssociateMember")]
    // [NotMapped] // One2many 
    // [InverseProperty("AssociateMemberNavigation")] // One2many
    // public virtual ICollection<ResPartner> InverseAssociateMemberNavigation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("CommercialPartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("CommercialPartner")] // One2many
    // public virtual ICollection<ResPartner> InverseCommercialPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("ParentId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Parent")] // One2many
    // public virtual ICollection<ResPartner> InverseParent { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("InvoiceTemplatePdfReportId")]
    public virtual IrActReportXml? InvoiceTemplatePdfReport { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (LoyaltyCard) is commented out
    // public virtual ICollection<LoyaltyCard> LoyaltyCard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (LunchSupplier) is commented out
    // public virtual ICollection<LunchSupplier> LunchSupplier { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("RequestPartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("RequestPartner")] // One2many // Peer relationship (MailActivity) is commented out
    // public virtual ICollection<MailActivity> MailActivity { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("AuthorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Author")] // One2many // Peer relationship (MailComposeMessage) is commented out
    // public virtual ICollection<MailComposeMessage> MailComposeMessage { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (MailFollowers) is commented out
    // public virtual ICollection<MailFollowers> MailFollowers { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (MailGroupMember) is commented out
    // public virtual ICollection<MailGroupMember> MailGroupMember { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("AuthorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Author")] // One2many // Peer relationship (MailMessage) is commented out
    // public virtual ICollection<MailMessage> MailMessage { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (MailMessageReaction) is commented out
    // public virtual ICollection<MailMessageReaction> MailMessageReaction { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("AuthorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Author")] // One2many // Peer relationship (MailNotification) is commented out
    // public virtual ICollection<MailNotification> MailNotificationAuthor { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("ResPartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("ResPartner")] // One2many // Peer relationship (MailNotification) is commented out
    // public virtual ICollection<MailNotification> MailNotificationResPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (MailPushDevice) is commented out
    // public virtual ICollection<MailPushDevice> MailPushDevice { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("AuthorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Author")] // One2many // Peer relationship (MailScheduledMessage) is commented out
    // public virtual ICollection<MailScheduledMessage> MailScheduledMessage { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (MaintenanceEquipment) is commented out
    // public virtual ICollection<MaintenanceEquipment> MaintenanceEquipment { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("Partner")]
    // [NotMapped] // One2many 
    // [InverseProperty("PartnerNavigation")] // One2many // Peer relationship (MembershipMembershipLine) is commented out
    // public virtual ICollection<MembershipMembershipLine> MembershipMembershipLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("SubcontractorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Subcontractor")] // One2many // Peer relationship (MrpProduction) is commented out
    // public virtual ICollection<MrpProduction> MrpProduction { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ParentId")]
    public virtual ResPartner? Parent { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (PaymentLinkWizard) is commented out
    // public virtual ICollection<PaymentLinkWizard> PaymentLinkWizard { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("PaymentResponsibleId")]
    public virtual ResUsers? PaymentResponsible { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (PaymentToken) is commented out
    // public virtual ICollection<PaymentToken> PaymentToken { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (PaymentTransaction) is commented out
    // public virtual ICollection<PaymentTransaction> PaymentTransaction { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (PortalWizardUser) is commented out
    // public virtual ICollection<PortalWizardUser> PortalWizardUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (PosOrder) is commented out
    // public virtual ICollection<PosOrder> PosOrder { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (ProcurementGroup) is commented out
    // public virtual ICollection<ProcurementGroup> ProcurementGroup { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (ProductSupplierinfo) is commented out
    // public virtual ICollection<ProductSupplierinfo> ProductSupplierinfo { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (ProductWishlist) is commented out
    // public virtual ICollection<ProductWishlist> ProductWishlist { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (ProjectCollaborator) is commented out
    // public virtual ICollection<ProjectCollaborator> ProjectCollaborator { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (ProjectProject) is commented out
    // public virtual ICollection<ProjectProject> ProjectProject { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (ProjectShareCollaboratorWizard) is commented out
    // public virtual ICollection<ProjectShareCollaboratorWizard> ProjectShareCollaboratorWizard { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (ProjectTask) is commented out
    // public virtual ICollection<ProjectTask> ProjectTask { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("DestAddressId")]
    // [NotMapped] // One2many 
    // [InverseProperty("DestAddress")] // One2many // Peer relationship (PurchaseOrder) is commented out
    // public virtual ICollection<PurchaseOrder> PurchaseOrderDestAddress { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (PurchaseOrderLine) is commented out
    // public virtual ICollection<PurchaseOrderLine> PurchaseOrderLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (PurchaseOrder) is commented out
    // public virtual ICollection<PurchaseOrder> PurchaseOrderPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("VendorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Vendor")] // One2many // Peer relationship (PurchaseRequisition) is commented out
    // public virtual ICollection<PurchaseRequisition> PurchaseRequisition { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (PurchaseRequisitionCreateAlternative) is commented out
    // public virtual ICollection<PurchaseRequisitionCreateAlternative> PurchaseRequisitionCreateAlternative { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (RatingRating) is commented out
    // public virtual ICollection<RatingRating> RatingRatingPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PublisherId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Publisher")] // One2many // Peer relationship (RatingRating) is commented out
    // public virtual ICollection<RatingRating> RatingRatingPublisher { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("RatedPartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("RatedPartner")] // One2many // Peer relationship (RatingRating) is commented out
    // public virtual ICollection<RatingRating> RatingRatingRatedPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (RecurringPayment) is commented out
    // public virtual ICollection<RecurringPayment> RecurringPayment { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (RecurringPaymentLine) is commented out
    // public virtual ICollection<RecurringPaymentLine> RecurringPaymentLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (RepairOrder) is commented out
    // public virtual ICollection<RepairOrder> RepairOrder { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many
    // public virtual ICollection<ResCompany> ResCompany { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (ResPartnerAutocompleteSync) is commented out
    // public virtual ICollection<ResPartnerAutocompleteSync> ResPartnerAutocompleteSync { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (ResPartnerBank) is commented out
    // public virtual ICollection<ResPartnerBank> ResPartnerBank { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public virtual ResPartnerIap? ResPartnerIap { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many
    // public virtual ICollection<ResUsers> ResUsers { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("GuestId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Guest")] // One2many // Peer relationship (ResUsersSettingsVolumes) is commented out
    // public virtual ICollection<ResUsersSettingsVolumes> ResUsersSettingsVolumesGuest { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (ResUsersSettingsVolumes) is commented out
    // public virtual ICollection<ResUsersSettingsVolumes> ResUsersSettingsVolumesPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("AuthorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Author")] // One2many // Peer relationship (SaleOrderCancel) is commented out
    // public virtual ICollection<SaleOrderCancel> SaleOrderCancel { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("OrderPartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("OrderPartner")] // One2many // Peer relationship (SaleOrderLine) is commented out
    // public virtual ICollection<SaleOrderLine> SaleOrderLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (SaleOrder) is commented out
    // public virtual ICollection<SaleOrder> SaleOrderPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerInvoiceId")]
    // [NotMapped] // One2many 
    // [InverseProperty("PartnerInvoice")] // One2many // Peer relationship (SaleOrder) is commented out
    // public virtual ICollection<SaleOrder> SaleOrderPartnerInvoice { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerShippingId")]
    // [NotMapped] // One2many 
    // [InverseProperty("PartnerShipping")] // One2many // Peer relationship (SaleOrder) is commented out
    // public virtual ICollection<SaleOrder> SaleOrderPartnerShipping { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (SlideChannelPartner) is commented out
    // public virtual ICollection<SlideChannelPartner> SlideChannelPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (SlideSlidePartner) is commented out
    // public virtual ICollection<SlideSlidePartner> SlideSlidePartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (SmsSms) is commented out
    // public virtual ICollection<SmsSms> SmsSms { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (SnailmailLetter) is commented out
    // public virtual ICollection<SnailmailLetter> SnailmailLetter { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (SnailmailLetterMissingRequiredFields) is commented out
    // public virtual ICollection<SnailmailLetterMissingRequiredFields> SnailmailLetterMissingRequiredFields { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("StateId")]
    public virtual ResCountryState? State { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("OwnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Owner")] // One2many // Peer relationship (StockMoveLine) is commented out
    // public virtual ICollection<StockMoveLine> StockMoveLine { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (StockMove) is commented out
    // public virtual ICollection<StockMove> StockMovePartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("RestrictPartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("RestrictPartner")] // One2many // Peer relationship (StockMove) is commented out
    // public virtual ICollection<StockMove> StockMoveRestrictPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("DriverId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Driver")] // One2many // Peer relationship (StockPickingBatch) is commented out
    // public virtual ICollection<StockPickingBatch> StockPickingBatch { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("OwnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Owner")] // One2many // Peer relationship (StockPicking) is commented out
    // public virtual ICollection<StockPicking> StockPickingOwner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (StockPicking) is commented out
    // public virtual ICollection<StockPicking> StockPickingPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("OwnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Owner")] // One2many // Peer relationship (StockQuant) is commented out
    // public virtual ICollection<StockQuant> StockQuant { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerAddressId")]
    // [NotMapped] // One2many 
    // [InverseProperty("PartnerAddress")] // One2many // Peer relationship (StockRule) is commented out
    // public virtual ICollection<StockRule> StockRule { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("OwnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Owner")] // One2many // Peer relationship (StockScrap) is commented out
    // public virtual ICollection<StockScrap> StockScrap { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (StockWarehouse) is commented out
    // public virtual ICollection<StockWarehouse> StockWarehouse { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("ProductSupplierId")]
    // [NotMapped] // One2many 
    // [InverseProperty("ProductSupplier")] // One2many // Peer relationship (StockWarehouseOrderpoint) is commented out
    // public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpointProductSupplier { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("VendorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Vendor")] // One2many // Peer relationship (StockWarehouseOrderpoint) is commented out
    // public virtual ICollection<StockWarehouseOrderpoint> StockWarehouseOrderpointVendor { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("AuthorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Author")] // One2many // Peer relationship (SurveyInvite) is commented out
    // public virtual ICollection<SurveyInvite> SurveyInvite { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (SurveyUserInput) is commented out
    // public virtual ICollection<SurveyUserInput> SurveyUserInput { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("Title")]
    public virtual ResPartnerTitle? TitleNavigation { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("UserId")]
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("WebsiteId")]
    public virtual Website? WebsiteNavigation { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("LivechatOperatorId")]
    // [NotMapped] // One2many 
    // [InverseProperty("LivechatOperator")] // One2many // Peer relationship (WebsiteVisitor) is commented out
    // public virtual ICollection<WebsiteVisitor> WebsiteVisitorLivechatOperator { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'ResPartner'
    // [One2many] [ForeignKey("PartnerId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Partner")] // One2many // Peer relationship (WebsiteVisitor) is commented out
    // public virtual ICollection<WebsiteVisitor> WebsiteVisitorPartner { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")] //Many2many // Hidden
    // [InverseProperty("ResPartner")] //Many2many // Hidden
    public virtual ICollection<AccountAgedTrialBalance> AccountAgedTrialBalance { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")] //Many2many // Hidden
    // [InverseProperty("ResPartner")] //Many2many // Hidden
    public virtual ICollection<AccountBalanceReport> AccountBalanceReport { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")] //Many2many // Hidden
    // [InverseProperty("ResPartner")] //Many2many // Hidden
    public virtual ICollection<AccountCommonAccountReport> AccountCommonAccountReport { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")] //Many2many // Hidden
    // [InverseProperty("ResPartner")] //Many2many // Hidden
    public virtual ICollection<AccountCommonPartnerReport> AccountCommonPartnerReport { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")] //Many2many // Hidden
    // [InverseProperty("ResPartner")] //Many2many // Hidden
    public virtual ICollection<AccountMoveSendWizard> AccountMoveSendWizard { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")] //Many2many // Hidden
    // [InverseProperty("ResPartner")] //Many2many // Hidden
    public virtual ICollection<AccountReconcileModel> AccountReconcileModel { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")] //Many2many // Hidden
    // [InverseProperty("ResPartner")] //Many2many // Hidden
    public virtual ICollection<AccountReportGeneralLedger> AccountReportGeneralLedger { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")] //Many2many // Hidden
    // [InverseProperty("ResPartner")] //Many2many // Hidden
    public virtual ICollection<AccountReportPartnerLedger> AccountReportPartnerLedger { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")] //Many2many // Hidden
    // [InverseProperty("ResPartner")] //Many2many // Hidden
    public virtual ICollection<BasePartnerMergeAutomaticWizard> BasePartnerMergeAutomaticWizardNavigation { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("ResPartnerId")] // Many2many // Normal
    // [InverseProperty("ResPartner")] // Many2many // Normal
    public virtual ICollection<CalendarEvent> CalendarEvent { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("PartnerId")] //Many2many // Hidden
    // [InverseProperty("Partner")] //Many2many // Hidden
    public virtual ICollection<ResPartnerCategory> Category { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("PartnerId")] //Many2many // Hidden
    // [InverseProperty("Partner")] //Many2many // Hidden
    public virtual ICollection<SurveyInvite> Invite { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")] //Many2many // Hidden
    // [InverseProperty("ResPartner")] //Many2many // Hidden
    public virtual ICollection<IrActServer> IrActServer { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("PartnerId")] //Many2many // Hidden
    // [InverseProperty("PartnerNavigation")] //Many2many // Hidden
    public virtual ICollection<CrmLead> Lead { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")] //Many2many // Hidden
    // [InverseProperty("ResPartner")] //Many2many // Hidden
    public virtual ICollection<LoyaltyGenerateWizard> LoyaltyGenerateWizard { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")] //Many2many // Hidden
    // [InverseProperty("ResPartner")] //Many2many // Hidden
    public virtual ICollection<MailMail> MailMail { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")] //Many2many // Hidden
    // [InverseProperty("ResPartnerNavigation")] //Many2many // Hidden
    public virtual ICollection<MailMessage> MailMessage1 { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")] //Many2many // Hidden
    // [InverseProperty("ResPartner")] //Many2many // Hidden
    public virtual ICollection<MailMessage> MailMessageNavigation { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")] //Many2many // Hidden
    // [InverseProperty("ResPartner")] //Many2many // Hidden
    public virtual ICollection<MailScheduledMessage> MailScheduledMessageNavigation { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")] //Many2many // Hidden
    // [InverseProperty("ResPartner")] //Many2many // Hidden
    public virtual ICollection<MailWizardInvite> MailWizardInvite { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("PartnerId")] //Many2many // Hidden
    // [InverseProperty("Partner")] //Many2many // Hidden
    public virtual ICollection<FleetVehicleModel> Model { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")] //Many2many // Hidden
    // [InverseProperty("ResPartner")] //Many2many // Hidden
    public virtual ICollection<MrpBom> MrpBom { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")] //Many2many // Hidden
    // [InverseProperty("ResPartner")] //Many2many // Hidden
    public virtual ICollection<PortalShare> PortalShare { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")] //Many2many // Hidden
    // [InverseProperty("ResPartner")] //Many2many // Hidden
    public virtual ICollection<PortalWizard> PortalWizard { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]

    [NotMapped] //Many2many // Hidden // Peer relationship (ProductProduct) is commented out
    // [ForeignKey("ResPartnerId")] //Many2many // Hidden
    // [InverseProperty("ResPartner")] //Many2many // Hidden
    public virtual ICollection<ProductProduct> ProductProduct { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")] //Many2many // Hidden
    // [InverseProperty("ResPartner")] //Many2many // Hidden
    public virtual ICollection<ProjectShareWizard> ProjectShareWizard { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("ResPartnerId")] //Many2many // Hidden
    // [InverseProperty("ResPartner")] //Many2many // Hidden
    public virtual ICollection<SlideChannelInvite> SlideChannelInvite { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("PartnerId")] // Many2many // Normal
    // [InverseProperty("Partner")] // Many2many // Normal
    public virtual ICollection<ResPartnerTag> Tag { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("PartnerId")] //Many2many // Hidden
    // [InverseProperty("Partner")] //Many2many // Hidden
    public virtual ICollection<MailComposeMessage> Wizard { get; set; }
}
