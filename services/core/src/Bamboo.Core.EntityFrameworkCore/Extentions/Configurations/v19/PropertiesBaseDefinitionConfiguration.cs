using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigurePropertiesBaseDefinition(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<PropertiesBaseDefinition>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("properties_base_definition_pkey");

                        entity.ToTable("properties_base_definition");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.PropertiesFieldId, "properties_base_definition_unique_properties_field_id").IsUnique();

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
                        entity.Property(e => e.PropertiesDefinition)
                            .HasColumnType("jsonb")
                            .HasColumnName("properties_definition");
                        entity.Property(e => e.PropertiesFieldId).HasColumnName("properties_field_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.PropertiesBaseDefinitionCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("properties_base_definition_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("properties_base_definition_create_uid_fkey");

                        entity.HasOne(d => d.PropertiesField).WithOne(p => p.PropertiesBaseDefinition)
                            .HasForeignKey<PropertiesBaseDefinition>(d => d.PropertiesFieldId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("properties_base_definition_properties_field_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.PropertiesBaseDefinitionWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("properties_base_definition_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("properties_base_definition_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}