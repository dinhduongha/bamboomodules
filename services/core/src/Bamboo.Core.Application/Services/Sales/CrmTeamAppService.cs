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
    [Module("SalesTeam", Category = "Sales", Depends = new[] { "base", "mail" })]
    public class CrmTeamAppService : GenericApplicationService<CrmTeam>, ICrmTeamAppService
    {
        private readonly IMailAliasMixinAppService _mailAliasMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        public CrmTeamAppService(IRepository<CrmTeam, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailAliasMixinAppService mailAliasMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailAliasMixinAppService = mailAliasMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        protected async Task<CrmTeam> ActionAssignLeadsInternalAsync(object force_quota, object creation_delta_days)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_team.py) ---
            // def _action_assign_leads(self, force_quota=False, creation_delta_days=7):
            // """ Private method for lead assignment. This method both
            // 
            //   * assigns leads to teams given by self;
            //   * assigns leads to salespersons belonging to self;
            // 
            // See sub methods for more details about assign process.
            // 
            // :param bool force_quota: Assign the full daily quota without taking into account
            //                          the leads already assigned today
            // :param int creation_delta_days: Take into account all leads created in the last nb days (by default 7).
            //                                 If set to zero we take all the past leads.
            // 
            // :return teams_data, members_data: structure-based result of assignment
            //   process. For more details about data see ``CrmTeam._allocate_leads()``
            //   and ``CrmTeam._assign_and_convert_leads``;
            // """
            // if not (self.env.user.has_group('sales_team.group_sale_manager') or self.env.is_system()):
            //     raise exceptions.UserError(_('Lead/Opportunities automatic assignment is limited to managers or administrators'))
            // 
            // _logger.info(
            //     '### START Lead Assignment (%d teams, %d sales persons, force daily quota: %s)',
            //     len(self),
            //     len(self.crm_team_member_ids),
            //     "ON" if force_quota else "OFF")
            // teams_data = self._allocate_leads(creation_delta_days=creation_delta_days)
            // _logger.info('### Team repartition done. Starting salesmen assignment.')
            // members_data = self._assign_and_convert_leads(force_quota=force_quota)
            // _logger.info('### END Lead Assignment')
            // return teams_data, members_data
            */
            return default;
        }

        protected async Task<CrmTeam> ActionAssignLeadsLogsInternalAsync(object teams_data, object members_data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_team.py) ---
            // def _action_assign_leads_logs(self, teams_data, members_data):
            // """ Tool method to prepare notification about assignment process result.
            // 
            // :param teams_data: see ``CrmTeam._allocate_leads()``;
            // :param members_data: see ``CrmTeam._assign_and_convert_leads()``;
            // 
            // :return list: list of formatted logs, ready to be formatted into a nice
            // plaintext or html message at caller's will
            // """
            // # extract some statistics
            // assigned = sum(len(teams_data[team]['assigned']) + len(teams_data[team]['merged']) for team in teams_data)
            // duplicates = sum(len(teams_data[team]['duplicates']) for team in teams_data)
            // members = len(members_data)
            // members_assigned = sum(len(member_data['assigned']) for member_data in members_data.values())
            // 
            // # format user notification
            // message_parts = []
            // # 1- duplicates removal
            // if duplicates:
            //     message_parts.append(_("%(duplicates)s duplicates leads have been merged.",
            //                            duplicates=duplicates))
            // 
            // # 2- nothing assigned at all
            // if not assigned and not members_assigned:
            //     if len(self) == 1:
            //         if not self.assignment_max:
            //             message_parts.append(
            //                 _("No allocated leads to %(team_name)s team because it has no capacity. Add capacity to its salespersons.",
            //                   team_name=self.name))
            //         else:
            //             message_parts.append(
            //                 _("No allocated leads to %(team_name)s team and its salespersons because no unassigned lead matches its domain.",
            //                   team_name=self.name))
            //     else:
            //         message_parts.append(
            //             _("No allocated leads to any team or salesperson. Check your Sales Teams and Salespersons configuration as well as unassigned leads."))
            // 
            // # 3- team allocation
            // if not assigned and members_assigned:
            //     if len(self) == 1:
            //         message_parts.append(
            //             _("No new lead allocated to %(team_name)s team because no unassigned lead matches its domain.",
            //               team_name=self.name))
            //     else:
            //         message_parts.append(_("No new lead allocated to the teams because no lead match their domains."))
            // elif assigned:
            //     if len(self) == 1:
            //         message_parts.append(
            //             _("%(assigned)s leads allocated to %(team_name)s team.",
            //               assigned=assigned, team_name=self.name))
            //     else:
            //         message_parts.append(
            //             _("%(assigned)s leads allocated among %(team_count)s teams.",
            //               assigned=assigned, team_count=len(self)))
            // 
            // # 4- salespersons assignment
            // if not members_assigned and assigned:
            //     message_parts.append(
            //         _("No lead assigned to salespersons because no unassigned lead matches their domains."))
            // elif members_assigned:
            //     message_parts.append(
            //         _("%(members_assigned)s leads assigned among %(member_count)s salespersons.",
            //           members_assigned=members_assigned, member_count=members))
            // 
            // return message_parts
            */
            return default;
        }

        protected async Task<CrmTeam> ActionUpdateToPipelineInternalAsync(object action)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_team.py) ---
            // def _action_update_to_pipeline(self, action):
            // self.check_access("read")
            // user_team_id = self.env.user.sale_team_id.id
            // if not user_team_id:
            //     user_team_id = self.search([], limit=1).id
            //     action['help'] = "<p class='o_view_nocontent_smiling_face'>%s</p><p>" % _("Create an Opportunity")
            //     if user_team_id:
            //         if self.env.user.has_group('sales_team.group_sale_manager'):
            //             action['help'] += "<p>%s</p>" % _("""As you are a member of no Sales Team, you are showed the Pipeline of the <b>first team by default.</b>
            //                                 To work with the CRM, you should <a name="%d" type="action" tabindex="-1">join a team.</a>""",
            //                                 self.env.ref('sales_team.crm_team_action_config').id)
            //         else:
            //             action['help'] += "<p>%s</p>" % _("""As you are a member of no Sales Team, you are showed the Pipeline of the <b>first team by default.</b>
            //                                 To work with the CRM, you should join a team.""")
            // action_context = safe_eval(action['context'], {'uid': self.env.uid})
            // action['context'] = action_context
            // return action
            */
            return default;
        }

        protected async Task<CrmTeam> AddMembersToFavoritesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py) ---
            // def _add_members_to_favorites(self):
            // for team in self:
            //     team.favorite_user_ids = [(4, member.id) for member in team.member_ids]
            */
            return default;
        }

        protected async Task<CrmTeam> AliasGetCreationValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_team.py) ---
            // def _alias_get_creation_values(self):
            // values = super(Team, self)._alias_get_creation_values()
            // values['alias_model_id'] = self.env['ir.model']._get('crm.lead').id
            // if self.id:
            //     if not self.use_leads and not self.use_opportunities:
            //         values['alias_name'] = False
            //     values['alias_defaults'] = defaults = literal_eval(self.alias_defaults or "{}")
            //     has_group_use_lead = self.env.user.has_group('crm.group_use_lead')
            //     defaults['type'] = 'lead' if has_group_use_lead and self.use_leads else 'opportunity'
            //     defaults['team_id'] = self.id
            // return values
            */
            return default;
        }

        protected async Task<CrmTeam> AllocateLeadsDeduplicateInternalAsync(object leads, object duplicates_cache)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_team.py) ---
            // def _allocate_leads_deduplicate(self, leads, duplicates_cache=None):
            // """ Assign leads to sales team given by self by calling lead tool
            // method _handle_salesmen_assignment. In this method we deduplicate leads
            // allowing to reduce number of resulting leads before assigning them
            // to salesmen.
            // 
            // :param leads: recordset of leads to assign to current team;
            // :param duplicates_cache: if given, avoid to perform a duplicate search
            //   and fetch information in it instead;
            // """
            // self.ensure_one()
            // duplicates_cache = duplicates_cache if duplicates_cache is not None else dict()
            // 
            // # classify leads
            // leads_assigned = self.env['crm.lead']  # direct team assign
            // leads_done_ids, leads_merged_ids, leads_dup_ids = set(), set(), set()  # classification
            // leads_dups_dict = dict()  # lead -> its duplicate
            // for lead in leads:
            //     if lead.id not in leads_done_ids:
            // 
            //         # fill cache if not already done
            //         if lead not in duplicates_cache:
            //             duplicates_cache[lead] = lead._get_lead_duplicates(email=lead.email_from)
            //         lead_duplicates = duplicates_cache[lead].exists()
            // 
            //         if len(lead_duplicates) > 1:
            //             leads_dups_dict[lead] = lead_duplicates
            //             leads_done_ids.update((lead + lead_duplicates).ids)
            //         else:
            //             leads_assigned += lead
            //             leads_done_ids.add(lead.id)
            // 
            // # assign team to direct assign (leads_assigned) + dups keys (to ensure their team
            // # if they are elected master of merge process)
            // dups_to_assign = [lead for lead in leads_dups_dict]
            // leads_assigned.union(*dups_to_assign)._handle_salesmen_assignment(user_ids=None, team_id=self.id)
            // 
            // for lead in leads.filtered(lambda lead: lead in leads_dups_dict):
            //     lead_duplicates = leads_dups_dict[lead]
            //     merged = lead_duplicates._merge_opportunity(user_id=False, team_id=False, auto_unlink=False, max_length=0)
            //     leads_dup_ids.update((lead_duplicates - merged).ids)
            //     leads_merged_ids.add(merged.id)
            // 
            // return {
            //     'assigned': set(leads_assigned.ids),
            //     'merged': leads_merged_ids,
            //     'duplicates': leads_dup_ids,
            // }
            */
            return default;
        }

        protected async Task<CrmTeam> AllocateLeadsInternalAsync(object creation_delta_days)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_team.py) ---
            // def _allocate_leads(self, creation_delta_days=7):
            // """ Allocate leads to teams given by self. This method sets ``team_id``
            // field on lead records that are unassigned (no team and no responsible).
            // No salesperson is assigned in this process. Its purpose is simply to
            // allocate leads within teams.
            // 
            // This process allocates all available leads on teams weighted by their
            // maximum assignment by month that indicates their relative workload.
            // 
            // Heuristic of this method is the following:
            //   * find unassigned leads for each team, aka leads being
            //     * without team, without user -> not assigned;
            //     * not in a won stage, and not having False/0 (lost) or 100 (won)
            //       probability) -> live leads;
            //     * created in the last creation_delta_days (in the last week by default)
            //       This avoid to take into account old leads in the allocation.
            //     * if set, a delay after creation can be applied (see BUNDLE_HOURS_DELAY)
            //       parameter explanations here below;
            //     * matching the team's assignment domain (empty means
            //       everything);
            // 
            //   * assign a weight to each team based on their assignment_max that
            //     indicates their relative workload;
            // 
            //   * pick a random team using a weighted random choice and find a lead
            //     to assign:
            // 
            //     * remove already assigned leads from the available leads. If there
            //       is not any lead spare to assign, remove team from active teams;
            //     * pick the first lead and set the current team;
            //     * when setting a team on leads, leads are also merged with their
            //       duplicates. Purpose is to clean database and avoid assigning
            //       duplicates to same or different teams;
            //     * add lead and its duplicates to already assigned leads;
            // 
            //   * pick another random team until their is no more leads to assign
            //     to any team;
            // 
            // This process ensure that teams having overlapping domains will all
            // receive leads as lead allocation is done one lead at a time. This
            // allocation will be proportional to their size (assignment of their
            // members).
            // 
            // :config int crm.assignment.bundle: deprecated
            // :config int crm.assignment.commit.bundle: optional config parameter allowing
            //   to set size of lead batch to be committed together. By default 100
            //   which is a good trade-off between transaction time and speed
            // :config float crm.assignment.delay: optional config parameter giving a
            //   delay before taking a lead into assignment process (BUNDLE_HOURS_DELAY)
            //   given in hours. Purpose if to allow other crons or automation rules
            //   to make their job. This option is mainly historic as its purpose was
            //   to let automation rules prepare leads and score before PLS was added
            //   into CRM. This is now not required anymore but still supported;
            // 
            // :param int creation_delta_days: see ``CrmTeam._action_assign_leads()``;
            // 
            // :return teams_data: dict() with each team assignment result:
            //   team: {
            //     'assigned': set of lead IDs directly assigned to the team (no
            //       duplicate or merged found);
            //     'merged': set of lead IDs merged and assigned to the team (main
            //       leads being results of merge process);
            //     'duplicates': set of lead IDs found as duplicates and merged into
            //       other leads. Those leads are unlinked during assign process and
            //       are already removed at return of this method;
            //   }, ...
            // """
            // 
            // BUNDLE_HOURS_DELAY = float(self.env['ir.config_parameter'].sudo().get_param('crm.assignment.delay', default=0))
            // BUNDLE_COMMIT_SIZE = int(self.env['ir.config_parameter'].sudo().get_param('crm.assignment.commit.bundle', 100))
            // auto_commit = not getattr(threading.current_thread(), 'testing', False)
            // 
            // # leads
            // max_create_dt = self.env.cr.now() - datetime.timedelta(hours=BUNDLE_HOURS_DELAY)
            // duplicates_lead_cache = dict()
            // 
            // # teams data
            // teams_data, population, weights = dict(), list(), list()
            // for team in self:
            //     if not team.assignment_max:
            //         continue
            // 
            //     lead_domain = expression.AND([
            //         literal_eval(team.assignment_domain or '[]'),
            //         [('create_date', '<=', max_create_dt)],
            //         ['&', ('team_id', '=', False), ('user_id', '=', False)],
            //         ['|', ('stage_id', '=', False), ('stage_id.is_won', '=', False)]
            //     ])
            //     if creation_delta_days > 0:
            //         lead_domain = expression.AND([
            //             lead_domain,
            //             [('create_date', '>', self.env.cr.now() - datetime.timedelta(days=creation_delta_days))]
            //         ])
            // 
            //     leads = self.env["crm.lead"].search(lead_domain)
            //     # Fill duplicate cache: search for duplicate lead before the assignation
            //     # avoid to flush during the search at every assignation
            //     for lead in leads:
            //         if lead not in duplicates_lead_cache:
            //             duplicates_lead_cache[lead] = lead._get_lead_duplicates(email=lead.email_from)
            // 
            //     teams_data[team] = {
            //         "team": team,
            //         "leads": leads,
            //         "assigned": set(),
            //         "merged": set(),
            //         "duplicates": set(),
            //     }
            //     population.append(team)
            //     weights.append(team.assignment_max)
            // 
            // # Start a new transaction, since data fetching take times
            // # and the first commit occur at the end of the bundle,
            // # the first transaction can be long which we want to avoid
            // if auto_commit:
            //     self._cr.commit()
            // 
            // # assignment process data
            // global_data = dict(assigned=set(), merged=set(), duplicates=set())
            // leads_done_ids, lead_unlink_ids, counter = set(), set(), 0
            // while population:
            //     counter += 1
            //     team = random.choices(population, weights=weights, k=1)[0]
            // 
            //     # filter remaining leads, remove team if no more leads for it
            //     teams_data[team]["leads"] = teams_data[team]["leads"].filtered(lambda l: l.id not in leads_done_ids).exists()
            //     if not teams_data[team]["leads"]:
            //         population_index = population.index(team)
            //         population.pop(population_index)
            //         weights.pop(population_index)
            //         continue
            // 
            //     # assign + deduplicate and concatenate results in teams_data to keep some history
            //     candidate_lead = teams_data[team]["leads"][0]
            //     assign_res = team._allocate_leads_deduplicate(candidate_lead, duplicates_cache=duplicates_lead_cache)
            //     for key in ('assigned', 'merged', 'duplicates'):
            //         teams_data[team][key].update(assign_res[key])
            //         leads_done_ids.update(assign_res[key])
            //         global_data[key].update(assign_res[key])
            //     lead_unlink_ids.update(assign_res['duplicates'])
            // 
            //     # auto-commit except in testing mode. As this process may be time consuming or we
            //     # may encounter errors, already commit what is allocated to avoid endless cron loops.
            //     if auto_commit and counter % BUNDLE_COMMIT_SIZE == 0:
            //         # unlink duplicates once
            //         self.env['crm.lead'].browse(lead_unlink_ids).unlink()
            //         lead_unlink_ids = set()
            //         self._cr.commit()
            // 
            // # unlink duplicates once
            // self.env['crm.lead'].browse(lead_unlink_ids).unlink()
            // 
            // if auto_commit:
            //     self._cr.commit()
            // 
            // # some final log
            // _logger.info('## Assigned %s leads', (len(global_data['assigned']) + len(global_data['merged'])))
            // for team, team_data in teams_data.items():
            //     _logger.info(
            //         '## Assigned %s leads to team %s',
            //         len(team_data['assigned']) + len(team_data['merged']), team.id)
            //     _logger.info(
            //         '\tLeads: direct assign %s / merge result %s / duplicates merged: %s',
            //         team_data['assigned'], team_data['merged'], team_data['duplicates'])
            // return teams_data
            */
            return default;
        }

        protected async Task<CrmTeam> AssignAndConvertLeadsInternalAsync(object force_quota)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_team.py) ---
            // def _assign_and_convert_leads(self, force_quota=False):
            // """ Main processing method to assign leads to sales team members. It also
            // converts them into opportunities. This method should be called after
            // ``_allocate_leads`` as this method assigns leads already allocated to
            // the member's team. Its main purpose is therefore to distribute team
            // workload on its members based on their capacity.
            // 
            // This method follows the following heuristic
            //     * Get quota per member
            //     * Find all leads to be assigned per team
            //     * Sort list of members per number of leads received in the last 24h
            //     * Assign the lead using round robin
            //         * Find the first member with a compatible domain
            //         * Assign the lead
            //         * Move the member at the end of the list if quota is not reached
            //         * Remove it otherwise
            //         * Move to the next lead
            // 
            // :param bool force_quota: see ``CrmTeam._action_assign_leads()``;
            // 
            // :return members_data: dict() with each member assignment result:
            //   membership: {
            //     'assigned': set of lead IDs directly assigned to the member;
            //   }, ...
            // 
            // """
            // auto_commit = not getattr(threading.current_thread(), 'testing', False)
            // result_data = {}
            // commit_bundle_size = int(self.env['ir.config_parameter'].sudo().get_param('crm.assignment.commit.bundle', 100))
            // teams_with_members = self.filtered(lambda team: team.crm_team_member_ids)
            // quota_per_member = {member: member._get_assignment_quota(force_quota=force_quota) for member in self.crm_team_member_ids}
            // counter = 0
            // leads_per_team = dict(self.env['crm.lead']._read_group(
            //     teams_with_members._get_lead_to_assign_domain(),
            //     ['team_id'],
            //     # Do not use recordset aggregation to avoid fetching all the leads at once in memory
            //     # We want to have in memory only leads for the current team
            //     # and make sure we need them before fetching them
            //     ['id:array_agg'],
            // ))
            // for team, leads_to_assign_ids in leads_per_team.items():
            //     members_to_assign = list(team.crm_team_member_ids.filtered(lambda member:
            //         not member.assignment_optout and quota_per_member.get(member, 0) > 0
            //     ).sorted(key=lambda member: quota_per_member.get(member, 0), reverse=True))
            //     if not members_to_assign:
            //         continue
            //     result_data.update({
            //         member: {"assigned": self.env["crm.lead"], "quota": quota_per_member[member]}
            //         for member in members_to_assign
            //     })
            //     # Need to check that record still exists since the ids have been fetched at the begining of the process
            //     # Previous iteration has commited the change, records may have been deleted in the meanwhile
            //     leads_to_assign = self.env['crm.lead'].browse(leads_to_assign_ids).exists()
            //     leads_per_member = {
            //         member: leads_to_assign.filtered_domain(literal_eval(member.assignment_domain or '[]'))
            //         for member in members_to_assign
            //     }
            //     for lead in leads_to_assign.sorted(lambda lead: (-lead.probability, id)):
            //         counter += 1
            //         member_found = next((member for member in members_to_assign if lead in leads_per_member[member]), False)
            //         if not member_found:
            //             continue
            //         lead.with_context(mail_auto_subscribe_no_notify=True).convert_opportunity(
            //             lead.partner_id,
            //             user_ids=member_found.user_id.ids
            //         )
            //         result_data[member_found]['assigned'] += lead
            //         members_to_assign.remove(member_found)
            //         quota_per_member[member_found] -= 1
            //         if quota_per_member[member_found] > 0:
            //             # If the member should receive more lead, send him back at the end of the list
            //             members_to_assign.append(member_found)
            // 
            //         if auto_commit and counter % commit_bundle_size == 0:
            //             self.env.cr.commit()
            //     # Make sure we commit at least at the end of the team
            //     if auto_commit:
            //         self.env.cr.commit()
            //     # Once we are done with a team we don't need to keep the leads in memory
            //     # Try to avoid to explode memory usage
            //     self.env.invalidate_all()
            // 
            // _logger.info('Assigned %s leads to %s salesmen', sum(len(r['assigned']) for r in result_data.values()), len(result_data))
            // for member, member_info in result_data.items():
            //     _logger.info('-> member %s of team %s: assigned %d/%d leads (%s)', member.id, member.crm_team_id.id, len(member_info["assigned"]), member_info["quota"], member_info["assigned"])
            // return result_data
            */
            return default;
        }

        public async Task<CrmTeam> AssignLeadsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_team.py) ---
            // def action_assign_leads(self):
            // """ Manual (direct) leads assignment. This method both
            // 
            //   * assigns leads to teams given by self;
            //   * assigns leads to salespersons belonging to self;
            // 
            // See sub methods for more details about assign process.
            // 
            // :return action: a client notification giving some insights on assign
            //   process;
            // """
            // teams_data, members_data = self._action_assign_leads(force_quota=True, creation_delta_days=0)
            // 
            // # format result messages
            // logs = self._action_assign_leads_logs(teams_data, members_data)
            // html_message = Markup('<br />').join(logs)
            // notif_message = ' '.join(logs)
            // 
            // # log a note in case of manual assign (as this method will mainly be called
            // # on singleton record set, do not bother doing a specific message per team)
            // log_action = _("Lead Assignment requested by %(user_name)s", user_name=self.env.user.name)
            // log_message = Markup("<p>%s<br /><br />%s</p>") % (log_action, html_message)
            // self._message_log_batch(bodies=dict((team.id, log_message) for team in self))
            // 
            // return {
            //     'type': 'ir.actions.client',
            //     'tag': 'display_notification',
            //     'params': {
            //         'type': 'success',
            //         'title': _("Leads Assigned"),
            //         'message': notif_message,
            //         'next': {
            //             'type': 'ir.actions.act_window_close'
            //         },
            //     }
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<CrmTeam> ComputeAbandonedCartsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: crm_team.py) ---
            // def _compute_abandoned_carts(self):
            // # abandoned carts to recover are draft sales orders that have no order lines,
            // # a partner other than the public user, and created over an hour ago
            // # and the recovery mail was not yet sent
            // website_teams = self.filtered(lambda team: team.website_ids)
            // abandoned_carts_data = self.env['sale.order']._read_group([
            //     ('is_abandoned_cart', '=', True),
            //     ('cart_recovery_email_sent', '=', False),
            //     ('team_id', 'in', website_teams.ids),
            // ], ['team_id'], ['amount_total:sum', '__count'])
            // counts = {team.id: count for team, __, count in abandoned_carts_data}
            // amounts = {team.id: amount_total_sum for team, amount_total_sum, __ in abandoned_carts_data}
            // for team in self:
            //     team.abandoned_carts_count = counts.get(team.id, 0)
            //     team.abandoned_carts_amount = amounts.get(team.id, 0)
            */
            return default;
        }

        protected async Task<CrmTeam> ComputeAssignmentEnabledInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_team.py) ---
            // def _compute_assignment_enabled(self):
            // assign_enabled = self.env['ir.config_parameter'].sudo().get_param('crm.lead.auto.assignment', False)
            // auto_assign_enabled = False
            // if assign_enabled:
            //     assign_cron = self.sudo().env.ref('crm.ir_cron_crm_lead_assign', raise_if_not_found=False)
            //     auto_assign_enabled = assign_cron.active if assign_cron else False
            // self.assignment_enabled = assign_enabled
            // self.assignment_auto_enabled = auto_assign_enabled
            */
            return default;
        }

        protected async Task<CrmTeam> ComputeAssignmentMaxInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_team.py) ---
            // def _compute_assignment_max(self):
            // for team in self:
            //     team.assignment_max = sum(member.assignment_max for member in team.crm_team_member_ids)
            */
            return default;
        }

        protected async Task<CrmTeam> ComputeDashboardButtonNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_team.py) ---
            // def _compute_dashboard_button_name(self):
            // super(Team, self)._compute_dashboard_button_name()
            // team_with_pipelines = self.filtered(lambda el: el.use_opportunities)
            // team_with_pipelines.update({'dashboard_button_name': _("Pipeline")})
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: crm_team.py) ---
            // def _compute_dashboard_button_name(self):
            // super(CrmTeam,self)._compute_dashboard_button_name()
            // if self._in_sale_scope():
            //     self.dashboard_button_name = _("Sales Analysis")
            --- ODOO METHOD SOURCE (MODULE: sale_crm, FILE: crm_team.py) ---
            // def _compute_dashboard_button_name(self):
            // super(CrmTeam, self)._compute_dashboard_button_name()
            // teams_with_opp = self.filtered(lambda team: team.use_opportunities)
            // if self._context.get('in_sales_app'):
            //     teams_with_opp.update({'dashboard_button_name': _("Sales Analysis")})
            --- ODOO METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py) ---
            // def _compute_dashboard_button_name(self):
            // """ Sets the adequate dashboard button name depending on the Sales Team's options
            // """
            // for team in self:
            //     team.dashboard_button_name = _("Big Pretty Button :)")
            */
            return default;
        }

        protected async Task<CrmTeam> ComputeDashboardGraphInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py) ---
            // def _compute_dashboard_graph(self):
            // for team in self:
            //     team.dashboard_graph_data = json.dumps(team._get_dashboard_graph_data())
            */
            return default;
        }

        protected async Task<CrmTeam> ComputeInvoicedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: crm_team.py) ---
            // def _compute_invoiced(self):
            // if not self:
            //     return
            // 
            // query = '''
            //     SELECT
            //         move.team_id AS team_id,
            //         SUM(move.amount_untaxed_signed) AS amount_untaxed_signed
            //     FROM account_move move
            //     WHERE move.move_type IN ('out_invoice', 'out_refund', 'out_receipt')
            //     AND move.payment_state IN ('in_payment', 'paid', 'reversed')
            //     AND move.state = 'posted'
            //     AND move.team_id IN %s
            //     AND move.date BETWEEN %s AND %s
            //     GROUP BY move.team_id
            // '''
            // today = fields.Date.today()
            // params = [tuple(self.ids), fields.Date.to_string(today.replace(day=1)), fields.Date.to_string(today)]
            // self._cr.execute(query, params)
            // 
            // data_map = dict((v[0], v[1]) for v in self._cr.fetchall())
            // for team in self:
            //     team.invoiced = data_map.get(team.id, 0.0)
            */
            return default;
        }

        protected async Task<CrmTeam> ComputeIsFavoriteInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py) ---
            // def _compute_is_favorite(self):
            // for team in self:
            //     team.is_favorite = self.env.user in team.favorite_user_ids
            */
            return default;
        }

        protected async Task<CrmTeam> ComputeIsMembershipMultiInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py) ---
            // def _compute_is_membership_multi(self):
            // multi_enabled = self.env['ir.config_parameter'].sudo().get_param('sales_team.membership_multi', False)
            // self.is_membership_multi = multi_enabled
            */
            return default;
        }

        protected async Task<CrmTeam> ComputeLeadAllAssignedMonthCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_team.py) ---
            // def _compute_lead_all_assigned_month_count(self):
            // for team in self:
            //     team.lead_all_assigned_month_count = sum(member.lead_month_count for member in team.crm_team_member_ids)
            //     team.lead_all_assigned_month_exceeded = team.lead_all_assigned_month_count > team.assignment_max
            */
            return default;
        }

        protected async Task<CrmTeam> ComputeLeadUnassignedCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_team.py) ---
            // def _compute_lead_unassigned_count(self):
            // leads_data = self.env['crm.lead']._read_group([
            //     ('team_id', 'in', self.ids),
            //     ('type', '=', 'lead'),
            //     ('user_id', '=', False),
            // ], ['team_id'], ['__count'])
            // counts = {team.id: count for team, count in leads_data}
            // for team in self:
            //     team.lead_unassigned_count = counts.get(team.id, 0)
            */
            return default;
        }

        protected async Task<CrmTeam> ComputeMemberCompanyIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py) ---
            // def _compute_member_company_ids(self):
            // """ Available companies for members. Either team company if set, either
            // any company if not set on team. """
            // all_companies = self.env['res.company'].search([])
            // for team in self:
            //     team.member_company_ids = team.company_id or all_companies
            */
            return default;
        }

        protected async Task<CrmTeam> ComputeMemberIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py) ---
            // def _compute_member_ids(self):
            // for team in self:
            //     team.member_ids = team.crm_team_member_ids.user_id
            */
            return default;
        }

        protected async Task<CrmTeam> ComputeMemberWarningInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py) ---
            // def _compute_member_warning(self):
            // """ Display a warning message to warn user they are about to archive
            // other memberships. Only valid in mono-membership mode and take into
            // account only active memberships as we may keep several archived
            // memberships. """
            // self.member_warning = False
            // if all(team.is_membership_multi for team in self):
            //     return
            // # done in a loop, but to be used in form view only -> not optimized
            // for team in self:
            //     member_warning = False
            //     other_memberships = self.env['crm.team.member'].search([
            //         ('crm_team_id', '!=', team._origin.id if team.ids else False),
            //         ('user_id', 'in', team.member_ids.ids)
            //     ])
            //     if other_memberships:
            //         member_warning = _("Adding %(user_names)s in this team will remove them from %(team_names)s.",
            //                            user_names=", ".join(other_memberships.mapped('user_id.name')),
            //                            team_names=", ".join(other_memberships.mapped('crm_team_id.name'))
            //                           )
            //     if member_warning:
            //         team.member_warning = member_warning + " " + _("Working in multiple teams? Activate the option under Configuration>Settings.")
            */
            return default;
        }

        protected async Task<CrmTeam> ComputeOpportunitiesDataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_team.py) ---
            // def _compute_opportunities_data(self):
            // opportunity_data = self.env['crm.lead']._read_group([
            //     ('team_id', 'in', self.ids),
            //     ('probability', '<', 100),
            //     ('type', '=', 'opportunity'),
            // ], ['team_id'], ['__count', 'expected_revenue:sum'])
            // counts_amounts = {team.id: (count, expected_revenue_sum) for team, count, expected_revenue_sum in opportunity_data}
            // for team in self:
            //     team.opportunities_count, team.opportunities_amount = counts_amounts.get(team.id, (0, 0))
            */
            return default;
        }

        protected async Task<CrmTeam> ComputeOpportunitiesOverdueDataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_team.py) ---
            // def _compute_opportunities_overdue_data(self):
            // opportunity_data = self.env['crm.lead']._read_group([
            //     ('team_id', 'in', self.ids),
            //     ('probability', '<', 100),
            //     ('type', '=', 'opportunity'),
            //     ('date_deadline', '<', fields.Date.to_string(fields.Datetime.now()))
            // ], ['team_id'], ['__count', 'expected_revenue:sum'])
            // counts_amounts = {team.id: (count, expected_revenue_sum) for team, count, expected_revenue_sum in opportunity_data}
            // for team in self:
            //     team.opportunities_overdue_count, team.opportunities_overdue_amount = counts_amounts.get(team.id, (0, 0))
            */
            return default;
        }

        protected async Task<CrmTeam> ComputePosOrderAmountTotalInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_sale, FILE: crm_team.py) ---
            // def _compute_pos_order_amount_total(self):
            // data = self.env['report.pos.order']._read_group([
            //     ('session_id.state', '=', 'opened'),
            //     ('config_id.crm_team_id', 'in', self.ids),
            // ], ['config_id'], ['price_total:sum'])
            // rg_results = {config.id: price_total_sum for config, price_total_sum in data}
            // for team in self:
            //     team.pos_order_amount_total = sum([
            //         rg_results.get(config.id, 0.0)
            //         for config in team.pos_config_ids
            //     ])
            */
            return default;
        }

        protected async Task<CrmTeam> ComputePosSessionsOpenCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_sale, FILE: crm_team.py) ---
            // def _compute_pos_sessions_open_count(self):
            // for team in self:
            //     team.pos_sessions_open_count = self.env['pos.session'].search_count([('config_id.crm_team_id', '=', team.id), ('state', '=', 'opened')])
            */
            return default;
        }

        protected async Task<CrmTeam> ComputeQuotationsToInvoiceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: crm_team.py) ---
            // def _compute_quotations_to_invoice(self):
            // query = self.env['sale.order']._where_calc([
            //     ('team_id', 'in', self.ids),
            //     ('state', 'in', ['draft', 'sent']),
            // ])
            // self.env['sale.order']._apply_ir_rules(query, 'read')
            // select_sql = SQL("""
            //     SELECT team_id, count(*), sum(amount_total /
            //         CASE COALESCE(currency_rate, 0)
            //         WHEN 0 THEN 1.0
            //         ELSE currency_rate
            //         END
            //     ) as amount_total
            //     FROM sale_order
            //     WHERE %s
            //     GROUP BY team_id
            // """, query.where_clause or SQL("TRUE"))
            // self.env.cr.execute(select_sql)
            // quotation_data = self.env.cr.dictfetchall()
            // teams = self.browse()
            // for datum in quotation_data:
            //     team = self.browse(datum['team_id'])
            //     team.quotations_amount = datum['amount_total']
            //     team.quotations_count = datum['count']
            //     teams |= team
            // remaining = (self - teams)
            // remaining.quotations_amount = 0
            // remaining.quotations_count = 0
            */
            return default;
        }

        protected async Task<CrmTeam> ComputeSaleOrderCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: crm_team.py) ---
            // def _compute_sale_order_count(self):
            // sale_order_data = self.env['sale.order']._read_group([
            //     ('team_id', 'in', self.ids),
            //     ('state', '!=', 'cancel'),
            // ], ['team_id'], ['__count'])
            // data_map = {team.id: count for team, count in sale_order_data}
            // for team in self:
            //     team.sale_order_count = data_map.get(team.id, 0)
            */
            return default;
        }

        protected async Task<CrmTeam> ComputeSalesToInvoiceInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: crm_team.py) ---
            // def _compute_sales_to_invoice(self):
            // sale_order_data = self.env['sale.order']._read_group([
            //     ('team_id', 'in', self.ids),
            //     ('invoice_status','=','to invoice'),
            // ], ['team_id'], ['__count'])
            // data_map = {team.id: count for team, count in sale_order_data}
            // for team in self:
            //     team.sales_to_invoice_count = data_map.get(team.id,0.0)
            */
            return default;
        }

        protected async Task<CrmTeam> ConstrainsAssignmentDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_team.py) ---
            // def _constrains_assignment_domain(self):
            // for team in self:
            //     try:
            //         domain = literal_eval(team.assignment_domain or '[]')
            //         if domain:
            //             self.env['crm.lead'].search(domain, limit=1)
            //     except Exception:
            //         raise exceptions.ValidationError(_('Assignment domain for team %(team)s is incorrectly formatted', team=team.name))
            */
            return default;
        }

        protected async Task<CrmTeam> CronAssignLeadsInternalAsync(object force_quota, object creation_delta_days)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_team.py) ---
            // def _cron_assign_leads(self, force_quota=False, creation_delta_days=7):
            // """ Cron method assigning leads. Leads are allocated to all teams and
            // assigned to their members.
            // 
            // The cron is designed to run at least once a day or more.
            // A number of leads will be assigned each time depending on the daily leads
            // already assigned.
            // This allows the assignation process based on the cron to work on a daily basis
            // without allocating too much leads on members if the cron is executed multiple
            // times a day.
            // The daily quota of leads can be forcefully assigned with force_quota
            // (ignoring the daily leads already assigned).
            // 
            // See ``CrmTeam.action_assign_leads()`` and its sub methods for more
            // details about assign process.
            // 
            // """
            // self.env['crm.team'].search([
            //     '&', '|', ('use_leads', '=', True), ('use_opportunities', '=', True),
            //     ('assignment_optout', '=', False)
            // ])._action_assign_leads(force_quota=force_quota, creation_delta_days=creation_delta_days)
            // return True
            */
            return default;
        }

        protected async Task<object> ExtraSqlConditionsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_team.py) ---
            // def _extra_sql_conditions(self):
            // if self.use_opportunities:
            //     return SQL("type LIKE 'opportunity'")
            // return super(Team,self)._extra_sql_conditions()
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: crm_team.py) ---
            // def _extra_sql_conditions(self):
            // if self._in_sale_scope():
            //     return SQL("state = 'sale'")
            // return super()._extra_sql_conditions()
            --- ODOO METHOD SOURCE (MODULE: sale_crm, FILE: crm_team.py) ---
            // def _extra_sql_conditions(self):
            // if self.use_opportunities and self._context.get('in_sales_app'):
            //     return SQL("state = 'sale'")
            // return super(CrmTeam,self)._extra_sql_conditions()
            --- ODOO METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py) ---
            // def _extra_sql_conditions(self) -> SQL:
            // return SQL()
            */
            return default;
        }

        public async Task<CrmTeam> GetAbandonedCartsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_sale, FILE: crm_team.py) ---
            // def get_abandoned_carts(self):
            // self.ensure_one()
            // return {
            //     'name': _('Abandoned Carts'),
            //     'type': 'ir.actions.act_window',
            //     'view_mode': 'list,form',
            //     'domain': [('is_abandoned_cart', '=', True)],
            //     'search_view_id': [self.env.ref('sale.sale_order_view_search_inherit_sale').id],
            //     'context': {
            //         'search_default_team_id': self.id,
            //         'default_team_id': self.id,
            //         'search_default_recovery_email': 1,
            //         'create': False
            //     },
            //     'res_model': 'sale.order',
            //     'help': _('''<p class="o_view_nocontent_smiling_face">
            //                 You can find all abandoned carts here, i.e. the carts generated by your website's visitors from over an hour ago that haven't been confirmed yet.</p>
            //                 <p>You should send an email to the customers to encourage them!</p>
            //             '''),
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<CrmTeam> GetDashboardGraphDataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py) ---
            // def _get_dashboard_graph_data(self):
            // def get_week_name(start_date, locale):
            //     """ Generates a week name (string) from a datetime according to the locale:
            //         E.g.: locale    start_date (datetime)      return string
            //               "en_US"      November 16th           "16-22 Nov"
            //               "en_US"      December 28th           "28 Dec-3 Jan"
            //     """
            //     if (start_date + relativedelta(days=6)).month == start_date.month:
            //         short_name_from = format_date(start_date, 'd', locale=locale)
            //     else:
            //         short_name_from = format_date(start_date, 'd MMM', locale=locale)
            //     short_name_to = format_date(start_date + relativedelta(days=6), 'd MMM', locale=locale)
            //     return short_name_from + '-' + short_name_to
            // 
            // self.ensure_one()
            // values = []
            // today = fields.Date.from_string(fields.Date.context_today(self))
            // start_date, end_date = self._graph_get_dates(today)
            // graph_data = self._graph_data(start_date, end_date)
            // x_field = 'label'
            // y_field = 'value'
            // 
            // # generate all required x_fields and update the y_values where we have data for them
            // locale = self._context.get('lang') or 'en_US'
            // 
            // weeks_in_start_year = int(date(start_date.year, 12, 28).isocalendar()[1]) # This date is always in the last week of ISO years
            // week_count = (end_date.isocalendar()[1] - start_date.isocalendar()[1]) % weeks_in_start_year + 1
            // for week in range(week_count):
            //     short_name = get_week_name(start_date + relativedelta(days=7 * week), locale)
            //     values.append({x_field: short_name, y_field: 0, 'type': 'future' if week + 1 == week_count else 'past'})
            // 
            // for data_item in graph_data:
            //     index = int((data_item.get('x_value') - start_date.isocalendar()[1]) % weeks_in_start_year)
            //     values[index][y_field] = data_item.get('y_value')
            // 
            // [graph_title, graph_key] = self._graph_title_and_key()
            // color = '#875A7B' if '+e' in version else '#7c7bad'
            // 
            // # If no actual data available, show some sample data
            // if not graph_data:
            //     graph_key = _('Sample data')
            //     for value in values:
            //         value['type'] = 'o_sample_data'
            //         # we use unrealistic values for the sample data
            //         value['value'] = random.randint(0, 20)
            // return [{'values': values, 'area': True, 'title': graph_title, 'key': graph_key, 'color': color}]
            */
            return default;
        }

        protected async Task<CrmTeam> GetDefaultFavoriteUserIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py) ---
            // def _get_default_favorite_user_ids(self):
            // return [(6, 0, [self.env.uid])]
            */
            return default;
        }

        protected async Task<CrmTeam> GetDefaultTeamIdInternalAsync(Guid user_id, object domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py) ---
            // def _get_default_team_id(self, user_id=False, domain=False):
            // """ Compute default team id for sales related documents. Note that this
            // method is not called by default_get as it takes some additional
            // parameters and is meant to be called by other default methods.
            // 
            // Heuristic (when multiple match: take from default context value or first
            // sequence ordered)
            // 
            //   1- any of my teams (member OR responsible) matching domain, either from
            //      context or based on _order;
            //   2- any of my teams (member OR responsible), either from context or based
            //      on _order;
            //   3- default from context
            //   4- any team matching my company and domain (based on company rule)
            //   5- any team matching my company (based on company rule)
            // 
            // :param user_id: salesperson to target, fallback on env.uid;
            // :domain: optional domain to filter teams (like use_lead = True);
            // """
            // if not user_id:
            //     user = self.env.user
            // else:
            //     user = self.env['res.users'].sudo().browse(user_id)
            // default_team = self.env['crm.team'].browse(
            //     self.env.context['default_team_id']
            // ) if self.env.context.get('default_team_id') else self.env['crm.team']
            // valid_cids = [False] + [c for c in user.company_ids.ids if c in self.env.companies.ids]
            // 
            // # 1- find in user memberships - note that if current user in C1 searches
            // # for team belonging to a user in C1/C2 -> only results for C1 will be returned
            // team = self.env['crm.team']
            // teams = self.env['crm.team'].search([
            //     ('company_id', 'in', valid_cids),
            //      '|', ('user_id', '=', user.id), ('member_ids', 'in', [user.id])
            // ])
            // if teams and domain:
            //     filtered_teams = teams.filtered_domain(domain)
            //     if default_team and default_team in filtered_teams:
            //         team = default_team
            //     else:
            //         team = filtered_teams[:1]
            // 
            // # 2- any of my teams
            // if not team:
            //     if default_team and default_team in teams:
            //         team = default_team
            //     else:
            //         team = teams[:1]
            // 
            // # 3- default: context
            // if not team and default_team:
            //     team = default_team
            // 
            // if not team:
            //     teams = self.env['crm.team'].search([('company_id', 'in', valid_cids)])
            //     # 4- default: based on company rule, first one matching domain
            //     if teams and domain:
            //         team = teams.filtered_domain(domain)[:1]
            //     # 5- default: based on company rule, first one
            //     if not team:
            //         team = teams[:1]
            // 
            // return team
            */
            return default;
        }

        protected async Task<CrmTeam> GetLeadToAssignDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_team.py) ---
            // def _get_lead_to_assign_domain(self):
            // return [
            //     ('user_id', '=', False),
            //     ('date_open', '=', False),
            //     ('team_id', 'in', self.ids),
            // ]
            */
            return default;
        }

        protected async Task<CrmTeam> GraphDataInternalAsync(object start_date, object end_date)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py) ---
            // def _graph_data(self, start_date, end_date):
            // """ return format should be an iterable of dicts that contain {'x_value': ..., 'y_value': ...}
            //     x_values should be weeks.
            //     y_values are floats.
            // """
            // # apply rules
            // extra_conditions = self._extra_sql_conditions() or SQL("TRUE")
            // dashboard_graph_model = self._graph_get_model()
            // GraphModel = self.env[dashboard_graph_model]
            // where_query = GraphModel._where_calc([])
            // GraphModel._apply_ir_rules(where_query, 'read')
            // if where_clause := where_query.where_clause:
            //     extra_conditions = SQL("%s AND (%s)", extra_conditions, where_clause)
            // 
            // sql = SQL(
            //     """
            //     SELECT %(x_query)s as x_value, %(y_query)s as y_value
            //     FROM %(table)s
            //     WHERE team_id = %(team_id)s
            //         AND DATE(%(date_column)s) >= %(start_date)s
            //         AND DATE(%(date_column)s) <= %(end_date)s
            //         AND %(extra_conditions)s
            //     GROUP BY x_value
            //     """,
            //     x_query=self._graph_x_query(),
            //     y_query=self._graph_y_query(),
            //     table=self._graph_get_table(GraphModel),
            //     team_id=self.id,
            //     date_column=self._graph_date_column(),
            //     start_date=start_date,
            //     end_date=end_date,
            //     extra_conditions=extra_conditions,
            // )
            // 
            // self._cr.execute(sql)
            // return self.env.cr.dictfetchall()
            */
            return default;
        }

        protected async Task<object> GraphDateColumnInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_team.py) ---
            // def _graph_date_column(self):
            // if self.use_opportunities:
            //     return SQL('create_date')
            // return super(Team,self)._graph_date_column()
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: crm_team.py) ---
            // def _graph_date_column(self):
            // if self._in_sale_scope():
            //     return SQL('date')
            // return super()._graph_date_column()
            --- ODOO METHOD SOURCE (MODULE: sale_crm, FILE: crm_team.py) ---
            // def _graph_date_column(self):
            // if self.use_opportunities and self._context.get('in_sales_app'):
            //     return SQL('date')
            // return super(CrmTeam,self)._graph_date_column()
            --- ODOO METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py) ---
            // def _graph_date_column(self) -> SQL:
            // return SQL('create_date')
            */
            return default;
        }

        protected async Task<CrmTeam> GraphGetDatesInternalAsync(object today)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py) ---
            // def _graph_get_dates(self, today):
            // """ return a coherent start and end date for the dashboard graph covering a month period grouped by week.
            // """
            // start_date = today - relativedelta(months=1)
            // # we take the start of the following week if we group by week
            // # (to avoid having twice the same week from different month)
            // start_date += relativedelta(days=8 - start_date.isocalendar()[2])
            // return [start_date, today]
            */
            return default;
        }

        protected async Task<string> GraphGetModelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_team.py) ---
            // def _graph_get_model(self):
            // if self.use_opportunities:
            //     return 'crm.lead'
            // return super(Team,self)._graph_get_model()
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: crm_team.py) ---
            // def _graph_get_model(self):
            // if self._in_sale_scope():
            //     return 'sale.report'
            // return super()._graph_get_model()
            --- ODOO METHOD SOURCE (MODULE: sale_crm, FILE: crm_team.py) ---
            // def _graph_get_model(self):
            // if self.use_opportunities and self._context.get('in_sales_app') :
            //     return 'sale.report'
            // return super(CrmTeam,self)._graph_get_model()
            --- ODOO METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py) ---
            // def _graph_get_model(self) -> str:
            // """ skeleton function defined here because it'll be called by crm and/or sale
            // """
            // raise UserError(_('Undefined graph model for Sales Team: %s', self.name))
            */
            return default;
        }

        protected async Task<object> GraphGetTableInternalAsync(object GraphModel)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: crm_team.py) ---
            // def _graph_get_table(self, GraphModel):
            // if self._in_sale_scope():
            //     # For a team not shared between company, we make sure the amounts are expressed
            //     # in the currency of the team company and not converted to the current company currency,
            //     # as the amounts of the sale report are converted in the currency
            //     # of the current company (for multi-company reporting, see #83550)
            //     GraphModel = GraphModel.with_company(self.company_id)
            //     return SQL(f"({GraphModel._table_query}) AS {GraphModel._table}")
            // return super()._graph_get_table(GraphModel)
            --- ODOO METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py) ---
            // def _graph_get_table(self, GraphModel) -> SQL:
            // return SQL(GraphModel._table)
            */
            return default;
        }

        protected async Task<CrmTeam> GraphTitleAndKeyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_team.py) ---
            // def _graph_title_and_key(self):
            // if self.use_opportunities:
            //     return ['', _('New Opportunities')] # no more title
            // return super(Team, self)._graph_title_and_key()
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: crm_team.py) ---
            // def _graph_title_and_key(self):
            // if self._in_sale_scope():
            //     return ['', _('Sales: Untaxed Total')] # no more title
            // return super()._graph_title_and_key()
            --- ODOO METHOD SOURCE (MODULE: sale_crm, FILE: crm_team.py) ---
            // def _graph_title_and_key(self):
            // if self.use_opportunities and self._context.get('in_sales_app'):
            //     return ['', _('Sales: Untaxed Total')]
            // return super(CrmTeam,self)._graph_title_and_key()
            --- ODOO METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py) ---
            // def _graph_title_and_key(self):
            // """ Returns an array containing the appropriate graph title and key respectively.
            // 
            //     The key is for lineCharts, to have the on-hover label.
            // """
            // return ['', '']
            */
            return default;
        }

        protected async Task<object> GraphXQueryInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py) ---
            // def _graph_x_query(self) -> SQL:
            // return SQL('EXTRACT(WEEK FROM %s)', self._graph_date_column())
            */
            return default;
        }

        protected async Task<object> GraphYQueryInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_team.py) ---
            // def _graph_y_query(self):
            // if self.use_opportunities:
            //     return SQL('count(*)')
            // return super(Team,self)._graph_y_query()
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: crm_team.py) ---
            // def _graph_y_query(self):
            // if self._in_sale_scope():
            //     return SQL('SUM(price_subtotal)')
            // return super()._graph_y_query()
            --- ODOO METHOD SOURCE (MODULE: sale_crm, FILE: crm_team.py) ---
            // def _graph_y_query(self):
            // if self.use_opportunities and self._context.get('in_sales_app'):
            //     return SQL('SUM(price_subtotal)')
            // return super(CrmTeam,self)._graph_y_query()
            --- ODOO METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py) ---
            // def _graph_y_query(self) -> SQL:
            // raise UserError(_('Undefined graph model for Sales Team: %s', self.name))
            */
            return default;
        }

        protected async Task<CrmTeam> InSaleScopeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: crm_team.py) ---
            // def _in_sale_scope(self):
            // return self.env.context.get('in_sales_app')
            */
            return default;
        }

        protected async Task<CrmTeam> InverseIsFavoriteInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py) ---
            // def _inverse_is_favorite(self):
            // sudoed_self = self.sudo()
            // to_fav = sudoed_self.filtered(lambda team: self.env.user not in team.favorite_user_ids)
            // to_fav.write({'favorite_user_ids': [(4, self.env.uid)]})
            // (sudoed_self - to_fav).write({'favorite_user_ids': [(3, self.env.uid)]})
            // return True
            */
            return default;
        }

        protected async Task<CrmTeam> InverseMemberIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py) ---
            // def _inverse_member_ids(self):
            // for team in self:
            //     # pre-save value to avoid having _compute_member_ids interfering
            //     # while building membership status
            //     memberships = team.crm_team_member_ids
            //     users_current = team.member_ids
            //     users_new = users_current - memberships.user_id
            // 
            //     # add missing memberships
            //     self.env['crm.team.member'].create([{'crm_team_id': team.id, 'user_id': user.id} for user in users_new])
            // 
            //     # activate or deactivate other memberships depending on members
            //     for membership in memberships:
            //         membership.active = membership.user_id in users_current
            */
            return default;
        }

        protected async Task<CrmTeam> OnchangeUseLeadsOpportunitiesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_team.py) ---
            // def _onchange_use_leads_opportunities(self):
            // if not self.use_leads and not self.use_opportunities:
            //     self.alias_name = False
            */
            return default;
        }

        public async Task<CrmTeam> OpportunityForecastAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_team.py) ---
            // def action_opportunity_forecast(self):
            // action = self.env['ir.actions.actions']._for_xml_id('crm.crm_lead_action_forecast')
            // return self._action_update_to_pipeline(action)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<CrmTeam> PrimaryChannelButtonAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_team.py) ---
            // def action_primary_channel_button(self):
            // self.ensure_one()
            // if self.use_opportunities:
            //     action = self.env['ir.actions.actions']._for_xml_id('crm.crm_case_form_view_salesteams_opportunity')
            //     rcontext = {
            //         'team': self,
            //     }
            //     action['help'] = self.env['ir.ui.view']._render_template('crm.crm_action_helper', values=rcontext)
            //     return action
            // return super(Team,self).action_primary_channel_button()
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: crm_team.py) ---
            // def action_primary_channel_button(self):
            // if self._in_sale_scope():
            //     return self.env["ir.actions.actions"]._for_xml_id("sale.action_order_report_so_salesteam")
            // return super().action_primary_channel_button()
            --- ODOO METHOD SOURCE (MODULE: sale_crm, FILE: crm_team.py) ---
            // def action_primary_channel_button(self):
            // if self._context.get('in_sales_app') and self.use_opportunities:
            //     return self.env["ir.actions.actions"]._for_xml_id("sale.action_order_report_so_salesteam")
            // return super(CrmTeam,self).action_primary_channel_button()
            --- ODOO METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py) ---
            // def action_primary_channel_button(self):
            // """ Skeleton function to be overloaded It will return the adequate action
            // depending on the Sales Team's options. """
            // return False
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<CrmTeam> SearchMemberIdsInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py) ---
            // def _search_member_ids(self, operator, value):
            // return [('crm_team_member_ids.user_id', operator, value)]
            */
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_team.py) ---
            // def unlink(self):
            // """ When unlinking, concatenate ``crm.lead.scoring.frequency`` linked to
            // the team into "no team" statistics. """
            // frequencies = self.env['crm.lead.scoring.frequency'].search([('team_id', 'in', self.ids)])
            // if frequencies:
            //     existing_noteam = self.env['crm.lead.scoring.frequency'].sudo().search([
            //         ('team_id', '=', False),
            //         ('variable', 'in', frequencies.mapped('variable'))
            //     ])
            //     for frequency in frequencies:
            //         # skip void-like values
            //         if float_compare(frequency.won_count, 0.1, 2) != 1 and float_compare(frequency.lost_count, 0.1, 2) != 1:
            //             continue
            // 
            //         match = existing_noteam.filtered(lambda frequ_nt: frequ_nt.variable == frequency.variable and frequ_nt.value == frequency.value)
            //         if match:
            //             # remove extra .1 that may exist in db as those are artifacts of initializing
            //             # frequency table. Final value of 0 will be set to 0.1.
            //             exist_won_count = float_round(match.won_count, precision_digits=0, rounding_method='HALF-UP')
            //             exist_lost_count = float_round(match.lost_count, precision_digits=0, rounding_method='HALF-UP')
            //             add_won_count = float_round(frequency.won_count, precision_digits=0, rounding_method='HALF-UP')
            //             add_lost_count = float_round(frequency.lost_count, precision_digits=0, rounding_method='HALF-UP')
            //             new_won_count = exist_won_count + add_won_count
            //             new_lost_count = exist_lost_count + add_lost_count
            //             match.won_count = new_won_count if float_compare(new_won_count, 0.1, 2) == 1 else 0.1
            //             match.lost_count = new_lost_count if float_compare(new_lost_count, 0.1, 2) == 1 else 0.1
            //         else:
            //             existing_noteam += self.env['crm.lead.scoring.frequency'].sudo().create({
            //                 'lost_count': frequency.lost_count if float_compare(frequency.lost_count, 0.1, 2) == 1 else 0.1,
            //                 'team_id': False,
            //                 'value': frequency.value,
            //                 'variable': frequency.variable,
            //                 'won_count': frequency.won_count if float_compare(frequency.won_count, 0.1, 2) == 1 else 0.1,
            //             })
            // return super(Team, self).unlink()
            */
            return await base.UnlinkAsync(ids);
        }

        protected async Task<CrmTeam> UnlinkExceptDefaultInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py) ---
            // def _unlink_except_default(self):
            // default_teams = [
            //     self.env.ref('sales_team.salesteam_website_sales'),
            //     self.env.ref('sales_team.pos_sales_team'),
            // ]
            // for team in self:
            //     if team in default_teams:
            //         raise UserError(_('Cannot delete default team "%s"', team.name))
            */
            return default;
        }

        protected async Task<CrmTeam> UnlinkExceptUsedForSalesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: crm_team.py) ---
            // def _unlink_except_used_for_sales(self):
            // """ If more than 5 active SOs, we consider this team to be actively used.
            // 5 is some random guess based on "user testing", aka more than testing
            // CRM feature and less than use it in real life use cases. """
            // SO_COUNT_TRIGGER = 5
            // for team in self:
            //     if team.sale_order_count >= SO_COUNT_TRIGGER:
            //         raise UserError(
            //             _('Team %(team_name)s has %(sale_order_count)s active sale orders. Consider cancelling them or archiving the team instead.',
            //               team_name=team.name,
            //               sale_order_count=team.sale_order_count
            //               ))
            */
            return default;
        }

        public async Task<CrmTeam> UpdateInvoicedTargetAsync(Guid id, CrmTeamUpdateInvoicedTargetRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: crm_team.py) ---
            // def update_invoiced_target(self, value):
            // return self.write({'invoiced_target': round(float(value or 0))})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, CrmTeam entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_team.py) ---
            // def write(self, vals):
            // result = super(Team, self).write(vals)
            // if 'use_leads' in vals or 'use_opportunities' in vals:
            //     for team in self:
            //         alias_vals = team._alias_get_creation_values()
            //         team.write({
            //             'alias_name': alias_vals.get('alias_name', team.alias_name),
            //             'alias_defaults': alias_vals.get('alias_defaults'),
            //         })
            // return result
            --- ODOO METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py) ---
            // def write(self, values):
            // res = super(CrmTeam, self).write(values)
            // # manually launch company sanity check
            // if values.get('company_id'):
            //     self.crm_team_member_ids._check_company(fnames=['crm_team_id'])
            // 
            // if values.get('member_ids'):
            //     self._add_members_to_favorites()
            // return res
            */
            return await base.WriteAsync(ids, entity, fields);
        }

        public async Task<CrmTeam> YourPipelineAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_team.py) ---
            // def action_your_pipeline(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("crm.crm_lead_action_pipeline")
            // return self._action_update_to_pipeline(action)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}