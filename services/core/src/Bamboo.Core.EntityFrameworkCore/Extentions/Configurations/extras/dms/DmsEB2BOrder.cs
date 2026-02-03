using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore;

public static partial class ModelBuilderExtensions
{
    public static void ConfigureDmsEB2BOrder(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DmsEB2BOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dms_eb2b_order_pkey");

            entity.ToTable("dms_eb2b_order");

            entity.HasIndex(e => e.TenantId);
            entity.HasIndex(e => e.OrganizationUnitId);

            entity.Property(e => e.Id)
                .HasDefaultValueSql("uuidv7()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");
            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");

            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.Channel).HasColumnName("channel");
            entity.Property(e => e.OrderSourceId).HasColumnName("order_source_id");
            entity.Property(e => e.OrderContent);
            entity.Property(e => e.OrderStatus).HasColumnName("order_status");
            entity.Property(e => e.ConvertedToSaleOrderId).HasColumnName("converted_to_sale_order_id");
            entity.Property(e => e.Timestamp).HasColumnName("timestamp");

            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");

            entity.Property(e => e.CreatorId).HasColumnName("create_uid");

            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");

            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.Partner)
                .WithMany()
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("dms_eb2b_order_res_partner_id_fkey");

            entity.TryConfigureExtraProperties();
            entity.TryConfigureObjectExtensions();
            entity.TryConfigureConcurrencyStamp();
        });
    }
}