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

[Table("hr_plan")]
public partial class HrPlan: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("department_id")]
    public Guid? DepartmentId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("HrPlans")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("HrPlanCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("DepartmentId")]
    //[InverseProperty("HrPlans")]
    [NotMapped]
    public virtual HrDepartment? Department { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrPlanWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }
    
    //[InverseProperty("Plan")]
    [NotMapped]
    public virtual ICollection<HrPlanActivityType> HrPlanActivityTypes { get; } = new List<HrPlanActivityType>();

    //[InverseProperty("Plan")]
    [NotMapped]
    public virtual ICollection<HrPlanWizard> HrPlanWizards { get; } = new List<HrPlanWizard>();

}
