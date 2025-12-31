using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace Bamboo.Admin.Data
{
    public class RoleUsersDataSeederData
    {
        public string? Module { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool? Enable { get; set; } = true;
    }
    /* 
    * Creates initial roles/users that is needed to property run the application    
    */
    public class RoleUsersDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IConfiguration _configuration;
        private readonly IdentityUserManager _identityUserManager;
        private readonly IdentityRoleManager _identityRoleManager;
        private readonly ICurrentTenant _currentTenant;
        private readonly IGuidGenerator _guidGenerator;
        public RoleUsersDataSeederContributor(
            IConfiguration configuration,
            IdentityUserManager identityUserManager,
            IdentityRoleManager identityRoleManager,
            ICurrentTenant currentTenant, IGuidGenerator guidGenerator)
        {
            _configuration = configuration;
            _identityUserManager = identityUserManager;
            _identityRoleManager = identityRoleManager;
            _currentTenant = currentTenant;
            _guidGenerator = guidGenerator;
        }

        [UnitOfWork]
        public async Task SeedAsync(DataSeedContext context)
        {
            var configurationSection = _configuration.GetSection("App");
            var rolesSection = _configuration.GetSection("Roles");
            var domain = configurationSection["Domain"] ?? "bamboo.io";
            var rolesName = new List<string>();
            rolesName = rolesSection.GetSection("StaticRoles").Get<List<string>>();
            //var roleGroups = rolesSection.GetSection("GroupRoles").Get<List<RoleUsersDataSeederData>>();
            var rolesBase = new List<string>
            {
                "group_system",
            };

            // "group_portal", Khách hàng + vendor
            // "group_public", User chưa đăng nhập

            /// GLOBAL
            /*
            Core / System
            "group_uom",
            "group_multi_company",
            "group_multi_currency",
            "group_fiscal_year"
            "group_product_variant",
            "website_page_controller_expose"
            "group_mail_template_editor"
            "group_account_secured"
            "group_stock_multi_locations"
            "group_stock_multi_warehouses"
            "group_tracking_lot"
            "group_tracking_owner"
            "group_production_lot"
            "group_adv_location"
            "group_mrp_routings"
            "group_mrp_byproducts"
            "group_mrp_workorder_dependencies"
            "group_multi_website"
            */
            // "group_unlocked_by_default",

            /// PER-TENANTS
            // "group_allow_export",
            // "group_allow_doc"

            // "group_use_lead
            // "group_use_recurring_revenues"
            // "group_warning_sale"
            // "group_stock_lot_print_gs1"
            // "group_pos_preset"

            /// Product / Sales
            // "group_product_pricelist",
            // "group_show_uom_price"
            // "group_product_price_comparison"
            // "group_discount_per_so_line"
            // "group_proforma_sales"
            // "group_sale_order_template"

            /// Purchase
            // "group_purchase_alternatives"
            // "group_auto_done_setting"
            // "group_send_reminder"
            // "group_warning_purchase"

            /// Inventory / Stock
            // "group_expiry_date_on_delivery_slip"
            // "group_lot_on_delivery_slip"
            // "group_lot_on_invoice"
            // "group_stock_sign_delivery"
            // "group_reception_report"
            // "group_warning_stock"

            /// Manufacturing (MRP)
            // "group_mrp_reception_report"


            /// Accounting
            // "group_cash_rounding"
            // "group_partial_purchase_deductibility"
            // "group_analytic_accounting"
            // "group_validate_bank_account"

            /// Project
            // "group_project_stages"
            // "group_project_milestone"
            // "group_project_task_dependencies"
            // "group_project_recurring_tasks"

            /// Website
            // "group_product_feed"

            /// Marketing / Communication
            // "group_mass_mailing_campaign"
            // "group_mail_notification_type_inbox"
            // "group_applicant_cv_display",
            // "group_delivery_invoice_address",


            var rolesModules = new List<string>
            {
                "group_erp_manager",
                "group_user",
                //"default_user_group",
                //"group_sanitize_override",
                //"group_no_one",
                "group_partner_manager",

                "group_account_readonly",
                "group_account_invoice",
                "group_account_basic",
                "group_account_user",
                "group_account_manager",
                "group_event_registration_desk",
                "group_event_user",
                "group_event_manager",
                "fleet_group_user",
                "fleet_group_manager",
                "group_hr_user",
                "group_hr_manager",
                "group_hr_attendance_own_reader",
                "group_hr_attendance_officer",
                "group_hr_attendance_user",
                "group_hr_attendance_manager",
                "group_hr_expense_team_approver",
                "group_hr_expense_user",
                "group_hr_expense_manager",
                "group_hr_holidays_responsible",
                "group_hr_holidays_user",
                "group_hr_holidays_manager",
                "group_hr_recruitment_interviewer",
                "group_hr_recruitment_user",
                "group_hr_recruitment_manager",
                "group_hr_timesheet_user",
                "group_hr_timesheet_approver",
                "group_timesheet_manager",
                "im_livechat_group_user",
                "im_livechat_group_manager",
                "group_lunch_user",
                "group_lunch_manager",
                "group_mail_canned_response_admin",
                "group_mail_template_editor",
                "group_equipment_manager",
                "marketing_card_group_user",
                "marketing_card_group_manager",
                "group_mass_mailing_user",
                "group_mrp_user",
                "group_mrp_manager",
                "group_pos_user",
                "group_pos_manager",

                "group_product_manager",
                "group_project_user",
                "group_project_manager",
                "group_purchase_user",
                "group_purchase_manager",
                "group_sale_salesman",
                "group_sale_salesman_all_leads",
                "group_sale_manager",
                "group_dashboard_manager",
                "group_stock_user",
                "group_stock_manager",
                "group_survey_user",
                "group_survey_manager",

                "group_website_restricted_editor",
                "group_website_designer",
                "group_website_slides_officer",
                "group_website_slides_manager",
            };
            rolesName = new List<string>()
            {
                "admin",
                "owner",
                "manager",
                "guest",
                "administration.administrator",
                "administration.settings",
                "sales.administrator",
                "sales.user",
                "sales.user_owner_only",
                "brand.administrator",
                "brand.user",
                "pos.cashier",
                "pos.administrator",
                "pos.user",
                "inventory.administrator",
                "inventory.user",
                "purchase.administrator",
                "purchase.user",
                "accounting.administrator",
                "accounting.advisor",
                "accounting.accountant",
                "accounting.billing",
                "accounting.auditor",
                "project.administrator",
                "project.user",
                "crm.administrator",
                "crm.officer",
                "crm.user",
                "crm.user_owner_only",
                "manufacture.administrator",
                "manufacture.user",
                "hr.lunch.administrator",
                "hr.lunch.user",
                "hr.fleet.administrator",
                "hr.fleet.user",
                "hr.employee.administrator",
                "hr.employee.officer",
                "hr.employee.user",
                "hr.timeoff.administrator",
                "hr.timeoff.officer",
                "hr.contract.administrator",
                "hr.recruitment.administrator",
                "hr.recruitment.officer",
                "hr.expenses.administrator",
                "hr.expenses.all_approver",
                "hr.expenses.team_approver",
                "hr.attendances.administrator",
                "hr.attendances.officer",
                "hr.attendances.user"
            };
            rolesName = new List<string>();
            if (_currentTenant.Id == null)
            {
                rolesName.AddRange([
                    "superadmin",
                    "admin",
                    //"owner",
                    "manager",
                    "guess",
                    "member",
                    // "group_user",
                    // "group_erp_manager",
                    // "group_system",
                    // "group_partner_manager",
                    // "group_portal",
                    // "group_public"
                    ]);
                rolesName.AddRange(rolesBase);
            }
            else
            {
                rolesName.AddRange([
                    "admin",
                    "owner",
                    //"user"
                ]);
                rolesName.AddRange(rolesModules);
            }
            if (rolesName != null)
            {
                var rolesDefault = new List<string>()
                {
                    "group_user"
                };
                foreach (var r in rolesName)
                {
                    if (!r.IsNullOrEmpty())
                    {
                        IdentityRole role = await _identityRoleManager.FindByNameAsync(r);
                        if (role == null)
                        {

                            role = new IdentityRole(_guidGenerator.Create(), r, _currentTenant.Id)
                            {
                                IsDefault = rolesDefault.Contains(r),
                                IsStatic = true,
                                IsPublic = true
                            };
                            try
                            {
                                await _identityRoleManager.CreateAsync(role);
                            }
                            catch (Exception e)
                            {
                                var str = e.Message;
                            }
                        }
                    }
                }
            }
        }
    }
}

