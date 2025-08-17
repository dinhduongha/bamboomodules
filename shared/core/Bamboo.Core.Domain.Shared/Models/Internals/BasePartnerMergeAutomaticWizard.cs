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

[Table("base_partner_merge_automatic_wizard")]
public partial class BasePartnerMergeAutomaticWizard: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("number_group")]
    public long? NumberGroup { get; set; }

    [Column("current_line_id")]
    public Guid? CurrentLineId { get; set; }

    [Column("dst_partner_id")]
    public Guid? DstPartnerId { get; set; }

    [Column("maximum_group")]
    public long? MaximumGroup { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("group_by_email")]
    public bool? GroupByEmail { get; set; }

    [Column("group_by_name")]
    public bool? GroupByName { get; set; }

    [Column("group_by_is_company")]
    public bool? GroupByIsCompany { get; set; }

    [Column("group_by_vat")]
    public bool? GroupByVat { get; set; }

    [Column("group_by_parent_id")]
    public bool? GroupByParentId { get; set; }

    [Column("exclude_contact")]
    public bool? ExcludeContact { get; set; }

    [Column("exclude_journal_item")]
    public bool? ExcludeJournalItem { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [One2many]
    [ForeignKey("WizardId")]
    [InverseProperty("Wizard")]
    public virtual ICollection<BasePartnerMergeLine> BasePartnerMergeLine { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("BasePartnerMergeAutomaticWizardCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("CurrentLineId")]
    // [InverseProperty("BasePartnerMergeAutomaticWizard")] //Many2one
    public virtual BasePartnerMergeLine? CurrentLine { get; set; }

    // [Many2one]
    [ForeignKey("DstPartnerId")]
    // [InverseProperty("BasePartnerMergeAutomaticWizard")] //Many2one
    public virtual ResPartner? DstPartner { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("BasePartnerMergeAutomaticWizardWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("BasePartnerMergeAutomaticWizardId")] //Many2many
    // [InverseProperty("BasePartnerMergeAutomaticWizardNavigation")] //Many2many
    public virtual ICollection<ResPartner> ResPartner { get; set; }
}
