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
    public virtual ResPartner? Address { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    public virtual ResUsers? CreateU { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("WorkLocationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("WorkLocation")] // One2many
    public virtual ICollection<HomeworkLocationWizard> HomeworkLocationWizard { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("FridayLocationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("FridayLocation")] // One2many
    public virtual ICollection<HrEmployee> HrEmployeeFridayLocation { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("WorkLocationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("WorkLocation")] // One2many
    public virtual ICollection<HrEmployeeLocation> HrEmployeeLocation { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("MondayLocationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("MondayLocation")] // One2many
    public virtual ICollection<HrEmployee> HrEmployeeMondayLocation { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("SaturdayLocationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SaturdayLocation")] // One2many
    public virtual ICollection<HrEmployee> HrEmployeeSaturdayLocation { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("SundayLocationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("SundayLocation")] // One2many
    public virtual ICollection<HrEmployee> HrEmployeeSundayLocation { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ThursdayLocationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("ThursdayLocation")] // One2many
    public virtual ICollection<HrEmployee> HrEmployeeThursdayLocation { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("TuesdayLocationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("TuesdayLocation")] // One2many
    public virtual ICollection<HrEmployee> HrEmployeeTuesdayLocation { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("WednesdayLocationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("WednesdayLocation")] // One2many
    public virtual ICollection<HrEmployee> HrEmployeeWednesdayLocation { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("WorkLocationId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("WorkLocation")] // One2many
    public virtual ICollection<HrEmployee> HrEmployeeWorkLocation { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    public virtual ResUsers? WriteU { get; set; }
}
