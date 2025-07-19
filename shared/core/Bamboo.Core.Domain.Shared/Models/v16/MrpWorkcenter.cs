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
//[Index("TenantId", Name = "mrp_workcenter_company_id_index")]
//[Index("ResourceCalendarId", Name = "mrp_workcenter_resource_calendar_id_index")]
//[Index("ResourceId", Name = "mrp_workcenter_resource_id_index")]
public partial class MrpWorkcenter: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("resource_id")]
    public Guid? ResourceId { get; set; }

    [Column("resource_calendar_id")]
    public Guid? ResourceCalendarId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

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
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

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

    [Column("analytic_distribution", TypeName = "jsonb")]
    public string? AnalyticDistribution { get; set; }

    // v16-Compat
    [Column("costs_hour_account_id")]
    public Guid? CostsHourAccountId { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("MrpWorkcenters")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CostsHourAccountId")]
    //[InverseProperty("MrpWorkcenters")]
    [NotMapped]
    public virtual AccountAnalyticAccount? CostsHourAccount { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MrpWorkcenterCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ResourceId")]
    //[InverseProperty("MrpWorkcenters")]
    [NotMapped]
    public virtual ResourceResource? Resource { get; set; }

    [ForeignKey("ResourceCalendarId")]
    //[InverseProperty("MrpWorkcenters")]
    [NotMapped]
    public virtual ResourceCalendar? ResourceCalendar { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MrpWorkcenterWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    // RELATIONS BEGIN - MUST HAVE
    //[ForeignKey("MrpWorkcenterId")]
    //[InverseProperty("MrpWorkcenters")]
    //[NotMapped]
    //public virtual ICollection<AccountAnalyticAccount> AccountAnalyticAccounts { get; set; } = new List<AccountAnalyticAccount>();
    // RELATIONS END

    //[InverseProperty("Workcenter")]
    [NotMapped]
    public virtual ICollection<MrpRoutingWorkcenter> MrpRoutingWorkcenters { get; set; } = new List<MrpRoutingWorkcenter>();

    //[InverseProperty("Workcenter")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenterCapacity> MrpWorkcenterCapacities { get; set; } = new List<MrpWorkcenterCapacity>();

    //[InverseProperty("Workcenter")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenterProductivity> MrpWorkcenterProductivities { get; set; } = new List<MrpWorkcenterProductivity>();

    //[InverseProperty("Workcenter")]
    [NotMapped]
    public virtual ICollection<MrpWorkorder> MrpWorkorders { get; set; } = new List<MrpWorkorder>();

    [ForeignKey("WorkcenterId")]
    //[InverseProperty("Workcenters")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenter> AlternativeWorkcenters { get; set; } = new List<MrpWorkcenter>();

    [ForeignKey("MrpWorkcenterId")]
    //[InverseProperty("MrpWorkcenters")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenterTag> MrpWorkcenterTags { get; set; } = new List<MrpWorkcenterTag>();

    [ForeignKey("AlternativeWorkcenterId")]
    //[InverseProperty("AlternativeWorkcenters")]
    [NotMapped]
    public virtual ICollection<MrpWorkcenter> Workcenters { get; set; } = new List<MrpWorkcenter>();
}
