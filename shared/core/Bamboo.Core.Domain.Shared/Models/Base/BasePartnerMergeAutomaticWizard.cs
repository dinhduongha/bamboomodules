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
public partial class BasePartnerMergeAutomaticWizard: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("number_group")]
    public long? NumberGroup { get; set; }

    [Column("current_line_id")]
    public Guid? CurrentLineId { get; set; }

    [Column("dst_partner_id")]
    public Guid? DstPartnerId { get; set; }

    [Column("maximum_group")]
    public long? MaximumGroup { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("BasePartnerMergeAutomaticWizardCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("CurrentLineId")]
    //[InverseProperty("BasePartnerMergeAutomaticWizards")]
    [NotMapped]
    public virtual BasePartnerMergeLine? CurrentLine { get; set; }

    [ForeignKey("DstPartnerId")]
    //[InverseProperty("BasePartnerMergeAutomaticWizards")]
    [NotMapped]
    public virtual ResPartner? DstPartner { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("BasePartnerMergeAutomaticWizardWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Wizard")]
    [NotMapped]
    public virtual ICollection<BasePartnerMergeLine> BasePartnerMergeLines { get; } = new List<BasePartnerMergeLine>();

    [ForeignKey("BasePartnerMergeAutomaticWizardId")]
    //[InverseProperty("BasePartnerMergeAutomaticWizardsNavigation")]
    [NotMapped]
    public virtual ICollection<ResPartner> ResPartners { get; } = new List<ResPartner>();
}
