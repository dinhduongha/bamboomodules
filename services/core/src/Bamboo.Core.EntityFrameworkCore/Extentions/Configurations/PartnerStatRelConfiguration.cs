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
        public static void ConfigurePartnerStatRel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PartnerStatRel>(entity =>
            {
                entity.HasKey(e => new { e.OsvMemoryId, e.PartnerId }).HasName("partner_stat_rel_pkey");

                entity.ToTable("partner_stat_rel");

                entity.HasIndex(e => e.TenantId, "partner_stat_rel_company_id_index");

                entity.HasIndex(e => new { e.PartnerId, e.OsvMemoryId }, "partner_stat_rel_partner_id_osv_memory_id_idx");

                entity.Property(e => e.OsvMemoryId).HasColumnName("osv_memory_id");
                entity.Property(e => e.PartnerId).HasColumnName("partner_id");

                entity.HasOne(d => d.OsvMemory).WithMany(p => p.PartnerStatRels)
                    .HasForeignKey(d => d.OsvMemoryId)
                    .HasConstraintName("partner_stat_rel_osv_memory_id_fkey");
            });
        }
    }
}