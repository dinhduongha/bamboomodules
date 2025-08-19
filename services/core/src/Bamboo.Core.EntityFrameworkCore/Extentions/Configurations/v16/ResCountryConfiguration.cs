using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Models;
// Cần thêm using đến namespace chứa entity của bạn ở đây
// Ví dụ: using YourProject.Entities;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureResCountry(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ResCountry>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("res_country_pkey");

            entity.ToTable("res_country");

            entity.HasIndex(e => e.Code, "res_country_code_uniq").IsUnique();

            entity.HasIndex(e => e.Name, "res_country_name_uniq").IsUnique();

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");
            entity.Property(e => e.AddressFormat).HasColumnName("address_format");
            entity.Property(e => e.AddressViewId).HasColumnName("address_view_id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
            entity.Property(e => e.EnforceCities).HasColumnName("enforce_cities");
            entity.Property(e => e.Name)
                .HasColumnType("jsonb")
                .HasColumnName("name");
            entity.Property(e => e.NamePosition).HasColumnName("name_position");
            entity.Property(e => e.PhoneCode).HasColumnName("phone_code");
            entity.Property(e => e.StateRequired).HasColumnName("state_required");
            entity.Property(e => e.VatLabel)
                .HasColumnType("jsonb")
                .HasColumnName("vat_label");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");
            entity.Property(e => e.ZipRequired).HasColumnName("zip_required");

            entity.HasOne(d => d.AddressView).WithMany(p => p.ResCountry)
                .HasForeignKey(d => d.AddressViewId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("res_country_address_view_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.ResCountryCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("res_country_create_uid_fkey");

            // entity.HasOne(d => d.Currency).WithMany(p => p.ResCountry)
            entity.HasOne(d => d.Currency).WithMany()
                .HasForeignKey(d => d.CurrencyId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("res_country_currency_id_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.ResCountryWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("res_country_write_uid_fkey");

            // entity.HasMany(d => d.ResCountryGroup).WithMany(p => p.ResCountry)
            entity.HasMany<ResCountryGroup>().WithMany()
                .UsingEntity<Dictionary<string, object>>(
                    "ResCountryResCountryGroupRel",
                    r => r.HasOne<ResCountryGroup>().WithMany()
                        .HasForeignKey("ResCountryGroupId")
                        .HasConstraintName("res_country_res_country_group_rel_res_country_group_id_fkey"),
                    l => l.HasOne<ResCountry>().WithMany()
                        .HasForeignKey("ResCountryId")
                        .HasConstraintName("res_country_res_country_group_rel_res_country_id_fkey"),
                    j =>
                    {
                        j.HasKey("ResCountryId", "ResCountryGroupId").HasName("res_country_res_country_group_rel_pkey");
                        j.ToTable("res_country_res_country_group_rel");
                        j.HasIndex(new[] { "ResCountryGroupId", "ResCountryId" }, "res_country_res_country_group_res_country_group_id_res_coun_idx");
                        j.IndexerProperty<Guid>("ResCountryId").HasColumnName("res_country_id");
                        j.IndexerProperty<Guid>("ResCountryGroupId").HasColumnName("res_country_group_id");
                    });
            });
        }
    }
}