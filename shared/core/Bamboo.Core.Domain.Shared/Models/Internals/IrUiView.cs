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

[Table("ir_ui_view")]
//[Index("InheritId", Name = "ir_ui_view__inherit_id_index")]
//[Index("Model", Name = "ir_ui_view__model_index")]
//[Index("Model", "InheritId", Name = "ir_ui_view_model_type_inherit_id")]
public partial class IrUiView: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("priority")]
    public long? Priority { get; set; }

    [Column("inherit_id")]
    public Guid? InheritId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

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

    [Column("field_parent")]
    public string? FieldParent { get; set; }

    [Column("mode")]
    public string? Mode { get; set; }

    [JsonField]
    [Column("arch_db", TypeName = "jsonb")]
    public string? ArchDb { get; set; }

    [Column("arch_prev")]
    public string? ArchPrev { get; set; }

    [Column("arch_updated")]
    public bool? ArchUpdated { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

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

    [Column("track")]
    public bool? Track { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("IrUiViewCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("InheritId")]
    // [InverseProperty("InverseInherit")] //Many2one
    public virtual IrUiView? Inherit { get; set; }

    // [One2many]
    [ForeignKey("InheritId")]
    [InverseProperty("Inherit")]
    public virtual ICollection<IrUiView> InverseInherit { get; set; }

    // [One2many]
    [ForeignKey("SearchViewId")]
    [InverseProperty("SearchView")]
    public virtual ICollection<IrActWindow> IrActWindowSearchView { get; set; }

    // [One2many]
    [ForeignKey("ViewId")]
    [InverseProperty("View")]
    public virtual ICollection<IrActWindow> IrActWindowView { get; set; }

    // [One2many]
    [ForeignKey("ViewId")]
    [InverseProperty("View")]
    public virtual ICollection<IrActWindowView> IrActWindowViewNavigation { get; set; }

    // [One2many]
    [ForeignKey("RefId")]
    [InverseProperty("Ref")]
    public virtual ICollection<IrUiViewCustom> IrUiViewCustom { get; set; }

    // [One2many]
    [ForeignKey("ExpressCheckoutFormViewId")]
    [InverseProperty("ExpressCheckoutFormView")]
    public virtual ICollection<PaymentProvider> PaymentProviderExpressCheckoutFormView { get; set; }

    // [One2many]
    [ForeignKey("InlineFormViewId")]
    [InverseProperty("InlineFormView")]
    public virtual ICollection<PaymentProvider> PaymentProviderInlineFormView { get; set; }

    // [One2many]
    [ForeignKey("RedirectFormViewId")]
    [InverseProperty("RedirectFormView")]
    public virtual ICollection<PaymentProvider> PaymentProviderRedirectFormView { get; set; }

    // [One2many]
    [ForeignKey("TokenInlineFormViewId")]
    [InverseProperty("TokenInlineFormView")]
    public virtual ICollection<PaymentProvider> PaymentProviderTokenInlineFormView { get; set; }

    // [One2many]
    [ForeignKey("ViewId")]
    [InverseProperty("View")]
    public virtual ICollection<ReportLayout> ReportLayout { get; set; }

    // [One2many]
    [ForeignKey("ExternalReportLayoutId")]
    [InverseProperty("ExternalReportLayout")]
    public virtual ICollection<ResCompany> ResCompany { get; set; }

    // [One2many]
    [ForeignKey("AddressViewId")]
    [InverseProperty("AddressView")]
    public virtual ICollection<ResCountry> ResCountry { get; set; }

    // [One2many]
    [ForeignKey("CompareViewId")]
    [InverseProperty("CompareView")]
    public virtual ICollection<ResetViewArchWizard> ResetViewArchWizardCompareView { get; set; }

    // [One2many]
    [ForeignKey("ViewId")]
    [InverseProperty("View")]
    public virtual ICollection<ResetViewArchWizard> ResetViewArchWizardView { get; set; }

    // [Many2one]
    [ForeignKey("ThemeTemplateId")]
    // [InverseProperty("IrUiView")] //Many2one
    public virtual ThemeIrUiView? ThemeTemplate { get; set; }

    // [Many2one]
    [ForeignKey("WebsiteId")]
    // [InverseProperty("IrUiView")] //Many2one
    public virtual Website? Website { get; set; }

    // [One2many]
    [ForeignKey("PageViewId")]
    [InverseProperty("PageView")]
    public virtual ICollection<WebsiteConfiguratorFeature> WebsiteConfiguratorFeature { get; set; }

    // [One2many]
    [ForeignKey("RecordViewId")]
    [InverseProperty("RecordView")]
    public virtual ICollection<WebsiteControllerPage> WebsiteControllerPageRecordView { get; set; }

    // [One2many]
    [ForeignKey("ViewId")]
    [InverseProperty("View")]
    public virtual ICollection<WebsiteControllerPage> WebsiteControllerPageView { get; set; }

    // [One2many]
    [ForeignKey("ViewId")]
    [InverseProperty("View")]
    public virtual ICollection<WebsiteEventMenu> WebsiteEventMenu { get; set; }

    // [One2many]
    [ForeignKey("ViewId")]
    [InverseProperty("View")]
    public virtual ICollection<WebsitePage> WebsitePage { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("IrUiViewWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("ViewId")] //Many2many
    // [InverseProperty("View")] //Many2many
    public virtual ICollection<ResGroups> Group { get; set; }
}
