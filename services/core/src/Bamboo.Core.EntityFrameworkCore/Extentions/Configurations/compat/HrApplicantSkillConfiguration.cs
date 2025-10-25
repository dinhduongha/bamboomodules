using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureHrApplicantSkill(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<HrApplicantSkill>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("hr_applicant_skill_pkey");

                        entity.ToTable("hr_applicant_skill");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => new { e.ApplicantId, e.SkillId }, "hr_applicant_skill__unique_skill").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.ApplicantId).HasColumnName("applicant_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.SkillId).HasColumnName("skill_id");
                        entity.Property(e => e.SkillLevelId).HasColumnName("skill_level_id");
                        entity.Property(e => e.SkillTypeId).HasColumnName("skill_type_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.Applicant).WithMany(p => p.HrApplicantSkill)
                            .HasForeignKey(d => d.ApplicantId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("hr_applicant_skill_applicant_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.HrApplicantSkillCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_applicant_skill_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_applicant_skill_create_uid_fkey");

                        entity.HasOne(d => d.Skill).WithMany()
                            .HasForeignKey(d => d.SkillId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("hr_applicant_skill_skill_id_fkey");

                        entity.HasOne(d => d.SkillLevel).WithMany()
                            .HasForeignKey(d => d.SkillLevelId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("hr_applicant_skill_skill_level_id_fkey");

                        entity.HasOne(d => d.SkillType).WithMany()
                            .HasForeignKey(d => d.SkillTypeId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("hr_applicant_skill_skill_type_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.HrApplicantSkillWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("hr_applicant_skill_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("hr_applicant_skill_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}