using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

//[Keyless]
public partial class HrLeaveReportCalendar: Entity<Guid>, IMultiTenant
{
    [Column("id")]
    public Guid? Id { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("start_datetime", TypeName = "timestamp without time zone")]
    public DateTime? StartDatetime { get; set; }

    [Column("stop_datetime", TypeName = "timestamp without time zone")]
    public DateTime? StopDatetime { get; set; }

    [Column("employee_id")]
    public Guid? EmployeeId { get; set; }

    [Column("state", TypeName = "character varying")]
    public string? State { get; set; }

    [Column("department_id")]
    public Guid? DepartmentId { get; set; }

    [Column("duration")]
    public double? Duration { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("job_id")]
    public Guid? JobId { get; set; }

    [Column("tz", TypeName = "character varying")]
    public string? Tz { get; set; }

    [Column("is_striked")]
    public bool? IsStriked { get; set; }

    [Column("is_hatched")]
    public bool? IsHatched { get; set; }
}
