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
        public static void ConfigurePosOrder(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PosOrder>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pos_order_pkey");

                entity.ToTable("pos_order");

                entity.HasIndex(e => e.AccountMove, "pos_order_account_move_index");

                entity.HasIndex(e => e.DateOrder, "pos_order_date_order_index");

                entity.HasIndex(e => e.PartnerId, "pos_order_partner_id_index").HasFilter("(partner_id IS NOT NULL)");

                entity.HasIndex(e => e.SessionId, "pos_order_session_id_index");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.AccessToken).HasColumnName("access_token");
                entity.Property(e => e.AccountMove).HasColumnName("account_move");
                entity.Property(e => e.AmountPaid).HasColumnName("amount_paid");
                entity.Property(e => e.AmountReturn).HasColumnName("amount_return");
                entity.Property(e => e.AmountTax).HasColumnName("amount_tax");
                entity.Property(e => e.AmountTotal).HasColumnName("amount_total");
                entity.Property(e => e.Cashier).HasColumnName("cashier");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.CrmTeamId).HasColumnName("crm_team_id");
                entity.Property(e => e.CurrencyRate).HasColumnName("currency_rate");
                entity.Property(e => e.DateOrder)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("date_order");
                entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
                entity.Property(e => e.FiscalPositionId).HasColumnName("fiscal_position_id");
                entity.Property(e => e.IsTipped).HasColumnName("is_tipped");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.NbPrint).HasColumnName("nb_print");
                entity.Property(e => e.Note).HasColumnName("note");
                entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                entity.Property(e => e.PosReference).HasColumnName("pos_reference");
                entity.Property(e => e.PricelistId).HasColumnName("pricelist_id");
                entity.Property(e => e.ProcurementGroupId).HasColumnName("procurement_group_id");
                entity.Property(e => e.SaleJournal).HasColumnName("sale_journal");
                entity.Property(e => e.SequenceNumber)
                    .HasColumnName("sequence_number");
                entity.Property(e => e.SessionId).HasColumnName("session_id");
                entity.Property(e => e.State).HasColumnName("state");
                entity.Property(e => e.TipAmount).HasColumnName("tip_amount");
                entity.Property(e => e.ToInvoice).HasColumnName("to_invoice");
                entity.Property(e => e.ToShip).HasColumnName("to_ship");
                entity.Property(e => e.UserId).HasColumnName("user_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne(d => d.AccountMoveNavigation).WithMany(p => p.PosOrders)
                    .HasForeignKey(d => d.AccountMove)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_order_account_move_fkey");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("pos_order_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_order_create_uid_fkey");

                entity.HasOne(d => d.CrmTeam).WithMany(p => p.PosOrders)
                    .HasForeignKey(d => d.CrmTeamId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_order_crm_team_id_fkey");

                entity.HasOne(d => d.Employee).WithMany(p => p.PosOrders)
                    .HasForeignKey(d => d.EmployeeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_order_employee_id_fkey");

                entity.HasOne(d => d.FiscalPosition).WithMany(p => p.PosOrders)
                    .HasForeignKey(d => d.FiscalPositionId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_order_fiscal_position_id_fkey");

                entity.HasOne<ResPartner>().WithMany()
                    .HasForeignKey(d => d.PartnerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_order_partner_id_fkey");

                entity.HasOne(d => d.Pricelist).WithMany(p => p.PosOrders)
                    .HasForeignKey(d => d.PricelistId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("pos_order_pricelist_id_fkey");

                entity.HasOne(d => d.ProcurementGroup).WithMany(p => p.PosOrders)
                    .HasForeignKey(d => d.ProcurementGroupId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_order_procurement_group_id_fkey");

                entity.HasOne(d => d.SaleJournalNavigation).WithMany(p => p.PosOrders)
                    .HasForeignKey(d => d.SaleJournal)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("pos_order_sale_journal_fkey");

                entity.HasOne(d => d.Session).WithMany(p => p.PosOrders)
                    .HasForeignKey(d => d.SessionId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("pos_order_session_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_order_user_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_order_write_uid_fkey");
            });
        }
    }
}