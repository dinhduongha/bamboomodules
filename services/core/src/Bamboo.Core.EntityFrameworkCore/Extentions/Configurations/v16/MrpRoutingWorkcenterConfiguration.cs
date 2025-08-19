using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Models;
// Cần thêm using đến namespace chứa entity của bạn ở đây
// Ví dụ: using YourProject.Entities;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMrpRoutingWorkcenter(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MrpRoutingWorkcenter>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mrp_routing_workcenter_pkey");

            entity.ToTable("mrp_routing_workcenter");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.BomId, "mrp_routing_workcenter__bom_id_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.BomId).HasColumnName("bom_id");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Note).HasColumnName("note");
            entity.Property(e => e.Sequence).HasColumnName("sequence");
            entity.Property(e => e.TimeCycleManual).HasColumnName("time_cycle_manual");
            entity.Property(e => e.TimeMode).HasColumnName("time_mode");
            entity.Property(e => e.TimeModeBatch).HasColumnName("time_mode_batch");
            entity.Property(e => e.WorkcenterId).HasColumnName("workcenter_id");
            entity.Property(e => e.WorksheetGoogleSlide).HasColumnName("worksheet_google_slide");
            entity.Property(e => e.WorksheetType).HasColumnName("worksheet_type");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.Bom).WithMany(p => p.MrpRoutingWorkcenter)
                .HasForeignKey(d => d.BomId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("mrp_routing_workcenter_bom_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.MrpRoutingWorkcenterCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mrp_routing_workcenter_create_uid_fkey");

            entity.HasOne(d => d.Workcenter).WithMany(p => p.MrpRoutingWorkcenter)
                .HasForeignKey(d => d.WorkcenterId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("mrp_routing_workcenter_workcenter_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.MrpRoutingWorkcenterWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("mrp_routing_workcenter_write_uid_fkey");

            // entity.HasMany(d => d.BlockedBy).WithMany(p => p.Operation)
            entity.HasMany(d => d.BlockedBy).WithMany(p => p.Operation)
                .UsingEntity<Dictionary<string, object>>(
                    "MrpRoutingWorkcenterDependenciesRel",
                    r => r.HasOne<MrpRoutingWorkcenter>().WithMany()
                        .HasForeignKey("BlockedById")
                        .HasConstraintName("mrp_routing_workcenter_dependencies_rel_blocked_by_id_fkey"),
                    l => l.HasOne<MrpRoutingWorkcenter>().WithMany()
                        .HasForeignKey("OperationId")
                        .HasConstraintName("mrp_routing_workcenter_dependencies_rel_operation_id_fkey"),
                    j =>
                    {
                        j.HasKey("OperationId", "BlockedById").HasName("mrp_routing_workcenter_dependencies_rel_pkey");
                        j.ToTable("mrp_routing_workcenter_dependencies_rel");
                        j.HasIndex(new[] { "BlockedById", "OperationId" }, "mrp_routing_workcenter_dependenc_blocked_by_id_operation_id_idx");
                        j.IndexerProperty<Guid>("OperationId").HasColumnName("operation_id");
                        j.IndexerProperty<Guid>("BlockedById").HasColumnName("blocked_by_id");
                    });

            // entity.HasMany(d => d.Operation).WithMany(p => p.BlockedBy)
            entity.HasMany(d => d.Operation).WithMany(p => p.BlockedBy)
                .UsingEntity<Dictionary<string, object>>(
                    "MrpRoutingWorkcenterDependenciesRel",
                    r => r.HasOne<MrpRoutingWorkcenter>().WithMany()
                        .HasForeignKey("OperationId")
                        .HasConstraintName("mrp_routing_workcenter_dependencies_rel_operation_id_fkey"),
                    l => l.HasOne<MrpRoutingWorkcenter>().WithMany()
                        .HasForeignKey("BlockedById")
                        .HasConstraintName("mrp_routing_workcenter_dependencies_rel_blocked_by_id_fkey"),
                    j =>
                    {
                        j.HasKey("OperationId", "BlockedById").HasName("mrp_routing_workcenter_dependencies_rel_pkey");
                        j.ToTable("mrp_routing_workcenter_dependencies_rel");
                        j.HasIndex(new[] { "BlockedById", "OperationId" }, "mrp_routing_workcenter_dependenc_blocked_by_id_operation_id_idx");
                        j.IndexerProperty<Guid>("OperationId").HasColumnName("operation_id");
                        j.IndexerProperty<Guid>("BlockedById").HasColumnName("blocked_by_id");
                    });

            // entity.HasMany(d => d.ProductTemplateAttributeValue).WithMany(p => p.MrpRoutingWorkcenter)
            entity.HasMany(d => d.ProductTemplateAttributeValue).WithMany(p => p.MrpRoutingWorkcenter)
                .UsingEntity<Dictionary<string, object>>(
                    "MrpRoutingWorkcenterProductTemplateAttributeValueRel",
                    r => r.HasOne<ProductTemplateAttributeValue>().WithMany()
                        .HasForeignKey("ProductTemplateAttributeValueId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .HasConstraintName("mrp_routing_workcenter_produc_product_template_attribute_v_fkey"),
                    l => l.HasOne<MrpRoutingWorkcenter>().WithMany()
                        .HasForeignKey("MrpRoutingWorkcenterId")
                        .HasConstraintName("mrp_routing_workcenter_product_t_mrp_routing_workcenter_id_fkey"),
                    j =>
                    {
                        j.HasKey("MrpRoutingWorkcenterId", "ProductTemplateAttributeValueId").HasName("mrp_routing_workcenter_product_template_attribute_value_re_pkey");
                        j.ToTable("mrp_routing_workcenter_product_template_attribute_value_rel");
                        j.HasIndex(new[] { "ProductTemplateAttributeValueId", "MrpRoutingWorkcenterId" }, "mrp_routing_workcenter_produc_product_template_attribute_va_idx");
                        j.IndexerProperty<Guid>("MrpRoutingWorkcenterId").HasColumnName("mrp_routing_workcenter_id");
                        j.IndexerProperty<Guid>("ProductTemplateAttributeValueId").HasColumnName("product_template_attribute_value_id");
                    });
            });
        }
    }
}
