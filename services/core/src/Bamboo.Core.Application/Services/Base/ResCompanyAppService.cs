using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Application.Services;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
using Microsoft.Extensions.Caching.Memory;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;

namespace Bamboo.Core.Application.Services
{
    [Module("BaseModule")]
    public class ResCompanyAppService : GenericApplicationService<ResCompany>, IResCompanyAppService
    {
        private readonly IFormatAddressMixinAppService _formatAddressMixinAppService;
        private readonly IFormatVatLabelMixinAppService _formatVatLabelMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public ResCompanyAppService(IRepository<ResCompany, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IFormatAddressMixinAppService formatAddressMixinAppService, IFormatVatLabelMixinAppService formatVatLabelMixinAppService, IMailThreadAppService mailThreadAppService, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _formatAddressMixinAppService = formatAddressMixinAppService;
            _formatVatLabelMixinAppService = formatVatLabelMixinAppService;
            _mailThreadAppService = mailThreadAppService;
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        protected async Task<ResCompany> AccessibleBranchesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _accessible_branches(self):
            // return self.browse(self.__accessible_branches())
            */
            return default;
        }

        protected async Task<ResCompany> ActionCheckHashIntegrityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def _action_check_hash_integrity(self):
            // return self.env.ref('account.action_report_account_hash_integrity').report_action(self.id)
            */
            return default;
        }

        protected async Task<ResCompany> ActionOpenKioskModeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: res_company.py) ---
            // def _action_open_kiosk_mode(self):
            // return {
            //     'type': 'ir.actions.act_url',
            //     'target': 'self',
            //     'url': f'/hr_attendance/kiosk_mode_menu/{self.env.company.id}',
            // }
            */
            return default;
        }

        protected async Task<ResCompany> ActivateOrCreatePricelistsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: res_company.py) ---
            // def _activate_or_create_pricelists(self):
            // """ Manage the default pricelists for needed companies. """
            // if self.env.context.get('disable_company_pricelist_creation'):
            //     return
            // 
            // if self.env.user.has_group('product.group_product_pricelist'):
            //     companies = self or self.env['res.company'].search([])
            //     ProductPricelist = self.env['product.pricelist'].sudo()
            //     # Activate existing default pricelists
            //     default_pricelists_sudo = ProductPricelist.with_context(active_test=False).search(
            //         [('item_ids', '=', False), ('company_id', 'in', companies.ids)]
            //     ).filtered(lambda pl: pl.currency_id == pl.company_id.currency_id)
            //     default_pricelists_sudo.action_unarchive()
            //     companies_without_pricelist = companies.filtered(
            //         lambda c: c.id not in default_pricelists_sudo.company_id.ids
            //     )
            //     # Create missing default pricelists
            //     ProductPricelist.create([
            //         company._get_default_pricelist_vals() for company in companies_without_pricelist
            //     ])
            */
            return default;
        }

        protected async Task<ResCompany> AllBranchesSelectedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _all_branches_selected(self):
            // """Return whether or all the branches of the companies in self are selected.
            // 
            // Is ``True`` if all the branches, and only those, are selected.
            // Can be used when some actions only make sense for whole companies regardless of the
            // branches.
            // """
            // return self == self.sudo().search([('id', 'child_of', self.root_id.ids)])
            */
            return default;
        }

        public async Task<ResCompany> AllCompanyBranchesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def action_all_company_branches(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _('Branches'),
            //     'res_model': 'res.company',
            //     'domain': [('parent_id', '=', self.id)],
            //     'context': {
            //         'active_test': False,
            //         'default_parent_id': self.id,
            //     },
            //     'views': [[False, 'list'], [False, 'kanban'], [False, 'form']],
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResCompany> CacheInvalidationFieldsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def cache_invalidation_fields(self):
            // # EXTENDS base
            // invalidation_fields = super().cache_invalidation_fields()
            // invalidation_fields.add('check_account_audit_trail')
            // return invalidation_fields
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def cache_invalidation_fields(self):
            // # This list is not well defined and tests should be improved
            // return {
            //     'active', # user._get_company_ids and other potential cached search
            //     'sequence', # user._get_company_ids and other potential cached search
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResCompany> ChartTemplateSelectionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def _chart_template_selection(self):
            // return self.env['account.chart.template']._select_chart_template(self.country_id)
            */
            return default;
        }

        protected async Task<ResCompany> CheckAccountPeppolPhoneNumberInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py) ---
            // def _check_account_peppol_phone_number(self):
            // for company in self:
            //     if company.account_peppol_phone_number:
            //         company._sanitize_peppol_phone_number()
            */
            return default;
        }

        protected async Task<ResCompany> CheckActiveInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: res_company.py) ---
            // def _check_active(self):
            // super()._check_active()
            // for company in self:
            //     if not company.active and company.website_id:
            //         raise ValidationError(_(
            //             'The company “%(company_name)s” cannot be archived because it has a linked website “%(website_name)s”.'
            //             '\nChange that website\'s company first.',
            //             company_name=company.name,
            //             website_name=company.website_id.name
            //         ))
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _check_active(self):
            // for company in self:
            //     if not company.active:
            //         company_active_users = self.env['res.users'].search_count([
            //             ('company_id', '=', company.id),
            //             ('active', '=', True),
            //         ])
            //         if company_active_users:
            //             # You cannot disable companies with active users
            //             raise ValidationError(_(
            //                 'The company %(company_name)s cannot be archived because it is still used '
            //                 'as the default company of %(active_users)s users.',
            //                 company_name=company.name,
            //                 active_users=company_active_users,
            //             ))
            */
            return default;
        }

        protected async Task<ResCompany> CheckAuditTrailRecordsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def _check_audit_trail_records(self):
            // if not self.check_account_audit_trail:
            //     move_count = self.env['account.move'].search_count([('company_id', '=', self.id)], limit=1)
            //     if move_count:
            //         raise UserError(_("Can't disable audit trail when there are existing records."))
            */
            return default;
        }

        protected async Task<ResCompany> CheckFiscalyearLastDayInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def _check_fiscalyear_last_day(self):
            // # if the user explicitly chooses the 29th of February we allow it:
            // # there is no "fiscalyear_last_year" so we do not know his intentions.
            // for rec in self:
            //     if rec.fiscalyear_last_day == 29 and rec.fiscalyear_last_month == '2':
            //         continue
            // 
            //     if rec.account_opening_date:
            //         year = rec.account_opening_date.year
            //     else:
            //         year = datetime.now().year
            // 
            //     max_day = calendar.monthrange(year, int(rec.fiscalyear_last_month))[1]
            //     if rec.fiscalyear_last_day > max_day:
            //         raise ValidationError(_("Invalid fiscal year last day"))
            */
            return default;
        }

        protected async Task<ResCompany> CheckHashIntegrityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def _check_hash_integrity(self):
            // """Checks that all hashed moves have still the same data as when they were hashed
            // and raises an error with the result.
            // """
            // if not self.env.user.has_group('account.group_account_user'):
            //     raise UserError(_('Please contact your accountant to print the Hash integrity result.'))
            // 
            // journals = self.env['account.journal'].search(self.env['account.journal']._check_company_domain(self))
            // results = []
            // 
            // for journal in journals:
            //     restricted_by_hash_table_flag = 'V' if journal.restrict_mode_hash_table else 'X'
            //     # We need the `sudo()` to ensure that all the moves are searched, no matter the user's access rights.
            //     # This is required in order to generate consistent hashes.
            //     # It is not an issue, since the data is only used to compute a hash and not to return the actual values.
            //     query = self.env['account.move'].sudo()._search(
            //         domain=[
            //             ('journal_id', '=', journal.id),
            //             ('inalterable_hash', '!=', False),
            //         ],
            //         order="secure_sequence_number ASC NULLS LAST, sequence_prefix, sequence_number ASC",
            //     )
            //     prefix2result = defaultdict(lambda: {
            //         'first_move': self.env['account.move'],
            //         'last_move': self.env['account.move'],
            //         'corrupted_move': self.env['account.move'],
            //     })
            //     last_move = self.env['account.move']
            //     self.env.execute_query(SQL("DECLARE hashed_moves CURSOR FOR %s", query.select()))
            //     while move_ids := self.env.execute_query(SQL("FETCH %s FROM hashed_moves", INTEGRITY_HASH_BATCH_SIZE)):
            //         self.env.invalidate_all()
            //         moves = self.env['account.move'].browse(move_id[0] for move_id in move_ids)
            //         if not moves and not last_move:
            //             results.append({
            //                 'journal_name': journal.name,
            //                 'restricted_by_hash_table': restricted_by_hash_table_flag,
            //                 'status': 'no_data',
            //                 'msg_cover': _('There is no journal entry flagged for accounting data inalterability yet.'),
            //             })
            //             continue
            // 
            //         current_hash_version = 1
            //         for move in moves:
            //             prefix_result = prefix2result[move.sequence_prefix]
            //             if prefix_result['corrupted_move']:
            //                 continue
            //             previous_move = prefix_result['last_move'] if not move.secure_sequence_number else last_move
            //             previous_hash = previous_move.inalterable_hash or ""
            //             computed_hash = move.with_context(hash_version=current_hash_version)._calculate_hashes(previous_hash)[move]
            //             while move.inalterable_hash != computed_hash and current_hash_version < MAX_HASH_VERSION:
            //                 current_hash_version += 1
            //                 computed_hash = move.with_context(hash_version=current_hash_version)._calculate_hashes(previous_hash)[move]
            //             if move.inalterable_hash != computed_hash:
            //                 prefix_result['corrupted_move'] = move
            //                 continue
            //             if not prefix_result['first_move']:
            //                 prefix_result['first_move'] = move
            //             prefix_result['last_move'] = move
            //             last_move = move
            // 
            //     self.env.execute_query(SQL("CLOSE hashed_moves"))
            // 
            //     for prefix, prefix_result in prefix2result.items():
            //         if corrupted_move := prefix_result['corrupted_move']:
            //             results.append({
            //                 'restricted_by_hash_table': restricted_by_hash_table_flag,
            //                 'journal_name': f"{journal.name} ({prefix}...)",
            //                 'status': 'corrupted',
            //                 'msg_cover': _(
            //                     "Corrupted data on journal entry with id %(id)s (%(name)s).",
            //                     id=corrupted_move.id,
            //                     name=corrupted_move.name,
            //                 ),
            //             })
            //         else:
            //             results.append({
            //                 'restricted_by_hash_table': restricted_by_hash_table_flag,
            //                 'journal_name': f"{journal.name} ({prefix}...)",
            //                 'status': 'verified',
            //                 'msg_cover': _("Entries are correctly hashed"),
            //                 'first_move_name': prefix_result['first_move'].name,
            //                 'first_hash': prefix_result['first_move'].inalterable_hash,
            //                 'first_move_date': format_date(self.env, prefix_result['first_move'].date),
            //                 'last_move_name': prefix_result['last_move'].name,
            //                 'last_hash': prefix_result['last_move'].inalterable_hash,
            //                 'last_move_date': format_date(self.env, prefix_result['last_move'].date),
            //             })
            // 
            // return {
            //     'results': results,
            //     'printing_date': format_date(self.env, fields.Date.context_today(self)),
            // }
            */
            return default;
        }

        protected async Task<ResCompany> CheckHrPresenceControlInternalAsync(object at_install)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: res_company.py) ---
            // def _check_hr_presence_control(self, at_install):
            // companies = self.env.companies
            // for company in companies:
            //     if at_install and company.hr_presence_control_login:
            //         company.hr_presence_control_attendance = True
            //     if not at_install and company.hr_presence_control_attendance:
            //         company.hr_presence_control_login = True
            */
            return default;
        }

        protected async Task<ResCompany> CheckInternalProjectIdCompanyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: res_company.py) ---
            // def _check_internal_project_id_company(self):
            // if self.filtered(lambda company: company.internal_project_id and company.internal_project_id.sudo().company_id != company):
            //     raise ValidationError(_('The Internal Project of a company should be in that company.'))
            */
            return default;
        }

        protected async Task<ResCompany> CheckPeppolEndpointInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py) ---
            // def _check_peppol_endpoint(self):
            // for company in self:
            //     if not company.peppol_endpoint:
            //         continue
            //     if not company._check_peppol_endpoint_number(PEPPOL_ENDPOINT_RULES):
            //         raise ValidationError(_("The Peppol endpoint identification number is not correct."))
            */
            return default;
        }

        protected async Task<ResCompany> CheckPeppolEndpointNumberInternalAsync(object warning)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py) ---
            // def _check_peppol_endpoint_number(self, warning=False):
            // self.ensure_one()
            // peppol_dict = PEPPOL_ENDPOINT_WARNINGS if warning else PEPPOL_ENDPOINT_RULES
            // 
            // return True if (endpoint_rule := peppol_dict.get(self.peppol_eas)) is None else endpoint_rule(self.peppol_endpoint)
            */
            return default;
        }

        protected async Task<ResCompany> CheckPeppolPurchaseJournalIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py) ---
            // def _check_peppol_purchase_journal_id(self):
            // for company in self:
            //     if company.peppol_purchase_journal_id and company.peppol_purchase_journal_id.type != 'purchase':
            //         raise ValidationError(_("A purchase journal must be used to receive Peppol documents."))
            */
            return default;
        }

        protected async Task<ResCompany> CheckPhonenumbersImportInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py) ---
            // def _check_phonenumbers_import(self):
            // if not phonenumbers:
            //     raise ValidationError(_("Please install the phonenumbers library."))
            */
            return default;
        }

        protected async Task<ResCompany> CheckPrepaymentPercentInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: res_company.py) ---
            // def _check_prepayment_percent(self):
            // for company in self:
            //     if company.portal_confirmation_pay and not (0 < company.prepayment_percent <= 1.0):
            //         raise ValidationError(_("Prepayment percentage must be a valid percentage."))
            */
            return default;
        }

        protected async Task<ResCompany> CheckRootDelegatedFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _check_root_delegated_fields(self):
            // for company in self:
            //     if company.parent_id:
            //         for fname in company._get_company_root_delegated_field_names():
            //             if company[fname] != company.parent_id[fname]:
            //                 description = self.env['ir.model.fields']._get("res.company", fname).field_description
            //                 raise ValidationError(_("The %s of a subsidiary must be the same as it's root company.", description))
            */
            return default;
        }

        protected async Task<ResCompany> CheckSetAccountPriceIncludeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def _check_set_account_price_include(self):
            // if any(company.sudo()._existing_accounting() for company in self):
            //     raise ValidationError("Cannot change Price Tax computation method on a company that has already started invoicing.")
            */
            return default;
        }

        protected async Task<ResCompany> CompanyDefaultGetInternalAsync(object @object, object field)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _company_default_get(self, object=False, field=False):
            // """ Returns the user's company
            //     - Deprecated
            // """
            // _logger.warning("The method '_company_default_get' on res.company is deprecated and shouldn't be used anymore")
            // return self.env.company
            */
            return default;
        }

        protected async Task<ResCompany> ComputeAccountEnabledTaxCountryIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def _compute_account_enabled_tax_country_ids(self):
            // for record in self:
            //     if record not in self.env.user.company_ids:
            //         # can have access to the company form without having access to its content (see base.res_company_rule_erp_manager)
            //         record.account_enabled_tax_country_ids = False
            //         continue
            //     foreign_vat_fpos = self.env['account.fiscal.position'].search([
            //         *self.env['account.fiscal.position']._check_company_domain(record),
            //         ('foreign_vat', '!=', False)
            //     ])
            //     record.account_enabled_tax_country_ids = foreign_vat_fpos.country_id + record.account_fiscal_country_id
            */
            return default;
        }

        protected async Task<ResCompany> ComputeAccountPeppolContactEmailInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py) ---
            // def _compute_account_peppol_contact_email(self):
            // for company in self:
            //     if not company.account_peppol_contact_email:
            //         company.account_peppol_contact_email = company.email
            */
            return default;
        }

        protected async Task<ResCompany> ComputeAccountPeppolPhoneNumberInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py) ---
            // def _compute_account_peppol_phone_number(self):
            // for company in self:
            //     if not company.account_peppol_phone_number:
            //         try:
            //             # precompute only if it's a valid phone number
            //             company._sanitize_peppol_phone_number(company.phone)
            //             company.account_peppol_phone_number = company.phone
            //         except ValidationError:
            //             continue
            */
            return default;
        }

        public async Task<ResCompany> ComputeAccountTaxFiscalCountryAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def compute_account_tax_fiscal_country(self):
            // for record in self:
            //     if not record.account_fiscal_country_id:
            //         record.account_fiscal_country_id = record.country_id
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResCompany> ComputeAddressInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _compute_address(self):
            // for company in self.filtered(lambda company: company.partner_id):
            //     address_data = company.partner_id.sudo().address_get(adr_pref=['contact'])
            //     if address_data['contact']:
            //         partner = company.partner_id.browse(address_data['contact']).sudo()
            //         company.update(company._get_company_address_update(partner))
            */
            return default;
        }

        protected async Task<ResCompany> ComputeAttendanceKioskUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: res_company.py) ---
            // def _compute_attendance_kiosk_url(self):
            // for company in self:
            //     company.attendance_kiosk_url = url_join(self.env['res.company'].get_base_url(), '/hr_attendance/%s' % company.attendance_kiosk_key)
            */
            return default;
        }

        protected async Task<ResCompany> ComputeBounceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_company.py) ---
            // def _compute_bounce(self):
            // self.bounce_email = ''
            // self.bounce_formatted = ''
            // 
            // for company in self.filtered('alias_domain_id'):
            //     bounce_email = company.alias_domain_id.bounce_email
            //     company.bounce_email = bounce_email
            //     company.bounce_formatted = tools.formataddr((company.name, bounce_email))
            */
            return default;
        }

        protected async Task<ResCompany> ComputeCatchallInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_company.py) ---
            // def _compute_catchall(self):
            // self.catchall_email = ''
            // self.catchall_formatted = ''
            // 
            // for company in self.filtered('alias_domain_id'):
            //     catchall_email = company.alias_domain_id.catchall_email
            //     company.catchall_email = catchall_email
            //     company.catchall_formatted = tools.formataddr((company.name, catchall_email))
            */
            return default;
        }

        protected async Task<ResCompany> ComputeColorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _compute_color(self):
            // for company in self:
            //     company.color = company.root_id.partner_id.color or (company.root_id._origin.id % 12)
            */
            return default;
        }

        protected async Task<ResCompany> ComputeCompanyRegistryPlaceholderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def _compute_company_registry_placeholder(self):
            // """ Provides a dynamic placeholder on the company registry field for countries that may need it.
            // Add your country and the value you want in the _ref_company_registry map in the partner.py file.
            // """
            // for company in self:
            //     country_code = (company.account_fiscal_country_id or company.country_id).code or ''
            //     company.company_registry_placeholder = _ref_company_registry.get(country_code.lower(), '')
            */
            return default;
        }

        protected async Task<ResCompany> ComputeCompanyVatPlaceholderInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def _compute_company_vat_placeholder(self):
            // for company in self:
            //     placeholder = _("/ if not applicable")
            //     if company.country_id or company.account_fiscal_country_id:
            //         expected_vat = _ref_vat.get(
            //             (company.country_id.code or company.account_fiscal_country_id.code).lower()
            //         )
            //         if expected_vat:
            //             placeholder = _("%s, or / if not applicable", expected_vat)
            // 
            //     company.company_vat_placeholder = placeholder
            */
            return default;
        }

        protected async Task<ResCompany> ComputeEmailFormattedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_company.py) ---
            // def _compute_email_formatted(self):
            // for company in self:
            //     if company.partner_id.email_formatted:
            //         company.email_formatted = company.partner_id.email_formatted
            //     elif company.catchall_formatted:
            //         company.email_formatted = company.catchall_formatted
            //     else:
            //         company.email_formatted = ''
            */
            return default;
        }

        protected async Task<ResCompany> ComputeEmailPrimaryColorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_company.py) ---
            // def _compute_email_primary_color(self):
            // """ When updating documents layout colors, force usage of same colors
            // for emails as it is considered as base colors for all communication.
            // Inverse is not true, people may change email colors without changing
            // their overall layout. """
            // for company in self:
            //     company.email_primary_color = company.primary_color or '#000000'
            */
            return default;
        }

        protected async Task<ResCompany> ComputeEmailSecondaryColorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_company.py) ---
            // def _compute_email_secondary_color(self):
            // """ When updating documents layout colors, force usage of same colors
            // for emails as it is considered as base colors for all communication.
            // Inverse is not true, people may change email colors without changing
            // their overall layout. """
            // for company in self:
            //     company.email_secondary_color = company.secondary_color or '#875A7B'
            */
            return default;
        }

        protected async Task<ResCompany> ComputeEmptyCompanyDetailsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _compute_empty_company_details(self):
            // # In recent change when an html field is empty a <p> balise remains with a <br> in it,
            // # but when company details is empty we want to put the info of the company
            // for record in self:
            //     record.is_company_details_empty = not html2plaintext(record.company_details or '')
            */
            return default;
        }

        public async Task<ResCompany> ComputeFiscalyearDatesAsync(Guid id, ResCompanyComputeFiscalyearDatesRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def compute_fiscalyear_dates(self, current_date):
            // """
            // Returns the dates of the fiscal year containing the provided date for this company.
            // :return: A dictionary containing:
            //     * date_from
            //     * date_to
            // """
            // self.ensure_one()
            // date_from, date_to = date_utils.get_fiscal_year(current_date, day=self.fiscalyear_last_day, month=int(self.fiscalyear_last_month))
            // return {'date_from': date_from, 'date_to': date_to}
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResCompany> ComputeInvoiceTermsHtmlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def _compute_invoice_terms_html(self):
            // for company in self.filtered(lambda company: is_html_empty(company.invoice_terms_html) and company.terms_type == 'html'):
            //     html = self.env['ir.qweb']._render('account.account_default_terms_and_conditions',
            //                 {'company_name': company.name, 'company_country': company.country_id.name},
            //                 raise_if_not_found=False)
            //     if html:
            //         company.invoice_terms_html = html
            */
            return default;
        }

        protected async Task<ResCompany> ComputeLogoWebInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _compute_logo_web(self):
            // for company in self:
            //     img = company.partner_id.image_1920
            //     company.logo_web = img and base64.b64encode(tools.image_process(base64.b64decode(img), size=(180, 0)))
            */
            return default;
        }

        protected async Task<ResCompany> ComputeMultiVatForeignCountryInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def _compute_multi_vat_foreign_country(self):
            // company_to_foreign_vat_country = {
            //     company.id: country_ids
            //     for company, country_ids in self.env['account.fiscal.position']._read_group(
            //         domain=[
            //             *self.env['account.fiscal.position']._check_company_domain(self),
            //             ('foreign_vat', '!=', False),
            //         ],
            //         groupby=['company_id'],
            //         aggregates=['country_id:array_agg'],
            //     )
            // }
            // for company in self:
            //     company.multi_vat_foreign_country_ids = self.env['res.country'].browse(company_to_foreign_vat_country.get(company.id))
            */
            return default;
        }

        protected async Task<ResCompany> ComputeParentIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _compute_parent_ids(self):
            // for company in self.with_context(active_test=False):
            //     company.parent_ids = self.browse(int(id) for id in company.parent_path.split('/') if id) if company.parent_path else company
            //     company.root_id = company.parent_ids[0]
            */
            return default;
        }

        protected async Task<ResCompany> ComputePeppolPurchaseJournalIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py) ---
            // def _compute_peppol_purchase_journal_id(self):
            // for company in self:
            //     if not company.peppol_purchase_journal_id and company.account_peppol_proxy_state not in ('not_registered', 'rejected'):
            //         company.peppol_purchase_journal_id = self.env['account.journal'].search([
            //             *self.env['account.journal']._check_company_domain(company),
            //             ('type', '=', 'purchase'),
            //         ], limit=1)
            //         company.peppol_purchase_journal_id.is_peppol_journal = True
            //     else:
            //         company.peppol_purchase_journal_id = company.peppol_purchase_journal_id
            */
            return default;
        }

        protected async Task<ResCompany> ComputeUninstalledL10nModuleIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _compute_uninstalled_l10n_module_ids(self):
            // # This will only compute uninstalled modules with auto-install without recursion,
            // # the rest will eventually be handled by `button_install`
            // self.env['ir.module.module'].flush_model(['auto_install', 'country_ids', 'dependencies_id'])
            // self.env['ir.module.module.dependency'].flush_model()
            // self.env.cr.execute("""
            //     SELECT country.id,
            //            ARRAY_AGG(module.id)
            //       FROM ir_module_module module,
            //            res_country country
            //      WHERE module.auto_install
            //        AND state NOT IN %(install_states)s
            //        AND NOT EXISTS (
            //                SELECT 1
            //                  FROM ir_module_module_dependency d
            //                  JOIN ir_module_module mdep ON (d.name = mdep.name)
            //                 WHERE d.module_id = module.id
            //                   AND d.auto_install_required
            //                   AND mdep.state NOT IN %(install_states)s
            //            )
            //        AND EXISTS (
            //                SELECT 1
            //                  FROM module_country mc
            //                 WHERE mc.module_id = module.id
            //                   AND mc.country_id = country.id
            //            )
            //        AND country.id = ANY(%(country_ids)s)
            //   GROUP BY country.id
            // """, {
            //     'country_ids': self.country_id.ids,
            //     'install_states': ('installed', 'to install', 'to upgrade'),
            // })
            // mapping = dict(self.env.cr.fetchall())
            // for company in self:
            //     company.uninstalled_l10n_module_ids = self.env['ir.module.module'].browse(mapping.get(company.country_id.id))
            */
            return default;
        }

        protected async Task<ResCompany> ComputeUserFiscalyearLockDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def _compute_user_fiscalyear_lock_date(self):
            // ignore_exceptions = bool(self.env.context.get('ignore_exceptions', False))
            // for company in self:
            //     company.user_fiscalyear_lock_date = company._get_user_lock_date('fiscalyear_lock_date', ignore_exceptions)
            */
            return default;
        }

        protected async Task<ResCompany> ComputeUserHardLockDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def _compute_user_hard_lock_date(self):
            // for company in self:
            //     company.user_hard_lock_date = max(
            //         c.hard_lock_date or date.min
            //         for c in company.with_context(active_test=False).sudo().parent_ids
            //     )
            */
            return default;
        }

        protected async Task<ResCompany> ComputeUserPurchaseLockDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def _compute_user_purchase_lock_date(self):
            // ignore_exceptions = bool(self.env.context.get('ignore_exceptions', False))
            // for company in self:
            //     company.user_purchase_lock_date = company._get_user_lock_date('purchase_lock_date', ignore_exceptions)
            */
            return default;
        }

        protected async Task<ResCompany> ComputeUserSaleLockDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def _compute_user_sale_lock_date(self):
            // ignore_exceptions = bool(self.env.context.get('ignore_exceptions', False))
            // for company in self:
            //     company.user_sale_lock_date = company._get_user_lock_date('sale_lock_date', ignore_exceptions)
            */
            return default;
        }

        protected async Task<ResCompany> ComputeUserTaxLockDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def _compute_user_tax_lock_date(self):
            // ignore_exceptions = bool(self.env.context.get('ignore_exceptions', False))
            // for company in self:
            //     company.user_tax_lock_date = company._get_user_lock_date('tax_lock_date', ignore_exceptions)
            */
            return default;
        }

        protected async Task<ResCompany> ComputeUsesDefaultLogoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _compute_uses_default_logo(self):
            // default_logo = self._get_logo()
            // for company in self:
            //     company.uses_default_logo = not company.logo or company.logo == default_logo
            */
            return default;
        }

        protected async Task<ResCompany> ComputeWebsiteIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: res_company.py) ---
            // def _compute_website_id(self):
            // for company in self:
            //     company.website_id = self.env['website'].search([('company_id', '=', company.id)], limit=1)
            */
            return default;
        }

        public override async Task<ResCompany> CreateAsync(ResCompany entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def create(self, vals_list):
            // companies = super().create(vals_list)
            // for company in companies:
            //     if root_template := company.parent_ids[0].chart_template:
            //         def try_loading(company=company, root_template=root_template):
            //             self.env['account.chart.template']._load(
            //                 root_template,
            //                 company,
            //                 install_demo=False,
            //             )
            //         self.env.cr.precommit.add(try_loading)
            // return companies
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     self._sanitize_peppol_endpoint_in_values(vals)
            // 
            // res = super().create(vals_list)
            // if res:
            //     for company in res:
            //         self.env['ir.default'].sudo().set(
            //             'res.partner',
            //             'peppol_verification_state',
            //             'not_verified',
            //             company_id=company.id,
            //         )
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: res_company.py) ---
            // def create(self, values):
            // company = super(ResCompany, self).create(values)
            // # use sudo as the user could have the right to create a company
            // # but not to create a project. On the other hand, when the company
            // # is created, it is not in the allowed_company_ids on the env
            // company.sudo()._create_internal_project_task()
            // return company
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_company.py) ---
            // def create(self, vals_list):
            // res = super().create(vals_list)
            // if not getattr(threading.current_thread(), 'testing', False):
            //     res.iap_enrich_auto()
            // return res
            --- ODOO METHOD SOURCE (MODULE: product, FILE: res_company.py) ---
            // def create(self, vals_list):
            // companies = super().create(vals_list)
            // companies._activate_or_create_pricelists()
            // return companies
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: res_company.py) ---
            // def create(self, vals_list):
            // companies = super().create(vals_list)
            // companies_without_calendar = companies.filtered(lambda c: not c.resource_calendar_id)
            // if companies_without_calendar:
            //     companies_without_calendar.sudo()._create_resource_calendar()
            // # calendar created from form view: no company_id set because record was still not created
            // for company in companies:
            //     if not company.resource_calendar_id.company_id:
            //         company.resource_calendar_id.company_id = company.id
            // return companies
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: res_company.py) ---
            // def create(self, vals_list):
            // companies = super().create(vals_list)
            // # Unarchive inter-company location when multi-company is enabled.
            // inter_company_location = self.env.ref('stock.stock_location_inter_company')
            // if not inter_company_location.active:
            //     inter_company_location.sudo().write({'active': True})
            // for company in companies:
            //     company.sudo()._create_per_company_locations()
            //     company.sudo()._create_per_company_sequences()
            //     company.sudo()._create_per_company_picking_types()
            //     company.sudo()._create_per_company_rules()
            //     company.sudo()._set_per_company_inter_company_locations(inter_company_location)
            // test_mode = getattr(threading.current_thread(), 'testing', False)
            // if test_mode:
            //     self.env['stock.warehouse'].sudo().create([{'company_id': company.id} for company in companies])
            // return companies
            --- ODOO METHOD SOURCE (MODULE: web, FILE: models.py) ---
            // def create(self, vals_list):
            // companies = super().create(vals_list)
            // style_fields = {'external_report_layout_id', 'font', 'primary_color', 'secondary_color'}
            // if any(not style_fields.isdisjoint(values) for values in vals_list):
            //     self._update_asset_style()
            // return companies
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def create(self, vals_list):
            // 
            // # create missing partners
            // no_partner_vals_list = [
            //     vals
            //     for vals in vals_list
            //     if vals.get('name') and not vals.get('partner_id')
            // ]
            // if no_partner_vals_list:
            //     partners = self.env['res.partner'].with_context(default_parent_id=False).create([
            //         {
            //             'name': vals['name'],
            //             'is_company': True,
            //             'image_1920': vals.get('logo'),
            //             'email': vals.get('email'),
            //             'phone': vals.get('phone'),
            //             'website': vals.get('website'),
            //             'vat': vals.get('vat'),
            //             'country_id': vals.get('country_id'),
            //         }
            //         for vals in no_partner_vals_list
            //     ])
            //     # compute stored fields, for example address dependent fields
            //     partners.flush_model()
            //     for vals, partner in zip(no_partner_vals_list, partners):
            //         vals['partner_id'] = partner.id
            // 
            // for vals in vals_list:
            //     # Copy delegated fields from root to branches
            //     if parent := self.browse(vals.get('parent_id')):
            //         for fname in self._get_company_root_delegated_field_names():
            //             vals.setdefault(fname, self._fields[fname].convert_to_write(parent[fname], parent))
            // 
            // self.env.registry.clear_cache()
            // companies = super().create(vals_list)
            // 
            // # The write is made on the user to set it automatically in the multi company group.
            // if companies:
            //     (self.env.user | self.env['res.users'].browse(SUPERUSER_ID)).write({
            //         'company_ids': [Command.link(company.id) for company in companies],
            //     })
            // 
            // # Make sure that the selected currencies are enabled
            // companies.currency_id.sudo().filtered(lambda c: not c.active).active = True
            // 
            // companies_needs_l10n = companies.filtered('country_id')
            // if companies_needs_l10n:
            //     companies_needs_l10n.install_l10n_modules()
            // 
            // return companies
            */
            return await base.CreateAsync(entity, fields);
        }

        protected async Task<ResCompany> CreateDropshipPickingTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_dropshipping, FILE: res_company.py) ---
            // def _create_dropship_picking_type(self):
            // dropship_vals = []
            // for company in self:
            //     sequence = self.env['ir.sequence'].search([
            //         ('code', '=', 'stock.dropshipping'),
            //         ('company_id', '=', company.id),
            //     ])
            //     dropship_vals.append({
            //         'name': 'Dropship',
            //         'company_id': company.id,
            //         'warehouse_id': False,
            //         'sequence_id': sequence.id,
            //         'code': 'dropship',
            //         'default_location_src_id': self.env.ref('stock.stock_location_suppliers').id,
            //         'default_location_dest_id': self.env.ref('stock.stock_location_customers').id,
            //         'sequence_code': 'DS',
            //         'use_existing_lots': False,
            //     })
            // if dropship_vals:
            //     self.env['stock.picking.type'].create(dropship_vals)
            */
            return default;
        }

        protected async Task<ResCompany> CreateDropshipRuleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_dropshipping, FILE: res_company.py) ---
            // def _create_dropship_rule(self):
            // dropship_route = self.env.ref('stock_dropshipping.route_drop_shipping')
            // supplier_location = self.env.ref('stock.stock_location_suppliers')
            // customer_location = self.env.ref('stock.stock_location_customers')
            // 
            // dropship_vals = []
            // for company in self:
            //     dropship_picking_type = self.env['stock.picking.type'].search([
            //         ('company_id', '=', company.id),
            //         ('default_location_src_id.usage', '=', 'supplier'),
            //         ('default_location_dest_id.usage', '=', 'customer'),
            //     ], limit=1, order='sequence')
            //     if not dropship_picking_type:
            //         continue
            //     dropship_vals.append({
            //         'name': '%s → %s' % (supplier_location.name, customer_location.name),
            //         'action': 'buy',
            //         'location_dest_id': customer_location.id,
            //         'location_src_id': supplier_location.id,
            //         'procure_method': 'make_to_stock',
            //         'route_id': dropship_route.id,
            //         'picking_type_id': dropship_picking_type.id,
            //         'company_id': company.id,
            //     })
            // if dropship_vals:
            //     self.env['stock.rule'].create(dropship_vals)
            */
            return default;
        }

        protected async Task<ResCompany> CreateDropshipSequenceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_dropshipping, FILE: res_company.py) ---
            // def _create_dropship_sequence(self):
            // dropship_vals = []
            // for company in self:
            //     dropship_vals.append({
            //         'name': 'Dropship (%s)' % company.name,
            //         'code': 'stock.dropshipping',
            //         'company_id': company.id,
            //         'prefix': 'DS/',
            //         'padding': 5,
            //     })
            // if dropship_vals:
            //     self.env['ir.sequence'].create(dropship_vals)
            */
            return default;
        }

        protected async Task<ResCompany> CreateInternalProjectTaskInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: res_company.py) ---
            // def _create_internal_project_task(self):
            // results = []
            // type_ids_ref = self.env.ref('hr_timesheet.internal_project_default_stage', raise_if_not_found=False)
            // type_ids = [(4, type_ids_ref.id)] if type_ids_ref else []
            // for company in self:
            //     company = company.with_company(company)
            //     results += [{
            //         'name': _('Internal'),
            //         'allow_timesheets': True,
            //         'company_id': company.id,
            //         'type_ids': type_ids,
            //         'task_ids': [(0, 0, {
            //             'name': name,
            //             'company_id': company.id,
            //         }) for name in [_('Training'), _('Meeting')]]
            //     }]
            // project_ids = self.env['project.project'].create(results)
            // projects_by_company = {project.company_id.id: project for project in project_ids}
            // for company in self:
            //     company.internal_project_id = projects_by_company.get(company.id, False)
            // return project_ids
            --- ODOO METHOD SOURCE (MODULE: project_timesheet_holidays, FILE: res_company.py) ---
            // def _create_internal_project_task(self):
            // projects = super()._create_internal_project_task()
            // for project in projects:
            //     company = project.company_id
            //     company = company.with_company(company)
            //     if not company.leave_timesheet_task_id:
            //         task = company.env['project.task'].sudo().create({
            //             'name': _('Time Off'),
            //             'project_id': company.internal_project_id.id,
            //             'active': True,
            //             'company_id': company.id,
            //         })
            //         company.write({
            //             'leave_timesheet_task_id': task.id,
            //         })
            // return projects
            */
            return default;
        }

        protected async Task<ResCompany> CreateInventoryLossLocationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: res_company.py) ---
            // def _create_inventory_loss_location(self):
            // parent_location = self.env.ref('stock.stock_location_locations_virtual', raise_if_not_found=False)
            // for company in self:
            //     inventory_loss_location = self.env['stock.location'].create({
            //         'name': 'Inventory adjustment',
            //         'usage': 'inventory',
            //         'location_id': parent_location.id,
            //         'company_id': company.id,
            //     })
            //     self.env['ir.default'].set('product.template', 'property_stock_inventory', inventory_loss_location.id, company_id=company.id)
            */
            return default;
        }

        public async Task<ResCompany> CreateMissingDropshipPickingTypeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_dropshipping, FILE: res_company.py) ---
            // def create_missing_dropship_picking_type(self):
            // company_ids = self.env['res.company'].search([])
            // company_has_dropship_picking_type = (
            //     self.env['stock.picking.type'].search([("code", "=", "dropship")]).company_id
            // )
            // company_todo_picking_type = company_ids - company_has_dropship_picking_type
            // company_todo_picking_type._create_dropship_picking_type()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResCompany> CreateMissingDropshipRuleAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_dropshipping, FILE: res_company.py) ---
            // def create_missing_dropship_rule(self):
            // dropship_route = self.env.ref('stock_dropshipping.route_drop_shipping')
            // 
            // company_ids = self.env['res.company'].search([])
            // company_has_dropship_rule = self.env['stock.rule'].search([('route_id', '=', dropship_route.id)]).mapped('company_id')
            // company_todo_rule = company_ids - company_has_dropship_rule
            // company_todo_rule._create_dropship_rule()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResCompany> CreateMissingDropshipSequenceAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_dropshipping, FILE: res_company.py) ---
            // def create_missing_dropship_sequence(self):
            // company_ids = self.env['res.company'].search([])
            // company_has_dropship_seq = self.env['ir.sequence'].search([('code', '=', 'stock.dropshipping')]).mapped('company_id')
            // company_todo_sequence = company_ids - company_has_dropship_seq
            // company_todo_sequence._create_dropship_sequence()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResCompany> CreateMissingInventoryLossLocationAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: res_company.py) ---
            // def create_missing_inventory_loss_location(self):
            // company_ids  = self.env['res.company'].search([])
            // inventory_loss_product_template_field = self.env['ir.model.fields']._get('product.template', 'property_stock_inventory')
            // companies_having_property = self.env['ir.default'].sudo().search([('field_id', '=', inventory_loss_product_template_field.id)]).mapped('company_id')
            // company_without_property = company_ids - companies_having_property
            // company_without_property._create_inventory_loss_location()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResCompany> CreateMissingProductionLocationAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: res_company.py) ---
            // def create_missing_production_location(self):
            // company_ids  = self.env['res.company'].search([])
            // production_product_template_field = self.env['ir.model.fields']._get('product.template', 'property_stock_production')
            // companies_having_property = self.env['ir.default'].sudo().search([('field_id', '=', production_product_template_field.id)]).mapped('company_id')
            // company_without_property = company_ids - companies_having_property
            // company_without_property._create_production_location()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResCompany> CreateMissingScrapLocationAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: res_company.py) ---
            // def create_missing_scrap_location(self):
            // company_ids  = self.env['res.company'].search([])
            // companies_having_scrap_loc = self.env['stock.location'].search([('scrap_location', '=', True)]).mapped('company_id')
            // company_without_property = company_ids - companies_having_scrap_loc
            // company_without_property._create_scrap_location()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResCompany> CreateMissingScrapSequenceAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: res_company.py) ---
            // def create_missing_scrap_sequence(self):
            // company_ids  = self.env['res.company'].search([])
            // company_has_scrap_seq = self.env['ir.sequence'].search([('code', '=', 'stock.scrap')]).mapped('company_id')
            // company_todo_sequence = company_ids - company_has_scrap_seq
            // company_todo_sequence._create_scrap_sequence()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResCompany> CreateMissingSubcontractingDropshippingPickingTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: res_company.py) ---
            // def _create_missing_subcontracting_dropshipping_picking_type(self):
            // company_ids = self.env['res.company'].search([])
            // company_has_dropship_subcontractor_picking_type = self.env['stock.picking.type'].search([
            //     ('default_location_src_id.usage', '=', 'supplier'),
            //     ('default_location_dest_id', 'in', company_ids.subcontracting_location_id.ids),
            // ]).mapped('company_id')
            // company_todo_picking_type = company_ids - company_has_dropship_subcontractor_picking_type
            // company_todo_picking_type._create_subcontracting_dropshipping_picking_type()
            */
            return default;
        }

        protected async Task<ResCompany> CreateMissingSubcontractingDropshippingRulesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: res_company.py) ---
            // def _create_missing_subcontracting_dropshipping_rules(self):
            // route = self.env.ref('mrp_subcontracting_dropshipping.route_subcontracting_dropshipping')
            // company_ids = self.env['res.company'].search([])
            // company_has_rules = self.env['stock.rule'].search([('route_id', '=', route.id)]).mapped('company_id')
            // company_todo_rules = company_ids - company_has_rules
            // company_todo_rules._create_subcontracting_dropshipping_rules()
            */
            return default;
        }

        protected async Task<ResCompany> CreateMissingSubcontractingDropshippingSequenceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: res_company.py) ---
            // def _create_missing_subcontracting_dropshipping_sequence(self):
            // company_ids = self.env['res.company'].search([])
            // company_has_seq = self.env['ir.sequence'].search([('code', '=', 'mrp.subcontracting.dropshipping')]).mapped('company_id')
            // company_todo_sequence = company_ids - company_has_seq
            // company_todo_sequence._create_subcontracting_dropshipping_sequence()
            */
            return default;
        }

        protected async Task<ResCompany> CreateMissingSubcontractingLocationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_company.py) ---
            // def _create_missing_subcontracting_location(self):
            // company_without_subcontracting_loc = self.env['res.company'].with_context(active_test=False).search(
            //     [('subcontracting_location_id', '=', False)])
            // company_without_subcontracting_loc._create_subcontracting_location()
            */
            return default;
        }

        public async Task<ResCompany> CreateMissingTransitLocationAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: res_company.py) ---
            // def create_missing_transit_location(self):
            // company_without_transit = self.env['res.company'].search([('internal_transit_location_id', '=', False)])
            // company_without_transit._create_transit_location()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResCompany> CreateMissingUnbuildSequencesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: res_company.py) ---
            // def create_missing_unbuild_sequences(self):
            // company_ids  = self.env['res.company'].search([])
            // company_has_unbuild_seq = self.env['ir.sequence'].search([('code', '=', 'mrp.unbuild')]).mapped('company_id')
            // company_todo_sequence = company_ids - company_has_unbuild_seq
            // company_todo_sequence._create_unbuild_sequence()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResCompany> CreateMissingWarehouseAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: res_company.py) ---
            // def create_missing_warehouse(self):
            // """ This hook is used to add a warehouse on the first company of the database
            // """
            // existing_warehouses = self.env['stock.warehouse'].search([])
            // if len(existing_warehouses) == 0:
            //     first_company = self.env['res.company'].search([], limit=1)
            //     self.env['stock.warehouse'].create({
            //         'name': first_company.name,
            //         'code': first_company.name[:5],
            //         'company_id': first_company.id,
            //         'partner_id': first_company.partner_id.id,
            //     })
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResCompany> CreatePerCompanyLocationsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_company.py) ---
            // def _create_per_company_locations(self):
            // super(ResCompany, self)._create_per_company_locations()
            // self._create_subcontracting_location()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: res_company.py) ---
            // def _create_per_company_locations(self):
            // self.ensure_one()
            // self._create_transit_location()
            // self._create_inventory_loss_location()
            // self._create_production_location()
            // self._create_scrap_location()
            */
            return default;
        }

        protected async Task<ResCompany> CreatePerCompanyPickingTypesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: res_company.py) ---
            // def _create_per_company_picking_types(self):
            // super()._create_per_company_picking_types()
            // self._create_subcontracting_dropshipping_picking_type()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: res_company.py) ---
            // def _create_per_company_picking_types(self):
            // self.ensure_one()
            --- ODOO METHOD SOURCE (MODULE: stock_dropshipping, FILE: res_company.py) ---
            // def _create_per_company_picking_types(self):
            // super(ResCompany, self)._create_per_company_picking_types()
            // self._create_dropship_picking_type()
            */
            return default;
        }

        protected async Task<ResCompany> CreatePerCompanyRulesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: res_company.py) ---
            // def _create_per_company_rules(self):
            // res = super()._create_per_company_rules()
            // self._create_subcontracting_dropshipping_rules()
            // return res
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: res_company.py) ---
            // def _create_per_company_rules(self):
            // self.ensure_one()
            --- ODOO METHOD SOURCE (MODULE: stock_dropshipping, FILE: res_company.py) ---
            // def _create_per_company_rules(self):
            // super(ResCompany, self)._create_per_company_rules()
            // self._create_dropship_rule()
            */
            return default;
        }

        protected async Task<ResCompany> CreatePerCompanySequencesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: res_company.py) ---
            // def _create_per_company_sequences(self):
            // super(Company, self)._create_per_company_sequences()
            // self._create_unbuild_sequence()
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: res_company.py) ---
            // def _create_per_company_sequences(self):
            // super()._create_per_company_sequences()
            // self._create_subcontracting_dropshipping_sequence()
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: res_company.py) ---
            // def _create_per_company_sequences(self):
            // self.ensure_one()
            // self._create_scrap_sequence()
            --- ODOO METHOD SOURCE (MODULE: stock_dropshipping, FILE: res_company.py) ---
            // def _create_per_company_sequences(self):
            // super(ResCompany, self)._create_per_company_sequences()
            // self._create_dropship_sequence()
            */
            return default;
        }

        protected async Task<ResCompany> CreateProductionLocationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: res_company.py) ---
            // def _create_production_location(self):
            // parent_location = self.env.ref('stock.stock_location_locations_virtual', raise_if_not_found=False)
            // for company in self:
            //     production_location = self.env['stock.location'].create({
            //         'name': 'Production',
            //         'usage': 'production',
            //         'location_id': parent_location.id,
            //         'company_id': company.id,
            //     })
            //     self.env['ir.default'].set('product.template', 'property_stock_production', production_location.id, company_id=company.id)
            */
            return default;
        }

        protected async Task<ResCompany> CreateResourceCalendarInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: res_company.py) ---
            // def _create_resource_calendar(self):
            // vals_list = [
            //     company._prepare_resource_calendar_values()
            //     for company in self
            // ]
            // resource_calendars = self.env['resource.calendar'].create(vals_list)
            // for company, calendar in zip(self, resource_calendars):
            //     company.resource_calendar_id = calendar
            */
            return default;
        }

        protected async Task<ResCompany> CreateScrapLocationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: res_company.py) ---
            // def _create_scrap_location(self):
            // parent_location = self.env.ref('stock.stock_location_locations_virtual', raise_if_not_found=False)
            // for company in self:
            //     scrap_location = self.env['stock.location'].create({
            //         'name': 'Scrap',
            //         'usage': 'inventory',
            //         'location_id': parent_location.id,
            //         'company_id': company.id,
            //         'scrap_location': True,
            //     })
            */
            return default;
        }

        protected async Task<ResCompany> CreateScrapSequenceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: res_company.py) ---
            // def _create_scrap_sequence(self):
            // scrap_vals = []
            // for company in self:
            //     scrap_vals.append({
            //         'name': '%s Sequence scrap' % company.name,
            //         'code': 'stock.scrap',
            //         'company_id': company.id,
            //         'prefix': 'SP/',
            //         'padding': 5,
            //         'number_next': 1,
            //         'number_increment': 1
            //     })
            // if scrap_vals:
            //     self.env['ir.sequence'].create(scrap_vals)
            */
            return default;
        }

        protected async Task<ResCompany> CreateSubcontractingDropshippingPickingTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: res_company.py) ---
            // def _create_subcontracting_dropshipping_picking_type(self):
            // pick_type_vals = []
            // for company in self:
            //     sequence = self.env['ir.sequence'].search([
            //         ('code', '=', 'mrp.subcontracting.dropshipping'),
            //         ('company_id', '=', company.id),
            //     ])
            //     pick_type_vals.append({
            //         'name': 'Dropship Subcontractor',
            //         'company_id': company.id,
            //         'warehouse_id': False,
            //         'sequence_id': sequence.id,
            //         'code': 'dropship',
            //         'default_location_src_id': self.env.ref('stock.stock_location_suppliers').id,
            //         'default_location_dest_id': company.subcontracting_location_id.id,
            //         'sequence_code': 'DSC',
            //         'use_existing_lots': False,
            //     })
            // if pick_type_vals:
            //     pick_type_ids = self.env['stock.picking.type'].create(pick_type_vals)
            //     for pick_type in pick_type_ids:
            //         pick_type.company_id.dropship_subcontractor_pick_type_id = pick_type.id
            */
            return default;
        }

        protected async Task<ResCompany> CreateSubcontractingDropshippingRulesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: res_company.py) ---
            // def _create_subcontracting_dropshipping_rules(self):
            // route = self.env.ref('mrp_subcontracting_dropshipping.route_subcontracting_dropshipping')
            // supplier_location = self.env.ref('stock.stock_location_suppliers')
            // vals = []
            // for company in self:
            //     subcontracting_location = company.subcontracting_location_id
            //     dropship_picking_type = self.env['stock.picking.type'].search([
            //         ('company_id', '=', company.id),
            //         ('default_location_src_id.usage', '=', 'supplier'),
            //         ('default_location_dest_id', '=', subcontracting_location.id),
            //     ], limit=1, order='sequence')
            //     if dropship_picking_type:
            //         vals.append({
            //             'name': '%s → %s' % (supplier_location.name, subcontracting_location.name),
            //             'action': 'buy',
            //             'location_dest_id': subcontracting_location.id,
            //             'location_src_id': supplier_location.id,
            //             'procure_method': 'make_to_stock',
            //             'route_id': route.id,
            //             'picking_type_id': dropship_picking_type.id,
            //             'company_id': company.id,
            //         })
            // if vals:
            //     self.env['stock.rule'].create(vals)
            */
            return default;
        }

        protected async Task<ResCompany> CreateSubcontractingDropshippingSequenceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting_dropshipping, FILE: res_company.py) ---
            // def _create_subcontracting_dropshipping_sequence(self):
            // seq_vals = [{
            //     'name': 'Dropship Subcontractor (%s)' % company.name,
            //     'code': 'mrp.subcontracting.dropshipping',
            //     'company_id': company.id,
            //     'prefix': 'DSC/',
            //     'padding': 5,
            // } for company in self]
            // 
            // if seq_vals:
            //     self.env['ir.sequence'].create(seq_vals)
            */
            return default;
        }

        protected async Task<ResCompany> CreateSubcontractingLocationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp_subcontracting, FILE: res_company.py) ---
            // def _create_subcontracting_location(self):
            // parent_location = self.env.ref('stock.stock_location_locations', raise_if_not_found=False)
            // for company in self:
            //     subcontracting_location = self.env['stock.location'].create({
            //         'name': _('Subcontracting Location'),
            //         'usage': 'internal',
            //         'location_id': parent_location.id,
            //         'company_id': company.id,
            //         'is_subcontracting_location': True,
            //     })
            //     self.env['ir.default'].set(
            //         "res.partner",
            //         "property_stock_subcontractor",
            //         subcontracting_location.id,
            //         company_id=company.id,
            //     )
            //     company.subcontracting_location_id = subcontracting_location
            */
            return default;
        }

        protected async Task<ResCompany> CreateTransitLocationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: res_company.py) ---
            // def _create_transit_location(self):
            // '''Create a transit location with company_id being the given company_id. This is needed
            //    in case of resuply routes between warehouses belonging to the same company, because
            //    we don't want to create accounting entries at that time.
            // '''
            // parent_location = self.env.ref('stock.stock_location_locations', raise_if_not_found=False)
            // for company in self:
            //     location = self.env['stock.location'].create({
            //         'name': _('Inter-warehouse transit'),
            //         'usage': 'transit',
            //         'location_id': parent_location and parent_location.id or False,
            //         'company_id': company.id,
            //         'active': False
            //     })
            // 
            //     company.write({'internal_transit_location_id': location.id})
            // 
            //     company.partner_id.with_company(company).write({
            //         'property_stock_customer': location.id,
            //         'property_stock_supplier': location.id,
            //     })
            */
            return default;
        }

        protected async Task<ResCompany> CreateUnbuildSequenceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mrp, FILE: res_company.py) ---
            // def _create_unbuild_sequence(self):
            // unbuild_vals = []
            // for company in self:
            //     unbuild_vals.append({
            //         'name': 'Unbuild',
            //         'code': 'mrp.unbuild',
            //         'company_id': company.id,
            //         'prefix': 'UB/',
            //         'padding': 5,
            //         'number_next': 1,
            //         'number_increment': 1
            //     })
            // if unbuild_vals:
            //     self.env['ir.sequence'].create(unbuild_vals)
            */
            return default;
        }

        protected async Task<ResCompany> DefaultAliasDomainIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: res_company.py) ---
            // def _default_alias_domain_id(self):
            // return self.env['mail.alias.domain'].search([], limit=1)
            */
            return default;
        }

        protected async Task<ResCompany> DefaultCompanyTokenInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: res_company.py) ---
            // def _default_company_token(self):
            // return str(uuid.uuid4())
            */
            return default;
        }

        protected async Task<ResCompany> DefaultConfirmationMailTemplateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: res_company.py) ---
            // def _default_confirmation_mail_template(self):
            // try:
            //     return self.env.ref('stock.mail_template_data_delivery_confirmation').id
            // except ValueError:
            //     return False
            */
            return default;
        }

        protected async Task<ResCompany> DefaultConfirmationSmsPickingTemplateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock_sms, FILE: res_company.py) ---
            // def _default_confirmation_sms_picking_template(self):
            // try:
            //     return self.env.ref('stock_sms.sms_template_data_stock_delivery').id
            // except ValueError:
            //     return False
            */
            return default;
        }

        protected async Task<ResCompany> DefaultCurrencyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _default_currency_id(self):
            // return self.env.user.company_id.currency_id
            */
            return default;
        }

        protected async Task<ResCompany> DefaultProjectTimeModeIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: res_company.py) ---
            // def _default_project_time_mode_id(self):
            // uom = self.env.ref('uom.product_uom_hour', raise_if_not_found=False)
            // wtime = self.env.ref('uom.uom_categ_wtime')
            // if not uom:
            //     uom = self.env['uom.uom'].search([('category_id', '=', wtime.id), ('uom_type', '=', 'reference')], limit=1)
            // if not uom:
            //     uom = self.env['uom.uom'].search([('category_id', '=', wtime.id)], limit=1)
            // return uom
            */
            return default;
        }

        protected async Task<ResCompany> DefaultTimesheetEncodeUomIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_timesheet, FILE: res_company.py) ---
            // def _default_timesheet_encode_uom_id(self):
            // uom = self.env.ref('uom.product_uom_hour', raise_if_not_found=False)
            // wtime = self.env.ref('uom.uom_categ_wtime')
            // if not uom:
            //     uom = self.env['uom.uom'].search([('category_id', '=', wtime.id), ('uom_type', '=', 'reference')], limit=1)
            // if not uom:
            //     uom = self.env['uom.uom'].search([('category_id', '=', wtime.id)], limit=1)
            // return uom
            */
            return default;
        }

        protected async Task<ResCompany> EnrichExtractM2oIdInternalAsync(object iap_data, object m2o_fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_company.py) ---
            // def _enrich_extract_m2o_id(self, iap_data, m2o_fields):
            // """ Extract m2O ids from data (because of res.partner._format_data_company) """
            // extracted_data = {}
            // for m2o_field in m2o_fields:
            //     relation_data = iap_data.get(m2o_field)
            //     if relation_data and isinstance(relation_data, dict):
            //         extracted_data[m2o_field] = relation_data.get('id', False)
            // return extracted_data
            */
            return default;
        }

        protected async Task<ResCompany> EnrichInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_company.py) ---
            // def _enrich(self):
            // """ This method calls the partner autocomplete service from IAP to enrich
            // partner related fields of the company.
            // 
            // :return bool: either done, either failed """
            // self.ensure_one()
            // _logger.info("Starting enrich of company %s (%s)", self.name, self.id)
            // 
            // company_domain = self._get_company_domain()
            // if not company_domain:
            //     return False
            // 
            // company_data = self.env['res.partner'].enrich_by_domain(company_domain, timeout=COMPANY_AC_TIMEOUT)
            // if not company_data or company_data.get("error"):
            //     return
            // 
            // company_data = {field: value for field, value in company_data.items()
            //                 if field in self.partner_id._fields and value and (field == 'image_1920' or not self.partner_id[field])}
            // 
            // # for company: from state_id / country_id display_name like to IDs
            // company_data.update(self._enrich_extract_m2o_id(company_data, ['state_id', 'country_id']))
            // 
            // self.partner_id.write(company_data)
            // return True
            */
            return default;
        }

        protected async Task<bool> ExistingAccountingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def _existing_accounting(self) -> bool:
            // """Return True iff some accounting entries have already been made for the current company."""
            // self.ensure_one()
            // return bool(self.env['account.move.line'].sudo().search_count([('company_id', 'child_of', self.id)], limit=1))
            */
            return default;
        }

        protected async Task<ResCompany> FormatLockDatesInternalAsync(object lock_dates)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def _format_lock_dates(self, lock_dates):
            // """Format a list of lock dates as a string.
            // :param lock_date_violations: list of tuple (lock_date, lock_date_field)
            // :return: a (localized) string listing all the lock date fields and their values
            // """
            // return format_list(self.env, [
            //     f"{self.fields_get([field])[field]['string']} ({format_date(self.env, lock_date)})"
            //     for lock_date, field in sorted(lock_dates)
            // ])
            */
            return default;
        }

        protected async Task<ResCompany> GetAssetStyleB64InternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: models.py) ---
            // def _get_asset_style_b64(self):
            // # One bundle for everyone, so this method
            // # necessarily updates the style for every company at once
            // company_ids = self.sudo().search([])
            // company_styles = self.env['ir.qweb']._render('web.styles_company_report', {
            //         'company_ids': company_ids,
            //     }, raise_if_not_found=False)
            // return base64.b64encode(company_styles.encode())
            */
            return default;
        }

        public async Task<ResCompany> GetChartOfAccountsOrFailAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def get_chart_of_accounts_or_fail(self):
            // account = self.env['account.account'].search(self.env['account.account']._check_company_domain(self), limit=1)
            // if len(account) == 0:
            //     action = self.env.ref('account.action_account_config')
            //     msg = _(
            //         "We cannot find a chart of accounts for this company, you should configure it. \n"
            //         "Please go to Account Configuration and select or install a fiscal localization.")
            //     raise RedirectWarning(msg, action.id, _("Go to the configuration panel"))
            // return account
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResCompany> GetCompanyAddressFieldNamesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _get_company_address_field_names(self):
            // """ Return a list of fields coming from the address partner to match
            // on company address fields. Fields are labeled same on both models. """
            // return ['street', 'street2', 'city', 'zip', 'state_id', 'country_id']
            */
            return default;
        }

        protected async Task<ResCompany> GetCompanyAddressUpdateInternalAsync(object partner)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _get_company_address_update(self, partner):
            // return dict((fname, partner[fname])
            //             for fname in self._get_company_address_field_names())
            */
            return default;
        }

        protected async Task<ResCompany> GetCompanyDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_company.py) ---
            // def _get_company_domain(self):
            // """ Extract the company domain to be used by IAP services.
            // The domain is extracted from the website or the email information.
            // e.g:
            //     - www.info.proximus.be -> proximus.be
            //     - info@proximus.be -> proximus.be """
            // self.ensure_one()
            // 
            // company_domain = email_domain_extract(self.email) if self.email else False
            // if company_domain and company_domain not in iap_tools._MAIL_PROVIDERS:
            //     return company_domain
            // 
            // company_domain = url_domain_extract(self.website) if self.website else False
            // if not company_domain or company_domain in ['localhost', 'example.com']:
            //     return False
            // 
            // return company_domain
            */
            return default;
        }

        protected async Task<ResCompany> GetCompanyRootDelegatedFieldNamesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def _get_company_root_delegated_field_names(self):
            // return super()._get_company_root_delegated_field_names() + [
            //     'fiscalyear_last_day',
            //     'fiscalyear_last_month',
            //     'account_storno',
            //     'tax_exigibility',
            // ]
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _get_company_root_delegated_field_names(self):
            // """Get the set of fields delegated to the root company.
            // 
            // Some fields need to be identical on all branches of the company. All
            // fields listed by this function will be copied from the root company and
            // appear as readonly in the form view.
            // :rtype: set
            // """
            // return ['currency_id']
            */
            return default;
        }

        protected async Task<ResCompany> GetDefaultNomenclatureInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: barcodes, FILE: res_company.py) ---
            // def _get_default_nomenclature(self):
            // return self.env.ref('barcodes.default_barcode_nomenclature', raise_if_not_found=False)
            */
            return default;
        }

        protected async Task<ResCompany> GetDefaultOpeningMoveValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def _get_default_opening_move_values(self):
            // """ Get the default values to create the opening move.
            // 
            // :return: A dictionary to be passed to account.move.create.
            // """
            // self.ensure_one()
            // default_journal = self.env['account.journal'].search(
            //     domain=[
            //         *self.env['account.journal']._check_company_domain(self),
            //         ('type', '=', 'general'),
            //     ],
            //     limit=1,
            // )
            // 
            // if not default_journal:
            //     raise UserError(_("Please install a chart of accounts or create a miscellaneous journal before proceeding."))
            // 
            // return {
            //     'ref': _('Opening Journal Entry'),
            //     'company_id': self.id,
            //     'journal_id': default_journal.id,
            //     'date': self.account_opening_date - timedelta(days=1),
            // }
            */
            return default;
        }

        protected async Task<ResCompany> GetDefaultPricelistValsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: product, FILE: res_company.py) ---
            // def _get_default_pricelist_vals(self):
            // """Add values to the default pricelist at company creation or activation of the pricelist
            // 
            // Note: self.ensure_one()
            // 
            // :rtype: dict
            // """
            // self.ensure_one()
            // values = {}
            // values.update({
            //     'name': _("Default"),
            //     'currency_id': self.currency_id.id,
            //     'company_id': self.id,
            //     'sequence': 10,
            // })
            // return values
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: res_company.py) ---
            // def _get_default_pricelist_vals(self):
            // """ Override of product. Called at company creation or activation of the pricelist setting.
            // 
            // We don't want the default website from the current company to be applied on every company
            // 
            // Note: self.ensure_one()
            // 
            // :rtype: dict
            // """
            // values = super()._get_default_pricelist_vals()
            // values['website_id'] = False
            // return values
            */
            return default;
        }

        public async Task<ResCompany> GetFiscalDatesAsync(Guid id, ResCompanyGetFiscalDatesRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: spreadsheet_account, FILE: res_company.py) ---
            // def get_fiscal_dates(self, payload):
            // companies = self.env["res.company"].browse(
            //     data["company_id"] or self.env.company.id for data in payload
            // )
            // existing_companies = companies.exists()
            // # prefetch both fields
            // existing_companies.fetch(["fiscalyear_last_day", "fiscalyear_last_month"])
            // results = []
            // 
            // for data, company in zip(payload, companies):
            //     if company not in existing_companies:
            //         results.append(False)
            //         continue
            //     start, end = date_utils.get_fiscal_year(
            //         fields.Date.to_date(data["date"]),
            //         day=company.fiscalyear_last_day,
            //         month=int(company.fiscalyear_last_month),
            //     )
            //     results.append({"start": start, "end": end})
            // return results
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResCompany> GetLockDateViolationsInternalAsync(object accounting_date, object fiscalyear, object sale, object purchase, object tax, object hard)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def _get_lock_date_violations(self, accounting_date, fiscalyear=True, sale=True, purchase=True, tax=True, hard=True):
            // """Get all the lock dates affecting the current accounting_date.
            // :param accounting_date:      The accounting date
            // :param bool fiscalyear:      Whether we should check the `fiscalyear_lock_date`
            // :param bool sale:            Whether we should check the `sale_lock_date`
            // :param bool purchase:        Whether we should check the `purchase_lock_date`
            // :param bool tax:             Whether we should check the `tax_lock_date`
            // :param bool hard:            Whether we should check the `hard_lock_date`
            // :return: a list of tuples containing the lock dates (not ordered chronologically).
            // """
            // self.ensure_one()
            // locks = []
            // 
            // if not accounting_date:
            //     return locks
            // 
            // soft_lock_date_fields_to_check = [
            //     # (field, "to check")
            //     ('fiscalyear_lock_date', fiscalyear),
            //     ('sale_lock_date', sale),
            //     ('purchase_lock_date', purchase),
            //     ('tax_lock_date', tax),
            // ]
            // for field, to_check in soft_lock_date_fields_to_check:
            //     if not to_check:
            //         continue
            //     violated_date = self._get_violated_soft_lock_date(field, accounting_date)
            //     if violated_date:
            //         locks.append((violated_date, field))
            // 
            // if hard:
            //     hard_lock_date = self.user_hard_lock_date
            //     if accounting_date <= hard_lock_date:
            //         locks.append((hard_lock_date, 'hard_lock_date'))
            // 
            // return locks
            */
            return default;
        }

        protected async Task<ResCompany> GetLogoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _get_logo(self):
            // with file_open('base/static/img/res_company_logo.png', 'rb') as file:
            //     return base64.b64encode(file.read())
            */
            return default;
        }

        protected async Task<ResCompany> GetMainCompanyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _get_main_company(self):
            // try:
            //     main_company = self.sudo().env.ref('base.main_company')
            // except ValueError:
            //     main_company = self.env['res.company'].sudo().search([], limit=1, order="id")
            // 
            // return main_company
            */
            return default;
        }

        public async Task<ResCompany> GetNewAccountCodeAsync(Guid id, ResCompanyGetNewAccountCodeRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def get_new_account_code(self, current_code, old_prefix, new_prefix):
            // digits = len(current_code)
            // return new_prefix + current_code.replace(old_prefix, '', 1).lstrip('0').rjust(digits-len(new_prefix), '0')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResCompany> GetNextBatchPaymentCommunicationAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def get_next_batch_payment_communication(self):
            // '''
            // When in need of a batch payment communication reference (several invoices paid at the same time)
            // use batch_payment_sequence_id to get it (eventually create it first): e.g BATCH/2024/00001
            // '''
            // self.ensure_one()
            // return self.sudo().batch_payment_sequence_id.next_by_id()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResCompany> GetPeppolEdiModeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py) ---
            // def _get_peppol_edi_mode(self):
            // self.ensure_one()
            // config_param = self.env['ir.config_parameter'].sudo().get_param('account_peppol.edi.mode')
            // # by design, we can only have zero or one proxy user per company with type Peppol
            // peppol_user = self.sudo().account_edi_proxy_client_ids.filtered(lambda u: u.proxy_type == 'peppol')
            // return peppol_user.edi_mode or config_param or 'prod'
            */
            return default;
        }

        protected async Task<ResCompany> GetPublicUserInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _get_public_user(self):
            // self.ensure_one()
            // # We need sudo to be able to see public users from others companies too
            // public_users = self.env.ref('base.group_public').sudo().with_context(active_test=False).users
            // public_users_for_company = public_users.filtered(lambda user: user.company_id == self)
            // 
            // if public_users_for_company:
            //     return public_users_for_company[0]
            // else:
            //     return self.env.ref('base.public_user').sudo().copy({
            //         'name': 'Public user for %s' % self.name,
            //         'login': 'public-user@company-%s.com' % self.id,
            //         'company_id': self.id,
            //         'company_ids': [(6, 0, [self.id])],
            //     })
            */
            return default;
        }

        protected async Task<ResCompany> GetSocialMediaLinksInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: res_company.py) ---
            // def _get_social_media_links(self):
            // self.ensure_one()
            // return {
            //     'social_facebook': self.social_facebook,
            //     'social_linkedin': self.social_linkedin,
            //     'social_twitter': self.social_twitter,
            //     'social_instagram': self.social_instagram,
            //     'social_tiktok': self.social_tiktok,
            // }
            --- ODOO METHOD SOURCE (MODULE: website_mass_mailing, FILE: res_company.py) ---
            // def _get_social_media_links(self):
            // social_media_links = super()._get_social_media_links()
            // website_id = self.env['website'].get_current_website()
            // social_media_links.update({
            //     'social_facebook': website_id.social_facebook or social_media_links.get('social_facebook'),
            //     'social_linkedin': website_id.social_linkedin or social_media_links.get('social_linkedin'),
            //     'social_twitter': website_id.social_twitter or social_media_links.get('social_twitter'),
            //     'social_instagram': website_id.social_instagram or social_media_links.get('social_instagram'),
            //     'social_tiktok': website_id.social_tiktok or social_media_links.get('social_tiktok'),
            // })
            // return social_media_links
            */
            return default;
        }

        public async Task<ResCompany> GetUnaffectedEarningsAccountAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def get_unaffected_earnings_account(self):
            // """ Returns the unaffected earnings account for this company, creating one
            // if none has yet been defined.
            // """
            // unaffected_earnings_type = "equity_unaffected"
            // account = self.env['account.account'].with_company(self).search([
            //     *self.env['account.account']._check_company_domain(self),
            //     ('account_type', '=', unaffected_earnings_type),
            // ], limit=1)
            // if account:
            //     return account
            // # Do not assume '999999' doesn't exist since the user might have created such an account
            // # manually.
            // code = 999999
            // while self.env['account.account'].with_company(self).search_count([
            //     *self.env['account.account']._check_company_domain(self),
            //     ('code', '=', str(code)),
            // ], limit=1):
            //     code -= 1
            // return self.env['account.account']._load_records([
            //     {
            //         'xml_id': f"account.{str(self.id)}_unaffected_earnings_account",
            //         'values': {
            //                       'code': str(code),
            //                       'name': _('Undistributed Profits/Losses'),
            //                       'account_type': unaffected_earnings_type,
            //                       'company_ids': [Command.link(self.id)],
            //                   },
            //         'noupdate': True,
            //     }
            // ])
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResCompany> GetUnreconciledStatementLinesDomainInternalAsync(object last_date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def _get_unreconciled_statement_lines_domain(self, last_date):
            // return [
            //     ('company_id', 'child_of', self.ids),
            //     ('is_reconciled', '=', False),
            //     ('date', '<=', last_date),
            //     ('move_id.state', 'in', ('draft', 'posted')),
            // ]
            */
            return default;
        }

        protected async Task<ResCompany> GetUnreconciledStatementLinesRedirectActionInternalAsync(object unreconciled_statement_lines)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def _get_unreconciled_statement_lines_redirect_action(self, unreconciled_statement_lines):
            // """ Get the action redirecting to the statement lines that are not already reconciled.
            // It can i.e. be used when setting a fiscal year lock date or hashing all entries until a certain date.
            // 
            // :param unreconciled_statement_lines: The statement lines.
            // :return: A dictionary representing a window action.
            // """
            // 
            // action = {
            //     'name': _("Unreconciled Transactions"),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'account.bank.statement.line',
            //     'context': {'create': False},
            // }
            // if len(unreconciled_statement_lines) == 1:
            //     action.update({
            //         'view_mode': 'form',
            //         'res_id': unreconciled_statement_lines.id,
            //     })
            // else:
            //     action.update({
            //         'view_mode': 'list,form',
            //         'domain': [('id', 'in', unreconciled_statement_lines.ids)],
            //     })
            // return action
            */
            return default;
        }

        protected async Task<ResCompany> GetUserFiscalLockDateInternalAsync(object journal, object ignore_exceptions)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def _get_user_fiscal_lock_date(self, journal, ignore_exceptions=False):
            // """Get the fiscal lock date for this company (depending on the affected journal) accounting for potential user exceptions
            // :param bool ignore_exceptions: Whether we ignore exceptions or not
            // :return the lock date
            // """
            // self.ensure_one()
            // company = self.with_context(ignore_exceptions=ignore_exceptions)
            // lock = max(company.user_fiscalyear_lock_date, company.user_hard_lock_date)
            // if journal.type == 'sale':
            //     lock = max(company.user_sale_lock_date, lock)
            // elif journal.type == 'purchase':
            //     lock = max(company.user_purchase_lock_date, lock)
            // return lock
            */
            return default;
        }

        protected async Task<ResCompany> GetUserLockDateInternalAsync(object soft_lock_date_field, object ignore_exceptions)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def _get_user_lock_date(self, soft_lock_date_field, ignore_exceptions=False):
            // """Get the lock date called `soft_lock_date_field` for this company depending on the user.
            // We consider the field and exceptions (except if `ignore_exceptions`) for it in this company and the parent companies.
            // :param str soft_lock_date_field: One of the lock date fields (except 'hard_lock_date'; see SOFT_LOCK_DATE_FIELDS)
            // :param bool ignore_exceptions: Whether we ignore exceptions or not
            // :return the user lock date
            // """
            // self.ensure_one()
            // soft_lock_date = date.min
            // # We need to use sudo, since we might not have access to a parent company.
            // for company in self.sudo().parent_ids:
            //     if company[soft_lock_date_field]:
            //         if ignore_exceptions:
            //             exception = None
            //         else:
            //             exception = self.env['account.lock_exception'].search(
            //                 [
            //                   ('state', '=', 'active'),  # checks the datetime
            //                   '|',
            //                       ('user_id', '=', None),
            //                       ('user_id', '=', self.env.user.id),
            //                   (soft_lock_date_field, '<', company[soft_lock_date_field]),
            //                   ('company_id', '=', company.id),
            //                 ],
            //                 order='lock_date asc NULLS FIRST',
            //                 limit=1,
            //             )
            //         if exception:
            //             # The search domain of the exception ensures `exception[soft_lock_date_field] < company[soft_lock_date_field]`
            //             # or `exception[soft_lock_date_field] is False`
            //             soft_lock_date = max(soft_lock_date, exception[soft_lock_date_field] or date.min)
            //         else:
            //             soft_lock_date = max(soft_lock_date, company[soft_lock_date_field])
            // return soft_lock_date
            */
            return default;
        }

        protected async Task<ResCompany> GetViewInternalAsync(Guid view_id, object view_type)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_company.py) ---
            // def _get_view(self, view_id=None, view_type='form', **options):
            // arch, view = super()._get_view(view_id, view_type, **options)
            // 
            // if view_type == 'form':
            //     for i, node in enumerate(arch.xpath("//field[@name='name' or @name='vat']")):
            //         node.set('widget', 'field_partner_autocomplete')
            // 
            // return arch, view
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _get_view(self, view_id=None, view_type='form', **options):
            // delegated_fnames = set(self._get_company_root_delegated_field_names())
            // arch, view = super()._get_view(view_id, view_type, **options)
            // for f in arch.iter("field"):
            //     if f.get('name') in delegated_fnames:
            //         f.set('readonly', "parent_id != False")
            // return arch, view
            */
            return default;
        }

        protected async Task<ResCompany> GetViolatedLockDatesInternalAsync(object accounting_date, object has_tax, object journal)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def _get_violated_lock_dates(self, accounting_date, has_tax, journal):
            // """Get all the lock dates affecting the current accounting_date.
            // :param accounting_date: The accounting date
            // :param has_tax: If any taxes are involved in the lines of the invoice
            // :param journal: The affected journal
            // :return: a list of tuples containing the lock dates ordered chronologically.
            // """
            // locks = self._get_lock_date_violations(
            //     accounting_date,
            //     fiscalyear=True,
            //     sale=(journal and journal.type == 'sale'),
            //     purchase=(journal and journal.type == 'purchase'),
            //     tax=has_tax,
            //     hard=True,
            // )
            // locks.sort()
            // return locks
            */
            return default;
        }

        protected async Task<ResCompany> GetViolatedSoftLockDateInternalAsync(object soft_lock_date_field, object date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def _get_violated_soft_lock_date(self, soft_lock_date_field, date):
            // """
            // Check whether `date` violates the lock date called `soft_lock_date_field`.
            // :param str soft_lock_date_field: One of the lock date fields (except 'hard_lock_date'; see SOFT_LOCK_DATE_FIELDS)
            // :param date: We check whether this date is prior or equal to the lock date.
            // :return the violated lock date as a date (or `None`)
            // """
            // violated_date = None
            // if not self:
            //     return violated_date
            // self.ensure_one()
            // user_lock_date_field = f'user_{soft_lock_date_field}'
            // regular_lock_date = self.with_context(ignore_exceptions=True)[user_lock_date_field]
            // if date <= regular_lock_date:
            //     violated_date = regular_lock_date
            //     user_lock_date = self.with_context(ignore_exceptions=False)[user_lock_date_field]
            //     violated_date = None if date > user_lock_date else user_lock_date
            // return violated_date
            */
            return default;
        }

        public async Task<ResCompany> GoogleMapImgAsync(Guid id, ResCompanyGoogleMapImgRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: res_company.py) ---
            // def google_map_img(self, zoom=8, width=298, height=298):
            // partner = self.sudo().partner_id
            // return partner and partner.google_map_img(zoom, width, height) or None
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResCompany> GoogleMapLinkAsync(Guid id, ResCompanyGoogleMapLinkRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: res_company.py) ---
            // def google_map_link(self, zoom=8):
            // partner = self.sudo().partner_id
            // return partner and partner.google_map_link(zoom) or None
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResCompany> IapEnrichAutoAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: partner_autocomplete, FILE: res_company.py) ---
            // def iap_enrich_auto(self):
            // """ Enrich company. This method should be called by automatic processes
            // and a protection is added to avoid doing enrich in a loop. """
            // if self.env.user._is_system():
            //     for company in self.filtered(lambda company: not company.iap_enrich_auto_done):
            //         company._enrich()
            //     self.iap_enrich_auto_done = True
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResCompany> InitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def init(self):
            // for company in self.search([('paperformat_id', '=', False)]):
            //     paperformat_euro = self.env.ref('base.paperformat_euro', False)
            //     if paperformat_euro:
            //         company.write({'paperformat_id': paperformat_euro.id})
            // sup = super(Company, self)
            // if hasattr(sup, 'init'):
            //     sup.init()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResCompany> InitColumnInternalAsync(object column_name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: res_company.py) ---
            // def _init_column(self, column_name):
            // """ Initialize the value of the given column for existing rows.
            //     Overridden here because we need to generate different access tokens
            //     and by default _init_column calls the default method once and applies
            //     it for every record.
            // """
            // if column_name != 'attendance_kiosk_key':
            //     super(ResCompany, self)._init_column(column_name)
            // else:
            //     self.env.cr.execute("SELECT id FROM %s WHERE attendance_kiosk_key IS NULL" % self._table)
            //     attendance_ids = self.env.cr.dictfetchall()
            //     values_args = [(attendance_id['id'], self._default_company_token()) for attendance_id in attendance_ids]
            //     query = """
            //         UPDATE {table}
            //         SET attendance_kiosk_key = vals.token
            //         FROM (VALUES %s) AS vals(id, token)
            //         WHERE {table}.id = vals.id
            //     """.format(table=self._table)
            //     self.env.cr.execute_values(query, values_args)
            */
            return default;
        }

        protected async Task<ResCompany> InitDataResourceCalendarInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: res_company.py) ---
            // def _init_data_resource_calendar(self):
            // self.search([('resource_calendar_id', '=', False)])._create_resource_calendar()
            */
            return default;
        }

        protected async Task<ResCompany> InitiateAccountOnboardingsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def _initiate_account_onboardings(self):
            // account_onboarding_routes = [
            //     'account_dashboard',
            // ]
            // onboardings = self.env['onboarding.onboarding'].sudo().search([('route_name', 'in', account_onboarding_routes)])
            // for company in self:
            //     onboardings.with_company(company)._search_or_create_progress()
            */
            return default;
        }

        public async Task<ResCompany> InstallL10nModulesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def install_l10n_modules(self):
            // if self.env.context.get('chart_template_load'):
            //     # No automatic install during the loading of a chart_template
            //     return False
            // if res := super().install_l10n_modules():
            //     self.env.flush_all()
            //     self.env.reset()     # clear the set of environments
            //     env = self.env()     # get an environment that refers to the new registry
            //     for company in self.filtered(lambda c: c.country_id and not c.chart_template):
            //         template_code = company.parent_id.chart_template or self.env['account.chart.template']._guess_chart_template(company.country_id)
            //         if template_code != 'generic_coa':
            //             @self.env.cr.precommit.add
            //             def try_loading(template_code=template_code, company=company):
            //                 env['account.chart.template'].try_loading(
            //                     template_code,
            //                     env['res.company'].browse(company.id),
            //                 )
            // return res
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def install_l10n_modules(self):
            // uninstalled_modules = self.uninstalled_l10n_module_ids
            // is_ready_and_not_test = (
            //     not tools.config['test_enable']
            //     and (self.env.registry.ready or not self.env.registry._init)
            //     and not getattr(threading.current_thread(), 'testing', False)
            // )
            // if uninstalled_modules and is_ready_and_not_test:
            //     return uninstalled_modules.button_immediate_install()
            // return is_ready_and_not_test
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResCompany> InstallModulesInternalAsync(object module_names)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: res_company.py) ---
            // def _install_modules(self, module_names):
            // modules_sudo = self.env['ir.module.module'].sudo().search([('name', 'in', module_names)])
            // STATES = ['installed', 'to install', 'to upgrade']
            // modules_sudo.filtered(lambda m: m.state not in STATES).button_immediate_install()
            */
            return default;
        }

        protected async Task<ResCompany> InverseCityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _inverse_city(self):
            // for company in self:
            //     company.partner_id.city = company.city
            */
            return default;
        }

        protected async Task<ResCompany> InverseColorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _inverse_color(self):
            // for company in self:
            //     company.root_id.partner_id.color = company.color
            */
            return default;
        }

        protected async Task<ResCompany> InverseCountryInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _inverse_country(self):
            // for company in self:
            //     company.partner_id.country_id = company.country_id
            */
            return default;
        }

        protected async Task<ResCompany> InversePeppolPurchaseJournalIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py) ---
            // def _inverse_peppol_purchase_journal_id(self):
            // for company in self:
            //     # This avoid having 2 or more journals from the same company with
            //     # `is_peppol_journal` set to True (which could occur after changes).
            //     journals_to_reset = self.env['account.journal'].search([
            //         ('company_id', '=', company.id),
            //         ('is_peppol_journal', '=', True),
            //     ])
            //     journals_to_reset.is_peppol_journal = False
            //     company.peppol_purchase_journal_id.is_peppol_journal = True
            */
            return default;
        }

        protected async Task<ResCompany> InverseStateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _inverse_state(self):
            // for company in self:
            //     company.partner_id.state_id = company.state_id
            */
            return default;
        }

        protected async Task<ResCompany> InverseStreet2InternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _inverse_street2(self):
            // for company in self:
            //     company.partner_id.street2 = company.street2
            */
            return default;
        }

        protected async Task<ResCompany> InverseStreetInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _inverse_street(self):
            // for company in self:
            //     company.partner_id.street = company.street
            */
            return default;
        }

        protected async Task<ResCompany> InverseZipInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _inverse_zip(self):
            // for company in self:
            //     company.partner_id.zip = company.zip
            */
            return default;
        }

        protected async Task<ResCompany> LoadPosDataDomainInternalAsync(object data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: res_company.py) ---
            // def _load_pos_data_domain(self, data):
            // return [('id', '=', data['pos.config']['data'][0]['company_id'])]
            */
            return default;
        }

        protected async Task<ResCompany> LoadPosDataFieldsInternalAsync(Guid config_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: res_company.py) ---
            // def _load_pos_data_fields(self, config_id):
            // return [
            //     'id', 'currency_id', 'email', 'website', 'company_registry', 'vat', 'name', 'phone', 'partner_id',
            //     'country_id', 'state_id', 'tax_calculation_rounding_method', 'nomenclature_id', 'point_of_sale_use_ticket_qr_code',
            //     'point_of_sale_ticket_unique_code', 'point_of_sale_ticket_portal_url_display_mode', 'street', 'city', 'zip',
            //     'account_fiscal_country_id',
            // ]
            */
            return default;
        }

        protected async Task<ResCompany> OnchangeCountryIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _onchange_country_id(self):
            // if self.country_id:
            //     self.currency_id = self.country_id.currency_id
            */
            return default;
        }

        protected async Task<ResCompany> OnchangeParentIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _onchange_parent_id(self):
            // if self.parent_id:
            //     for fname in self._get_company_root_delegated_field_names():
            //         if self[fname] != self.parent_id[fname]:
            //             self[fname] = self.parent_id[fname]
            */
            return default;
        }

        protected async Task<ResCompany> OnchangeStateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _onchange_state(self):
            // if self.state_id.country_id:
            //     self.country_id = self.state_id.country_id
            */
            return default;
        }

        public async Task<ResCompany> OpenWebsiteThemeSelectorAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website, FILE: res_company.py) ---
            // def action_open_website_theme_selector(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("website.theme_install_kanban_action")
            // action['target'] = 'new'
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResCompany> OpeningMovePostedAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def opening_move_posted(self):
            // """ Returns true if this company has an opening account move and this move is posted."""
            // return bool(self.account_opening_move_id) and self.account_opening_move_id.state == 'posted'
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResCompany> PeppolModulesDocumentTypesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py) ---
            // def _peppol_modules_document_types(self):
            // """Override this function to add supported document types as modules are installed.
            // 
            // :returns: dictionary of the form: {module_name: [(document identifier, document_name)]}
            // """
            // return {
            //     'default': {
            //         "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2::Invoice##urn:cen.eu:en16931:2017#compliant#urn:fdc:peppol.eu:2017:poacc:billing:3.0::2.1":
            //             "Peppol BIS Billing UBL Invoice V3",
            //         "urn:oasis:names:specification:ubl:schema:xsd:CreditNote-2::CreditNote##urn:cen.eu:en16931:2017#compliant#urn:fdc:peppol.eu:2017:poacc:billing:3.0::2.1":
            //             "Peppol BIS Billing UBL CreditNote V3",
            //         "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2::Invoice##urn:cen.eu:en16931:2017#compliant#urn:fdc:nen.nl:nlcius:v1.0::2.1":
            //             "SI-UBL 2.0 Invoice",
            //         "urn:oasis:names:specification:ubl:schema:xsd:CreditNote-2::CreditNote##urn:cen.eu:en16931:2017#compliant#urn:fdc:nen.nl:nlcius:v1.0::2.1":
            //             "SI-UBL 2.0 CreditNote",
            //         "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2::Invoice##urn:cen.eu:en16931:2017#conformant#urn:fdc:peppol.eu:2017:poacc:billing:international:sg:3.0::2.1":
            //             "SG Peppol BIS Billing 3.0 Invoice",
            //         "urn:oasis:names:specification:ubl:schema:xsd:CreditNote-2::CreditNote##urn:cen.eu:en16931:2017#conformant#urn:fdc:peppol.eu:2017:poacc:billing:international:sg:3.0::2.1":
            //             "SG Peppol BIS Billing 3.0 Credit Note",
            //         "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2::Invoice##urn:cen.eu:en16931:2017#compliant#urn:xeinkauf.de:kosit:xrechnung_3.0::2.1":
            //             "XRechnung UBL Invoice V2.0",
            //         "urn:oasis:names:specification:ubl:schema:xsd:CreditNote-2::CreditNote##urn:cen.eu:en16931:2017#compliant#urn:xeinkauf.de:kosit:xrechnung_3.0::2.1":
            //             "XRechnung UBL CreditNote V2.0",
            //         "urn:oasis:names:specification:ubl:schema:xsd:Invoice-2::Invoice##urn:cen.eu:en16931:2017#conformant#urn:fdc:peppol.eu:2017:poacc:billing:international:aunz:3.0::2.1":
            //             "AU-NZ Peppol BIS Billing 3.0 Invoice",
            //         "urn:oasis:names:specification:ubl:schema:xsd:CreditNote-2::CreditNote##urn:cen.eu:en16931:2017#conformant#urn:fdc:peppol.eu:2017:poacc:billing:international:aunz:3.0::2.1":
            //             "AU-NZ Peppol BIS Billing 3.0 CreditNote",
            //     }
            // }
            */
            return default;
        }

        protected async Task<ResCompany> PeppolSupportedDocumentTypesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py) ---
            // def _peppol_supported_document_types(self):
            // """Returns a flattened dictionary of all supported document types."""
            // return {
            //     identifier: document_name
            //     for module, identifiers in self._peppol_modules_document_types().items()
            //     for identifier, document_name in identifiers.items()
            // }
            */
            return default;
        }

        protected async Task<ResCompany> PrepareResourceCalendarValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: resource, FILE: res_company.py) ---
            // def _prepare_resource_calendar_values(self):
            // self.ensure_one()
            // return {
            //     'name': _('Standard 40 hours/week'),
            //     'company_id': self.id,
            // }
            */
            return default;
        }

        public async Task<ResCompany> ReflectCodePrefixChangeAsync(Guid id, ResCompanyReflectCodePrefixChangeRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def reflect_code_prefix_change(self, old_code, new_code):
            // if not old_code or new_code == old_code:
            //     return
            // accounts = self.env['account.account'].with_company(self).search([
            //     *self.env['account.account']._check_company_domain(self),
            //     ('code', '=like', old_code + '%'),
            //     ('account_type', 'in', ('asset_cash', 'liability_credit_card')),
            // ], order='code asc')
            // for account in accounts:
            //     account.write({'code': self.get_new_account_code(account.code, old_code, new_code)})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResCompany> RegenerateAttendanceKioskKeyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: res_company.py) ---
            // def _regenerate_attendance_kiosk_key(self):
            // self.ensure_one()
            // self.write({
            //     'attendance_kiosk_key': uuid.uuid4().hex
            // })
            */
            return default;
        }

        protected async Task<ResCompany> RunPaymentOnboardingStepInternalAsync(Guid menu_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: payment, FILE: res_company.py) ---
            // def _run_payment_onboarding_step(self, menu_id=None):
            // """ Install the suggested payment modules and configure the providers.
            // 
            // It's checked that the current company has a Chart of Account.
            // 
            // :param int menu_id: The menu from which the user started the onboarding step, as an
            //                     `ir.ui.menu` id
            // :return: The action returned by `action_stripe_connect_account`
            // :rtype: dict
            // """
            // self.env.company.get_chart_of_accounts_or_fail()
            // 
            // self._install_modules(['payment_stripe'])
            // 
            // # Create a new env including the freshly installed module(s)
            // new_env = api.Environment(self.env.cr, self.env.uid, self.env.context)
            // 
            // # Configure Stripe
            // stripe_provider = new_env['payment.provider'].search([
            //     *self.env['payment.provider']._check_company_domain(self.env.company),
            //     ('code', '=', 'stripe')
            // ], limit=1)
            // if not stripe_provider:
            //     base_provider = self.env.ref('payment.payment_provider_stripe')
            //     # Use sudo to access payment provider record that can be in different company.
            //     stripe_provider = base_provider.sudo().with_context(
            //         stripe_connect_onboarding=True,
            //     ).copy(default={'company_id': self.env.company.id})
            // 
            // return stripe_provider.action_stripe_connect_account(menu_id=menu_id)
            */
            return default;
        }

        protected async Task<ResCompany> SanitizePeppolEndpointInValuesInternalAsync(object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py) ---
            // def _sanitize_peppol_endpoint_in_values(self, values):
            // eas = values.get('peppol_eas')
            // endpoint = values.get('peppol_endpoint')
            // if not eas or not endpoint:
            //     return
            // if sanitizer := PEPPOL_ENDPOINT_SANITIZERS.get(eas):
            //     new_endpoint = sanitizer(endpoint)
            //     if new_endpoint:
            //         values['peppol_endpoint'] = new_endpoint
            */
            return default;
        }

        protected async Task<ResCompany> SanitizePeppolEndpointInternalAsync(object vals, object eas, object endpoint)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py) ---
            // def _sanitize_peppol_endpoint(self, vals, eas=False, endpoint=False):
            // # TODO: remove in master
            // if not (peppol_eas := vals.get('peppol_eas', eas)) or not (peppol_endpoint := vals.get('peppol_endpoint', endpoint)):
            //     return vals
            // 
            // if sanitizer := PEPPOL_ENDPOINT_SANITIZERS.get(peppol_eas):
            //     vals['peppol_endpoint'] = sanitizer(peppol_endpoint)
            // 
            // return vals
            */
            return default;
        }

        protected async Task<ResCompany> SanitizePeppolPhoneNumberInternalAsync(object phone_number)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py) ---
            // def _sanitize_peppol_phone_number(self, phone_number=None):
            // self.ensure_one()
            // 
            // error_message = _(
            //     "Please enter the mobile number in the correct international format.\n"
            //     "For example: +32123456789, where +32 is the country code.\n"
            //     "Currently, only European countries are supported.")
            // 
            // self._check_phonenumbers_import()
            // 
            // phone_number = phone_number or self.account_peppol_phone_number
            // if not phone_number:
            //     return
            // 
            // if not phone_number.startswith('+'):
            //     phone_number = f'+{phone_number}'
            // 
            // try:
            //     phone_nbr = phonenumbers.parse(phone_number)
            // except phonenumbers.phonenumberutil.NumberParseException:
            //     raise ValidationError(error_message)
            // 
            // country_code = phonenumbers.phonenumberutil.region_code_for_number(phone_nbr)
            // if country_code not in PEPPOL_LIST or not phonenumbers.is_valid_number(phone_nbr):
            //     raise ValidationError(error_message)
            */
            return default;
        }

        public async Task<ResCompany> SaveOnboardingCompanyDataAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def action_save_onboarding_company_data(self):
            // self.ensure_one()
            // if self.street:
            //     ref = 'account.onboarding_onboarding_step_company_data'
            //     self.env['onboarding.onboarding.step'].with_company(self).action_validate_step(ref)
            // return {'type': 'ir.actions.client', 'tag': 'soft_reload'}
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<ResCompany> SaveOnboardingSaleTaxAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def action_save_onboarding_sale_tax(self):
            // """ Set the onboarding step as done """
            // self.env['onboarding.onboarding.step'].action_validate_step('account.onboarding_onboarding_step_sales_tax')
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResCompany> SearchDisplayNameInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def _search_display_name(self, operator, value):
            // context = dict(self.env.context)
            // newself = self
            // constraint = []
            // if context.pop('user_preference', None):
            //     # We browse as superuser. Otherwise, the user would be able to
            //     # select only the currently visible companies (according to rules,
            //     # which are probably to allow to see the child companies) even if
            //     # she belongs to some other companies.
            //     companies = self.env.user.company_ids
            //     constraint = [('id', 'in', companies.ids)]
            //     newself = newself.sudo()
            // newself = newself.with_context(context)
            // domain = super(Company, newself)._search_display_name(operator, value)
            // return expression.AND([domain, constraint])
            */
            return default;
        }

        protected async Task<ResCompany> SetPerCompanyInterCompanyLocationsInternalAsync(object inter_company_location)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: stock, FILE: res_company.py) ---
            // def _set_per_company_inter_company_locations(self, inter_company_location):
            // self.ensure_one()
            // if not self.env.user.has_group('base.group_multi_company'):
            //     return
            // other_companies = self.env['res.company'].search([('id', '!=', self.id)])
            // other_companies.partner_id.with_company(self).write({
            //     'property_stock_customer': inter_company_location.id,
            //     'property_stock_supplier': inter_company_location.id,
            // })
            // for company in other_companies:
            //     # Still need to insert those one by one, as the env company must be different every time
            //     self.partner_id.with_company(company).write({
            //         'property_stock_customer': inter_company_location.id,
            //         'property_stock_supplier': inter_company_location.id,
            //     })
            */
            return default;
        }

        public async Task<ResCompany> SettingInitBankAccountActionAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def setting_init_bank_account_action(self):
            // """ Called by the 'Bank Accounts' button of the setup bar or from the Financial configuration menu."""
            // view_id = self.env.ref('account.setup_bank_account_wizard').id
            // context = {'dialog_size': 'medium', **self.env.context}
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _('Setup Bank Account'),
            //     'res_model': 'account.setup.bank.manual.config',
            //     'target': 'new',
            //     'view_mode': 'form',
            //     'views': [[view_id, 'form']],
            //     'context': context,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResCompany> UpdateAssetStyleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: web, FILE: models.py) ---
            // def _update_asset_style(self):
            // asset_attachment = self.env.ref('web.asset_styles_company_report', raise_if_not_found=False)
            // if not asset_attachment:
            //     return
            // asset_attachment = asset_attachment.sudo()
            // b64_val = self._get_asset_style_b64()
            // if b64_val != asset_attachment.datas:
            //     asset_attachment.write({'datas': b64_val})
            */
            return default;
        }

        protected async Task<ResCompany> UpdateOpeningMoveInternalAsync(object to_update)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def _update_opening_move(self, to_update):
            // """ Create or update the opening move for the accounts passed as parameter.
            // 
            // :param to_update:   A dictionary mapping each account with a tuple (debit, credit).
            //                     A separated opening line is created for both fields. A None value on debit/credit means the corresponding
            //                     line will not be updated.
            // """
            // self.ensure_one()
            // 
            // # Don't allow to modify the opening move if not in draft.
            // opening_move = self.account_opening_move_id
            // if opening_move and opening_move.state != 'draft':
            //     raise UserError(_(
            //         'You cannot import the "openning_balance" if the opening move (%s) is already posted. \
            //         If you are absolutely sure you want to modify the opening balance of your accounts, reset the move to draft.',
            //         self.account_opening_move_id.name,
            //     ))
            // 
            // def del_lines(lines):
            //     nonlocal open_balance
            //     for line in lines:
            //         open_balance -= line.balance
            //         yield Command.delete(line.id)
            // 
            // def update_vals(account, side, balance, balancing=False):
            //     nonlocal open_balance
            //     corresponding_lines = corresponding_lines_per_account[(account, side)]
            //     currency = account.currency_id or self.currency_id
            //     amount_currency = balance if balancing else self.currency_id._convert(balance, currency, date=conversion_date)
            //     open_balance += balance
            //     if self.currency_id.is_zero(balance):
            //         yield from del_lines(corresponding_lines)
            //     elif corresponding_lines:
            //         line_to_update = corresponding_lines[0]
            //         open_balance -= line_to_update.balance
            //         yield Command.update(line_to_update.id, {
            //             'balance': balance,
            //             'amount_currency': amount_currency,
            //         })
            //         yield from del_lines(corresponding_lines[1:])
            //     else:
            //         yield Command.create({
            //             'name':_("Automatic Balancing Line") if balancing else _("Opening balance"),
            //             'account_id': account.id,
            //             'balance': balance,
            //             'amount_currency': amount_currency,
            //             'currency_id': currency.id,
            //         })
            // 
            // # Decode the existing opening move.
            // corresponding_lines_per_account = defaultdict(lambda: self.env['account.move.line'])
            // corresponding_lines_per_account.update(opening_move.line_ids.grouped(lambda line: (
            //     line.account_id,
            //     'debit' if line.balance > 0.0 or line.amount_currency > 0.0 else 'credit',
            // )))
            // 
            // # Update the opening move's lines.
            // balancing_account = self.get_unaffected_earnings_account()
            // open_balance = (
            //     sum(corresponding_lines_per_account[(balancing_account, 'credit')].mapped('credit'))
            //     -sum(corresponding_lines_per_account[(balancing_account, 'debit')].mapped('debit'))
            // )
            // commands = []
            // move_values = {'line_ids': commands}
            // if opening_move:
            //     conversion_date = opening_move.date
            // else:
            //     move_values.update(self._get_default_opening_move_values())
            //     conversion_date = move_values['date']
            // for account, (debit, credit) in to_update.items():
            //     if debit is not None:
            //         commands.extend(update_vals(account, 'debit', debit))
            //     if credit is not None:
            //         commands.extend(update_vals(account, 'credit', -credit))
            // 
            // commands.extend(update_vals(balancing_account, 'debit', max(-open_balance, 0), balancing=True))
            // commands.extend(update_vals(balancing_account, 'credit', -max(open_balance, 0), balancing=True))
            // 
            // # Nothing to do.
            // if not commands:
            //     return
            // 
            // if opening_move:
            //     opening_move.write(move_values)
            // else:
            //     self.account_opening_move_id = self.env['account.move'].create(move_values)
            */
            return default;
        }

        protected async Task<ResCompany> ValidateFiscalyearLockInternalAsync(object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: om_fiscal_year, FILE: res_company.py) ---
            // def _validate_fiscalyear_lock(self, values):
            // if values.get('fiscalyear_lock_date'):
            //     draft_entries = self.env['account.move'].search([
            //         ('company_id', 'in', self.ids),
            //         ('state', '=', 'draft'),
            //         ('date', '<=', values['fiscalyear_lock_date'])])
            //     if draft_entries:
            //         error_msg = _(
            //             'There are still unposted entries in the period you want to lock. You should either post or delete them.')
            //         action_error = {
            //             'view_mode': 'list',
            //             'name': 'Unposted Entries',
            //             'res_model': 'account.move',
            //             'type': 'ir.actions.act_window',
            //             'domain': [('id', 'in', draft_entries.ids)],
            //             'search_view_id': [self.env.ref('account.view_account_move_filter').id, 'search'],
            //             'views': [[self.env.ref('account.view_move_tree').id, 'list'],
            //                       [self.env.ref('account.view_move_form').id, 'form']],
            //         }
            //         raise RedirectWarning(error_msg, action_error, _('Show unposted entries'))
            // 
            //     unreconciled_statement_lines = self.env['account.bank.statement.line'].search([
            //         ('company_id', 'in', self.ids),
            //         ('is_reconciled', '=', False),
            //         ('date', '<=', values['fiscalyear_lock_date']),
            //         ('move_id.state', 'in', ('draft', 'posted')),
            //     ])
            //     if unreconciled_statement_lines:
            //         error_msg = _("There are still unreconciled bank statement lines in the period you want to lock."
            //                       "You should either reconcile or delete them.")
            //         raise ValidationError(error_msg)
            */
            return default;
        }

        public async Task<ResCompany> ValidateLockDatesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: point_of_sale, FILE: res_company.py) ---
            // def validate_lock_dates(self):
            // """ This constrains makes it impossible to change the relevant lock dates if
            // some open POS session would violate them. Without that, these POS sessions
            // could not be closed (since the closing entries violate the lock dates).
            // """
            // pos_session_model = self.env['pos.session'].sudo()
            // for record in self:
            //     record = record.with_context(ignore_exceptions=True)
            //     fiscal_lock_date = max(record.user_fiscalyear_lock_date, record.user_hard_lock_date)
            //     sessions_in_period = pos_session_model.search(
            //         [
            //             ("company_id", "child_of", record.id),
            //             ("state", "!=", "closed"),
            //             *expression.OR([
            //                 [("start_at", "<=", fiscal_lock_date)],
            //                 [("start_at", "<=", record.user_tax_lock_date)],
            //                 # The `config_id.journal_id.type` is either 'sale' or 'misc'
            //                 [("config_id.journal_id.type", "=", 'sale'),
            //                  ("start_at", "<=", record.user_sale_lock_date)],
            //             ])
            //         ]
            //     )
            //     if sessions_in_period:
            //         sessions_str = ', '.join(sessions_in_period.mapped('name'))
            //         raise ValidationError(_("Please close all the point of sale sessions in this period before closing it. Open sessions are: %s ", sessions_str))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<ResCompany> ValidateLocksInternalAsync(object values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def _validate_locks(self, values):
            // """Check that the lock date changes are valid.
            // * Check that we do not decrease or remove the hard lock dates.
            // * Check there are no unreconciled bank statement lines in the period we want to lock.
            // * Check there are no unhashed journal entires in the period we want to lock.
            // :param vals: The values passed to the write method.
            // """
            // new_locks = {field: fields.Date.to_date(values[field])for field in LOCK_DATE_FIELDS if field in values}
            // 
            // fiscalyear_lock_date = new_locks.get('fiscalyear_lock_date')
            // hard_lock_date = new_locks.get('hard_lock_date')
            // sale_lock_date = new_locks.get('sale_lock_date')
            // purchase_lock_date = new_locks.get('purchase_lock_date')
            // fiscal_lock_date = None
            // if fiscalyear_lock_date or hard_lock_date:
            //     fiscal_lock_date = max(fiscalyear_lock_date or date.min, hard_lock_date or date.min)
            // 
            // if 'hard_lock_date' in new_locks:
            //     for company in self:
            //         if not company.hard_lock_date:
            //             continue
            //         if not hard_lock_date:
            //             raise UserError(_("The Hard Lock Date cannot be removed."))
            //         if hard_lock_date < company.hard_lock_date:
            //             raise UserError(_("A new Hard Lock Date must be posterior (or equal) to the previous one."))
            // 
            // if hard_lock_date:
            //     draft_entries = self.env['account.move'].search([
            //         ('company_id', 'child_of', self.ids),
            //         ('state', '=', 'draft'),
            //         ('date', '<=', hard_lock_date)])
            //     if draft_entries:
            //         error_msg = _('There are still draft entries in the period you want to hard lock. You should either post or delete them.')
            //         action_error = {
            //             'view_mode': 'list',
            //             'name': _('Draft Entries'),
            //             'res_model': 'account.move',
            //             'type': 'ir.actions.act_window',
            //             'domain': [('id', 'in', draft_entries.ids)],
            //             'search_view_id': [self.env.ref('account.view_account_move_filter').id, 'search'],
            //             'views': [[self.env.ref('account.view_move_tree_multi_edit').id, 'list'], [self.env.ref('account.view_move_form').id, 'form']],
            //         }
            //         raise RedirectWarning(error_msg, action_error, _('Show draft entries'))
            // 
            // # Check for unreconciled bank statement lines
            // if fiscal_lock_date:
            //     unreconciled_statement_lines = self.env['account.bank.statement.line'].search(
            //         self._get_unreconciled_statement_lines_domain(fiscal_lock_date)
            //     )
            //     if unreconciled_statement_lines:
            //         error_msg = _("There are still unreconciled bank statement lines in the period you want to lock."
            //                     "You should either reconcile or delete them.")
            //         action_error = self._get_unreconciled_statement_lines_redirect_action(unreconciled_statement_lines)
            //         raise RedirectWarning(error_msg, action_error, _('Show Unreconciled Bank Statement Line'))
            */
            return default;
        }

        protected async Task<ResCompany> WithLockedRecordsInternalAsync(object records, object allow_raising)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def _with_locked_records(self, records, allow_raising=True):
            // """ To avoid sending the same records multiple times from different transactions,
            // we use this generic method to lock the records passed as parameter.
            // 
            // :param records: The records to lock.
            // """
            // if not records.ids:
            //     return
            // self._cr.execute(f'SELECT * FROM {records._table} WHERE id IN %s FOR UPDATE SKIP LOCKED', [tuple(records.ids)])
            // available_ids = {r[0] for r in self._cr.fetchall()}
            // all_locked = available_ids == set(records.ids)
            // if not all_locked and allow_raising:
            //     raise UserError(_("Some documents are being sent by another process already."))
            // else:
            //     return all_locked
            */
            return default;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, ResCompany entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: company.py) ---
            // def write(self, values):
            // self._validate_locks(values)
            // 
            // self.env['res.company'].invalidate_model(fnames=[f'user_{field}' for field in LOCK_DATE_FIELDS if field in values])
            // 
            // # Reflect the change on accounts
            // for company in self:
            //     if values.get('bank_account_code_prefix'):
            //         new_bank_code = values.get('bank_account_code_prefix') or company.bank_account_code_prefix
            //         company.reflect_code_prefix_change(company.bank_account_code_prefix, new_bank_code)
            // 
            //     if values.get('cash_account_code_prefix'):
            //         new_cash_code = values.get('cash_account_code_prefix') or company.cash_account_code_prefix
            //         company.reflect_code_prefix_change(company.cash_account_code_prefix, new_cash_code)
            // 
            //     #forbid the change of currency_id if there are already some accounting entries existing
            //     if 'currency_id' in values and values['currency_id'] != company.currency_id.id:
            //         if company.root_id._existing_accounting():
            //             raise UserError(_('You cannot change the currency of the company since some journal items already exist'))
            // 
            // companies = super().write(values)
            // 
            // # We revoke all active exceptions affecting the changed lock dates and recreate them (with the updated lock dates)
            // changed_soft_lock_fields = [field for field in SOFT_LOCK_DATE_FIELDS if field in values]
            // for company in self:
            //     active_exceptions = self.env['account.lock_exception'].search(
            //         self.env['account.lock_exception']._get_active_exceptions_domain(company, changed_soft_lock_fields),
            //     )
            //     active_exceptions._recreate()
            // 
            // return companies
            --- ODOO METHOD SOURCE (MODULE: account_peppol, FILE: res_company.py) ---
            // def write(self, vals):
            // self._sanitize_peppol_endpoint_in_values(vals)
            // return super().write(vals)
            --- ODOO METHOD SOURCE (MODULE: hr_attendance, FILE: res_company.py) ---
            // def write(self, vals):
            // search_domains = []  # Overtime to generate
            // # Also recompute if the threshold have changed
            // if 'overtime_company_threshold' in vals or 'overtime_employee_threshold' in vals:
            //     for company in self:
            //         # If we modify the thresholds only
            //         if (vals.get('overtime_company_threshold') != company.overtime_company_threshold) or\
            //             (vals.get('overtime_employee_threshold') != company.overtime_employee_threshold):
            //             search_domains.append([('employee_id.company_id', '=', company.id)])
            // 
            // res = super().write(vals)
            // if search_domains:
            //     self.env['hr.attendance'].search(OR(search_domains))._update_overtime()
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: product, FILE: res_company.py) ---
            // def write(self, vals):
            // """Delay the automatic creation of pricelists post-company update.
            // 
            // This makes sure that the pricelist(s) automatically created are created with the right
            // currency.
            // """
            // if not vals.get('currency_id'):
            //     return super().write(vals)
            // 
            // enabled_pricelists = self.env.user.has_group('product.group_product_pricelist')
            // res = super(
            //     ResCompany, self.with_context(disable_company_pricelist_creation=True)
            // ).write(vals)
            // if not enabled_pricelists and self.env.user.has_group('product.group_product_pricelist'):
            //     self.browse()._activate_or_create_pricelists()
            // 
            // return res
            --- ODOO METHOD SOURCE (MODULE: web, FILE: models.py) ---
            // def write(self, values):
            // res = super().write(values)
            // style_fields = {'external_report_layout_id', 'font', 'primary_color', 'secondary_color'}
            // if not style_fields.isdisjoint(values):
            //     self._update_asset_style()
            // return res
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def write(self, values):
            // invalidation_fields = self.cache_invalidation_fields()
            // asset_invalidation_fields = {'font', 'primary_color', 'secondary_color', 'external_report_layout_id'}
            // 
            // companies_needs_l10n = (
            //     values.get('country_id')
            //     and self.filtered(lambda company: not company.country_id)
            //     or self.browse()
            // )
            // if not invalidation_fields.isdisjoint(values):
            //     self.env.registry.clear_cache()
            // 
            // if not asset_invalidation_fields.isdisjoint(values):
            //     # this is used in the content of an asset (see asset_styles_company_report)
            //     # and thus needs to invalidate the assets cache when this is changed
            //     self.env.registry.clear_cache('assets')  # not 100% it is useful a test is missing if it is the case
            // 
            // if 'parent_id' in values:
            //     raise UserError(_("The company hierarchy cannot be changed."))
            // 
            // if values.get('currency_id'):
            //     currency = self.env['res.currency'].browse(values['currency_id'])
            //     if not currency.active:
            //         currency.write({'active': True})
            // 
            // res = super(Company, self).write(values)
            // 
            // # Archiving a company should also archive all of its branches
            // if values.get('active') is False:
            //     self.child_ids.active = False
            // 
            // for company in self:
            //     # Copy modified delegated fields from root to branches
            //     if (changed := set(values) & set(self._get_company_root_delegated_field_names())) and not company.parent_id:
            //         branches = self.sudo().search([
            //             ('id', 'child_of', company.id),
            //             ('id', '!=', company.id),
            //         ])
            //         for fname in sorted(changed):
            //             branches[fname] = company[fname]
            // 
            // if companies_needs_l10n:
            //     companies_needs_l10n.install_l10n_modules()
            // 
            // # invalidate company cache to recompute address based on updated partner
            // company_address_fields = self._get_company_address_field_names()
            // company_address_fields_upd = set(company_address_fields) & set(values.keys())
            // if company_address_fields_upd:
            //     self.invalidate_model(company_address_fields)
            // return res
            */
            return await base.WriteAsync(ids, entity, fields);
        }

        private async Task<ResCompany> _AccessibleBranchesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_company.py) ---
            // def __accessible_branches(self):
            // # Get branches of this company that the current user can use
            // self.ensure_one()
            // 
            // accessible_branch_ids = []
            // accessible = self.env.companies
            // current = self.sudo()
            // while current:
            //     accessible_branch_ids.extend((current & accessible).ids)
            //     current = current.child_ids
            // 
            // if not accessible_branch_ids and self.env.uid == SUPERUSER_ID:
            //     # Accessible companies will always be the same for super user when called in a cron.
            //     # Because of that, the intersection between them and self might be empty. The super user anyway always has
            //     # access to all companies (as it bypasses the record rules), so we return the current company in this case.
            //     return self.ids
            // 
            // return accessible_branch_ids
            */
            return default;
        }
    }
}