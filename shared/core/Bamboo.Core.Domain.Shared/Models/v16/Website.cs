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

[Table("website")]
//[Index("Domain", Name = "website_domain_unique", IsUnique = true)]
public partial class Website: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("default_lang_id")]
    public Guid? DefaultLangId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("theme_id")]
    public Guid? ThemeId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("domain")]
    public string? Domain { get; set; }

    [Column("social_twitter")]
    public string? SocialTwitter { get; set; }

    [Column("social_facebook")]
    public string? SocialFacebook { get; set; }

    [Column("social_github")]
    public string? SocialGithub { get; set; }

    [Column("social_linkedin")]
    public string? SocialLinkedin { get; set; }

    [Column("social_youtube")]
    public string? SocialYoutube { get; set; }

    [Column("social_instagram")]
    public string? SocialInstagram { get; set; }

    [Column("social_tiktok")]
    public string? SocialTiktok { get; set; }

    [Column("google_analytics_key")]
    public string? GoogleAnalyticsKey { get; set; }

    [Column("google_search_console")]
    public string? GoogleSearchConsole { get; set; }

    [Column("google_maps_api_key")]
    public string? GoogleMapsApiKey { get; set; }

    [Column("plausible_shared_key")]
    public string? PlausibleSharedKey { get; set; }

    [Column("plausible_site")]
    public string? PlausibleSite { get; set; }

    [Column("cdn_url")]
    public string? CdnUrl { get; set; }

    [Column("homepage_url")]
    public string? HomepageUrl { get; set; }

    [Column("auth_signup_uninvited")]
    public string? AuthSignupUninvited { get; set; }

    [Column("custom_blocked_third_party_domains")]
    public string? CustomBlockedThirdPartyDomains { get; set; }

    [Column("cdn_filters")]
    public string? CdnFilters { get; set; }

    [Column("custom_code_head")]
    public string? CustomCodeHead { get; set; }

    [Column("custom_code_footer")]
    public string? CustomCodeFooter { get; set; }

    [Column("robots_txt")]
    public string? RobotsTxt { get; set; }

    [Column("auto_redirect_lang")]
    public bool? AutoRedirectLang { get; set; }

    [Column("cookies_bar")]
    public bool? CookiesBar { get; set; }

    [Column("configurator_done")]
    public bool? ConfiguratorDone { get; set; }

    [Column("block_third_party_domains")]
    public bool? BlockThirdPartyDomains { get; set; }

    [Column("has_social_default_image")]
    public bool? HasSocialDefaultImage { get; set; }

    [Column("cdn_activated")]
    public bool? CdnActivated { get; set; }

    [Column("specific_user_account")]
    public bool? SpecificUserAccount { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("crm_default_team_id")]
    public Guid? CrmDefaultTeamId { get; set; }

    [Column("crm_default_user_id")]
    public Guid? CrmDefaultUserId { get; set; }

    [Column("salesperson_id")]
    public Guid? SalespersonId { get; set; }

    [Column("salesteam_id")]
    public Guid? SalesteamId { get; set; }

    [Column("cart_recovery_mail_template_id")]
    public Guid? CartRecoveryMailTemplateId { get; set; }

    [Column("shop_ppg")]
    public long? ShopPpg { get; set; }

    [Column("shop_ppr")]
    public long? ShopPpr { get; set; }

    [Column("product_page_grid_columns")]
    public long? ProductPageGridColumns { get; set; }

    [Column("shop_default_sort")]
    public string? ShopDefaultSort { get; set; }

    [Column("show_line_subtotals_tax_selection")]
    public string? ShowLineSubtotalsTaxSelection { get; set; }

    [Column("add_to_cart_action")]
    public string? AddToCartAction { get; set; }

    [Column("account_on_checkout")]
    public string? AccountOnCheckout { get; set; }

    [Column("shop_gap")]
    public string? ShopGap { get; set; }

    // [Column("shop_default_sort")]
    // public string? ShopDefaultSort { get; set; }

    [Column("product_page_image_layout")]
    public string? ProductPageImageLayout { get; set; }

    [Column("product_page_image_width")]
    public string? ProductPageImageWidth { get; set; }

    [Column("product_page_image_spacing")]
    public string? ProductPageImageSpacing { get; set; }

    [Column("ecommerce_access")]
    public string? EcommerceAccess { get; set; }

    [JsonField]
    [Column("prevent_zero_price_sale_text", TypeName = "jsonb")]
    public string? PreventZeroPriceSaleText { get; set; }

    [JsonField]
    [Column("contact_us_button_url", TypeName = "jsonb")]
    public string? ContactUsButtonUrl { get; set; }

    // [JsonField]
    // [Column("prevent_zero_price_sale_text", TypeName = "jsonb")]
    // public string? PreventZeroPriceSaleText { get; set; }

    [Column("enabled_portal_reorder_button")]
    public bool? EnabledPortalReorderButton { get; set; }

    [Column("send_abandoned_cart_email")]
    public bool? SendAbandonedCartEmail { get; set; }

    [Column("prevent_zero_price_sale")]
    public bool? PreventZeroPriceSale { get; set; }

    // [Column("enabled_portal_reorder_button")]
    // public bool? EnabledPortalReorderButton { get; set; }

    [Column("cart_abandoned_delay")]
    public double? CartAbandonedDelay { get; set; }

    [Column("warehouse_id")]
    public Guid? WarehouseId { get; set; }

    [Column("karma_profile_min")]
    public long? KarmaProfileMin { get; set; }

    [Column("website_slide_google_app_key")]
    public string? WebsiteSlideGoogleAppKey { get; set; }

    [Column("channel_id")]
    public Guid? ChannelId { get; set; }

    [Column("newsletter_id")]
    public Guid? NewsletterId { get; set; }

    [Column("forum_count")]
    public long? ForumCount { get; set; }

    [Column("forums_count")]
    public long? ForumsCount { get; set; }

    [Column("events_app_name")]
    public string? EventsAppName { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'Website'
    // [ForeignKey("WebsiteId")]
    // [InverseProperty("Website")]
    // public virtual ICollection<AccountMove> AccountMove { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'Website'
    // [ForeignKey("WebsiteId")]
    // [InverseProperty("Website")]
    // public virtual ICollection<BlogBlog> BlogBlog { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'Website'
    // [ForeignKey("WebsiteId")]
    // [InverseProperty("Website")]
    // public virtual ICollection<BlogPost> BlogPost { get; set; }

    // [Many2one]
    [ForeignKey("CartRecoveryMailTemplateId")]
    // [InverseProperty("Website")] //Many2one
    public virtual MailTemplate? CartRecoveryMailTemplate { get; set; }

    // [Many2one]
    [ForeignKey("ChannelId")]
    // [InverseProperty("Website")] //Many2one
    public virtual ImLivechatChannel? Channel { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("WebsiteNavigation")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'Website'
    // [ForeignKey("WebsiteId")]
    // [InverseProperty("Website")]
    // public virtual ICollection<CouponShare> CouponShare { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("WebsiteCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("CrmDefaultTeamId")]
    // [InverseProperty("WebsiteCrmDefaultTeam")] //Many2one
    public virtual CrmTeam? CrmDefaultTeam { get; set; }

    // [Many2one]
    [ForeignKey("CrmDefaultUserId")]
    // [InverseProperty("WebsiteCrmDefaultUser")] //Many2one
    public virtual ResUsers? CrmDefaultUser { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'Website'
    // [ForeignKey("WebsiteId")]
    // [InverseProperty("Website")]
    // public virtual ICollection<CrmRevealRule> CrmRevealRule { get; set; }

    // [Many2one]
    [ForeignKey("DefaultLangId")]
    // [InverseProperty("Website")] //Many2one
    public virtual ResLang? DefaultLang { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'Website'
    // [ForeignKey("WebsiteId")]
    // [InverseProperty("Website")]
    // public virtual ICollection<DeliveryCarrier> DeliveryCarrier { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'Website'
    // [ForeignKey("WebsiteId")]
    // [InverseProperty("Website")]
    // public virtual ICollection<EventEvent> EventEvent { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'Website'
    // [ForeignKey("WebsiteId")]
    // [InverseProperty("Website")]
    // public virtual ICollection<EventTag> EventTag { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'Website'
    // [ForeignKey("WebsiteId")]
    // [InverseProperty("Website")]
    // public virtual ICollection<EventTagCategory> EventTagCategory { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'Website'
    // [ForeignKey("WebsiteId")]
    // [InverseProperty("Website")]
    // public virtual ICollection<ForumForum> ForumForum { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'Website'
    // [ForeignKey("WebsiteId")]
    // [InverseProperty("Website")]
    // public virtual ICollection<HrJob> HrJob { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'Website'
    // [ForeignKey("WebsiteId")]
    // [InverseProperty("Website")]
    // public virtual ICollection<IrAsset> IrAsset { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'Website'
    // [ForeignKey("WebsiteId")]
    // [InverseProperty("Website")]
    // public virtual ICollection<IrAttachment> IrAttachment { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'Website'
    // [ForeignKey("WebsiteId")]
    // [InverseProperty("Website")]
    // public virtual ICollection<IrUiView> IrUiView { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'Website'
    // [ForeignKey("WebsiteId")]
    // [InverseProperty("Website")]
    // public virtual ICollection<LoyaltyProgram> LoyaltyProgram { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'Website'
    // [ForeignKey("WebsiteId")]
    // [InverseProperty("Website")]
    // public virtual ICollection<LoyaltyRule> LoyaltyRule { get; set; }

    // [Many2one]
    [ForeignKey("NewsletterId")]
    // [InverseProperty("Website")] //Many2one
    public virtual MailingList? Newsletter { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'Website'
    // [ForeignKey("WebsiteId")]
    // [InverseProperty("Website")]
    // public virtual ICollection<PaymentProvider> PaymentProvider { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'Website'
    // [ForeignKey("WebsiteId")]
    // [InverseProperty("Website")]
    // public virtual ICollection<ProductPricelist> ProductPricelist { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'Website'
    // [ForeignKey("WebsiteId")]
    // [InverseProperty("Website")]
    // public virtual ICollection<ProductPublicCategory> ProductPublicCategory { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'Website'
    // [ForeignKey("WebsiteId")]
    // [InverseProperty("Website")]
    // public virtual ICollection<ProductTag> ProductTag { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'Website'
    // [ForeignKey("WebsiteId")]
    // [InverseProperty("Website")]
    // public virtual ICollection<ProductTemplate> ProductTemplate { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'Website'
    // [ForeignKey("WebsiteId")]
    // [InverseProperty("Website")]
    // public virtual ICollection<ProductWishlist> ProductWishlist { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'Website'
    // [ForeignKey("WebsiteId")]
    // [InverseProperty("Website")]
    // public virtual ICollection<ResCompany> ResCompany { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'Website'
    // [ForeignKey("WebsiteId")]
    // [InverseProperty("Website")]
    // public virtual ICollection<ResConfigSettings> ResConfigSettings { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'Website'
    // [ForeignKey("WebsiteId")]
    // [InverseProperty("WebsiteNavigation")]
    // public virtual ICollection<ResPartner> ResPartner { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'Website'
    // [ForeignKey("WebsiteId")]
    // [InverseProperty("Website")]
    // public virtual ICollection<ResUsers> ResUsers { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'Website'
    // [ForeignKey("WebsiteId")]
    // [InverseProperty("Website")]
    // public virtual ICollection<SaleOrder> SaleOrder { get; set; }

    // [Many2one]
    [ForeignKey("SalespersonId")]
    // [InverseProperty("WebsiteSalesperson")] //Many2one
    public virtual ResUsers? Salesperson { get; set; }

    // [Many2one]
    [ForeignKey("SalesteamId")]
    // [InverseProperty("WebsiteSalesteam")] //Many2one
    public virtual CrmTeam? Salesteam { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'Website'
    // [ForeignKey("WebsiteId")]
    // [InverseProperty("Website")]
    // public virtual ICollection<SlideChannel> SlideChannel { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'Website'
    // [ForeignKey("WebsiteId")]
    // [InverseProperty("Website")]
    // public virtual ICollection<StockPicking> StockPicking { get; set; }

    // [Many2one]
    [ForeignKey("ThemeId")]
    // [InverseProperty("WebsiteNavigation")] //Many2one
    public virtual IrModuleModule? Theme { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    // [InverseProperty("WebsiteUser")] //Many2one
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("WarehouseId")]
    // [InverseProperty("Website")] //Many2one
    public virtual StockWarehouse? Warehouse { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'Website'
    // [ForeignKey("WebsiteId")]
    // [InverseProperty("Website")]
    // public virtual ICollection<WebsiteControllerPage> WebsiteControllerPage { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'Website'
    // [ForeignKey("WebsiteId")]
    // [InverseProperty("Website")]
    // public virtual ICollection<WebsiteMenu> WebsiteMenu { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'Website'
    // [ForeignKey("WebsiteId")]
    // [InverseProperty("Website")]
    // public virtual ICollection<WebsitePage> WebsitePage { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'Website'
    // [ForeignKey("WebsiteId")]
    // [InverseProperty("Website")]
    // public virtual ICollection<WebsitePageProperties> WebsitePageProperties { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'Website'
    // [ForeignKey("WebsiteId")]
    // [InverseProperty("Website")]
    // public virtual ICollection<WebsitePagePropertiesBase> WebsitePagePropertiesBase { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'Website'
    // [ForeignKey("WebsiteId")]
    // [InverseProperty("Website")]
    // public virtual ICollection<WebsiteRewrite> WebsiteRewrite { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'Website'
    // [ForeignKey("WebsiteId")]
    // [InverseProperty("Website")]
    // public virtual ICollection<WebsiteSaleExtraField> WebsiteSaleExtraField { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'Website'
    // [ForeignKey("WebsiteId")]
    // [InverseProperty("Website")]
    // public virtual ICollection<WebsiteSnippetFilter> WebsiteSnippetFilter { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'Website'
    // [ForeignKey("WebsiteId")]
    // [InverseProperty("Website")]
    // public virtual ICollection<WebsiteVisitor> WebsiteVisitor { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("WebsiteWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("WebsiteId")]
    // [InverseProperty("Website")]
    public virtual ICollection<BaseLanguageInstall> BaseLanguageInstall { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("WebsiteId")] //Many2many
    // [InverseProperty("WebsiteNavigation")] //Many2many
    public virtual ICollection<ResLang> Lang { get; set; }
}
