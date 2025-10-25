using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMrpBom(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MrpBom>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mrp_bom_pkey");

                        entity.ToTable("mrp_bom");

                        entity.HasIndex(e => e.TenantId, "mrp_bom__company_id_index");

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.ProductId, "mrp_bom__product_id_index");

                        entity.HasIndex(e => e.ProductTmplId, "mrp_bom__product_tmpl_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.AllowOperationDependencies).HasColumnName("allow_operation_dependencies");
                        entity.Property(e => e.Code).HasColumnName("code");

                        entity.Property(e => e.Consumption).HasColumnName("consumption");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DaysToPrepareMo).HasColumnName("days_to_prepare_mo");
                        entity.Property(e => e.PickingTypeId).HasColumnName("picking_type_id");
                        entity.Property(e => e.ProduceDelay).HasColumnName("produce_delay");
                        entity.Property(e => e.ProductId).HasColumnName("product_id");
                        entity.Property(e => e.ProductQty).HasColumnName("product_qty");
                        entity.Property(e => e.ProductTmplId).HasColumnName("product_tmpl_id");
                        entity.Property(e => e.ProductUomId).HasColumnName("product_uom_id");
                        entity.Property(e => e.ProjectId).HasColumnName("project_id");
                        entity.Property(e => e.ReadyToProduce).HasColumnName("ready_to_produce");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.Type).HasColumnName("type");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.MrpBom) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mrp_bom_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_bom_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.MrpBomCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mrp_bom_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_bom_create_uid_fkey");

                        entity.HasOne(d => d.PickingType).WithMany(p => p.MrpBom)
                            .HasForeignKey(d => d.PickingTypeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_bom_picking_type_id_fkey");

                        // entity.HasOne(d => d.Product).WithMany(p => p.MrpBom) .HasForeignKey(d => d.ProductId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mrp_bom_product_id_fkey");
                        entity.HasOne(d => d.Product).WithMany()
                            .HasForeignKey(d => d.ProductId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_bom_product_id_fkey");

                        entity.HasOne(d => d.ProductTmpl).WithMany(p => p.MrpBom)
                            .HasForeignKey(d => d.ProductTmplId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("mrp_bom_product_tmpl_id_fkey");

                        // entity.HasOne(d => d.ProductUom).WithMany(p => p.MrpBom) .HasForeignKey(d => d.ProductUomId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("mrp_bom_product_uom_id_fkey");
                        entity.HasOne(d => d.ProductUom).WithMany()
                            .HasForeignKey(d => d.ProductUomId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("mrp_bom_product_uom_id_fkey");

                        entity.HasOne(d => d.Project).WithMany(p => p.MrpBom)
                            .HasForeignKey(d => d.ProjectId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_bom_project_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.MrpBomWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mrp_bom_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_bom_write_uid_fkey");

                        // entity.HasMany(d => d.ResPartner).WithMany(p => p.MrpBom)
                        entity.HasMany(d => d.ResPartner).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "MrpBomSubcontractor",
                                r => r.HasOne<ResPartner>().WithMany()
                                    .HasForeignKey("ResPartnerId")
                                    .HasConstraintName("mrp_bom_subcontractor_res_partner_id_fkey"),
                                l => l.HasOne<MrpBom>().WithMany()
                                    .HasForeignKey("MrpBomId")
                                    .HasConstraintName("mrp_bom_subcontractor_mrp_bom_id_fkey"),
                                j =>
                                {
                                    j.HasKey("MrpBomId", "ResPartnerId").HasName("mrp_bom_subcontractor_pkey");
                                    j.ToTable("mrp_bom_subcontractor");
                                    j.HasIndex(new[] { "ResPartnerId", "MrpBomId" }, "mrp_bom_subcontractor_res_partner_id_mrp_bom_id_idx");
                                    j.IndexerProperty<Guid>("MrpBomId").HasColumnName("mrp_bom_id");
                                    j.IndexerProperty<Guid>("ResPartnerId").HasColumnName("res_partner_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}