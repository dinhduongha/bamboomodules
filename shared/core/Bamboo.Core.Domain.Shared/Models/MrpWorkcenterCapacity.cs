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

[Table("mrp_workcenter_capacity")]
//[Index("WorkcenterId", "ProductId", Name = "mrp_workcenter_capacity_unique_product", IsUnique = true)]
public partial class MrpWorkcenterCapacity: Entity<Guid>, IEntityDto<Guid>
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("workcenter_id")]
    public Guid? WorkcenterId { get; set; }

    [Column("product_id")]
    public Guid? ProductId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("capacity")]
    public double? Capacity { get; set; }

    [Column("time_start")]
    public double? TimeStart { get; set; }

    [Column("time_stop")]
    public double? TimeStop { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("MrpWorkcenterCapacityCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("ProductId")]
    //[InverseProperty("MrpWorkcenterCapacities")]
    [NotMapped]
    public virtual ProductProduct? Product { get; set; }

    [ForeignKey("WorkcenterId")]
    //[InverseProperty("MrpWorkcenterCapacities")]
    [NotMapped]
    public virtual MrpWorkcenter? Workcenter { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("MrpWorkcenterCapacityWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
}
