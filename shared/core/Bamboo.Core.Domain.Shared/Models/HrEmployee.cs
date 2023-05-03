using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Bamboo.Core.Models;

[Table("hr_employee")]
//[Index("Barcode", Name = "hr_employee_barcode_uniq", IsUnique = true)]
//[Index("TenantId", Name = "hr_employee_company_id_index")]
//[Index("ResourceCalendarId", Name = "hr_employee_resource_calendar_id_index")]
//[Index("ResourceId", Name = "hr_employee_resource_id_index")]
//[Index("UserId", "TenantId", Name = "hr_employee_user_uniq", IsUnique = true)]
public partial class HrEmployee: Entity<Guid>, IEntityDto<Guid>, IMultiTenant, IMayHaveCreator, IModificationAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("resource_id")]
    public Guid? ResourceId { get; set; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("resource_calendar_id")]
    public Guid? ResourceCalendarId { get; set; }

    [Column("message_main_attachment_id")]
    public Guid? MessageMainAttachmentId { get; set; }

    [Column("color")]
    public long? Color { get; set; }

    [Column("department_id")]
    public Guid? DepartmentId { get; set; }

    [Column("job_id")]
    public Guid? JobId { get; set; }

    [Column("address_id")]
    public Guid? AddressId { get; set; }

    [Column("work_contact_id")]
    public Guid? WorkContactId { get; set; }

    [Column("work_location_id")]
    public Guid? WorkLocationId { get; set; }

    [Column("user_id")]
    public Guid? UserId { get; set; }

    [Column("parent_id")]
    public Guid? ParentId { get; set; }

    [Column("coach_id")]
    public Guid? CoachId { get; set; }

    [Column("address_home_id")]
    public Guid? AddressHomeId { get; set; }

    [Column("country_id")]
    public long? CountryId { get; set; }

    [Column("children")]
    public long? Children { get; set; }

    [Column("country_of_birth")]
    public long? CountryOfBirth { get; set; }

    [Column("bank_account_id")]
    public Guid? BankAccountId { get; set; }

    [Column("km_home_work")]
    public long? KmHomeWork { get; set; }

    [Column("departure_reason_id")]
    public long? DepartureReasonId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get; set; }

    [Column("write_uid")]
    public Guid? LastModifierId { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("job_title")]
    public string? JobTitle { get; set; }

    [Column("work_phone")]
    public string? WorkPhone { get; set; }

    [Column("mobile_phone")]
    public string? MobilePhone { get; set; }

    [Column("work_email")]
    public string? WorkEmail { get; set; }

    [Column("employee_type")]
    public string? EmployeeType { get; set; }

    [Column("gender")]
    public string? Gender { get; set; }

    [Column("marital")]
    public string? Marital { get; set; }

    [Column("spouse_complete_name")]
    public string? SpouseCompleteName { get; set; }

    [Column("place_of_birth")]
    public string? PlaceOfBirth { get; set; }

    [Column("ssnid")]
    public string? Ssnid { get; set; }

    [Column("sinid")]
    public string? Sinid { get; set; }

    [Column("identification_id")]
    public string? IdentificationId { get; set; }

    [Column("passport_id")]
    public string? PassportId { get; set; }

    [Column("permit_no")]
    public string? PermitNo { get; set; }

    [Column("visa_no")]
    public string? VisaNo { get; set; }

    [Column("certificate")]
    public string? Certificate { get; set; }

    [Column("study_field")]
    public string? StudyField { get; set; }

    [Column("study_school")]
    public string? StudySchool { get; set; }

    [Column("emergency_contact")]
    public string? EmergencyContact { get; set; }

    [Column("emergency_phone")]
    public string? EmergencyPhone { get; set; }

    [Column("barcode")]
    public string? Barcode { get; set; }

    [Column("pin")]
    public string? Pin { get; set; }

    [Column("spouse_birthdate")]
    public DateTime? SpouseBirthdate { get; set; }

    [Column("birthday")]
    public DateTime? Birthday { get; set; }

    [Column("visa_expire")]
    public DateTime? VisaExpire { get; set; }

    [Column("work_permit_expiration_date")]
    public DateTime? WorkPermitExpirationDate { get; set; }

    [Column("departure_date")]
    public DateTime? DepartureDate { get; set; }

    [Column("additional_note")]
    public string? AdditionalNote { get; set; }

    [Column("notes")]
    public string? Notes { get; set; }

    [Column("departure_description")]
    public string? DepartureDescription { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("work_permit_scheduled_activity")]
    public bool? WorkPermitScheduledActivity { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime? CreationTime { get; set; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public DateTime? LastModificationTime { get; set; }

    [Column("contract_id")]
    public Guid? ContractId { get; set; }

    [Column("vehicle")]
    public string? Vehicle { get; set; }

    [Column("first_contract_date")]
    public DateTime? FirstContractDate { get; set; }

    [Column("contract_warning")]
    public bool? ContractWarning { get; set; }

    [Column("expense_manager_id")]
    public Guid? ExpenseManagerId { get; set; }

    [Column("last_attendance_id")]
    public Guid? LastAttendanceId { get; set; }

    [Column("last_check_in", TypeName = "timestamp without time zone")]
    public DateTime? LastCheckIn { get; set; }

    [Column("last_check_out", TypeName = "timestamp without time zone")]
    public DateTime? LastCheckOut { get; set; }

    [Column("leave_manager_id")]
    public Guid? LeaveManagerId { get; set; }

    [Column("mobility_card")]
    public string? MobilityCard { get; set; }

    [ForeignKey("AddressId")]
    //[InverseProperty("HrEmployeeAddresses")]
    [NotMapped]
    public virtual ResPartner? Address { get; set; }

    [ForeignKey("AddressHomeId")]
    //[InverseProperty("HrEmployeeAddressHomes")]
    [NotMapped]
    public virtual ResPartner? AddressHome { get; set; }

    [ForeignKey("BankAccountId")]
    //[InverseProperty("HrEmployees")]
    [NotMapped]
    public virtual ResPartnerBank? BankAccount { get; set; }

    [ForeignKey("CoachId")]
    //[InverseProperty("InverseCoach")]
    [NotMapped]
    public virtual HrEmployee? Coach { get; set; }

    [ForeignKey("TenantId")]
    //[InverseProperty("HrEmployees")]
    [NotMapped]
    public virtual ResCompany? Company { get; set; }

    [ForeignKey("ContractId")]
    //[InverseProperty("HrEmployees")]
    [NotMapped]
    public virtual HrContract? Contract { get; set; }

    [ForeignKey("CountryId")]
    //[InverseProperty("HrEmployeeCountries")]
    [NotMapped]
    public virtual ResCountry? Country { get; set; }

    [ForeignKey("CountryOfBirth")]
    //[InverseProperty("HrEmployeeCountryOfBirthNavigations")]
    [NotMapped]
    public virtual ResCountry? CountryOfBirthNavigation { get; set; }

    [ForeignKey("CreatorId")]
    //[InverseProperty("HrEmployeeCreateUs")]
    [NotMapped]
    public virtual ResUser? CreateU { get; set; }

    [ForeignKey("DepartmentId")]
    //[InverseProperty("HrEmployees")]
    [NotMapped]
    public virtual HrDepartment? Department { get; set; }

    [ForeignKey("DepartureReasonId")]
    //[InverseProperty("HrEmployees")]
    [NotMapped]
    public virtual HrDepartureReason? DepartureReason { get; set; }

    [ForeignKey("ExpenseManagerId")]
    //[InverseProperty("HrEmployeeExpenseManagers")]
    [NotMapped]
    public virtual ResUser? ExpenseManager { get; set; }

    [ForeignKey("JobId")]
    //[InverseProperty("HrEmployees")]
    [NotMapped]
    public virtual HrJob? Job { get; set; }

    [ForeignKey("LastAttendanceId")]
    //[InverseProperty("HrEmployees")]
    [NotMapped]
    public virtual HrAttendance? LastAttendance { get; set; }

    [ForeignKey("LeaveManagerId")]
    //[InverseProperty("HrEmployeeLeaveManagers")]
    [NotMapped]
    public virtual ResUser? LeaveManager { get; set; }

    [ForeignKey("MessageMainAttachmentId")]
    //[InverseProperty("HrEmployees")]
    [NotMapped]
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    [ForeignKey("ParentId")]
    //[InverseProperty("InverseParent")]
    [NotMapped]
    public virtual HrEmployee? Parent { get; set; }

    [ForeignKey("ResourceId")]
    //[InverseProperty("HrEmployees")]
    [NotMapped]
    public virtual ResourceResource? Resource { get; set; }

    [ForeignKey("ResourceCalendarId")]
    //[InverseProperty("HrEmployees")]
    [NotMapped]
    public virtual ResourceCalendar? ResourceCalendar { get; set; }

    [ForeignKey("UserId")]
    //[InverseProperty("HrEmployeeUsers")]
    [NotMapped]
    public virtual ResUser? User { get; set; }

    [ForeignKey("WorkContactId")]
    //[InverseProperty("HrEmployeeWorkContacts")]
    [NotMapped]
    public virtual ResPartner? WorkContact { get; set; }

    [ForeignKey("WorkLocationId")]
    //[InverseProperty("HrEmployees")]
    [NotMapped]
    public virtual HrWorkLocation? WorkLocation { get; set; }

    [ForeignKey("LastModifierId")]
    //[InverseProperty("HrEmployeeWriteUs")]
    [NotMapped]
    public virtual ResUser? WriteU { get; set; }

    //[InverseProperty("DriverEmployee")]
    [NotMapped]
    public virtual ICollection<FleetVehicleAssignationLog> FleetVehicleAssignationLogs { get; } = new List<FleetVehicleAssignationLog>();

    //[InverseProperty("DriverEmployee")]
    [NotMapped]
    public virtual ICollection<FleetVehicle> FleetVehicleDriverEmployees { get; } = new List<FleetVehicle>();

    //[InverseProperty("FutureDriverEmployee")]
    [NotMapped]
    public virtual ICollection<FleetVehicle> FleetVehicleFutureDriverEmployees { get; } = new List<FleetVehicle>();

    //[InverseProperty("PurchaserEmployee")]
    [NotMapped]
    public virtual ICollection<FleetVehicleLogService> FleetVehicleLogServices { get; } = new List<FleetVehicleLogService>();

    //[InverseProperty("Emp")]
    [NotMapped]
    public virtual ICollection<HrApplicant> HrApplicants { get; } = new List<HrApplicant>();

    //[InverseProperty("Employee")]
    [NotMapped]
    public virtual ICollection<HrAttendanceOvertime> HrAttendanceOvertimes { get; } = new List<HrAttendanceOvertime>();

    //[InverseProperty("Employee")]
    [NotMapped]
    public virtual ICollection<HrAttendance> HrAttendances { get; } = new List<HrAttendance>();

    //[InverseProperty("Employee")]
    [NotMapped]
    public virtual ICollection<HrContract> HrContracts { get; } = new List<HrContract>();

    //[InverseProperty("Manager")]
    [NotMapped]
    public virtual ICollection<HrDepartment> HrDepartments { get; } = new List<HrDepartment>();

    //[InverseProperty("Employee")]
    [NotMapped]
    public virtual ICollection<HrDepartureWizard> HrDepartureWizards { get; } = new List<HrDepartureWizard>();

    //[InverseProperty("Employee")]
    [NotMapped]
    public virtual ICollection<HrEmployeeSkillLog> HrEmployeeSkillLogs { get; } = new List<HrEmployeeSkillLog>();

    //[InverseProperty("Employee")]
    [NotMapped]
    public virtual ICollection<HrEmployeeSkill> HrEmployeeSkills { get; } = new List<HrEmployeeSkill>();

    //[InverseProperty("Employee")]
    [NotMapped]
    public virtual ICollection<HrExpenseSheet> HrExpenseSheets { get; } = new List<HrExpenseSheet>();

    //[InverseProperty("Employee")]
    [NotMapped]
    public virtual ICollection<HrExpenseSplit> HrExpenseSplits { get; } = new List<HrExpenseSplit>();

    //[InverseProperty("Employee")]
    [NotMapped]
    public virtual ICollection<HrExpense> HrExpenses { get; } = new List<HrExpense>();

    //[InverseProperty("Manager")]
    [NotMapped]
    public virtual ICollection<HrJob> HrJobs { get; } = new List<HrJob>();

    //[InverseProperty("Approver")]
    [NotMapped]
    public virtual ICollection<HrLeaveAllocation> HrLeaveAllocationApprovers { get; } = new List<HrLeaveAllocation>();

    //[InverseProperty("Employee")]
    [NotMapped]
    public virtual ICollection<HrLeaveAllocation> HrLeaveAllocationEmployees { get; } = new List<HrLeaveAllocation>();

    //[InverseProperty("Manager")]
    [NotMapped]
    public virtual ICollection<HrLeaveAllocation> HrLeaveAllocationManagers { get; } = new List<HrLeaveAllocation>();

    //[InverseProperty("Employee")]
    [NotMapped]
    public virtual ICollection<HrLeave> HrLeaveEmployees { get; } = new List<HrLeave>();

    //[InverseProperty("FirstApprover")]
    [NotMapped]
    public virtual ICollection<HrLeave> HrLeaveFirstApprovers { get; } = new List<HrLeave>();

    //[InverseProperty("Manager")]
    [NotMapped]
    public virtual ICollection<HrLeave> HrLeaveManagers { get; } = new List<HrLeave>();

    //[InverseProperty("SecondApprover")]
    [NotMapped]
    public virtual ICollection<HrLeave> HrLeaveSecondApprovers { get; } = new List<HrLeave>();

    //[InverseProperty("Employee")]
    [NotMapped]
    public virtual ICollection<HrResumeLine> HrResumeLines { get; } = new List<HrResumeLine>();

    //[InverseProperty("Coach")]
    [NotMapped]
    public virtual ICollection<HrEmployee> InverseCoach { get; } = new List<HrEmployee>();

    //[InverseProperty("Parent")]
    [NotMapped]
    public virtual ICollection<HrEmployee> InverseParent { get; } = new List<HrEmployee>();

    //[InverseProperty("Employee")]
    [NotMapped]
    public virtual ICollection<MaintenanceEquipment> MaintenanceEquipments { get; } = new List<MaintenanceEquipment>();

    //[InverseProperty("Employee")]
    [NotMapped]
    public virtual ICollection<MaintenanceRequest> MaintenanceRequests { get; } = new List<MaintenanceRequest>();

    //[InverseProperty("Employee")]
    [NotMapped]
    public virtual ICollection<PosOrder> PosOrders { get; } = new List<PosOrder>();

    [ForeignKey("EmpId")]
    //[InverseProperty("Emps")]
    [NotMapped]
    public virtual ICollection<HrEmployeeCategory> Categories { get; } = new List<HrEmployeeCategory>();

    [ForeignKey("PlanWizardId")]
    //[InverseProperty("PlanWizards")]
    [NotMapped]
    public virtual ICollection<HrPlanWizard> Employees { get; } = new List<HrPlanWizard>();

    [ForeignKey("HrEmployeeId")]
    //[InverseProperty("HrEmployees")]
    [NotMapped]
    public virtual ICollection<HrLeaveAllocation> HrLeaveAllocations { get; } = new List<HrLeaveAllocation>();

    [ForeignKey("HrEmployeeId")]
    //[InverseProperty("HrEmployees")]
    [NotMapped]
    public virtual ICollection<HrLeave> HrLeaves { get; } = new List<HrLeave>();

    [ForeignKey("HrEmployeeId")]
    //[InverseProperty("HrEmployees")]
    [NotMapped]
    public virtual ICollection<HrSkill> HrSkills { get; } = new List<HrSkill>();

    [ForeignKey("HrEmployeeId")]
    //[InverseProperty("HrEmployees")]
    [NotMapped]
    public virtual ICollection<PosConfig> PosConfigs { get; } = new List<PosConfig>();

    [ForeignKey("EmpId")]
    //[InverseProperty("Emps")]
    [NotMapped]
    public virtual ICollection<HrHolidaysSummaryEmployee> Sums { get; } = new List<HrHolidaysSummaryEmployee>();
}
