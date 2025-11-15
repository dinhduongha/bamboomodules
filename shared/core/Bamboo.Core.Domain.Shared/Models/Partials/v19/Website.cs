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

public partial class Website
{
    [Column("social_discord")]
    public string? SocialDiscord { get; set; }

    [Column("confirmation_email_template_id")]
    public Guid? ConfirmationEmailTemplateId { get; set; }

    [Column("shop_page_container")]
    public string? ShopPageContainer { get; set; }

    [Column("shop_opt_products_design_classes")]
    public string? ShopOptProductsDesignClasses { get; set; }

    [Column("product_page_container")]
    public string? ProductPageContainer { get; set; }

    [Column("product_page_cols_order")]
    public string? ProductPageColsOrder { get; set; }

    [Column("product_page_image_roundness")]
    public string? ProductPageImageRoundness { get; set; }

    [Column("product_page_image_ratio")]
    public string? ProductPageImageRatio { get; set; }

    [Column("product_page_image_ratio_mobile")]
    public string? ProductPageImageRatioMobile { get; set; }

    [Column("enabled_gmc_src")]
    public bool? EnabledGmcSrc { get; set; }

    [Column("send_abandoned_cart_email_activation_time", TypeName = "timestamp without time zone")]
    public DateTime? SendAbandonedCartEmailActivationTime { get; set; }

    [Column("google_places_api_key")]
    public string? GooglePlacesApiKey { get; set; }

    [Column("wishlist_grid_columns")]
    public long? WishlistGridColumns { get; set; }

    [Column("wishlist_mobile_columns")]
    public long? WishlistMobileColumns { get; set; }

    [Column("wishlist_opt_products_design_classes")]
    public string? WishlistOptProductsDesignClasses { get; set; }

    [Column("wishlist_gap")]
    public string? WishlistGap { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ConfirmationEmailTemplateId")]
    public virtual MailTemplate? ConfirmationEmailTemplate { get; set; }

    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'Website'
    // [One2many] [ForeignKey("WebsiteId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Website")] // One2many // Peer relationship (ProductFeed) is commented out
    // public virtual ICollection<ProductFeed> ProductFeed { get; set; }


    // [One2many] - RELATIONSHIP COMMENTED OUT FOR 'Website'
    // [One2many] [ForeignKey("WebsiteId")]
    // [NotMapped] // One2many 
    // [InverseProperty("Website")] // One2many // Peer relationship (WebsiteCheckoutStep) is commented out
    // public virtual ICollection<WebsiteCheckoutStep> WebsiteCheckoutStep { get; set; }

}