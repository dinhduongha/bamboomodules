using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureRestaurantOrderCourse(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<RestaurantOrderCourse>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("restaurant_order_course_pkey");

                        entity.ToTable("restaurant_order_course");

                        entity.HasIndex(e => e.OrderId, "restaurant_order_course__order_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Fired).HasColumnName("fired");
                        entity.Property(e => e.FiredDate)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("fired_date");
                        entity.Property(e => e.Index).HasColumnName("index");
                        entity.Property(e => e.OrderId).HasColumnName("order_id");
                        entity.Property(e => e.Uuid).HasColumnName("uuid");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.RestaurantOrderCourseCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("restaurant_order_course_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("restaurant_order_course_create_uid_fkey");

                        entity.HasOne(d => d.Order).WithMany(p => p.RestaurantOrderCourse)
                            .HasForeignKey(d => d.OrderId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("restaurant_order_course_order_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.RestaurantOrderCourseWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("restaurant_order_course_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("restaurant_order_course_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}