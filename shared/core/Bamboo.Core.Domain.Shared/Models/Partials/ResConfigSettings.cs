using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using Bamboo.Core.Domain.Shared.Attributes;

namespace Bamboo.Core.Models;

//[Table("res_config_settings")]
public partial class ResConfigSettings
{

    [Column("module_base_gengo")]
    public bool? ModuleBaseGengo { get; set; }


    [Column("alias_domain")]
    public string? AliasDomain { get; set; }


    [Column("product_pricelist_setting")]
    public string? ProductPricelistSetting { get; set; }


    [Column("group_sale_pricelist")]
    public bool? GroupSalePricelist { get; set; }


    [Column("chart_template_id")]
    public Guid? ChartTemplateId { get; set; }


    [Column("show_line_subtotals_tax_selection")]
    public string? ShowLineSubtotalsTaxSelection { get; set; }


    [Column("group_show_line_subtotals_tax_excluded")]
    public bool? GroupShowLineSubtotalsTaxExcluded { get; set; }


    [Column("group_show_line_subtotals_tax_included")]
    public bool? GroupShowLineSubtotalsTaxIncluded { get; set; }


    [Column("module_account_sepa")]
    public bool? ModuleAccountSepa { get; set; }


    [Column("module_account_taxcloud")]
    public bool? ModuleAccountTaxcloud { get; set; }

    [Column("deposit_default_product_id")]
    public Guid? DepositDefaultProductId { get; set; }

    [Column("use_quotation_validity_days")]
    public bool? UseQuotationValidityDays { get; set; }

    [Column("module_sale_quotation_builder")]
    public bool? ModuleSaleQuotationBuilder { get; set; }

    [Column("group_stock_picking_wave")]
    public bool? GroupStockPickingWave { get; set; }

    [Column("group_stock_storage_categories")]
    public bool? GroupStockStorageCategories { get; set; }

    [Column("pos_iface_start_categ_id")]
    public Guid? PosIfaceStartCategId { get; set; }

    [Column("pos_proxy_ip")]
    public string? PosProxyIp { get; set; }

    [Column("module_pos_mercury")]
    public bool? ModulePosMercury { get; set; }

    [Column("pos_iface_customer_facing_display_via_proxy")]
    public bool? PosIfaceCustomerFacingDisplayViaProxy { get; set; }

    [Column("group_display_incoterm")]
    public bool? GroupDisplayIncoterm { get; set; }


    [Column("module_mrp_workorder")]
    public bool? ModuleMrpWorkorder { get; set; }


    [Column("hr_presence_control_login")]
    public bool? HrPresenceControlLogin { get; set; }

    [Column("hr_presence_control_email")]
    public bool? HrPresenceControlEmail { get; set; }

    [Column("hr_presence_control_ip")]
    public bool? HrPresenceControlIp { get; set; }

    [Column("module_hr_attendance")]
    public bool? ModuleHrAttendance { get; set; }


    [Column("expense_alias_prefix")]
    public string? ExpenseAliasPrefix { get; set; }

    [Column("use_mailgateway")]
    public bool? UseMailgateway { get; set; }


    [Column("overtime_start_date")]
    public DateTime? OvertimeStartDate { get; set; }

    [Column("group_attendance_use_pin")]
    public bool? GroupAttendanceUsePin { get; set; }

    [Column("hr_attendance_overtime")]
    public bool? HrAttendanceOvertime { get; set; }


    [Column("module_project_forecast")]
    public bool? ModuleProjectForecast { get; set; }


    [Column("group_subtask_project")]
    public bool? GroupSubtaskProject { get; set; }


    [Column("module_payment_paypal")]
    public bool? ModulePaymentPaypal { get; set; }

    [Column("sale_delivery_settings")]
    public string? SaleDeliverySettings { get; set; }

    [Column("module_website_sale_delivery")]
    public bool? ModuleWebsiteSaleDelivery { get; set; }

    [Column("module_website_sale_digital")]
    public bool? ModuleWebsiteSaleDigital { get; set; }


    [Column("module_website_sale_picking")]
    public bool? ModuleWebsiteSalePicking { get; set; }


    [Column("module_website_event_questions")]
    public bool? ModuleWebsiteEventQuestions { get; set; }

    [Column("module_event_barcode")]
    public bool? ModuleEventBarcode { get; set; }

    [Column("pos_iface_orderline_notes")]
    public bool? PosIfaceOrderlineNotes { get; set; }

    [Column("pos_is_table_management")]
    public bool? PosIsTableManagement { get; set; }

    [Column("module_project_timesheet_synchro")]
    public bool? ModuleProjectTimesheetSynchro { get; set; }

    [Column("reminder_manager_allow")]
    public bool? ReminderManagerAllow { get; set; }

    // [Many2one]
    [ForeignKey("ChartTemplateId")]
    public virtual AccountChartTemplate? ChartTemplateObject { get; set; }

    // [Many2one]
    [ForeignKey("DepositDefaultProductId")]
    public virtual ProductProduct? DepositDefaultProduct { get; set; }

    // [Many2one]
    [ForeignKey("PosIfaceStartCategId")]
    public virtual PosCategory? PosIfaceStartCateg { get; set; }
}
