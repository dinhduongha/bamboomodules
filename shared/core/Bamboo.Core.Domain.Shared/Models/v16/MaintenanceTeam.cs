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

[Table("maintenance_team")]
public partial class MaintenanceTeam: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("MaintenanceTeamId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MaintenanceTeam")] // One2many
    public virtual ICollection<MaintenanceEquipment> MaintenanceEquipment { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("MaintenanceTeamId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MaintenanceTeam")] // One2many
    public virtual ICollection<MaintenanceRequest> MaintenanceRequest { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    [NotMapped] // Many2many // Peer relationship (ResUsers) is commented out
    // [ForeignKey("MaintenanceTeamId")] // Many2many // Normal
    // [InverseProperty("MaintenanceTeam")] // Many2many // Normal
    public virtual ICollection<ResUsers> ResUsers { get; set; }
}
