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
public partial class SpreadsheetDashboard: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("dashboard_group_id")]
    public Guid? DashboardGroupId { get; set; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("sample_dashboard_file_path")]
    public string? SampleDashboardFilePath { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    // v16-Compat
    //[Column("name")]
    //public string? Name { get; set; }

    [Column("is_published")]
    public bool? IsPublished { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("SpreadsheetDashboard")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("SpreadsheetDashboardCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("DashboardGroupId")]
    // [InverseProperty("SpreadsheetDashboard")] //Many2one
    public virtual SpreadsheetDashboardGroup? DashboardGroup { get; set; }

    // [One2many]
    [ForeignKey("DashboardId")]
    [InverseProperty("Dashboard")]
    public virtual ICollection<SpreadsheetDashboardShare> SpreadsheetDashboardShare { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("SpreadsheetDashboardWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("SpreadsheetDashboardId")] //Many2many
    // [InverseProperty("SpreadsheetDashboard")] //Many2many
    public virtual ICollection<IrModel> IrModel { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("SpreadsheetDashboardId")] //Many2many
    // [InverseProperty("SpreadsheetDashboard")] //Many2many
    public virtual ICollection<ResGroups> ResGroups { get; set; }
}
