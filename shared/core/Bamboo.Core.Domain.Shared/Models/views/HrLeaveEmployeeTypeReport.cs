using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

//[Keyless]
public partial class HrLeaveEmployeeTypeReport: Entity<Guid>, IMultiTenant
{
    [Column("id")]
    public Guid? Id { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    [Column("active_employee")]
    public bool? ActiveEmployee { get; set; }

    [Column("number_of_days")]
    public double? NumberOfDays { get; set; }

    [Column("department_id")]
    public Guid? DepartmentId { get; set; }

    [Column("leave_type")]
    public Guid? LeaveType { get; set; }

    [Column("holiday_status")]
    public string? HolidayStatus { get; set; }

    [Column("state", TypeName = "character varying")]
    public string? State { get; set; }

    [Column("date_from", TypeName = "timestamp without time zone")]
    public DateTime? DateFrom { get; set; }

    [Column("date_to", TypeName = "timestamp without time zone")]
    public DateTime? DateTo { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }
}
