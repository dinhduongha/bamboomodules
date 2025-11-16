using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureLoyaltyProgram(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<LoyaltyProgram>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("loyalty_program_pkey");

                        entity.ToTable("loyalty_program");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.WebsiteId, "loyalty_program__website_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.AppliesOn).HasColumnName("applies_on");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
                        entity.Property(e => e.DateFrom).HasColumnName("date_from");
                        entity.Property(e => e.DateTo).HasColumnName("date_to");
                        entity.Property(e => e.EcommerceOk).HasColumnName("ecommerce_ok");
                        entity.Property(e => e.LimitUsage).HasColumnName("limit_usage");
                        entity.Property(e => e.MaxUsage).HasColumnName("max_usage");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.PortalPointName)
                            .HasColumnType("jsonb")
                            .HasColumnName("portal_point_name");
                        entity.Property(e => e.PortalVisible).HasColumnName("portal_visible");
                        entity.Property(e => e.PosOk).HasColumnName("pos_ok");
                        entity.Property(e => e.ProgramType).HasColumnName("program_type");
                        entity.Property(e => e.SaleOk).HasColumnName("sale_ok");
                        entity.Property(e => e.Sequence).HasColumnName("sequence");
                        entity.Property(e => e.Trigger).HasColumnName("trigger");
                        entity.Property(e => e.WebsiteId).HasColumnName("website_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.LoyaltyProgram) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("loyalty_program_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("loyalty_program_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.LoyaltyProgramCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("loyalty_program_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("loyalty_program_create_uid_fkey");

                        // entity.HasOne(d => d.Currency).WithMany(p => p.LoyaltyProgram) .HasForeignKey(d => d.CurrencyId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("loyalty_program_currency_id_fkey");
                        entity.HasOne(d => d.Currency).WithMany()
                            .HasForeignKey(d => d.CurrencyId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("loyalty_program_currency_id_fkey");

                        // entity.HasOne(d => d.Website).WithMany(p => p.LoyaltyProgram) .HasForeignKey(d => d.WebsiteId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("loyalty_program_website_id_fkey");
                        entity.HasOne(d => d.Website).WithMany()
                            .HasForeignKey(d => d.WebsiteId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("loyalty_program_website_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.LoyaltyProgramWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("loyalty_program_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("loyalty_program_write_uid_fkey");

                        // entity.HasMany(d => d.PosConfig).WithMany(p => p.LoyaltyProgram)
                        entity.HasMany(d => d.PosConfig).WithMany(p => p.LoyaltyProgram)
                            .UsingEntity<Dictionary<string, object>>(
                                "LoyaltyProgramPosConfigRel",
                                r => r.HasOne<PosConfig>().WithMany()
                                    .HasForeignKey("PosConfigId")
                                    .HasConstraintName("loyalty_program_pos_config_rel_pos_config_id_fkey"),
                                l => l.HasOne<LoyaltyProgram>().WithMany()
                                    .HasForeignKey("LoyaltyProgramId")
                                    .HasConstraintName("loyalty_program_pos_config_rel_loyalty_program_id_fkey"),
                                j =>
                                {
                                    j.HasKey("LoyaltyProgramId", "PosConfigId").HasName("loyalty_program_pos_config_rel_pkey");
                                    j.ToTable("loyalty_program_pos_config_rel");
                                    j.HasIndex(new[] { "PosConfigId", "LoyaltyProgramId" }, "loyalty_program_pos_config_re_pos_config_id_loyalty_program_idx");
                                    j.IndexerProperty<Guid>("LoyaltyProgramId").HasColumnName("loyalty_program_id");
                                    j.IndexerProperty<Guid>("PosConfigId").HasColumnName("pos_config_id");
                                });

                        // entity.HasMany(d => d.ProductPricelist).WithMany(p => p.LoyaltyProgram)
                        entity.HasMany(d => d.ProductPricelist).WithMany(p => p.LoyaltyProgram)
                            .UsingEntity<Dictionary<string, object>>(
                                "LoyaltyProgramProductPricelistRel",
                                r => r.HasOne<ProductPricelist>().WithMany()
                                    .HasForeignKey("ProductPricelistId")
                                    .HasConstraintName("loyalty_program_product_pricelist_rel_product_pricelist_id_fkey"),
                                l => l.HasOne<LoyaltyProgram>().WithMany()
                                    .HasForeignKey("LoyaltyProgramId")
                                    .HasConstraintName("loyalty_program_product_pricelist_rel_loyalty_program_id_fkey"),
                                j =>
                                {
                                    j.HasKey("LoyaltyProgramId", "ProductPricelistId").HasName("loyalty_program_product_pricelist_rel_pkey");
                                    j.ToTable("loyalty_program_product_pricelist_rel");
                                    j.HasIndex(new[] { "ProductPricelistId", "LoyaltyProgramId" }, "loyalty_program_product_price_product_pricelist_id_loyalty__idx");
                                    j.IndexerProperty<Guid>("LoyaltyProgramId").HasColumnName("loyalty_program_id");
                                    j.IndexerProperty<Guid>("ProductPricelistId").HasColumnName("product_pricelist_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}