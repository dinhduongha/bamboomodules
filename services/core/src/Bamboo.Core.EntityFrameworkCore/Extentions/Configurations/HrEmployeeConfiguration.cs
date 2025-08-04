using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
// TODO: Hãy chắc chắn rằng bạn đã thêm using cho namespace chứa Models của mình ở đây
// Ví dụ: using YourProject.Models;
using Bamboo.Core.Models;
namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureHrEmployee(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HrEmployee>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("hr_employee_pkey");

                entity.ToTable("hr_employee");

                entity.HasIndex(e => new { e.TenantId, e.Barcode }, "hr_employee_barcode_uniq").IsUnique();

                entity.HasIndex(e => e.TenantId, "hr_employee_company_id_index");

                entity.HasIndex(e => e.ResourceCalendarId, "hr_employee_resource_calendar_id_index");

                entity.HasIndex(e => e.ResourceId, "hr_employee_resource_id_index");

                entity.HasIndex(e => new { e.TenantId, e.UserId }, "hr_employee_user_uniq").IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.AdditionalNote).HasColumnName("additional_note");
                entity.Property(e => e.AddressHomeId).HasColumnName("address_home_id");
                entity.Property(e => e.AddressId).HasColumnName("address_id");
                entity.Property(e => e.BankAccountId).HasColumnName("bank_account_id");
                entity.Property(e => e.Barcode).HasColumnName("barcode");
                entity.Property(e => e.Birthday).HasColumnName("birthday");
                entity.Property(e => e.Certificate).HasColumnName("certificate");
                entity.Property(e => e.Children).HasColumnName("children");
                entity.Property(e => e.CoachId).HasColumnName("coach_id");
                entity.Property(e => e.Color).HasColumnName("color");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.ContractId).HasColumnName("contract_id");
                entity.Property(e => e.ContractWarning).HasColumnName("contract_warning");
                entity.Property(e => e.CountryId).HasColumnName("country_id");
                entity.Property(e => e.CountryOfBirth).HasColumnName("country_of_birth");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.DepartmentId).HasColumnName("department_id");
                entity.Property(e => e.DepartureDate).HasColumnName("departure_date");
                entity.Property(e => e.DepartureDescription).HasColumnName("departure_description");
                entity.Property(e => e.DepartureReasonId).HasColumnName("departure_reason_id");
                entity.Property(e => e.EmergencyContact).HasColumnName("emergency_contact");
                entity.Property(e => e.EmergencyPhone).HasColumnName("emergency_phone");
                entity.Property(e => e.EmployeeType).HasColumnName("employee_type");
                entity.Property(e => e.ExpenseManagerId).HasColumnName("expense_manager_id");
                entity.Property(e => e.FirstContractDate).HasColumnName("first_contract_date");
                entity.Property(e => e.Gender).HasColumnName("gender");
                entity.Property(e => e.IdentificationId).HasColumnName("identification_id");
                entity.Property(e => e.JobId).HasColumnName("job_id");
                entity.Property(e => e.JobTitle).HasColumnName("job_title");
                entity.Property(e => e.KmHomeWork).HasColumnName("km_home_work");
                entity.Property(e => e.LastAttendanceId).HasColumnName("last_attendance_id");
                entity.Property(e => e.LastCheckIn)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("last_check_in");
                entity.Property(e => e.LastCheckOut)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("last_check_out");
                entity.Property(e => e.LeaveManagerId).HasColumnName("leave_manager_id");
                entity.Property(e => e.Marital).HasColumnName("marital");
                entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
                entity.Property(e => e.MobilePhone).HasColumnName("mobile_phone");
                entity.Property(e => e.MobilityCard).HasColumnName("mobility_card");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Notes).HasColumnName("notes");
                entity.Property(e => e.ParentId).HasColumnName("parent_id");
                entity.Property(e => e.PassportId).HasColumnName("passport_id");
                entity.Property(e => e.PermitNo).HasColumnName("permit_no");
                entity.Property(e => e.Pin).HasColumnName("pin");
                entity.Property(e => e.PlaceOfBirth).HasColumnName("place_of_birth");
                entity.Property(e => e.ResourceCalendarId).HasColumnName("resource_calendar_id");
                entity.Property(e => e.ResourceId).HasColumnName("resource_id");
                entity.Property(e => e.Sinid).HasColumnName("sinid");
                entity.Property(e => e.SpouseBirthdate).HasColumnName("spouse_birthdate");
                entity.Property(e => e.SpouseCompleteName).HasColumnName("spouse_complete_name");
                entity.Property(e => e.Ssnid).HasColumnName("ssnid");
                entity.Property(e => e.StudyField).HasColumnName("study_field");
                entity.Property(e => e.StudySchool).HasColumnName("study_school");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.Vehicle).HasColumnName("vehicle");
                entity.Property(e => e.VisaExpire).HasColumnName("visa_expire");
                entity.Property(e => e.VisaNo).HasColumnName("visa_no");
                entity.Property(e => e.WorkContactId).HasColumnName("work_contact_id");
                entity.Property(e => e.WorkEmail).HasColumnName("work_email");
                entity.Property(e => e.WorkLocationId).HasColumnName("work_location_id");
                entity.Property(e => e.WorkPermitExpirationDate).HasColumnName("work_permit_expiration_date");
                entity.Property(e => e.WorkPermitScheduledActivity).HasColumnName("work_permit_scheduled_activity");
                entity.Property(e => e.WorkPhone).HasColumnName("work_phone");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.AddressHome).WithMany(p => p.HrEmployeeAddressHomes)
                    .HasForeignKey(d => d.AddressHomeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_employee_address_home_id_fkey");

                entity.HasOne(d => d.Address).WithMany(p => p.HrEmployeeAddresses)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_employee_address_id_fkey");

                entity.HasOne(d => d.BankAccount).WithMany(p => p.HrEmployees)
                    .HasForeignKey(d => d.BankAccountId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_employee_bank_account_id_fkey");

                entity.HasOne(d => d.Coach).WithMany(p => p.InverseCoach)
                    .HasForeignKey(d => d.CoachId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_employee_coach_id_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_employee_company_id_fkey");

                entity.HasOne(d => d.Contract).WithMany(p => p.HrEmployees)
                    .HasForeignKey(d => d.ContractId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_employee_contract_id_fkey");

                entity.HasOne<ResCountry>().WithMany()
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_employee_country_id_fkey");

                entity.HasOne(d => d.CountryOfBirthNavigation).WithMany(p => p.HrEmployeeCountryOfBirthNavigations)
                    .HasForeignKey(d => d.CountryOfBirth)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_employee_country_of_birth_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_employee_create_uid_fkey");

                entity.HasOne(d => d.Department).WithMany(p => p.HrEmployees)
                    .HasForeignKey(d => d.DepartmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_employee_department_id_fkey");

                entity.HasOne(d => d.DepartureReason).WithMany(p => p.HrEmployees)
                    .HasForeignKey(d => d.DepartureReasonId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("hr_employee_departure_reason_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.ExpenseManagerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_employee_expense_manager_id_fkey");

                entity.HasOne(d => d.Job).WithMany(p => p.HrEmployees)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_employee_job_id_fkey");

                entity.HasOne(d => d.LastAttendance).WithMany(p => p.HrEmployees)
                    .HasForeignKey(d => d.LastAttendanceId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_employee_last_attendance_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LeaveManagerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_employee_leave_manager_id_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.HrEmployees)
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_employee_message_main_attachment_id_fkey");

                entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_employee_parent_id_fkey");

                entity.HasOne(d => d.ResourceCalendar).WithMany(p => p.HrEmployees)
                    .HasForeignKey(d => d.ResourceCalendarId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_employee_resource_calendar_id_fkey");

                entity.HasOne(d => d.Resource).WithMany(p => p.HrEmployees)
                    .HasForeignKey(d => d.ResourceId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("hr_employee_resource_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_employee_user_id_fkey");

                entity.HasOne(d => d.WorkContact).WithMany(p => p.HrEmployeeWorkContacts)
                    .HasForeignKey(d => d.WorkContactId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_employee_work_contact_id_fkey");

                entity.HasOne(d => d.WorkLocation).WithMany(p => p.HrEmployees)
                    .HasForeignKey(d => d.WorkLocationId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_employee_work_location_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_employee_write_uid_fkey");

                //entity.HasMany(d => d.Categories).WithMany(p => p.Emps)
                entity.HasMany<HrEmployeeCategory>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "EmployeeCategoryRel",
                        r => r.HasOne<HrEmployeeCategory>().WithMany()
                            .HasForeignKey("CategoryId")
                            .HasConstraintName("employee_category_rel_category_id_fkey"),
                        l => l.HasOne<HrEmployee>().WithMany()
                            .HasForeignKey("EmployeeId")
                            .HasConstraintName("employee_category_rel_emp_id_fkey"),
                        j =>
                        {
                            // v16-Compat data
                            //j.HasKey("EmpId", "CategoryId").HasName("employee_category_rel_pkey");
                            j.HasKey("EmployeeId", "CategoryId").HasName("employee_category_rel_pkey");
                            j.ToTable("employee_category_rel");
                            j.HasIndex(new[] { "CategoryId", "EmployeeId" }, "employee_category_rel_category_id_emp_id_idx");

                        });

                //entity.HasMany(d => d.HrSkills).WithMany(p => p.HrEmployees)
                entity.HasMany<HrSkill>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "HrEmployeeHrSkillRel",
                        r => r.HasOne<HrSkill>().WithMany()
                            .HasForeignKey("HrSkillId")
                            .HasConstraintName("hr_employee_hr_skill_rel_hr_skill_id_fkey"),
                        l => l.HasOne<HrEmployee>().WithMany()
                            .HasForeignKey("HrEmployeeId")
                            .HasConstraintName("hr_employee_hr_skill_rel_hr_employee_id_fkey"),
                        j =>
                        {
                            j.HasKey("HrEmployeeId", "HrSkillId").HasName("hr_employee_hr_skill_rel_pkey");
                            j.ToTable("hr_employee_hr_skill_rel");
                            j.HasIndex(new[] { "HrSkillId", "HrEmployeeId" }, "hr_employee_hr_skill_rel_hr_skill_id_hr_employee_id_idx");
                        });
            });
        }
    }
}