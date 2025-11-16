using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigurePurchaseOrder(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<PurchaseOrder>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("purchase_order_pkey");

                        entity.ToTable("purchase_order");

                        entity.HasIndex(e => e.TenantId, "purchase_order__company_id_index");

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.DateApprove, "purchase_order__date_approve_index");

                        entity.HasIndex(e => e.DateOrder, "purchase_order__date_order_index");

                        entity.HasIndex(e => e.DatePlanned, "purchase_order__date_planned_index");

                        entity.HasIndex(e => e.Name, "purchase_order__name_index")
                            .HasMethod("gin")
                            .HasOperators(new[] { "gin_trgm_ops" });

                        entity.HasIndex(e => e.Priority, "purchase_order__priority_index");

                        entity.HasIndex(e => e.State, "purchase_order__state_index");

                        entity.HasIndex(e => e.UserId, "purchase_order__user_id_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AccessToken).HasColumnName("access_token");
                        entity.Property(e => e.AmountTax).HasColumnName("amount_tax");
                        entity.Property(e => e.AmountTotal).HasColumnName("amount_total");
                        entity.Property(e => e.AmountTotalCc).HasColumnName("amount_total_cc");
                        entity.Property(e => e.AmountUntaxed).HasColumnName("amount_untaxed");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
                        entity.Property(e => e.CurrencyRate).HasColumnName("currency_rate");
                        entity.Property(e => e.DateApprove)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("date_approve");
                        entity.Property(e => e.DateCalendarStart)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("date_calendar_start");
                        entity.Property(e => e.DateOrder)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("date_order");
                        entity.Property(e => e.DatePlanned)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("date_planned");
                        entity.Property(e => e.DestAddressId).HasColumnName("dest_address_id");
                        entity.Property(e => e.EffectiveDate)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("effective_date");
                        entity.Property(e => e.FiscalPositionId).HasColumnName("fiscal_position_id");
                        entity.Property(e => e.GroupId).HasColumnName("group_id");
                        entity.Property(e => e.IncotermId).HasColumnName("incoterm_id");
                        entity.Property(e => e.IncotermLocation).HasColumnName("incoterm_location");
                        entity.Property(e => e.InvoiceCount).HasColumnName("invoice_count");
                        entity.Property(e => e.InvoiceStatus).HasColumnName("invoice_status");
                        entity.Property(e => e.MailReceptionConfirmed).HasColumnName("mail_reception_confirmed");
                        entity.Property(e => e.MailReceptionDeclined).HasColumnName("mail_reception_declined");
                        entity.Property(e => e.MailReminderConfirmed).HasColumnName("mail_reminder_confirmed");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.Notes).HasColumnName("notes");
                        entity.Property(e => e.Origin).HasColumnName("origin");
                        entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                        entity.Property(e => e.PartnerRef).HasColumnName("partner_ref");
                        entity.Property(e => e.PaymentTermId).HasColumnName("payment_term_id");
                        entity.Property(e => e.PickingTypeId).HasColumnName("picking_type_id");
                        entity.Property(e => e.Priority).HasColumnName("priority");
                        entity.Property(e => e.ProjectId).HasColumnName("project_id");
                        entity.Property(e => e.PurchaseGroupId).HasColumnName("purchase_group_id");
                        entity.Property(e => e.ReceiptStatus).HasColumnName("receipt_status");
                        entity.Property(e => e.ReportGrids).HasColumnName("report_grids");
                        entity.Property(e => e.RequisitionId).HasColumnName("requisition_id");
                        entity.Property(e => e.State).HasColumnName("state");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.PurchaseOrder) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("purchase_order_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("purchase_order_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.PurchaseOrderCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("purchase_order_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("purchase_order_create_uid_fkey");

                        // entity.HasOne(d => d.Currency).WithMany(p => p.PurchaseOrder) .HasForeignKey(d => d.CurrencyId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("purchase_order_currency_id_fkey");
                        entity.HasOne(d => d.Currency).WithMany()
                            .HasForeignKey(d => d.CurrencyId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("purchase_order_currency_id_fkey");

                        // entity.HasOne(d => d.DestAddress).WithMany(p => p.PurchaseOrderDestAddress) .HasForeignKey(d => d.DestAddressId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("purchase_order_dest_address_id_fkey");
                        entity.HasOne(d => d.DestAddress).WithMany()
                            .HasForeignKey(d => d.DestAddressId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("purchase_order_dest_address_id_fkey");

                        entity.HasOne(d => d.FiscalPosition).WithMany(p => p.PurchaseOrder)
                            .HasForeignKey(d => d.FiscalPositionId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("purchase_order_fiscal_position_id_fkey");

                        entity.HasOne(d => d.Group).WithMany(p => p.PurchaseOrder)
                            .HasForeignKey(d => d.GroupId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("purchase_order_group_id_fkey");

                        entity.HasOne(d => d.Incoterm).WithMany(p => p.PurchaseOrder)
                            .HasForeignKey(d => d.IncotermId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("purchase_order_incoterm_id_fkey");

                        // entity.HasOne(d => d.Partner).WithMany(p => p.PurchaseOrderPartner) .HasForeignKey(d => d.PartnerId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("purchase_order_partner_id_fkey");
                        entity.HasOne(d => d.Partner).WithMany()
                            .HasForeignKey(d => d.PartnerId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("purchase_order_partner_id_fkey");

                        entity.HasOne(d => d.PaymentTerm).WithMany(p => p.PurchaseOrder)
                            .HasForeignKey(d => d.PaymentTermId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("purchase_order_payment_term_id_fkey");

                        entity.HasOne(d => d.PickingType).WithMany(p => p.PurchaseOrder)
                            .HasForeignKey(d => d.PickingTypeId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("purchase_order_picking_type_id_fkey");

                        entity.HasOne(d => d.Project).WithMany(p => p.PurchaseOrder)
                            .HasForeignKey(d => d.ProjectId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("purchase_order_project_id_fkey");

                        entity.HasOne(d => d.PurchaseGroup).WithMany(p => p.PurchaseOrder)
                            .HasForeignKey(d => d.PurchaseGroupId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("purchase_order_purchase_group_id_fkey");

                        entity.HasOne(d => d.Requisition).WithMany(p => p.PurchaseOrder)
                            .HasForeignKey(d => d.RequisitionId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("purchase_order_requisition_id_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.PurchaseOrderUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("purchase_order_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("purchase_order_user_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.PurchaseOrderWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("purchase_order_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("purchase_order_write_uid_fkey");

                        // entity.HasMany(d => d.AccountMove).WithMany(p => p.PurchaseOrder)
                        entity.HasMany(d => d.AccountMove).WithMany(p => p.PurchaseOrder)
                            .UsingEntity<Dictionary<string, object>>(
                                "AccountMovePurchaseOrderRel",
                                r => r.HasOne<AccountMove>().WithMany()
                                    .HasForeignKey("AccountMoveId")
                                    .HasConstraintName("account_move_purchase_order_rel_account_move_id_fkey"),
                                l => l.HasOne<PurchaseOrder>().WithMany()
                                    .HasForeignKey("PurchaseOrderId")
                                    .HasConstraintName("account_move_purchase_order_rel_purchase_order_id_fkey"),
                                j =>
                                {
                                    j.HasKey("PurchaseOrderId", "AccountMoveId").HasName("account_move_purchase_order_rel_pkey");
                                    j.ToTable("account_move_purchase_order_rel");
                                    j.HasIndex(new[] { "AccountMoveId", "PurchaseOrderId" }, "account_move_purchase_order_r_account_move_id_purchase_orde_idx");
                                    j.IndexerProperty<Guid>("PurchaseOrderId").HasColumnName("purchase_order_id");
                                    j.IndexerProperty<Guid>("AccountMoveId").HasColumnName("account_move_id");
                                });

                        // entity.HasMany(d => d.StockPicking).WithMany(p => p.PurchaseOrder)
                        entity.HasMany(d => d.StockPicking).WithMany(p => p.PurchaseOrder)
                            .UsingEntity<Dictionary<string, object>>(
                                "PurchaseOrderStockPickingRel",
                                r => r.HasOne<StockPicking>().WithMany()
                                    .HasForeignKey("StockPickingId")
                                    .HasConstraintName("purchase_order_stock_picking_rel_stock_picking_id_fkey"),
                                l => l.HasOne<PurchaseOrder>().WithMany()
                                    .HasForeignKey("PurchaseOrderId")
                                    .HasConstraintName("purchase_order_stock_picking_rel_purchase_order_id_fkey"),
                                j =>
                                {
                                    j.HasKey("PurchaseOrderId", "StockPickingId").HasName("purchase_order_stock_picking_rel_pkey");
                                    j.ToTable("purchase_order_stock_picking_rel");
                                    j.HasIndex(new[] { "StockPickingId", "PurchaseOrderId" }, "purchase_order_stock_picking__stock_picking_id_purchase_ord_idx");
                                    j.IndexerProperty<Guid>("PurchaseOrderId").HasColumnName("purchase_order_id");
                                    j.IndexerProperty<Guid>("StockPickingId").HasColumnName("stock_picking_id");
                                });

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}