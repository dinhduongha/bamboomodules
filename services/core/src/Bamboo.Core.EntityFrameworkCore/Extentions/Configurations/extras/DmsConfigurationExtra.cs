using Microsoft.EntityFrameworkCore;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureResUserExtra(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResUsers>(entity =>
            {
                entity.HasIndex(e => e.DefaultSalesmanLocationId);
                entity.HasIndex(e => e.CurrentVehicleId);

                entity.Property(e => e.DefaultSalesmanLocationId).HasColumnName("default_salesman_location_id");
                entity.Property(e => e.IsSalesman).HasColumnName("is_salesman").HasDefaultValue(false);
                entity.Property(e => e.IsDriver).HasColumnName("is_driver").HasDefaultValue(false);
                entity.Property(e => e.CurrentVehicleId).HasColumnName("current_vehicle_id");
                entity.Property(e => e.ProvisionLocationId).HasColumnName("provision_location_id");
                entity.Property(e => e.TargetDailySales).HasColumnName("target_daily_sales");
                entity.Property(e => e.TargetMonthlyVisit).HasColumnName("target_monthly_visit");
                entity.Property(e => e.AchievementToday).HasColumnName("achievement_today");
                entity.Property(e => e.LastProvisionDate).HasColumnName("last_provision_date");
                entity.Property(e => e.VoiceNoteEnabled).HasColumnName("voice_note_enabled").HasDefaultValue(false);
                entity.Property(e => e.POSMDeploymentStatus).HasColumnName("posm_deployment_status");
                entity.Property(e => e.VMIEnabled).HasColumnName("vmi_enabled").HasDefaultValue(false);

                entity.HasOne(d => d.DefaultSalesmanLocation)
                    .WithMany()
                    .HasForeignKey(d => d.DefaultSalesmanLocationId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_users_default_salesman_location_id_fkey");

                entity.HasOne(d => d.CurrentVehicle)
                    .WithMany()
                    .HasForeignKey(d => d.CurrentVehicleId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_users_current_vehicle_id_fkey");
            });
        }
        public static void ConfigureProductExtra(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductProduct>(entity =>
            {
                entity.Property(e => e.VolumeM3).HasColumnName("volume_m3");
                entity.Property(e => e.WeightKg).HasColumnName("weight_kg");
                entity.Property(e => e.IsDeliverable).HasColumnName("is_deliverable").HasDefaultValue(true);
            });
        }
        public static void ConfigureStockLocationExtra(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockLocation>(entity =>
            {
                entity.HasIndex(e => e.VehicleId);
                entity.HasIndex(e => e.UserId);
                entity.HasIndex(e => e.PartnerId);

                entity.Property(e => e.LocationType).HasColumnName("location_type");
                entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                entity.Property(e => e.GeofenceRadiusMeters).HasColumnName("geofence_radius_meters");
                entity.Property(e => e.GeofencePolygonJson).HasColumnName("geofence_polygon_json");
                entity.Property(e => e.LastInventoryCheckDate).HasColumnName("last_inventory_check_date");

                entity.HasOne(d => d.Vehicle)
                    .WithMany()
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_location_vehicle_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_location_user_id_fkey");

                entity.HasOne(d => d.Partner)
                    .WithMany()
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_location_partner_id_fkey");
            });
        }
        public static void ConfigureStockPickingExtra(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockPicking>(entity =>
            {
                entity.HasIndex(e => e.DmsRouteId);
                entity.HasIndex(e => e.VehicleId);

                entity.Property(e => e.DmsRouteId).HasColumnName("dms_route_id");
                entity.Property(e => e.VehicleId).HasColumnName("vehicle_id");
                entity.Property(e => e.PlannedStartTime).HasColumnName("planned_start_time");
                entity.Property(e => e.ActualDeliveryTime).HasColumnName("actual_delivery_time");
                entity.Property(e => e.DeliveryStatus).HasColumnName("delivery_status");
                entity.Property(e => e.VMIOrderFlag).HasColumnName("vmi_order_flag").HasDefaultValue(false);
                entity.Property(e => e.PromotionAppliedJson).HasColumnName("promotion_applied_json");

                entity.HasOne(d => d.DmsRoute)
                    .WithMany()
                    .HasForeignKey(d => d.DmsRouteId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_picking_dms_route_id_fkey");

                entity.HasOne(d => d.Vehicle)
                    .WithMany()
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("stock_picking_vehicle_id_fkey");
            });
        }
        public static void ConfigureStockMoveExtra(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockMove>(entity =>
            {
                entity.Property(e => e.SequenceInRoute).HasColumnName("sequence_in_route");
            });
        }
        public static void ConfigureSaleOrderExtra(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SaleOrder>(entity =>
            {
                entity.Property(e => e.PreferredDeliveryTimeSlot).HasColumnName("preferred_delivery_time_slot");
                entity.Property(e => e.DeliveryPriority).HasColumnName("delivery_priority");
            });
        }
        public static void ConfigureResPartnerExtra(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ResPartner>(entity =>
            {
                entity.HasIndex(e => e.DeliveryZoneId);

                entity.Property(e => e.ShopCode).HasColumnName("shop_code");
                entity.Property(e => e.ShopType).HasColumnName("shop_type");
                entity.Property(e => e.ChannelType).HasColumnName("channel_type");
                entity.Property(e => e.GeoLatitude).HasColumnName("geo_latitude");
                entity.Property(e => e.GeoLongitude).HasColumnName("geo_longitude");
                entity.Property(e => e.VisitFrequencyDays).HasColumnName("visit_frequency_days");
                entity.Property(e => e.LastVisitDate).HasColumnName("last_visit_date");
                entity.Property(e => e.DeliveryZoneId).HasColumnName("delivery_zone_id");
                entity.Property(e => e.NoSaleReasonsJson).HasColumnName("no_sale_reasons_json");
                entity.Property(e => e.LastNoSaleDate).HasColumnName("last_no_sale_date");
                entity.Property(e => e.IsKeyAccount).HasColumnName("is_key_account").HasDefaultValue(false);
                entity.Property(e => e.LastInventoryQtyJson).HasColumnName("last_inventory_qty_json");
                entity.Property(e => e.POSMPhotosJson).HasColumnName("posm_photos_json");
                entity.Property(e => e.ExpiryDateTracking).HasColumnName("expiry_date_tracking").HasDefaultValue(false);
                entity.Property(e => e.LastPOSMCheckDate).HasColumnName("last_posm_check_date");
                entity.Property(e => e.GeofenceRadiusMeters).HasColumnName("geofence_radius_meters");

                entity.HasOne(d => d.DeliveryZone)
                    .WithMany()
                    .HasForeignKey(d => d.DeliveryZoneId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("res_partner_delivery_zone_id_fkey");
            });
        }
        public static void ConfigureFleetVehicleExtra(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FleetVehicle>(entity =>
            {
                entity.HasIndex(e => e.CurrentLocationId);
                entity.HasIndex(e => e.CurrentDriverId);

                entity.Property(e => e.MaxWeightKg).HasColumnName("max_weight_kg");
                entity.Property(e => e.MaxVolumeM3).HasColumnName("max_volume_m3");
                entity.Property(e => e.CurrentLocationId).HasColumnName("current_location_id");
                entity.Property(e => e.CurrentDriverId).HasColumnName("current_driver_id");
                entity.Property(e => e.IsActiveForDelivery).HasColumnName("is_active_for_delivery").HasDefaultValue(true);
                entity.Property(e => e.VehicleType).HasColumnName("vehicle_type");
                entity.Property(e => e.TrackDeviceId).HasColumnName("traccar_device_id");
                entity.Property(e => e.OdometerAutoUpdate).HasColumnName("odometer_auto_update").HasDefaultValue(false);
                entity.Property(e => e.LastGpsLatitude).HasColumnName("last_gps_latitude");
                entity.Property(e => e.LastGpsLongitude).HasColumnName("last_gps_longitude");
                entity.Property(e => e.LastGpsTime).HasColumnName("last_gps_time");
                entity.Property(e => e.RouteOptimizationScore).HasColumnName("route_optimization_score");
                entity.Property(e => e.POSMCapacity).HasColumnName("posm_capacity");

                entity.HasOne(d => d.CurrentLocation)
                    .WithMany()
                    .HasForeignKey(d => d.CurrentLocationId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fleet_vehicle_current_location_id_fkey");

                entity.HasOne(d => d.CurrentDriver)
                    .WithMany()
                    .HasForeignKey(d => d.CurrentDriverId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fleet_vehicle_current_driver_id_fkey");
            });
        }
    }
}