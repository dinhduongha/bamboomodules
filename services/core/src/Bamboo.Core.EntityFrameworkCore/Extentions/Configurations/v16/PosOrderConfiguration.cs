using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigurePosOrder(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<PosOrder>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("pos_order_pkey");

                        entity.ToTable("pos_order");

                        entity.HasIndex(e => e.AccountMove, "pos_order__account_move_index").HasFilter("(account_move IS NOT NULL)");

                        entity.HasIndex(e => e.TenantId, "pos_order__company_id_index");

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.DateOrder, "pos_order__date_order_index");

                        entity.HasIndex(e => e.PartnerId, "pos_order__partner_id_index").HasFilter("(partner_id IS NOT NULL)");

                        entity.HasIndex(e => e.PosReference, "pos_order__pos_reference_index");

                        entity.HasIndex(e => e.SessionId, "pos_order__session_id_index");

                        entity.HasIndex(e => e.State, "pos_order__state_index");

                        entity.HasIndex(e => e.TableId, "pos_order__table_id_index").HasFilter("(table_id IS NOT NULL)");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("next_uuid()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AccessToken).HasColumnName("access_token");
                        entity.Property(e => e.AccountMove).HasColumnName("account_move");
                        entity.Property(e => e.AmountDifference).HasColumnName("amount_difference");
                        entity.Property(e => e.AmountPaid).HasColumnName("amount_paid");
                        entity.Property(e => e.AmountReturn).HasColumnName("amount_return");
                        entity.Property(e => e.AmountTax).HasColumnName("amount_tax");
                        entity.Property(e => e.AmountTotal).HasColumnName("amount_total");
                        entity.Property(e => e.Cashier).HasColumnName("cashier");

                        entity.Property(e => e.ConfigId).HasColumnName("config_id");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.CrmTeamId).HasColumnName("crm_team_id");
                        entity.Property(e => e.CurrencyRate).HasColumnName("currency_rate");
                        entity.Property(e => e.CustomerCount).HasColumnName("customer_count");
                        entity.Property(e => e.DateOrder)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("date_order");
                        entity.Property(e => e.Email).HasColumnName("email");
                        entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
                        entity.Property(e => e.FiscalPositionId).HasColumnName("fiscal_position_id");
                        entity.Property(e => e.FloatingOrderName).HasColumnName("floating_order_name");
                        entity.Property(e => e.GeneralNote).HasColumnName("general_note");
                        entity.Property(e => e.HasDeletedLine).HasColumnName("has_deleted_line");
                        entity.Property(e => e.IsTipped).HasColumnName("is_tipped");
                        entity.Property(e => e.LastOrderPreparationChange).HasColumnName("last_order_preparation_change");
                        entity.Property(e => e.Mobile).HasColumnName("mobile");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.NbPrint).HasColumnName("nb_print");
                        entity.Property(e => e.NextOnlinePaymentAmount).HasColumnName("next_online_payment_amount");
                        entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                        entity.Property(e => e.PosReference).HasColumnName("pos_reference");
                        entity.Property(e => e.PricelistId).HasColumnName("pricelist_id");
                        entity.Property(e => e.ProcurementGroupId).HasColumnName("procurement_group_id");
                        entity.Property(e => e.SaleJournal).HasColumnName("sale_journal");
                        entity.Property(e => e.SequenceNumber).HasColumnName("sequence_number");
                        entity.Property(e => e.SessionId).HasColumnName("session_id");
                        entity.Property(e => e.ShippingDate).HasColumnName("shipping_date");
                        entity.Property(e => e.State).HasColumnName("state");
                        entity.Property(e => e.TableId).HasColumnName("table_id");
                        entity.Property(e => e.TableStandNumber).HasColumnName("table_stand_number");
                        entity.Property(e => e.Takeaway).HasColumnName("takeaway");
                        entity.Property(e => e.TicketCode).HasColumnName("ticket_code");
                        entity.Property(e => e.TipAmount).HasColumnName("tip_amount");
                        entity.Property(e => e.ToInvoice).HasColumnName("to_invoice");
                        entity.Property(e => e.UseSelfOrderOnlinePayment).HasColumnName("use_self_order_online_payment");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.Uuid).HasColumnName("uuid");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        entity.HasOne(d => d.AccountMove1).WithMany(p => p.PosOrder)
                            .HasForeignKey(d => d.AccountMove)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_order_account_move_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.PosOrder) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("pos_order_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("pos_order_company_id_fkey");

                        entity.HasOne(d => d.Config).WithMany(p => p.PosOrder)
                            .HasForeignKey(d => d.ConfigId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_order_config_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.PosOrderCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("pos_order_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_order_create_uid_fkey");

                        entity.HasOne(d => d.CrmTeam).WithMany(p => p.PosOrder)
                            .HasForeignKey(d => d.CrmTeamId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_order_crm_team_id_fkey");

                        entity.HasOne(d => d.Employee).WithMany(p => p.PosOrder)
                            .HasForeignKey(d => d.EmployeeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_order_employee_id_fkey");

                        entity.HasOne(d => d.FiscalPosition).WithMany(p => p.PosOrder)
                            .HasForeignKey(d => d.FiscalPositionId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_order_fiscal_position_id_fkey");

                        // entity.HasOne(d => d.Partner).WithMany(p => p.PosOrder) .HasForeignKey(d => d.PartnerId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("pos_order_partner_id_fkey");
                        entity.HasOne(d => d.Partner).WithMany()
                            .HasForeignKey(d => d.PartnerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_order_partner_id_fkey");

                        entity.HasOne(d => d.Pricelist).WithMany(p => p.PosOrder)
                            .HasForeignKey(d => d.PricelistId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_order_pricelist_id_fkey");

                        entity.HasOne(d => d.ProcurementGroup).WithMany(p => p.PosOrder)
                            .HasForeignKey(d => d.ProcurementGroupId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_order_procurement_group_id_fkey");

                        entity.HasOne(d => d.SaleJournalNavigation).WithMany(p => p.PosOrder)
                            .HasForeignKey(d => d.SaleJournal)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("pos_order_sale_journal_fkey");

                        entity.HasOne(d => d.Session).WithMany(p => p.PosOrder)
                            .HasForeignKey(d => d.SessionId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("pos_order_session_id_fkey");

                        entity.HasOne(d => d.Table).WithMany(p => p.PosOrder)
                            .HasForeignKey(d => d.TableId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_order_table_id_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.PosOrderUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("pos_order_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_order_user_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.PosOrderWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("pos_order_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_order_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}