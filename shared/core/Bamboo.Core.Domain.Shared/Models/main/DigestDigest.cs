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

[Table("digest_digest")]
public partial class DigestDigest : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("periodicity")]
    public string? Periodicity { get; set; }

    [Column("state")]
    public string? State { get; set; }

    [Column("next_run_date")]
    public DateTime? NextRunDate { get; set; }

    [JsonField(IsSparse = false)] // Name
    [Column("name", TypeName = "jsonb")]
    public StringDictionary? Name { get; set; }

    [Column("kpi_res_users_connected")]
    public bool? KpiResUsersConnected { get; set; }

    [Column("kpi_mail_message_total")]
    public bool? KpiMailMessageTotal { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

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

    [Column("kpi_hr_recruitment_new_colleagues")]
    public bool? KpiHrRecruitmentNewColleagues { get; set; }

    [Column("kpi_project_task_opened")]
    public bool? KpiProjectTaskOpened { get; set; }

    [Column("kpi_website_sale_total")]
    public bool? KpiWebsiteSaleTotal { get; set; }

    [Column("kpi_livechat_rating")]
    public bool? KpiLivechatRating { get; set; }

    [Column("kpi_livechat_conversations")]
    public bool? KpiLivechatConversations { get; set; }

    [Column("kpi_livechat_response")]
    public bool? KpiLivechatResponse { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("DigestId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Digest")] // One2many
    public virtual ICollection<ResConfigSettings> ResConfigSettings { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] // Many2many // Peer relationship (ResUsers) is commented out
    // [ForeignKey("DigestDigestId")] // Many2many // Normal
    // [InverseProperty("DigestDigest")] // Many2many // Normal
    public virtual ICollection<ResUsers> ResUsers { get; set; }
}
