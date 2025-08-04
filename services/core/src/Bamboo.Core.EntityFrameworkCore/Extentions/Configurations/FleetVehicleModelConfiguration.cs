using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
// TODO: Hãy chắc chắn rằng bạn đã thêm using cho namespace chứa Models của mình ở đây
// Ví dụ: using YourProject.Models;
using Bamboo.Core.Models;
namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureFleetVehicleModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FleetVehicleModel>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("fleet_vehicle_model_pkey");

                entity.ToTable("fleet_vehicle_model");

                entity.HasIndex(e => e.TenantId, "fleet_vehicle_model_company_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.BrandId).HasColumnName("brand_id");
                entity.Property(e => e.CategoryId).HasColumnName("category_id");
                entity.Property(e => e.Co2Standard).HasColumnName("co2_standard");
                entity.Property(e => e.Color).HasColumnName("color");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.DefaultCo2).HasColumnName("default_co2");
                entity.Property(e => e.DefaultFuelType).HasColumnName("default_fuel_type");
                entity.Property(e => e.Doors).HasColumnName("doors");
                entity.Property(e => e.ElectricAssistance).HasColumnName("electric_assistance");
                entity.Property(e => e.Horsepower).HasColumnName("horsepower");
                entity.Property(e => e.HorsepowerTax).HasColumnName("horsepower_tax");
                entity.Property(e => e.ModelYear).HasColumnName("model_year");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Power).HasColumnName("power");
                entity.Property(e => e.Seats).HasColumnName("seats");
                entity.Property(e => e.TrailerHook).HasColumnName("trailer_hook");
                entity.Property(e => e.Transmission).HasColumnName("transmission");
                entity.Property(e => e.VehicleType).HasColumnName("vehicle_type");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.Brand).WithMany(p => p.FleetVehicleModels)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fleet_vehicle_model_brand_id_fkey");

                entity.HasOne(d => d.Category).WithMany(p => p.FleetVehicleModels)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fleet_vehicle_model_category_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fleet_vehicle_model_create_uid_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fleet_vehicle_model_write_uid_fkey");

                //entity.HasMany(d => d.Partners).WithMany(p => p.Models)
                entity.HasMany<ResPartner>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "FleetVehicleModelVendor",
                        r => r.HasOne<ResPartner>().WithMany()
                            .HasForeignKey("PartnerId")
                            .HasConstraintName("fleet_vehicle_model_vendors_partner_id_fkey"),
                        l => l.HasOne<FleetVehicleModel>().WithMany()
                            .HasForeignKey("ModelId")
                            .HasConstraintName("fleet_vehicle_model_vendors_model_id_fkey"),
                        j =>
                        {
                            j.HasKey("ModelId", "PartnerId").HasName("fleet_vehicle_model_vendors_pkey");
                            j.ToTable("fleet_vehicle_model_vendors");
                            j.HasIndex(new[] { "PartnerId", "ModelId" }, "fleet_vehicle_model_vendors_partner_id_model_id_idx");
                        });
            });
        }
    }
}