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
        public static void ConfigurePosConfig(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PosConfig>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("pos_config_pkey");

                entity.ToTable("pos_config");

                entity.Property(e => e.Id)
                    .HasDefaultValueSql("next_uuid()")
                    .HasColumnName("id");
                entity.Property(e => e.Active).HasColumnName("active");
                entity.Property(e => e.AmountAuthorizedDiff).HasColumnName("amount_authorized_diff");
                entity.Property(e => e.CashRounding).HasColumnName("cash_rounding");
                entity.Property(e => e.TenantId).HasColumnName("company_id");
                entity.Property(e => e.CreationTime).HasDefaultValueSql("now()")
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("create_date");
                entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                entity.Property(e => e.CrmTeamId).HasColumnName("crm_team_id");
                entity.Property(e => e.DefaultFiscalPositionId).HasColumnName("default_fiscal_position_id");
                entity.Property(e => e.DownPaymentProductId).HasColumnName("down_payment_product_id");
                entity.Property(e => e.EpsonPrinterIp).HasColumnName("epson_printer_ip");
                entity.Property(e => e.GroupPosManagerId).HasColumnName("group_pos_manager_id");
                entity.Property(e => e.GroupPosUserId).HasColumnName("group_pos_user_id");
                entity.Property(e => e.IfaceBigScrollbars).HasColumnName("iface_big_scrollbars");
                entity.Property(e => e.IfaceCashdrawer).HasColumnName("iface_cashdrawer");
                entity.Property(e => e.IfaceCustomerFacingDisplayLocal).HasColumnName("iface_customer_facing_display_local");
                entity.Property(e => e.IfaceCustomerFacingDisplayViaProxy).HasColumnName("iface_customer_facing_display_via_proxy");
                entity.Property(e => e.IfaceElectronicScale).HasColumnName("iface_electronic_scale");
                entity.Property(e => e.IfacePrintAuto).HasColumnName("iface_print_auto");
                entity.Property(e => e.IfacePrintSkipScreen).HasColumnName("iface_print_skip_screen");
                entity.Property(e => e.IfacePrintViaProxy).HasColumnName("iface_print_via_proxy");
                entity.Property(e => e.IfaceScanViaProxy).HasColumnName("iface_scan_via_proxy");
                entity.Property(e => e.IfaceStartCategId).HasColumnName("iface_start_categ_id");
                entity.Property(e => e.IfaceTaxIncluded).HasColumnName("iface_tax_included");
                entity.Property(e => e.IfaceTipproduct).HasColumnName("iface_tipproduct");
                entity.Property(e => e.InvoiceJournalId).HasColumnName("invoice_journal_id");
                entity.Property(e => e.IsHeaderOrFooter).HasColumnName("is_header_or_footer");
                entity.Property(e => e.IsMarginsCostsAccessibleToEveryUser).HasColumnName("is_margins_costs_accessible_to_every_user");
                entity.Property(e => e.IsPosbox).HasColumnName("is_posbox");
                entity.Property(e => e.JournalId).HasColumnName("journal_id");
                entity.Property(e => e.LimitCategories).HasColumnName("limit_categories");
                entity.Property(e => e.LimitedPartnersAmount).HasColumnName("limited_partners_amount");
                entity.Property(e => e.LimitedPartnersLoading).HasColumnName("limited_partners_loading");
                entity.Property(e => e.LimitedProductsAmount).HasColumnName("limited_products_amount");
                entity.Property(e => e.LimitedProductsLoading).HasColumnName("limited_products_loading");
                entity.Property(e => e.ManualDiscount).HasColumnName("manual_discount");
                entity.Property(e => e.ModulePosDiscount).HasColumnName("module_pos_discount");
                entity.Property(e => e.ModulePosHr).HasColumnName("module_pos_hr");
                entity.Property(e => e.ModulePosMercury).HasColumnName("module_pos_mercury");
                entity.Property(e => e.ModulePosRestaurant).HasColumnName("module_pos_restaurant");
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.OnlyRoundCashMethod).HasColumnName("only_round_cash_method");
                entity.Property(e => e.OtherDevices).HasColumnName("other_devices");
                entity.Property(e => e.PartnerLoadBackground).HasColumnName("partner_load_background");
                entity.Property(e => e.PickingPolicy).HasColumnName("picking_policy");
                entity.Property(e => e.PickingTypeId).HasColumnName("picking_type_id");
                entity.Property(e => e.PricelistId).HasColumnName("pricelist_id");
                entity.Property(e => e.ProductLoadBackground).HasColumnName("product_load_background");
                entity.Property(e => e.ProxyIp).HasColumnName("proxy_ip");
                entity.Property(e => e.ReceiptFooter).HasColumnName("receipt_footer");
                entity.Property(e => e.ReceiptHeader).HasColumnName("receipt_header");
                entity.Property(e => e.RestrictPriceControl).HasColumnName("restrict_price_control");
                entity.Property(e => e.RoundingMethod).HasColumnName("rounding_method");
                entity.Property(e => e.RouteId).HasColumnName("route_id");
                entity.Property(e => e.SequenceId).HasColumnName("sequence_id");
                entity.Property(e => e.SequenceLineId).HasColumnName("sequence_line_id");
                entity.Property(e => e.SetMaximumDifference).HasColumnName("set_maximum_difference");
                entity.Property(e => e.ShipLater).HasColumnName("ship_later");
                entity.Property(e => e.StartCategory).HasColumnName("start_category");
                entity.Property(e => e.TaxRegimeSelection).HasColumnName("tax_regime_selection");
                entity.Property(e => e.TipProductId).HasColumnName("tip_product_id");
                entity.Property(e => e.UsePricelist).HasColumnName("use_pricelist");
                entity.Property(e => e.Uuid).HasColumnName("uuid");
                entity.Property(e => e.WarehouseId).HasColumnName("warehouse_id");
                entity.Property(e => e.LastModificationTime)
                    .HasColumnType("timestamp without time zone")
                    .HasColumnName("write_date");
                entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                entity.HasOne<ResCompany>().WithMany()
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("pos_config_company_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_config_create_uid_fkey");

                entity.HasOne(d => d.CrmTeam).WithMany(p => p.PosConfigs)
                    .HasForeignKey(d => d.CrmTeamId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_config_crm_team_id_fkey");

                entity.HasOne(d => d.DefaultFiscalPosition).WithMany(p => p.PosConfigsNavigation)
                    .HasForeignKey(d => d.DefaultFiscalPositionId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_config_default_fiscal_position_id_fkey");

                entity.HasOne(d => d.DownPaymentProduct).WithMany(p => p.PosConfigDownPaymentProducts)
                    .HasForeignKey(d => d.DownPaymentProductId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_config_down_payment_product_id_fkey");

                entity.HasOne(d => d.GroupPosManager).WithMany(p => p.PosConfigGroupPosManagers)
                    .HasForeignKey(d => d.GroupPosManagerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_config_group_pos_manager_id_fkey");

                entity.HasOne(d => d.GroupPosUser).WithMany(p => p.PosConfigGroupPosUsers)
                    .HasForeignKey(d => d.GroupPosUserId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_config_group_pos_user_id_fkey");

                entity.HasOne(d => d.IfaceStartCateg).WithMany(p => p.PosConfigsNavigation)
                    .HasForeignKey(d => d.IfaceStartCategId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_config_iface_start_categ_id_fkey");

                entity.HasOne(d => d.InvoiceJournal).WithMany(p => p.PosConfigInvoiceJournals)
                    .HasForeignKey(d => d.InvoiceJournalId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_config_invoice_journal_id_fkey");

                entity.HasOne(d => d.Journal).WithMany(p => p.PosConfigJournals)
                    .HasForeignKey(d => d.JournalId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("pos_config_journal_id_fkey");

                entity.HasOne(d => d.PickingType).WithMany(p => p.PosConfigs)
                    .HasForeignKey(d => d.PickingTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("pos_config_picking_type_id_fkey");

                entity.HasOne(d => d.Pricelist).WithMany(p => p.PosConfigs)
                    .HasForeignKey(d => d.PricelistId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("pos_config_pricelist_id_fkey");

                entity.HasOne(d => d.RoundingMethodNavigation).WithMany(p => p.PosConfigs)
                    .HasForeignKey(d => d.RoundingMethod)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_config_rounding_method_fkey");

                entity.HasOne(d => d.Route).WithMany(p => p.PosConfigs)
                    .HasForeignKey(d => d.RouteId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_config_route_id_fkey");

                entity.HasOne(d => d.Sequence).WithMany(p => p.PosConfigSequences)
                    .HasForeignKey(d => d.SequenceId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("pos_config_sequence_id_fkey");

                entity.HasOne(d => d.SequenceLine).WithMany(p => p.PosConfigSequenceLines)
                    .HasForeignKey(d => d.SequenceLineId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_config_sequence_line_id_fkey");

                entity.HasOne(d => d.TipProduct).WithMany(p => p.PosConfigTipProducts)
                    .HasForeignKey(d => d.TipProductId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_config_tip_product_id_fkey");

                entity.HasOne(d => d.Warehouse).WithMany(p => p.PosConfigs)
                    .HasForeignKey(d => d.WarehouseId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("pos_config_warehouse_id_fkey");

                entity.HasOne<ResUser>().WithMany()
                    .HasForeignKey(d => d.LastModifierId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("pos_config_write_uid_fkey");

                //entity.HasMany(d => d.AccountFiscalPositions).WithMany(p => p.PosConfigs)
                entity.HasMany<AccountFiscalPosition>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "AccountFiscalPositionPosConfigRel",
                        r => r.HasOne<AccountFiscalPosition>().WithMany()
                            .HasForeignKey("AccountFiscalPositionId")
                            .HasConstraintName("account_fiscal_position_pos_con_account_fiscal_position_id_fkey"),
                        l => l.HasOne<PosConfig>().WithMany()
                            .HasForeignKey("PosConfigId")
                            .HasConstraintName("account_fiscal_position_pos_config_rel_pos_config_id_fkey"),
                        j =>
                        {
                            j.HasKey("PosConfigId", "AccountFiscalPositionId").HasName("account_fiscal_position_pos_config_rel_pkey");
                            j.ToTable("account_fiscal_position_pos_config_rel");
                            j.HasIndex(new[] { "AccountFiscalPositionId", "PosConfigId" }, "account_fiscal_position_pos_c_account_fiscal_position_id_po_idx");
                        });

                //entity.HasMany(d => d.HrEmployees).WithMany(p => p.PosConfigs)
                entity.HasMany<HrEmployee>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "PosHrAdvancedEmployeeHrEmployee",
                        r => r.HasOne<HrEmployee>().WithMany()
                            .HasForeignKey("HrEmployeeId")
                            .HasConstraintName("pos_hr_advanced_employee_hr_employee_hr_employee_id_fkey"),
                        l => l.HasOne<PosConfig>().WithMany()
                            .HasForeignKey("PosConfigId")
                            .HasConstraintName("pos_hr_advanced_employee_hr_employee_pos_config_id_fkey"),
                        j =>
                        {
                            j.HasKey("PosConfigId", "HrEmployeeId").HasName("pos_hr_advanced_employee_hr_employee_pkey");
                            j.ToTable("pos_hr_advanced_employee_hr_employee");
                            j.HasIndex(new[] { "HrEmployeeId", "PosConfigId" }, "pos_hr_advanced_employee_hr_em_hr_employee_id_pos_config_id_idx");
                            j.IndexerProperty<Guid>("PosConfigId").HasColumnName("pos_config_id");
                            j.IndexerProperty<Guid>("HrEmployeeId").HasColumnName("hr_employee_id");
                        });


                //entity.HasMany(d => d.HrEmployees).WithMany(p => p.PosConfigs)
                entity.HasMany<HrEmployee>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "HrEmployeePosConfigRel",
                        r => r.HasOne<HrEmployee>().WithMany()
                            .HasForeignKey("HrEmployeeId")
                            .HasConstraintName("hr_employee_pos_config_rel_hr_employee_id_fkey"),
                        l => l.HasOne<PosConfig>().WithMany()
                            .HasForeignKey("PosConfigId")
                            .HasConstraintName("hr_employee_pos_config_rel_pos_config_id_fkey"),
                        j =>
                        {
                            j.HasKey("PosConfigId", "HrEmployeeId").HasName("hr_employee_pos_config_rel_pkey");
                            j.ToTable("hr_employee_pos_config_rel");
                            j.HasIndex(new[] { "HrEmployeeId", "PosConfigId" }, "hr_employee_pos_config_rel_hr_employee_id_pos_config_id_idx");
                        });

                //entity.HasMany(d => d.HrEmployeesNavigation).WithMany(p => p.PosConfigsNavigation)
                entity.HasMany<HrEmployee>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "PosHrBasicEmployeeHrEmployee",
                        r => r.HasOne<HrEmployee>().WithMany()
                            .HasForeignKey("HrEmployeeId")
                            .HasConstraintName("pos_hr_basic_employee_hr_employee_hr_employee_id_fkey"),
                        l => l.HasOne<PosConfig>().WithMany()
                            .HasForeignKey("PosConfigId")
                            .HasConstraintName("pos_hr_basic_employee_hr_employee_pos_config_id_fkey"),
                        j =>
                        {
                            j.HasKey("PosConfigId", "HrEmployeeId").HasName("pos_hr_basic_employee_hr_employee_pkey");
                            j.ToTable("pos_hr_basic_employee_hr_employee");
                            j.HasIndex(new[] { "HrEmployeeId", "PosConfigId" }, "pos_hr_basic_employee_hr_emplo_hr_employee_id_pos_config_id_idx");
                            j.IndexerProperty<Guid>("PosConfigId").HasColumnName("pos_config_id");
                            j.IndexerProperty<Guid>("HrEmployeeId").HasColumnName("hr_employee_id");
                        });

                entity.HasMany(d => d.IrAttachments).WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "IrAttachmentPosConfigRel",
                        r => r.HasOne<IrAttachment>().WithMany()
                            .HasForeignKey("IrAttachmentId")
                            .HasConstraintName("ir_attachment_pos_config_rel_ir_attachment_id_fkey"),
                        l => l.HasOne<PosConfig>().WithMany()
                            .HasForeignKey("PosConfigId")
                            .HasConstraintName("ir_attachment_pos_config_rel_pos_config_id_fkey"),
                        j =>
                        {
                            j.HasKey("PosConfigId", "IrAttachmentId").HasName("ir_attachment_pos_config_rel_pkey");
                            j.ToTable("ir_attachment_pos_config_rel");
                            j.HasIndex(new[] { "IrAttachmentId", "PosConfigId" }, "ir_attachment_pos_config_rel_ir_attachment_id_pos_config_id_idx");
                            j.IndexerProperty<Guid>("PosConfigId").HasColumnName("pos_config_id");
                            j.IndexerProperty<Guid>("IrAttachmentId").HasColumnName("ir_attachment_id");
                        });

                entity.HasMany(d => d.IsTrusteds).WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "PosConfigTrustRelation",
                        r => r.HasOne<PosConfig>().WithMany()
                            .HasForeignKey("IsTrusted")
                            .HasConstraintName("pos_config_trust_relation_is_trusted_fkey"),
                        l => l.HasOne<PosConfig>().WithMany()
                            .HasForeignKey("IsTrusting")
                            .HasConstraintName("pos_config_trust_relation_is_trusting_fkey"),
                        j =>
                        {
                            j.HasKey("IsTrusting", "IsTrusted").HasName("pos_config_trust_relation_pkey");
                            j.ToTable("pos_config_trust_relation");
                            j.HasIndex(new[] { "IsTrusted", "IsTrusting" }, "pos_config_trust_relation_is_trusted_is_trusting_idx");
                            j.IndexerProperty<Guid>("IsTrusting").HasColumnName("is_trusting");
                            j.IndexerProperty<Guid>("IsTrusted").HasColumnName("is_trusted");
                        });

                entity.HasMany(d => d.IsTrustings).WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "PosConfigTrustRelation",
                        r => r.HasOne<PosConfig>().WithMany()
                            .HasForeignKey("IsTrusting")
                            .HasConstraintName("pos_config_trust_relation_is_trusting_fkey"),
                        l => l.HasOne<PosConfig>().WithMany()
                            .HasForeignKey("IsTrusted")
                            .HasConstraintName("pos_config_trust_relation_is_trusted_fkey"),
                        j =>
                        {
                            j.HasKey("IsTrusting", "IsTrusted").HasName("pos_config_trust_relation_pkey");
                            j.ToTable("pos_config_trust_relation");
                            j.HasIndex(new[] { "IsTrusted", "IsTrusting" }, "pos_config_trust_relation_is_trusted_is_trusting_idx");
                            j.IndexerProperty<Guid>("IsTrusting").HasColumnName("is_trusting");
                            j.IndexerProperty<Guid>("IsTrusted").HasColumnName("is_trusted");
                        });

                //entity.HasMany(d => d.PosBills).WithMany(p => p.PosConfigs)
                entity.HasMany<PosBill>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "PosBillPosConfigRel",
                        r => r.HasOne<PosBill>().WithMany()
                            .HasForeignKey("PosBillId")
                            .HasConstraintName("pos_bill_pos_config_rel_pos_bill_id_fkey"),
                        l => l.HasOne<PosConfig>().WithMany()
                            .HasForeignKey("PosConfigId")
                            .HasConstraintName("pos_bill_pos_config_rel_pos_config_id_fkey"),
                        j =>
                        {
                            j.HasKey("PosConfigId", "PosBillId").HasName("pos_bill_pos_config_rel_pkey");
                            j.ToTable("pos_bill_pos_config_rel");
                            j.HasIndex(new[] { "PosBillId", "PosConfigId" }, "pos_bill_pos_config_rel_pos_bill_id_pos_config_id_idx");
                        });

                //entity.HasMany(d => d.PosCategories).WithMany(p => p.PosConfigs)
                entity.HasMany<PosCategory>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "PosCategoryPosConfigRel",
                        r => r.HasOne<PosCategory>().WithMany()
                            .HasForeignKey("PosCategoryId")
                            .HasConstraintName("pos_category_pos_config_rel_pos_category_id_fkey"),
                        l => l.HasOne<PosConfig>().WithMany()
                            .HasForeignKey("PosConfigId")
                            .HasConstraintName("pos_category_pos_config_rel_pos_config_id_fkey"),
                        j =>
                        {
                            j.HasKey("PosConfigId", "PosCategoryId").HasName("pos_category_pos_config_rel_pkey");
                            j.ToTable("pos_category_pos_config_rel");
                            j.HasIndex(new[] { "PosCategoryId", "PosConfigId" }, "pos_category_pos_config_rel_pos_category_id_pos_config_id_idx");
                        });

                //entity.HasMany(d => d.PosNotes).WithMany(p => p.PosConfigs)
                entity.HasMany<PosNote>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "PosConfigPosNoteRel",
                        r => r.HasOne<PosNote>().WithMany()
                            .HasForeignKey("PosNoteId")
                            .HasConstraintName("pos_config_pos_note_rel_pos_note_id_fkey"),
                        l => l.HasOne<PosConfig>().WithMany()
                            .HasForeignKey("PosConfigId")
                            .HasConstraintName("pos_config_pos_note_rel_pos_config_id_fkey"),
                        j =>
                        {
                            j.HasKey("PosConfigId", "PosNoteId").HasName("pos_config_pos_note_rel_pkey");
                            j.ToTable("pos_config_pos_note_rel");
                            j.HasIndex(new[] { "PosNoteId", "PosConfigId" }, "pos_config_pos_note_rel_pos_note_id_pos_config_id_idx");
                            j.IndexerProperty<Guid>("PosConfigId").HasColumnName("pos_config_id");
                            j.IndexerProperty<Guid>("PosNoteId").HasColumnName("pos_note_id");
                        });

                //entity.HasMany(d => d.PosPaymentMethods).WithMany(p => p.PosConfigs)
                entity.HasMany<PosPaymentMethod>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "PosConfigPosPaymentMethodRel",
                        r => r.HasOne<PosPaymentMethod>().WithMany()
                            .HasForeignKey("PosPaymentMethodId")
                            .HasConstraintName("pos_config_pos_payment_method_rel_pos_payment_method_id_fkey"),
                        l => l.HasOne<PosConfig>().WithMany()
                            .HasForeignKey("PosConfigId")
                            .HasConstraintName("pos_config_pos_payment_method_rel_pos_config_id_fkey"),
                        j =>
                        {
                            j.HasKey("PosConfigId", "PosPaymentMethodId").HasName("pos_config_pos_payment_method_rel_pkey");
                            j.ToTable("pos_config_pos_payment_method_rel");
                            j.HasIndex(new[] { "PosPaymentMethodId", "PosConfigId" }, "pos_config_pos_payment_method_pos_payment_method_id_pos_con_idx");
                        });

                //entity.HasMany(d => d.Printers).WithMany(p => p.Configs)
                entity.HasMany<PosPrinter>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "PosConfigPrinterRel",
                        r => r.HasOne<PosPrinter>().WithMany()
                            .HasForeignKey("PrinterId")
                            .HasConstraintName("pos_config_printer_rel_printer_id_fkey"),
                        l => l.HasOne<PosConfig>().WithMany()
                            .HasForeignKey("ConfigId")
                            .HasConstraintName("pos_config_printer_rel_config_id_fkey"),
                        j =>
                        {
                            j.HasKey("ConfigId", "PrinterId").HasName("pos_config_printer_rel_pkey");
                            j.ToTable("pos_config_printer_rel");
                            j.HasIndex(new[] { "PrinterId", "ConfigId" }, "pos_config_printer_rel_printer_id_config_id_idx");
                            j.IndexerProperty<Guid>("ConfigId").HasColumnName("config_id");
                            j.IndexerProperty<Guid>("PrinterId").HasColumnName("printer_id");
                        });

                //entity.HasMany(d => d.ProductPricelists).WithMany(p => p.PosConfigsNavigation)
                entity.HasMany<ProductPricelist>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "PosConfigProductPricelistRel",
                        r => r.HasOne<ProductPricelist>().WithMany()
                            .HasForeignKey("ProductPricelistId")
                            .HasConstraintName("pos_config_product_pricelist_rel_product_pricelist_id_fkey"),
                        l => l.HasOne<PosConfig>().WithMany()
                            .HasForeignKey("PosConfigId")
                            .HasConstraintName("pos_config_product_pricelist_rel_pos_config_id_fkey"),
                        j =>
                        {
                            j.HasKey("PosConfigId", "ProductPricelistId").HasName("pos_config_product_pricelist_rel_pkey");
                            j.ToTable("pos_config_product_pricelist_rel");
                            j.HasIndex(new[] { "ProductPricelistId", "PosConfigId" }, "pos_config_product_pricelist__product_pricelist_id_pos_conf_idx");
                        });

                //entity.HasMany(d => d.ResLangs).WithMany(p => p.PosConfigsNavigation)
                entity.HasMany<ResLang>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "PosConfigResLangRel",
                        r => r.HasOne<ResLang>().WithMany()
                            .HasForeignKey("ResLangId")
                            .HasConstraintName("pos_config_res_lang_rel_res_lang_id_fkey"),
                        l => l.HasOne<PosConfig>().WithMany()
                            .HasForeignKey("PosConfigId")
                            .HasConstraintName("pos_config_res_lang_rel_pos_config_id_fkey"),
                        j =>
                        {
                            j.HasKey("PosConfigId", "ResLangId").HasName("pos_config_res_lang_rel_pkey");
                            j.ToTable("pos_config_res_lang_rel");
                            j.HasIndex(new[] { "ResLangId", "PosConfigId" }, "pos_config_res_lang_rel_res_lang_id_pos_config_id_idx");
                            j.IndexerProperty<Guid>("PosConfigId").HasColumnName("pos_config_id");
                            j.IndexerProperty<Guid>("ResLangId").HasColumnName("res_lang_id");
                        });

                //entity.HasMany(d => d.RestaurantFloors).WithMany(p => p.PosConfigs)
                entity.HasMany<RestaurantFloor>().WithMany()
                    .UsingEntity<Dictionary<string, object>>(
                        "PosConfigRestaurantFloorRel",
                        r => r.HasOne<RestaurantFloor>().WithMany()
                            .HasForeignKey("RestaurantFloorId")
                            .HasConstraintName("pos_config_restaurant_floor_rel_restaurant_floor_id_fkey"),
                        l => l.HasOne<PosConfig>().WithMany()
                            .HasForeignKey("PosConfigId")
                            .HasConstraintName("pos_config_restaurant_floor_rel_pos_config_id_fkey"),
                        j =>
                        {
                            j.HasKey("PosConfigId", "RestaurantFloorId").HasName("pos_config_restaurant_floor_rel_pkey");
                            j.ToTable("pos_config_restaurant_floor_rel");
                            j.HasIndex(new[] { "RestaurantFloorId", "PosConfigId" }, "pos_config_restaurant_floor_r_restaurant_floor_id_pos_confi_idx");
                            j.IndexerProperty<Guid>("PosConfigId").HasColumnName("pos_config_id");
                            j.IndexerProperty<Guid>("RestaurantFloorId").HasColumnName("restaurant_floor_id");
                        });
            });
        }
    }
}