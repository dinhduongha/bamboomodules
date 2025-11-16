using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureProjectSaleLineEmployeeMap(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ProjectSaleLineEmployeeMap>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("project_sale_line_employee_map_pkey");

                        entity.ToTable("project_sale_line_employee_map");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.ProjectId, "project_sale_line_employee_map__project_id_index");

                        entity.HasIndex(e => new { e.ProjectId, e.EmployeeId }, "project_sale_line_employee_map_uniqueness_employee").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Cost).HasColumnName("cost");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
                        entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
                        entity.Property(e => e.IsCostChanged).HasColumnName("is_cost_changed");
                        entity.Property(e => e.PriceUnit).HasColumnName("price_unit");
                        entity.Property(e => e.ProjectId).HasColumnName("project_id");
                        entity.Property(e => e.SaleLineId).HasColumnName("sale_line_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ProjectSaleLineEmployeeMapCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("project_sale_line_employee_map_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_sale_line_employee_map_create_uid_fkey");

                        // entity.HasOne(d => d.Currency).WithMany(p => p.ProjectSaleLineEmployeeMap) .HasForeignKey(d => d.CurrencyId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("project_sale_line_employee_map_currency_id_fkey");
                        entity.HasOne(d => d.Currency).WithMany()
                            .HasForeignKey(d => d.CurrencyId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_sale_line_employee_map_currency_id_fkey");

                        entity.HasOne(d => d.Employee).WithMany(p => p.ProjectSaleLineEmployeeMap)
                            .HasForeignKey(d => d.EmployeeId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("project_sale_line_employee_map_employee_id_fkey");

                        entity.HasOne(d => d.Project).WithMany(p => p.ProjectSaleLineEmployeeMap)
                            .HasForeignKey(d => d.ProjectId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("project_sale_line_employee_map_project_id_fkey");

                        entity.HasOne(d => d.SaleLine).WithMany(p => p.ProjectSaleLineEmployeeMap)
                            .HasForeignKey(d => d.SaleLineId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_sale_line_employee_map_sale_line_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ProjectSaleLineEmployeeMapWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("project_sale_line_employee_map_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("project_sale_line_employee_map_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}