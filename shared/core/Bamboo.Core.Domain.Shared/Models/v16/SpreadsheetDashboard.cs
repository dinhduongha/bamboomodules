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

[Table("spreadsheet_dashboard")]
public partial class SpreadsheetDashboard: FullAuditedEntity<Guid>, IEntityDto<Guid>, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("dashboard_group_id")]
    public Guid? DashboardGroupId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("sample_dashboard_file_path")]
    public string? SampleDashboardFilePath { get; set; }

    // v16-Compat json
    //[Column("name")]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("is_published")]
    public bool? IsPublished { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("SpreadsheetDashboards")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("SpreadsheetDashboardCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("DashboardGroupId")]
    //[InverseProperty("SpreadsheetDashboards")]
    [NotMapped]
    public virtual SpreadsheetDashboardGroup? DashboardGroup { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("SpreadsheetDashboardWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Dashboard")]
    [NotMapped]
    public virtual ICollection<SpreadsheetDashboardShare> SpreadsheetDashboardShares { get; set; } = new List<SpreadsheetDashboardShare>();

    [ForeignKey("SpreadsheetDashboardId")]
    //[InverseProperty("SpreadsheetDashboards")]
    [NotMapped]
    public virtual ICollection<IrModel> IrModels { get; set; } = new List<IrModel>();

    [ForeignKey("SpreadsheetDashboardId")]
    //[InverseProperty("SpreadsheetDashboards")]
    [NotMapped]
    public virtual ICollection<ResGroup> ResGroups { get; set; } = new List<ResGroup>();
}
