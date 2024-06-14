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

[Table("hr_departure_reason")]
public partial class HrDepartureReason: Entity<long>, IEntityDto<long>
{
    [Key]
    [Column("id")]
    public long Id { get => base.Id; set => base.Id = value; }

    [Column("sequence", TypeName = "bigserial")]
    public long Sequence { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name", TypeName = "jsonb")]
    public string? Name { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("HrDepartureReasonCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrDepartureReasonWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("DepartureReason")]
    [NotMapped]
    public virtual ICollection<HrDepartureWizard> HrDepartureWizards { get; } = new List<HrDepartureWizard>();

    //[InverseProperty("DepartureReason")]
    [NotMapped]
    public virtual ICollection<HrEmployee> HrEmployees { get; } = new List<HrEmployee>();

}
