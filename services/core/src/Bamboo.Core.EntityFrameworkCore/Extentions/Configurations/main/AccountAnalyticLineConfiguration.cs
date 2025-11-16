using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureAccountAnalyticLine(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<AccountAnalyticLine>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("account_analytic_line_pkey");

                        entity.ToTable("account_analytic_line");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.AccountId, "account_analytic_line__account_id_index");

                        entity.HasIndex(e => e.Date, "account_analytic_line__date_index");

                        entity.HasIndex(e => e.EmployeeId, "account_analytic_line__employee_id_index");

                        entity.HasIndex(e => e.GlobalLeaveId, "account_analytic_line__global_leave_id_index").HasFilter("(global_leave_id IS NOT NULL)");

                        entity.HasIndex(e => e.HolidayId, "account_analytic_line__holiday_id_index").HasFilter("(holiday_id IS NOT NULL)");

                        entity.HasIndex(e => e.MoveLineId, "account_analytic_line__move_line_id_index");

                        entity.HasIndex(e => e.OrderId, "account_analytic_line__order_id_index");

                        entity.HasIndex(e => e.ProjectId, "account_analytic_line__project_id_index");

                        entity.HasIndex(e => e.SoLine, "account_analytic_line__so_line_index").HasFilter("(so_line IS NOT NULL)");

                        entity.HasIndex(e => e.TaskId, "account_analytic_line__task_id_index").HasFilter("(task_id IS NOT NULL)");

                        entity.HasIndex(e => e.TimesheetInvoiceId, "account_analytic_line__timesheet_invoice_id_index").HasFilter("(timesheet_invoice_id IS NOT NULL)");

                        entity.HasIndex(e => e.UserId, "account_analytic_line__user_id_index");

                        entity.HasIndex(e => e.XPlan2Id, "account_analytic_line__x_plan2_id_index").HasFilter("(x_plan2_id IS NOT NULL)");

                        entity.HasIndex(e => e.XPlan3Id, "account_analytic_line__x_plan3_id_index").HasFilter("(x_plan3_id IS NOT NULL)");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AccountId).HasColumnName("account_id");
                        entity.Property(e => e.Amount).HasColumnName("amount");
                        entity.Property(e => e.Category).HasColumnName("category");
                        entity.Property(e => e.Code).HasColumnName("code");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
                        entity.Property(e => e.Date).HasColumnName("date");
                        entity.Property(e => e.DepartmentId).HasColumnName("department_id");
                        entity.Property(e => e.EmployeeId).HasColumnName("employee_id");
                        entity.Property(e => e.GeneralAccountId).HasColumnName("general_account_id");
                        entity.Property(e => e.GlobalLeaveId).HasColumnName("global_leave_id");
                        entity.Property(e => e.HolidayId).HasColumnName("holiday_id");
                        entity.Property(e => e.IsSoLineEdited).HasColumnName("is_so_line_edited");
                        entity.Property(e => e.JournalId).HasColumnName("journal_id");
                        entity.Property(e => e.ManagerId).HasColumnName("manager_id");
                        entity.Property(e => e.MoveLineId).HasColumnName("move_line_id");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.OrderId).HasColumnName("order_id");
                        entity.Property(e => e.ParentTaskId).HasColumnName("parent_task_id");
                        entity.Property(e => e.PartnerId).HasColumnName("partner_id");
                        entity.Property(e => e.ProductId).HasColumnName("product_id");
                        entity.Property(e => e.ProductUomId).HasColumnName("product_uom_id");
                        entity.Property(e => e.ProjectId).HasColumnName("project_id");
                        entity.Property(e => e.Ref).HasColumnName("ref");
                        entity.Property(e => e.SoLine).HasColumnName("so_line");
                        entity.Property(e => e.TaskId).HasColumnName("task_id");
                        entity.Property(e => e.TimesheetInvoiceId).HasColumnName("timesheet_invoice_id");
                        entity.Property(e => e.TimesheetInvoiceType).HasColumnName("timesheet_invoice_type");
                        entity.Property(e => e.UnitAmount).HasColumnName("unit_amount");
                        entity.Property(e => e.UserId).HasColumnName("user_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");
                        entity.Property(e => e.XPlan2Id).HasColumnName("x_plan2_id");
                        entity.Property(e => e.XPlan3Id).HasColumnName("x_plan3_id");

                        // entity.HasOne(d => d.Account).WithMany(p => p.AccountAnalyticLineAccount) .HasForeignKey(d => d.AccountId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("account_analytic_line_account_id_fkey");
                        entity.HasOne(d => d.Account).WithMany()
                            .HasForeignKey(d => d.AccountId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("account_analytic_line_account_id_fkey");

                        // entity.HasOne(d => d.Company).WithMany(p => p.AccountAnalyticLine) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("account_analytic_line_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("account_analytic_line_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.AccountAnalyticLineCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_analytic_line_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_analytic_line_create_uid_fkey");

                        // entity.HasOne(d => d.Currency).WithMany(p => p.AccountAnalyticLine) .HasForeignKey(d => d.CurrencyId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_analytic_line_currency_id_fkey");
                        entity.HasOne(d => d.Currency).WithMany()
                            .HasForeignKey(d => d.CurrencyId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_analytic_line_currency_id_fkey");

                        entity.HasOne(d => d.Department).WithMany(p => p.AccountAnalyticLine)
                            .HasForeignKey(d => d.DepartmentId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_analytic_line_department_id_fkey");

                        entity.HasOne(d => d.Employee).WithMany(p => p.AccountAnalyticLineEmployee)
                            .HasForeignKey(d => d.EmployeeId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_analytic_line_employee_id_fkey");

                        // entity.HasOne(d => d.GeneralAccount).WithMany(p => p.AccountAnalyticLine) .HasForeignKey(d => d.GeneralAccountId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("account_analytic_line_general_account_id_fkey");
                        entity.HasOne(d => d.GeneralAccount).WithMany()
                            .HasForeignKey(d => d.GeneralAccountId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("account_analytic_line_general_account_id_fkey");

                        entity.HasOne(d => d.GlobalLeave).WithMany(p => p.AccountAnalyticLine)
                            .HasForeignKey(d => d.GlobalLeaveId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("account_analytic_line_global_leave_id_fkey");

                        entity.HasOne(d => d.Holiday).WithMany(p => p.AccountAnalyticLine)
                            .HasForeignKey(d => d.HolidayId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_analytic_line_holiday_id_fkey");

                        // entity.HasOne(d => d.Journal).WithMany(p => p.AccountAnalyticLine) .HasForeignKey(d => d.JournalId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_analytic_line_journal_id_fkey");
                        entity.HasOne(d => d.Journal).WithMany()
                            .HasForeignKey(d => d.JournalId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_analytic_line_journal_id_fkey");

                        entity.HasOne(d => d.Manager).WithMany(p => p.AccountAnalyticLineManager)
                            .HasForeignKey(d => d.ManagerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_analytic_line_manager_id_fkey");

                        entity.HasOne(d => d.MoveLine).WithMany(p => p.AccountAnalyticLine)
                            .HasForeignKey(d => d.MoveLineId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("account_analytic_line_move_line_id_fkey");

                        entity.HasOne(d => d.Order).WithMany(p => p.AccountAnalyticLine)
                            .HasForeignKey(d => d.OrderId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_analytic_line_order_id_fkey");

                        entity.HasOne(d => d.ParentTask).WithMany(p => p.AccountAnalyticLineParentTask)
                            .HasForeignKey(d => d.ParentTaskId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_analytic_line_parent_task_id_fkey");

                        // entity.HasOne(d => d.Partner).WithMany(p => p.AccountAnalyticLine) .HasForeignKey(d => d.PartnerId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_analytic_line_partner_id_fkey");
                        entity.HasOne(d => d.Partner).WithMany()
                            .HasForeignKey(d => d.PartnerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_analytic_line_partner_id_fkey");

                        // entity.HasOne(d => d.Product).WithMany(p => p.AccountAnalyticLine) .HasForeignKey(d => d.ProductId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_analytic_line_product_id_fkey");
                        entity.HasOne(d => d.Product).WithMany()
                            .HasForeignKey(d => d.ProductId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_analytic_line_product_id_fkey");

                        // entity.HasOne(d => d.ProductUom).WithMany(p => p.AccountAnalyticLine) .HasForeignKey(d => d.ProductUomId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_analytic_line_product_uom_id_fkey");
                        entity.HasOne(d => d.ProductUom).WithMany()
                            .HasForeignKey(d => d.ProductUomId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_analytic_line_product_uom_id_fkey");

                        entity.HasOne(d => d.Project).WithMany(p => p.AccountAnalyticLine)
                            .HasForeignKey(d => d.ProjectId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_analytic_line_project_id_fkey");

                        entity.HasOne(d => d.SoLineNavigation).WithMany(p => p.AccountAnalyticLine)
                            .HasForeignKey(d => d.SoLine)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_analytic_line_so_line_fkey");

                        entity.HasOne(d => d.Task).WithMany(p => p.AccountAnalyticLineTask)
                            .HasForeignKey(d => d.TaskId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_analytic_line_task_id_fkey");

                        entity.HasOne(d => d.TimesheetInvoice).WithMany(p => p.AccountAnalyticLine)
                            .HasForeignKey(d => d.TimesheetInvoiceId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_analytic_line_timesheet_invoice_id_fkey");

                        // entity.HasOne(d => d.User).WithMany(p => p.AccountAnalyticLineUser) .HasForeignKey(d => d.UserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_analytic_line_user_id_fkey");
                        entity.HasOne(d => d.User).WithMany()
                            .HasForeignKey(d => d.UserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_analytic_line_user_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.AccountAnalyticLineWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("account_analytic_line_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_analytic_line_write_uid_fkey");

                        entity.HasOne(d => d.XPlan2).WithMany(p => p.AccountAnalyticLineXPlan2)
                            .HasForeignKey(d => d.XPlan2Id)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_analytic_line_x_plan2_id_fkey");

                        entity.HasOne(d => d.XPlan3).WithMany(p => p.AccountAnalyticLineXPlan3)
                            .HasForeignKey(d => d.XPlan3Id)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("account_analytic_line_x_plan3_id_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}