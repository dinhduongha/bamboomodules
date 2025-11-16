using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureBasePartnerMergeLine(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<BasePartnerMergeLine>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("base_partner_merge_line_pkey");

                        entity.ToTable("base_partner_merge_line");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");
                        entity.Property(e => e.AggrIds).HasColumnName("aggr_ids");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.MinId).HasColumnName("min_id");
                        entity.Property(e => e.WizardId).HasColumnName("wizard_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.BasePartnerMergeLineCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("base_partner_merge_line_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("base_partner_merge_line_create_uid_fkey");

                        entity.HasOne(d => d.Wizard).WithMany(p => p.BasePartnerMergeLine)
                            .HasForeignKey(d => d.WizardId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("base_partner_merge_line_wizard_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.BasePartnerMergeLineWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("base_partner_merge_line_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("base_partner_merge_line_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}