using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureLoyaltyGenerateWizard(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<LoyaltyGenerateWizard>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("loyalty_generate_wizard_pkey");

                        entity.ToTable("loyalty_generate_wizard");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CouponQty).HasColumnName("coupon_qty");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Description).HasColumnName("description");
                        entity.Property(e => e.Mode).HasColumnName("mode");
                        entity.Property(e => e.PointsGranted).HasColumnName("points_granted");
                        entity.Property(e => e.ProgramId).HasColumnName("program_id");
                        entity.Property(e => e.ValidUntil).HasColumnName("valid_until");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.LoyaltyGenerateWizardCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("loyalty_generate_wizard_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("loyalty_generate_wizard_create_uid_fkey");

                        entity.HasOne(d => d.Program).WithMany(p => p.LoyaltyGenerateWizard)
                            .HasForeignKey(d => d.ProgramId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("loyalty_generate_wizard_program_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.LoyaltyGenerateWizardWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("loyalty_generate_wizard_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("loyalty_generate_wizard_write_uid_fkey");

                        // entity.HasMany(d => d.ResPartner).WithMany(p => p.LoyaltyGenerateWizard)
                        entity.HasMany(d => d.ResPartner).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "LoyaltyGenerateWizardResPartnerRel",
                                r => r.HasOne<ResPartner>().WithMany()
                                    .HasForeignKey("ResPartnerId")
                                    .HasConstraintName("loyalty_generate_wizard_res_partner_rel_res_partner_id_fkey"),
                                l => l.HasOne<LoyaltyGenerateWizard>().WithMany()
                                    .HasForeignKey("LoyaltyGenerateWizardId")
                                    .HasConstraintName("loyalty_generate_wizard_res_par_loyalty_generate_wizard_id_fkey"),
                                j =>
                                {
                                    j.HasKey("LoyaltyGenerateWizardId", "ResPartnerId").HasName("loyalty_generate_wizard_res_partner_rel_pkey");
                                    j.ToTable("loyalty_generate_wizard_res_partner_rel");
                                    j.HasIndex(new[] { "ResPartnerId", "LoyaltyGenerateWizardId" }, "loyalty_generate_wizard_res_p_res_partner_id_loyalty_genera_idx");
                                    j.IndexerProperty<Guid>("LoyaltyGenerateWizardId").HasColumnName("loyalty_generate_wizard_id");
                                    j.IndexerProperty<Guid>("ResPartnerId").HasColumnName("res_partner_id");
                                });

                        // entity.HasMany(d => d.ResPartnerCategory).WithMany(p => p.LoyaltyGenerateWizard)
                        entity.HasMany(d => d.ResPartnerCategory).WithMany(p => p.LoyaltyGenerateWizard)
                            .UsingEntity<Dictionary<string, object>>(
                                "LoyaltyGenerateWizardResPartnerCategoryRel",
                                r => r.HasOne<ResPartnerCategory>().WithMany()
                                    .HasForeignKey("ResPartnerCategoryId")
                                    .HasConstraintName("loyalty_generate_wizard_res_partne_res_partner_category_id_fkey"),
                                l => l.HasOne<LoyaltyGenerateWizard>().WithMany()
                                    .HasForeignKey("LoyaltyGenerateWizardId")
                                    .HasConstraintName("loyalty_generate_wizard_res_pa_loyalty_generate_wizard_id_fkey1"),
                                j =>
                                {
                                    j.HasKey("LoyaltyGenerateWizardId", "ResPartnerCategoryId").HasName("loyalty_generate_wizard_res_partner_category_rel_pkey");
                                    j.ToTable("loyalty_generate_wizard_res_partner_category_rel");
                                    j.HasIndex(new[] { "ResPartnerCategoryId", "LoyaltyGenerateWizardId" }, "loyalty_generate_wizard_res_p_res_partner_category_id_loyal_idx");
                                    j.IndexerProperty<Guid>("LoyaltyGenerateWizardId").HasColumnName("loyalty_generate_wizard_id");
                                    j.IndexerProperty<Guid>("ResPartnerCategoryId").HasColumnName("res_partner_category_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}