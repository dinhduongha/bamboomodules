using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureIrProfile(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<IrProfile>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("ir_profile_pkey");

                        entity.ToTable("ir_profile");

                        entity.HasIndex(e => e.Session, "ir_profile__session_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");
                        entity.Property(e => e.CpuDuration).HasColumnName("cpu_duration");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.Duration).HasColumnName("duration");
                        entity.Property(e => e.EntryCount).HasColumnName("entry_count");
                        entity.Property(e => e.InitStackTrace).HasColumnName("init_stack_trace");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.Others).HasColumnName("others");
                        entity.Property(e => e.Qweb).HasColumnName("qweb");
                        entity.Property(e => e.Session).HasColumnName("session");
                        entity.Property(e => e.Sql).HasColumnName("sql");
                        entity.Property(e => e.SqlCount).HasColumnName("sql_count");
                        entity.Property(e => e.TracesAsync).HasColumnName("traces_async");
                        entity.Property(e => e.TracesSync).HasColumnName("traces_sync");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}