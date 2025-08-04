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
        public static void ConfigureHrRecruitmentStage(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HrRecruitmentStage>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("hr_recruitment_stage_pkey");

                entity.ToTable("hr_recruitment_stage");

                entity.HasIndex(e => e.TenantId, "hr_recruitment_stage_company_id_index");

                //entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Fold).HasColumnName("fold");
                entity.Property(e => e.HiredStage).HasColumnName("hired_stage");
                entity.Property(e => e.LegendBlocked)
                    .HasColumnType("jsonb")
                    .HasColumnName("legend_blocked");
                entity.Property(e => e.LegendDone)
                    .HasColumnType("jsonb")
                    .HasColumnName("legend_done");
                entity.Property(e => e.LegendNormal)
                    .HasColumnType("jsonb")
                    .HasColumnName("legend_normal");
                entity.Property(e => e.Name)
                    .HasColumnType("jsonb")
                    .HasColumnName("name");
                entity.Property(e => e.Requirements).HasColumnName("requirements");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
                entity.Property(e => e.TemplateId).HasColumnName("template_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_recruitment_stage_create_uid_fkey");

                entity.HasOne(d => d.Template).WithMany(p => p.HrRecruitmentStages)
                    .HasForeignKey(d => d.TemplateId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_recruitment_stage_template_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("hr_recruitment_stage_write_uid_fkey");

                //entity.HasMany(d => d.HrJobs).WithMany(p => p.HrRecruitmentStages)
                entity.HasMany<HrJob>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "HrJobHrRecruitmentStageRel",
                        r => r.HasOne<HrJob>().WithMany()
                            .HasForeignKey("HrJobId")
                            .HasConstraintName("hr_job_hr_recruitment_stage_rel_hr_job_id_fkey"),
                        l => l.HasOne<HrRecruitmentStage>().WithMany()
                            .HasForeignKey("HrRecruitmentStageId")
                            .HasConstraintName("hr_job_hr_recruitment_stage_rel_hr_recruitment_stage_id_fkey"),
                        j =>
                        {
                            j.HasKey("HrRecruitmentStageId", "HrJobId").HasName("hr_job_hr_recruitment_stage_rel_pkey");
                            j.ToTable("hr_job_hr_recruitment_stage_rel");
                            j.HasIndex(new[] { "HrJobId", "HrRecruitmentStageId" }, "hr_job_hr_recruitment_stage_r_hr_job_id_hr_recruitment_stag_idx");
                        });
            });
        }
    }
}