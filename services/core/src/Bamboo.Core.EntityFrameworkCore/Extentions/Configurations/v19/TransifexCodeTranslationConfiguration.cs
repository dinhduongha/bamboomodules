using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureTransifexCodeTranslation(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<TransifexCodeTranslation>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("transifex_code_translation_pkey");

                        entity.ToTable("transifex_code_translation");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Lang).HasColumnName("lang");
                        entity.Property(e => e.Module).HasColumnName("module");
                        entity.Property(e => e.Source).HasColumnName("source");
                        entity.Property(e => e.Value).HasColumnName("value");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}