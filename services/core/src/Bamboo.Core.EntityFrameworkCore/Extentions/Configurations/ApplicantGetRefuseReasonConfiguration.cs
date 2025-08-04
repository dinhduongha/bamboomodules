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
        public static void ConfigureApplicantGetRefuseReason(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicantGetRefuseReason>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("applicant_get_refuse_reason_pkey");

                entity.ToTable("applicant_get_refuse_reason");

                entity.HasIndex(e => e.TenantId, "hr_applicant_get_refuse_reason_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Duplicates).HasColumnName("duplicates");
                entity.Property(e => e.RefuseReasonId).HasColumnName("refuse_reason_id");
                entity.Property(e => e.SendMail).HasColumnName("send_mail");
                entity.Property(e => e.TemplateId).HasColumnName("template_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("applicant_get_refuse_reason_create_uid_fkey");

                entity.HasOne(d => d.RefuseReason).WithMany(p => p.ApplicantGetRefuseReasons)
                    .HasForeignKey(d => d.RefuseReasonId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("applicant_get_refuse_reason_refuse_reason_id_fkey");

                entity.HasOne(d => d.Template).WithMany(p => p.ApplicantGetRefuseReasons)
                    .HasForeignKey(d => d.TemplateId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("applicant_get_refuse_reason_template_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("applicant_get_refuse_reason_write_uid_fkey");

                //entity.HasMany(d => d.HrApplicants).WithMany(p => p.ApplicantGetRefuseReasons)
                entity.HasMany<HrApplicant>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "ApplicantGetRefuseReasonHrApplicantRel",
                        r => r.HasOne<HrApplicant>().WithMany()
                            .HasForeignKey("HrApplicantId")
                            .HasConstraintName("applicant_get_refuse_reason_hr_applicant_r_hr_applicant_id_fkey"),
                        l => l.HasOne<ApplicantGetRefuseReason>().WithMany()
                            .HasForeignKey("ApplicantGetRefuseReasonId")
                            .HasConstraintName("applicant_get_refuse_reason_h_applicant_get_refuse_reason__fkey"),
                        j =>
                        {
                            j.HasKey("ApplicantGetRefuseReasonId", "HrApplicantId").HasName("applicant_get_refuse_reason_hr_applicant_rel_pkey");
                            j.ToTable("applicant_get_refuse_reason_hr_applicant_rel");
                            j.HasIndex(new[] { "HrApplicantId", "ApplicantGetRefuseReasonId" }, "applicant_get_refuse_reason_h_hr_applicant_id_applicant_get_idx");
                            j.IndexerProperty<Guid>("ApplicantGetRefuseReasonId").HasColumnName("applicant_get_refuse_reason_id");
                            j.IndexerProperty<Guid>("HrApplicantId").HasColumnName("hr_applicant_id");
                        });
            });
        }
    }
}