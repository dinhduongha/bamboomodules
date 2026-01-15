using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureResCurrencyExtra(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResCurrency>(entity =>
            {
                entity.HasIndex(e => e.Network);
                entity.HasIndex(e => e.ContractAddress);
                entity.Property(e => e.IsStableCoin).HasColumnName("is_stable_coin").HasDefaultValue(false);
                entity.Property(e => e.ContractAddress).HasColumnName("contract_address");
            });
        }
    }
}