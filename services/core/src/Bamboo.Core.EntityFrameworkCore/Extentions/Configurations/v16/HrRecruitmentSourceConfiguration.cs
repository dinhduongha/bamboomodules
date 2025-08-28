using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureHrRecruitmentSource(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HrRecruitmentSource>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("hr_recruitment_source_pkey");

                        entity.ToTable("hr_recruitment_source");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AliasId).HasColumnName("alias_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.JobId).HasColumnName("job_id");
                        entity.Property(e => e.MediumId).HasColumnName("medium_id");
                        entity.Property(e => e.SourceId).HasColumnName("source_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Alias).WithMany(p => p.HrRecruitmentSource)
                            .HasForeignKey(d => d.AliasId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("hr_recruitment_source_alias_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.HrRecruitmentSourceCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_recruitment_source_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_recruitment_source_create_uid_fkey");

                        entity.HasOne(d => d.Job).WithMany(p => p.HrRecruitmentSource)
                            .HasForeignKey(d => d.JobId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("hr_recruitment_source_job_id_fkey");

                        entity.HasOne(d => d.Medium).WithMany(p => p.HrRecruitmentSource)
                            .HasForeignKey(d => d.MediumId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_recruitment_source_medium_id_fkey");

                        entity.HasOne(d => d.Source).WithMany(p => p.HrRecruitmentSource)
                            .HasForeignKey(d => d.SourceId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("hr_recruitment_source_source_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.HrRecruitmentSourceWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_recruitment_source_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_recruitment_source_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}