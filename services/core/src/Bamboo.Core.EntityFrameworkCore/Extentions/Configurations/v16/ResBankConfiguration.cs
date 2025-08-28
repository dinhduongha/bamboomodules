using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureResBank(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ResBank>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("res_bank_pkey");

                        entity.ToTable("res_bank");

                        entity.HasIndex(e => e.Bic, "res_bank__bic_index");

                        entity.Property(e => e.Id)
                            .ValueGeneratedNever()
                            .HasColumnName("id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.Bic).HasColumnName("bic");
                        entity.Property(e => e.City).HasColumnName("city");
                        entity.Property(e => e.Country).HasColumnName("country");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Email).HasColumnName("email");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.Phone).HasColumnName("phone");
                        entity.Property(e => e.State).HasColumnName("state");
                        entity.Property(e => e.Street).HasColumnName("street");
                        entity.Property(e => e.Street2).HasColumnName("street2");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");
                        entity.Property(e => e.Zip).HasColumnName("zip");

                        // entity.HasOne(d => d.CountryNavigation).WithMany(p => p.ResBank) .HasForeignKey(d => d.Country) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_bank_country_fkey");
                        entity.HasOne(d => d.CountryNavigation).WithMany()
                            .HasForeignKey(d => d.Country)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_bank_country_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ResBankCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_bank_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_bank_create_uid_fkey");

                        // entity.HasOne(d => d.StateNavigation).WithMany(p => p.ResBank) .HasForeignKey(d => d.State) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_bank_state_fkey");
                        entity.HasOne(d => d.StateNavigation).WithMany()
                            .HasForeignKey(d => d.State)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_bank_state_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ResBankWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_bank_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_bank_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}