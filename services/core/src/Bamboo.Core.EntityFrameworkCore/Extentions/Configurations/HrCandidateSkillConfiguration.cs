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
        public static void ConfigureHrCandidateSkill(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HrCandidateSkill>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("hr_candidate_skill_pkey");

                entity.ToTable("hr_candidate_skill");

                entity.HasIndex(e => new { e.CandidateId, e.SkillId }, "hr_candidate_skill__unique_skill").IsUnique();

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CandidateId).HasColumnName("candidate_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
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

                entity.HasOne(d => d.Candidate).WithMany(p => p.HrCandidateSkills)
                    .HasForeignKey(d => d.CandidateId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("hr_candidate_skill_candidate_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_candidate_skill_create_uid_fkey");

                entity.HasOne(d => d.Skill).WithMany()
                    .HasForeignKey(d => d.SkillId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("hr_candidate_skill_skill_id_fkey");

                entity.HasOne(d => d.SkillLevel).WithMany()
                    .HasForeignKey(d => d.SkillLevelId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("hr_candidate_skill_skill_level_id_fkey");

                entity.HasOne(d => d.SkillType).WithMany()
                    .HasForeignKey(d => d.SkillTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("hr_candidate_skill_skill_type_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_candidate_skill_write_uid_fkey");
            });
        }
    }
}