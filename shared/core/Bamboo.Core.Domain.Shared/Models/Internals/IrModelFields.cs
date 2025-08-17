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

[Table("ir_model_fields")]
//[Index("CompleteName", Name = "ir_model_fields__complete_name_index")]
//[Index("ModelId", Name = "ir_model_fields__model_id_index")]
//[Index("Model", Name = "ir_model_fields__model_index")]
//[Index("Name", Name = "ir_model_fields__name_index")]
//[Index("State", Name = "ir_model_fields__state_index")]
//[Index("WebsiteFormBlacklisted", Name = "ir_model_fields__website_form_blacklisted_index")]
//[Index("Model", "Name", Name = "ir_model_fields_name_unique", IsUnique = true)]
public partial class IrModelFields: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("relation_field_id")]
    public Guid? RelationFieldId { get; set; }

    [Column("model_id")]
    public Guid? ModelId { get; set; }

    [Column("related_field_id")]
    public Guid? RelatedFieldId { get; set; }

    [Column("size")]
    public long? Size { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("complete_name")]
    public string? CompleteName { get; set; }

    [Column("model")]
    public string? Model { get; set; }

    [Column("relation")]
    public string? Relation { get; set; }

    [Column("relation_field")]
    public string? RelationField { get; set; }

    [Column("ttype")]
    public string? Ttype { get; set; }

    [Column("related")]
    public string? Related { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("on_delete")]
    public string? OnDelete { get; set; }

    [Column("domain")]
    public string? Domain { get; set; }

    [Column("relation_table")]
    public string? RelationTable { get; set; }

    [Column("column1")]
    public string? Column1 { get; set; }

    [Column("column2")]
    public string? Column2 { get; set; }

    [Column("depends")]
    public string? Depends { get; set; }

    [Column("currency_field")]
    public string? CurrencyField { get; set; }

    [JsonField]
    [Column("field_description", TypeName = "jsonb")]
    public string? FieldDescription { get; set; }

    [JsonField]
    [Column("help", TypeName = "jsonb")]
    public string? Help { get; set; }

    [Column("compute")]
    public string? Compute { get; set; }

    [Column("copied")]
    public bool? Copied { get; set; }

    [Column("required")]
    public bool? Required { get; set; }

    [Column("readonly")]
    public bool? Readonly { get; set; }

    [Column("index")]
    public bool? Index { get; set; }

    [Column("translate")]
    public bool? Translate { get; set; }

    [Column("company_dependent")]
    public bool? CompanyDependent { get; set; }

    [Column("group_expand")]
    public bool? GroupExpand { get; set; }

    [Column("selectable")]
    public bool? Selectable { get; set; }

    [Column("store")]
    public bool? Store { get; set; }

    [Column("sanitize")]
    public bool? Sanitize { get; set; }

    [Column("sanitize_overridable")]
    public bool? SanitizeOverridable { get; set; }

    [Column("sanitize_tags")]
    public bool? SanitizeTags { get; set; }

    [Column("sanitize_attributes")]
    public bool? SanitizeAttributes { get; set; }

    [Column("sanitize_style")]
    public bool? SanitizeStyle { get; set; }

    [Column("sanitize_form")]
    public bool? SanitizeForm { get; set; }

    [Column("strip_style")]
    public bool? StripStyle { get; set; }

    [Column("strip_classes")]
    public bool? StripClasses { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("tracking")]
    public long? Tracking { get; set; }

    [Column("website_form_blacklisted")]
    public bool? WebsiteFormBlacklisted { get; set; }

    [Column("serialization_field_id")]
    public Guid? SerializationFieldId { get; set; }

    // [One2many]
    [ForeignKey("TrgDateId")]
    [InverseProperty("TrgDate")]
    public virtual ICollection<BaseAutomation> BaseAutomation { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("IrModelFieldsCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("FieldId")]
    [InverseProperty("Field")]
    public virtual ICollection<CrmLeadScoringFrequencyField> CrmLeadScoringFrequencyField { get; set; }

    // [One2many]
    [ForeignKey("TimeFieldId")]
    [InverseProperty("TimeField")]
    public virtual ICollection<DataRecycleModel> DataRecycleModel { get; set; }

    // [One2many]
    [ForeignKey("BatchDistinctiveField")]
    [InverseProperty("BatchDistinctiveFieldNavigation")]
    public virtual ICollection<GamificationGoalDefinition> GamificationGoalDefinitionBatchDistinctiveFieldNavigation { get; set; }

    // [One2many]
    [ForeignKey("FieldId")]
    [InverseProperty("Field")]
    public virtual ICollection<GamificationGoalDefinition> GamificationGoalDefinitionField { get; set; }

    // [One2many]
    [ForeignKey("FieldDateId")]
    [InverseProperty("FieldDate")]
    public virtual ICollection<GamificationGoalDefinition> GamificationGoalDefinitionFieldDate { get; set; }

    // [One2many]
    [ForeignKey("RelatedFieldId")]
    [InverseProperty("RelatedField")]
    public virtual ICollection<IrModelFields> InverseRelatedField { get; set; }

    // [One2many]
    [ForeignKey("RelationFieldId")]
    [InverseProperty("RelationFieldNavigation")]
    public virtual ICollection<IrModelFields> InverseRelationFieldNavigation { get; set; }

    // [One2many]
    [ForeignKey("SerializationFieldId")]
    [InverseProperty("SerializationField")]
    public virtual ICollection<IrModelFields> InverseSerializationField { get; set; }

    // [One2many]
    [ForeignKey("LinkFieldId")]
    [InverseProperty("LinkField")]
    public virtual ICollection<IrActServer> IrActServerLinkField { get; set; }

    // [One2many]
    [ForeignKey("UpdateFieldId")]
    [InverseProperty("UpdateField")]
    public virtual ICollection<IrActServer> IrActServerUpdateField { get; set; }

    // [One2many]
    [ForeignKey("LinkFieldId")]
    [InverseProperty("LinkField")]
    public virtual ICollection<IrActServer> IrActServer { get; set; }

    // [One2many]
    [ForeignKey("FieldId")]
    [InverseProperty("Field")]
    public virtual ICollection<IrDefault> IrDefault { get; set; }

    // [One2many]
    [ForeignKey("WebsiteFormDefaultFieldId")]
    [InverseProperty("WebsiteFormDefaultField")]
    public virtual ICollection<IrModel> IrModel { get; set; }

    // [One2many]
    [ForeignKey("FieldId")]
    [InverseProperty("Field")]
    public virtual ICollection<IrModelFieldsSelection> IrModelFieldsSelection { get; set; }

    // [One2many]
    [ForeignKey("ParentFieldId")]
    [InverseProperty("ParentField")]
    public virtual ICollection<IrModelInherit> IrModelInherit { get; set; }

    // [One2many]
    [ForeignKey("FieldsId")]
    [InverseProperty("Fields")]
    public virtual ICollection<IrProperty> IrProperty { get; set; }

    // [One2many]
    [ForeignKey("Col1")]
    [InverseProperty("Col1Navigation")]
    public virtual ICollection<IrServerObjectLines> IrServerObjectLines { get; set; }

    // [One2many]
    // [ForeignKey("FieldId")]
    // [InverseProperty("Field")]
    // public virtual ICollection<MailTrackingValue> MailTrackingValue { get; set; }

    // [One2many]
    [ForeignKey("Field")]
    [InverseProperty("FieldNavigation")]
    public virtual ICollection<MailTrackingValue> MailTrackingValue { get; set; }

    // [Many2one]
    [ForeignKey("ModelId")]
    // [InverseProperty("IrModelFields")] //Many2one
    public virtual IrModel? ModelNavigation { get; set; }

    // [Many2one]
    [ForeignKey("RelatedFieldId")]
    // [InverseProperty("InverseRelatedField")] //Many2one
    public virtual IrModelFields? RelatedField { get; set; }

    // [Many2one]
    [ForeignKey("RelationFieldId")]
    // [InverseProperty("InverseRelationFieldNavigation")] //Many2one
    public virtual IrModelFields? RelationFieldNavigation { get; set; }

    // [Many2one]
    [ForeignKey("SerializationFieldId")]
    // [InverseProperty("InverseSerializationField")] //Many2one
    public virtual IrModelFields? SerializationField { get; set; }

    // [One2many]
    [ForeignKey("FieldId")]
    [InverseProperty("Field")]
    public virtual ICollection<WebsiteSaleExtraField> WebsiteSaleExtraField { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("IrModelFieldsWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("IrModelFieldsId")]
    // [InverseProperty("IrModelFieldsNavigation")]
    // public virtual ICollection<BaseAutomation> BaseAutomation1 { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("IrModelFieldsId")]
    // [InverseProperty("IrModelFields")]
    // public virtual ICollection<BaseAutomation> BaseAutomationNavigation { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("FieldId")] //Many2many
    // [InverseProperty("Field")] //Many2many
    public virtual ICollection<ResGroups> Group { get; set; }

    // [Many2many] // ManyToMany Hidden
    // [NotMapped] //Many2many // Hidden
    // [ForeignKey("FieldId")]
    // [InverseProperty("Field")]
    // public virtual ICollection<IrActServer> Server { get; set; }
}
