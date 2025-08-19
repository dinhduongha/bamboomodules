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
//[Index("CompanyId", Name = "hr_employee__company_id_index")]
//[Index("ResourceCalendarId", Name = "hr_employee__resource_calendar_id_index")]
//[Index("ResourceId", Name = "hr_employee__resource_id_index")]
//[Index("Barcode", Name = "hr_employee_barcode_uniq", IsUnique = true)]
//[Index("UserId", "CompanyId", Name = "hr_employee_user_uniq", IsUnique = true)]
public partial class HrEmployee: FullAuditedAggregateRoot<Guid>, IEntityDto<Guid>, IMultiTenant, IAuditedObject
{
    [Key]
    [Column("id")]
    public Guid Id { get => base.Id; set => base.Id = value; }

    [Column("company_id")]
    public Guid? TenantId { get; set; }

    [Column("organization_unit_id")]
    public Guid? OrganizationUnitId  { get; set; }
    

    [Column("resource_id")]
    public Guid? ResourceId { get; set; }

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

    [Column("private_state_id")]
    public Guid? PrivateStateId { get; set; }

    [Column("private_country_id")]
    public Guid? PrivateCountryId { get; set; }

    [Column("country_id")]
    public Guid? CountryId { get; set; }

    [Column("children")]
    public long? Children { get; set; }

    [Column("country_of_birth")]
    public Guid? CountryOfBirth { get; set; }

    [Column("bank_account_id")]
    public Guid? BankAccountId { get; set; }

    [Column("distance_home_work")]
    public long? DistanceHomeWork { get; set; }

    [Column("km_home_work")]
    public long? KmHomeWork { get; set; }

    [Column("departure_reason_id")]
    public Guid? DepartureReasonId { get; set; }

    [Column("create_uid")]
    public Guid? CreatorId { get => base.CreatorId; set => base.CreatorId = value; }

    [Column("write_uid")]
    public override Guid? LastModifierId { get; set; }

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

    [Column("private_street")]
    public string? PrivateStreet { get; set; }

    [Column("private_street2")]
    public string? PrivateStreet2 { get; set; }

    [Column("private_city")]
    public string? PrivateCity { get; set; }

    [Column("private_zip")]
    public string? PrivateZip { get; set; }

    [Column("private_phone")]
    public string? PrivatePhone { get; set; }

    [Column("private_email")]
    public string? PrivateEmail { get; set; }

    [Column("lang")]
    public string? Lang { get; set; }

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

    [Column("distance_home_work_unit")]
    public string? DistanceHomeWorkUnit { get; set; }

    // [Column("employee_type")]
    // public string? EmployeeType { get; set; }

    [Column("barcode")]
    public string? Barcode { get; set; }

    [Column("pin")]
    public string? Pin { get; set; }

    [Column("private_car_plate")]
    public string? PrivateCarPlate { get; set; }

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

    [JsonField]
    [Column("employee_properties", TypeName = "jsonb")]
    public string? EmployeeProperties { get; set; }

    [Column("additional_note")]
    public string? AdditionalNote { get; set; }

    [Column("notes")]
    public string? Notes { get; set; }

    [Column("departure_description")]
    public string? DepartureDescription { get; set; }

    [Column("active")]
    public bool? Active { get; set; }

    [Column("is_flexible")]
    public bool? IsFlexible { get; set; }

    [Column("is_fully_flexible")]
    public bool? IsFullyFlexible { get; set; }

    [Column("work_permit_scheduled_activity")]
    public bool? WorkPermitScheduledActivity { get; set; }

    [Column("create_date", TypeName = "timestamp without time zone")]
    public DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }

    [Column("write_date", TypeName = "timestamp without time zone")]
    public override DateTime? LastModificationTime { get; set; }

    [Column("contract_id")]
    public Guid? ContractId { get; set; }

    [Column("legal_name")]
    public string? LegalName { get; set; }

    [Column("vehicle")]
    public string? Vehicle { get; set; }

    [Column("first_contract_date")]
    public DateTime? FirstContractDate { get; set; }

    [Column("contract_warning")]
    public bool? ContractWarning { get; set; }

    [Column("attendance_manager_id")]
    public Guid? AttendanceManagerId { get; set; }

    [Column("last_attendance_id")]
    public Guid? LastAttendanceId { get; set; }

    [Column("last_check_in", TypeName = "timestamp without time zone")]
    public DateTime? LastCheckIn { get; set; }

    [Column("last_check_out", TypeName = "timestamp without time zone")]
    public DateTime? LastCheckOut { get; set; }

    [Column("expense_manager_id")]
    public Guid? ExpenseManagerId { get; set; }

    [Column("leave_manager_id")]
    public Guid? LeaveManagerId { get; set; }

    [Column("mobility_card")]
    public string? MobilityCard { get; set; }

    [Column("monday_location_id")]
    public Guid? MondayLocationId { get; set; }

    [Column("tuesday_location_id")]
    public Guid? TuesdayLocationId { get; set; }

    [Column("wednesday_location_id")]
    public Guid? WednesdayLocationId { get; set; }

    [Column("thursday_location_id")]
    public Guid? ThursdayLocationId { get; set; }

    [Column("friday_location_id")]
    public Guid? FridayLocationId { get; set; }

    [Column("saturday_location_id")]
    public Guid? SaturdayLocationId { get; set; }

    [Column("sunday_location_id")]
    public Guid? SundayLocationId { get; set; }

    [Column("today_location_name")]
    public string? TodayLocationName { get; set; }

    [Column("hourly_cost")]
    public decimal? HourlyCost { get; set; }

    [Column("hr_presence_state_display")]
    public string? HrPresenceStateDisplay { get; set; }

    [Column("email_sent")]
    public bool? EmailSent { get; set; }

    [Column("ip_connected")]
    public bool? IpConnected { get; set; }

    [Column("manually_set_present")]
    public bool? ManuallySetPresent { get; set; }

    [Column("manually_set_presence")]
    public bool? ManuallySetPresence { get; set; }

    // [Column("hourly_cost")]
    // public decimal? HourlyCost { get; set; }

    // [One2many]
    [ForeignKey("EmployeeId")]
    [InverseProperty("Employee")]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLineEmployee { get; set; }

    // [One2many]
    [ForeignKey("ManagerId")]
    [InverseProperty("Manager")]
    public virtual ICollection<AccountAnalyticLine> AccountAnalyticLineManager { get; set; }

    // [One2many]
    [ForeignKey("EmployeeId")]
    [InverseProperty("Employee")]
    public virtual ICollection<AccountBankStatementLine> AccountBankStatementLine { get; set; }

    // [Many2one]
    [ForeignKey("AddressId")]
    // [InverseProperty("HrEmployeeAddress")] //Many2one
    public virtual ResPartner? Address { get; set; }

    // [Many2one]
    [ForeignKey("AddressHomeId")]
    // [InverseProperty("HrEmployeeAddressHome")] //Many2one
    public virtual ResPartner? AddressHome { get; set; }

    // [Many2one]
    [ForeignKey("AttendanceManagerId")]
    // [InverseProperty("HrEmployeeAttendanceManager")] //Many2one
    public virtual ResUsers? AttendanceManager { get; set; }

    // [Many2one]
    [ForeignKey("BankAccountId")]
    // [InverseProperty("HrEmployee")] //Many2one
    public virtual ResPartnerBank? BankAccount { get; set; }

    // [Many2one]
    [ForeignKey("CoachId")]
    // [InverseProperty("InverseCoach")] //Many2one
    public virtual HrEmployee? Coach { get; set; }

    // [Many2one]
    [ForeignKey("TenantId")]
    // [InverseProperty("HrEmployee")] //Many2one
    public virtual ResCompany? Company { get; set; }

    // [Many2one]
    [ForeignKey("ContractId")]
    // [InverseProperty("HrEmployee")] //Many2one
    public virtual HrContract? Contract { get; set; }

    // [Many2one]
    [ForeignKey("CountryId")]
    // [InverseProperty("HrEmployeeCountry")] //Many2one
    public virtual ResCountry? Country { get; set; }

    // [Many2one]
    [ForeignKey("CountryOfBirth")]
    // [InverseProperty("HrEmployeeCountryOfBirthNavigation")] //Many2one
    public virtual ResCountry? CountryOfBirthNavigation { get; set; }

    // [Many2one]
    [ForeignKey("CreatorId")]
    // [InverseProperty("HrEmployeeCreateU")] //Many2one
    public virtual ResUsers? CreateU { get; set; }

    // [Many2one]
    [ForeignKey("DepartmentId")]
    // [InverseProperty("HrEmployee")] //Many2one
    public virtual HrDepartment? Department { get; set; }

    // [Many2one]
    [ForeignKey("DepartureReasonId")]
    // [InverseProperty("HrEmployee")] //Many2one
    public virtual HrDepartureReason? DepartureReason { get; set; }

    // [Many2one]
    [ForeignKey("ExpenseManagerId")]
    // [InverseProperty("HrEmployeeExpenseManager")] //Many2one
    public virtual ResUsers? ExpenseManager { get; set; }

    // [One2many]
    [ForeignKey("DriverEmployeeId")]
    [InverseProperty("DriverEmployee")]
    public virtual ICollection<FleetVehicleAssignationLog> FleetVehicleAssignationLog { get; set; }

    // [One2many]
    [ForeignKey("DriverEmployeeId")]
    [InverseProperty("DriverEmployee")]
    public virtual ICollection<FleetVehicle> FleetVehicleDriverEmployee { get; set; }

    // [One2many]
    [ForeignKey("FutureDriverEmployeeId")]
    [InverseProperty("FutureDriverEmployee")]
    public virtual ICollection<FleetVehicle> FleetVehicleFutureDriverEmployee { get; set; }

    // [One2many]
    [ForeignKey("PurchaserEmployeeId")]
    [InverseProperty("PurchaserEmployee")]
    public virtual ICollection<FleetVehicleLogServices> FleetVehicleLogServices { get; set; }

    // [Many2one]
    [ForeignKey("FridayLocationId")]
    // [InverseProperty("HrEmployeeFridayLocation")] //Many2one
    public virtual HrWorkLocation? FridayLocation { get; set; }

    // [One2many]
    [ForeignKey("EmployeeId")]
    [InverseProperty("Employee")]
    public virtual ICollection<GamificationBadgeUser> GamificationBadgeUser { get; set; }

    // [One2many]
    [ForeignKey("EmployeeId")]
    [InverseProperty("Employee")]
    public virtual ICollection<GamificationBadgeUserWizard> GamificationBadgeUserWizard { get; set; }

    // [One2many]
    [ForeignKey("EmployeeId")]
    [InverseProperty("Employee")]
    public virtual ICollection<HomeworkLocationWizard> HomeworkLocationWizard { get; set; }

    // [One2many]
    [ForeignKey("EmpId")]
    [InverseProperty("Emp")]
    public virtual ICollection<HrApplicant> HrApplicant { get; set; }

    // [One2many]
    [ForeignKey("EmployeeId")]
    [InverseProperty("Employee")]
    public virtual ICollection<HrAttendance> HrAttendance { get; set; }

    // [One2many]
    [ForeignKey("EmployeeId")]
    [InverseProperty("Employee")]
    public virtual ICollection<HrAttendanceOvertime> HrAttendanceOvertime { get; set; }

    // [One2many]
    [ForeignKey("EmployeeId")]
    [InverseProperty("Employee")]
    public virtual ICollection<HrCandidate> HrCandidate { get; set; }

    // [One2many]
    [ForeignKey("EmployeeId")]
    [InverseProperty("Employee")]
    public virtual ICollection<HrContract> HrContract { get; set; }

    // [One2many]
    [ForeignKey("ManagerId")]
    [InverseProperty("Manager")]
    public virtual ICollection<HrDepartment> HrDepartment { get; set; }

    // [One2many]
    [ForeignKey("EmployeeId")]
    [InverseProperty("Employee")]
    public virtual ICollection<HrDepartureWizard> HrDepartureWizard { get; set; }

    // [One2many]
    [ForeignKey("EmployeeId")]
    [InverseProperty("Employee")]
    public virtual ICollection<HrEmployeeLocation> HrEmployeeLocation { get; set; }

    // [One2many]
    [ForeignKey("EmployeeId")]
    [InverseProperty("Employee")]
    public virtual ICollection<HrEmployeeSkill> HrEmployeeSkill { get; set; }

    // [One2many]
    [ForeignKey("EmployeeId")]
    [InverseProperty("Employee")]
    public virtual ICollection<HrEmployeeSkillLog> HrEmployeeSkillLog { get; set; }

    // [One2many]
    [ForeignKey("EmployeeId")]
    [InverseProperty("Employee")]
    public virtual ICollection<HrExpense> HrExpense { get; set; }

    // [One2many]
    [ForeignKey("EmployeeId")]
    [InverseProperty("Employee")]
    public virtual ICollection<HrExpenseSheet> HrExpenseSheet { get; set; }

    // [One2many]
    [ForeignKey("EmployeeId")]
    [InverseProperty("Employee")]
    public virtual ICollection<HrExpenseSplit> HrExpenseSplit { get; set; }

    // [One2many]
    [ForeignKey("ManagerId")]
    [InverseProperty("Manager")]
    public virtual ICollection<HrJob> HrJob { get; set; }

    // [One2many]
    [ForeignKey("ApproverId")]
    [InverseProperty("Approver")]
    public virtual ICollection<HrLeaveAllocation> HrLeaveAllocationApprover { get; set; }

    // [One2many]
    [ForeignKey("EmployeeId")]
    [InverseProperty("Employee")]
    public virtual ICollection<HrLeaveAllocation> HrLeaveAllocationEmployee { get; set; }

    // [One2many]
    [ForeignKey("ManagerId")]
    [InverseProperty("Manager")]
    public virtual ICollection<HrLeaveAllocation> HrLeaveAllocationManager { get; set; }

    // [One2many]
    [ForeignKey("SecondApproverId")]
    [InverseProperty("SecondApprover")]
    public virtual ICollection<HrLeaveAllocation> HrLeaveAllocationSecondApprover { get; set; }

    // [One2many]
    [ForeignKey("EmployeeId")]
    [InverseProperty("Employee")]
    public virtual ICollection<HrLeave> HrLeaveEmployee { get; set; }

    // [One2many]
    [ForeignKey("FirstApproverId")]
    [InverseProperty("FirstApprover")]
    public virtual ICollection<HrLeave> HrLeaveFirstApprover { get; set; }

    // [One2many]
    [ForeignKey("ManagerId")]
    [InverseProperty("Manager")]
    public virtual ICollection<HrLeave> HrLeaveManager { get; set; }

    // [One2many]
    [ForeignKey("SecondApproverId")]
    [InverseProperty("SecondApprover")]
    public virtual ICollection<HrLeave> HrLeaveSecondApprover { get; set; }

    // [One2many]
    [ForeignKey("EmployeeId")]
    [InverseProperty("Employee")]
    public virtual ICollection<HrPayslip> HrPayslip { get; set; }

    // [One2many]
    [ForeignKey("EmployeeId")]
    [InverseProperty("Employee")]
    public virtual ICollection<HrPayslipLine> HrPayslipLine { get; set; }

    // [One2many]
    [ForeignKey("EmployeeId")]
    [InverseProperty("Employee")]
    public virtual ICollection<HrResumeLine> HrResumeLine { get; set; }

    // [One2many]
    [ForeignKey("EmployeeId")]
    [InverseProperty("Employee")]
    public virtual ICollection<HrUserWorkEntryEmployee> HrUserWorkEntryEmployee { get; set; }

    // [One2many]
    [ForeignKey("EmployeeId")]
    [InverseProperty("Employee")]
    public virtual ICollection<HrWorkEntry> HrWorkEntry { get; set; }

    // [One2many]
    [ForeignKey("CoachId")]
    [InverseProperty("Coach")]
    public virtual ICollection<HrEmployee> InverseCoach { get; set; }

    // [One2many]
    [ForeignKey("ParentId")]
    [InverseProperty("Parent")]
    public virtual ICollection<HrEmployee> InverseParent { get; set; }

    // [Many2one]
    [ForeignKey("JobId")]
    // [InverseProperty("HrEmployee")] //Many2one
    public virtual HrJob? Job { get; set; }

    // [Many2one]
    [ForeignKey("LastAttendanceId")]
    // [InverseProperty("HrEmployee")] //Many2one
    public virtual HrAttendance? LastAttendance { get; set; }

    // [Many2one]
    [ForeignKey("LeaveManagerId")]
    // [InverseProperty("HrEmployeeLeaveManager")] //Many2one
    public virtual ResUsers? LeaveManager { get; set; }

    // [One2many]
    [ForeignKey("EmployeeId")]
    [InverseProperty("Employee")]
    public virtual ICollection<MaintenanceEquipment> MaintenanceEquipment { get; set; }

    // [One2many]
    [ForeignKey("EmployeeId")]
    [InverseProperty("Employee")]
    public virtual ICollection<MaintenanceRequest> MaintenanceRequest { get; set; }

    // [Many2one]
    [ForeignKey("MessageMainAttachmentId")]
    // [InverseProperty("HrEmployee")] //Many2one
    public virtual IrAttachment? MessageMainAttachment { get; set; }

    // [Many2one]
    [ForeignKey("MondayLocationId")]
    // [InverseProperty("HrEmployeeMondayLocation")] //Many2one
    public virtual HrWorkLocation? MondayLocation { get; set; }

    // [Many2one]
    [ForeignKey("ParentId")]
    // [InverseProperty("InverseParent")] //Many2one
    public virtual HrEmployee? Parent { get; set; }

    // [One2many]
    [ForeignKey("EmployeeId")]
    [InverseProperty("Employee")]
    public virtual ICollection<PosOrder> PosOrder { get; set; }

    // [One2many]
    [ForeignKey("EmployeeId")]
    [InverseProperty("Employee")]
    public virtual ICollection<PosPayment> PosPayment { get; set; }

    // [One2many]
    [ForeignKey("EmployeeId")]
    [InverseProperty("Employee")]
    public virtual ICollection<PosSession> PosSession { get; set; }

    // [Many2one]
    [ForeignKey("PrivateCountryId")]
    // [InverseProperty("HrEmployeePrivateCountry")] //Many2one
    public virtual ResCountry? PrivateCountry { get; set; }

    // [Many2one]
    [ForeignKey("PrivateStateId")]
    // [InverseProperty("HrEmployee")] //Many2one
    public virtual ResCountryState? PrivateState { get; set; }

    // [One2many]
    [ForeignKey("EmployeeId")]
    [InverseProperty("Employee")]
    public virtual ICollection<ProjectCreateSaleOrderLine> ProjectCreateSaleOrderLine { get; set; }

    // [One2many]
    [ForeignKey("EmployeeId")]
    [InverseProperty("Employee")]
    public virtual ICollection<ProjectSaleLineEmployeeMap> ProjectSaleLineEmployeeMap { get; set; }

    // [Many2one]
    [ForeignKey("ResourceId")]
    // [InverseProperty("HrEmployee")] //Many2one
    public virtual ResourceResource? Resource { get; set; }

    // [Many2one]
    [ForeignKey("ResourceCalendarId")]
    // [InverseProperty("HrEmployee")] //Many2one
    public virtual ResourceCalendar? ResourceCalendar { get; set; }

    // [Many2one]
    [ForeignKey("SaturdayLocationId")]
    // [InverseProperty("HrEmployeeSaturdayLocation")] //Many2one
    public virtual HrWorkLocation? SaturdayLocation { get; set; }

    // [Many2one]
    [ForeignKey("SundayLocationId")]
    // [InverseProperty("HrEmployeeSundayLocation")] //Many2one
    public virtual HrWorkLocation? SundayLocation { get; set; }

    // [Many2one]
    [ForeignKey("ThursdayLocationId")]
    // [InverseProperty("HrEmployeeThursdayLocation")] //Many2one
    public virtual HrWorkLocation? ThursdayLocation { get; set; }

    // [Many2one]
    [ForeignKey("TuesdayLocationId")]
    // [InverseProperty("HrEmployeeTuesdayLocation")] //Many2one
    public virtual HrWorkLocation? TuesdayLocation { get; set; }

    // [Many2one]
    [ForeignKey("UserId")]
    // [InverseProperty("HrEmployeeUser")] //Many2one
    public virtual ResUsers? User { get; set; }

    // [Many2one]
    [ForeignKey("WednesdayLocationId")]
    // [InverseProperty("HrEmployeeWednesdayLocation")] //Many2one
    public virtual HrWorkLocation? WednesdayLocation { get; set; }

    // [Many2one]
    [ForeignKey("WorkContactId")]
    // [InverseProperty("HrEmployeeWorkContact")] //Many2one
    public virtual ResPartner? WorkContact { get; set; }

    // [Many2one]
    [ForeignKey("WorkLocationId")]
    // [InverseProperty("HrEmployee")] //Many2one
    // [InverseProperty("HrEmployeeWorkLocation")] //Many2one
    public virtual HrWorkLocation? WorkLocation { get; set; }

    // [Many2one]
    [ForeignKey("LastModifierId")]
    // [InverseProperty("HrEmployeeWriteU")] //Many2one
    public virtual ResUsers? WriteU { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("EmpId")] //Many2many
    // [InverseProperty("Emp")] //Many2many
    public virtual ICollection<HrEmployeeCategory> Category { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("PlanWizardId")]
    // [InverseProperty("PlanWizard")]
    public virtual ICollection<HrPlanWizard> Employee { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("HrEmployeeId")]
    // [InverseProperty("HrEmployee")]
    public virtual ICollection<HrEmployeeCvWizard> HrEmployeeCvWizard { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("HrEmployeeId")]
    // [InverseProperty("HrEmployee")]
    public virtual ICollection<HrEmployeeDeleteWizard> HrEmployeeDeleteWizard { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("HrEmployeeId")]
    // [InverseProperty("HrEmployee")]
    public virtual ICollection<HrLeaveAllocationGenerateMultiWizard> HrLeaveAllocationGenerateMultiWizard { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("HrEmployeeId")]
    // [InverseProperty("HrEmployee")]
    public virtual ICollection<HrLeave> HrLeave { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("HrEmployeeId")]
    // [InverseProperty("HrEmployee")]
    public virtual ICollection<HrLeaveGenerateMultiWizard> HrLeaveGenerateMultiWizard { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("HrEmployeeId")]
    // [InverseProperty("HrEmployee")]
    public virtual ICollection<HrLeaveAllocation> HrLeaveAllocation { get; set; }

    // [Many2many] // Normal
    // [NotMapped] //Many2many // Normal
    // [ForeignKey("HrEmployeeId")] //Many2many
    // [InverseProperty("HrEmployee")] //Many2many
    public virtual ICollection<HrSkill> HrSkill { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("HrEmployeeId")]
    // [InverseProperty("HrEmployee")]
    public virtual ICollection<HrWorkEntryRegenerationWizard> HrWorkEntryRegenerationWizard { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("EmployeeId")]
    // [InverseProperty("Employee")]
    public virtual ICollection<HrPayslipEmployees> Payslip { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("HrEmployeeId")]
    // [InverseProperty("HrEmployee")]
    public virtual ICollection<PosConfig> PosConfig { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("HrEmployeeId")]
    // [InverseProperty("HrEmployeeNavigation")]
    public virtual ICollection<PosConfig> PosConfigNavigation { get; set; }

    // [Many2many] // ManyToMany Hidden
    [NotMapped] //Many2many // Hidden
    // [ForeignKey("EmpId")]
    // [InverseProperty("Emp")]
    public virtual ICollection<HrHolidaysSummaryEmployee> Sum { get; set; }
}
