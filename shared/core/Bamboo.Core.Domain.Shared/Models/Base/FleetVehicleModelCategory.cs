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

[Table("fleet_vehicle_model_category")]
//[Index("Name", Name = "fleet_vehicle_model_category_name_uniq", IsUnique = true)]
public partial class FleetVehicleModelCategory: Entity<long>, IEntityDto<long>
{
    [Key]
    [Column("id")]
    public long Id { get => base.Id; set => base.Id = value; }

    [Column("sequence")]
    public long? Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("FleetVehicleModelCategoryCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("FleetVehicleModelCategoryWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Category")]
    [NotMapped]
    public virtual ICollection<FleetVehicleModel> FleetVehicleModels { get; } = new List<FleetVehicleModel>();

    //[InverseProperty("Category")]
    [NotMapped]
    public virtual ICollection<FleetVehicle> FleetVehicles { get; } = new List<FleetVehicle>();

}
