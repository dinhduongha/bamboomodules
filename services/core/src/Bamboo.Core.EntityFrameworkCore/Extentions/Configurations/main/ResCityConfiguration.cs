using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureResCity(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ResCity>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("res_city_pkey");

                        entity.ToTable("res_city");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");
                        entity.Property(e => e.CountryId).HasColumnName("country_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Name)
                            .HasColumnType("jsonb")
                            .HasColumnName("name");
                        entity.Property(e => e.StateId).HasColumnName("state_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");
                        entity.Property(e => e.Zipcode).HasColumnName("zipcode");

                        // entity.HasOne(d => d.Country).WithMany(p => p.ResCity) .HasForeignKey(d => d.CountryId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("res_city_country_id_fkey");
                        entity.HasOne(d => d.Country).WithMany()
                            .HasForeignKey(d => d.CountryId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("res_city_country_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ResCityCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_city_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_city_create_uid_fkey");

                        // entity.HasOne(d => d.State).WithMany(p => p.ResCity) .HasForeignKey(d => d.StateId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_city_state_id_fkey");
                        entity.HasOne(d => d.State).WithMany()
                            .HasForeignKey(d => d.StateId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_city_state_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ResCityWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_city_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_city_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}