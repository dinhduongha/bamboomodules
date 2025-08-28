using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureIrProperty(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<IrProperty>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("ir_property_pkey");

                        entity.ToTable("ir_property");

                        entity.HasIndex(e => e.TenantId, "ir_property_company_id_index");

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.Name, "ir_property_name_index");

                        entity.HasIndex(e => e.ResId, "ir_property_res_id_index");

                        entity.HasIndex(e => e.Type, "ir_property_type_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.FieldsId).HasColumnName("fields_id");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.ResId).HasColumnName("res_id");
                        entity.Property(e => e.Type).HasColumnName("type");
                        entity.Property(e => e.ValueBinary).HasColumnName("value_binary");
                        entity.Property(e => e.ValueDatetime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("value_datetime");
                        entity.Property(e => e.ValueFloat).HasColumnName("value_float");
                        entity.Property(e => e.ValueInteger).HasColumnName("value_integer");
                        entity.Property(e => e.ValueReference).HasColumnName("value_reference");
                        entity.Property(e => e.ValueText).HasColumnName("value_text");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.IrProperty) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("ir_property_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("ir_property_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.IrPropertyCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("ir_property_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("ir_property_create_uid_fkey");

                        entity.HasOne(d => d.Fields).WithMany(p => p.IrProperty)
                            .HasForeignKey(d => d.FieldsId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("ir_property_fields_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.IrPropertyWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("ir_property_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("ir_property_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}