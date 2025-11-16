using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureWebsite(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<Website>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("website_pkey");

                        entity.ToTable("website");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.SalesteamId, "website__salesteam_id_index").HasFilter("(salesteam_id IS NOT NULL)");

                        entity.HasIndex(e => e.Domain, "website_domain_unique").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AccountOnCheckout).HasColumnName("account_on_checkout");
                        entity.Property(e => e.AddToCartAction).HasColumnName("add_to_cart_action");
                        entity.Property(e => e.AuthSignupUninvited).HasColumnName("auth_signup_uninvited");
                        entity.Property(e => e.AutoRedirectLang).HasColumnName("auto_redirect_lang");
                        entity.Property(e => e.BlockThirdPartyDomains).HasColumnName("block_third_party_domains");
                        entity.Property(e => e.CartAbandonedDelay).HasColumnName("cart_abandoned_delay");
                        entity.Property(e => e.CartRecoveryMailTemplateId).HasColumnName("cart_recovery_mail_template_id");
                        entity.Property(e => e.CdnActivated).HasColumnName("cdn_activated");
                        entity.Property(e => e.CdnFilters).HasColumnName("cdn_filters");
                        entity.Property(e => e.CdnUrl).HasColumnName("cdn_url");
                        entity.Property(e => e.ChannelId).HasColumnName("channel_id");

                        entity.Property(e => e.ConfiguratorDone).HasColumnName("configurator_done");
                        entity.Property(e => e.ConfirmationEmailTemplateId).HasColumnName("confirmation_email_template_id");
                        entity.Property(e => e.ContactUsButtonUrl)
                            .HasColumnType("jsonb")
                            .HasColumnName("contact_us_button_url");
                        entity.Property(e => e.CookiesBar).HasColumnName("cookies_bar");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.CrmDefaultTeamId).HasColumnName("crm_default_team_id");
                        entity.Property(e => e.CrmDefaultUserId).HasColumnName("crm_default_user_id");
                        entity.Property(e => e.CustomBlockedThirdPartyDomains).HasColumnName("custom_blocked_third_party_domains");
                        entity.Property(e => e.CustomCodeFooter).HasColumnName("custom_code_footer");
                        entity.Property(e => e.CustomCodeHead).HasColumnName("custom_code_head");
                        entity.Property(e => e.DefaultLangId).HasColumnName("default_lang_id");
                        entity.Property(e => e.Domain).HasColumnName("domain");
                        entity.Property(e => e.EcommerceAccess).HasColumnName("ecommerce_access");
                        entity.Property(e => e.EnabledGmcSrc).HasColumnName("enabled_gmc_src");
                        entity.Property(e => e.EventsAppName).HasColumnName("events_app_name");
                        entity.Property(e => e.ForumCount).HasColumnName("forum_count");
                        entity.Property(e => e.GoogleAnalyticsKey).HasColumnName("google_analytics_key");
                        entity.Property(e => e.GoogleMapsApiKey).HasColumnName("google_maps_api_key");
                        entity.Property(e => e.GooglePlacesApiKey).HasColumnName("google_places_api_key");
                        entity.Property(e => e.GoogleSearchConsole).HasColumnName("google_search_console");
                        entity.Property(e => e.HasSocialDefaultImage).HasColumnName("has_social_default_image");
                        entity.Property(e => e.HomepageUrl).HasColumnName("homepage_url");
                        entity.Property(e => e.KarmaProfileMin).HasColumnName("karma_profile_min");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.NewsletterId).HasColumnName("newsletter_id");
                        entity.Property(e => e.PlausibleSharedKey).HasColumnName("plausible_shared_key");
                        entity.Property(e => e.PlausibleSite).HasColumnName("plausible_site");
                        entity.Property(e => e.PreventZeroPriceSale).HasColumnName("prevent_zero_price_sale");
                        entity.Property(e => e.ProductPageColsOrder).HasColumnName("product_page_cols_order");
                        entity.Property(e => e.ProductPageContainer).HasColumnName("product_page_container");
                        entity.Property(e => e.ProductPageGridColumns).HasColumnName("product_page_grid_columns");
                        entity.Property(e => e.ProductPageImageLayout).HasColumnName("product_page_image_layout");
                        entity.Property(e => e.ProductPageImageRatio).HasColumnName("product_page_image_ratio");
                        entity.Property(e => e.ProductPageImageRatioMobile).HasColumnName("product_page_image_ratio_mobile");
                        entity.Property(e => e.ProductPageImageRoundness).HasColumnName("product_page_image_roundness");
                        entity.Property(e => e.ProductPageImageSpacing).HasColumnName("product_page_image_spacing");
                        entity.Property(e => e.ProductPageImageWidth).HasColumnName("product_page_image_width");
                        entity.Property(e => e.RobotsTxt).HasColumnName("robots_txt");
                        entity.Property(e => e.SalespersonId).HasColumnName("salesperson_id");
                        entity.Property(e => e.SalesteamId).HasColumnName("salesteam_id");
                        entity.Property(e => e.SendAbandonedCartEmail).HasColumnName("send_abandoned_cart_email");
                        entity.Property(e => e.SendAbandonedCartEmailActivationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("send_abandoned_cart_email_activation_time");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.ShopDefaultSort).HasColumnName("shop_default_sort");
                        entity.Property(e => e.ShopGap).HasColumnName("shop_gap");
                        entity.Property(e => e.ShopOptProductsDesignClasses).HasColumnName("shop_opt_products_design_classes");
                        entity.Property(e => e.ShopPageContainer).HasColumnName("shop_page_container");
                        entity.Property(e => e.ShopPpg).HasColumnName("shop_ppg");
                        entity.Property(e => e.ShopPpr).HasColumnName("shop_ppr");
                        entity.Property(e => e.ShowLineSubtotalsTaxSelection).HasColumnName("show_line_subtotals_tax_selection");
                        entity.Property(e => e.SocialDiscord).HasColumnName("social_discord");
                        entity.Property(e => e.SocialFacebook).HasColumnName("social_facebook");
                        entity.Property(e => e.SocialGithub).HasColumnName("social_github");
                        entity.Property(e => e.SocialInstagram).HasColumnName("social_instagram");
                        entity.Property(e => e.SocialLinkedin).HasColumnName("social_linkedin");
                        entity.Property(e => e.SocialTiktok).HasColumnName("social_tiktok");
                        entity.Property(e => e.SocialTwitter).HasColumnName("social_twitter");
                        entity.Property(e => e.SocialYoutube).HasColumnName("social_youtube");
                        entity.Property(e => e.SpecificUserAccount).HasColumnName("specific_user_account");
                        entity.Property(e => e.ThemeId).HasColumnName("theme_id");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.WarehouseId).HasColumnName("warehouse_id");
                        entity.Property(e => e.WebsiteSlideGoogleAppKey).HasColumnName("website_slide_google_app_key");
                        entity.Property(e => e.WishlistGap).HasColumnName("wishlist_gap");
                        entity.Property(e => e.WishlistGridColumns).HasColumnName("wishlist_grid_columns");
                        entity.Property(e => e.WishlistMobileColumns).HasColumnName("wishlist_mobile_columns");
                        entity.Property(e => e.WishlistOptProductsDesignClasses).HasColumnName("wishlist_opt_products_design_classes");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.CartRecoveryMailTemplate).WithMany(p => p.WebsiteCartRecoveryMailTemplate)
                            .HasForeignKey(d => d.CartRecoveryMailTemplateId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("website_cart_recovery_mail_template_id_fkey");

                        entity.HasOne(d => d.Channel).WithMany(p => p.Website)
                            .HasForeignKey(d => d.ChannelId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("website_channel_id_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.WebsiteNavigation) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("website_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("website_company_id_fkey");

                        entity.HasOne(d => d.ConfirmationEmailTemplate).WithMany(p => p.WebsiteConfirmationEmailTemplate)
                            .HasForeignKey(d => d.ConfirmationEmailTemplateId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("website_confirmation_email_template_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.WebsiteCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("website_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("website_create_uid_fkey");

                        entity.HasOne(d => d.CrmDefaultTeam).WithMany(p => p.WebsiteCrmDefaultTeam)
                            .HasForeignKey(d => d.CrmDefaultTeamId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("website_crm_default_team_id_fkey");

                        // entity.HasOne(d => d.CrmDefaultUser).WithMany(p => p.WebsiteCrmDefaultUser) .HasForeignKey(d => d.CrmDefaultUserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("website_crm_default_user_id_fkey");
                        entity.HasOne(d => d.CrmDefaultUser).WithMany()
                            .HasForeignKey(d => d.CrmDefaultUserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("website_crm_default_user_id_fkey");

                        entity.HasOne(d => d.DefaultLang).WithMany(p => p.Website)
                            .HasForeignKey(d => d.DefaultLangId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("website_default_lang_id_fkey");

                        entity.HasOne(d => d.Newsletter).WithMany(p => p.Website)
                            .HasForeignKey(d => d.NewsletterId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("website_newsletter_id_fkey");

                        // entity.HasOne(d => d.Salesperson).WithMany(p => p.WebsiteSalesperson) .HasForeignKey(d => d.SalespersonId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("website_salesperson_id_fkey");
                        entity.HasOne(d => d.Salesperson).WithMany()
                            .HasForeignKey(d => d.SalespersonId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("website_salesperson_id_fkey");

                        entity.HasOne(d => d.Salesteam).WithMany(p => p.WebsiteSalesteam)
                            .HasForeignKey(d => d.SalesteamId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("website_salesteam_id_fkey");

                        entity.HasOne(d => d.Theme).WithMany(p => p.WebsiteNavigation)
                            .HasForeignKey(d => d.ThemeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("website_theme_id_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.WebsiteUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("website_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("website_user_id_fkey");

                        entity.HasOne(d => d.Warehouse).WithMany(p => p.Website)
                            .HasForeignKey(d => d.WarehouseId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("website_warehouse_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.WebsiteWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("website_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("website_write_uid_fkey");

                        // entity.HasMany(d => d.Lang).WithMany(p => p.WebsiteNavigation)
                        entity.HasMany<ResLang>().WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "WebsiteLangRel",
                                r => r.HasOne<ResLang>().WithMany()
                                    .HasForeignKey("LangId")
                                    .HasConstraintName("website_lang_rel_lang_id_fkey"),
                                l => l.HasOne<Website>().WithMany()
                                    .HasForeignKey("WebsiteId")
                                    .HasConstraintName("website_lang_rel_website_id_fkey"),
                                j =>
                                {
                                    j.HasKey("WebsiteId", "LangId").HasName("website_lang_rel_pkey");
                                    j.ToTable("website_lang_rel");
                                    j.HasIndex(new[] { "LangId", "WebsiteId" }, "website_lang_rel_lang_id_website_id_idx");
                                    j.IndexerProperty<Guid>("WebsiteId").HasColumnName("website_id");
                                    j.IndexerProperty<Guid>("LangId").HasColumnName("lang_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}