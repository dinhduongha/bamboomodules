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

[Table("digest_digest")]
public partial class DigestDigest: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("periodicity")]
    public string? Periodicity { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("next_run_date")]
    public DateTime? NextRunDate { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("kpi_res_users_connected")]
    public bool? KpiResUsersConnected { get; set; }

    [Column("kpi_mail_message_total")]
    public bool? KpiMailMessageTotal { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("kpi_account_total_revenue")]
    public bool? KpiAccountTotalRevenue { get; set; }

    [Column("kpi_all_sale_total")]
    public bool? KpiAllSaleTotal { get; set; }

    [Column("kpi_pos_total")]
    public bool? KpiPosTotal { get; set; }

    [Column("kpi_crm_lead_created")]
    public bool? KpiCrmLeadCreated { get; set; }

    [Column("kpi_crm_opportunities_won")]
    public bool? KpiCrmOpportunitiesWon { get; set; }

    [Column("kpi_project_task_opened")]
    public bool? KpiProjectTaskOpened { get; set; }

    [Column("kpi_hr_recruitment_new_colleagues")]
    public bool? KpiHrRecruitmentNewColleagues { get; set; }

    [Column("kpi_website_sale_total")]
    public bool? KpiWebsiteSaleTotal { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("DigestDigests")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("DigestDigestCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("DigestDigestWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Digest")]
    [NotMapped]
    public virtual ICollection<ResConfigSetting> ResConfigSettings { get; } = new List<ResConfigSetting>();

    [ForeignKey("DigestDigestId")]
    //[InverseProperty("DigestDigests")]
    [NotMapped]
    public virtual ICollection<ResUser> ResUsers { get; } = new List<ResUser>();
}
