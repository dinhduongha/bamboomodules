using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureHrJobSkill(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HrJobSkill>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("hr_job_skill_pkey");

                        entity.ToTable("hr_job_skill");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.JobId, "hr_job_skill__job_id_index");

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
                        entity.Property(e => e.DisplayWarningMessage).HasColumnName("display_warning_message");
                        entity.Property(e => e.JobId).HasColumnName("job_id");
                        entity.Property(e => e.SkillId).HasColumnName("skill_id");
                        entity.Property(e => e.SkillLevelId).HasColumnName("skill_level_id");
                        entity.Property(e => e.SkillTypeId).HasColumnName("skill_type_id");
                        entity.Property(e => e.ValidFrom).HasColumnName("valid_from");
                        entity.Property(e => e.ValidTo).HasColumnName("valid_to");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.HrJobSkillCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_job_skill_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_job_skill_create_uid_fkey");

                        entity.HasOne(d => d.Job).WithMany(p => p.HrJobSkill)
                            .HasForeignKey(d => d.JobId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("hr_job_skill_job_id_fkey");

                        entity.HasOne(d => d.Skill).WithMany(p => p.HrJobSkill)
                            .HasForeignKey(d => d.SkillId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("hr_job_skill_skill_id_fkey");

                        entity.HasOne(d => d.SkillLevel).WithMany(p => p.HrJobSkill)
                            .HasForeignKey(d => d.SkillLevelId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("hr_job_skill_skill_level_id_fkey");

                        entity.HasOne(d => d.SkillType).WithMany(p => p.HrJobSkill)
                            .HasForeignKey(d => d.SkillTypeId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("hr_job_skill_skill_type_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.HrJobSkillWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_job_skill_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_job_skill_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}