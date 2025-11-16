using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureResCountryGroup(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ResCountryGroup>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("res_country_group_pkey");

                        entity.ToTable("res_country_group");

                        entity.HasIndex(e => e.Code, "res_country_group_check_code_uniq").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");
                        entity.Property(e => e.Code).HasColumnName("code");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ResCountryGroupCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_country_group_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_country_group_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ResCountryGroupWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_country_group_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_country_group_write_uid_fkey");

                        // entity.HasMany(d => d.ResCountryState).WithMany(p => p.ResCountryGroup)
                        entity.HasMany(d => d.ResCountryState).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "ResCountryGroupResCountryStateRel",
                                r => r.HasOne<ResCountryState>().WithMany()
                                    .HasForeignKey("ResCountryStateId")
                                    .HasConstraintName("res_country_group_res_country_state_r_res_country_state_id_fkey"),
                                l => l.HasOne<ResCountryGroup>().WithMany()
                                    .HasForeignKey("ResCountryGroupId")
                                    .HasConstraintName("res_country_group_res_country_state_r_res_country_group_id_fkey"),
                                j =>
                                {
                                    j.HasKey("ResCountryGroupId", "ResCountryStateId").HasName("res_country_group_res_country_state_rel_pkey");
                                    j.ToTable("res_country_group_res_country_state_rel");
                                    j.HasIndex(new[] { "ResCountryStateId", "ResCountryGroupId" }, "res_country_group_res_country_res_country_state_id_res_coun_idx");
                                    j.IndexerProperty<Guid>("ResCountryGroupId").HasColumnName("res_country_group_id");
                                    j.IndexerProperty<Guid>("ResCountryStateId").HasColumnName("res_country_state_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}