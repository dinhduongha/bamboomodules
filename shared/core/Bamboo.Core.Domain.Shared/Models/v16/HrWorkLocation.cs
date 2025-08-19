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

[Table("hr_work_location")]
public partial class HrWorkLocation: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }

    [Column("address_id")]
    public Guid? AddressId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("location_type")]
    public string? LocationType { get; set; }

    [Column("location_number")]
    public string? LocationNumber { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    // [Many2one]
    [ForeignKey("AddressId")]
    // [InverseProperty("HrWorkLocation")] //Many2one
    public virtual ResPartner? Address { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("HrWorkLocation")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("HrWorkLocationCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    [ForeignKey("WorkLocationId")]
    [InverseProperty("WorkLocation")]
    public virtual ICollection<HomeworkLocationWizard> HomeworkLocationWizard { get; set; }

    // [One2many]
    [ForeignKey("FridayLocationId")]
    [InverseProperty("FridayLocation")]
    public virtual ICollection<HrEmployee> HrEmployeeFridayLocation { get; set; }

    // [One2many]
    [ForeignKey("WorkLocationId")]
    [InverseProperty("WorkLocation")]
    public virtual ICollection<HrEmployeeLocation> HrEmployeeLocation { get; set; }

    // [One2many]
    [ForeignKey("MondayLocationId")]
    [InverseProperty("MondayLocation")]
    public virtual ICollection<HrEmployee> HrEmployeeMondayLocation { get; set; }

    // [One2many]
    [ForeignKey("SaturdayLocationId")]
    [InverseProperty("SaturdayLocation")]
    public virtual ICollection<HrEmployee> HrEmployeeSaturdayLocation { get; set; }

    // [One2many]
    [ForeignKey("SundayLocationId")]
    [InverseProperty("SundayLocation")]
    public virtual ICollection<HrEmployee> HrEmployeeSundayLocation { get; set; }

    // [One2many]
    [ForeignKey("ThursdayLocationId")]
    [InverseProperty("ThursdayLocation")]
    public virtual ICollection<HrEmployee> HrEmployeeThursdayLocation { get; set; }

    // [One2many]
    [ForeignKey("TuesdayLocationId")]
    [InverseProperty("TuesdayLocation")]
    public virtual ICollection<HrEmployee> HrEmployeeTuesdayLocation { get; set; }

    // [One2many]
    [ForeignKey("WednesdayLocationId")]
    [InverseProperty("WednesdayLocation")]
    public virtual ICollection<HrEmployee> HrEmployeeWednesdayLocation { get; set; }

    // [One2many]
    [ForeignKey("WorkLocationId")]
    [InverseProperty("WorkLocation")]
    public virtual ICollection<HrEmployee> HrEmployeeWorkLocation { get; set; }

    // [One2many]
    [ForeignKey("WorkLocationId")]
    [InverseProperty("WorkLocation")]
    public virtual ICollection<HrEmployee> HrEmployee { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("HrWorkLocationWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }
}
