using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("hr_employee")]
//[Index("CompanyId", Name = "hr_employee__company_id_index")]
//[Index("ResourceCalendarId", Name = "hr_employee__resource_calendar_id_index")]
//[Index("ResourceId", Name = "hr_employee__resource_id_index")]
//[Index("Barcode", Name = "hr_employee_barcode_uniq", IsUnique = true)]
//[Index("UserId", "CompanyId", Name = "hr_employee_user_uniq", IsUnique = true)]
public partial class HrEmployee
{
    [Column("address_home_id")]
    public Guid? AddressHomeId { get; set; }

    // [Many2one]
    [ForeignKey("AddressHomeId")]
    public virtual ResPartner? AddressHome { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("EmpId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Emp")] // One2many
    public virtual ICollection<HrApplicant> HrApplicant { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("EmployeeId")]
    [NotMapped] // One2many // Normal
    // [InverseProperty("Employee")] // One2many
    public virtual ICollection<ProjectCreateSaleOrderLine> ProjectCreateSaleOrderLine { get; set; }

    // [Many2many] // Normal
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] // Many2many // Normal
    // [ForeignKey("EmpId")] // Many2many // Normal
    // [InverseProperty("Emp")] // Many2many // Normal
    // public virtual ICollection<HrEmployeeCategory> Category { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("PlanWizardId")] //Many2many // Hidden
    // [InverseProperty("PlanWizard")] //Many2many // Hidden
    public virtual ICollection<HrPlanWizard> Employee { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("HrEmployeeId")] //Many2many // Hidden
    // [InverseProperty("HrEmployee")] //Many2many // Hidden
    public virtual ICollection<HrLeave> HrLeave { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("HrEmployeeId")] //Many2many // Hidden
    // [InverseProperty("HrEmployee")] //Many2many // Hidden
    public virtual ICollection<HrLeaveAllocation> HrLeaveAllocation { get; set; }

}
