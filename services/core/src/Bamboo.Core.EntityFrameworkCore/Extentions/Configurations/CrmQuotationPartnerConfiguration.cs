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
        public static void ConfigureCrmQuotationPartner(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CrmQuotationPartner>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("crm_quotation_partner_pkey");

                entity.ToTable("crm_quotation_partner");

                entity.HasIndex(e => e.TenantId, "crm_quotation_partner_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Action).HasColumnName("action");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.LeadId).HasColumnName("lead_id");
                entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_quotation_partner_create_uid_fkey");

                entity.HasOne(d => d.Lead).WithMany(p => p.CrmQuotationPartners)
                    .HasForeignKey(d => d.LeadId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("crm_quotation_partner_lead_id_fkey");

                entity.HasOne<ResPartner>().WithMany()
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_quotation_partner_partner_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("crm_quotation_partner_write_uid_fkey");
            });
        }
    }
}