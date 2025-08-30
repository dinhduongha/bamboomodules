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

    [Column("mode")]
    public string? Mode { get; set; }

    [JsonField] // ArchDb
    [Column("arch_db", TypeName = "jsonb")]
    public JsonElement? ArchDb { get; set; }

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

    [Column("track")]
    public bool? Track { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("InheritId")]
    public virtual IrUiView? Inherit { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("InheritId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Inherit")] // One2many
    public virtual ICollection<IrUiView> InverseInherit { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("SearchViewId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SearchView")] // One2many
    public virtual ICollection<IrActWindow> IrActWindowSearchView { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ViewId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("View")] // One2many
    public virtual ICollection<IrActWindow> IrActWindowView { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ViewId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("View")] // One2many
    public virtual ICollection<IrActWindowView> IrActWindowViewNavigation { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("RefId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Ref")] // One2many
    public virtual ICollection<IrUiViewCustom> IrUiViewCustom { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ExpressCheckoutFormViewId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ExpressCheckoutFormView")] // One2many
    public virtual ICollection<PaymentProvider> PaymentProviderExpressCheckoutFormView { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("InlineFormViewId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("InlineFormView")] // One2many
    public virtual ICollection<PaymentProvider> PaymentProviderInlineFormView { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("RedirectFormViewId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("RedirectFormView")] // One2many
    public virtual ICollection<PaymentProvider> PaymentProviderRedirectFormView { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("TokenInlineFormViewId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("TokenInlineFormView")] // One2many
    public virtual ICollection<PaymentProvider> PaymentProviderTokenInlineFormView { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ViewId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("View")] // One2many
    public virtual ICollection<ReportLayout> ReportLayout { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ExternalReportLayoutId")]
    [NotMapped] // One2many // Peer relationship (ResCompany) is commented out
    // [InverseProperty("ExternalReportLayout")] // One2many
    public virtual ICollection<ResCompany> ResCompany { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("AddressViewId")]
    [NotMapped] // One2many // Peer relationship (ResCountry) is commented out
    // [InverseProperty("AddressView")] // One2many
    public virtual ICollection<ResCountry> ResCountry { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("CompareViewId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("CompareView")] // One2many
    public virtual ICollection<ResetViewArchWizard> ResetViewArchWizardCompareView { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ViewId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("View")] // One2many
    public virtual ICollection<ResetViewArchWizard> ResetViewArchWizardView { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ThemeTemplateId")]
    public virtual ThemeIrUiView? ThemeTemplate { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("WebsiteId")]
    public virtual Website? Website { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("PageViewId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("PageView")] // One2many
    public virtual ICollection<WebsiteConfiguratorFeature> WebsiteConfiguratorFeature { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("RecordViewId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("RecordView")] // One2many
    public virtual ICollection<WebsiteControllerPage> WebsiteControllerPageRecordView { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ViewId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("View")] // One2many
    public virtual ICollection<WebsiteControllerPage> WebsiteControllerPageView { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ViewId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("View")] // One2many
    public virtual ICollection<WebsiteEventMenu> WebsiteEventMenu { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("ViewId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("View")] // One2many
    public virtual ICollection<WebsitePage> WebsitePage { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("ViewId")] // Many2many // Normal
    // [InverseProperty("View")] // Many2many // Normal
    public virtual ICollection<ResGroups> Group { get; set; }
}
