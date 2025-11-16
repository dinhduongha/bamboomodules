using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureHrVersion(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HrVersion>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("hr_version_pkey");

                        entity.ToTable("hr_version");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.EmployeeId, "hr_version__employee_id_index");

                        entity.HasIndex(e => new { e.EmployeeId, e.DateVersion }, "hr_version_check_unique_date_version")
                            .IsUnique()
                            .HasFilter("((active = true) AND (employee_id IS NOT NULL))");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.AdditionalNote).HasColumnName("additional_note");
                        entity.Property(e => e.AddressId).HasColumnName("address_id");
                        entity.Property(e => e.Children).HasColumnName("children");

                        entity.Property(e => e.ContractDateEnd).HasColumnName("contract_date_end");
                        entity.Property(e => e.ContractDateStart).HasColumnName("contract_date_start");
                        entity.Property(e => e.ContractTemplateId).HasColumnName("contract_template_id");
                        entity.Property(e => e.ContractTypeId).HasColumnName("contract_type_id");
                        entity.Property(e => e.CountryId).HasColumnName("country_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DateGeneratedFrom)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("date_generated_from");
                        entity.Property(e => e.DateGeneratedTo)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("date_generated_to");
                        entity.Property(e => e.DateVersion).HasColumnName("date_version");
                        entity.Property(e => e.DepartmentId).HasColumnName("department_id");
                        entity.Property(e => e.DepartureDate).HasColumnName("departure_date");
                        entity.Property(e => e.DepartureDescription).HasColumnName("departure_description");
                        entity.Property(e => e.DepartureReasonId).HasColumnName("departure_reason_id");
                        entity.Property(e => e.DistanceHomeWork).HasColumnName("distance_home_work");
                        entity.Property(e => e.DistanceHomeWorkUnit).HasColumnName("distance_home_work_unit");
                        entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
                        entity.Property(e => e.EmployeeType).HasColumnName("employee_type");
                        entity.Property(e => e.HrResponsibleId).HasColumnName("hr_responsible_id");
                        entity.Property(e => e.IdentificationId).HasColumnName("identification_id");
                        entity.Property(e => e.IsCustomJobTitle).HasColumnName("is_custom_job_title");
                        entity.Property(e => e.IsFlexible).HasColumnName("is_flexible");
                        entity.Property(e => e.IsFullyFlexible).HasColumnName("is_fully_flexible");
                        entity.Property(e => e.JobId).HasColumnName("job_id");
                        entity.Property(e => e.JobTitle).HasColumnName("job_title");
                        entity.Property(e => e.KmHomeWork).HasColumnName("km_home_work");
                        entity.Property(e => e.LastGenerationDate).HasColumnName("last_generation_date");
                        entity.Property(e => e.LastModifiedDate)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("last_modified_date");
                        entity.Property(e => e.LastModifiedUid).HasColumnName("last_modified_uid");
                        entity.Property(e => e.Marital).HasColumnName("marital");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.PassportExpirationDate).HasColumnName("passport_expiration_date");
                        entity.Property(e => e.PassportId).HasColumnName("passport_id");
                        entity.Property(e => e.PrivateCity).HasColumnName("private_city");
                        entity.Property(e => e.PrivateCountryId).HasColumnName("private_country_id");
                        entity.Property(e => e.PrivateStateId).HasColumnName("private_state_id");
                        entity.Property(e => e.PrivateStreet).HasColumnName("private_street");
                        entity.Property(e => e.PrivateStreet2).HasColumnName("private_street2");
                        entity.Property(e => e.PrivateZip).HasColumnName("private_zip");
                        entity.Property(e => e.ResourceCalendarId).HasColumnName("resource_calendar_id");
                        entity.Property(e => e.RulesetId).HasColumnName("ruleset_id");
                        entity.Property(e => e.Sex).HasColumnName("sex");
                        entity.Property(e => e.SpouseBirthdate).HasColumnName("spouse_birthdate");
                        entity.Property(e => e.SpouseCompleteName).HasColumnName("spouse_complete_name");
                        entity.Property(e => e.Ssnid).HasColumnName("ssnid");
                        entity.Property(e => e.StructureTypeId).HasColumnName("structure_type_id");
                        entity.Property(e => e.TrialDateEnd).HasColumnName("trial_date_end");
                        entity.Property(e => e.Wage).HasColumnName("wage");
                        entity.Property(e => e.WorkEntrySource).HasColumnName("work_entry_source");
                        entity.Property(e => e.WorkLocationId).HasColumnName("work_location_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Address).WithMany(p => p.HrVersion) .HasForeignKey(d => d.AddressId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_version_address_id_fkey");
                        entity.HasOne(d => d.Address).WithMany()
                            .HasForeignKey(d => d.AddressId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_version_address_id_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.HrVersion) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_version_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_version_company_id_fkey");

                        entity.HasOne(d => d.ContractTemplate).WithMany(p => p.InverseContractTemplate)
                            .HasForeignKey(d => d.ContractTemplateId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_version_contract_template_id_fkey");

                        entity.HasOne(d => d.ContractType).WithMany(p => p.HrVersion)
                            .HasForeignKey(d => d.ContractTypeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_version_contract_type_id_fkey");

                        // entity.HasOne(d => d.Country).WithMany(p => p.HrVersionCountry) .HasForeignKey(d => d.CountryId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_version_country_id_fkey");
                        entity.HasOne(d => d.Country).WithMany()
                            .HasForeignKey(d => d.CountryId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_version_country_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.HrVersionCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_version_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_version_create_uid_fkey");

                        entity.HasOne(d => d.Department).WithMany(p => p.HrVersion)
                            .HasForeignKey(d => d.DepartmentId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_version_department_id_fkey");

                        entity.HasOne(d => d.DepartureReason).WithMany(p => p.HrVersion)
                            .HasForeignKey(d => d.DepartureReasonId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("hr_version_departure_reason_id_fkey");

                        entity.HasOne(d => d.Employee).WithMany(p => p.HrVersion)
                            .HasForeignKey(d => d.EmployeeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_version_employee_id_fkey");

                        // entity.HasOne(d => d.HrResponsible).WithMany(p => p.HrVersionHrResponsible) .HasForeignKey(d => d.HrResponsibleId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("hr_version_hr_responsible_id_fkey");
                        entity.HasOne(d => d.HrResponsible).WithMany()
                            .HasForeignKey(d => d.HrResponsibleId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("hr_version_hr_responsible_id_fkey");

                        entity.HasOne(d => d.Job).WithMany(p => p.HrVersion)
                            .HasForeignKey(d => d.JobId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_version_job_id_fkey");

                        // entity.HasOne(d => d.LastModifiedU).WithMany(p => p.HrVersionLastModifiedU) .HasForeignKey(d => d.LastModifiedUid) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("hr_version_last_modified_uid_fkey");
                        entity.HasOne(d => d.LastModifiedU).WithMany()
                            .HasForeignKey(d => d.LastModifiedUid)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("hr_version_last_modified_uid_fkey");

                        // entity.HasOne(d => d.PrivateCountry).WithMany(p => p.HrVersionPrivateCountry) .HasForeignKey(d => d.PrivateCountryId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_version_private_country_id_fkey");
                        entity.HasOne(d => d.PrivateCountry).WithMany()
                            .HasForeignKey(d => d.PrivateCountryId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_version_private_country_id_fkey");

                        // entity.HasOne(d => d.PrivateState).WithMany(p => p.HrVersion) .HasForeignKey(d => d.PrivateStateId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_version_private_state_id_fkey");
                        entity.HasOne(d => d.PrivateState).WithMany()
                            .HasForeignKey(d => d.PrivateStateId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_version_private_state_id_fkey");

                        entity.HasOne(d => d.ResourceCalendar).WithMany(p => p.HrVersion)
                            .HasForeignKey(d => d.ResourceCalendarId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_version_resource_calendar_id_fkey");

                        entity.HasOne(d => d.Ruleset).WithMany(p => p.HrVersion)
                            .HasForeignKey(d => d.RulesetId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_version_ruleset_id_fkey");

                        entity.HasOne(d => d.StructureType).WithMany(p => p.HrVersion)
                            .HasForeignKey(d => d.StructureTypeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_version_structure_type_id_fkey");

                        entity.HasOne(d => d.WorkLocation).WithMany(p => p.HrVersion)
                            .HasForeignKey(d => d.WorkLocationId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_version_work_location_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.HrVersionWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_version_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_version_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}