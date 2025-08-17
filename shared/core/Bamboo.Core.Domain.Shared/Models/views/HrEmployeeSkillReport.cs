using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

//[Keyless]
public partial class HrEmployeeSkillReport: Entity<Guid>, IMultiTenant
{
    [Column("id")]
    public Guid? Id { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("department_id")]
    public Guid? DepartmentId { get; set; }

    [Column("skill_id")]
    public Guid? SkillId { get; set; }

    [Column("skill_type_id")]
    public Guid? SkillTypeId { get; set; }

    [Column("level_progress")]
    public decimal? LevelProgress { get; set; }

    [Column("skill_level", TypeName = "character varying")]
    public string? SkillLevel { get; set; }
}
