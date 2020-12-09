using System;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using Bamboo.Base.Entities;

namespace Bamboo.Base.EntityFrameworkCore
{
    public static class BaseModelBuilderExtension_Country
    {
        public static ModelBuilder ConfigureCoutryEntity(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasIndex(e => e.Id).IsUnique();
                entity.HasIndex(e => e.TenantId);

                //entity.Property(e => e.Status).HasDefaultValue(0);
                entity.Property(e => e.IsDeleted).HasDefaultValue(false);
                entity.Property(e => e.IsActive).HasDefaultValue(true);
#if HAS_DB_POSTGRESQL
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Id).HasDefaultValueSql("next_uuid()");
                //entity.Property(e => e.Sequence).ValueGeneratedOnAdd();
                entity.Property(e => e.ExtraProperties).HasColumnType("jsonb");
#endif

#if HAS_DB_MSSQL
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Id).HasDefaultValueSql("NEWSEQUENTIALID()");
#endif
            });
            return modelBuilder;
        }
    }
 }
