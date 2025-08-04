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
        public static void ConfigureAccountFiscalPositionTaxTemplate(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountFiscalPositionTaxTemplate>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("account_fiscal_position_tax_template_pkey");

                entity.ToTable("account_fiscal_position_tax_template");

                entity.HasIndex(e => e.TenantId, "account_fiscal_position_tax_template_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
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

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_fiscal_position_tax_template_create_uid_fkey");

                entity.HasOne(d => d.Position).WithMany(p => p.AccountFiscalPositionTaxTemplates)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("account_fiscal_position_tax_template_position_id_fkey");

                entity.HasOne(d => d.TaxDest).WithMany(p => p.AccountFiscalPositionTaxTemplateTaxDests)
                    .HasForeignKey(d => d.TaxDestId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_fiscal_position_tax_template_tax_dest_id_fkey");

                entity.HasOne(d => d.TaxSrc).WithMany(p => p.AccountFiscalPositionTaxTemplateTaxSrcs)
                    .HasForeignKey(d => d.TaxSrcId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("account_fiscal_position_tax_template_tax_src_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("account_fiscal_position_tax_template_write_uid_fkey");
            });
        }
    }
}