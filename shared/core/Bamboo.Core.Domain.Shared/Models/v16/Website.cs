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
public partial class Website: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("sequence")]
    public long Sequence { get; set; }

    [Column("default_lang_id")]
    public Guid? DefaultLangId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("theme_id")]
    public Guid? ThemeId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

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

    [Column("show_line_subtotals_tax_selection")]
    public string? ShowLineSubtotalsTaxSelection { get; set; }

    // v16-Compat
    // [Column("shop_default_sort")]
    // public string? ShopDefaultSort { get; set; }

    [Column("add_to_cart_action")]
    public string? AddToCartAction { get; set; }

    [Column("account_on_checkout")]
    public string? AccountOnCheckout { get; set; }

    [Column("shop_gap")]
    public string? ShopGap { get; set; }

    [Column("shop_default_sort")]
    public string? ShopDefaultSort { get; set; }

    [Column("product_page_image_layout")]
    public string? ProductPageImageLayout { get; set; }

    [Column("product_page_image_width")]
    public string? ProductPageImageWidth { get; set; }

    [Column("product_page_image_spacing")]
    public string? ProductPageImageSpacing { get; set; }

    [Column("ecommerce_access")]
    public string? EcommerceAccess { get; set; }

    // v16-Compat
    // [Column("prevent_zero_price_sale_text", TypeName = "jsonb")]
    // public string? PreventZeroPriceSaleText { get; set; }

    [Column("contact_us_button_url", TypeName = "jsonb")]
    public string? ContactUsButtonUrl { get; set; }

    [Column("prevent_zero_price_sale_text", TypeName = "jsonb")]
    public string? PreventZeroPriceSaleText { get; set; }

    [Column("enabled_portal_reorder_button")]
    public bool? EnabledPortalReorderButton { get; set; }

    [Column("send_abandoned_cart_email")]
    public bool? SendAbandonedCartEmail { get; set; }

    [Column("prevent_zero_price_sale")]
    public bool? PreventZeroPriceSale { get; set; }

    // v16-Compat
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

    [Column("newsletter_id")]
    public Guid? NewsletterId { get; set; }

    [Column("channel_id")]
    public Guid? ChannelId { get; set; }

    [ForeignKey("CartRecoveryMailTemplateId")]
    //[InverseProperty("Websites")]
    [NotMapped]
    public virtual MailTemplate? CartRecoveryMailTemplate { get; set; }

    [ForeignKey("ChannelId")]
    //[InverseProperty("Websites")]
    [NotMapped]
    public virtual ImLivechatChannel? Channel { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("Websites")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("WebsiteCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("CrmDefaultTeamId")]
    //[InverseProperty("WebsiteCrmDefaultTeams")]
    [NotMapped]
    public virtual CrmTeam? CrmDefaultTeam { get; set; }

    [ForeignKey("CrmDefaultUserId")]
    //[InverseProperty("WebsiteCrmDefaultUsers")]
    [NotMapped]
    public virtual ResUser? CrmDefaultUser { get; set; }

    [ForeignKey("DefaultLangId")]
    //[InverseProperty("Websites")]
    [NotMapped]
    public virtual ResLang? DefaultLang { get; set; }

    [ForeignKey("NewsletterId")]
    //[InverseProperty("Websites")]
    [NotMapped]
    public virtual MailingList? Newsletter { get; set; }

    [ForeignKey("SalespersonId")]
    //[InverseProperty("WebsiteSalespeople")]
    [NotMapped]
    public virtual ResUser? Salesperson { get; set; }

    [ForeignKey("SalesteamId")]
    //[InverseProperty("WebsiteSalesteams")]
    [NotMapped]
    public virtual CrmTeam? Salesteam { get; set; }

    [ForeignKey("ThemeId")]
    //[InverseProperty("Websites")]
    [NotMapped]
    public virtual IrModuleModule? Theme { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("WebsiteUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("WarehouseId")]
    //[InverseProperty("Websites")]
    [NotMapped]
    public virtual StockWarehouse? Warehouse { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("WebsiteWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Website")]
    [NotMapped]
    public virtual ICollection<AccountMove> AccountMoves { get; set; } = new List<AccountMove>();

    //[InverseProperty("Website")]
    [NotMapped]
    public virtual ICollection<HrJob> HrJobs { get; set; } = new List<HrJob>();

    //[InverseProperty("Website")]
    [NotMapped]
    public virtual ICollection<IrAsset> IrAssets { get; set; } = new List<IrAsset>();

    //[InverseProperty("Website")]
    [NotMapped]
    public virtual ICollection<IrAttachment> IrAttachments { get; set; } = new List<IrAttachment>();

    //[InverseProperty("Website")]
    [NotMapped]
    public virtual ICollection<IrUiView> IrUiViews { get; set; } = new List<IrUiView>();

    //[InverseProperty("Website")]
    [NotMapped]
    public virtual ICollection<PaymentProvider> PaymentProviders { get; set; } = new List<PaymentProvider>();

    //[InverseProperty("Website")]
    [NotMapped]
    public virtual ICollection<ProductPricelist> ProductPricelists { get; set; } = new List<ProductPricelist>();

    //[InverseProperty("Website")]
    [NotMapped]
    public virtual ICollection<ProductPublicCategory> ProductPublicCategories { get; set; } = new List<ProductPublicCategory>();

    //[InverseProperty("Website")]
    [NotMapped]
    public virtual ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();

    //[InverseProperty("Website")]
    [NotMapped]
    public virtual ICollection<ProductTemplate> ProductTemplates { get; set; } = new List<ProductTemplate>();

    //[InverseProperty("Website")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanies { get; set; } = new List<ResCompany>();

    //[InverseProperty("Website")]
    [NotMapped]
    public virtual ICollection<ResConfigSetting> ResConfigSettings { get; set; } = new List<ResConfigSetting>();

    //[InverseProperty("WebsiteNavigation")]
    [NotMapped]
    public virtual ICollection<ResPartner> ResPartners { get; set; } = new List<ResPartner>();

    //[InverseProperty("Website")]
    [NotMapped]
    public virtual ICollection<ResUser> ResUsers { get; set; } = new List<ResUser>();

    //[InverseProperty("Website")]
    [NotMapped]
    public virtual ICollection<SaleOrder> SaleOrders { get; set; } = new List<SaleOrder>();

    //[InverseProperty("Website")]
    [NotMapped]
    public virtual ICollection<StockPicking> StockPickings { get; set; } = new List<StockPicking>();

    //[InverseProperty("Website")]
    [NotMapped]
    public virtual ICollection<WebsiteMenu> WebsiteMenus { get; set; } = new List<WebsiteMenu>();

    //[InverseProperty("Website")]
    [NotMapped]
    public virtual ICollection<WebsitePage> WebsitePages { get; set; } = new List<WebsitePage>();

    //[InverseProperty("Website")]
    [NotMapped]
    public virtual ICollection<WebsiteRewrite> WebsiteRewrites { get; set; } = new List<WebsiteRewrite>();

    //[InverseProperty("Website")]
    [NotMapped]
    public virtual ICollection<WebsiteSaleExtraField> WebsiteSaleExtraFields { get; set; } = new List<WebsiteSaleExtraField>();

    //[InverseProperty("Website")]
    [NotMapped]
    public virtual ICollection<WebsiteSnippetFilter> WebsiteSnippetFilters { get; set; } = new List<WebsiteSnippetFilter>();

    //[InverseProperty("Website")]
    [NotMapped]
    public virtual ICollection<WebsiteVisitor> WebsiteVisitors { get; set; } = new List<WebsiteVisitor>();

    [ForeignKey("WebsiteId")]
    //[InverseProperty("Websites")]
    [NotMapped]
    public virtual ICollection<BaseLanguageInstall> BaseLanguageInstalls { get; set; } = new List<BaseLanguageInstall>();

    [ForeignKey("WebsiteId")]
    //[InverseProperty("WebsitesNavigation")]
    [NotMapped]
    public virtual ICollection<ResLang> Langs { get; set; } = new List<ResLang>();
}
