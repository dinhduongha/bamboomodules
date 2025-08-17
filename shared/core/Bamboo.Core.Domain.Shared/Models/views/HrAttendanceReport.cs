using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

//[Keyless]
public partial class HrAttendanceReport: Entity<Guid>, IMultiTenant
{
    [Column("id")]
    public Guid? Id { get; set; }

    [Column("department_id")]
    public Guid? DepartmentId { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("check_in")]
    public DateTime? CheckIn { get; set; }

    [Column("worked_hours")]
    public double? WorkedHours { get; set; }

    [Column("overtime_hours")]
    public double? OvertimeHours { get; set; }
}
