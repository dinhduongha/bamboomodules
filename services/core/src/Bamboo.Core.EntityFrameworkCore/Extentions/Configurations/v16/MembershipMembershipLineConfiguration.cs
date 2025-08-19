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
        public static void ConfigureMembershipMembershipLine(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<MembershipMembershipLine>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("membership_membership_line_pkey");

            entity.ToTable("membership_membership_line");

            entity.HasIndex(e => e.TenantId);

            entity.HasIndex(e => e.OrganizationUnitId);

            entity.HasIndex(e => e.Partner, "membership_membership_line__partner_index");

            entity.Property(e => e.Id)
                .HasDefaultValueSql("next_uuid()")
                .HasColumnName("id");

            entity.Property(e => e.TenantId).HasColumnName("company_id");

            entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
            entity.Property(e => e.AccountInvoiceLine).HasColumnName("account_invoice_line");

            entity.Property(e => e.CreationTime)
                .HasDefaultValueSql("now()")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("create_date");
            entity.Property(e => e.CreatorId).HasColumnName("create_uid");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.DateCancel).HasColumnName("date_cancel");
            entity.Property(e => e.DateFrom).HasColumnName("date_from");
            entity.Property(e => e.DateTo).HasColumnName("date_to");
            entity.Property(e => e.MemberPrice).HasColumnName("member_price");
            entity.Property(e => e.MembershipId).HasColumnName("membership_id");
            entity.Property(e => e.Partner).HasColumnName("partner");
            entity.Property(e => e.State).HasColumnName("state");
            entity.Property(e => e.LastModificationTime)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("write_date");
            entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

            entity.HasOne(d => d.AccountInvoiceLineNavigation).WithMany(p => p.MembershipMembershipLine)
                .HasForeignKey(d => d.AccountInvoiceLine)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("membership_membership_line_account_invoice_line_fkey");

            // entity.HasOne(d => d.Company).WithMany(p => p.MembershipMembershipLine)
            entity.HasOne(d => d.Company).WithMany()
                .HasForeignKey(d => d.TenantId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("membership_membership_line_company_id_fkey");

            // entity.HasOne(d => d.CreateU).WithMany(p => p.MembershipMembershipLineCreateU)
            entity.HasOne(d => d.CreateU).WithMany()
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("membership_membership_line_create_uid_fkey");

            entity.HasOne(d => d.Membership).WithMany()
                .HasForeignKey(d => d.MembershipId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("membership_membership_line_membership_id_fkey");

            entity.HasOne(d => d.PartnerNavigation).WithMany()
                .HasForeignKey(d => d.Partner)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("membership_membership_line_partner_fkey");

            // entity.HasOne(d => d.WriteU).WithMany(p => p.MembershipMembershipLineWriteU)
            entity.HasOne(d => d.WriteU).WithMany()
                .HasForeignKey(d => d.LastModifierId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("membership_membership_line_write_uid_fkey");
            });
        }
    }
}
