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
public partial class FleetServiceType: Entity<long>, IEntityDto<long>
{
    [Key]
    [Column("id")]
    public long Id { get => base.Id; set => base.Id = value; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("category")]
    public string? Category { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("FleetServiceTypeCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("FleetServiceTypeWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("CostSubtype")]
    [NotMapped]
    public virtual ICollection<FleetVehicleLogContract> FleetVehicleLogContractsNavigation { get; } = new List<FleetVehicleLogContract>();

    //[InverseProperty("ServiceType")]
    [NotMapped]
    public virtual ICollection<FleetVehicleLogService> FleetVehicleLogServices { get; } = new List<FleetVehicleLogService>();

    [ForeignKey("FleetServiceTypeId")]
    //[InverseProperty("FleetServiceTypes")]
    [NotMapped]
    public virtual ICollection<FleetVehicleLogContract> FleetVehicleLogContracts { get; } = new List<FleetVehicleLogContract>();
}
