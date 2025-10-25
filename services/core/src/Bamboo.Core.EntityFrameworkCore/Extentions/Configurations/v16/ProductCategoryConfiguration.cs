using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Bamboo.Core.Models;

namespace Bamboo.Core.EntityFrameworkCore
{
    public static partial class ModelBuilderExtensions
    {
        public static void ConfigureProductCategory(this ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<ProductCategory>(entity =>
            {
            entity.HasKey(e => e.Id).HasName("product_category_pkey");

                        entity.ToTable("product_category");

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.Name, "product_category__name_index")
                            .HasMethod("gin")
                            .HasOperators(new[] { "gin_trgm_ops" });

                        entity.HasIndex(e => e.ParentId, "product_category__parent_id_index");

                        entity.HasIndex(e => e.ParentPath, "product_category__parent_path_index");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.CompleteName).HasColumnName("complete_name");
                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.PackagingReserveMethod).HasColumnName("packaging_reserve_method");
                        entity.Property(e => e.ParentId).HasColumnName("parent_id");
                        entity.Property(e => e.ParentPath).HasColumnName("parent_path");
                        entity.Property(e => e.ProductPropertiesDefinition)
                            .HasColumnType("jsonb")
                            .HasColumnName("product_properties_definition");
                        entity.Property(e => e.PropertyAccountCreditorPriceDifferenceCateg)
                            .HasColumnType("jsonb")
                            .HasColumnName("property_account_creditor_price_difference_categ");
                        entity.Property(e => e.PropertyAccountDownpaymentCategId)
                            .HasColumnType("jsonb")
                            .HasColumnName("property_account_downpayment_categ_id");
                        entity.Property(e => e.PropertyAccountExpenseCategId)
                            .HasColumnType("jsonb")
                            .HasColumnName("property_account_expense_categ_id");
                        entity.Property(e => e.PropertyAccountIncomeCategId)
                            .HasColumnType("jsonb")
                            .HasColumnName("property_account_income_categ_id");
                        entity.Property(e => e.PropertyCostMethod)
                            .HasColumnType("jsonb")
                            .HasColumnName("property_cost_method");
                        entity.Property(e => e.PropertyStockAccountInputCategId)
                            .HasColumnType("jsonb")
                            .HasColumnName("property_stock_account_input_categ_id");
                        entity.Property(e => e.PropertyStockAccountOutputCategId)
                            .HasColumnType("jsonb")
                            .HasColumnName("property_stock_account_output_categ_id");
                        entity.Property(e => e.PropertyStockAccountProductionCostId)
                            .HasColumnType("jsonb")
                            .HasColumnName("property_stock_account_production_cost_id");
                        entity.Property(e => e.PropertyStockJournal)
                            .HasColumnType("jsonb")
                            .HasColumnName("property_stock_journal");
                        entity.Property(e => e.PropertyStockValuationAccountId)
                            .HasColumnType("jsonb")
                            .HasColumnName("property_stock_valuation_account_id");
                        entity.Property(e => e.PropertyValuation)
                            .HasColumnType("jsonb")
                            .HasColumnName("property_valuation");
                        entity.Property(e => e.RemovalStrategyId).HasColumnName("removal_strategy_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.ProductCategoryCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("product_category_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_category_create_uid_fkey");

                        entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                            .HasForeignKey(d => d.ParentId)
                            .OnDelete(DeleteBehavior.Cascade)
                            .HasConstraintName("product_category_parent_id_fkey");

                        entity.HasOne(d => d.RemovalStrategy).WithMany(p => p.ProductCategory)
                            .HasForeignKey(d => d.RemovalStrategyId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_category_removal_strategy_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.ProductCategoryWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("product_category_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("product_category_write_uid_fkey");

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}