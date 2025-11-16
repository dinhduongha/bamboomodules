using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureJobAddApplicants(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<JobAddApplicants>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("job_add_applicants_pkey");

                        entity.ToTable("job_add_applicants");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.JobAddApplicantsCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("job_add_applicants_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("job_add_applicants_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.JobAddApplicantsWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("job_add_applicants_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("job_add_applicants_write_uid_fkey");

                        // entity.HasMany(d => d.HrApplicant).WithMany(p => p.JobAddApplicants)
                        entity.HasMany(d => d.HrApplicant).WithMany(p => p.JobAddApplicants)
                            .UsingEntity<Dictionary<string, object>>(
                                "HrApplicantJobAddApplicantsRel",
                                r => r.HasOne<HrApplicant>().WithMany()
                                    .HasForeignKey("HrApplicantId")
                                    .HasConstraintName("hr_applicant_job_add_applicants_rel_hr_applicant_id_fkey"),
                                l => l.HasOne<JobAddApplicants>().WithMany()
                                    .HasForeignKey("JobAddApplicantsId")
                                    .HasConstraintName("hr_applicant_job_add_applicants_rel_job_add_applicants_id_fkey"),
                                j =>
                                {
                                    j.HasKey("JobAddApplicantsId", "HrApplicantId").HasName("hr_applicant_job_add_applicants_rel_pkey");
                                    j.ToTable("hr_applicant_job_add_applicants_rel");
                                    j.HasIndex(new[] { "HrApplicantId", "JobAddApplicantsId" }, "hr_applicant_job_add_applican_hr_applicant_id_job_add_appli_idx");
                                    j.IndexerProperty<Guid>("JobAddApplicantsId").HasColumnName("job_add_applicants_id");
                                    j.IndexerProperty<Guid>("HrApplicantId").HasColumnName("hr_applicant_id");
                                });

                        // entity.HasMany(d => d.HrJob).WithMany(p => p.JobAddApplicants)
                        entity.HasMany(d => d.HrJob).WithMany(p => p.JobAddApplicants)
                            .UsingEntity<Dictionary<string, object>>(
                                "HrJobJobAddApplicantsRel",
                                r => r.HasOne<HrJob>().WithMany()
                                    .HasForeignKey("HrJobId")
                                    .HasConstraintName("hr_job_job_add_applicants_rel_hr_job_id_fkey"),
                                l => l.HasOne<JobAddApplicants>().WithMany()
                                    .HasForeignKey("JobAddApplicantsId")
                                    .HasConstraintName("hr_job_job_add_applicants_rel_job_add_applicants_id_fkey"),
                                j =>
                                {
                                    j.HasKey("JobAddApplicantsId", "HrJobId").HasName("hr_job_job_add_applicants_rel_pkey");
                                    j.ToTable("hr_job_job_add_applicants_rel");
                                    j.HasIndex(new[] { "HrJobId", "JobAddApplicantsId" }, "hr_job_job_add_applicants_rel_hr_job_id_job_add_applicants__idx");
                                    j.IndexerProperty<Guid>("JobAddApplicantsId").HasColumnName("job_add_applicants_id");
                                    j.IndexerProperty<Guid>("HrJobId").HasColumnName("hr_job_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}