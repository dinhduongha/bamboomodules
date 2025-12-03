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
                "group_user",
                "group_erp_manager",
                "group_sanitize_override",
                "group_system",
                "group_multi_company",
                "group_multi_currency",
                "group_no_one",
                "group_allow_export",
                "group_partner_manager",
                "group_portal",
                "group_public",
                "default_user_group",
                "group_uom",
            };

            var rolesModules = new List<string>
            {
                "group_delivery_invoice_address",
                "group_account_readonly",
                "group_account_invoice",
                "group_account_basic",
                "group_account_user",
                "group_account_manager",
                "group_account_secured",
                "group_cash_rounding",
                "group_partial_purchase_deductibility",
                "group_validate_bank_account",
                "group_analytic_accounting",
                "group_allow_doc",
                "group_use_lead",
                "group_use_recurring_revenues",
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
                "group_applicant_cv_display",
                "group_hr_timesheet_user",
                "group_hr_timesheet_approver",
                "group_timesheet_manager",
                "im_livechat_group_user",
                "im_livechat_group_manager",
                "group_lunch_user",
                "group_lunch_manager",
                "group_mail_canned_response_admin",
                "group_mail_template_editor",
                "group_mail_notification_type_inbox",
                "group_equipment_manager",
                "marketing_card_group_user",
                "marketing_card_group_manager",
                "group_mass_mailing_user",
                "group_mass_mailing_campaign",
                "group_mrp_user",
                "group_mrp_manager",
                "group_mrp_routings",
                "group_mrp_byproducts",
                "group_unlocked_by_default",
                "group_mrp_reception_report",
                "group_mrp_workorder_dependencies",
                "group_fiscal_year",
                "group_pos_user",
                "group_pos_manager",
                "group_pos_preset",
                "group_product_pricelist",
                "group_product_variant",
                "group_product_manager",
                "group_expiry_date_on_delivery_slip",
                "group_project_user",
                "group_project_manager",
                "group_project_stages",
                "group_project_recurring_tasks",
                "group_project_task_dependencies",
                "group_project_milestone",
                "group_purchase_user",
                "group_purchase_manager",
                "group_warning_purchase",
                "group_send_reminder",
                "group_purchase_alternatives",
                "group_auto_done_setting",
                "group_discount_per_so_line",
                "group_warning_sale",
                "group_proforma_sales",
                "group_sale_order_template",
                "group_sale_salesman",
                "group_sale_salesman_all_leads",
                "group_sale_manager",
                "group_dashboard_manager",
                "group_stock_user",
                "group_stock_manager",
                "group_stock_multi_locations",
                "group_stock_multi_warehouses",
                "group_production_lot",
                "group_stock_lot_print_gs1",
                "group_lot_on_delivery_slip",
                "group_tracking_lot",
                "group_adv_location",
                "group_tracking_owner",
                "group_warning_stock",
                "group_stock_sign_delivery",
                "group_reception_report",
                "group_lot_on_invoice",
                "group_survey_user",
                "group_survey_manager",

                "group_website_restricted_editor",
                "group_website_designer",
                "website_page_controller_expose",
                "group_multi_website",
                "group_show_uom_price",
                "group_product_price_comparison",
                "group_product_feed",
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
                    "manager",
                    "group_user",
                    "group_erp_manager",
                    "group_system",
                    "group_multi_company",
                    "group_multi_currency",
                    "group_partner_manager",
                    "group_portal",
                    "group_public"
                    ]);
            }
            else
            {
                rolesName.AddRange([
                    "admin",
                    "owner"
                ]);
                rolesName.AddRange(rolesModules);
            }
            if (rolesName != null)
            {
                foreach (var r in rolesName)
                {
                    if (!r.IsNullOrEmpty())
                    {
                        IdentityRole role = await _identityRoleManager.FindByNameAsync(r);
                        if (role == null)
                        {
                            role = new IdentityRole(_guidGenerator.Create(), r, _currentTenant.Id)
                            {
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

