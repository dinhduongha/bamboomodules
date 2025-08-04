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
        public static void ConfigureCrmLeadScoringFrequencyField(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CrmLeadScoringFrequencyField>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("crm_lead_scoring_frequency_field_pkey");

                entity.ToTable("crm_lead_scoring_frequency_field");

                entity.HasIndex(e => e.TenantId, "crm_lead_scoring_frequency_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.FieldId).HasColumnName("field_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_lead_scoring_frequency_field_create_uid_fkey");

                entity.HasOne(d => d.Field).WithMany(p => p.CrmLeadScoringFrequencyFields)
                    .HasForeignKey(d => d.FieldId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("crm_lead_scoring_frequency_field_field_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_lead_scoring_frequency_field_write_uid_fkey");
            });
        }
    }
}