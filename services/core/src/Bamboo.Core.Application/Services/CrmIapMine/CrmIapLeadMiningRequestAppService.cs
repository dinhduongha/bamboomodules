using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Bamboo.Core.Application.Services
{
    [Module("CrmIapMine", Depends = new[] { "iap_crm", "iap_mail" })]
    public class CrmIapLeadMiningRequestAppService : GenericApplicationService<CrmIapLeadMiningRequest>, ICrmIapLeadMiningRequestAppService
    {

        public CrmIapLeadMiningRequestAppService(IRepository<CrmIapLeadMiningRequest, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public async Task<CrmIapLeadMiningRequest> BuyCreditsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py) ---
            // def action_buy_credits(self):
            // return {
            //     'type': 'ir.actions.act_url',
            //     'url': self.env['iap.account'].get_credits_url(service_name='reveal'),
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<CrmIapLeadMiningRequest> ComputeAvailableStateIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py) ---
            // def _compute_available_state_ids(self):
            // """ States for some specific countries should not be offered as filtering options because
            // they drastically reduce the amount of IAP reveal results.
            // 
            // For example, in Belgium, only 11% of companies have a defined state within the
            // reveal service while the rest of them have no state defined at all.
            // 
            // Meaning specifying states for that country will yield a lot less results than what you could
            // expect, which is not the desired behavior.
            // Obviously all companies are active within a state, it's just a lack of data in the reveal
            // service side.
            // 
            // To help users create meaningful iap searches, we only keep the states filtering for several
            // whitelisted countries (based on their country code).
            // The complete list and reasons for this change can be found on task-2471703. """
            // 
            // for lead_mining_request in self:
            //     countries = lead_mining_request.country_ids.filtered(lambda country:
            //         country.code in iap_tools._STATES_FILTER_COUNTRIES_WHITELIST)
            //     lead_mining_request.available_state_ids = self.env['res.country.state'].search([
            //         ('country_id', 'in', countries.ids)
            //     ])
            */
            return default;
        }

        protected async Task<CrmIapLeadMiningRequest> ComputeLeadCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py) ---
            // def _compute_lead_count(self):
            // leads_data = self.env['crm.lead']._read_group(
            //     [('lead_mining_request_id', 'in', self.ids)],
            //     ['lead_mining_request_id'], ['__count'])
            // mapped_data = {
            //     lead_mining_request.id: count
            //     for lead_mining_request, count in leads_data}
            // for request in self:
            //     request.lead_count = mapped_data.get(request.id, 0)
            */
            return default;
        }

        protected async Task<CrmIapLeadMiningRequest> ComputeTeamIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py) ---
            // def _compute_team_id(self):
            // """ When changing the user, also set a team_id or restrict team id
            // to the ones user_id is member of. """
            // for mining in self:
            //     # setting user as void should not trigger a new team computation
            //     if not mining.user_id:
            //         continue
            //     user = mining.user_id
            //     if mining.team_id and user in mining.team_id.member_ids | mining.team_id.user_id:
            //         continue
            //     team_domain = [('use_leads', '=', True)] if mining.lead_type == 'lead' else [('use_opportunities', '=', True)]
            //     team = self.env['crm.team']._get_default_team_id(user_id=user.id, domain=team_domain)
            //     mining.team_id = team.id
            */
            return default;
        }

        protected async Task<CrmIapLeadMiningRequest> ComputeTooltipInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py) ---
            // def _compute_tooltip(self):
            // for record in self:
            //     company_credits = CREDIT_PER_COMPANY * record.lead_number
            //     contact_credits = CREDIT_PER_CONTACT * record.contact_number
            //     total_contact_credits = contact_credits * record.lead_number
            //     record.lead_contacts_credits = _(
            //         "Up to %(credit_count)d additional credits will be consumed to identify %(contact_count)d contacts per company.",
            //         credit_count=contact_credits * company_credits,
            //         contact_count=record.contact_number,
            //     )
            //     record.lead_credits = _(
            //         "%(credit_count)d credits will be consumed to find %(company_count)d companies.",
            //         credit_count=company_credits,
            //         company_count=record.lead_number,
            //     )
            //     record.lead_total_credits = _("This makes a total of %d credits for this request.", total_contact_credits + company_credits)
            */
            return default;
        }

        protected async Task<CrmIapLeadMiningRequest> CreateLeadsFromResponseInternalAsync(object result)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py) ---
            // def _create_leads_from_response(self, result):
            // """ This method will get the response from the service and create the leads accordingly """
            // self.ensure_one()
            // lead_vals_list = []
            // messages_to_post = {}
            // for data in result:
            //     lead_vals_list.append(self._lead_vals_from_response(data))
            // 
            //     template_values = data['company_data']
            //     template_values.update({
            //         'flavor_text': _("Opportunity created by Odoo Lead Generation"),
            //         'people_data': data.get('people_data'),
            //     })
            //     messages_to_post[data['company_data']['clearbit_id']] = template_values
            // leads = self.env['crm.lead'].create(lead_vals_list)
            // for lead in leads:
            //     if messages_to_post.get(lead.reveal_id):
            //         lead.message_post_with_source(
            //             'iap_mail.enrich_company',
            //             render_values=messages_to_post[lead.reveal_id],
            //             subtype_xmlid='mail.mt_note',
            //         )
            */
            return default;
        }

        protected async Task<CrmIapLeadMiningRequest> DefaultCountryIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py) ---
            // def _default_country_ids(self):
            // return self.env.user.company_id.country_id
            */
            return default;
        }

        protected async Task<CrmIapLeadMiningRequest> DefaultLeadTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py) ---
            // def _default_lead_type(self):
            // if self.env.user.has_group('crm.group_use_lead'):
            //     return 'lead'
            // else:
            //     return 'opportunity'
            */
            return default;
        }

        public async Task<CrmIapLeadMiningRequest> DraftAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py) ---
            // def action_draft(self):
            // self.ensure_one()
            // self.name = _('New')
            // self.state = 'draft'
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<CrmIapLeadMiningRequest> GetEmptyListHelpAsync(Guid id, CrmIapLeadMiningRequestGetEmptyListHelpRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py) ---
            // def get_empty_list_help(self, help_message):
            // if not is_html_empty(help_message):
            //     return help_message
            // 
            // help_title = _('Create a Lead Mining Request')
            // sub_title = _('Generate new leads based on their country, industry, size, etc.')
            // return super().get_empty_list_help(
            //     f'<p class="o_view_nocontent_smiling_face">{help_title}</p><p class="oe_view_nocontent_alias">{sub_title}</p>'
            // )
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<CrmIapLeadMiningRequest> GetLeadActionAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py) ---
            // def action_get_lead_action(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("crm.crm_lead_all_leads")
            // action['domain'] = [('id', 'in', self.lead_ids.ids), ('type', '=', 'lead')]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<CrmIapLeadMiningRequest> GetOpportunityActionAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py) ---
            // def action_get_opportunity_action(self):
            // self.ensure_one()
            // action = self.env["ir.actions.actions"]._for_xml_id("crm.crm_lead_opportunities")
            // action['domain'] = [('id', 'in', self.lead_ids.ids), ('type', '=', 'opportunity')]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<CrmIapLeadMiningRequest> IapContactMiningInternalAsync(object @params, object timeout)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py) ---
            // def _iap_contact_mining(self, params, timeout=300):
            // endpoint = self.env['ir.config_parameter'].sudo().get_param('reveal.endpoint', DEFAULT_ENDPOINT) + '/iap/clearbit/2/lead_mining_request'
            // return iap_tools.iap_jsonrpc(endpoint, params=params, timeout=timeout)
            */
            return default;
        }

        protected async Task<CrmIapLeadMiningRequest> LeadValsFromResponseInternalAsync(object data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py) ---
            // def _lead_vals_from_response(self, data):
            // self.ensure_one()
            // company_data = data.get('company_data')
            // people_data = data.get('people_data')
            // lead_vals = self.env['crm.iap.lead.helpers'].lead_vals_from_response(self.lead_type, self.team_id.id, self.tag_ids.ids, self.user_id.id, company_data, people_data)
            // lead_vals['lead_mining_request_id'] = self.id
            // return lead_vals
            */
            return default;
        }

        protected async Task<CrmIapLeadMiningRequest> OnchangeAvailableStateIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py) ---
            // def _onchange_available_state_ids(self):
            // self.state_ids -= self.state_ids.filtered(
            //     lambda state: (state._origin.id or state.id) not in self.available_state_ids.ids
            // )
            */
            return default;
        }

        protected async Task<CrmIapLeadMiningRequest> OnchangeCompanySizeMaxInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py) ---
            // def _onchange_company_size_max(self):
            // if self.company_size_max < self.company_size_min:
            //     self.company_size_max = self.company_size_min
            */
            return default;
        }

        protected async Task<CrmIapLeadMiningRequest> OnchangeCompanySizeMinInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py) ---
            // def _onchange_company_size_min(self):
            // if self.company_size_min <= 0:
            //     self.company_size_min = 1
            // elif self.company_size_min > self.company_size_max:
            //     self.company_size_min = self.company_size_max
            */
            return default;
        }

        protected async Task<CrmIapLeadMiningRequest> OnchangeContactNumberInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py) ---
            // def _onchange_contact_number(self):
            // if self.contact_number <= 0:
            //     self.contact_number = 1
            // elif self.contact_number > MAX_CONTACT:
            //     self.contact_number = MAX_CONTACT
            */
            return default;
        }

        protected async Task<CrmIapLeadMiningRequest> OnchangeCountryIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py) ---
            // def _onchange_country_ids(self):
            // self.state_ids = []
            */
            return default;
        }

        protected async Task<CrmIapLeadMiningRequest> OnchangeLeadNumberInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py) ---
            // def _onchange_lead_number(self):
            // if self.lead_number <= 0:
            //     self.lead_number = 1
            // elif self.lead_number > MAX_LEAD:
            //     self.lead_number = MAX_LEAD
            */
            return default;
        }

        protected async Task<CrmIapLeadMiningRequest> PerformRequestInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py) ---
            // def _perform_request(self):
            // """
            // This will perform the request and create the corresponding leads.
            // The user will be notified if they don't have enough credits.
            // """
            // self.error_type = False
            // server_payload = self._prepare_iap_payload()
            // reveal_account = self.env['iap.account'].get('reveal')
            // dbuuid = self.env['ir.config_parameter'].sudo().get_param('database.uuid')
            // params = {
            //     'account_token': reveal_account.account_token,
            //     'dbuuid': dbuuid,
            //     'data': server_payload
            // }
            // try:
            //     response = self._iap_contact_mining(params, timeout=300)
            //     if not response.get('data'):
            //         self.error_type = 'no_result'
            //         return False
            // 
            //     return response['data']
            // except iap_tools.InsufficientCreditError as e:
            //     self.error_type = 'credits'
            //     self.state = 'error'
            //     return False
            // except Exception as e:
            //     raise UserError(_("Your request could not be executed: %s", e))
            */
            return default;
        }

        protected async Task<CrmIapLeadMiningRequest> PrepareIapPayloadInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py) ---
            // def _prepare_iap_payload(self):
            // """
            // This will prepare the data to send to the server
            // """
            // self.ensure_one()
            // payload = {
            //     'lead_number': self.lead_number,
            //     'search_type': self.search_type,
            //     'countries': [{
            //         'code': country.code,
            //         'states': self.state_ids.filtered(lambda state: state in country.state_ids).mapped('code'),
            //     } for country in self.country_ids],
            // }
            // 
            // if self.filter_on_size:
            //     payload.update({'company_size_min': self.company_size_min,
            //                     'company_size_max': self.company_size_max})
            // if self.industry_ids:
            //     # accumulate all reveal_ids (separated by ',') into one list
            //     # eg: 3 records with values: "175,176", "177" and "190,191"
            //     # will become ['175','176','177','190','191']
            //     all_industry_ids = [
            //         reveal_id.strip()
            //         for reveal_ids in self.mapped('industry_ids.reveal_ids')
            //         for reveal_id in reveal_ids.split(',')
            //     ]
            //     payload['industry_ids'] = all_industry_ids
            // if self.search_type == 'people':
            //     payload.update({'contact_number': self.contact_number,
            //                     'contact_filter_type': self.contact_filter_type})
            //     if self.contact_filter_type == 'role':
            //         payload.update({'preferred_role': self.preferred_role_id.reveal_id,
            //                         'other_roles': self.role_ids.mapped('reveal_id')})
            //     elif self.contact_filter_type == 'seniority':
            //         payload['seniority'] = self.seniority_id.reveal_id
            // return payload
            */
            return default;
        }

        public async Task<CrmIapLeadMiningRequest> SubmitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm_iap_mine, FILE: crm_iap_lead_mining_request.py) ---
            // def action_submit(self):
            // self.ensure_one()
            // if self.name == _('New'):
            //     self.name = self.env['ir.sequence'].next_by_code('crm.iap.lead.mining.request') or _('New')
            // results = self._perform_request()
            // 
            // if results:
            //     self._create_leads_from_response(results)
            //     self.state = 'done'
            //     if self.lead_type == 'lead':
            //         return self.action_get_lead_action()
            //     elif self.lead_type == 'opportunity':
            //         return self.action_get_opportunity_action()
            // elif self.env.context.get('is_modal'):
            //     # when we are inside a modal already, we re-open the same record
            //     # that way, the form view is updated and the correct error message appears
            //     # (sadly, there is no way to simply 'reload' a form view within a modal)
            //     return {
            //         'name': _('Generate Leads'),
            //         'res_model': 'crm.iap.lead.mining.request',
            //         'views': [[False, 'form']],
            //         'target': 'new',
            //         'type': 'ir.actions.act_window',
            //         'res_id': self.id,
            //         'context': dict(self.env.context, edit=True)
            //     }
            // else:
            //     # will reload the form view and show the error message on top
            //     return False
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}