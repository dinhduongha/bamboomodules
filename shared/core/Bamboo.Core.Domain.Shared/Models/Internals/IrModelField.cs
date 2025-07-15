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
//[Index("CompleteName", Name = "ir_model_fields_complete_name_index")]
//[Index("ModelId", Name = "ir_model_fields_model_id_index")]
//[Index("Model", Name = "ir_model_fields_model_index")]
//[Index("Name", Name = "ir_model_fields_name_index")]
//[Index("Model", "Name", Name = "ir_model_fields_name_unique", IsUnique = true)]
//[Index("State", Name = "ir_model_fields_state_index")]
//[Index("WebsiteFormBlacklisted", Name = "ir_model_fields_website_form_blacklisted_index")]
public partial class IrModelField: FullAuditedEntity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("relation_field_id")]
    public Guid? RelationFieldId { get; set; }

    [Column("model_id")]
    public Guid? ModelId { get; set; }

    [Column("related_field_id")]
    public Guid? RelatedFieldId { get; set; }

    [Column("size")]
    public long? Size { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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

    [Column("field_description", TypeName = "jsonb")]
    public string? FieldDescription { get; set; }

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
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("tracking")]
    public long? Tracking { get; set; }

    [Column("website_form_blacklisted")]
    public bool? WebsiteFormBlacklisted { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("IrModelFieldCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    //[InverseProperty("Field")]
    [NotMapped]
    public virtual ICollection<CrmLeadScoringFrequencyField> CrmLeadScoringFrequencyFields { get; set; } = new List<CrmLeadScoringFrequencyField>();

    //[InverseProperty("TimeField")]
    [NotMapped]
    public virtual ICollection<DataRecycleModel> DataRecycleModels { get; set; } = new List<DataRecycleModel>();

    //[InverseProperty("BatchDistinctiveFieldNavigation")]
    [NotMapped]
    public virtual ICollection<GamificationGoalDefinition> GamificationGoalDefinitionBatchDistinctiveFieldNavigations { get; set; } = new List<GamificationGoalDefinition>();

    //[InverseProperty("FieldDate")]
    [NotMapped]
    public virtual ICollection<GamificationGoalDefinition> GamificationGoalDefinitionFieldDates { get; set; } = new List<GamificationGoalDefinition>();

    //[InverseProperty("Field")]
    [NotMapped]
    public virtual ICollection<GamificationGoalDefinition> GamificationGoalDefinitionFields { get; set; } = new List<GamificationGoalDefinition>();

    //[InverseProperty("RelatedField")]
    [NotMapped]
    public virtual ICollection<IrModelField> InverseRelatedField { get; set; } = new List<IrModelField>();

    //[InverseProperty("RelationFieldNavigation")]
    [NotMapped]
    public virtual ICollection<IrModelField> InverseRelationFieldNavigation { get; set; } = new List<IrModelField>();

    //[InverseProperty("LinkField")]
    [NotMapped]
    public virtual ICollection<IrActServer> IrActServers { get; set; } = new List<IrActServer>();

    //[InverseProperty("UpdateField")]
    [NotMapped]
    public virtual ICollection<IrActServer> IrActServerUpdateFields { get; set; } = new List<IrActServer>();

    //[InverseProperty("Field")]
    [NotMapped]
    public virtual ICollection<IrDefault> IrDefaults { get; set; } = new List<IrDefault>();

    //[InverseProperty("Field")]
    [NotMapped]
    public virtual ICollection<IrModelFieldsSelection> IrModelFieldsSelections { get; set; } = new List<IrModelFieldsSelection>();

    //[InverseProperty("ParentField")]
    [NotMapped]
    public virtual ICollection<IrModelInherit> IrModelInherits { get; set; } = new List<IrModelInherit>();

    //[InverseProperty("WebsiteFormDefaultField")]
    [NotMapped]
    public virtual ICollection<IrModel> IrModels { get; set; } = new List<IrModel>();

    //[InverseProperty("Fields")]
    [NotMapped]
    public virtual ICollection<IrProperty> IrProperties { get; set; } = new List<IrProperty>();

    //[InverseProperty("Col1Navigation")]
    [NotMapped]
    public virtual ICollection<IrServerObjectLine> IrServerObjectLines { get; set; } = new List<IrServerObjectLine>();

    //[InverseProperty("FieldNavigation")]
    [NotMapped]
    public virtual ICollection<MailTrackingValue> MailTrackingValues { get; set; } = new List<MailTrackingValue>();

    [ForeignKey("ModelId")]
    //[InverseProperty("IrModelFields")]
    [NotMapped]
    public virtual IrModel? ModelNavigation { get; set; }

    [ForeignKey("RelatedFieldId")]
    //[InverseProperty("InverseRelatedField")]
    [NotMapped]
    public virtual IrModelField? RelatedField { get; set; }

    [ForeignKey("RelationFieldId")]
    //[InverseProperty("InverseRelationFieldNavigation")]
    [NotMapped]
    public virtual IrModelField? RelationFieldNavigation { get; set; }

    //[InverseProperty("Field")]
    [NotMapped]
    public virtual ICollection<WebsiteSaleExtraField> WebsiteSaleExtraFields { get; set; } = new List<WebsiteSaleExtraField>();

    [ForeignKey("LastModifierId")]
    //[InverseProperty("IrModelFieldWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    [ForeignKey("FieldId")]
    //[InverseProperty("Fields")]
    [NotMapped]
    public virtual ICollection<ResGroup> Groups { get; set; } = new List<ResGroup>();

    [ForeignKey("FieldId")]
    //[InverseProperty("Fields")]
    [NotMapped]
    public virtual ICollection<IrActServer> Servers { get; set; } = new List<IrActServer>();
}
