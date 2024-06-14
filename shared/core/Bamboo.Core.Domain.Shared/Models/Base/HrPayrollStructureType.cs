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

[Table("hr_payroll_structure_type")]
public partial class HrPayrollStructureType: Entity<long>, IEntityDto<long>
{
    [Key]
    [Column("id")]
    public long Id { get => base.Id; set => base.Id = value; }

    [Column("default_resource_calendar_id")]
    public Guid? DefaultResourceCalendarId { get; set; }

    [Column("country_id")]
    public long? CountryId { get; set; }

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

    [ForeignKey("CountryId")]
    //[InverseProperty("HrPayrollStructureTypes")]
    [NotMapped]
    public virtual ResCountry? Country { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("HrPayrollStructureTypeCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("DefaultResourceCalendarId")]
    //[InverseProperty("HrPayrollStructureTypes")]
    [NotMapped]
    public virtual ResourceCalendar? DefaultResourceCalendar { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrPayrollStructureTypeWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("StructureType")]
    [NotMapped]
    public virtual ICollection<HrContract> HrContracts { get; } = new List<HrContract>();

}
