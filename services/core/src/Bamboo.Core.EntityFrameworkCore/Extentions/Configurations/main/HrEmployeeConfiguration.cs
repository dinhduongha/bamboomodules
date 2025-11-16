using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.HasIndex(e => e.TenantId, "hr_employee__company_id_index");

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.MessageMainAttachmentId, "hr_employee__message_main_attachment_id_index").HasFilter("(message_main_attachment_id IS NOT NULL)");

                        entity.HasIndex(e => e.ParentId, "hr_employee__parent_id_index");

                        entity.HasIndex(e => e.ResourceId, "hr_employee__resource_id_index");

                        entity.HasIndex(e => e.UserId, "hr_employee__user_id_index").HasFilter("(user_id IS NOT NULL)");

                        entity.HasIndex(e => e.WorkContactId, "hr_employee__work_contact_id_index").HasFilter("(work_contact_id IS NOT NULL)");

                        entity.HasIndex(e => e.Barcode, "hr_employee_barcode_uniq").IsUnique();

                        entity.HasIndex(e => new { e.UserId, e.TenantId }, "hr_employee_user_uniq").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.AttendanceManagerId).HasColumnName("attendance_manager_id");
                        entity.Property(e => e.Barcode).HasColumnName("barcode");
                        entity.Property(e => e.Birthday).HasColumnName("birthday");
                        entity.Property(e => e.BirthdayPublicDisplay).HasColumnName("birthday_public_display");
                        entity.Property(e => e.Certificate).HasColumnName("certificate");
                        entity.Property(e => e.CoachId).HasColumnName("coach_id");
                        entity.Property(e => e.Color).HasColumnName("color");

                        entity.Property(e => e.CountryOfBirth).HasColumnName("country_of_birth");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.CurrentVersionId).HasColumnName("current_version_id");
                        entity.Property(e => e.EmailSent).HasColumnName("email_sent");
                        entity.Property(e => e.EmergencyContact).HasColumnName("emergency_contact");
                        entity.Property(e => e.EmergencyPhone).HasColumnName("emergency_phone");
                        entity.Property(e => e.EmployeeProperties)
                            .HasColumnType("jsonb")
                            .HasColumnName("employee_properties");
                        entity.Property(e => e.ExpenseManagerId).HasColumnName("expense_manager_id");
                        entity.Property(e => e.FridayLocationId).HasColumnName("friday_location_id");
                        entity.Property(e => e.HourlyCost).HasColumnName("hourly_cost");
                        entity.Property(e => e.HrPresenceStateDisplay).HasColumnName("hr_presence_state_display");
                        entity.Property(e => e.IpConnected).HasColumnName("ip_connected");
                        entity.Property(e => e.Lang).HasColumnName("lang");
                        entity.Property(e => e.LastAttendanceId).HasColumnName("last_attendance_id");
                        entity.Property(e => e.LastCheckIn)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("last_check_in");
                        entity.Property(e => e.LastCheckOut)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("last_check_out");
                        entity.Property(e => e.LeaveManagerId).HasColumnName("leave_manager_id");
                        entity.Property(e => e.LegalName).HasColumnName("legal_name");
                        entity.Property(e => e.ManuallySetPresence).HasColumnName("manually_set_presence");
                        entity.Property(e => e.ManuallySetPresent).HasColumnName("manually_set_present");
                        entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
                        entity.Property(e => e.MobilePhone).HasColumnName("mobile_phone");
                        entity.Property(e => e.MobilityCard).HasColumnName("mobility_card");
                        entity.Property(e => e.MondayLocationId).HasColumnName("monday_location_id");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.ParentId).HasColumnName("parent_id");
                        entity.Property(e => e.PermitNo).HasColumnName("permit_no");
                        entity.Property(e => e.Pin).HasColumnName("pin");
                        entity.Property(e => e.PlaceOfBirth).HasColumnName("place_of_birth");
                        entity.Property(e => e.PrivateCarPlate).HasColumnName("private_car_plate");
                        entity.Property(e => e.PrivateEmail).HasColumnName("private_email");
                        entity.Property(e => e.PrivatePhone).HasColumnName("private_phone");
                        entity.Property(e => e.ResourceId).HasColumnName("resource_id");
                        entity.Property(e => e.SalaryDistribution)
                            .HasColumnType("jsonb")
                            .HasColumnName("salary_distribution");
                        entity.Property(e => e.SaturdayLocationId).HasColumnName("saturday_location_id");
                        entity.Property(e => e.StudyField).HasColumnName("study_field");
                        entity.Property(e => e.StudySchool).HasColumnName("study_school");
                        entity.Property(e => e.SundayLocationId).HasColumnName("sunday_location_id");
                        entity.Property(e => e.ThursdayLocationId).HasColumnName("thursday_location_id");
                        entity.Property(e => e.TodayLocationName).HasColumnName("today_location_name");
                        entity.Property(e => e.TuesdayLocationId).HasColumnName("tuesday_location_id");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.VisaExpire).HasColumnName("visa_expire");
                        entity.Property(e => e.VisaNo).HasColumnName("visa_no");
                        entity.Property(e => e.WednesdayLocationId).HasColumnName("wednesday_location_id");
                        entity.Property(e => e.WorkContactId).HasColumnName("work_contact_id");
                        entity.Property(e => e.WorkEmail).HasColumnName("work_email");
                        entity.Property(e => e.WorkPermitExpirationDate).HasColumnName("work_permit_expiration_date");
                        entity.Property(e => e.WorkPermitScheduledActivity).HasColumnName("work_permit_scheduled_activity");
                        entity.Property(e => e.WorkPhone).HasColumnName("work_phone");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.AttendanceManager).WithMany(p => p.HrEmployeeAttendanceManager) .HasForeignKey(d => d.AttendanceManagerId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_employee_attendance_manager_id_fkey");
                        entity.HasOne(d => d.AttendanceManager).WithMany()
                            .HasForeignKey(d => d.AttendanceManagerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_employee_attendance_manager_id_fkey");

                        entity.HasOne(d => d.Coach).WithMany(p => p.InverseCoach)
                            .HasForeignKey(d => d.CoachId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_employee_coach_id_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.HrEmployee) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_employee_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_employee_company_id_fkey");

                        // entity.HasOne(d => d.CountryOfBirthNavigation).WithMany(p => p.HrEmployee) .HasForeignKey(d => d.CountryOfBirth) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_employee_country_of_birth_fkey");
                        entity.HasOne(d => d.CountryOfBirthNavigation).WithMany()
                            .HasForeignKey(d => d.CountryOfBirth)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_employee_country_of_birth_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.HrEmployeeCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_employee_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_employee_create_uid_fkey");

                        entity.HasOne(d => d.CurrentVersion).WithMany(p => p.HrEmployee)
                            .HasForeignKey(d => d.CurrentVersionId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_employee_current_version_id_fkey");

                        // entity.HasOne(d => d.ExpenseManager).WithMany(p => p.HrEmployeeExpenseManager) .HasForeignKey(d => d.ExpenseManagerId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_employee_expense_manager_id_fkey");
                        entity.HasOne(d => d.ExpenseManager).WithMany()
                            .HasForeignKey(d => d.ExpenseManagerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_employee_expense_manager_id_fkey");

                        entity.HasOne(d => d.FridayLocation).WithMany(p => p.HrEmployeeFridayLocation)
                            .HasForeignKey(d => d.FridayLocationId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_employee_friday_location_id_fkey");

                        entity.HasOne(d => d.LastAttendance).WithMany(p => p.HrEmployee)
                            .HasForeignKey(d => d.LastAttendanceId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_employee_last_attendance_id_fkey");

                        // entity.HasOne(d => d.LeaveManager).WithMany(p => p.HrEmployeeLeaveManager) .HasForeignKey(d => d.LeaveManagerId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_employee_leave_manager_id_fkey");
                        entity.HasOne(d => d.LeaveManager).WithMany()
                            .HasForeignKey(d => d.LeaveManagerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_employee_leave_manager_id_fkey");

                        // entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.HrEmployee) .HasForeignKey(d => d.MessageMainAttachmentId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_employee_message_main_attachment_id_fkey");
                        entity.HasOne(d => d.MessageMainAttachment).WithMany()
                            .HasForeignKey(d => d.MessageMainAttachmentId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_employee_message_main_attachment_id_fkey");

                        entity.HasOne(d => d.MondayLocation).WithMany(p => p.HrEmployeeMondayLocation)
                            .HasForeignKey(d => d.MondayLocationId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_employee_monday_location_id_fkey");

                        entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                            .HasForeignKey(d => d.ParentId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_employee_parent_id_fkey");

                        entity.HasOne(d => d.Resource).WithMany(p => p.HrEmployee)
                            .HasForeignKey(d => d.ResourceId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("hr_employee_resource_id_fkey");

                        entity.HasOne(d => d.SaturdayLocation).WithMany(p => p.HrEmployeeSaturdayLocation)
                            .HasForeignKey(d => d.SaturdayLocationId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_employee_saturday_location_id_fkey");

                        entity.HasOne(d => d.SundayLocation).WithMany(p => p.HrEmployeeSundayLocation)
                            .HasForeignKey(d => d.SundayLocationId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_employee_sunday_location_id_fkey");

                        entity.HasOne(d => d.ThursdayLocation).WithMany(p => p.HrEmployeeThursdayLocation)
                            .HasForeignKey(d => d.ThursdayLocationId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_employee_thursday_location_id_fkey");

                        entity.HasOne(d => d.TuesdayLocation).WithMany(p => p.HrEmployeeTuesdayLocation)
                            .HasForeignKey(d => d.TuesdayLocationId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_employee_tuesday_location_id_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.HrEmployeeUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("hr_employee_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("hr_employee_user_id_fkey");

                        entity.HasOne(d => d.WednesdayLocation).WithMany(p => p.HrEmployeeWednesdayLocation)
                            .HasForeignKey(d => d.WednesdayLocationId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_employee_wednesday_location_id_fkey");

                        // entity.HasOne(d => d.WorkContact).WithMany(p => p.HrEmployee) .HasForeignKey(d => d.WorkContactId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_employee_work_contact_id_fkey");
                        entity.HasOne(d => d.WorkContact).WithMany()
                            .HasForeignKey(d => d.WorkContactId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_employee_work_contact_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.HrEmployeeWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_employee_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_employee_write_uid_fkey");

                        // entity.HasMany(d => d.BankAccount).WithMany(p => p.Employee)
                        entity.HasMany(d => d.BankAccount).WithMany(p => p.Employee)
                            .UsingEntity<Dictionary<string, object>>(
                                "EmployeeBankAccountRel",
                                r => r.HasOne<ResPartnerBank>().WithMany()
                                    .HasForeignKey("BankAccountId")
                                    .HasConstraintName("employee_bank_account_rel_bank_account_id_fkey"),
                                l => l.HasOne<HrEmployee>().WithMany()
                                    .HasForeignKey("EmployeeId")
                                    .HasConstraintName("employee_bank_account_rel_employee_id_fkey"),
                                j =>
                                {
                                    j.HasKey("EmployeeId", "BankAccountId").HasName("employee_bank_account_rel_pkey");
                                    j.ToTable("employee_bank_account_rel");
                                    j.HasIndex(new[] { "BankAccountId", "EmployeeId" }, "employee_bank_account_rel_bank_account_id_employee_id_idx");
                                    j.IndexerProperty<Guid>("EmployeeId").HasColumnName("employee_id");
                                    j.IndexerProperty<Guid>("BankAccountId").HasColumnName("bank_account_id");
                                });

                        // entity.HasMany(d => d.Category).WithMany(p => p.Employee)
                        entity.HasMany(d => d.Category).WithMany(p => p.Employee)
                            .UsingEntity<Dictionary<string, object>>(
                                "EmployeeCategoryRel",
                                r => r.HasOne<HrEmployeeCategory>().WithMany()
                                    .HasForeignKey("CategoryId")
                                    .HasConstraintName("employee_category_rel_category_id_fkey"),
                                l => l.HasOne<HrEmployee>().WithMany()
                                    .HasForeignKey("EmployeeId")
                                    .HasConstraintName("employee_category_rel_employee_id_fkey"),
                                j =>
                                {
                                    j.HasKey("EmployeeId", "CategoryId").HasName("employee_category_rel_pkey");
                                    j.ToTable("employee_category_rel");
                                    j.HasIndex(new[] { "CategoryId", "EmployeeId" }, "employee_category_rel_category_id_employee_id_idx");
                                    j.IndexerProperty<Guid>("EmployeeId").HasColumnName("employee_id");
                                    j.IndexerProperty<Guid>("CategoryId").HasColumnName("category_id");
                                });

                        // entity.HasMany(d => d.HrSkill).WithMany(p => p.HrEmployee)
                        entity.HasMany(d => d.HrSkill).WithMany(p => p.HrEmployee)
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
                                    j.IndexerProperty<Guid>("HrEmployeeId").HasColumnName("hr_employee_id");
                                    j.IndexerProperty<Guid>("HrSkillId").HasColumnName("hr_skill_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}