using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

[Table("dms_demand_forecast")]
public partial class DmsDemandForecast : FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId { get; set; }

    [Column("product_id")]
    public Guid ProductId { get; set; }

    [Column("partner_id")]
    public Guid? PartnerId { get; set; }

    [Column("period")]
    public string Period { get; set; } = "month";

    [Column("forecast_qty")]
    public decimal ForecastQty { get; set; }

    [Column("confidence_score")]
    public decimal ConfidenceScore { get; set; }

    [Column("based_on_history_json")]
    public string? BasedOnHistoryJson { get; set; }

    [Column("season_factor")]
    public decimal SeasonFactor { get; set; }

    [Column("forecast_date")]
    public DateTime ForecastDate { get; set; }

    [Column("status")]
    public string Status { get; set; } = "draft";

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("ProductId")]
    public virtual ProductProduct? Product { get; set; }
}