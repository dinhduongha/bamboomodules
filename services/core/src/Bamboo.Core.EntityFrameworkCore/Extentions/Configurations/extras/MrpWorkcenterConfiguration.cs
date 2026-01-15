using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureMrpWorkcenterExtra(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MrpWorkcenter>(entity =>
            {
                entity.HasIndex(e => e.CategId, "mrp_workcenter__categ_id_index");
                entity.Property(e => e.CategId).HasColumnName("categ_id");
                entity.HasOne(d => d.Categ).WithMany()
                        .HasForeignKey(d => d.CategId)
                        .OnDelete(DeleteBehavior.SetNull)
                        .HasConstraintName("mrp_workcenter_categ_id_fkey");

            });
        }
    }
}