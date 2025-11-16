using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureProjectTemplateCreateWizard(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ProjectTemplateCreateWizard>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("project_template_create_wizard_pkey");

                        entity.ToTable("project_template_create_wizard");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AliasDomainId).HasColumnName("alias_domain_id");
                        entity.Property(e => e.AliasName).HasColumnName("alias_name");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Date).HasColumnName("date");
                        entity.Property(e => e.DateStart).HasColumnName("date_start");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                        entity.Property(e => e.TemplateId).HasColumnName("template_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.AliasDomain).WithMany(p => p.ProjectTemplateCreateWizard)
                            .HasForeignKey(d => d.AliasDomainId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_template_create_wizard_alias_domain_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ProjectTemplateCreateWizardCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("project_template_create_wizard_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_template_create_wizard_create_uid_fkey");

                        // entity.HasOne(d => d.Partner).WithMany(p => p.ProjectTemplateCreateWizard) .HasForeignKey(d => d.PartnerId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("project_template_create_wizard_partner_id_fkey");
                        entity.HasOne(d => d.Partner).WithMany()
                            .HasForeignKey(d => d.PartnerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_template_create_wizard_partner_id_fkey");

                        entity.HasOne(d => d.Template).WithMany(p => p.ProjectTemplateCreateWizard)
                            .HasForeignKey(d => d.TemplateId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_template_create_wizard_template_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ProjectTemplateCreateWizardWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("project_template_create_wizard_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_template_create_wizard_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}