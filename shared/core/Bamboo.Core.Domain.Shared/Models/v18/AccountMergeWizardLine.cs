using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bamboo.Core.Models;

[Table("account_merge_wizard_line")]
public partial class AccountMergeWizardLine: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("wizard_id")]
    public Guid? WizardId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("account_id")]
    public Guid? AccountId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("grouping_key")]
    public string? GroupingKey { get; set; }

    [Column("display_type")]
    public string? DisplayType { get; set; }

    [Column("is_selected")]
    public bool? IsSelected { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("AccountId")]
    //[InverseProperty("AccountMergeWizardLines")]
    [NotMapped]
    public virtual AccountAccount? Account { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("AccountMergeWizardLineCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("WizardId")]
    //[InverseProperty("AccountMergeWizardLines")]
    [NotMapped]
    public virtual AccountMergeWizard? Wizard { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("AccountMergeWizardLineWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
