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

//[Table("hr_leave_allocation")]
//[Index("DateFrom", Name = "hr_leave_allocation__date_from_index")]
//[Index("EmployeeId", Name = "hr_leave_allocation__employee_id_index")]
public partial class HrLeaveAllocation
{
    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("mode_company_id")]
    public Guid? ModeCompanyId { get; set; }

    [Column("category_id")]
    public Guid? CategoryId { get; set; }

    [Column("private_name")]
    public string? PrivateName { get; set; }

    [Column("holiday_type")]
    public string? HolidayType { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("multi_employee")]
    public bool? MultiEmployee { get; set; }

    // [Many2one]
    [ForeignKey("CategoryId")]
    public virtual HrEmployeeCategory? Category { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("HolidayAllocationId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("HolidayAllocation")] // One2many
    public virtual ICollection<HrLeave> HrLeave { get; set; }

    // [One2many]
    // [One2many] [ForeignKey("ParentId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Parent")] // One2many
    public virtual ICollection<HrLeaveAllocation> InverseParent { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("ModeCompanyId")]
    public virtual ResCompany? ModeCompany { get; set; }

    // [Many2one]
    [ForeignKey("ParentId")]
    public virtual HrLeaveAllocation? Parent { get; set; }

    // [Many2many] // Normal
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("HrLeaveAllocationId")] // Many2many // Normal
    // [InverseProperty("HrLeaveAllocation")] // Many2many // Normal
    public virtual ICollection<HrEmployee> HrEmployee { get; set; }
}
