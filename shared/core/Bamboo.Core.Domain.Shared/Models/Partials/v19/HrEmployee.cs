using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

public partial class HrEmployee
{
    [Column("current_version_id")]
    public Guid? CurrentVersionId { get; set; }

    // [Column("country_of_birth")]
    // public Guid? CountryOfBirth { get; set; }

    // [Column("legal_name")]
    // public string? LegalName { get; set; }

    [JsonField] // SalaryDistribution
    [Column("salary_distribution", TypeName = "jsonb")]
    public JsonElement? SalaryDistribution { get; set; }

    [Column("birthday_public_display")]
    public bool? BirthdayPublicDisplay { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("EmployeeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Employee")] // One2many
    public virtual ICollection<AccountAnalyticLineCalendarEmployee> AccountAnalyticLineCalendarEmployee { get; set; }

    // [Many2one]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [ForeignKey("CurrentVersionId")]
    public virtual HrVersion? CurrentVersion { get; set; }

    // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // // [One2many] [ForeignKey("EmployeeId")]
    // // [NotMapped] // One2many // Normal
    // // [InverseProperty("Employee")] // One2many
    // public virtual ICollection<HrApplicant> HrApplicant { get; set; }

    // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // // [One2many] [ForeignKey("EmployeeId")]
    // // [NotMapped] // One2many // Normal
    // // [InverseProperty("Employee")] // One2many
    // public virtual ICollection<HrAttendance> HrAttendance { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("EmployeeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Employee")] // One2many
    public virtual ICollection<HrAttendanceOvertimeLine> HrAttendanceOvertimeLine { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("EmployeeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Employee")] // One2many
    public virtual ICollection<HrBankAccountAllocationWizard> HrBankAccountAllocationWizard { get; set; }

    // // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // // [One2many] [ForeignKey("EmployeeId")]
    // // [NotMapped] // One2many // Normal
    // // [InverseProperty("Employee")] // One2many
    // public virtual ICollection<HrResumeLine> HrResumeLine { get; set; }

    // // [One2many]
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // // [One2many] [ForeignKey("EmployeeId")]
    // // [NotMapped] // One2many // Normal
    // // [InverseProperty("Employee")] // One2many
    // public virtual ICollection<HrUserWorkEntryEmployee> HrUserWorkEntryEmployee { get; set; }

    // [One2many]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [One2many] [ForeignKey("EmployeeId")]
    // [NotMapped] // One2many // Normal
    // [InverseProperty("Employee")] // One2many
    public virtual ICollection<HrVersion> HrVersion { get; set; }

    // // [Many2many] // Normal
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // // [NotMapped] // Many2many // Normal
    // // [ForeignKey("EmployeeId")] // Many2many // Normal
    // // [InverseProperty("Employee")] // Many2many // Normal
    // public virtual ICollection<ResPartnerBank> BankAccount { get; set; }

    // // [Many2many] // Hidden
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] //Many2many // Hidden
    // // [ForeignKey("HrEmployeeId")] //Many2many // Hidden
    // // [InverseProperty("HrEmployee")] //Many2many // Hidden
    // public virtual ICollection<HrDepartureWizard> HrDepartureWizard { get; set; }

    // // [Many2many] // Hidden
    // [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    // [NotMapped] //Many2many // Hidden
    // // [ForeignKey("HrEmployeeId")] //Many2many // Hidden
    // // [InverseProperty("HrEmployee")] //Many2many // Hidden
    // public virtual ICollection<PosConfig> PosConfig { get; set; }

    // [Many2many] // Hidden
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("HrEmployeeId")] //Many2many // Hidden
    // [InverseProperty("HrEmployee1")] //Many2many // Hidden
    public virtual ICollection<PosConfig> PosConfig1 { get; set; }


}