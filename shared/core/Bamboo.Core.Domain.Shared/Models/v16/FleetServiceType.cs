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

[Table("fleet_service_type")]
public partial class FleetServiceType: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("category")]
    public string? Category { get; set; }

    [JsonField]
    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("FleetServiceTypeCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("CostSubtypeId")]
    [InverseProperty("CostSubtype")]
    public virtual ICollection<FleetVehicleLogContract> FleetVehicleLogContractNavigation { get; set; }

    // [One2many]
    [ForeignKey("ServiceTypeId")]
    [InverseProperty("ServiceType")]
    public virtual ICollection<FleetVehicleLogServices> FleetVehicleLogServices { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("FleetServiceTypeWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("FleetServiceTypeId")]
    // [InverseProperty("FleetServiceType")]
    public virtual ICollection<FleetVehicleLogContract> FleetVehicleLogContract { get; set; }
}
