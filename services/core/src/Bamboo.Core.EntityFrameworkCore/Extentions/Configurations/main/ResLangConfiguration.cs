using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureResLang(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ResLang>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("res_lang_pkey");

                        entity.ToTable("res_lang");

                        entity.HasIndex(e => e.Code, "res_lang_code_uniq").IsUnique();

                        entity.HasIndex(e => e.Name, "res_lang_name_uniq").IsUnique();

                        entity.HasIndex(e => e.UrlCode, "res_lang_url_code_uniq").IsUnique();

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.Code).HasColumnName("code");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.DateFormat).HasColumnName("date_format");
                        entity.Property(e => e.DecimalPoint).HasColumnName("decimal_point");
                        entity.Property(e => e.Direction).HasColumnName("direction");
                        entity.Property(e => e.Grouping).HasColumnName("grouping");
                        entity.Property(e => e.IsoCode).HasColumnName("iso_code");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.ThousandsSep).HasColumnName("thousands_sep");
                        entity.Property(e => e.TimeFormat).HasColumnName("time_format");
                        entity.Property(e => e.UrlCode).HasColumnName("url_code");
                        entity.Property(e => e.WeekStart).HasColumnName("week_start");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ResLangCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_lang_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_lang_create_uid_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ResLangWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("res_lang_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("res_lang_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}