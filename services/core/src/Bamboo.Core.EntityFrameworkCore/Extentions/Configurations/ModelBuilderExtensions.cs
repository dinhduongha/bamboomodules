using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ApplyAllCoreConfigurations(this ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("pg_trgm");
            modelBuilder.HasPostgresExtension("btree_gist");
            modelBuilder.HasPostgresExtension("postgis");

            // Áp dụng global cho tất cả FullAudited entities (nếu dùng ABP 8.x+)
            //modelBuilder.Entity<FullAuditedAggregateRoot<Guid>>(b => b.Property(e => e.ExtraProperties).IsRequired(false));

            // Lấy tất cả các type kế thừa từ FullAuditedAggregateRoot<Guid>
            // var entityTypes = modelBuilder.Model.GetEntityTypes()
            // .Where(t => typeof(FullAuditedAggregateRoot<Guid>).IsAssignableFrom(t.ClrType) && t.ClrType != typeof(FullAuditedAggregateRoot<Guid>));

            // Lấy tất cả các entity implement IHasExtraProperties
            var entityTypeExtras = modelBuilder.Model.GetEntityTypes()
                .Where(t => typeof(IHasExtraProperties).IsAssignableFrom(t.ClrType) && !t.ClrType.IsAbstract);

            foreach (var entityType in entityTypeExtras)
            {
                // Cấu hình ExtraProperties nullable cho entity
                modelBuilder.Entity(entityType.ClrType, b =>
                {
                    b.Property(nameof(IHasExtraProperties.ExtraProperties)).IsRequired(false);
                });
            }

            var entityTypeConcurrencyStamps = modelBuilder.Model.GetEntityTypes()
                .Where(t => typeof(IHasConcurrencyStamp).IsAssignableFrom(t.ClrType) && !t.ClrType.IsAbstract);

            foreach (var entityType in entityTypeConcurrencyStamps)
            {
                // Cấu hình ExtraProperties nullable cho entity
                modelBuilder.Entity(entityType.ClrType, b =>
                {
                    b.Property(nameof(IHasConcurrencyStamp.ConcurrencyStamp))
                        .IsRequired(false)
                        .HasDefaultValueSql("uuidv7()::text"); ;
                });
            }

            modelBuilder.ApplyAllConfigurations();
            modelBuilder.ApplyV18Configurations();
            modelBuilder.ConfigureV18Compat();
            modelBuilder.ApplyV16Configurations();
            modelBuilder.ConfigureV16Compat();
            modelBuilder.ApplyExtrasConfigurations();
            //modelBuilder.ApplyViewsConfigurations();            
        }
    }
}
