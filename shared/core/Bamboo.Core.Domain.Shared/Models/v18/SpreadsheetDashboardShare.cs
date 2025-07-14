using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bamboo.Core.Models;

[Table("spreadsheet_dashboard_share")]
public partial class SpreadsheetDashboardShare: FullAuditedEntity<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("dashboard_id")]
    public Guid? DashboardId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("access_token")]
    public string? AccessToken { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("SpreadsheetDashboardShareCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("DashboardId")]
    //[InverseProperty("SpreadsheetDashboardShares")]
    [NotMapped]
    public virtual SpreadsheetDashboard? Dashboard { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("SpreadsheetDashboardShareWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
