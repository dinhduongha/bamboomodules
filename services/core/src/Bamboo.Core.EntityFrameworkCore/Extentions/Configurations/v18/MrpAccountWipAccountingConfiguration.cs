using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMrpAccountWipAccounting(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MrpAccountWipAccounting>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("mrp_account_wip_accounting_pkey");

                        entity.ToTable("mrp_account_wip_accounting");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

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
                        entity.Property(e => e.Date).HasColumnName("date");
                        entity.Property(e => e.JournalId).HasColumnName("journal_id");
                        entity.Property(e => e.Reference).HasColumnName("reference");
                        entity.Property(e => e.ReversalDate).HasColumnName("reversal_date");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.MrpAccountWipAccountingCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mrp_account_wip_accounting_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_account_wip_accounting_create_uid_fkey");

                        // entity.HasOne(d => d.Journal).WithMany(p => p.MrpAccountWipAccounting) .HasForeignKey(d => d.JournalId) .OnDelete(DeleteBehavior.Cascade) .HasConstraintName("mrp_account_wip_accounting_journal_id_fkey");
                        entity.HasOne(d => d.Journal).WithMany()
                            .HasForeignKey(d => d.JournalId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("mrp_account_wip_accounting_journal_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.MrpAccountWipAccountingWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("mrp_account_wip_accounting_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("mrp_account_wip_accounting_write_uid_fkey");

                        // entity.HasMany(d => d.MrpProduction).WithMany(p => p.MrpAccountWipAccounting)
                        entity.HasMany(d => d.MrpProduction).WithMany(p => p.MrpAccountWipAccounting)
                            .UsingEntity<Dictionary<string, object>>(
                                "MrpAccountWipAccountingMrpProductionRel",
                                r => r.HasOne<MrpProduction>().WithMany()
                                    .HasForeignKey("MrpProductionId")
                                    .HasConstraintName("mrp_account_wip_accounting_mrp_productio_mrp_production_id_fkey"),
                                l => l.HasOne<MrpAccountWipAccounting>().WithMany()
                                    .HasForeignKey("MrpAccountWipAccountingId")
                                    .HasConstraintName("mrp_account_wip_accounting_mr_mrp_account_wip_accounting_i_fkey"),
                                j =>
                                {
                                    j.HasKey("MrpAccountWipAccountingId", "MrpProductionId").HasName("mrp_account_wip_accounting_mrp_production_rel_pkey");
                                    j.ToTable("mrp_account_wip_accounting_mrp_production_rel");
                                    j.HasIndex(new[] { "MrpProductionId", "MrpAccountWipAccountingId" }, "mrp_account_wip_accounting_mr_mrp_production_id_mrp_account_idx");
                                    j.IndexerProperty<Guid>("MrpAccountWipAccountingId").HasColumnName("mrp_account_wip_accounting_id");
                                    j.IndexerProperty<Guid>("MrpProductionId").HasColumnName("mrp_production_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}