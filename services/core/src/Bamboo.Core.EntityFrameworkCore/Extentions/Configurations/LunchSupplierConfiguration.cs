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
        public static void ConfigureLunchSupplier(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LunchSupplier>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("lunch_supplier_pkey");

                entity.ToTable("lunch_supplier");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.AutomaticEmailTime).HasColumnName("automatic_email_time");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.CronId).HasColumnName("cron_id");
                entity.Property(e => e.Delivery).HasColumnName("delivery");
                entity.Property(e => e.Fri).HasColumnName("fri");
                entity.Property(e => e.MessageMainAttachmentId).HasColumnName("message_main_attachment_id");
                entity.Property(e => e.Moment).HasColumnName("moment");
                entity.Property(e => e.Mon).HasColumnName("mon");
                entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                entity.Property(e => e.RecurrencyEndDate).HasColumnName("recurrency_end_date");
                entity.Property(e => e.ResponsibleId).HasColumnName("responsible_id");
                entity.Property(e => e.Sat).HasColumnName("sat");
                entity.Property(e => e.SendBy).HasColumnName("send_by");
                entity.Property(e => e.Sun).HasColumnName("sun");
                entity.Property(e => e.Thu).HasColumnName("thu");
                entity.Property(e => e.ToppingLabel1).HasColumnName("topping_label_1");
                entity.Property(e => e.ToppingLabel2).HasColumnName("topping_label_2");
                entity.Property(e => e.ToppingLabel3).HasColumnName("topping_label_3");
                entity.Property(e => e.ToppingQuantity1).HasColumnName("topping_quantity_1");
                entity.Property(e => e.ToppingQuantity2).HasColumnName("topping_quantity_2");
                entity.Property(e => e.ToppingQuantity3).HasColumnName("topping_quantity_3");
                entity.Property(e => e.Tue).HasColumnName("tue");
                entity.Property(e => e.Tz).HasColumnName("tz");
                entity.Property(e => e.Wed).HasColumnName("wed");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("lunch_supplier_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("lunch_supplier_create_uid_fkey");

                entity.HasOne(d => d.Cron).WithMany(p => p.LunchSuppliers)
                    .HasForeignKey(d => d.CronId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("lunch_supplier_cron_id_fkey");

                entity.HasOne(d => d.MessageMainAttachment).WithMany(p => p.LunchSuppliers)
                    .HasForeignKey(d => d.MessageMainAttachmentId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("lunch_supplier_message_main_attachment_id_fkey");

                entity.HasOne<ResPartner>().WithMany()
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("lunch_supplier_partner_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.ResponsibleId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("lunch_supplier_responsible_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("lunch_supplier_write_uid_fkey");

                //entity.HasMany(d => d.LunchLocations).WithMany(p => p.LunchSuppliers)
                entity.HasMany<LunchLocation>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "LunchLocationLunchSupplierRel",
                        r => r.HasOne<LunchLocation>().WithMany()
                            .HasForeignKey("LunchLocationId")
                            .HasConstraintName("lunch_location_lunch_supplier_rel_lunch_location_id_fkey"),
                        l => l.HasOne<LunchSupplier>().WithMany()
                            .HasForeignKey("LunchSupplierId")
                            .HasConstraintName("lunch_location_lunch_supplier_rel_lunch_supplier_id_fkey"),
                        j =>
                        {
                            j.HasKey("LunchSupplierId", "LunchLocationId").HasName("lunch_location_lunch_supplier_rel_pkey");
                            j.ToTable("lunch_location_lunch_supplier_rel");
                            j.HasIndex(new[] { "LunchLocationId", "LunchSupplierId" }, "lunch_location_lunch_supplier_lunch_location_id_lunch_suppl_idx");
                        });
            });
        }
    }
}