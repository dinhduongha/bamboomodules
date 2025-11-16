using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
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

                        entity.HasIndex(e => e.TenantId);

                        entity.HasIndex(e => e.OrganizationUnitId);

                        entity.HasIndex(e => e.CrmTeamId, "pos_config__crm_team_id_index").HasFilter("(crm_team_id IS NOT NULL)");

                        entity.Property(e => e.Id)
                            .HasDefaultValueSql("uuidv7()")
                            .HasColumnName("id");

                        entity.Property(e => e.TenantId).HasColumnName("company_id");

                        entity.Property(e => e.OrganizationUnitId).HasColumnName("organization_unit_id");
                        entity.Property(e => e.AccessToken).HasColumnName("access_token");
                        entity.Property(e => e.Active).HasColumnName("active");
                        entity.Property(e => e.AmountAuthorizedDiff).HasColumnName("amount_authorized_diff");
                        entity.Property(e => e.AutoValidateTerminalPayment).HasColumnName("auto_validate_terminal_payment");
                        entity.Property(e => e.BasicReceipt).HasColumnName("basic_receipt");
                        entity.Property(e => e.CashRounding).HasColumnName("cash_rounding");

                        entity.Property(e => e.CreationTime)
                            .HasDefaultValueSql("now()")
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("create_date");
                        entity.Property(e => e.CreatorId).HasColumnName("create_uid");
                        entity.Property(e => e.CrmTeamId).HasColumnName("crm_team_id");
                        entity.Property(e => e.CurrencyId).HasColumnName("currency_id");
                        entity.Property(e => e.CustomerDisplayBgImgName).HasColumnName("customer_display_bg_img_name");
                        entity.Property(e => e.DefaultFiscalPositionId).HasColumnName("default_fiscal_position_id");
                        entity.Property(e => e.DefaultPresetId).HasColumnName("default_preset_id");
                        entity.Property(e => e.DefaultScreen).HasColumnName("default_screen");
                        entity.Property(e => e.DeviceSeqId).HasColumnName("device_seq_id");
                        entity.Property(e => e.DiscountPc).HasColumnName("discount_pc");
                        entity.Property(e => e.DiscountProductId).HasColumnName("discount_product_id");
                        entity.Property(e => e.DownPaymentProductId).HasColumnName("down_payment_product_id");
                        entity.Property(e => e.EpsonPrinterIp).HasColumnName("epson_printer_ip");
                        entity.Property(e => e.FallbackNomenclatureId).HasColumnName("fallback_nomenclature_id");
                        entity.Property(e => e.GroupPosManagerId).HasColumnName("group_pos_manager_id");
                        entity.Property(e => e.GroupPosUserId).HasColumnName("group_pos_user_id");
                        entity.Property(e => e.HasPaper).HasColumnName("has_paper");
                        entity.Property(e => e.IfaceBigScrollbars).HasColumnName("iface_big_scrollbars");
                        entity.Property(e => e.IfaceCashdrawer).HasColumnName("iface_cashdrawer");
                        entity.Property(e => e.IfaceDiscount).HasColumnName("iface_discount");
                        entity.Property(e => e.IfaceElectronicScale).HasColumnName("iface_electronic_scale");
                        entity.Property(e => e.IfaceGroupByCateg).HasColumnName("iface_group_by_categ");
                        entity.Property(e => e.IfacePrintAuto).HasColumnName("iface_print_auto");
                        entity.Property(e => e.IfacePrintSkipScreen).HasColumnName("iface_print_skip_screen");
                        entity.Property(e => e.IfacePrintViaProxy).HasColumnName("iface_print_via_proxy");
                        entity.Property(e => e.IfacePrintbill).HasColumnName("iface_printbill");
                        entity.Property(e => e.IfaceScanViaProxy).HasColumnName("iface_scan_via_proxy");
                        entity.Property(e => e.IfaceSplitbill).HasColumnName("iface_splitbill");
                        entity.Property(e => e.IfaceTaxIncluded).HasColumnName("iface_tax_included");
                        entity.Property(e => e.IfaceTipproduct).HasColumnName("iface_tipproduct");
                        entity.Property(e => e.InvoiceJournalId).HasColumnName("invoice_journal_id");
                        entity.Property(e => e.IsClosingEntryByProduct).HasColumnName("is_closing_entry_by_product");
                        entity.Property(e => e.IsHeaderOrFooter).HasColumnName("is_header_or_footer");
                        entity.Property(e => e.IsMarginsCostsAccessibleToEveryUser).HasColumnName("is_margins_costs_accessible_to_every_user");
                        entity.Property(e => e.IsOrderPrinter).HasColumnName("is_order_printer");
                        entity.Property(e => e.IsPosbox).HasColumnName("is_posbox");
                        entity.Property(e => e.JournalId).HasColumnName("journal_id");
                        entity.Property(e => e.LastDataChange)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("last_data_change");
                        entity.Property(e => e.LimitCategories).HasColumnName("limit_categories");
                        entity.Property(e => e.ManualDiscount).HasColumnName("manual_discount");
                        entity.Property(e => e.ModulePosAppointment).HasColumnName("module_pos_appointment");
                        entity.Property(e => e.ModulePosAvatax).HasColumnName("module_pos_avatax");
                        entity.Property(e => e.ModulePosDiscount).HasColumnName("module_pos_discount");
                        entity.Property(e => e.ModulePosHr).HasColumnName("module_pos_hr");
                        entity.Property(e => e.ModulePosRestaurant).HasColumnName("module_pos_restaurant");
                        entity.Property(e => e.ModulePosSms).HasColumnName("module_pos_sms");
                        entity.Property(e => e.Name).HasColumnName("name");
                        entity.Property(e => e.OnlyRoundCashMethod).HasColumnName("only_round_cash_method");
                        entity.Property(e => e.OrderBackendSeqId).HasColumnName("order_backend_seq_id");
                        entity.Property(e => e.OrderEditTracking).HasColumnName("order_edit_tracking");
                        entity.Property(e => e.OrderLineSeqId).HasColumnName("order_line_seq_id");
                        entity.Property(e => e.OrderSeqId).HasColumnName("order_seq_id");
                        entity.Property(e => e.OtherDevices).HasColumnName("other_devices");
                        entity.Property(e => e.PickingPolicy).HasColumnName("picking_policy");
                        entity.Property(e => e.PickingTypeId).HasColumnName("picking_type_id");
                        entity.Property(e => e.PricelistId).HasColumnName("pricelist_id");
                        entity.Property(e => e.ProxyIp).HasColumnName("proxy_ip");
                        entity.Property(e => e.ReceiptFooter).HasColumnName("receipt_footer");
                        entity.Property(e => e.ReceiptHeader).HasColumnName("receipt_header");
                        entity.Property(e => e.RestrictPriceControl).HasColumnName("restrict_price_control");
                        entity.Property(e => e.RoundingMethod).HasColumnName("rounding_method");
                        entity.Property(e => e.RouteId).HasColumnName("route_id");
                        entity.Property(e => e.SelfOrderOnlinePaymentMethodId).HasColumnName("self_order_online_payment_method_id");
                        entity.Property(e => e.SelfOrderingDefaultLanguageId).HasColumnName("self_ordering_default_language_id");
                        entity.Property(e => e.SelfOrderingDefaultUserId).HasColumnName("self_ordering_default_user_id");
                        entity.Property(e => e.SelfOrderingImageBrandName).HasColumnName("self_ordering_image_brand_name");
                        entity.Property(e => e.SelfOrderingMode).HasColumnName("self_ordering_mode");
                        entity.Property(e => e.SelfOrderingPayAfter).HasColumnName("self_ordering_pay_after");
                        entity.Property(e => e.SelfOrderingServiceMode).HasColumnName("self_ordering_service_mode");
                        entity.Property(e => e.SetMaximumDifference).HasColumnName("set_maximum_difference");
                        entity.Property(e => e.SetTipAfterPayment).HasColumnName("set_tip_after_payment");
                        entity.Property(e => e.ShipLater).HasColumnName("ship_later");
                        entity.Property(e => e.ShowCategoryImages).HasColumnName("show_category_images");
                        entity.Property(e => e.ShowProductImages).HasColumnName("show_product_images");
                        entity.Property(e => e.TaxRegimeSelection).HasColumnName("tax_regime_selection");
                        entity.Property(e => e.TipProductId).HasColumnName("tip_product_id");
                        entity.Property(e => e.UseFastPayment).HasColumnName("use_fast_payment");
                        entity.Property(e => e.UsePresets).HasColumnName("use_presets");
                        entity.Property(e => e.UsePricelist).HasColumnName("use_pricelist");
                        entity.Property(e => e.Uuid).HasColumnName("uuid");
                        entity.Property(e => e.WarehouseId).HasColumnName("warehouse_id");
                        entity.Property(e => e.LastModificationTime)
                            .HasColumnType("timestamp without time zone")
                            .HasColumnName("write_date");
                        entity.Property(e => e.LastModifierId).HasColumnName("write_uid");

                        // entity.HasOne(d => d.Company).WithMany(p => p.PosConfig) .HasForeignKey(d => d.TenantId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("pos_config_company_id_fkey");
                        entity.HasOne(d => d.Company).WithMany()
                            .HasForeignKey(d => d.TenantId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("pos_config_company_id_fkey");

                        // entity.HasOne(d => d.CreateU).WithMany(p => p.PosConfigCreateU) .HasForeignKey(d => d.CreatorId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("pos_config_create_uid_fkey");
                        entity.HasOne(d => d.CreateU).WithMany()
                            .HasForeignKey(d => d.CreatorId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_config_create_uid_fkey");

                        entity.HasOne(d => d.CrmTeam).WithMany(p => p.PosConfig)
                            .HasForeignKey(d => d.CrmTeamId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_config_crm_team_id_fkey");

                        // entity.HasOne(d => d.Currency).WithMany(p => p.PosConfig) .HasForeignKey(d => d.CurrencyId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("pos_config_currency_id_fkey");
                        entity.HasOne(d => d.Currency).WithMany()
                            .HasForeignKey(d => d.CurrencyId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_config_currency_id_fkey");

                        entity.HasOne(d => d.DefaultFiscalPosition).WithMany(p => p.PosConfigNavigation)
                            .HasForeignKey(d => d.DefaultFiscalPositionId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_config_default_fiscal_position_id_fkey");

                        entity.HasOne(d => d.DefaultPreset).WithMany(p => p.PosConfig)
                            .HasForeignKey(d => d.DefaultPresetId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_config_default_preset_id_fkey");

                        entity.HasOne(d => d.DeviceSeq).WithMany(p => p.PosConfigDeviceSeq)
                            .HasForeignKey(d => d.DeviceSeqId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_config_device_seq_id_fkey");

                        // entity.HasOne(d => d.DiscountProduct).WithMany(p => p.PosConfigDiscountProduct) .HasForeignKey(d => d.DiscountProductId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("pos_config_discount_product_id_fkey");
                        entity.HasOne(d => d.DiscountProduct).WithMany()
                            .HasForeignKey(d => d.DiscountProductId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_config_discount_product_id_fkey");

                        // entity.HasOne(d => d.DownPaymentProduct).WithMany(p => p.PosConfigDownPaymentProduct) .HasForeignKey(d => d.DownPaymentProductId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("pos_config_down_payment_product_id_fkey");
                        entity.HasOne(d => d.DownPaymentProduct).WithMany()
                            .HasForeignKey(d => d.DownPaymentProductId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_config_down_payment_product_id_fkey");

                        entity.HasOne(d => d.FallbackNomenclature).WithMany(p => p.PosConfig)
                            .HasForeignKey(d => d.FallbackNomenclatureId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_config_fallback_nomenclature_id_fkey");

                        entity.HasOne(d => d.GroupPosManager).WithMany(p => p.PosConfigGroupPosManager)
                            .HasForeignKey(d => d.GroupPosManagerId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_config_group_pos_manager_id_fkey");

                        entity.HasOne(d => d.GroupPosUser).WithMany(p => p.PosConfigGroupPosUser)
                            .HasForeignKey(d => d.GroupPosUserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_config_group_pos_user_id_fkey");

                        entity.HasOne(d => d.InvoiceJournal).WithMany(p => p.PosConfigInvoiceJournal)
                            .HasForeignKey(d => d.InvoiceJournalId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_config_invoice_journal_id_fkey");

                        // entity.HasOne(d => d.Journal).WithMany(p => p.PosConfigJournal) .HasForeignKey(d => d.JournalId) .OnDelete(DeleteBehavior.Restrict) .HasConstraintName("pos_config_journal_id_fkey");
                        entity.HasOne(d => d.Journal).WithMany()
                            .HasForeignKey(d => d.JournalId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("pos_config_journal_id_fkey");

                        entity.HasOne(d => d.OrderBackendSeq).WithMany(p => p.PosConfigOrderBackendSeq)
                            .HasForeignKey(d => d.OrderBackendSeqId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_config_order_backend_seq_id_fkey");

                        entity.HasOne(d => d.OrderLineSeq).WithMany(p => p.PosConfigOrderLineSeq)
                            .HasForeignKey(d => d.OrderLineSeqId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_config_order_line_seq_id_fkey");

                        entity.HasOne(d => d.OrderSeq).WithMany(p => p.PosConfigOrderSeq)
                            .HasForeignKey(d => d.OrderSeqId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_config_order_seq_id_fkey");

                        entity.HasOne(d => d.PickingType).WithMany(p => p.PosConfig)
                            .HasForeignKey(d => d.PickingTypeId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("pos_config_picking_type_id_fkey");

                        entity.HasOne(d => d.Pricelist).WithMany(p => p.PosConfig)
                            .HasForeignKey(d => d.PricelistId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_config_pricelist_id_fkey");

                        entity.HasOne(d => d.RoundingMethodNavigation).WithMany(p => p.PosConfig)
                            .HasForeignKey(d => d.RoundingMethod)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_config_rounding_method_fkey");

                        entity.HasOne(d => d.Route).WithMany(p => p.PosConfig)
                            .HasForeignKey(d => d.RouteId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_config_route_id_fkey");

                        entity.HasOne(d => d.SelfOrderOnlinePaymentMethod).WithMany(p => p.PosConfig)
                            .HasForeignKey(d => d.SelfOrderOnlinePaymentMethodId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_config_self_order_online_payment_method_id_fkey");

                        entity.HasOne(d => d.SelfOrderingDefaultLanguage).WithMany(p => p.PosConfig)
                            .HasForeignKey(d => d.SelfOrderingDefaultLanguageId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_config_self_ordering_default_language_id_fkey");

                        // entity.HasOne(d => d.SelfOrderingDefaultUser).WithMany(p => p.PosConfigSelfOrderingDefaultUser) .HasForeignKey(d => d.SelfOrderingDefaultUserId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("pos_config_self_ordering_default_user_id_fkey");
                        entity.HasOne(d => d.SelfOrderingDefaultUser).WithMany()
                            .HasForeignKey(d => d.SelfOrderingDefaultUserId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_config_self_ordering_default_user_id_fkey");

                        // entity.HasOne(d => d.TipProduct).WithMany(p => p.PosConfigTipProduct) .HasForeignKey(d => d.TipProductId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("pos_config_tip_product_id_fkey");
                        entity.HasOne(d => d.TipProduct).WithMany()
                            .HasForeignKey(d => d.TipProductId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_config_tip_product_id_fkey");

                        entity.HasOne(d => d.Warehouse).WithMany(p => p.PosConfig)
                            .HasForeignKey(d => d.WarehouseId)
                            .OnDelete(DeleteBehavior.Restrict)
                            .HasConstraintName("pos_config_warehouse_id_fkey");

                        // entity.HasOne(d => d.WriteU).WithMany(p => p.PosConfigWriteU) .HasForeignKey(d => d.LastModifierId) .OnDelete(DeleteBehavior.SetNull) .HasConstraintName("pos_config_write_uid_fkey");
                        entity.HasOne(d => d.WriteU).WithMany()
                            .HasForeignKey(d => d.LastModifierId)
                            .OnDelete(DeleteBehavior.SetNull)
                            .HasConstraintName("pos_config_write_uid_fkey");

                        // entity.HasMany(d => d.AccountFiscalPosition).WithMany(p => p.PosConfig)
                        entity.HasMany(d => d.AccountFiscalPosition).WithMany(p => p.PosConfig)
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
                                    j.IndexerProperty<Guid>("PosConfigId").HasColumnName("pos_config_id");
                                    j.IndexerProperty<Guid>("AccountFiscalPositionId").HasColumnName("account_fiscal_position_id");
                                });

                        // entity.HasMany(d => d.HrEmployee).WithMany(p => p.PosConfig)
                        entity.HasMany(d => d.HrEmployee).WithMany(p => p.PosConfig)
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

                        // entity.HasMany(d => d.HrEmployee1).WithMany(p => p.PosConfig1)
                        entity.HasMany(d => d.HrEmployee1).WithMany(p => p.PosConfig1)
                            .UsingEntity<Dictionary<string, object>>(
                                "PosHrMinimalEmployeeHrEmployee",
                                r => r.HasOne<HrEmployee>().WithMany()
                                    .HasForeignKey("HrEmployeeId")
                                    .HasConstraintName("pos_hr_minimal_employee_hr_employee_hr_employee_id_fkey"),
                                l => l.HasOne<PosConfig>().WithMany()
                                    .HasForeignKey("PosConfigId")
                                    .HasConstraintName("pos_hr_minimal_employee_hr_employee_pos_config_id_fkey"),
                                j =>
                                {
                                    j.HasKey("PosConfigId", "HrEmployeeId").HasName("pos_hr_minimal_employee_hr_employee_pkey");
                                    j.ToTable("pos_hr_minimal_employee_hr_employee");
                                    j.HasIndex(new[] { "HrEmployeeId", "PosConfigId" }, "pos_hr_minimal_employee_hr_emp_hr_employee_id_pos_config_id_idx");
                                    j.IndexerProperty<Guid>("PosConfigId").HasColumnName("pos_config_id");
                                    j.IndexerProperty<Guid>("HrEmployeeId").HasColumnName("hr_employee_id");
                                });

                        // entity.HasMany(d => d.HrEmployeeNavigation).WithMany(p => p.PosConfigNavigation)
                        entity.HasMany(d => d.HrEmployeeNavigation).WithMany(p => p.PosConfigNavigation)
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

                        // entity.HasMany(d => d.IrAttachment).WithMany(p => p.PosConfig)
                        entity.HasMany(d => d.IrAttachment).WithMany()
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

                        // entity.HasMany(d => d.IrAttachmentNavigation).WithMany(p => p.PosConfigNavigation)
                        entity.HasMany(d => d.IrAttachmentNavigation).WithMany()
                            .UsingEntity<Dictionary<string, object>>(
                                "PosSelfOrderBackgroundRels",
                                r => r.HasOne<IrAttachment>().WithMany()
                                    .HasForeignKey("IrAttachmentId")
                                    .HasConstraintName("pos_self_order_background_rels_ir_attachment_id_fkey"),
                                l => l.HasOne<PosConfig>().WithMany()
                                    .HasForeignKey("PosConfigId")
                                    .HasConstraintName("pos_self_order_background_rels_pos_config_id_fkey"),
                                j =>
                                {
                                    j.HasKey("PosConfigId", "IrAttachmentId").HasName("pos_self_order_background_rels_pkey");
                                    j.ToTable("pos_self_order_background_rels");
                                    j.HasIndex(new[] { "IrAttachmentId", "PosConfigId" }, "pos_self_order_background_rel_ir_attachment_id_pos_config_i_idx");
                                    j.IndexerProperty<Guid>("PosConfigId").HasColumnName("pos_config_id");
                                    j.IndexerProperty<Guid>("IrAttachmentId").HasColumnName("ir_attachment_id");
                                });

                        // entity.HasMany(d => d.IsTrusted).WithMany(p => p.IsTrusting)
                        entity.HasMany(d => d.IsTrusted).WithMany(p => p.IsTrusting)
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

                        // entity.HasMany(d => d.IsTrusting).WithMany(p => p.IsTrusted)
                        entity.HasMany(d => d.IsTrusting).WithMany(p => p.IsTrusted)
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

                        // entity.HasMany(d => d.PosBill).WithMany(p => p.PosConfig)
                        entity.HasMany(d => d.PosBill).WithMany(p => p.PosConfig)
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
                                    j.IndexerProperty<Guid>("PosConfigId").HasColumnName("pos_config_id");
                                    j.IndexerProperty<Guid>("PosBillId").HasColumnName("pos_bill_id");
                                });

                        // entity.HasMany(d => d.PosCategory).WithMany(p => p.PosConfig)
                        entity.HasMany(d => d.PosCategory).WithMany(p => p.PosConfig)
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
                                    j.IndexerProperty<Guid>("PosConfigId").HasColumnName("pos_config_id");
                                    j.IndexerProperty<Guid>("PosCategoryId").HasColumnName("pos_category_id");
                                });

                        // entity.HasMany(d => d.PosNote).WithMany(p => p.PosConfig)
                        entity.HasMany(d => d.PosNote).WithMany(p => p.PosConfig)
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

                        // entity.HasMany(d => d.PosPaymentMethod).WithMany(p => p.PosConfigNavigation)
                        entity.HasMany(d => d.PosPaymentMethod).WithMany(p => p.PosConfigNavigation)
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
                                    j.IndexerProperty<Guid>("PosConfigId").HasColumnName("pos_config_id");
                                    j.IndexerProperty<Guid>("PosPaymentMethodId").HasColumnName("pos_payment_method_id");
                                });

                        // entity.HasMany(d => d.PosPaymentMethodNavigation).WithMany(p => p.PosConfig1)
                        entity.HasMany(d => d.PosPaymentMethodNavigation).WithMany(p => p.PosConfig1)
                            .UsingEntity<Dictionary<string, object>>(
                                "PosPaymentMethodConfigFastValidationRelation",
                                r => r.HasOne<PosPaymentMethod>().WithMany()
                                    .HasForeignKey("PosPaymentMethodId")
                                    .HasConstraintName("pos_payment_method_config_fast_valid_pos_payment_method_id_fkey"),
                                l => l.HasOne<PosConfig>().WithMany()
                                    .HasForeignKey("PosConfigId")
                                    .HasConstraintName("pos_payment_method_config_fast_validation_re_pos_config_id_fkey"),
                                j =>
                                {
                                    j.HasKey("PosConfigId", "PosPaymentMethodId").HasName("pos_payment_method_config_fast_validation_relation_pkey");
                                    j.ToTable("pos_payment_method_config_fast_validation_relation");
                                    j.HasIndex(new[] { "PosPaymentMethodId", "PosConfigId" }, "pos_payment_method_config_fas_pos_payment_method_id_pos_con_idx");
                                    j.IndexerProperty<Guid>("PosConfigId").HasColumnName("pos_config_id");
                                    j.IndexerProperty<Guid>("PosPaymentMethodId").HasColumnName("pos_payment_method_id");
                                });

                        // entity.HasMany(d => d.PosPreset).WithMany(p => p.PosConfigNavigation)
                        entity.HasMany(d => d.PosPreset).WithMany(p => p.PosConfigNavigation)
                            .UsingEntity<Dictionary<string, object>>(
                                "PosConfigPosPresetRel",
                                r => r.HasOne<PosPreset>().WithMany()
                                    .HasForeignKey("PosPresetId")
                                    .HasConstraintName("pos_config_pos_preset_rel_pos_preset_id_fkey"),
                                l => l.HasOne<PosConfig>().WithMany()
                                    .HasForeignKey("PosConfigId")
                                    .HasConstraintName("pos_config_pos_preset_rel_pos_config_id_fkey"),
                                j =>
                                {
                                    j.HasKey("PosConfigId", "PosPresetId").HasName("pos_config_pos_preset_rel_pkey");
                                    j.ToTable("pos_config_pos_preset_rel");
                                    j.HasIndex(new[] { "PosPresetId", "PosConfigId" }, "pos_config_pos_preset_rel_pos_preset_id_pos_config_id_idx");
                                    j.IndexerProperty<Guid>("PosConfigId").HasColumnName("pos_config_id");
                                    j.IndexerProperty<Guid>("PosPresetId").HasColumnName("pos_preset_id");
                                });

                        // entity.HasMany(d => d.ProductPricelist).WithMany(p => p.PosConfigNavigation)
                        entity.HasMany(d => d.ProductPricelist).WithMany(p => p.PosConfigNavigation)
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
                                    j.IndexerProperty<Guid>("PosConfigId").HasColumnName("pos_config_id");
                                    j.IndexerProperty<Guid>("ProductPricelistId").HasColumnName("product_pricelist_id");
                                });

                        // entity.HasMany(d => d.ResLang).WithMany(p => p.PosConfigNavigation)
                        entity.HasMany(d => d.ResLang).WithMany(p => p.PosConfigNavigation)
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

                        // entity.HasMany(d => d.RestaurantFloor).WithMany(p => p.PosConfig)
                        entity.HasMany(d => d.RestaurantFloor).WithMany(p => p.PosConfig)
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

                entity.TryConfigureExtraProperties();
                entity.TryConfigureObjectExtensions();
                entity.TryConfigureConcurrencyStamp();
            });
        }
    }
}