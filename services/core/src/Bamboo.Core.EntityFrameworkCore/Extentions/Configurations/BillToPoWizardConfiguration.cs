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
        public static void ConfigureBillToPoWizard(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BillToPoWizard>(entity =>
            {
                    entity.HasKey(e => e.Id).HasName("bill_to_po_wizard_pkey");

                    entity.ToTable("bill_to_po_wizard");

                    entity.Property(e => e.Id)
                        .HasDefaultValueSql("next_uuid()")
                        .HasColumnName("id");
                    entity.Property(e => e.TenantId).HasColumnName("company_id");
                    entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("create_date");
                    entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                    entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                    entity.Property(e => e.PurchaseOrderId).HasColumnName("purchase_order_id");
                    entity.Property(e => e.LastModificationTime)
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("write_date");
                    entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                    entity.HasOne<ResUser>().WithMany()
                        .HasForeignKey(d => d.CreatorId)
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("bill_to_po_wizard_create_uid_fkey");

                    entity.HasOne<ResPartner>().WithMany()
                        .HasForeignKey(d => d.PartnerId)
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("bill_to_po_wizard_partner_id_fkey");

                //entity.HasOne(d => d.PurchaseOrder).WithMany(p => p.BillToPoWizards)
                    entity.HasOne(d => d.PurchaseOrder).WithMany()
                        .HasForeignKey(d => d.PurchaseOrderId)
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("bill_to_po_wizard_purchase_order_id_fkey");

                    entity.HasOne<ResUser>().WithMany()
                        .HasForeignKey(d => d.LastModifierId)
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("bill_to_po_wizard_write_uid_fkey");
            });
        }
    }
}