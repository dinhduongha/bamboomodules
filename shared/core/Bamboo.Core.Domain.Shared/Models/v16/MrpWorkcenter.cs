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

[Table("mrp_workcenter")]
//[Index("CompanyId", Name = "mrp_workcenter__company_id_index")]
//[Index("ResourceCalendarId", Name = "mrp_workcenter__resource_calendar_id_index")]
//[Index("ResourceId", Name = "mrp_workcenter__resource_id_index")]
public partial class MrpWorkcenter: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("resource_id")]
    public Guid? ResourceId { get; set; }

    [Column("resource_calendar_id")]
    public Guid? ResourceCalendarId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("code")]
    public string? Code { get; set; }

    [Column("working_state")]
    public string? WorkingState { get; set; }

    [Column("note")]
    public string? Note { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("time_efficiency")]
    public double? TimeEfficiency { get; set; }

    [Column("default_capacity")]
    public double? DefaultCapacity { get; set; }

    [Column("costs_hour")]
    public double? CostsHour { get; set; }

    [Column("time_start")]
    public double? TimeStart { get; set; }

    [Column("time_stop")]
    public double? TimeStop { get; set; }

    [Column("oee_target")]
    public double? OeeTarget { get; set; }

    [Column("expense_account_id")]
    public Guid? ExpenseAccountId { get; set; }

    [JsonField]
    [Column("analytic_distribution", TypeName = "jsonb")]
    public string? AnalyticDistribution { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("ExpenseAccountId")]
    public virtual AccountAccount? ExpenseAccount { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("WorkcenterId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Workcenter")] // One2many
    public virtual ICollection<MrpRoutingWorkcenter> MrpRoutingWorkcenter { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("WorkcenterId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Workcenter")] // One2many
    public virtual ICollection<MrpWorkcenterCapacity> MrpWorkcenterCapacity { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("WorkcenterId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Workcenter")] // One2many
    public virtual ICollection<MrpWorkcenterProductivity> MrpWorkcenterProductivity { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("WorkcenterId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Workcenter")] // One2many
    public virtual ICollection<MrpWorkorder> MrpWorkorder { get; set; }

    // [Many2one]
    [ForeignKey("ResourceId")]
    public virtual ResourceResource? Resource { get; set; }

    // [Many2one]
    [ForeignKey("ResourceCalendarId")]
    public virtual ResourceCalendar? ResourceCalendar { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("MrpWorkcenterId")] //Many2many // Hidden
    // [InverseProperty("MrpWorkcenter")] //Many2many // Hidden
    public virtual ICollection<AccountAnalyticAccount> AccountAnalyticAccount { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("WorkcenterId")] // Many2many // Normal
    // [InverseProperty("Workcenter")] // Many2many // Normal
    public virtual ICollection<MrpWorkcenter> AlternativeWorkcenter { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("MrpWorkcenterId")] // Many2many // Normal
    // [InverseProperty("MrpWorkcenter")] // Many2many // Normal
    public virtual ICollection<MrpWorkcenterTag> MrpWorkcenterTag { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("AlternativeWorkcenterId")] // Many2many // Normal
    // [InverseProperty("AlternativeWorkcenter")] // Many2many // Normal
    public virtual ICollection<MrpWorkcenter> Workcenter { get; set; }
}
