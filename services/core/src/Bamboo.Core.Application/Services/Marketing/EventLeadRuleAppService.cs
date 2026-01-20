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
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("EventCrm", Category = "Marketing", Depends = new[] { "event", "crm" })]
    public partial class EventLeadRuleAppService : GenericApplicationService<EventLeadRule>, IEventLeadRuleAppService
    {

        public EventLeadRuleAppService(IRepository<EventLeadRule, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {

        }

        public async Task<EventLeadRule> ExecuteRuleAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_crm, FILE: event_lead_rule.py) ---
            // def action_execute_rule(self):
            // events = self.event_id or self.env['event.event'].search([('is_finished', '!=', True)])
            // return events.action_generate_leads(event_lead_rules=self)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<EventLeadRule> FilterRegistrationsInternalAsync(object registrations)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_crm, FILE: event_lead_rule.py) ---
            // def _filter_registrations(self, registrations):
            // """ Keep registrations matching rule conditions. Those are
            // 
            //   * if a filter is set: filter registrations based on this filter. This is
            //     done like a search, and filter is a domain;
            //   * if a company is set on the rule, it must match event's company. Note
            //     that multi-company rules apply on event_lead_rule;
            //   * if an event category it set, it must match;
            //   * if an event is set, it must match;
            //   * if both event and category are set, one of them must match (OR). If none
            //     of those are set, it is considered as OK;
            // 
            // :param registrations: event.registration recordset on which rule filters
            //   will be evaluated;
            // :return: subset of registrations matching rules
            // """
            // self.ensure_one()
            // if self.event_registration_filter and self.event_registration_filter != '[]':
            //     registrations = registrations.filtered_domain(literal_eval(self.event_registration_filter))
            // 
            // # check from direct m2o to linked m2o / o2m to filter first without inner search
            // company_ok = lambda registration: registration.company_id == self.company_id if self.company_id else True
            // event_or_event_type_ok = \
            //     lambda registration: \
            //         registration.event_id == self.event_id or registration.event_id.event_type_id in self.event_type_ids \
            //         if (self.event_id or self.event_type_ids) else True
            // 
            // return registrations.filtered(lambda r: company_ok(r) and event_or_event_type_ok(r))
            */
            return default;
        }

        protected async Task<EventLeadRule> OnchangeLeadSalesTeamIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_crm, FILE: event_lead_rule.py) ---
            // def _onchange_lead_sales_team_id(self):
            // if self.lead_sales_team_id and self.lead_sales_team_id.user_id:
            //     self.lead_user_id = self.lead_sales_team_id.user_id
            */
            return default;
        }

        protected async Task<EventLeadRule> RunOnRegistrationsInternalAsync(object registrations)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_crm, FILE: event_lead_rule.py) ---
            // def _run_on_registrations(self, registrations):
            // """ Create or update leads based on rule configuration. Two main lead
            // management type exists
            // 
            //   * per attendee: each registration creates a lead;
            //   * per order: registrations are grouped per group and one lead is created
            //     or updated with the batch (used mainly with sale order configuration
            //     in event_sale);
            // 
            // Heuristic
            // 
            //   * first, check existing lead linked to registrations to ensure no
            //     duplication. Indeed for example attendee status change may trigger
            //     the same rule several times;
            //   * then for each rule, get the subset of registrations matching its
            //     filters;
            //   * then for each order-based rule, get the grouping information. This
            //     give a list of registrations by group (event, sale_order), with maybe
            //     an already-existing lead to update instead of creating a new one;
            //   * finally apply rules. Attendee-based rules create a lead for each
            //     attendee, group-based rules use the grouping information to create
            //     or update leads;
            // 
            // :param registrations: event.registration recordset on which rules given by
            //   self have to run. Triggers should already be checked, only filters are
            //   applied here.
            // 
            // :returns: newly-created leads. Updated leads are not returned.
            // """
            // if not self:
            //     return self.env['crm.lead']
            // 
            // # order by ID, ensure first created wins
            // registrations = registrations.sorted('id')
            // 
            // # first: ensure no duplicate by searching existing registrations / rule (include lost leads)
            // existing_leads = self.env['crm.lead'].with_context(active_test=False).search([
            //     ('registration_ids', 'in', registrations.ids),
            //     ('event_lead_rule_id', 'in', self.ids)
            // ])
            // rule_to_existing_regs = defaultdict(lambda: self.env['event.registration'])
            // for lead in existing_leads:
            //     rule_to_existing_regs[lead.event_lead_rule_id] += lead.registration_ids
            // 
            // # second: check registrations matching rules (in batch)
            // new_registrations = self.env['event.registration']
            // rule_to_new_regs = dict()
            // for rule in self:
            //     new_for_rule = registrations.filtered(lambda reg: reg not in rule_to_existing_regs[rule])
            //     rule_registrations = rule._filter_registrations(new_for_rule)
            //     new_registrations |= rule_registrations
            //     rule_to_new_regs[rule] = rule_registrations
            // new_registrations.sorted('id')  # as an OR was used, re-ensure order
            // 
            // # third: check grouping
            // order_based_rules = self.filtered(lambda rule: rule.lead_creation_basis == 'order')
            // rule_group_info = new_registrations._get_lead_grouping(order_based_rules, rule_to_new_regs)
            // 
            // lead_vals_list = []
            // for rule in self:
            //     if rule.lead_creation_basis == 'attendee':
            //         matching_registrations = rule_to_new_regs[rule].sorted('id')
            //         for registration in matching_registrations:
            //             lead_vals_list.append(registration._get_lead_values(rule))
            //     else:
            //         # check if registrations are part of a group, for example a sale order, to know if we update or create leads
            //         for toupdate_leads, _group_key, group_registrations in rule_group_info[rule]:
            //             if toupdate_leads:
            //                 additionnal_description = group_registrations._get_lead_description(_("New registrations"), line_counter=True)
            //                 for lead in toupdate_leads:
            //                     lead.write({
            //                         'description': "%s<br/>%s" % (lead.description, additionnal_description),
            //                         'registration_ids': [(4, reg.id) for reg in group_registrations],
            //                     })
            //             elif group_registrations:
            //                 lead_vals_list.append(group_registrations._get_lead_values(rule))
            // 
            // return self.env['crm.lead'].create(lead_vals_list)
            */
            return default;
        }
    }
}