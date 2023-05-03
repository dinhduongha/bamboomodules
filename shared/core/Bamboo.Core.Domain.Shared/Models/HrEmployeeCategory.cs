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

[Table("hr_employee_category")]
//[Index("Name", Name = "hr_employee_category_name_uniq", IsUnique = true)]
public partial class HrEmployeeCategory: Entity<long>, IEntityDto<long>
{
    [Key]
    [Column("id")]
    public long Id { get => base.Id; set => base.Id = value; }

    [Column("color")]
    public long? Color { get; set; }

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
    //[InverseProperty("HrEmployeeCategoryCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrEmployeeCategoryWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("Category")]
    [NotMapped]
    public virtual ICollection<HrLeaveAllocation> HrLeaveAllocations { get; } = new List<HrLeaveAllocation>();

    //[InverseProperty("Category")]
    [NotMapped]
    public virtual ICollection<HrLeave> HrLeaves { get; } = new List<HrLeave>();

    [ForeignKey("CategoryId")]
    //[InverseProperty("Categories")]
    [NotMapped]
    public virtual ICollection<HrEmployee> Emps { get; } = new List<HrEmployee>();
}
