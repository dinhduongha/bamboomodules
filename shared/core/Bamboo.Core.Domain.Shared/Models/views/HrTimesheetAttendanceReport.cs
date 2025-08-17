using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

//[Keyless]
public partial class HrTimesheetAttendanceReport: Entity<Guid>, IMultiTenant
{
    [Column("id")]
    public Guid? Id { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    [Column("date")]
    public DateTime? Date { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("total_attendance")]
    public double? TotalAttendance { get; set; }

    [Column("total_timesheet")]
    public double? TotalTimesheet { get; set; }

    [Column("total_difference")]
    public double? TotalDifference { get; set; }

    [Column("timesheets_cost")]
    public double? TimesheetsCost { get; set; }

    [Column("attendance_cost")]
    public double? AttendanceCost { get; set; }

    [Column("cost_difference")]
    public double? CostDifference { get; set; }
}
