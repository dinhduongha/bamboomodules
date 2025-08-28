using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("hr_leave")]
//[Index("DateFrom", Name = "hr_leave__date_from_index")]
//[Index("EmployeeId", Name = "hr_leave__employee_id_index")]
//[Index("UserId", Name = "hr_leave__user_id_index")]
//[Index("DateTo", "DateFrom", Name = "hr_leave_date_to_date_from_index")]
public partial class HrLeave
{
    [Column("holiday_allocation_id")]
    public Guid? HolidayAllocationId { get; set; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("category_id")]
    public Guid? CategoryId { get; set; }

    [Column("mode_company_id")]
    public Guid? ModeCompanyId { get; set; }

    [Column("holiday_type")]
    public string? HolidayType { get; set; }

    // [Column("request_hour_from")]
    // public string? RequestHourFrom { get; set; }

    // [Column("request_hour_to")]
    // public string? RequestHourTo { get; set; }

    [Column("report_note")]
    public string? ReportNote { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("multi_employee")]
    public bool? MultiEmployee { get; set; }

    // [Many2one]
    [ForeignKey("CategoryId")]
    public virtual HrEmployeeCategory? Category { get; set; }

    // [Many2one]
    [ForeignKey("HolidayAllocationId")]
    public virtual HrLeaveAllocation? HolidayAllocation { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ParentId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Parent")] // One2many
    public virtual ICollection<HrLeave> InverseParent { get; set; }

    // [Many2one]
    [ForeignKey("ModeCompanyId")]
    public virtual ResCompany? ModeCompany { get; set; }

    // [Many2one]
    [ForeignKey("ParentId")]
    public virtual HrLeave? Parent { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("HrLeaveId")] // Many2many // Normal
    // [InverseProperty("HrLeave")] // Many2many // Normal
    public virtual ICollection<HrEmployee> HrEmployee { get; set; }
}
