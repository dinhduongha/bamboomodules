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
[Table("ir_ui_view")]
//[Index("InheritId", Name = "ir_ui_view_inherit_id_index")]
//[Index("Model", Name = "ir_ui_view_model_index")]
//[Index("Model", "InheritId", Name = "ir_ui_view_model_type_inherit_id")]
public partial class IrUiView: FullAuditedEntity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("priority")]
    public long? Priority { get; set; }

    [Column("inherit_id")]
    public Guid? InheritId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("model")]
    public string? Model { get; set; }

    [Column("key")]
    public string? Key { get; set; }

    [Column("type")]
    public string? Type { get; set; }

    [Column("arch_fs")]
    public string? ArchFs { get; set; }

    // v16-Compat
    [Column("field_parent")]
    public string? FieldParent { get; set; }

    [Column("mode")]
    public string? Mode { get; set; }

    [JsonField]
    [Column("arch_db", TypeName = "jsonb")]
    public StringDictionary? ArchDb { get; set; }

    [Column("arch_prev")]
    public string? ArchPrev { get; set; }

    [Column("arch_updated")]
    public bool? ArchUpdated { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("customize_show")]
    public bool? CustomizeShow { get; set; }

    [Column("website_id")]
    public Guid? WebsiteId { get; set; }

    [Column("theme_template_id")]
    public Guid? ThemeTemplateId { get; set; }

    [Column("website_meta_og_img")]
    public string? WebsiteMetaOgImg { get; set; }

    [Column("visibility")]
    public string? Visibility { get; set; }

    [Column("visibility_password")]
    public string? VisibilityPassword { get; set; }

    [JsonField]
    [Column("website_meta_title", TypeName = "jsonb")]
    public StringDictionary? WebsiteMetaTitle { get; set; }

    [JsonField]
    [Column("website_meta_description", TypeName = "jsonb")]
    public StringDictionary? WebsiteMetaDescription { get; set; }

    [JsonField]
    [Column("website_meta_keywords", TypeName = "jsonb")]
    public StringDictionary? WebsiteMetaKeywords { get; set; }

    [JsonField]
    [Column("seo_name", TypeName = "jsonb")]
    public StringDictionary? SeoName { get; set; }

    [Column("track")]
    public bool? Track { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("IrUiViewCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("InheritId")]
    //[InverseProperty("InverseInherit")]
    [NotMapped]
    public virtual IrUiView? Inherit { get; set; }

    [ForeignKey("ThemeTemplateId")]
    //[InverseProperty("IrUiViews")]
    [NotMapped]
    public virtual ThemeIrUiView? ThemeTemplate { get; set; }

    [ForeignKey("WebsiteId")]
    //[InverseProperty("IrUiViews")]
    [NotMapped]
    public virtual Website? Website { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("IrUiViewWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Inherit")]
    [NotMapped]
    public virtual ICollection<IrUiView> InverseInherit { get; set; } 

    //[InverseProperty("SearchView")]
    [NotMapped]
    public virtual ICollection<IrActWindow> IrActWindowSearchViews { get; set; } 

    //[InverseProperty("View")]
    [NotMapped]
    public virtual ICollection<IrActWindow> IrActWindowViews { get; set; } 

    //[InverseProperty("View")]
    [NotMapped]
    public virtual ICollection<IrActWindowView> IrActWindowViewsNavigation { get; set; } 

    //[InverseProperty("Ref")]
    [NotMapped]
    public virtual ICollection<IrUiViewCustom> IrUiViewCustoms { get; set; } 

    //[InverseProperty("ExpressCheckoutFormView")]
    [NotMapped]
    public virtual ICollection<PaymentProvider> PaymentProviderExpressCheckoutFormViews { get; set; } 

    //[InverseProperty("InlineFormView")]
    [NotMapped]
    public virtual ICollection<PaymentProvider> PaymentProviderInlineFormViews { get; set; } 

    //[InverseProperty("RedirectFormView")]
    [NotMapped]
    public virtual ICollection<PaymentProvider> PaymentProviderRedirectFormViews { get; set; } 

    //[InverseProperty("TokenInlineFormView")]
    [NotMapped]
    public virtual ICollection<PaymentProvider> PaymentProviderTokenInlineFormViews { get; set; } 

    //[InverseProperty("View")]
    [NotMapped]
    public virtual ICollection<ReportLayout> ReportLayouts { get; set; } 

    //[InverseProperty("ExternalReportLayout")]
    [NotMapped]
    public virtual ICollection<ResCompany> ResCompanies { get; set; } 

    //[InverseProperty("AddressView")]
    [NotMapped]
    public virtual ICollection<ResCountry> ResCountries { get; set; } 

    //[InverseProperty("CompareView")]
    [NotMapped]
    public virtual ICollection<ResetViewArchWizard> ResetViewArchWizardCompareViews { get; set; } 

    //[InverseProperty("View")]
    [NotMapped]
    public virtual ICollection<ResetViewArchWizard> ResetViewArchWizardViews { get; set; } 

    //[InverseProperty("PageView")]
    [NotMapped]
    public virtual ICollection<WebsiteConfiguratorFeature> WebsiteConfiguratorFeatures { get; set; } 

    //[InverseProperty("RecordView")]
    [NotMapped]
    public virtual ICollection<WebsiteControllerPage> WebsiteControllerPageRecordViews { get; set; } 

    //[InverseProperty("View")]
    [NotMapped]
    public virtual ICollection<WebsiteControllerPage> WebsiteControllerPageViews { get; set; } 

    //[InverseProperty("View")]
    [NotMapped]
    public virtual ICollection<WebsiteEventMenu> WebsiteEventMenus { get; set; } 

    //[InverseProperty("View")]
    [NotMapped]
    public virtual ICollection<WebsitePage> WebsitePages { get; set; } 

    [ForeignKey("ViewId")]
    //[InverseProperty("Views")]
    [NotMapped]
    public virtual ICollection<ResGroup> Groups { get; set; } 
}
