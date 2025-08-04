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
        public static void ConfigureMrpRoutingWorkcenter(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MrpRoutingWorkcenter>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("mrp_routing_workcenter_pkey");

                entity.ToTable("mrp_routing_workcenter");

                entity.HasIndex(e => e.TenantId, "mrp_routing_workcenter_company_id_index");

                entity.HasIndex(e => e.BomId, "mrp_routing_workcenter_bom_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.BomId).HasColumnName("bom_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Note).HasColumnName("note");
                entity.Property(e => e.Sequence)
                    .HasColumnName("sequence");
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

                entity.HasOne(d => d.Bom).WithMany(p => p.MrpRoutingWorkcenters)
                    .HasForeignKey(d => d.BomId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("mrp_routing_workcenter_bom_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_routing_workcenter_create_uid_fkey");

                entity.HasOne(d => d.Workcenter).WithMany(p => p.MrpRoutingWorkcenters)
                    .HasForeignKey(d => d.WorkcenterId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("mrp_routing_workcenter_workcenter_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("mrp_routing_workcenter_write_uid_fkey");

                //entity.HasMany(d => d.BlockedBies).WithMany(p => p.Operations)
                entity.HasMany<MrpRoutingWorkcenter>().WithMany()
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
                        });

                //entity.HasMany(d => d.Operations).WithMany(p => p.BlockedBies)
                entity.HasMany<MrpRoutingWorkcenter>().WithMany()
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
                        });

                //entity.HasMany(d => d.ProductTemplateAttributeValues).WithMany(p => p.MrpRoutingWorkcenters)
                entity.HasMany<ProductTemplateAttributeValue>().WithMany()
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
                        });
            });
        }
    }
}