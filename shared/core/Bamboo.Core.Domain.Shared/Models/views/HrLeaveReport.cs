using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

//[Keyless]
public partial class HrLeaveReport: Entity<Guid>, IMultiTenant
{
    [Column("id")]
    public Guid? Id { get; set; }

    [Column("allocation_id")]
    public Guid? AllocationId { get; set; }

    [Column("leave_id")]
    public Guid? LeaveId { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    [Column("name", TypeName = "character varying")]
    public string? Name { get; set; }

    [Column("active_employee")]
    public bool? ActiveEmployee { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("number_of_days")]
    public double? NumberOfDays { get; set; }

    [Column("leave_type")]
    public string? LeaveType { get; set; }

    [Column("category_id")]
    public Guid? CategoryId { get; set; }

    [Column("department_id")]
    public Guid? DepartmentId { get; set; }

    [Column("holiday_status_id")]
    public Guid? HolidayStatusId { get; set; }

    [Column("state", TypeName = "character varying")]
    public string? State { get; set; }

    [Column("holiday_type", TypeName = "character varying")]
    public string? HolidayType { get; set; }

    [Column("date_from", TypeName = "timestamp without time zone")]
    public DateTime? DateFrom { get; set; }

    [Column("date_to", TypeName = "timestamp without time zone")]
    public DateTime? DateTo { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }
}
