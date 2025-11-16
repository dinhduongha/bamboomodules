using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureAccountFiscalPositionTax(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountFiscalPositionTax>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_fiscal_position_tax_pkey");

                        entity.ToTable("account_fiscal_position_tax");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => new { e.PositionId, e.TaxSrcId, e.TaxDestId }, "account_fiscal_position_tax_tax_src_dest_uniq").IsUnique();

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
                        entity.Property(e => e.PositionId).HasColumnName("position_id");
                        entity.Property(e => e.TaxDestId).HasColumnName("tax_dest_id");
                        entity.Property(e => e.TaxSrcId).HasColumnName("tax_src_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.AccountFiscalPositionTax) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_fiscal_position_tax_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_fiscal_position_tax_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountFiscalPositionTaxCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_fiscal_position_tax_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_fiscal_position_tax_create_uid_fkey");

                        entity.HasOne(d => d.Position).WithMany(p => p.AccountFiscalPositionTax)
                            .HasForeignKey(d => d.PositionId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("account_fiscal_position_tax_position_id_fkey");

                        entity.HasOne(d => d.TaxDest).WithMany(p => p.AccountFiscalPositionTaxTaxDest)
                            .HasForeignKey(d => d.TaxDestId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_fiscal_position_tax_tax_dest_id_fkey");

                        entity.HasOne(d => d.TaxSrc).WithMany(p => p.AccountFiscalPositionTaxTaxSrc)
                            .HasForeignKey(d => d.TaxSrcId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("account_fiscal_position_tax_tax_src_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountFiscalPositionTaxWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_fiscal_position_tax_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_fiscal_position_tax_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}