using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("Crm", Category = "Sales", Depends = new[] { "base_setup", "sales_team", "mail", "calendar", "resource", "utm", "web_tour", "contacts", "digest", "phone_validation" })]
    public class CrmLeadAppService : GenericApplicationService<CrmLead>, ICrmLeadAppService
    {
        private readonly IFormatAddressMixinAppService _formatAddressMixinAppService;
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadBlacklistAppService _mailThreadBlacklistAppService;
        private readonly IMailThreadCcAppService _mailThreadCcAppService;
        private readonly IMailThreadPhoneAppService _mailThreadPhoneAppService;
        private readonly IMailTrackingDurationMixinAppService _mailTrackingDurationMixinAppService;
        private readonly IUtmMixinAppService _utmMixinAppService;
        public CrmLeadAppService(IRepository<CrmLead, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IFormatAddressMixinAppService formatAddressMixinAppService, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadBlacklistAppService mailThreadBlacklistAppService, IMailThreadCcAppService mailThreadCcAppService, IMailThreadPhoneAppService mailThreadPhoneAppService, IMailTrackingDurationMixinAppService mailTrackingDurationMixinAppService, IUtmMixinAppService utmMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _formatAddressMixinAppService = formatAddressMixinAppService;
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadBlacklistAppService = mailThreadBlacklistAppService;
            _mailThreadCcAppService = mailThreadCcAppService;
            _mailThreadPhoneAppService = mailThreadPhoneAppService;
            _mailTrackingDurationMixinAppService = mailTrackingDurationMixinAppService;
            _utmMixinAppService = utmMixinAppService;
        }

        public async Task<CrmLead> AssignGeoLocalizeAsync(Guid id, CrmLeadAssignGeoLocalizeRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: crm_lead.py) ---
            // def assign_geo_localize(self, latitude=False, longitude=False):
            // if latitude and longitude:
            //     self.write({
            //         'partner_latitude': latitude,
            //         'partner_longitude': longitude
            //     })
            //     return True
            // # Don't pass context to browse()! We need country name in english below
            // for lead in self:
            //     if lead.partner_latitude and lead.partner_longitude:
            //         continue
            //     if lead.country_id:
            //         result = self.env['res.partner']._geo_localize(
            //             lead.street, lead.zip, lead.city,
            //             lead.state_id.name, lead.country_id.name
            //         )
            //         if result:
            //             lead.write({
            //                 'partner_latitude': result[0],
            //                 'partner_longitude': result[1]
            //             })
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<CrmLead> AssignPartnerAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: crm_lead.py) ---
            // def action_assign_partner(self):
            // """ While assigning a partner, geo-localization is performed only for leads having country
            //     set (see method 'assign_geo_localize' and 'search_geo_partner'). So for leads that does not
            //     have country set, we show the notification, and for the rest, we geo-localize them.
            // """
            // leads_with_country = self.filtered(lambda lead: lead.country_id)
            // leads_without_country = self - leads_with_country
            // if leads_without_country:
            //     self.env.user._bus_send('simple_notification', {
            //         'type': 'danger',
            //         'title': _("Warning"),
            //         'message': _('There is no country set in addresses for %(lead_names)s.', lead_names=', '.join(leads_without_country.mapped('name'))),
            //     })
            // return leads_with_country.assign_partner(partner_id=False)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<CrmLead> AssignPartnerAsync(Guid id, CrmLeadAssignPartnerRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: crm_lead.py) ---
            // def assign_partner(self, partner_id=False):
            // partner_dict = {}
            // res = False
            // if not partner_id:
            //     partner_dict = self.search_geo_partner()
            // for lead in self:
            //     if not partner_id:
            //         partner_id = partner_dict.get(lead.id, False)
            //     if not partner_id:
            //         tag_to_add = self.env.ref('website_crm_partner_assign.tag_portal_lead_partner_unavailable', False)
            //         if tag_to_add:
            //             lead.write({'tag_ids': [(4, tag_to_add.id, False)]})
            //         continue
            //     lead.assign_geo_localize(lead.partner_latitude, lead.partner_longitude)
            //     partner = self.env['res.partner'].browse(partner_id)
            //     if partner.user_id:
            //         lead._handle_salesmen_assignment(user_ids=partner.user_id.ids)
            //     lead.write({'partner_assigned_id': partner_id})
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<CrmLead> AssignSalesmanOfAssignedPartnerAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: crm_lead.py) ---
            // def assign_salesman_of_assigned_partner(self):
            // salesmans_leads = {}
            // for lead in self:
            //     if lead.active and lead.probability < 100:
            //         if lead.partner_assigned_id and lead.partner_assigned_id.user_id != lead.user_id:
            //             salesmans_leads.setdefault(lead.partner_assigned_id.user_id.id, []).append(lead.id)
            // 
            // for salesman_id, leads_ids in salesmans_leads.items():
            //     leads = self.browse(leads_ids)
            //     leads.write({'user_id': salesman_id})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<CrmLead> AutoInitInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _auto_init(self):
            // super()._auto_init()
            // tools.create_index(self._cr, 'crm_lead_user_id_team_id_type_index',
            //                    self._table, ['user_id', 'team_id', 'type'])
            // tools.create_index(self._cr, 'crm_lead_create_date_team_id_idx',
            //                    self._table, ['create_date', 'team_id'])
            */
            return default;
        }

        protected async Task<CrmLead> ComputeCompanyCurrencyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_company_currency(self):
            // for lead in self:
            //     if not lead.company_id:
            //         lead.company_currency = self.env.company.currency_id
            //     else:
            //         lead.company_currency = lead.company_id.currency_id
            */
            return default;
        }

        protected async Task<CrmLead> ComputeCompanyIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_company_id(self):
            // """ Compute company_id coherency. """
            // for lead in self:
            //     proposal = lead.company_id
            // 
            //     # invalidate wrong configuration
            //     if proposal:
            //         # company not in responsible companies
            //         if lead.user_id and proposal not in lead.user_id.company_ids:
            //             proposal = False
            //         # inconsistent
            //         elif lead.team_id.company_id and proposal != lead.team_id.company_id:
            //             proposal = False
            //         # void company on team and no assignee
            //         elif lead.team_id and not lead.team_id.company_id and not lead.user_id:
            //             proposal = False
            //         # no user and no team -> void company and let assignment do its job
            //         # unless customer has a company
            //         elif not lead.team_id and not lead.user_id and \
            //                 (not lead.partner_id or lead.partner_id.company_id != proposal):
            //             proposal = False
            // 
            //     # propose a new company based on team > user (respecting context) > partner
            //     if not proposal:
            //         if lead.team_id.company_id:
            //             lead.company_id = lead.team_id.company_id
            //         elif lead.user_id:
            //             if self.env.company in lead.user_id.company_ids:
            //                 lead.company_id = self.env.company
            //             else:
            //                 lead.company_id = lead.user_id.company_id & self.env.companies
            //         elif lead.partner_id:
            //             lead.company_id = lead.partner_id.company_id
            //         else:
            //             lead.company_id = False
            */
            return default;
        }

        protected async Task<CrmLead> ComputeContactNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_contact_name(self):
            // """ compute the new values when partner_id has changed """
            // for lead in self:
            //     lead.update(lead._prepare_contact_name_from_partner(lead.partner_id))
            */
            return default;
        }

        protected async Task<CrmLead> ComputeDateLastStageUpdateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_date_last_stage_update(self):
            // for lead in self:
            //     if not lead.date_last_stage_update:
            //         lead.date_last_stage_update = self.env.cr.now()
            */
            return default;
        }

        protected async Task<CrmLead> ComputeDateOpenInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_date_open(self):
            // for lead in self:
            //     if not lead.date_open and lead.user_id:
            //         lead.date_open = self.env.cr.now()
            */
            return default;
        }

        protected async Task<CrmLead> ComputeDatePartnerAssignInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: crm_lead.py) ---
            // def _compute_date_partner_assign(self):
            // for lead in self:
            //     if not lead.partner_assigned_id:
            //         lead.date_partner_assign = False
            //     else:
            //         lead.date_partner_assign = fields.Date.context_today(lead)
            */
            return default;
        }

        protected async Task<CrmLead> ComputeDayCloseInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_day_close(self):
            // """ Compute difference between current date and log date """
            // leads = self.filtered(lambda l: l.date_closed and l.create_date)
            // others = self - leads
            // others.day_close = None
            // for lead in leads:
            //     date_create = fields.Datetime.from_string(lead.create_date)
            //     date_close = fields.Datetime.from_string(lead.date_closed)
            //     lead.day_close = abs((date_close - date_create).days)
            */
            return default;
        }

        protected async Task<CrmLead> ComputeDayOpenInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_day_open(self):
            // """ Compute difference between create date and open date """
            // leads = self.filtered(lambda l: l.date_open and l.create_date)
            // others = self - leads
            // others.day_open = None
            // for lead in leads:
            //     date_create = fields.Datetime.from_string(lead.create_date).replace(microsecond=0)
            //     date_open = fields.Datetime.from_string(lead.date_open)
            //     lead.day_open = abs((date_open - date_create).days)
            */
            return default;
        }

        protected async Task<CrmLead> ComputeEmailDomainCriterionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_email_domain_criterion(self):
            // self.email_domain_criterion = False
            // for lead in self.filtered('email_normalized'):
            //     lead.email_domain_criterion = iap_tools.mail_prepare_for_domain_search(
            //         lead.email_normalized
            //     )
            */
            return default;
        }

        protected async Task<CrmLead> ComputeEmailFromInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_email_from(self):
            // for lead in self:
            //     if lead.partner_id.email and lead._get_partner_email_update():
            //         lead.email_from = lead.partner_id.email
            */
            return default;
        }

        protected async Task<CrmLead> ComputeEmailStateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_email_state(self):
            // for lead in self:
            //     email_state = False
            //     if lead.email_from:
            //         email_state = 'incorrect'
            //         for email in email_split(lead.email_from):
            //             if mail_validation.mail_validate(email):
            //                 email_state = 'correct'
            //                 break
            //     lead.email_state = email_state
            */
            return default;
        }

        protected async Task<CrmLead> ComputeFunctionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_function(self):
            // """ compute the new values when partner_id has changed """
            // for lead in self:
            //     if not lead.function or lead.partner_id.function:
            //         lead.function = lead.partner_id.function
            */
            return default;
        }

        protected async Task<CrmLead> ComputeIsAutomatedProbabilityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_is_automated_probability(self):
            // """ If probability and automated_probability are equal probability computation
            // is considered as automatic, aka probability is sync with automated_probability """
            // for lead in self:
            //     lead.is_automated_probability = tools.float_compare(lead.probability, lead.automated_probability, 2) == 0
            */
            return default;
        }

        protected async Task<CrmLead> ComputeIsPartnerVisibleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_is_partner_visible(self):
            // """ When the crm.lead is of type 'lead', we don't want to display the "Customer" field on the form view
            // unless it's set (or debug mode).
            // 
            // Indeed, most of the times leads will not have this information set, since when we assign a Customer we
            // usually convert the lead to an opportunity as well.
            // 
            // This means that on the lead form, we don't want to display this field since it may be misleading for the
            // end user.
            // When it's set however, we want to display it, mainly because there are a few automatic synchronizations between
            // the lead and its partner (phone and email for examples), and this needs to be clear that modifying
            // one of those fields will in turn modify the linked partner."""
            // is_debug_mode = self.env.user.has_group('base.group_no_one')
            // for lead in self:
            //     lead.is_partner_visible = bool(lead.type == 'opportunity' or lead.partner_id or is_debug_mode)
            */
            return default;
        }

        protected async Task<CrmLead> ComputeLangActiveCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_lang_active_count(self):
            // self.lang_active_count = len(self.env['res.lang'].get_installed())
            */
            return default;
        }

        protected async Task<CrmLead> ComputeLangIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_lang_id(self):
            // """ compute the lang based on partner, erase any value to force the partner
            // one if set. """
            // # prepare cache
            // lang_codes = [code for code in self.mapped('partner_id.lang') if code]
            // if lang_codes:
            //     lang_id_by_code = dict(
            //         (code, self.env['res.lang']._get_data(code=code).id)
            //         for code in lang_codes
            //     )
            // else:
            //     lang_id_by_code = {}
            // for lead in self.filtered('partner_id'):
            //     lead.lang_id = lang_id_by_code.get(lead.partner_id.lang, False)
            */
            return default;
        }

        protected async Task<CrmLead> ComputeMeetingDisplayInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_meeting_display(self):
            // now = fields.Datetime.now()
            // meeting_data = self.env['calendar.event'].sudo()._read_group([
            //     ('opportunity_id', 'in', self.ids),
            // ], ['opportunity_id'], ['start:array_agg', 'start:max'])
            // mapped_data = {
            //     lead: {
            //         'last_meeting_date': last_meeting_date,
            //         'next_meeting_date': min([dt for dt in meeting_start_dates if dt > now] or [False]),
            //     } for lead, meeting_start_dates, last_meeting_date in meeting_data
            // }
            // for lead in self:
            //     lead_meeting_info = mapped_data.get(lead)
            //     if not lead_meeting_info:
            //         lead.meeting_display_date = False
            //         lead.meeting_display_label = _('No Meeting')
            //     elif lead_meeting_info['next_meeting_date']:
            //         lead.meeting_display_date = lead_meeting_info['next_meeting_date']
            //         lead.meeting_display_label = _('Next Meeting')
            //     else:
            //         lead.meeting_display_date = lead_meeting_info['last_meeting_date']
            //         lead.meeting_display_label = _('Last Meeting')
            */
            return default;
        }

        protected async Task<CrmLead> ComputeMobileInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_mobile(self):
            // """ compute the new values when partner_id has changed """
            // for lead in self:
            //     if not lead.mobile or lead.partner_id.mobile:
            //         lead.mobile = lead.partner_id.mobile
            */
            return default;
        }

        protected async Task<CrmLead> ComputeNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_name(self):
            // for lead in self:
            //     if not lead.name and lead.partner_id and lead.partner_id.name:
            //         lead.name = _("%s's opportunity") % lead.partner_id.name
            */
            return default;
        }

        protected async Task<CrmLead> ComputePartnerAddressValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_partner_address_values(self):
            // """ Sync all or none of address fields """
            // for lead in self:
            //     lead.update(lead._prepare_address_values_from_partner(lead.partner_id))
            */
            return default;
        }

        protected async Task<CrmLead> ComputePartnerEmailUpdateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_partner_email_update(self):
            // for lead in self:
            //     lead.partner_email_update = lead._get_partner_email_update(force_void=False)
            */
            return default;
        }

        protected async Task<CrmLead> ComputePartnerNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_partner_name(self):
            // """ compute the new values when partner_id has changed """
            // for lead in self:
            //     lead.update(lead._prepare_partner_name_from_partner(lead.partner_id))
            */
            return default;
        }

        protected async Task<CrmLead> ComputePartnerPhoneUpdateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_partner_phone_update(self):
            // for lead in self:
            //     lead.partner_phone_update = lead._get_partner_phone_update(force_void=False)
            */
            return default;
        }

        protected async Task<CrmLead> ComputePhoneInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_phone(self):
            // for lead in self:
            //     if lead.partner_id.phone and lead._get_partner_phone_update():
            //         lead.phone = lead.partner_id.phone
            */
            return default;
        }

        protected async Task<CrmLead> ComputePhoneStateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_phone_state(self):
            // for lead in self:
            //     phone_status = False
            //     if lead.phone:
            //         country_code = lead.country_id.code if lead.country_id and lead.country_id.code else None
            //         try:
            //             if phone_validation.phone_parse(lead.phone, country_code):  # otherwise library not installed
            //                 phone_status = 'correct'
            //         except UserError:
            //             phone_status = 'incorrect'
            //     lead.phone_state = phone_status
            */
            return default;
        }

        protected async Task<CrmLead> ComputePotentialLeadDuplicatesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_potential_lead_duplicates(self):
            // """ Override potential lead duplicates computation to be more efficient
            // with high lead volume.
            // Criterions:
            //   * email domain exact match;
            //   * phone_sanitized exact match;
            //   * same commercial entity;
            // """
            // SEARCH_RESULT_LIMIT = 21
            // 
            // def return_if_relevant(model_name, domain):
            //     """ Returns the recordset obtained by performing a search on the provided
            //     model with the provided domain if the cardinality of that recordset is
            //     below a given threshold (i.e: `SEARCH_RESULT_LIMIT`). Otherwise, returns
            //     an empty recordset of the provided model as it indicates search term
            //     was not relevant.
            //     Note: The function will use the administrator privileges to guarantee
            //     that a maximum amount of leads will be included in the search results
            //     and transcend multi-company record rules. It also includes archived
            //     records. Idea is that counter indicates duplicates are present and
            //     the lead could be escalated to managers.
            //     """
            //     model = self.env[model_name].sudo().with_context(active_test=False)
            //     res = model.search(domain, limit=SEARCH_RESULT_LIMIT)
            //     return res if len(res) < SEARCH_RESULT_LIMIT else model
            // 
            // for lead in self:
            //     lead_id = lead._origin.id if isinstance(lead.id, models.NewId) else lead.id
            //     common_lead_domain = [
            //         ('id', '!=', lead_id)
            //     ]
            // 
            //     duplicate_lead_ids = self.env['crm.lead']
            // 
            //     # check the "company" email domain duplicates
            //     if lead.email_domain_criterion:
            //         duplicate_lead_ids |= return_if_relevant('crm.lead', common_lead_domain + [
            //             ('email_domain_criterion', '=', lead.email_domain_criterion)
            //         ])
            //     # check for "same commercial entity" duplicates
            //     if lead.partner_id and lead.partner_id.commercial_partner_id:
            //         duplicate_lead_ids |= lead.with_context(active_test=False).search(common_lead_domain + [
            //             ("partner_id", "child_of", lead.partner_id.commercial_partner_id.ids)
            //         ])
            //     # check the phone number duplicates, based on phone_sanitized. Only
            //     # exact matches are found, and the single one stored in phone_sanitized
            //     # in case phone and mobile are both set.
            //     if lead.phone_sanitized:
            //         duplicate_lead_ids |= return_if_relevant('crm.lead', common_lead_domain + [
            //             ('phone_sanitized', '=', lead.phone_sanitized)
            //         ])
            // 
            //     lead.duplicate_lead_ids = duplicate_lead_ids + lead
            //     lead.duplicate_lead_count = len(duplicate_lead_ids)
            */
            return default;
        }

        protected async Task<CrmLead> ComputeProbabilitiesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_probabilities(self):
            // lead_probabilities = self._pls_get_naive_bayes_probabilities()
            // for lead in self:
            //     if lead.id in lead_probabilities:
            //         was_automated = lead.active and lead.is_automated_probability
            //         lead.automated_probability = lead_probabilities[lead.id]
            //         if was_automated:
            //             lead.probability = lead.automated_probability
            */
            return default;
        }

        protected async Task<CrmLead> ComputeProratedRevenueInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_prorated_revenue(self):
            // for lead in self:
            //     lead.prorated_revenue = round((lead.expected_revenue or 0.0) * (lead.probability or 0) / 100.0, 2)
            */
            return default;
        }

        protected async Task<CrmLead> ComputeRecurringRevenueMonthlyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_recurring_revenue_monthly(self):
            // for lead in self:
            //     lead.recurring_revenue_monthly = (lead.recurring_revenue or 0.0) / (lead.recurring_plan.number_of_months or 1)
            */
            return default;
        }

        protected async Task<CrmLead> ComputeRecurringRevenueMonthlyProratedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_recurring_revenue_monthly_prorated(self):
            // for lead in self:
            //     lead.recurring_revenue_monthly_prorated = (lead.recurring_revenue_monthly or 0.0) * (lead.probability or 0) / 100.0
            */
            return default;
        }

        protected async Task<CrmLead> ComputeRecurringRevenueProratedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_recurring_revenue_prorated(self):
            // for lead in self:
            //     lead.recurring_revenue_prorated = (lead.recurring_revenue or 0.0) * (lead.probability or 0) / 100.0
            */
            return default;
        }

        protected async Task<CrmLead> ComputeRegistrationCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_crm, FILE: crm_lead.py) ---
            // def _compute_registration_count(self):
            // for record in self:
            //     record.registration_count = len(record.registration_ids)
            */
            return default;
        }

        protected async Task<CrmLead> ComputeSaleDataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_crm, FILE: crm_lead.py) ---
            // def _compute_sale_data(self):
            // for lead in self:
            //     company_currency = lead.company_currency or self.env.company.currency_id
            //     sale_orders = lead.order_ids.filtered_domain(self._get_lead_sale_order_domain())
            //     lead.sale_amount_total = sum(
            //         order.currency_id._convert(
            //             order.amount_untaxed, company_currency, order.company_id, order.date_order or fields.Date.today()
            //         )
            //         for order in sale_orders
            //     )
            //     lead.quotation_count = len(lead.order_ids.filtered_domain(self._get_lead_quotation_domain()))
            //     lead.sale_order_count = len(sale_orders)
            */
            return default;
        }

        protected async Task<CrmLead> ComputeShowEnrichButtonInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_iap_enrich, FILE: crm_lead.py) ---
            // def _compute_show_enrich_button(self):
            // for lead in self:
            //     if not lead.active or not lead.email_from or lead.email_state == 'incorrect' or lead.iap_enrich_done or lead.reveal_id or lead.probability == 100:
            //         lead.show_enrich_button = False
            //     else:
            //         lead.show_enrich_button = True
            */
            return default;
        }

        protected async Task<CrmLead> ComputeStageIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_stage_id(self):
            // for lead in self:
            //     if not lead.stage_id:
            //         lead.stage_id = lead._stage_find(domain=[('fold', '=', False)]).id
            */
            return default;
        }

        protected async Task<CrmLead> ComputeTeamIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_team_id(self):
            // """ When changing the user, also set a team_id or restrict team id
            // to the ones user_id is member of. """
            // for lead in self:
            //     # setting user as void should not trigger a new team computation
            //     if not lead.user_id:
            //         continue
            //     user = lead.user_id
            //     if lead.team_id and user in (lead.team_id.member_ids | lead.team_id.user_id):
            //         continue
            //     team_domain = [('use_leads', '=', True)] if lead.type == 'lead' else [('use_opportunities', '=', True)]
            //     team = self.env['crm.team']._get_default_team_id(user_id=user.id, domain=team_domain)
            //     if lead.team_id != team:
            //         lead.team_id = team.id
            */
            return default;
        }

        protected async Task<CrmLead> ComputeTitleInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_title(self):
            // """ compute the new values when partner_id has changed """
            // for lead in self:
            //     if not lead.title or lead.partner_id.title:
            //         lead.title = lead.partner_id.title
            */
            return default;
        }

        protected async Task<CrmLead> ComputeUserCompanyIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_user_company_ids(self):
            // all_companies = self.env['res.company'].search([])
            // for lead in self:
            //     if not lead.company_id:
            //         lead.user_company_ids = all_companies
            //     else:
            //         lead.user_company_ids = lead.company_id
            */
            return default;
        }

        protected async Task<CrmLead> ComputeVisitorPageCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_crm, FILE: crm_lead.py) ---
            // def _compute_visitor_page_count(self):
            // mapped_data = {}
            // if self.ids:
            //     self.flush_model(['visitor_ids'])
            //     self.env['website.track'].flush_model(['visitor_id'])
            //     sql = """ SELECT l.id as lead_id, count(*) as page_view_count
            //                 FROM crm_lead l
            //                 JOIN crm_lead_website_visitor_rel lv ON l.id = lv.crm_lead_id
            //                 JOIN website_visitor v ON v.id = lv.website_visitor_id
            //                 JOIN website_track p ON p.visitor_id = v.id
            //                 WHERE l.id in %s
            //                 GROUP BY l.id"""
            //     self.env.cr.execute(sql, (tuple(self.ids),))
            //     page_data = self.env.cr.dictfetchall()
            //     mapped_data = {data['lead_id']: data['page_view_count'] for data in page_data}
            // for lead in self:
            //     lead.visitor_page_count = mapped_data.get(lead.id, 0)
            */
            return default;
        }

        protected async Task<CrmLead> ComputeVisitorSessionsCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_crm_livechat, FILE: crm_lead.py) ---
            // def _compute_visitor_sessions_count(self):
            // for lead in self:
            //     lead.visitor_sessions_count = len(lead.visitor_ids.discuss_channel_ids)
            */
            return default;
        }

        protected async Task<CrmLead> ComputeWebsiteInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _compute_website(self):
            // """ compute the new values when partner_id has changed """
            // for lead in self:
            //     if not lead.website or lead.partner_id.website:
            //         lead.website = lead.partner_id.website
            */
            return default;
        }

        public async Task<CrmLead> ConvertOpportunityAsync(Guid id, CrmLeadConvertOpportunityRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def convert_opportunity(self, partner, user_ids=False, team_id=False):
            // customer = partner if partner else self.env['res.partner']
            // for lead in self:
            //     if not lead.active or lead.probability == 100:
            //         continue
            //     vals = lead._convert_opportunity_data(customer, team_id)
            //     lead.write(vals)
            // 
            // if user_ids or team_id:
            //     self._handle_salesmen_assignment(user_ids=user_ids, team_id=team_id)
            // 
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<CrmLead> ConvertOpportunityDataInternalAsync(object customer, Guid team_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _convert_opportunity_data(self, customer, team_id=False):
            // """ Extract the data from a lead to create the opportunity
            //     :param customer : res.partner record
            //     :param team_id : identifier of the Sales Team to determine the stage
            // """
            // new_team_id = team_id if team_id else self.team_id.id
            // upd_values = {
            //     'type': 'opportunity',
            //     'date_conversion': self.env.cr.now(),
            // }
            // if customer != self.partner_id:
            //     upd_values['partner_id'] = customer.id if customer else False
            // if not self.stage_id:
            //     stage = self._stage_find(team_id=new_team_id)
            //     upd_values['stage_id'] = stage.id
            // return upd_values
            */
            return default;
        }

        public async Task<CrmLead> CopyDataAsync(Guid id, CrmLeadCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def copy_data(self, default=None):
            // # set default value in context, if not already set (Put stage to 'new' stage)
            // # Set date_open to today if it is an opp
            // default = dict(default or {})
            // if not self.env.user.has_group('crm.group_use_recurring_revenues'):
            //     default['recurring_revenue'] = 0
            //     default['recurring_plan'] = False
            // vals_list = super().copy_data(default=default)
            // now = self.env.cr.now()
            // for lead, vals in zip(self, vals_list):
            //     vals.setdefault('type', lead.type)
            //     vals.setdefault('team_id', lead.team_id.id)
            //     vals['date_open'] = now if lead.type == 'opportunity' else False
            //     if not lead.user_id.active:
            //         vals['user_id'] = False
            // return vals_list
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<CrmLead> CreateAsync(CrmLead entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     if vals.get('website'):
            //         vals['website'] = self.env['res.partner']._clean_website(vals['website'])
            // leads = super(Lead, self).create(vals_list)
            // 
            // for lead, values in zip(leads, vals_list):
            //     if any(field in ['active', 'stage_id'] for field in values):
            //         lead._handle_won_lost(values)
            // 
            // return leads
            --- ODOO METHOD SOURCE (MODULE: crm_iap_enrich, FILE: crm_lead.py) ---
            // def create(self, vals_list):
            // leads = super(Lead, self).create(vals_list)
            // enrich_mode = self.env['ir.config_parameter'].sudo().get_param('crm.iap.lead.enrich.setting', 'auto')
            // if enrich_mode == 'auto':
            //     cron = self.env.ref('crm_iap_enrich.ir_cron_lead_enrichment', raise_if_not_found=False)
            //     if cron:
            //         cron._trigger()
            // return leads
            */
            return await base.CreateAsync(entity, fields);
        }

        protected async Task<CrmLead> CreateCustomerInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _create_customer(self):
            // """ Create a partner from lead data and link it to the lead.
            // 
            // :return: newly-created partner browse record
            // """
            // Partner = self.env['res.partner']
            // contact_name = self.contact_name
            // if not contact_name:
            //     contact_name = parse_contact_from_email(self.email_from)[0] if self.email_from else False
            // 
            // if self.partner_name:
            //     partner_company = Partner.create(self._prepare_customer_values(self.partner_name, is_company=True))
            // elif self.partner_id:
            //     partner_company = self.partner_id
            // else:
            //     partner_company = None
            // 
            // if contact_name:
            //     return Partner.create(self._prepare_customer_values(contact_name, is_company=False, parent_id=partner_company.id if partner_company else False))
            // 
            // if partner_company:
            //     return partner_company
            // return Partner.create(self._prepare_customer_values(self.name, is_company=False))
            */
            return default;
        }

        public async Task<CrmLead> CreateOppPortalAsync(Guid id, CrmLeadCreateOppPortalRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: crm_lead.py) ---
            // def create_opp_portal(self, values):
            // if not (self.env.user.partner_id.grade_id or self.env.user.commercial_partner_id.grade_id):
            //     raise AccessDenied()
            // user = self.env.user
            // self = self.sudo()
            // if not (values['contact_name'] and values['description'] and values['title']):
            //     return {
            //         'errors': _('All fields are required!')
            //     }
            // tag_own = self.env.ref('website_crm_partner_assign.tag_portal_lead_own_opp', False)
            // values = {
            //     'contact_name': values['contact_name'],
            //     'name': values['title'],
            //     'description': values['description'],
            //     'priority': '2',
            //     'partner_assigned_id': user.commercial_partner_id.id,
            // }
            // if tag_own:
            //     values['tag_ids'] = [(4, tag_own.id, False)]
            // 
            // lead = self.create(values)
            // lead.assign_salesman_of_assigned_partner()
            // lead.convert_opportunity(lead.partner_id)
            // return {
            //     'id': lead.id
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<CrmLead> CreationMessageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _creation_message(self):
            // self.ensure_one()
            // if self.team_id:
            //     return _('A new lead has been created for the team "%(team_name)s".', team_name=self.team_id.display_name)
            // return _('A new lead has been created and is not assigned to any team.')
            */
            return default;
        }

        protected async Task<CrmLead> CreationSubtypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _creation_subtype(self):
            // return self.env.ref('crm.mt_lead_create')
            */
            return default;
        }

        protected async Task<CrmLead> CronUpdateAutomatedProbabilitiesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _cron_update_automated_probabilities(self):
            // """ This cron will :
            //   - rebuild the lead scoring frequency table
            //   - recompute all the automated_probability and align probability if both were aligned
            // """
            // cron_start_date = datetime.now()
            // self._rebuild_pls_frequency_table()
            // self._update_automated_probabilities()
            // _logger.info("Predictive Lead Scoring : Cron duration = %d seconds" % ((datetime.now() - cron_start_date).total_seconds()))
            */
            return default;
        }

        protected async Task<CrmLead> FindMatchingPartnerInternalAsync(object email_only)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _find_matching_partner(self, email_only=False):
            // """ Try to find a matching partner with available information on the
            // lead, using notably customer's name, email, ...
            // 
            // :param email_only: Only find a matching based on the email. To use
            //     for automatic process where ilike based on name can be too dangerous
            // :return: partner browse record
            // """
            // self.ensure_one()
            // partner = self.partner_id
            // 
            // if not partner and self.email_from:
            //     partner = self.env['res.partner'].search([('email', '=', self.email_from)], limit=1)
            // 
            // if not partner and not email_only:
            //     # search through the existing partners based on the lead's partner or contact name
            //     # to be aligned with _create_customer, search on lead's name as last possibility
            //     for customer_potential_name in [self[field_name] for field_name in ['partner_name', 'contact_name', 'name'] if self[field_name]]:
            //         partner = self.env['res.partner'].search([('name', 'ilike', customer_potential_name)], limit=1)
            //         if partner:
            //             break
            // 
            // return partner
            */
            return default;
        }

        protected async Task<CrmLead> FormViewAutoFillInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_mail_plugin, FILE: crm_lead.py) ---
            // def _form_view_auto_fill(self):
            // """
            //     deprecated as of saas-14.3, not needed for newer versions of the mail plugin but necessary
            //     for supporting older versions
            // """
            // return {
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'form',
            //     'res_model': 'crm.lead',
            //     'context': {
            //         'default_partner_id': self.env.context.get('params', {}).get('partner_id'),
            //     }
            // }
            */
            return default;
        }

        protected async Task<CrmLead> FormatPropertiesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _format_properties(self):
            // """Format the properties to build the merge message.
            // 
            // Return a list of dict containing the label, and a value key if there's only
            // one value, or a "values" key if we have multiple values (e.g. many2many, tags).
            // 
            // E.G.
            //     [{
            //         'label': 'My Partner',
            //         'value': 'Alice',
            //     }, {
            //         'label': 'My Partners',
            //         'values': [
            //             {'name': 'Alice'},
            //             {'name': 'Bob'},
            //         ],
            //     }, {
            //         'label': 'My Tags',
            //         'values': [
            //             {'name': 'A', 'color': 1},
            //             {'name': 'C', 'color': 3},
            //         ],
            //     }]
            // """
            // self.ensure_one()
            // # read to have the display names already in the value
            // properties = self.read(['lead_properties'])[0]['lead_properties']
            // 
            // formatted = []
            // for definition in properties:
            //     label = definition.get('string')
            //     value = definition.get('value')
            //     property_type = definition['type']
            //     if not value and property_type != 'boolean':
            //         continue
            // 
            //     property_dict = {'label': label}
            //     if property_type == 'boolean':
            //         property_dict['value'] = _('Yes') if value else _('No')
            //     elif value and property_type == 'many2one':
            //         property_dict['value'] = value[1]
            //     elif value and property_type == 'many2many':
            //         # show many2many in badge
            //         property_dict['values'] = [{'name': rec[1]} for rec in value]
            //     elif value and property_type in ['selection', 'tags']:
            //         # retrieve the option label from the value
            //         options = {
            //             option[0]: option[1:]
            //             for option in (definition.get(property_type) or [])
            //         }
            //         if property_type == 'selection':
            //             value = options.get(value)
            //             property_dict['value'] = value[0] if value else None
            //         else:
            //             property_dict['values'] = [{
            //                 'name': options[tag][0],
            //                 'color': options[tag][1],
            //                 } for tag in value if tag in options
            //             ]
            //     else:
            //         property_dict['value'] = value
            // 
            //     formatted.append(property_dict)
            // 
            // return formatted
            */
            return default;
        }

        public async Task<CrmLead> GenerateLeadsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_lead.py) ---
            // def action_generate_leads(self):
            // return {
            //     "name": _("Need help reaching your target?"),
            //     "type": "ir.actions.act_window",
            //     "res_model": "crm.iap.lead.mining.request",
            //     "target": "new",
            //     "views": [[False, "form"]],
            //     "context": {"is_modal": True},
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<CrmLead> GetAccessActionInternalAsync(object access_uid, object force_website)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: crm_lead.py) ---
            // def _get_access_action(self, access_uid=None, force_website=False):
            // """ Instead of the classic form view, redirect to the online document for
            // portal users or if force_website=True. """
            // self.ensure_one()
            // 
            // user, record = self.env.user, self
            // if access_uid:
            //     try:
            //         record.check_access("read")
            //     except AccessError:
            //         return super(CrmLead, self)._get_access_action(access_uid=access_uid, force_website=force_website)
            //     user = self.env['res.users'].sudo().browse(access_uid)
            //     record = self.with_user(user)
            // if user.share or force_website:
            //     try:
            //         record.check_access('read')
            //     except AccessError:
            //         pass
            //     else:
            //         return {
            //             'type': 'ir.actions.act_url',
            //             'url': '/my/opportunity/%s' % record.id,
            //         }
            // return super(CrmLead, self)._get_access_action(access_uid=access_uid, force_website=force_website)
            */
            return default;
        }

        protected async Task<CrmLead> GetActionViewSaleQuotationDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_crm, FILE: crm_lead.py) ---
            // def _get_action_view_sale_quotation_domain(self):
            // return [('state', 'in', ('draft', 'sent', 'cancel'))]
            */
            return default;
        }

        protected async Task<CrmLead> GetCustomerInformationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _get_customer_information(self):
            // email_normalized_to_values = super()._get_customer_information()
            // Partner = self.env['res.partner']
            // 
            // for record in self.filtered('email_normalized'):
            //     values = email_normalized_to_values.setdefault(record.email_normalized, {})
            //     contact_name = record.contact_name or record.partner_name or parse_contact_from_email(record.email_from)[0] or record.email_from
            //     # Note that we don't attempt to create the parent company even if partner name is set
            //     values.update(record._prepare_customer_values(contact_name, is_company=False))
            //     values['company_name'] = record.partner_name
            //     if contact_name == record.partner_name:
            //         values['company_type'] = 'company'
            // return email_normalized_to_values
            */
            return default;
        }

        public async Task<CrmLead> GetEmptyListHelpAsync(Guid id, CrmLeadGetEmptyListHelpRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def get_empty_list_help(self, help_message):
            // """ This method returns the action helpers for the leads. If help is already provided
            //     on the action, the same is returned. Otherwise, we build the help message which
            //     contains the alias responsible for creating the lead (if available) and return it.
            // """
            // if not is_html_empty(help_message):
            //     return help_message
            // 
            // help_title, sub_title = "", ""
            // if self._context.get('default_type') == 'lead':
            //     help_title = _('Create a new lead')
            // else:
            //     help_title = _('Create an opportunity to start playing with your pipeline.')
            // alias_domain = [
            //     ('company_id', 'in', [self.env.company.id, False]),
            //     ('alias_id.alias_name', '!=', False),
            //     ('alias_id.alias_name', '!=', ''),
            //     ('alias_id.alias_model_id.model', '=', 'crm.lead'),
            // ]
            // # sort by use_leads, then by our membership of the team
            // alias_records = self.env['crm.team'].search(alias_domain).sorted(
            //     lambda r: (r.use_leads, self.env.user in r.member_ids), reverse=True
            // )
            // alias_record = alias_records[0] if alias_records else None
            // if alias_record and alias_record.alias_domain and alias_record.alias_name:
            //     sub_title = Markup(_('Use the <i>New</i> button, or send an email to %(email_link)s to test the email gateway.')) % {
            //         'email_link': Markup("<b><a href='mailto:%s'>%s</a></b>") % (alias_record.alias_email, alias_record.alias_email),
            //     }
            // return super().get_empty_list_help(
            //     f'<p class="o_view_nocontent_smiling_face">{help_title}</p><p class="oe_view_nocontent_alias">{sub_title}</p>'
            // )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<CrmLead> GetImportTemplatesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def get_import_templates(self):
            // return [{
            //     'label': _('Import Template for Leads & Opportunities'),
            //     'template': '/crm/static/xls/crm_lead.xls'
            // }]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<CrmLead> GetLeadDuplicatesInternalAsync(object partner, object email, object include_lost)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _get_lead_duplicates(self, partner=None, email=None, include_lost=False):
            // """ Search for leads that seem duplicated based on partner / email.
            // 
            // :param partner : optional customer when searching duplicated
            // :param email: email (possibly formatted) to search
            // :param boolean include_lost: if True, search includes archived opportunities
            //   (still only active leads are considered). If False, search for active
            //   and not won leads and opportunities;
            // """
            // if not email and not partner:
            //     return self.env['crm.lead']
            // 
            // domain = []
            // for normalized_email in [tools.email_normalize(email) for email in tools.email_split(email)]:
            //     domain.append(('email_normalized', '=', normalized_email))
            // if partner:
            //     domain.append(('partner_id', '=', partner.id))
            // 
            // if not domain:
            //     return self.env['crm.lead']
            // 
            // domain = ['|'] * (len(domain) - 1) + domain
            // if include_lost:
            //     domain += ['|', ('type', '=', 'opportunity'), ('active', '=', True)]
            // else:
            //     domain += ['&', ('active', '=', True), '|', ('stage_id', '=', False), ('stage_id.is_won', '=', False)]
            // 
            // return self.with_context(active_test=False).search(domain)
            */
            return default;
        }

        protected async Task<CrmLead> GetLeadQuotationDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_crm, FILE: crm_lead.py) ---
            // def _get_lead_quotation_domain(self):
            // return [('state', 'in', ('draft', 'sent'))]
            */
            return default;
        }

        protected async Task<CrmLead> GetLeadSaleOrderDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_crm, FILE: crm_lead.py) ---
            // def _get_lead_sale_order_domain(self):
            // return [('state', 'not in', ('draft', 'sent', 'cancel'))]
            */
            return default;
        }

        protected async Task<CrmLead> GetOpportunityMeetingViewParametersInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _get_opportunity_meeting_view_parameters(self):
            // """ Return the most relevant parameters for calendar view when viewing meetings linked to an opportunity.
            //     If there are any meetings that are not finished yet, only consider those meetings,
            //     since the user would prefer no to see past meetings. Otherwise, consider all meetings.
            //     Allday events datetimes are used without taking tz into account.
            //     -If there is no event, return week mode and false (The calendar will target 'now' by default)
            //     -If there is only one, return week mode and date of the start of the event.
            //     -If there are several events entirely on the same week, return week mode and start of first event.
            //     -Else, return month mode and the date of the start of first event as initial date. (If they are
            //     on the same month, this will display that month and therefore show all of them, which is expected)
            // 
            //     :return tuple(mode, initial_date)
            //         - mode: selected mode of the calendar view, 'week' or 'month'
            //         - initial_date: date of the start of the first relevant meeting. The calendar will target that date.
            // """
            // self.ensure_one()
            // meeting_results = self.env["calendar.event"].search_read([('opportunity_id', '=', self.id)], ['start', 'stop', 'allday'])
            // if not meeting_results:
            //     return "week", False
            // 
            // user_tz = self.env.user.tz or self.env.context.get('tz')
            // user_pytz = pytz.timezone(user_tz) if user_tz else pytz.utc
            // 
            // # meeting_dts will contain one tuple of datetimes per meeting : (Start, Stop)
            // # meetings_dts and now_dt are as per user time zone.
            // meeting_dts = []
            // now_dt = datetime.now().astimezone(user_pytz).replace(tzinfo=None)
            // 
            // # When creating an allday meeting, whatever the TZ, it will be stored the same e.g. 00.00.00->23.59.59 in utc or
            // # 08.00.00->18.00.00. Therefore we must not put it back in the user tz but take it raw.
            // for meeting in meeting_results:
            //     if meeting.get('allday'):
            //         meeting_dts.append((meeting.get('start'), meeting.get('stop')))
            //     else:
            //         meeting_dts.append((meeting.get('start').astimezone(user_pytz).replace(tzinfo=None),
            //                            meeting.get('stop').astimezone(user_pytz).replace(tzinfo=None)))
            // 
            // # If there are meetings that are still ongoing or to come, only take those.
            // unfinished_meeting_dts = [meeting_dt for meeting_dt in meeting_dts if meeting_dt[1] >= now_dt]
            // relevant_meeting_dts = unfinished_meeting_dts if unfinished_meeting_dts else meeting_dts
            // relevant_meeting_count = len(relevant_meeting_dts)
            // 
            // if relevant_meeting_count == 1:
            //     return "week", relevant_meeting_dts[0][0].date()
            // else:
            //     # Range of meetings
            //     earliest_start_dt = min(relevant_meeting_dt[0] for relevant_meeting_dt in relevant_meeting_dts)
            //     latest_stop_dt = max(relevant_meeting_dt[1] for relevant_meeting_dt in relevant_meeting_dts)
            // 
            //     # The week start day depends on language. We fetch the week_start of user's language. 1 is monday.
            //     lang_week_start = self.env["res.lang"].search_read([('code', '=', self.env.user.lang)], ['week_start'])
            //     # We substract one to make week_start_index range 0-6 instead of 1-7
            //     week_start_index = int(lang_week_start[0].get('week_start', '1')) - 1
            // 
            //     # We compute the weekday of earliest_start_dt according to week_start_index. earliest_start_dt_index will be 0 if we are on the
            //     # first day of the week and 6 on the last. weekday() returns 0 for monday and 6 for sunday. For instance, Tuesday in UK is the
            //     # third day of the week, so earliest_start_dt_index is 2, and remaining_days_in_week includes tuesday, so it will be 5.
            //     # The first term 7 is there to avoid negative left side on the modulo, improving readability.
            //     earliest_start_dt_weekday = (7 + earliest_start_dt.weekday() - week_start_index) % 7
            //     remaining_days_in_week = 7 - earliest_start_dt_weekday
            // 
            //     # We compute the start of the week following the one containing the start of the first meeting.
            //     next_week_start_date = earliest_start_dt.date() + timedelta(days=remaining_days_in_week)
            // 
            //     # Latest_stop_dt must be before the start of following week. Limit is therefore set at midnight of first day, included.
            //     meetings_in_same_week = latest_stop_dt <= datetime(next_week_start_date.year, next_week_start_date.month, next_week_start_date.day, 0, 0, 0)
            // 
            //     if meetings_in_same_week:
            //         return "week", earliest_start_dt.date()
            //     else:
            //         return "month", earliest_start_dt.date()
            */
            return default;
        }

        protected async Task<CrmLead> GetPartnerEmailUpdateInternalAsync(object force_void)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _get_partner_email_update(self, force_void=True):
            // """Calculate if we should write the email on the related partner. When
            // the email of the lead / partner is an empty string, we force it to False
            // to not propagate a False on an empty string.
            // 
            // Done in a separate method so it can be used in both ribbon and inverse
            // and compute of email update methods.
            // 
            // :param bool force_void: if False, skip when lead has a void email value.
            //   This is used notably to avoid propagating void lead value to a valid
            //   partner value.
            // """
            // self.ensure_one()
            // if self.partner_id and (force_void or self.email_from) and self.email_from != self.partner_id.email:
            //     lead_email_normalized = tools.email_normalize(self.email_from) or self.email_from or False
            //     partner_email_normalized = tools.email_normalize(self.partner_id.email) or self.partner_id.email or False
            //     return lead_email_normalized != partner_email_normalized
            // return False
            */
            return default;
        }

        protected async Task<CrmLead> GetPartnerPhoneUpdateInternalAsync(object force_void)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _get_partner_phone_update(self, force_void=True):
            // """Calculate if we should write the phone on the related partner. When
            // the phone of the lead / partner is an empty string, we force it to False
            // to not propagate a False on an empty string.
            // 
            // Done in a separate method so it can be used in both ribbon and inverse
            // and compute of phone update methods.
            // 
            // :param bool force_void: if False, skip when lead has a void phone value.
            //   This is used notably to avoid propagating void lead value to a valid
            //   partner value.
            // """
            // self.ensure_one()
            // if self.partner_id and (force_void or self.phone) and self.phone != self.partner_id.phone:
            //     lead_phone_formatted = self._phone_format(fname='phone') or self.phone or False
            //     partner_phone_formatted = self.partner_id._phone_format(fname='phone') or self.partner_id.phone or False
            //     return lead_phone_formatted != partner_phone_formatted
            // return False
            */
            return default;
        }

        public async Task<CrmLead> GetRainbowmanMessageAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def get_rainbowman_message(self):
            // self.ensure_one()
            // if self.stage_id.is_won:
            //     return self._get_rainbowman_message()
            // return False
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<CrmLead> GetRainbowmanMessageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _get_rainbowman_message(self):
            // if not self.user_id or not self.team_id:
            //     return False
            // if not self.expected_revenue:
            //     # Show rainbow man for the first won lead of a salesman, even if expected revenue is not set. It is not
            //     # very often that leads without revenues are marked won, so simply get count using ORM instead of query
            //     today = fields.Datetime.today()
            //     user_won_leads_count = self.search_count([
            //         ('type', '=', 'opportunity'),
            //         ('user_id', '=', self.user_id.id),
            //         ('probability', '=', 100),
            //         ('date_closed', '>=', date_utils.start_of(today, 'year')),
            //         ('date_closed', '<', date_utils.end_of(today, 'year')),
            //     ])
            //     if user_won_leads_count == 1:
            //         return _('Go, go, go! Congrats for your first deal.')
            //     return False
            // 
            // self.flush_model()  # flush fields to make sure DB is up to date
            // query = """
            //     SELECT
            //         SUM(CASE WHEN user_id = %(user_id)s THEN 1 ELSE 0 END) as total_won,
            //         MAX(CASE WHEN date_closed >= CURRENT_DATE - INTERVAL '30 days' AND user_id = %(user_id)s THEN expected_revenue ELSE 0 END) as max_user_30,
            //         MAX(CASE WHEN date_closed >= CURRENT_DATE - INTERVAL '7 days' AND user_id = %(user_id)s THEN expected_revenue ELSE 0 END) as max_user_7,
            //         MAX(CASE WHEN date_closed >= CURRENT_DATE - INTERVAL '30 days' AND team_id = %(team_id)s THEN expected_revenue ELSE 0 END) as max_team_30,
            //         MAX(CASE WHEN date_closed >= CURRENT_DATE - INTERVAL '7 days' AND team_id = %(team_id)s THEN expected_revenue ELSE 0 END) as max_team_7
            //     FROM crm_lead
            //     WHERE
            //         type = 'opportunity'
            //     AND
            //         active = True
            //     AND
            //         probability = 100
            //     AND
            //         DATE_TRUNC('year', date_closed) = DATE_TRUNC('year', CURRENT_DATE)
            //     AND
            //         (user_id = %(user_id)s OR team_id = %(team_id)s)
            // """
            // self.env.cr.execute(query, {'user_id': self.user_id.id,
            //                             'team_id': self.team_id.id})
            // query_result = self.env.cr.dictfetchone()
            // 
            // message = False
            // if query_result['total_won'] == 1:
            //     message = _('Go, go, go! Congrats for your first deal.')
            // elif query_result['max_team_30'] == self.expected_revenue:
            //     message = _('Boom! Team record for the past 30 days.')
            // elif query_result['max_team_7'] == self.expected_revenue:
            //     message = _('Yeah! Deal of the last 7 days for the team.')
            // elif query_result['max_user_30'] == self.expected_revenue:
            //     message = _('You just beat your personal record for the past 30 days.')
            // elif query_result['max_user_7'] == self.expected_revenue:
            //     message = _('You just beat your personal record for the past 7 days.')
            // return message
            */
            return default;
        }

        protected async Task<CrmLead> HandlePartnerAssignmentInternalAsync(Guid force_partner_id, object create_missing)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _handle_partner_assignment(self, force_partner_id=False, create_missing=True):
            // """ Update customer (partner_id) of leads. Purpose is to set the same
            // partner on most leads; either through a newly created partner either
            // through a given partner_id.
            // 
            // :param int force_partner_id: if set, update all leads to that customer;
            // :param create_missing: for leads without customer, create a new one
            //   based on lead information;
            // """
            // for lead in self:
            //     if force_partner_id:
            //         lead.partner_id = force_partner_id
            //     if not lead.partner_id and create_missing:
            //         partner = lead._create_customer()
            //         lead.partner_id = partner.id
            */
            return default;
        }

        protected async Task<CrmLead> HandleSalesmenAssignmentInternalAsync(List<Guid> user_ids, Guid team_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _handle_salesmen_assignment(self, user_ids=False, team_id=False):
            // """ Assign salesmen and salesteam to a batch of leads.  If there are more
            // leads than salesmen, these salesmen will be assigned in round-robin. E.g.
            // 4 salesmen (S1, S2, S3, S4) for 6 leads (L1, L2, ... L6) will assigned as
            // following: L1 - S1, L2 - S2, L3 - S3, L4 - S4, L5 - S1, L6 - S2.
            // 
            // :param list user_ids: salesmen to assign
            // :param int team_id: salesteam to assign
            // """
            // update_vals = {'team_id': team_id} if team_id else {}
            // if not user_ids and team_id:
            //     self.write(update_vals)
            // else:
            //     lead_ids = self.ids
            //     steps = len(user_ids)
            //     # pass 1 : lead_ids[0:6:3] = [L1,L4]
            //     # pass 2 : lead_ids[1:6:3] = [L2,L5]
            //     # pass 3 : lead_ids[2:6:3] = [L3,L6]
            //     # ...
            //     for idx in range(0, steps):
            //         subset_ids = lead_ids[idx:len(lead_ids):steps]
            //         update_vals['user_id'] = user_ids[idx]
            //         self.env['crm.lead'].browse(subset_ids).write(update_vals)
            */
            return default;
        }

        protected async Task<CrmLead> HandleWonLostInternalAsync(object vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _handle_won_lost(self, vals):
            // """ This method handle the state changes :
            // - To lost : We need to increment corresponding lost count in scoring frequency table
            // - To won : We need to increment corresponding won count in scoring frequency table
            // - From lost to Won : We need to decrement corresponding lost count + increment corresponding won count
            // in scoring frequency table.
            // - From won to lost : We need to decrement corresponding won count + increment corresponding lost count
            // in scoring frequency table."""
            // Lead = self.env['crm.lead']
            // leads_reach_won = Lead
            // leads_leave_won = Lead
            // leads_reach_lost = Lead
            // leads_leave_lost = Lead
            // won_stage_ids = self.env['crm.stage'].search([('is_won', '=', True)]).ids
            // for lead in self:
            //     if 'stage_id' in vals:
            //         if vals['stage_id'] in won_stage_ids:
            //             if lead.probability == 0:
            //                 leads_leave_lost += lead
            //             leads_reach_won += lead
            //         elif lead.stage_id.id in won_stage_ids and lead.active:  # a lead can be lost at won_stage
            //             leads_leave_won += lead
            //     if 'active' in vals:
            //         if not vals['active'] and lead.active:  # archive lead
            //             if lead.stage_id.id in won_stage_ids and lead not in leads_leave_won:
            //                 leads_leave_won += lead
            //             leads_reach_lost += lead
            //         elif vals['active'] and not lead.active:  # restore lead
            //             leads_leave_lost += lead
            // 
            // leads_reach_won._pls_increment_frequencies(to_state='won')
            // leads_leave_won._pls_increment_frequencies(from_state='won')
            // leads_reach_lost._pls_increment_frequencies(to_state='lost')
            // leads_leave_lost._pls_increment_frequencies(from_state='lost')
            */
            return default;
        }

        public async Task<CrmLead> IapEnrichAsync(Guid id, CrmLeadIapEnrichRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_iap_enrich, FILE: crm_lead.py) ---
            // def iap_enrich(self, from_cron=False):
            // # Split self in a list of sub-recordsets or 50 records to prevent timeouts
            // batches = [self[index:index + 50] for index in range(0, len(self), 50)]
            // for leads in batches:
            //     lead_emails = {}
            //     with self._cr.savepoint():
            //         try:
            //             self._cr.execute(
            //                 "SELECT 1 FROM {} WHERE id in %(lead_ids)s FOR UPDATE NOWAIT".format(self._table),
            //                 {'lead_ids': tuple(leads.ids)}, log_exceptions=False)
            //             for lead in leads:
            //                 # If lead is lost, active == False, but is anyway removed from the search in the cron.
            //                 if lead.probability == 100 or lead.iap_enrich_done:
            //                     continue
            //                 # Skip if no email (different from wrong email leading to no email_normalized)
            //                 if not lead.email_from:
            //                     continue
            // 
            //                 normalized_email = tools.email_normalize(lead.email_from)
            //                 if not normalized_email:
            //                     lead.message_post_with_source(
            //                         'crm_iap_enrich.mail_message_lead_enrich_no_email',
            //                         subtype_xmlid='mail.mt_note',
            //                     )
            //                     continue
            // 
            //                 email_domain = normalized_email.split('@')[1]
            //                 # Discard domains of generic email providers as it won't return relevant information
            //                 if email_domain in iap_tools._MAIL_PROVIDERS:
            //                     lead.write({'iap_enrich_done': True})
            //                     lead.message_post_with_source(
            //                         'crm_iap_enrich.mail_message_lead_enrich_notfound',
            //                         subtype_xmlid='mail.mt_note',
            //                     )
            //                 else:
            //                     lead_emails[lead.id] = email_domain
            // 
            //             if lead_emails:
            //                 try:
            //                     iap_response = self.env['iap.enrich.api']._request_enrich(lead_emails)
            //                 except iap_tools.InsufficientCreditError:
            //                     _logger.info('Lead enrichment failed because of insufficient credit')
            //                     if not from_cron:
            //                         self.env['iap.account']._send_no_credit_notification(
            //                             service_name='reveal',
            //                             title=_("Not enough credits for Lead Enrichment"))
            //                     # Since there are no credits left, there is no point to process the other batches
            //                     break
            //                 except Exception as e:
            //                     if not from_cron:
            //                         self.env['iap.account']._send_error_notification(
            //                             message=_('An error occurred during lead enrichment'))
            //                     _logger.info('An error occurred during lead enrichment: %s', e)
            //                 else:
            //                     if not from_cron:
            //                         self.env['iap.account']._send_success_notification(
            //                             message=_("The leads/opportunities have successfully been enriched"))
            //                     _logger.info('Batch of %s leads successfully enriched', len(lead_emails))
            //                     self._iap_enrich_from_response(iap_response)
            //         except OperationalError:
            //             _logger.error('A batch of leads could not be enriched :%s', repr(leads))
            //             continue
            //     # Commit processed batch to avoid complete rollbacks and therefore losing credits.
            //     if not self.env.registry.in_test_mode():
            //         self.env.cr.commit()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<CrmLead> IapEnrichFromResponseInternalAsync(object iap_response)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_iap_enrich, FILE: crm_lead.py) ---
            // def _iap_enrich_from_response(self, iap_response):
            // """ Handle from the service and enrich the lead accordingly
            // 
            // :param iap_response: dict{lead_id: company data or False}
            // """
            // for lead in self.search([('id', 'in', list(iap_response.keys()))]):  # handle unlinked data by performing a search
            //     iap_data = iap_response.get(str(lead.id))
            //     if not iap_data:
            //         lead.write({'iap_enrich_done': True})
            //         lead.message_post_with_source(
            //             'crm_iap_enrich.mail_message_lead_enrich_notfound',
            //             subtype_xmlid='mail.mt_note',
            //         )
            //         continue
            // 
            //     values = {'iap_enrich_done': True}
            //     lead_fields = ['partner_name', 'reveal_id', 'street', 'city', 'zip']
            //     iap_fields = ['name', 'clearbit_id', 'location', 'city', 'postal_code']
            //     for lead_field, iap_field in zip(lead_fields, iap_fields):
            //         if not lead[lead_field] and iap_data.get(iap_field):
            //             values[lead_field] = iap_data[iap_field]
            // 
            //     if not lead.phone and iap_data.get('phone_numbers'):
            //         values['phone'] = iap_data['phone_numbers'][0]
            //     if not lead.mobile and iap_data.get('phone_numbers') and len(iap_data['phone_numbers']) > 1:
            //         values['mobile'] = iap_data['phone_numbers'][1]
            //     if not lead.country_id and iap_data.get('country_code'):
            //         country = self.env['res.country'].search([('code', '=', iap_data['country_code'].upper())])
            //         values['country_id'] = country.id
            //     else:
            //         country = lead.country_id
            //     if not lead.state_id and country and iap_data.get('state_code'):
            //         state = self.env['res.country.state'].search([
            //             ('code', '=', iap_data['state_code']),
            //             ('country_id', '=', country.id)
            //         ])
            //         values['state_id'] = state.id
            // 
            //     lead.write(values)
            // 
            //     template_values = iap_data
            //     template_values['flavor_text'] = _("Lead enriched based on email address")
            //     lead.message_post_with_source(
            //         'iap_mail.enrich_company',
            //         render_values=template_values,
            //         subtype_xmlid='mail.mt_note',
            //     )
            */
            return default;
        }

        protected async Task<CrmLead> IapEnrichLeadsCronInternalAsync(object enrich_hours_delay, object leads_batch_size)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_iap_enrich, FILE: crm_lead.py) ---
            // def _iap_enrich_leads_cron(self, enrich_hours_delay=1, leads_batch_size=1000):
            // timeDelta = self.env.cr.now() - datetime.timedelta(hours=enrich_hours_delay)
            // # Get all leads not lost nor won (lost: active = False)
            // leads = self.search([
            //     ('iap_enrich_done', '=', False),
            //     ('reveal_id', '=', False),
            //     '|', ('probability', '<', 100), ('probability', '=', False),
            //     ('create_date', '>', timeDelta)
            // ], limit=leads_batch_size)
            // leads.iap_enrich(from_cron=True)
            */
            return default;
        }

        protected async Task<CrmLead> InverseEmailFromInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _inverse_email_from(self):
            // for lead in self:
            //     if lead._get_partner_email_update(force_void=False):
            //         lead.partner_id.email = lead.email_from
            */
            return default;
        }

        protected async Task<CrmLead> InversePhoneInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _inverse_phone(self):
            // for lead in self:
            //     if lead._get_partner_phone_update(force_void=False):
            //         lead.partner_id.phone = lead.phone
            */
            return default;
        }

        public async Task<CrmLead> LogMeetingAsync(Guid id, CrmLeadLogMeetingRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def log_meeting(self, meeting):
            // """ Log the meeting info with a link to it in the chatter
            // :param record meeting: the meeting we want to log
            // """
            // if not meeting.duration:
            //     duration = _('unknown')
            // else:
            //     duration = self.env['ir.qweb.field.duration'].value_to_html(meeting.duration, {'unit': 'hour'})
            // meeting_usertime = fields.Datetime.to_string(fields.Datetime.context_timestamp(self, meeting.start))
            // meeting_time = Markup("<time datetime='%(meeting_start)s+00:00'>%(meeting_user_time)s</time>") % {
            //     'meeting_start': meeting.start,
            //     'meeting_user_time': meeting_usertime,
            // }
            // message = Markup("<p>%(meeting)s<br/>%(subject_string)s %(subject_link)s<br/>%(duration)s<p>") % {
            //     'meeting': _("Meeting scheduled at %s", meeting_time),
            //     'subject_string': _("Subject: "),
            //     'subject_link': meeting._get_html_link(),
            //     'duration': _("Duration: %s", duration),
            // }
            // return self.message_post(body=message)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<CrmLead> MergeDataInternalAsync(object fnames)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_data(self, fnames=None):
            // """ Prepare lead/opp data into a dictionary for merging. Different types
            //     of fields are processed in different ways:
            //         - text: all the values are concatenated
            //         - m2m and o2m: those fields aren't processed
            //         - m2o: the first not null value prevails (the other are dropped)
            //         - any other type of field: same as m2o
            // 
            //     :param fields: list of fields to process
            //     :return dict data: contains the merged values of the new opportunity
            // """
            // if fnames is None:
            //     fnames = self._merge_get_fields()
            // fcallables = self._merge_get_fields_specific()
            // address_values = self._merge_get_fields_address()
            // 
            // # helpers
            // def _get_first_not_null(attr, opportunities):
            //     value = False
            //     for opp in opportunities:
            //         if opp[attr]:
            //             value = opp[attr].id if isinstance(opp[attr], models.BaseModel) else opp[attr]
            //             break
            //     return value
            // 
            // # process the field's values
            // data = {}
            // for field_name in fnames:
            //     field = self._fields.get(field_name)
            //     if field is None:
            //         continue
            // 
            //     fcallable = fcallables.get(field_name)
            //     if fcallable and callable(fcallable):
            //         data[field_name] = fcallable(field_name, self)
            //     elif field_name in address_values:
            //         data[field_name] = address_values[field_name]
            //     elif not fcallable and field.type in ('many2many', 'one2many'):
            //         continue
            //     else:
            //         data[field_name] = _get_first_not_null(field_name, self)  # take the first not null
            // 
            // return data
            */
            return default;
        }

        protected async Task<CrmLead> MergeDependencesAttachmentsInternalAsync(object opportunities)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_dependences_attachments(self, opportunities):
            // """ Move attachments of given opportunities to the current one `self`, and rename
            //     the attachments having same name than native ones.
            // 
            // :param opportunities: see ``_merge_dependences``
            // """
            // self.ensure_one()
            // 
            // all_attachments = self.env['ir.attachment'].search([
            //     ('res_model', '=', self._name),
            //     ('res_id', 'in', opportunities.ids)
            // ])
            // 
            // for opportunity in opportunities:
            //     attachments = all_attachments.filtered(lambda attach: attach.res_id == opportunity.id)
            //     for attachment in attachments:
            //         attachment.write({
            //             'res_id': self.id,
            //             'name': _("%(attach_name)s (from %(lead_name)s)",
            //                       attach_name=attachment.name,
            //                       lead_name=opportunity.name[:20]
            //                      )
            //         })
            // return True
            */
            return default;
        }

        protected async Task<CrmLead> MergeDependencesCalendarEventsInternalAsync(object opportunities)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_dependences_calendar_events(self, opportunities):
            // """ Move calender.event from the given opportunities to the current one. `self` is the
            //     crm.lead record destination for event of `opportunities`.
            // :param opportunities: see ``merge_dependences``
            // """
            // self.ensure_one()
            // meetings = self.env['calendar.event'].search([('opportunity_id', 'in', opportunities.ids)])
            // return meetings.write({
            //     'res_id': self.id,
            //     'opportunity_id': self.id,
            // })
            */
            return default;
        }

        protected async Task<CrmLead> MergeDependencesHistoryInternalAsync(object opportunities)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_dependences_history(self, opportunities):
            // """ Move history from the given opportunities to the current one. `self`
            // is the crm.lead record destination for message of `opportunities`.
            // 
            // This method moves
            //   * messages
            //   * activities
            // 
            // :param opportunities: see ``_merge_dependences``
            // """
            // self.ensure_one()
            // # sudo usage: because we want to go through all messages, whatever the real ACLs
            // # current user has on them
            // for opportunity_su in opportunities.sudo():
            //     for message_su in opportunity_su.message_ids:
            //         if message_su.subject:
            //             subject = _("From %(source_name)s: %(source_subject)s", source_name=opportunity_su.name, source_subject=message_su.subject)
            //         else:
            //             subject = _("From %(source_name)s", source_name=opportunity_su.name)
            //         message_su.write({
            //             'res_id': self.id,
            //             'subject': subject,
            //         })
            // opportunities.activity_ids.write({
            //     'res_id': self.id,
            // })
            // 
            // return True
            */
            return default;
        }

        protected async Task<CrmLead> MergeDependencesInternalAsync(object opportunities)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_dependences(self, opportunities):
            // """ Merge dependences (messages, attachments,activities, calendar events,
            // ...). These dependences will be transfered to `self` considered as the
            // master lead.
            // 
            // :param opportunities : recordset of opportunities to transfer. Does not
            //   include `self` which is the target crm.lead being the result of the
            //   merge;
            // """
            // self.ensure_one()
            // self._merge_dependences_history(opportunities)
            // self._merge_dependences_attachments(opportunities)
            // self._merge_dependences_calendar_events(opportunities)
            --- ODOO METHOD SOURCE (MODULE: event_crm, FILE: crm_lead.py) ---
            // def _merge_dependences(self, opportunities):
            // super(Lead, self)._merge_dependences(opportunities)
            // 
            // # merge registrations as sudo, as crm people may not have access to event rights
            // self.sudo().write({
            //     'registration_ids': [(4, registration.id) for registration in opportunities.sudo().registration_ids]
            // })
            */
            return default;
        }

        protected async Task<CrmLead> MergeFollowersInternalAsync(object opportunities)
        {
            #if PYTHON_CODE
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_followers(self, opportunities):
            // """Add the followers into the destination lead if they post a message in the last 30 days.
            // 
            // :param opportunities : Record<crm.lead> of opportunities to transfer
            // :return: {old_lead_id: Record<mail.followers>} Followers which have been added in
            //     the destination lead grouped by source lead ID.
            // """
            // self.ensure_one()
            // 
            // self.env['mail.message'].flush_model()
            // self.env['mail.followers'].flush_model()
            // 
            // # Get the active followers (followers whose partner post a message on the
            // # leads in the last 30 days) which should be moved on the destination lead
            // self.env.cr.execute(
            //     '''
            //     SELECT MAX(mf.id) AS id
            //       FROM mail_followers AS mf
            //       JOIN mail_message AS mm
            //         ON mm.author_id = mf.partner_id
            //        AND mm.res_id = mf.res_id
            //        AND mm.model = 'crm.lead'
            //        AND mm.date > NOW() - INTERVAL '30 DAY'
            //            /* Check if the partner is already
            //               following the destination lead */
            //  LEFT JOIN mail_followers AS destf
            //         ON destf.res_model = 'crm.lead'
            //        AND destf.res_id = %(lead_id)s
            //        AND destf.partner_id = mf.partner_id
            //            /* Select only once each partner
            //               to not create duplicated followers */
            //      WHERE mf.res_model = 'crm.lead'
            //        AND mf.res_id IN %(lead_ids)s
            //        AND destf IS NULL
            //   GROUP BY mf.partner_id
            //     ''',
            //     {'lead_ids': tuple(opportunities.ids), 'lead_id': self.id},
            // )
            // followers_to_update = [r[0] for r in self.env.cr.fetchall()]
            // followers_to_update = self.env['mail.followers'].browse(followers_to_update).sudo()
            // followers_by_old_lead = dict(groupby(followers_to_update, lambda f: f.res_id))
            // followers_to_update.write({'res_id': self.id})
            // return followers_by_old_lead
            #endif
            return default;
        }

        protected async Task<CrmLead> MergeGetFieldsAddressInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_get_fields_address(self):
            // """The address fields are propagated as a whole.
            // 
            // The address is taken from the lead with the most non-empty address field
            // (sorted by highest rank if multiple lead have the same amount of non-empty
            // fields).
            // """
            // source_lead = max(self, key=lambda lead: len(list(
            //     lead[field] for field in PARTNER_ADDRESS_FIELDS_TO_SYNC
            //     if lead[field]
            // )))
            // return {fname: source_lead[fname] for fname in PARTNER_ADDRESS_FIELDS_TO_SYNC}
            */
            return default;
        }

        protected async Task<CrmLead> MergeGetFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_get_fields(self):
            // return (
            //     CRM_LEAD_FIELDS_TO_MERGE
            //     + list(self._merge_get_fields_specific().keys())
            //     + PARTNER_ADDRESS_FIELDS_TO_SYNC
            // )
            --- ODOO METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_lead.py) ---
            // def _merge_get_fields(self):
            // return super(Lead, self)._merge_get_fields() + ['lead_mining_request_id']
            --- ODOO METHOD SOURCE (MODULE: event_crm, FILE: crm_lead.py) ---
            // def _merge_get_fields(self):
            // return super(Lead, self)._merge_get_fields() + ['event_lead_rule_id', 'event_id']
            --- ODOO METHOD SOURCE (MODULE: iap_crm, FILE: crm_lead.py) ---
            // def _merge_get_fields(self):
            // return super(Lead, self)._merge_get_fields() + ['reveal_id']
            --- ODOO METHOD SOURCE (MODULE: website_crm_iap_reveal, FILE: crm_lead.py) ---
            // def _merge_get_fields(self):
            // return super(Lead, self)._merge_get_fields() + ['reveal_ip', 'reveal_iap_credits', 'reveal_rule_id']
            --- ODOO METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: crm_lead.py) ---
            // def _merge_get_fields(self):
            // fields_list = super(CrmLead, self)._merge_get_fields()
            // fields_list += ['partner_latitude', 'partner_longitude', 'partner_assigned_id', 'date_partner_assign']
            // return fields_list
            */
            return default;
        }

        protected async Task<CrmLead> MergeGetFieldsSpecificInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_get_fields_specific(self):
            // return {
            //     'description': lambda fname, leads: '<br/><br/>'.join(desc for desc in leads.mapped('description') if not is_html_empty(desc)),
            //     'type': lambda fname, leads: 'opportunity' if any(lead.type == 'opportunity' for lead in leads) else 'lead',
            //     'priority': lambda fname, leads: max(priorities) if (priorities := leads.filtered('priority').mapped('priority')) else False,
            //     'tag_ids': lambda fname, leads: leads.mapped('tag_ids'),
            //     'lost_reason_id': lambda fname, leads:
            //         False if leads and leads[0].probability
            //         else next((lead.lost_reason_id for lead in leads if lead.lost_reason_id), False),
            // }
            --- ODOO METHOD SOURCE (MODULE: crm_iap_enrich, FILE: crm_lead.py) ---
            // def _merge_get_fields_specific(self):
            // return {
            //     ** super(Lead, self)._merge_get_fields_specific(),
            //     'iap_enrich_done': lambda fname, leads: any(lead.iap_enrich_done for lead in leads),
            // }
            --- ODOO METHOD SOURCE (MODULE: sale_crm, FILE: crm_lead.py) ---
            // def _merge_get_fields_specific(self):
            // fields_info = super(CrmLead, self)._merge_get_fields_specific()
            // # add all the orders from all lead to merge
            // fields_info['order_ids'] = lambda fname, leads: [(4, order.id) for order in leads.order_ids]
            // return fields_info
            --- ODOO METHOD SOURCE (MODULE: website_crm, FILE: crm_lead.py) ---
            // def _merge_get_fields_specific(self):
            // fields_info = super(Lead, self)._merge_get_fields_specific()
            // # add all the visitors from all lead to merge
            // fields_info['visitor_ids'] = lambda fname, leads: [(6, 0, leads.visitor_ids.ids)]
            // return fields_info
            */
            return default;
        }

        protected async Task<CrmLead> MergeLogSummaryInternalAsync(object merged_followers, object opportunities_tail)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_log_summary(self, merged_followers, opportunities_tail):
            // """Log the merge message on the lead."""
            // self.ensure_one()
            // self.message_post_with_source(
            //     "crm.crm_lead_merge_summary",
            //     render_values={
            //         "merged_followers": merged_followers,
            //         "opportunities": opportunities_tail,
            //         "is_html_empty": is_html_empty,
            //     },
            //     subtype_xmlid='mail.mt_note',
            // )
            */
            return default;
        }

        public async Task<CrmLead> MergeOpportunityAsync(Guid id, CrmLeadMergeOpportunityRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def merge_opportunity(self, user_id=False, team_id=False, auto_unlink=True):
            // """ Merge opportunities in one. Different cases of merge:
            //         - merge leads together = 1 new lead
            //         - merge at least 1 opp with anything else (lead or opp) = 1 new opp
            //     The resulting lead/opportunity will be the most important one (based on its confidence level)
            //     updated with values from other opportunities to merge.
            // 
            // :param user_id : the id of the saleperson. If not given, will be determined by `_merge_data`.
            // :param team : the id of the Sales Team. If not given, will be determined by `_merge_data`.
            // 
            // :return crm.lead record resulting of th merge
            // """
            // return self._merge_opportunity(user_id=user_id, team_id=team_id, auto_unlink=auto_unlink)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<CrmLead> MergeOpportunityInternalAsync(Guid user_id, Guid team_id, object auto_unlink, object max_length)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _merge_opportunity(self, user_id=False, team_id=False, auto_unlink=True, max_length=5):
            // """ Private merging method. This one allows to relax rules on record set
            // length allowing to merge more than 5 opportunities at once if requested.
            // This should not be called by action buttons.
            // 
            // See ``merge_opportunity`` for more details. """
            // if len(self.ids) <= 1:
            //     raise UserError(_('Select at least two Leads/Opportunities from the list to merge them.'))
            // 
            // if max_length and len(self.ids) > max_length and not self.env.is_superuser():
            //     raise UserError(_("To prevent data loss, Leads and Opportunities can only be merged by groups of %(max_length)s.", max_length=max_length))
            // 
            // opportunities = self._sort_by_confidence_level(reverse=True)
            // 
            // # get SORTED recordset of head and tail, and complete list
            // opportunities_head = opportunities[0]
            // opportunities_tail = opportunities[1:]
            // 
            // # merge all the sorted opportunity. This means the value of
            // # the first (head opp) will be a priority.
            // merged_data = opportunities._merge_data(self._merge_get_fields())
            // 
            // # force value for saleperson and Sales Team
            // if user_id:
            //     merged_data['user_id'] = user_id
            // if team_id:
            //     merged_data['team_id'] = team_id
            // 
            // merged_followers = opportunities_head._merge_followers(opportunities_tail)
            // 
            // # log merge message
            // opportunities_head._merge_log_summary(merged_followers, opportunities_tail)
            // # merge other data (mail.message, attachments, ...) from tail into head
            // opportunities_head._merge_dependences(opportunities_tail)
            // 
            // # check if the stage is in the stages of the Sales Team. If not, assign the stage with the lowest sequence
            // if merged_data.get('team_id'):
            //     team_stage_ids = self.env['crm.stage'].search(['|', ('team_id', '=', merged_data['team_id']), ('team_id', '=', False)], order='sequence, id')
            //     if merged_data.get('stage_id') not in team_stage_ids.ids:
            //         merged_data['stage_id'] = team_stage_ids[0].id if team_stage_ids else False
            // 
            // # write merged data into first opportunity; remove some keys if already
            // # set on opp to avoid useless recomputes
            // if 'user_id' in merged_data and opportunities_head.user_id.id == merged_data['user_id']:
            //     merged_data.pop('user_id')
            // if 'team_id' in merged_data and opportunities_head.team_id.id == merged_data['team_id']:
            //     merged_data.pop('team_id')
            // opportunities_head.write(merged_data)
            // 
            // # delete tail opportunities
            // # we use the SUPERUSER to avoid access rights issues because as the user had the rights to see the records it should be safe to do so
            // if auto_unlink:
            //     opportunities_tail.sudo().unlink()
            // 
            // return opportunities_head
            */
            return default;
        }

        protected async Task<CrmLead> MessageGetDefaultRecipientsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _message_get_default_recipients(self):
            // return {
            //     r.id: {
            //         'partner_ids': [],
            //         'email_to': ','.join(tools.email_normalize_all(r.email_from)) or r.email_from,
            //         'email_cc': False,
            //     } for r in self
            // }
            */
            return default;
        }

        protected async Task<CrmLead> MessageGetSuggestedRecipientsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _message_get_suggested_recipients(self):
            // recipients = super()._message_get_suggested_recipients()
            // try:
            //     # check if that language is correctly installed (and active) before using it
            //     lang_code = self.env['res.lang']._get_data(code=self.lang_code).code or None
            //     if self.partner_id:
            //         self._message_add_suggested_recipient(
            //             recipients, partner=self.partner_id, lang=lang_code, reason=_('Customer'))
            //     elif self.email_from:
            //         self._message_add_suggested_recipient(
            //             recipients, email=self.email_from, lang=lang_code, reason=_('Customer Email'))
            // except AccessError:  # no read access rights -> just ignore suggested recipients because this imply modifying followers
            //     pass
            // return recipients
            */
            return default;
        }

        public async Task<CrmLead> MessageNewAsync(Guid id, CrmLeadMessageNewRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def message_new(self, msg_dict, custom_values=None):
            // """ Overrides mail_thread message_new that is called by the mailgateway
            //     through message_process.
            //     This override updates the document according to the email.
            // """
            // # remove default author when going through the mail gateway. Indeed we
            // # do not want to explicitly set an user as responsible. We prefer that
            // # assignment is done automatically (scoring) or manually. Otherwise it
            // # would always be root (gateway user). It also allows to exclude portal
            // # and public users.
            // self = self.with_context(default_user_id=False)
            // 
            // if custom_values is None:
            //     custom_values = {}
            // defaults = {
            //     'name':  msg_dict.get('subject') or _("No Subject"),
            //     'email_from': msg_dict.get('from'),
            //     'partner_id': msg_dict.get('author_id', False),
            // }
            // if msg_dict.get('priority') in dict(crm_stage.AVAILABLE_PRIORITIES):
            //     defaults['priority'] = msg_dict.get('priority')
            // defaults.update(custom_values)
            // 
            // return super(Lead, self).message_new(msg_dict, custom_values=defaults)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<CrmLead> MessagePartnerInfoFromEmailsInternalAsync(object emails, object link_mail)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _message_partner_info_from_emails(self, emails, link_mail=False):
            // """ Try to propose a better recipient when having only an email by populating
            // it with the partner_name / contact_name field of the lead e.g. if lead
            // contact_name is "Raoul" and email is "raoul@raoul.fr", suggest
            // "Raoul" <raoul@raoul.fr> as recipient. """
            // result = super(Lead, self)._message_partner_info_from_emails(emails, link_mail=link_mail)
            // if not (self.partner_name or self.contact_name) or not self.email_from:
            //     return result
            // for email, partner_info in zip(emails, result):
            //     if partner_info.get('partner_id') or not email:
            //         continue
            //     # reformat email if no name information
            //     name_emails = tools.mail.email_split_tuples(email)
            //     name_from_email = name_emails[0][0] if name_emails else False
            //     if name_from_email:
            //         continue  # already containing name + email
            //     name_from_email = self.partner_name or self.contact_name
            //     emails_normalized = tools.email_normalize_all(email)
            //     email_normalized = emails_normalized[0] if emails_normalized else False
            //     if email.lower() == self.email_from.lower() or (email_normalized and self.email_normalized == email_normalized):
            //         partner_info['full_name'] = tools.formataddr((
            //             name_from_email,
            //             ','.join(emails_normalized) if emails_normalized else email))
            //         break
            // return result
            */
            return default;
        }

        protected async Task<CrmLead> MessagePostAfterHookInternalAsync(object message, object msg_vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _message_post_after_hook(self, message, msg_vals):
            // if self.email_from and not self.partner_id:
            //     # we consider that posting a message with a specified recipient (not a follower, a specific one)
            //     # on a document without customer means that it was created through the chatter using
            //     # suggested recipients. This heuristic allows to avoid ugly hacks in JS.
            //     new_partner = message.partner_ids.filtered(
            //         lambda partner: partner.email == self.email_from or (self.email_normalized and partner.email_normalized == self.email_normalized)
            //     )
            //     if new_partner:
            //         if new_partner[0].email_normalized:
            //             email_domain = ('email_normalized', '=', new_partner[0].email_normalized)
            //         else:
            //             email_domain = ('email_from', '=', new_partner[0].email)
            //         self.search([
            //             ('partner_id', '=', False), email_domain, ('stage_id.fold', '=', False)
            //         ]).write({'partner_id': new_partner[0].id})
            // return super(Lead, self)._message_post_after_hook(message, msg_vals)
            */
            return default;
        }

        public async Task<CrmLead> NewQuotationAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_crm, FILE: crm_lead.py) ---
            // def action_new_quotation(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("sale_crm.sale_action_quotations_new")
            // action['context'] = self._prepare_opportunity_quotation_context()
            // action['context']['search_default_opportunity_id'] = self.id
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<CrmLead> NotifyByEmailPrepareRenderingContextInternalAsync(object message, object msg_vals, object model_description, object force_email_company, object force_email_lang)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _notify_by_email_prepare_rendering_context(self, message, msg_vals=False, model_description=False,
            //                                            force_email_company=False, force_email_lang=False):
            // render_context = super()._notify_by_email_prepare_rendering_context(
            //     message, msg_vals, model_description=model_description,
            //     force_email_company=force_email_company, force_email_lang=force_email_lang
            // )
            // if self.date_deadline:
            //     render_context['subtitles'].append(
            //         _('Deadline: %s', self.date_deadline.strftime(get_lang(self.env).date_format)))
            // return render_context
            */
            return default;
        }

        protected async Task<CrmLead> NotifyGetRecipientsGroupsInternalAsync(object message, object model_description, object msg_vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _notify_get_recipients_groups(self, message, model_description, msg_vals=None):
            // """ Handle salesman recipients that can convert leads into opportunities
            // and set opportunities as won / lost. """
            // groups = super()._notify_get_recipients_groups(
            //     message, model_description, msg_vals=msg_vals
            // )
            // if not self:
            //     return groups
            // 
            // local_msg_vals = dict(msg_vals or {})
            // 
            // self.ensure_one()
            // if self.type == 'lead':
            //     convert_action = self._notify_get_action_link('controller', controller='/lead/convert', **local_msg_vals)
            //     salesman_actions = [{'url': convert_action, 'title': _('Convert to opportunity')}]
            // else:
            //     won_action = self._notify_get_action_link('controller', controller='/lead/case_mark_won', **local_msg_vals)
            //     lost_action = self._notify_get_action_link('controller', controller='/lead/case_mark_lost', **local_msg_vals)
            //     salesman_actions = [
            //         {'url': won_action, 'title': _('Mark Won')},
            //         {'url': lost_action, 'title': _('Mark Lost')}]
            // 
            // salesman_group_id = self.env.ref('sales_team.group_sale_salesman').id
            // new_group = (
            //     'group_sale_salesman',
            //     lambda pdata: pdata['type'] == 'user' and salesman_group_id in pdata['groups'],
            //     {
            //         'actions': salesman_actions,
            //         'active': True,
            //         'has_button_access': True,
            //     }
            // )
            // 
            // return [new_group] + groups
            */
            return default;
        }

        protected async Task<CrmLead> NotifyGetReplyToInternalAsync(object @default)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _notify_get_reply_to(self, default=None):
            // """ Override to set alias of lead and opportunities to their sales team if any. """
            // aliases = self.mapped('team_id').sudo()._notify_get_reply_to(default=default)
            // res = {lead.id: aliases.get(lead.team_id.id) for lead in self}
            // leftover = self.filtered(lambda rec: not rec.team_id)
            // if leftover:
            //     res.update(super(Lead, leftover)._notify_get_reply_to(default=default))
            // return res
            */
            return default;
        }

        protected async Task<CrmLead> OnchangeMobileValidationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _onchange_mobile_validation(self):
            // if self.mobile:
            //     self.mobile = self._phone_format(fname='mobile', force_format='INTERNATIONAL') or self.mobile
            */
            return default;
        }

        protected async Task<CrmLead> OnchangePhoneValidationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _onchange_phone_validation(self):
            // if self.phone:
            //     self.phone = self._phone_format(fname='phone', force_format='INTERNATIONAL') or self.phone
            */
            return default;
        }

        public async Task<CrmLead> PartnerDesinterestedAsync(Guid id, CrmLeadPartnerDesinterestedRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: crm_lead.py) ---
            // def partner_desinterested(self, comment=False, contacted=False, spam=False):
            // if contacted:
            //     message = Markup('<p>%s</p>') % _('I am not interested by this lead. I contacted the lead.')
            // else:
            //     message = Markup('<p>%s</p>') % _('I am not interested by this lead. I have not contacted the lead.')
            // partner_ids = self.env['res.partner'].search(
            //     [('id', 'child_of', self.env.user.partner_id.commercial_partner_id.id)])
            // self.message_unsubscribe(partner_ids=partner_ids.ids)
            // if comment:
            //     message += Markup('<p>%s</p>') % comment
            // self.message_post(body=message)
            // values = {
            //     'partner_assigned_id': False,
            // }
            // 
            // if spam:
            //     tag_spam = self.env.ref('website_crm_partner_assign.tag_portal_lead_is_spam', False)
            //     if tag_spam and tag_spam not in self.tag_ids:
            //         values['tag_ids'] = [(4, tag_spam.id, False)]
            // if partner_ids:
            //     values['partner_declined_ids'] = [(4, p, 0) for p in partner_ids.ids]
            // self.sudo().write(values)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<CrmLead> PartnerInterestedAsync(Guid id, CrmLeadPartnerInterestedRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: crm_lead.py) ---
            // def partner_interested(self, comment=False):
            // message = Markup('<p>%s</p>') % _('I am interested by this lead.')
            // if comment:
            //     message += Markup('<p>%s</p>') % comment
            // for lead in self:
            //     lead.message_post(body=message)
            //     lead.sudo().convert_opportunity(lead.partner_id)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<CrmLead> PlsGetLeadPlsValuesInternalAsync(object domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_get_lead_pls_values(self, domain=[]):
            // """
            // This methods builds a dict where, for each lead in self or matching the given domain,
            // we will get a list of field/value couple.
            // Due to onchange and create, we don't always have the id of the lead to recompute.
            // When we update few records (one, typically) with onchanges, we build the lead_values (= couple field/value)
            // using the ORM.
            // To speed up the computation and avoid making too much DB read inside loops,
            // we can give a domain to make sql queries to bypass the ORM.
            // This domain will be used in sql queries to get the values for every lead matching the domain.
            // :param domain: If set, we get all the leads values via unique sql queries (one for tags, one for other fields),
            //                     using the given domain on leads.
            //                If not set, get lead values lead by lead using the ORM.
            // :return: {lead_id: [(field1: value1), (field2: value2), ...], ...}
            // """
            // leads_values_dict = OrderedDict()
            // pls_fields = ["stage_id", "team_id"] + self._pls_get_safe_fields()
            // 
            // # Check if tag_ids is in the pls_fields and removed it from the list. The tags will be managed separately.
            // use_tags = 'tag_ids' in pls_fields
            // if use_tags:
            //     pls_fields.remove('tag_ids')
            // 
            // if domain:
            //     # Get leads values
            //     self.flush_model()
            //     # active_test = False as domain should take active into 'active' field it self
            //     query = self.env['crm.lead'].with_context(active_test=False)._where_calc(domain)
            //     table = query.table
            //     query.order = SQL("%(table)s.team_id asc, %(table)s.id desc", table=SQL.identifier(table))
            //     sql_fields = [SQL.identifier(field) for field in pls_fields]
            //     self._cr.execute(query.select(
            //         SQL("id"),
            //         SQL("probability"),
            //         *sql_fields,
            //     ))
            //     lead_results = self._cr.dictfetchall()
            // 
            //     if use_tags:
            //         # Get tags values
            //         tag_rel_alias = query.left_join(table, 'id', 'crm_tag_rel', 'lead_id', 'crm_tag_rel')
            //         tag_alias = query.left_join(tag_rel_alias, 'tag_id', 'crm_tag', 'id', 'crm_tag')
            //         self._cr.execute(query.select(
            //             SQL("%s AS lead_id", SQL.identifier(table, "id")),
            //             SQL("%s AS tag_id", SQL.identifier(tag_alias, "id")),
            //         ))
            //         tag_results = self._cr.dictfetchall()
            //     else:
            //         tag_results = []
            // 
            //     # get all (variable, value) couple for all in self
            //     for lead in lead_results:
            //         lead_values = []
            //         for field in pls_fields + ['probability']:  # add probability as used in _pls_prepare_frequencies (needed in rebuild mode)
            //             value = lead[field]
            //             if field == 'team_id':  # ignore team_id as stored separately in leads_values_dict[lead_id][team_id]
            //                 continue
            //             if value or field == 'probability':  # 0 is a correct value for probability
            //                 lead_values.append((field, value))
            //             elif field in ('email_state', 'phone_state'):  # As ORM reads 'None' as 'False', do the same here
            //                 lead_values.append((field, False))
            //             leads_values_dict[lead['id']] = {'values': lead_values, 'team_id': lead['team_id'] or 0}
            // 
            //     for tag in tag_results:
            //         if tag['tag_id']:
            //             leads_values_dict[tag['lead_id']]['values'].append(('tag_id', tag['tag_id']))
            //     return leads_values_dict
            // else:
            //     for lead in self:
            //         lead_values = []
            //         for field in pls_fields:
            //             if field == 'team_id':  # ignore team_id as stored separately in leads_values_dict[lead_id][team_id]
            //                 continue
            //             value = lead[field].id if isinstance(lead[field], models.BaseModel) else lead[field]
            //             if value or field in ('email_state', 'phone_state'):
            //                 lead_values.append((field, value))
            //         if use_tags:
            //             for tag in lead.tag_ids:
            //                 lead_values.append(('tag_id', tag.id))
            //         leads_values_dict[lead.id] = {'values': lead_values, 'team_id': lead['team_id'].id}
            //     return leads_values_dict
            */
            return default;
        }

        protected async Task<CrmLead> PlsGetNaiveBayesProbabilitiesInternalAsync(object batch_mode)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_get_naive_bayes_probabilities(self, batch_mode=False):
            // """
            // In machine learning, naive Bayes classifiers (NBC) are a family of simple "probabilistic classifiers" based on
            // applying Bayes theorem with strong (naive) independence assumptions between the variables taken into account.
            // E.g: will TDE eat m&m's depending on his sleep status, the amount of work he has and the fullness of his stomach?
            // As we use experience to compute the statistics, every day, we will register the variables state + the result.
            // As the days pass, we will be able to determine, with more and more precision, if TDE will eat m&m's
            // for a specific combination :
            //     - did sleep very well, a lot of work and stomach full > Will never happen !
            //     - didn't sleep at all, no work at all and empty stomach > for sure !
            // Following Bayes' Theorem: the probability that an event occurs (to win) under certain conditions is proportional
            // to the probability to win under each condition separately and the probability to win. We compute a 'Win score'
            // -> P(Won | A∩B) ∝ P(A∩B | Won)*P(Won) OR S(Won | A∩B) = P(A∩B | Won)*P(Won)
            // To compute a percentage of probability to win, we also compute the 'Lost score' that is proportional to the
            // probability to lose under each condition separately and the probability to lose.
            // -> Probability =  S(Won | A∩B) / ( S(Won | A∩B) + S(Lost | A∩B) )
            // See https://www.youtube.com/watch?v=CPqOCI0ahss can help to get a quick and simple example.
            // One issue about NBC is when a event occurence is never observed.
            // E.g: if when TDE has an empty stomach, he always eat m&m's, than the "not eating m&m's when empty stomach' event
            // will never be observed.
            // This is called 'zero frequency' and that leads to division (or at least multiplication) by zero.
            // To avoid this, we add 0.1 in each frequency. With few data, the computation is than not really realistic.
            // The more we have records to analyse, the more the estimation will be precise.
            // :return: probability in percent (and integer rounded) that the lead will be won at the current stage.
            // """
            // lead_probabilities = {}
            // if not self:
            //     return lead_probabilities
            // 
            // # Get all leads values, no matter the team_id
            // domain = []
            // if batch_mode:
            //     domain = [
            //         '&',
            //             ('active', '=', True), ('id', 'in', self.ids),
            //             '|',
            //                 ('probability', '=', None),
            //                 '&',
            //                     ('probability', '<', 100), ('probability', '>', 0)
            //     ]
            // leads_values_dict = self._pls_get_lead_pls_values(domain=domain)
            // 
            // if not leads_values_dict:
            //     return lead_probabilities
            // 
            // # Get unique couples to search in frequency table and won leads.
            // leads_fields = set()  # keep unique fields, as a lead can have multiple tag_ids
            // won_leads = set()
            // won_stage_ids = self.env['crm.stage'].search([('is_won', '=', True)]).ids
            // for lead_id, values in leads_values_dict.items():
            //     for field, value in values['values']:
            //         if field == 'stage_id' and value in won_stage_ids:
            //             won_leads.add(lead_id)
            //         leads_fields.add(field)
            // leads_fields = sorted(leads_fields)
            // # get all variable related records from frequency table, no matter the team_id
            // frequencies = self.env['crm.lead.scoring.frequency'].search([('variable', 'in', list(leads_fields))], order="team_id asc, id")
            // 
            // # get all team_ids from frequencies
            // frequency_teams = frequencies.mapped('team_id')
            // frequency_team_ids = [team.id for team in frequency_teams]
            // 
            // # 1. Compute each variable value count individually
            // # regroup each variable to be able to compute their own probabilities
            // # As all the variable does not enter into account (as we reject unset values in the process)
            // # each value probability must be computed only with their own variable related total count
            // # special case: for lead for which team_id is not in frequency table or lead with no team_id,
            // # we consider all the records, independently from team_id (this is why we add a result[-1])
            // result = dict((team_id, dict((field, dict(won_total=0, lost_total=0)) for field in leads_fields)) for team_id in frequency_team_ids)
            // result[-1] = dict((field, dict(won_total=0, lost_total=0)) for field in leads_fields)
            // for frequency in frequencies:
            //     field = frequency['variable']
            //     value = frequency['value']
            // 
            //     # To avoid that a tag take too much importance if its subset is too small,
            //     # we ignore the tag frequencies if we have less than 50 won or lost for this tag.
            //     if field == 'tag_id' and (frequency['won_count'] + frequency['lost_count']) < 50:
            //         continue
            // 
            //     if frequency.team_id:
            //         team_result = result[frequency.team_id.id]
            //         team_result[field][value] = {'won': frequency['won_count'], 'lost': frequency['lost_count']}
            //         team_result[field]['won_total'] += frequency['won_count']
            //         team_result[field]['lost_total'] += frequency['lost_count']
            // 
            //     if value not in result[-1][field]:
            //         result[-1][field][value] = {'won': 0, 'lost': 0}
            //     result[-1][field][value]['won'] += frequency['won_count']
            //     result[-1][field][value]['lost'] += frequency['lost_count']
            //     result[-1][field]['won_total'] += frequency['won_count']
            //     result[-1][field]['lost_total'] += frequency['lost_count']
            // 
            // # Get all won, lost and total count for all records in frequencies per team_id
            // for team_id in result:
            //     result[team_id]['team_won'], \
            //     result[team_id]['team_lost'], \
            //     result[team_id]['team_total'] = self._pls_get_won_lost_total_count(result[team_id])
            // 
            // save_team_id = None
            // p_won, p_lost = 1, 1
            // for lead_id, lead_values in leads_values_dict.items():
            //     # if stage_id is null, return 0 and bypass computation
            //     lead_fields = [value[0] for value in lead_values.get('values', [])]
            //     if not 'stage_id' in lead_fields:
            //         lead_probabilities[lead_id] = 0
            //         continue
            //     # if lead stage is won, return 100
            //     elif lead_id in won_leads:
            //         lead_probabilities[lead_id] = 100
            //         continue
            // 
            //     # team_id not in frequency Table -> convert to -1
            //     lead_team_id = lead_values['team_id'] if lead_values['team_id'] in result else -1
            //     if lead_team_id != save_team_id:
            //         save_team_id = lead_team_id
            //         team_won = result[save_team_id]['team_won']
            //         team_lost = result[save_team_id]['team_lost']
            //         team_total = result[save_team_id]['team_total']
            //         # if one count = 0, we cannot compute lead probability
            //         if not team_won or not team_lost:
            //             continue
            //         p_won = team_won / team_total
            //         p_lost = team_lost / team_total
            // 
            //     # 2. Compute won and lost score using each variable's individual probability
            //     s_lead_won, s_lead_lost = p_won, p_lost
            //     for field, value in lead_values['values']:
            //         field_result = result.get(save_team_id, {}).get(field)
            //         value = value.origin if hasattr(value, 'origin') else value
            //         value_result = field_result.get(str(value)) if field_result else False
            //         if value_result:
            //             total_won = team_won if field == 'stage_id' else field_result['won_total']
            //             total_lost = team_lost if field == 'stage_id' else field_result['lost_total']
            // 
            //             # if one count = 0, we cannot compute lead probability
            //             if not total_won or not total_lost:
            //                 continue
            //             s_lead_won *= value_result['won'] / total_won
            //             s_lead_lost *= value_result['lost'] / total_lost
            // 
            //     # 3. Compute Probability to win
            //     probability = s_lead_won / (s_lead_won + s_lead_lost)
            //     lead_probabilities[lead_id] = min(max(round(100 * probability, 2), 0.01), 99.99)
            // return lead_probabilities
            */
            return default;
        }

        protected async Task<CrmLead> PlsGetSafeFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_get_safe_fields(self):
            // """ As config_parameters does not accept M2M field,
            //     we the fields from the formated string stored into the Char config field.
            //     To avoid sql injections when using that list, we return only the fields
            //     that are defined on the model. """
            // pls_fields_config = self.env['ir.config_parameter'].sudo().get_param('crm.pls_fields')
            // pls_fields = pls_fields_config.split(',') if pls_fields_config else []
            // pls_safe_fields = [field for field in pls_fields if field in self._fields.keys()]
            // return pls_safe_fields
            */
            return default;
        }

        protected async Task<CrmLead> PlsGetSafeStartDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_get_safe_start_date(self):
            // """ As config_parameters does not accept Date field,
            //     we get directly the date formated string stored into the Char config field,
            //     as we directly use this string in the sql queries.
            //     To avoid sql injections when using this config param,
            //     we ensure the date string can be effectively a date."""
            // str_date = self.env['ir.config_parameter'].sudo().get_param('crm.pls_start_date')
            // if not fields.Date.to_date(str_date):
            //     return False
            // return str_date
            */
            return default;
        }

        protected async Task<CrmLead> PlsGetWonLostTotalCountInternalAsync(object team_results)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_get_won_lost_total_count(self, team_results):
            // """ Get all won and all lost + total :
            //        first stage can be used to know how many lost and won there is
            //        as won count are equals for all stage
            //        and first stage is always incremented in lost_count
            // :param frequencies: lead_scoring_frequencies
            // :return: won count, lost count and total count for all records in frequencies
            // """
            // # TODO : check if we need to handle specific team_id stages [for lost count] (if first stage in sequence is team_specific)
            // first_stage_id = self.env['crm.stage'].search([('team_id', '=', False)], order='sequence, id', limit=1)
            // if str(first_stage_id.id) not in team_results.get('stage_id', []):
            //     return 0, 0, 0
            // stage_result = team_results['stage_id'][str(first_stage_id.id)]
            // return stage_result['won'], stage_result['lost'], stage_result['won'] + stage_result['lost']
            */
            return default;
        }

        protected async Task<CrmLead> PlsIncrementFrequenciesInternalAsync(object from_state, object to_state)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_increment_frequencies(self, from_state=None, to_state=None):
            // """
            // When losing or winning a lead, this method is called to increment each PLS parameter related to the lead
            // in won_count (if won) or in lost_count (if lost).
            // 
            // This method is also used when reactivating a mistakenly lost lead (using the decrement argument).
            // In this case, the lost count should be de-increment by 1 for each PLS parameter linked to the lead.
            // 
            // Live increment must be done before writing the new values because we need to know the state change (from and to).
            // This would not be an issue for the reach won or reach lost as we just need to increment the frequencies with the
            // final state of the lead.
            // This issue is when the lead leaves a closed state because once the new values have been writen, we do not know
            // what was the previous state that we need to decrement.
            // This is why 'is_won' and 'decrement' parameters are used to describe the from / to change of its state.
            // """
            // new_frequencies_by_team, existing_frequencies_by_team = self._pls_prepare_update_frequency_table(target_state=from_state or to_state)
            // 
            // # update frequency table
            // self._pls_update_frequency_table(new_frequencies_by_team, 1 if to_state else -1,
            //                                  existing_frequencies_by_team=existing_frequencies_by_team)
            */
            return default;
        }

        protected async Task<CrmLead> PlsIncrementFrequencyDictInternalAsync(object frequencies, object field, object @value, object won, object lost)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_increment_frequency_dict(self, frequencies, field, value, won, lost):
            // value = str(value)  # Ensure we will always compare strings.
            // if value not in frequencies[field]:
            //     frequencies[field][value] = {'won': won, 'lost': lost}
            // else:
            //     frequencies[field][value]['won'] += won
            //     frequencies[field][value]['lost'] += lost
            // return frequencies
            */
            return default;
        }

        protected async Task<CrmLead> PlsPrepareFrequenciesInternalAsync(object lead_values, object leads_pls_fields, object target_state)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_prepare_frequencies(self, lead_values, leads_pls_fields, target_state=None):
            // """new state is used when getting frequencies for leads that are changing to lost or won.
            // Stays none if we are checking frequencies for leads already won or lost."""
            // pls_fields = leads_pls_fields.copy()
            // frequencies = dict((field, {}) for field in pls_fields)
            // 
            // stage_ids = self.env['crm.stage'].search_read([], ['sequence', 'name', 'id'], order='sequence, id')
            // stage_sequences = {stage['id']: stage['sequence'] for stage in stage_ids}
            // 
            // # Increment won / lost frequencies by criteria (field / value couple)
            // for values in lead_values:
            //     if target_state:  # ignore probability values if target state (as probability is the old value)
            //         won_count = values['count'] if target_state == 'won' else 0
            //         lost_count = values['count'] if target_state == 'lost' else 0
            //     else:
            //         won_count = values['count'] if values.get('probability', 0) == 100 else 0
            //         lost_count = values['count'] if values.get('probability', 1) == 0  else 0
            // 
            //     if 'tag_id' in values:
            //         frequencies = self._pls_increment_frequency_dict(frequencies, 'tag_id', values['tag_id'], won_count, lost_count)
            //         continue
            // 
            //     # Else, treat other fields
            //     if 'tag_id' in pls_fields:  # tag_id already treated here above.
            //         pls_fields.remove('tag_id')
            //     for field in pls_fields:
            //         if field not in values:
            //             continue
            //         value = values[field]
            //         if value or field in ('email_state', 'phone_state'):
            //             if field == 'stage_id':
            //                 if won_count:  # increment all stages if won
            //                     stages_to_increment = [stage['id'] for stage in stage_ids]
            //                 else:  # increment only current + previous stages if lost
            //                     current_stage_sequence = stage_sequences[value]
            //                     stages_to_increment = [stage['id'] for stage in stage_ids if stage['sequence'] <= current_stage_sequence]
            //                 for stage_id in stages_to_increment:
            //                     frequencies = self._pls_increment_frequency_dict(frequencies, field, stage_id, won_count, lost_count)
            //             else:
            //                 frequencies = self._pls_increment_frequency_dict(frequencies, field, value, won_count, lost_count)
            // 
            // return frequencies
            */
            return default;
        }

        protected async Task<CrmLead> PlsPrepareUpdateFrequencyTableInternalAsync(object rebuild, object target_state)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_prepare_update_frequency_table(self, rebuild=False, target_state=False):
            // """
            // This method is common to Live Increment or Full Rebuild mode, as it shares the main steps.
            // This method will prepare the frequency dict needed to update the frequency table:
            //     - New frequencies: frequencies that we need to add in the frequency table.
            //     - Existing frequencies: frequencies that are already in the frequency table.
            // In rebuild mode, only the new frequencies are needed as existing frequencies are truncated.
            // For each team, each dict contains the frequency in won and lost for each field/value couple
            // of the target leads.
            // Target leads are :
            //     - in Live increment mode : given ongoing leads (self)
            //     - in Full rebuild mode : all the closed (won and lost) leads in the DB.
            // During the frequencies update, with both new and existing frequencies, we can split frequencies to update
            // and frequencies to add. If a field/value couple already exists in the frequency table, we just update it.
            // Otherwise, we need to insert a new one.
            // """
            // # Keep eligible leads
            // pls_start_date = self._pls_get_safe_start_date()
            // if not pls_start_date:
            //     return {}, {}
            // 
            // if rebuild:  # rebuild will treat every closed lead in DB, increment will treat current ongoing leads
            //     pls_leads = self
            // else:
            //     # Only treat leads created after the PLS start Date
            //     pls_leads = self.filtered(
            //         lambda lead: fields.Date.to_date(pls_start_date) <= fields.Date.to_date(lead.create_date))
            //     if not pls_leads:
            //         return {}, {}
            // 
            // # Extract target leads values
            // if rebuild:  # rebuild is ok
            //     domain = [
            //         '&',
            //             ('create_date', '>=', pls_start_date),
            //             '|',
            //                 ('probability', '=', 100),
            //                 '&',
            //                     ('probability', '=', 0), ('active', '=', False)
            //       ]
            //     team_ids = self.env['crm.team'].with_context(active_test=False).search([]).ids + [0]  # If team_id is unset, consider it as team 0
            // else:  # increment
            //     domain = [('id', 'in', pls_leads.ids)]
            //     team_ids = pls_leads.mapped('team_id').ids + [0]
            // 
            // leads_values_dict = pls_leads._pls_get_lead_pls_values(domain=domain)
            // 
            // # split leads values by team_id
            // # get current frequencies related to the target leads
            // leads_frequency_values_by_team = dict((team_id, []) for team_id in team_ids)
            // leads_pls_fields = set()  # ensure to keep each field unique (can have multiple tag_id leads_values_dict)
            // for lead_id, values in leads_values_dict.items():
            //     team_id = values.get('team_id', 0)  # If team_id is unset, consider it as team 0
            //     lead_frequency_values = {'count': 1}
            //     for field, value in values['values']:
            //         if field != "probability":  # was added to lead values in batch mode to know won/lost state, but is not a pls fields.
            //             leads_pls_fields.add(field)
            //         else:  # extract lead probability - needed to increment tag_id frequency. (proba always before tag_id)
            //             lead_probability = value
            //         if field == 'tag_id':  # handle tag_id separatelly (as in One Shot rebuild mode)
            //             leads_frequency_values_by_team[team_id].append({field: value, 'count': 1, 'probability': lead_probability})
            //         else:
            //             lead_frequency_values[field] = value
            //     leads_frequency_values_by_team[team_id].append(lead_frequency_values)
            // leads_pls_fields = sorted(leads_pls_fields)
            // 
            // # get new frequencies
            // new_frequencies_by_team = {}
            // for team_id in team_ids:
            //     # prepare fields and tag values for leads by team
            //     new_frequencies_by_team[team_id] = self._pls_prepare_frequencies(
            //         leads_frequency_values_by_team[team_id], leads_pls_fields, target_state=target_state)
            // 
            // # get existing frequencies
            // existing_frequencies_by_team = {}
            // if not rebuild:  # there is no existing frequency in rebuild mode as they were all deleted.
            //     # read all fields to get everything in memory in one query (instead of having query + prefetch)
            //     existing_frequencies = self.env['crm.lead.scoring.frequency'].search_read(
            //         ['&', ('variable', 'in', leads_pls_fields),
            //               '|', ('team_id', 'in', pls_leads.mapped('team_id').ids), ('team_id', '=', False)])
            //     for frequency in existing_frequencies:
            //         team_id = frequency['team_id'][0] if frequency.get('team_id') else 0
            //         if team_id not in existing_frequencies_by_team:
            //             existing_frequencies_by_team[team_id] = dict((field, {}) for field in leads_pls_fields)
            // 
            //         existing_frequencies_by_team[team_id][frequency['variable']][frequency['value']] = {
            //             'frequency_id': frequency['id'],
            //             'won': frequency['won_count'],
            //             'lost': frequency['lost_count']
            //         }
            // 
            // return new_frequencies_by_team, existing_frequencies_by_team
            */
            return default;
        }

        protected async Task<CrmLead> PlsUpdateFrequencyTableInternalAsync(object new_frequencies_by_team, object step, object existing_frequencies_by_team)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _pls_update_frequency_table(self, new_frequencies_by_team, step, existing_frequencies_by_team=None):
            // """ Create / update the frequency table in a cross company way, per team_id"""
            // values_to_update = {}
            // values_to_create = []
            // if not existing_frequencies_by_team:
            //     existing_frequencies_by_team = {}
            // # build the create multi + frequencies to update
            // for team_id, new_frequencies in new_frequencies_by_team.items():
            //     for field, value in new_frequencies.items():
            //         # frequency already present ?
            //         current_frequencies = existing_frequencies_by_team.get(team_id, {})
            //         for param, result in value.items():
            //             current_frequency_for_couple = current_frequencies.get(field, {}).get(param, {})
            //             # If frequency already present : UPDATE IT
            //             if current_frequency_for_couple:
            //                 new_won = current_frequency_for_couple['won'] + (result['won'] * step)
            //                 new_lost = current_frequency_for_couple['lost'] + (result['lost'] * step)
            //                 # ensure to have always positive frequencies
            //                 values_to_update[current_frequency_for_couple['frequency_id']] = {
            //                     'won_count': new_won if new_won > 0 else 0.1,
            //                     'lost_count': new_lost if new_lost > 0 else 0.1
            //                 }
            //                 continue
            // 
            //             # Else, CREATE a new frequency record.
            //             # We add + 0.1 in won and lost counts to avoid zero frequency issues
            //             # should be +1 but it weights too much on small recordset.
            //             values_to_create.append({
            //                 'variable': field,
            //                 'value': param,
            //                 'won_count': result['won'] + 0.1,
            //                 'lost_count': result['lost'] + 0.1,
            //                 'team_id': team_id if team_id else None  # team_id = 0 means no team_id
            //             })
            // 
            // LeadScoringFrequency = self.env['crm.lead.scoring.frequency'].sudo()
            // for frequency_id, values in values_to_update.items():
            //     LeadScoringFrequency.browse(frequency_id).write(values)
            // 
            // if values_to_create:
            //     LeadScoringFrequency.create(values_to_create)
            */
            return default;
        }

        protected async Task<CrmLead> PrepareAddressValuesFromPartnerInternalAsync(object partner)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _prepare_address_values_from_partner(self, partner):
            // # Sync all address fields from partner, or none, to avoid mixing them.
            // if any(partner[f] for f in PARTNER_ADDRESS_FIELDS_TO_SYNC):
            //     values = {f: partner[f] for f in PARTNER_ADDRESS_FIELDS_TO_SYNC}
            // else:
            //     values = {f: self[f] for f in PARTNER_ADDRESS_FIELDS_TO_SYNC}
            // return values
            */
            return default;
        }

        protected async Task<CrmLead> PrepareContactNameFromPartnerInternalAsync(object partner)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _prepare_contact_name_from_partner(self, partner):
            // contact_name = False if partner.is_company else partner.name
            // return {'contact_name': contact_name or self.contact_name}
            */
            return default;
        }

        protected async Task<CrmLead> PrepareCustomerValuesInternalAsync(object partner_name, object is_company, Guid parent_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _prepare_customer_values(self, partner_name, is_company=False, parent_id=False):
            // """ Extract data from lead to create a partner.
            // 
            // :param name : furtur name of the partner
            // :param is_company : True if the partner is a company
            // :param parent_id : id of the parent partner (False if no parent)
            // 
            // :return: dictionary of values to give at res_partner.create()
            // """
            // email_parts = tools.email_split(self.email_from)
            // res = {
            //     'name': partner_name,
            //     'user_id': self.env.context.get('default_user_id') or self.user_id.id,
            //     'comment': self.description,
            //     'parent_id': parent_id,
            //     'phone': self.phone,
            //     'mobile': self.mobile,
            //     'email': email_parts[0] if email_parts else False,
            //     'title': self.title.id,
            //     'function': self.function,
            //     'street': self.street,
            //     'street2': self.street2,
            //     'zip': self.zip,
            //     'city': self.city,
            //     'country_id': self.country_id.id,
            //     'state_id': self.state_id.id,
            //     'website': self.website,
            //     'is_company': is_company,
            //     'type': 'contact'
            // }
            // if self.lang_id.active:
            //     res['lang'] = self.lang_id.code
            // return res
            --- ODOO METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: crm_lead.py) ---
            // def _prepare_customer_values(self, partner_name, is_company=False, parent_id=False):
            // res = super()._prepare_customer_values(partner_name, is_company=is_company, parent_id=parent_id)
            // res.update({
            //     'partner_latitude': self.partner_latitude,
            //     'partner_longitude': self.partner_longitude,
            // })
            // return res
            */
            return default;
        }

        protected async Task<CrmLead> PrepareOpportunityQuotationContextInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_crm, FILE: crm_lead.py) ---
            // def _prepare_opportunity_quotation_context(self):
            // """ Prepares the context for a new quotation (sale.order) by sharing the values of common fields """
            // self.ensure_one()
            // quotation_context = {
            //     'default_opportunity_id': self.id,
            //     'default_partner_id': self.partner_id.id,
            //     'default_campaign_id': self.campaign_id.id,
            //     'default_medium_id': self.medium_id.id,
            //     'default_origin': self.name,
            //     'default_source_id': self.source_id.id,
            //     'default_company_id': self.company_id.id or self.env.company.id,
            //     'default_tag_ids': [(6, 0, self.tag_ids.ids)]
            // }
            // if self.team_id:
            //     quotation_context['default_team_id'] = self.team_id.id
            // if self.user_id:
            //     quotation_context['default_user_id'] = self.user_id.id
            // return quotation_context
            */
            return default;
        }

        protected async Task<CrmLead> PreparePartnerNameFromPartnerInternalAsync(object partner)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _prepare_partner_name_from_partner(self, partner):
            // """ Company name: name of partner parent (if set) or name of partner
            // (if company) or company_name of partner (if not a company). """
            // partner_name = partner.parent_id.name
            // if not partner_name and partner.is_company:
            //     partner_name = partner.name
            // elif not partner_name and partner.company_name:
            //     partner_name = partner.company_name
            // return {'partner_name': partner_name or self.partner_name}
            */
            return default;
        }

        protected async Task<CrmLead> PrepareValuesFromPartnerInternalAsync(object partner)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _prepare_values_from_partner(self, partner):
            // """ Get a dictionary with values coming from partner information to
            // copy on a lead. Non-address fields get the current lead
            // values to avoid being reset if partner has no value for them. """
            // 
            // # Sync all address fields from partner, or none, to avoid mixing them.
            // values = self._prepare_address_values_from_partner(partner)
            // 
            // # For other fields, get the info from the partner, but only if set
            // values.update({f: partner[f] or self[f] for f in PARTNER_FIELDS_TO_SYNC if f != 'lang'})
            // if partner.lang:
            //     values['lang_id'] = self.env['res.lang']._get_data(code=partner.lang).id
            // 
            // # Fields with specific logic
            // values.update(self._prepare_contact_name_from_partner(partner))
            // values.update(self._prepare_partner_name_from_partner(partner))
            // 
            // return self._convert_to_write(values)
            */
            return default;
        }

        protected async Task<CrmLead> ReadGroupStageIdsInternalAsync(object stages, object domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _read_group_stage_ids(self, stages, domain):
            // # retrieve team_id from the context and write the domain
            // # - ('id', 'in', stages.ids): add columns that should be present
            // # - OR ('fold', '=', False): add default columns that are not folded
            // # - OR ('team_ids', '=', team_id), ('fold', '=', False) if team_id: add team columns that are not folded
            // team_id = self._context.get('default_team_id')
            // if team_id:
            //     search_domain = ['|', ('id', 'in', stages.ids), '|', ('team_id', '=', False), ('team_id', '=', team_id)]
            // else:
            //     search_domain = ['|', ('id', 'in', stages.ids), ('team_id', '=', False)]
            // 
            // # perform search
            // stage_ids = stages.sudo()._search(search_domain, order=stages._order)
            // return stages.browse(stage_ids)
            */
            return default;
        }

        protected async Task<CrmLead> RebuildPlsFrequencyTableInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _rebuild_pls_frequency_table(self):
            // # Clear the frequencies table (in sql to speed up the cron)
            // try:
            //     self.browse().check_access('unlink')
            // except AccessError:
            //     raise UserError(_("You don't have the access needed to run this cron."))
            // else:
            //     self._cr.execute('TRUNCATE TABLE crm_lead_scoring_frequency')
            // 
            // new_frequencies_by_team, unused = self._pls_prepare_update_frequency_table(rebuild=True)
            // # update frequency table
            // self._pls_update_frequency_table(new_frequencies_by_team, 1)
            // 
            // _logger.info("Predictive Lead Scoring : crm.lead.scoring.frequency table rebuilt")
            */
            return default;
        }

        public async Task<CrmLead> RedirectLeadOpportunityViewAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def redirect_lead_opportunity_view(self):
            // self.ensure_one()
            // return {
            //     'name': _('Lead or Opportunity'),
            //     'view_mode': 'form',
            //     'res_model': 'crm.lead',
            //     'domain': [('type', '=', self.type)],
            //     'res_id': self.id,
            //     'view_id': False,
            //     'type': 'ir.actions.act_window',
            //     'context': {'default_type': self.type}
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<CrmLead> RedirectToLivechatSessionsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_crm_livechat, FILE: crm_lead.py) ---
            // def action_redirect_to_livechat_sessions(self):
            // visitors = self.visitor_ids
            // action = self.env["ir.actions.actions"]._for_xml_id("website_livechat.website_visitor_livechat_session_action")
            // action['domain'] = [('livechat_visitor_id', 'in', visitors.ids), ('has_message', '=', True)]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<CrmLead> RedirectToPageViewsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_crm, FILE: crm_lead.py) ---
            // def action_redirect_to_page_views(self):
            // visitors = self.visitor_ids
            // action = self.env["ir.actions.actions"]._for_xml_id("website.website_visitor_page_action")
            // action['domain'] = [('visitor_id', 'in', visitors.ids)]
            // # avoid grouping if only few records
            // if len(visitors.website_track_ids) > 15 and len(visitors.website_track_ids.page_id) > 1:
            //     action['context'] = {'search_default_group_by_page': '1'}
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<CrmLead> RescheduleMeetingAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_reschedule_meeting(self):
            // self.ensure_one()
            // action = self.action_schedule_meeting(smart_calendar=False)
            // next_activity = self.activity_ids.filtered(lambda activity: activity.user_id == self.env.user)[:1]
            // if next_activity.calendar_event_id:
            //     action['context']['initial_date'] = next_activity.calendar_event_id.start
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<CrmLead> SaleQuotationsNewAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_crm, FILE: crm_lead.py) ---
            // def action_sale_quotations_new(self):
            // if not self.partner_id:
            //     return self.env["ir.actions.actions"]._for_xml_id("sale_crm.crm_quotation_partner_action")
            // else:
            //     return self.action_new_quotation()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<CrmLead> ScheduleMeetingAsync(Guid id, CrmLeadScheduleMeetingRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_schedule_meeting(self, smart_calendar=True):
            // """ Open meeting's calendar view to schedule meeting on current opportunity.
            // 
            //     :param smart_calendar: boolean, to set to False if the view should not try to choose relevant
            //       mode and initial date for calendar view, see ``_get_opportunity_meeting_view_parameters``
            //     :return dict: dictionary value for created Meeting view
            // """
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("calendar.action_calendar_event")
            // partner_ids = self.env.user.partner_id.ids
            // if self.partner_id:
            //     partner_ids.append(self.partner_id.id)
            // current_opportunity_id = self.id if self.type == 'opportunity' else False
            // action['context'] = {
            //     'search_default_opportunity_id': current_opportunity_id,
            //     'default_opportunity_id': current_opportunity_id,
            //     'default_partner_id': self.partner_id.id,
            //     'default_partner_ids': partner_ids,
            //     'default_team_id': self.team_id.id,
            //     'default_name': self.name,
            // }
            // 
            // # 'Smart' calendar view : get the most relevant time period to display to the user.
            // if current_opportunity_id and smart_calendar:
            //     mode, initial_date = self._get_opportunity_meeting_view_parameters()
            //     action['context'].update({'default_mode': mode, 'initial_date': initial_date})
            // 
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<CrmLead> SearchFetchAsync(Guid id, CrmLeadSearchFetchRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def search_fetch(self, domain, field_names, offset=0, limit=None, order=None):
            // """ Override to support ordering on my_activity_date_deadline.
            // 
            // Ordering through web client calls search_read() with an order parameter
            // set. Method search_read() then calls search_fetch(). Here we override
            // search_fetch() to intercept a search with an order on field
            // my_activity_date_deadline. In that case we do the search in two steps.
            // 
            // First step: fill with deadline-based results
            // 
            //   * Perform a read_group on my activities to get a mapping lead_id / deadline
            //     Remember date_deadline is required, we always have a value for it. Only
            //     the earliest deadline per lead is kept.
            //   * Search leads linked to those activities that also match the asked domain
            //     and order from the original search request.
            //   * Results of that search will be at the top of returned results. Use limit
            //     None because we have to search all leads linked to activities as ordering
            //     on deadline is done in post processing.
            //   * Reorder them according to deadline asc or desc depending on original
            //     search ordering. Finally take only a subset of those leads to fill with
            //     results matching asked offset / limit.
            // 
            // Second step: fill with other results. If first step does not gives results
            // enough to match offset and limit parameters we fill with a search on other
            // leads. We keep the asked domain and ordering while filtering out already
            // scanned leads to keep a coherent results.
            // 
            // All other search and search_read are left untouched by this override to avoid
            // side effects. Search_count is not affected by this override.
            // """
            // if not order or 'my_activity_date_deadline' not in order:
            //     return super().search_fetch(domain, field_names, offset, limit, order)
            // order_items = [order_item.strip().lower() for order_item in (order or self._order).split(',')]
            // 
            // # Perform a read_group on my activities to get a mapping lead_id / deadline
            // # Remember date_deadline is required, we always have a value for it. Only
            // # the earliest deadline per lead is kept.
            // activity_asc = any('my_activity_date_deadline asc' in item for item in order_items)
            // my_lead_activities = self.env['mail.activity']._read_group(
            //     [('res_model', '=', self._name), ('user_id', '=', self.env.uid)],
            //     ['res_id'],
            //     ['date_deadline:min'],
            //     order='date_deadline:min ASC, res_id',
            // )
            // my_lead_mapping = dict(my_lead_activities)
            // my_lead_ids = list(my_lead_mapping.keys())
            // my_lead_domain = expression.AND([[('id', 'in', my_lead_ids)], domain])
            // my_lead_order = ', '.join(item for item in order_items if 'my_activity_date_deadline' not in item)
            // 
            // # Search leads linked to those activities and order them. See docstring
            // # of this method for more details.
            // search_res = super().search_fetch(my_lead_domain, field_names, order=my_lead_order)
            // my_lead_ids_ordered = sorted(search_res.ids, key=lambda lead_id: my_lead_mapping[lead_id], reverse=not activity_asc)
            // # keep only requested window (offset + limit, or offset+)
            // my_lead_ids_keep = my_lead_ids_ordered[offset:(offset + limit)] if limit else my_lead_ids_ordered[offset:]
            // # keep list of already skipped lead ids to exclude them from future search
            // my_lead_ids_skip = my_lead_ids_ordered[:(offset + limit)] if limit else my_lead_ids_ordered
            // 
            // # do not go further if limit is achieved
            // if limit and len(my_lead_ids_keep) >= limit:
            //     return self.browse(my_lead_ids_keep)
            // 
            // # Fill with remaining leads. If a limit is given, simply remove count of
            // # already fetched. Otherwise keep none. If an offset is set we have to
            // # reduce it by already fetch results hereabove. Order is updated to exclude
            // # my_activity_date_deadline when calling super() .
            // lead_limit = (limit - len(my_lead_ids_keep)) if limit else None
            // if offset:
            //     lead_offset = max((offset - len(search_res), 0))
            // else:
            //     lead_offset = 0
            // lead_order = ', '.join(item for item in order_items if 'my_activity_date_deadline' not in item)
            // 
            // other_lead_res = super().search_fetch(
            //     expression.AND([[('id', 'not in', my_lead_ids_skip)], domain]),
            //     field_names, lead_offset, lead_limit, lead_order,
            // )
            // return self.browse(my_lead_ids_keep) + other_lead_res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<CrmLead> SearchGeoPartnerAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: crm_lead.py) ---
            // def search_geo_partner(self):
            // Partner = self.env['res.partner']
            // res_partner_ids = {}
            // self.assign_geo_localize()
            // for lead in self:
            //     partner_ids = []
            //     if not lead.country_id:
            //         continue
            //     latitude = lead.partner_latitude
            //     longitude = lead.partner_longitude
            //     if latitude and longitude:
            //         # 1. first way: in the same country, small area
            //         partner_ids = Partner.search([
            //             ('partner_weight', '>', 0),
            //             ('partner_latitude', '>', latitude - 2), ('partner_latitude', '<', latitude + 2),
            //             ('partner_longitude', '>', longitude - 1.5), ('partner_longitude', '<', longitude + 1.5),
            //             ('country_id', '=', lead.country_id.id),
            //             ('id', 'not in', lead.partner_declined_ids.mapped('id')),
            //         ])
            // 
            //         # 2. second way: in the same country, big area
            //         if not partner_ids:
            //             partner_ids = Partner.search([
            //                 ('partner_weight', '>', 0),
            //                 ('partner_latitude', '>', latitude - 4), ('partner_latitude', '<', latitude + 4),
            //                 ('partner_longitude', '>', longitude - 3), ('partner_longitude', '<', longitude + 3),
            //                 ('country_id', '=', lead.country_id.id),
            //                 ('id', 'not in', lead.partner_declined_ids.mapped('id')),
            //             ])
            // 
            //         # 3. third way: in the same country, extra large area
            //         if not partner_ids:
            //             partner_ids = Partner.search([
            //                 ('partner_weight', '>', 0),
            //                 ('partner_latitude', '>', latitude - 8), ('partner_latitude', '<', latitude + 8),
            //                 ('partner_longitude', '>', longitude - 8), ('partner_longitude', '<', longitude + 8),
            //                 ('country_id', '=', lead.country_id.id),
            //                 ('id', 'not in', lead.partner_declined_ids.mapped('id')),
            //             ])
            // 
            //         # 5. fifth way: anywhere in same country
            //         if not partner_ids:
            //             # still haven't found any, let's take all partners in the country!
            //             partner_ids = Partner.search([
            //                 ('partner_weight', '>', 0),
            //                 ('country_id', '=', lead.country_id.id),
            //                 ('id', 'not in', lead.partner_declined_ids.mapped('id')),
            //             ])
            // 
            //         # 6. sixth way: closest partner whatsoever, just to have at least one result
            //         if not partner_ids:
            //             # warning: point() type takes (longitude, latitude) as parameters in this order!
            //             self._cr.execute("""SELECT id, distance
            //                           FROM  (select id, (point(partner_longitude, partner_latitude) <-> point(%s,%s)) AS distance FROM res_partner
            //                           WHERE active
            //                                 AND partner_longitude is not null
            //                                 AND partner_latitude is not null
            //                                 AND partner_weight > 0
            //                                 AND id not in (select partner_id from crm_lead_declined_partner where lead_id = %s)
            //                                 ) AS d
            //                           ORDER BY distance LIMIT 1""", (longitude, latitude, lead.id))
            //             res = self._cr.dictfetchone()
            //             if res:
            //                 partner_ids = Partner.browse([res['id']])
            // 
            //         if partner_ids:
            //             res_partner_ids[lead.id] = random.choices(
            //                 partner_ids.ids,
            //                 partner_ids.mapped('partner_weight'),
            //             )[0]
            // 
            // return res_partner_ids
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<CrmLead> SetAutomatedProbabilityAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_set_automated_probability(self):
            // self.write({'probability': self.automated_probability})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<CrmLead> SetLostAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_set_lost(self, **additional_values):
            // """ Lost semantic: probability = 0 or active = False """
            // res = self.action_archive()
            // if additional_values:
            //     self.write(dict(additional_values))
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<CrmLead> SetWonAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_set_won(self):
            // """ Won semantic: probability = 100 (active untouched) """
            // self.action_unarchive()
            // # group the leads by team_id, in order to write once by values couple (each write leads to frequency increment)
            // leads_by_won_stage = {}
            // for lead in self:
            //     won_stages = self._stage_find(domain=[('is_won', '=', True)], limit=None)
            //     # ABD : We could have a mixed pipeline, with "won" stages being separated by "standard"
            //     # stages. In the future, we may want to prevent any "standard" stage to have a higher
            //     # sequence than any "won" stage. But while this is not the case, searching
            //     # for the "won" stage while alterning the sequence order (see below) will correctly
            //     # handle such a case :
            //     #       stage sequence : [x] [x (won)] [y] [y (won)] [z] [z (won)]
            //     #       when in stage [y] and marked as "won", should go to the stage [y (won)],
            //     #       not in [x (won)] nor [z (won)]
            //     stage_id = next((stage for stage in won_stages if stage.sequence > lead.stage_id.sequence), None)
            //     if not stage_id:
            //         stage_id = next((stage for stage in reversed(won_stages) if stage.sequence <= lead.stage_id.sequence), won_stages)
            //     if stage_id in leads_by_won_stage:
            //         leads_by_won_stage[stage_id] += lead
            //     else:
            //         leads_by_won_stage[stage_id] = lead
            // for won_stage_id, leads in leads_by_won_stage.items():
            //     leads.write({'stage_id': won_stage_id.id, 'probability': 100})
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<CrmLead> SetWonRainbowmanAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_set_won_rainbowman(self):
            // self.ensure_one()
            // self.action_set_won()
            // 
            // message = self._get_rainbowman_message()
            // if message:
            //     return {
            //         'effect': {
            //             'fadeout': 'slow',
            //             'message': message,
            //             'img_url': '/web/image/%s/%s/image_1024' % (self.team_id.user_id._name, self.team_id.user_id.id) if self.team_id.user_id.image_1024 else '/web/static/img/smile.svg',
            //             'type': 'rainbow_man',
            //         }
            //     }
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<CrmLead> ShowPotentialDuplicatesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_show_potential_duplicates(self):
            // """ Open kanban view to display duplicate leads or opportunity.
            //     :return dict: dictionary value for created kanban view
            // """
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("crm.crm_lead_opportunities")
            // action['domain'] = [('id', 'in', self.duplicate_lead_ids.ids)]
            // action['context'] = {
            //     'active_test': False,
            //     'create': False
            // }
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<CrmLead> SnoozeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def action_snooze(self):
            // self.ensure_one()
            // my_next_activity = self.activity_ids.filtered(lambda activity: activity.user_id == self.env.user)[:1]
            // my_next_activity.action_snooze()
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<CrmLead> SortByConfidenceLevelInternalAsync(object reverse)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _sort_by_confidence_level(self, reverse=False):
            // """ Sorting the leads/opps according to the confidence level to it
            // being won. It is sorted following this incremental heuristics :
            // 
            //   * "not lost" first (inactive leads are lost); normally all leads
            //     should be active but in case lost one, they are always last.
            //     Inactive opportunities are considered as valid;
            //   * opportunity is more reliable than a lead which is a pre-stage
            //     used mainly for first classification;
            //   * stage sequence: the higher the better as it indicates we are moving
            //     towards won stage;
            //   * probability: the higher the better as it is more likely to be won;
            //   * ID: the higher the better when all other parameters are equal. We
            //     consider newer leads to be more reliable;
            // """
            // def opps_key(opportunity):
            //     return opportunity.type == 'opportunity' or opportunity.active,  \
            //         opportunity.type == 'opportunity', \
            //         opportunity.stage_id.sequence, \
            //         opportunity.probability, \
            //         -opportunity._origin.id
            // 
            // return self.sorted(key=opps_key, reverse=reverse)
            */
            return default;
        }

        protected async Task<CrmLead> StageFindInternalAsync(Guid team_id, object domain, object order, object limit)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _stage_find(self, team_id=False, domain=None, order='sequence, id', limit=1):
            // """ Determine the stage of the current lead with its teams, the given domain and the given team_id
            //     :param team_id
            //     :param domain : base search domain for stage
            //     :param order : base search order for stage
            //     :param limit : base search limit for stage
            //     :returns crm.stage recordset
            // """
            // # collect all team_ids by adding given one, and the ones related to the current leads
            // team_ids = set()
            // if team_id:
            //     team_ids.add(team_id)
            // for lead in self:
            //     if lead.team_id:
            //         team_ids.add(lead.team_id.id)
            // # generate the domain
            // if team_ids:
            //     search_domain = ['|', ('team_id', '=', False), ('team_id', 'in', list(team_ids))]
            // else:
            //     search_domain = [('team_id', '=', False)]
            // # AND with the domain in parameter
            // if domain:
            //     search_domain += list(domain)
            // # perform search, return the first found
            // return self.env['crm.stage'].search(search_domain, order=order, limit=limit)
            */
            return default;
        }

        public async Task<CrmLead> ToggleActiveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def toggle_active(self):
            // """ When archiving: mark probability as 0. When re-activating
            // update probability again, for leads and opportunities. """
            // res = super(Lead, self).toggle_active()
            // activated = self.filtered(lambda lead: lead.active)
            // archived = self.filtered(lambda lead: not lead.active)
            // if activated:
            //     activated.write({'lost_reason_id': False})
            //     activated._compute_probabilities()
            // if archived:
            //     archived.write({'probability': 0, 'automated_probability': 0})
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<CrmLead> TrackSubtypeInternalAsync(object init_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _track_subtype(self, init_values):
            // self.ensure_one()
            // if 'stage_id' in init_values and self.probability == 100 and self.stage_id:
            //     return self.env.ref('crm.mt_lead_won')
            // elif 'lost_reason_id' in init_values and self.lost_reason_id:
            //     return self.env.ref('crm.mt_lead_lost')
            // elif 'stage_id' in init_values:
            //     return self.env.ref('crm.mt_lead_stage')
            // elif 'active' in init_values and self.active:
            //     return self.env.ref('crm.mt_lead_restored')
            // elif 'active' in init_values and not self.active:
            //     return self.env.ref('crm.mt_lead_lost')
            // return super(Lead, self)._track_subtype(init_values)
            */
            return default;
        }

        protected async Task<CrmLead> UpdateAutomatedProbabilitiesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_lead.py) ---
            // def _update_automated_probabilities(self):
            // """ Recompute all the automated_probability (and align probability if both were aligned) for all the leads
            // that are active (not won, nor lost).
            // 
            // For performance matter, as there can be a huge amount of leads to recompute, this cron proceed by batch.
            // Each batch is performed into its own transaction, in order to minimise the lock time on the lead table
            // (and to avoid complete lock if there was only 1 transaction that would last for too long -> several minutes).
            // If a concurrent update occurs, it will simply be put in the queue to get the lock.
            // """
            // pls_start_date = self._pls_get_safe_start_date()
            // if not pls_start_date:
            //     return
            // 
            // # 1. Get all the leads to recompute created after pls_start_date that are nor won nor lost
            // # (Won : probability = 100 | Lost : probability = 0 or inactive. Here, inactive won't be returned anyway)
            // # Get also all the lead without probability --> These are the new leads. Activate auto probability on them.
            // pending_lead_domain = [
            //     '&',
            //         '&',
            //             ('stage_id', '!=', False), ('create_date', '>=', pls_start_date),
            //         '|',
            //             ('probability', '=', False),
            //             '&',
            //                 ('probability', '<', 100), ('probability', '>', 0)
            // ]
            // leads_to_update = self.env['crm.lead'].search(pending_lead_domain)
            // leads_to_update_count = len(leads_to_update)
            // 
            // # 2. Compute by batch to avoid memory error
            // lead_probabilities = {}
            // for i in range(0, leads_to_update_count, PLS_COMPUTE_BATCH_STEP):
            //     leads_to_update_part = leads_to_update[i:i + PLS_COMPUTE_BATCH_STEP]
            //     lead_probabilities.update(leads_to_update_part._pls_get_naive_bayes_probabilities(batch_mode=True))
            // _logger.info("Predictive Lead Scoring : New automated probabilities computed")
            // 
            // # 3. Group by new probability to reduce server roundtrips when executing the update
            // probability_leads = defaultdict(list)
            // for lead_id, probability in sorted(lead_probabilities.items()):
            //     probability_leads[probability].append(lead_id)
            // 
            // # 4. Update automated_probability (+ probability if both were equal)
            // update_sql = """UPDATE crm_lead
            //                 SET automated_probability = %s,
            //                     probability = CASE WHEN (probability = automated_probability OR probability is null)
            //                                        THEN (%s)
            //                                        ELSE (probability)
            //                                   END
            //                 WHERE id in %s"""
            // 
            // # Update by a maximum number of leads at the same time, one batch by transaction :
            // # - avoid memory errors
            // # - avoid blocking the table for too long with a too big transaction
            // transactions_count, transactions_failed_count = 0, 0
            // cron_update_lead_start_date = datetime.now()
            // auto_commit = not getattr(threading.current_thread(), 'testing', False)
            // self.flush_model()
            // for probability, probability_lead_ids in probability_leads.items():
            //     for lead_ids_current in tools.split_every(PLS_UPDATE_BATCH_STEP, probability_lead_ids):
            //         transactions_count += 1
            //         try:
            //             self.env.cr.execute(update_sql, (probability, probability, tuple(lead_ids_current)))
            //             # auto-commit except in testing mode
            //             if auto_commit:
            //                 self.env.cr.commit()
            //         except Exception as e:
            //             _logger.warning("Predictive Lead Scoring : update transaction failed. Error: %s" % e)
            //             transactions_failed_count += 1
            // self.invalidate_model()
            // 
            // _logger.info(
            //     "Predictive Lead Scoring : All automated probabilities updated (%d leads / %d transactions (%d failed) / %d seconds)" % (
            //         leads_to_update_count,
            //         transactions_count,
            //         transactions_failed_count,
            //         (datetime.now() - cron_update_lead_start_date).total_seconds(),
            //     )
            // )
            */
            return default;
        }

        public async Task<CrmLead> UpdateContactDetailsFromPortalAsync(Guid id, CrmLeadUpdateContactDetailsFromPortalRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: crm_lead.py) ---
            // def update_contact_details_from_portal(self, values):
            // self.browse().check_access('write')
            // fields = ['partner_name', 'phone', 'mobile', 'email_from', 'street', 'street2',
            //     'city', 'zip', 'state_id', 'country_id']
            // if any([key not in fields for key in values]):
            //     raise UserError(_("Not allowed to update the following field(s): %s.", ", ".join([key for key in values if not key in fields])))
            // return self.sudo().write(values)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<CrmLead> UpdateLeadPortalAsync(Guid id, CrmLeadUpdateLeadPortalRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_crm_partner_assign, FILE: crm_lead.py) ---
            // def update_lead_portal(self, values):
            // self.browse().check_access('write')
            // for lead in self:
            //     lead_values = {
            //         'expected_revenue': values['expected_revenue'],
            //         'probability': values['probability'] or False,
            //         'priority': values['priority'],
            //         'date_deadline': values['date_deadline'] or False,
            //     }
            //     # As activities may belong to several users, only the current portal user activity
            //     # will be modified by the portal form. If no activity exist we create a new one instead
            //     # that we assign to the portal user.
            // 
            //     user_activity = lead.sudo().activity_ids.filtered(lambda activity: activity.user_id == self.env.user)[:1]
            //     if values['activity_date_deadline']:
            //         if user_activity:
            //             user_activity.sudo().write({
            //                 'activity_type_id': values['activity_type_id'],
            //                 'summary': values['activity_summary'],
            //                 'date_deadline': values['activity_date_deadline'],
            //             })
            //         else:
            //             self.env['mail.activity'].sudo().create({
            //                 'res_model_id': self.env.ref('crm.model_crm_lead').id,
            //                 'res_id': lead.id,
            //                 'user_id': self.env.user.id,
            //                 'activity_type_id': values['activity_type_id'],
            //                 'summary': values['activity_summary'],
            //                 'date_deadline': values['activity_date_deadline'],
            //             })
            //     lead.write(lead_values)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<CrmLead> UpdateRevenuesFromSoInternalAsync(object order)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_crm, FILE: crm_lead.py) ---
            // def _update_revenues_from_so(self, order):
            // for opportunity in self:
            //     if (
            //         (opportunity.expected_revenue or 0) < order.amount_untaxed
            //         and order.currency_id == opportunity.company_id.currency_id
            //     ):
            //         opportunity.expected_revenue = order.amount_untaxed
            //         opportunity._track_set_log_message(_('Expected revenue has been updated based on the linked Sales Orders.'))
            */
            return default;
        }

        public async Task<CrmLead> ViewSaleOrderAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_crm, FILE: crm_lead.py) ---
            // def action_view_sale_order(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("sale.action_orders")
            // action['context'] = {
            //     'search_default_partner_id': self.partner_id.id,
            //     'default_partner_id': self.partner_id.id,
            //     'default_opportunity_id': self.id,
            // }
            // action['domain'] = expression.AND([[('opportunity_id', '=', self.id)], self._get_lead_sale_order_domain()])
            // orders = self.order_ids.filtered_domain(self._get_lead_sale_order_domain())
            // if len(orders) == 1:
            //     action['views'] = [(self.env.ref('sale.view_order_form').id, 'form')]
            //     action['res_id'] = orders.id
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<CrmLead> ViewSaleQuotationAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale_crm, FILE: crm_lead.py) ---
            // def action_view_sale_quotation(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("sale.action_quotations_with_onboarding")
            // action['context'] = self._prepare_opportunity_quotation_context()
            // action['context']['search_default_draft'] = 1
            // action['domain'] = expression.AND([[('opportunity_id', '=', self.id)], self._get_action_view_sale_quotation_domain()])
            // quotations = self.order_ids.filtered_domain(self._get_action_view_sale_quotation_domain())
            // if len(quotations) == 1:
            //     action['views'] = [(self.env.ref('sale.view_order_form').id, 'form')]
            //     action['res_id'] = quotations.id
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<CrmLead> WebsiteFormInputFilterAsync(Guid id, CrmLeadWebsiteFormInputFilterRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_crm, FILE: crm_lead.py) ---
            // def website_form_input_filter(self, request, values):
            // values['medium_id'] = values.get('medium_id') or \
            //                       self.sudo().default_get(['medium_id']).get('medium_id') or \
            //                       self.env['utm.medium']._fetch_or_create_utm_medium('website').id
            // values['team_id'] = values.get('team_id') or \
            //                     request.website.crm_default_team_id.id
            // values['user_id'] = values.get('user_id') or \
            //                     request.website.crm_default_user_id.id
            // if values.get('team_id'):
            //     values['type'] = 'lead' if self.env['crm.team'].sudo().browse(values['team_id']).use_leads else 'opportunity'
            // else:
            //     values['type'] = 'lead' if self.env.user.has_group('crm.group_use_lead') else 'opportunity'
            // 
            // return values
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}