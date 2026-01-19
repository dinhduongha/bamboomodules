using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore;

public static partial class ModelBuilderExtensions
{
    public static void ConfigureDmsOutletVisit(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DmsOutletVisit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dms_outlet_visit_pkey");

            entity.ToTable("dms_outlet_visit");

            entity.HasIndex(e => e.TenantId);
            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuidv7()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");
            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");

            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.VisitDateTime).HasColumnName("visit_date_time");
            entity.Property(e => e.CheckInLatitude).HasColumnName("check_in_latitude");
            entity.Property(e => e.CheckInLongitude).HasColumnName("check_in_longitude");
            entity.Property(e => e.CheckInAccuracy).HasColumnName("check_in_accuracy");
            entity.Property(e => e.GeoStatus).HasColumnName("geo_status");
            entity.Property(e => e.DurationMinutes).HasColumnName("duration_minutes");
            entity.Property(e => e.CheckOutLatitude).HasColumnName("check_out_latitude");
            entity.Property(e => e.CheckOutLongitude).HasColumnName("check_out_longitude");
            entity.Property(e => e.VisitStatus).HasColumnName("visit_status");
            entity.Property(e => e.PhotosJson).HasColumnName("photos_json");
            entity.Property(e => e.OrderCreated).HasColumnName("order_created");
            entity.Property(e => e.NoSaleReasonId).HasColumnName("no_sale_reason_id");

            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");

            entity.Property(e => e.CreatorId).HasColumnName("create_uid");

            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");

            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.ResPartner)
                .WithMany()
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("dms_outlet_visit_res_partner_id_fkey");

            entity.HasOne(d => d.User)
                .WithMany()
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("dms_outlet_visit_user_id_fkey");

            entity.TryConfigureExtraProperties();
            entity.TryConfigureObjectExtensions();
            entity.TryConfigureConcurrencyStamp();
        });
    }
}