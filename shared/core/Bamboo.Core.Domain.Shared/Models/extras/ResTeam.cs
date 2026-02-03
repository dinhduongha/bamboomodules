using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

[Table("res_team")]
public partial class ResTeam : FullAuditedAggregateRoot<Guid>, IMultiTenant, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }
    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("organization_id")]
    public Guid? OrganizationId { get; set; } // FK to ResOrganization (khu vực)

    [Column("team_code")]
    public string TeamCode { get; set; } = null!;

    [Column("team_name")]
    public string TeamName { get; set; } = null!;

    [Column("supervisor_id")]
    public Guid? SupervisorId { get; set; } // Supervisor (Quản lý team)

    [Column("target_sales_amount")]
    public decimal? TargetSalesAmount { get; set; }

    [Column("target_visit_count")]
    public int? TargetVisitCount { get; set; }

    [Column("target_coverage_percent")]
    public decimal? TargetCoveragePercent { get; set; }

    [Column("is_active")]
    public bool IsActive { get; set; } = true;

    [Column("description")]
    public string? Description { get; set; }

    // Navigation
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("OrganizationId")]
    public virtual ResOrganization? Organization { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("SupervisorId")]
    public virtual ResUsers? Supervisor { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public virtual ICollection<ResUsers>? TeamMembers { get; set; } = new List<ResUsers>(); // NVBH trong team
}