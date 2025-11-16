using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureWebsiteCheckoutStep(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<WebsiteCheckoutStep>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("website_checkout_step_pkey");

                        entity.ToTable("website_checkout_step");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.IsPublished, "website_checkout_step__is_published_index");

                        entity.HasIndex(e => e.WebsiteId, "website_checkout_step__website_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.BackButtonLabel)
                            .HasColumnType("jsonb")
                            .HasColumnName("back_button_label");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.IsPublished).HasColumnName("is_published");
                        entity.Property(e => e.MainButtonLabel)
                            .HasColumnType("jsonb")
                            .HasColumnName("main_button_label");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.StepHref).HasColumnName("step_href");
                        entity.Property(e => e.WebsiteId).HasColumnName("website_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.WebsiteCheckoutStepCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("website_checkout_step_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("website_checkout_step_create_uid_fkey");

                        // entity.HasOne(d => d.Website).WithMany(p => p.WebsiteCheckoutStep) .HasForeignKey(d => d.WebsiteId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("website_checkout_step_website_id_fkey");
                        entity.HasOne(d => d.Website).WithMany()
                            .HasForeignKey(d => d.WebsiteId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("website_checkout_step_website_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.WebsiteCheckoutStepWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("website_checkout_step_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("website_checkout_step_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}