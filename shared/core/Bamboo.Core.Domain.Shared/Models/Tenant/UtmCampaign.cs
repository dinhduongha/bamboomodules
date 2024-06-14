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

[Table("utm_campaign")]
//[Index("Name", Name = "utm_campaign_unique_name", IsUnique = true)]
public partial class UtmCampaign: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("stage_id")]
    public long? StageId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("title", TypeName = "jsonb")]
    public string? Title { get; set; }

    [Column("is_auto_campaign")]
    public bool? IsAutoCampaign { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("UtmCampaigns")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("UtmCampaignCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("StageId")]
    //[InverseProperty("UtmCampaigns")]
    [NotMapped]
    public virtual UtmStage? Stage { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("UtmCampaignUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("UtmCampaignWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Campaign")]
    [NotMapped]
    public virtual ICollection<AccountMove> AccountMoves { get; } = new List<AccountMove>();

    //[InverseProperty("Campaign")]
    [NotMapped]
    public virtual ICollection<CrmLead> CrmLeads { get; } = new List<CrmLead>();

    //[InverseProperty("Campaign")]
    [NotMapped]
    public virtual ICollection<HrApplicant> HrApplicants { get; } = new List<HrApplicant>();

    //[InverseProperty("Campaign")]
    [NotMapped]
    public virtual ICollection<SaleOrder> SaleOrders { get; } = new List<SaleOrder>();

    [ForeignKey("TagId")]
    //[InverseProperty("Tags")]
    [NotMapped]
    public virtual ICollection<UtmTag> Campaigns { get; } = new List<UtmTag>();
}
