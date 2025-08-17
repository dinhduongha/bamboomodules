using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Domain.Shared.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("mail", Depends = new[] { "base", "base_setup", "bus", "web_tour", "html_editor" })]
    public class MailAliasMixinAppService : ApplicationService, IMailAliasMixinAppService
    {

        public MailAliasMixinAppService() 
        {

        }

        public async Task<TEntity> ActionAssignLeadsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_quota, object creation_delta_days) where TEntity : IEntity<Guid>, IMailAliasMixinable
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

        public async Task<TEntity> ActionAssignLeadsLogsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object teams_data, object members_data) where TEntity : IEntity<Guid>, IMailAliasMixinable
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

        public async Task<TEntity> ActionLoadRecruitmentScenarioInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _action_load_recruitment_scenario(self):
            // 
            // convert_file(
            //     self.sudo().env,
            //     "hr_recruitment",
            //     "data/scenarios/hr_recruitment_scenario.xml",
            //     None,
            //     mode="init",
            //     kind="data",
            // )
            // 
            // return {
            //     "type": "ir.actions.client",
            //     "tag": "reload",
            // }
            */
            return default;
        }

        public async Task<TEntity> ActionUpdateToPipelineInternalAsync<TEntity>(IEnumerable<TEntity> entities, object action) where TEntity : IEntity<Guid>, IMailAliasMixinable
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

        public async Task<TEntity> AddCollaboratorsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partners, object limited_access) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _add_collaborators(self, partners, limited_access=False):
            // self.ensure_one()
            // new_collaborators = self._get_new_collaborators(partners)
            // if not new_collaborators:
            //     # Then we have nothing to do
            //     return
            // self.write({'collaborator_ids': [
            //     Command.create({
            //         'partner_id': collaborator.id,
            //         'limited_access': limited_access,
            //     }) for collaborator in new_collaborators],
            // })
            */
            return default;
        }

        public async Task<TEntity> AddFollowersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partners) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _add_followers(self, partners):
            // self.ensure_one()
            // self.message_subscribe(partners.ids)
            // 
            // dict_tasks_per_partner = {}
            // dict_partner_ids_to_subscribe_per_partner = {}
            // for task in self.task_ids:
            //     if task.partner_id in dict_tasks_per_partner:
            //         dict_tasks_per_partner[task.partner_id] |= task
            //     else:
            //         partner_ids_to_subscribe = [
            //             partner.id for partner in partners
            //             if partner == task.partner_id or partner in task.partner_id.child_ids
            //         ]
            //         if partner_ids_to_subscribe:
            //             dict_tasks_per_partner[task.partner_id] = task
            //             dict_partner_ids_to_subscribe_per_partner[task.partner_id] = partner_ids_to_subscribe
            // for partner, tasks in dict_tasks_per_partner.items():
            //     tasks.message_subscribe(dict_partner_ids_to_subscribe_per_partner[partner])
            */
            return default;
        }

        public async Task<TEntity> AddMembersToFavoritesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py) ---
            // def _add_members_to_favorites(self):
            // for team in self:
            //     team.favorite_user_ids = [(4, member.id) for member in team.member_ids]
            */
            return default;
        }

        public async Task<TEntity> AddressIdDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _address_id_domain(self):
            // return ['|', '&', '&', ('type', '!=', 'contact'), ('type', '!=', 'private'),
            //         ('id', 'in', self.sudo().env.companies.partner_id.child_ids.ids),
            //         ('id', 'in', self.sudo().env.companies.partner_id.ids)]
            */
            return default;
        }

        public async Task<TEntity> AliasGetCreationValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
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
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _alias_get_creation_values(self):
            // values = super()._alias_get_creation_values()
            // values['alias_model_id'] = self.env['ir.model']._get('hr.applicant').id
            // if self.id:
            //     values['alias_defaults'] = defaults = ast.literal_eval(self.alias_defaults or "{}")
            //     defaults.update({
            //         'job_id': self.id,
            //         'department_id': self.department_id.id,
            //         'company_id': self.department_id.company_id.id if self.department_id else self.company_id.id,
            //         'user_id': self.user_id.id,
            //     })
            // return values
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def _alias_get_creation_values(self):
            // """Return the default values for the automatically created alias."""
            // values = super(MailGroup, self)._alias_get_creation_values()
            // values['alias_model_id'] = self.env['ir.model']._get('mail.group').id
            // values['alias_force_thread_id'] = self.id
            // values['alias_defaults'] = literal_eval(self.alias_defaults or '{}')
            // return values
            --- ODOO METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py) ---
            // def _alias_get_creation_values(self):
            // values = super(MaintenanceEquipmentCategory, self)._alias_get_creation_values()
            // values['alias_model_id'] = self.env['ir.model']._get('maintenance.request').id
            // if self.id:
            //     values['alias_defaults'] = defaults = ast.literal_eval(self.alias_defaults or "{}")
            //     defaults['category_id'] = self.id
            // return values
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _alias_get_creation_values(self):
            // values = super(Project, self)._alias_get_creation_values()
            // values['alias_model_id'] = self.env['ir.model']._get('project.task').id
            // if self.id:
            //     values['alias_defaults'] = defaults = ast.literal_eval(self.alias_defaults or "{}")
            //     defaults['project_id'] = self.id
            // return values
            --- ODOO METHOD SOURCE (MODULE: test_mail, FILE: test_mail_models.py) ---
            // def _alias_get_creation_values(self):
            // values = super(MailTestGatewayGroups, self)._alias_get_creation_values()
            // values['alias_model_id'] = self.env['ir.model']._get('mail.test.gateway.groups').id
            // if self.id:
            //     values['alias_force_thread_id'] = self.id
            //     values['alias_parent_thread_id'] = self.id
            // return values
            --- ODOO METHOD SOURCE (MODULE: test_mail, FILE: test_mail_models.py) ---
            // def _alias_get_creation_values(self):
            // values = super()._alias_get_creation_values()
            // values['alias_model_id'] = self.env['ir.model']._get('mail.test.ticket').id
            // values['alias_force_thread_id'] = False
            // if self.id:
            //     values['alias_defaults'] = defaults = ast.literal_eval(self.alias_defaults or "{}")
            //     defaults['container_id'] = self.id
            // return values
            */
            return default;
        }

        public async Task<TEntity> AliasGetErrorInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object message_dict, object @alias) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def _alias_get_error(self, message, message_dict, alias):
            // """ Checks for access errors related to sending email to the mailing list.
            // Returns None if the mailing list is public or if no error cases are detected. """
            // self.ensure_one()
            // 
            // # Error Case: Selected group of users, but no user found for that email
            // email = email_normalize(message_dict.get('email_from', ''))
            // email_has_access = self.search_count([('id', '=', self.id), ('access_group_id.users.email_normalized', '=', email)])
            // if self.access_mode == 'groups' and not email_has_access:
            //     return AliasError('error_mail_group_members_restricted',
            //                           _('Only selected groups of users can send email to the mailing list.'))
            // 
            // # Error Case: Access for members, but no member found for that email
            // elif self.access_mode == 'members' and not self._find_member(message_dict.get('email_from')):
            //     return AliasError('error_mail_group_members_restricted',
            //                           _('Only members can send email to the mailing list.'))
            // 
            // return None
            */
            return default;
        }

        public async Task<TEntity> AllocateLeadsDeduplicateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object leads, object duplicates_cache) where TEntity : IEntity<Guid>, IMailAliasMixinable
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

        public async Task<TEntity> AllocateLeadsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object creation_delta_days) where TEntity : IEntity<Guid>, IMailAliasMixinable
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

        public async Task<TEntity> AssignAndConvertLeadsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_quota) where TEntity : IEntity<Guid>, IMailAliasMixinable
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

        public async Task<TEntity> AssignLeadsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
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
            return default;
        }

        public async Task<TEntity> ChangePrivacyVisibilityInternalAsync<TEntity>(IEnumerable<TEntity> entities, object new_visibility) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _change_privacy_visibility(self, new_visibility):
            // """
            // Unsubscribe non-internal users from the project and tasks if the project privacy visibility
            // goes from 'portal' to a different value.
            // If the privacy visibility is set to 'portal', subscribe back project and tasks partners.
            // """
            // for project in self:
            //     if project.privacy_visibility == new_visibility:
            //         continue
            //     if new_visibility == 'portal':
            //         project.message_subscribe(partner_ids=project.partner_id.ids)
            //         for task in project.task_ids.filtered('partner_id'):
            //             task.message_subscribe(partner_ids=task.partner_id.ids)
            //     elif project.privacy_visibility == 'portal':
            //         portal_users = project.message_partner_ids.user_ids.filtered('share')
            //         project.message_unsubscribe(partner_ids=portal_users.partner_id.ids)
            //         project.tasks._unsubscribe_portal_users()
            //         # revoke access_token since the project and its tasks are no longer accessible for portal/public users
            //         project.tasks.access_token = ''
            //         project.access_token = ''
            */
            return default;
        }

        public async Task<TEntity> CheckAccessModeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def _check_access_mode(self):
            // if any(group.access_mode == 'groups' and not group.access_group_id for group in self):
            //     raise ValidationError(_('The "Authorized Group" is missing.'))
            */
            return default;
        }

        public async Task<TEntity> CheckAccountIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _check_account_id(self):
            // # Overriden from 'analytic.plan.fields.mixin'
            // pass
            */
            return default;
        }

        public async Task<TEntity> CheckModerationGuidelinesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def _check_moderation_guidelines(self):
            // if any(group.moderation_guidelines and not group.moderation_guidelines_msg for group in self):
            //     raise ValidationError(_('The guidelines description is missing.'))
            */
            return default;
        }

        public async Task<TEntity> CheckModerationNotifyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def _check_moderation_notify(self):
            // if any(group.moderation_notify and not group.moderation_notify_msg for group in self):
            //     raise ValidationError(_('The notification message is missing.'))
            */
            return default;
        }

        public async Task<TEntity> CheckModeratorEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def _check_moderator_email(self):
            // if any(not moderator.email for group in self for moderator in group.moderator_ids):
            //     raise ValidationError(_('Moderators must have an email address.'))
            */
            return default;
        }

        public async Task<TEntity> CheckModeratorExistenceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def _check_moderator_existence(self):
            // if any(not group.moderator_ids for group in self if group.moderation):
            //     raise ValidationError(_('Moderated group must have moderators.'))
            */
            return default;
        }

        public async Task<TEntity> CheckProjectSharingAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _check_project_sharing_access(self):
            // self.ensure_one()
            // if self.privacy_visibility != 'portal':
            //     return False
            // if self.env.user._is_portal():
            //     return self.env['project.collaborator'].search([('project_id', '=', self.sudo().id), ('partner_id', '=', self.env.user.partner_id.id)])
            // return self.env.user._is_internal()
            */
            return default;
        }

        public async Task<TEntity> CleanEmailBodyInternalAsync<TEntity>(IEnumerable<TEntity> entities, object body_html) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def _clean_email_body(self, body_html):
            // """When we receive an email, we want to clean it before storing it in the database."""
            // tree = lxml.html.fromstring(body_html or '')
            // # Remove the mailing footer
            // xpath_footer = ".//div[contains(@id, 'o_mg_message_footer')]"
            // for parent_footer in tree.xpath(xpath_footer + "/.."):
            //     for footer in parent_footer.xpath(xpath_footer):
            //         parent_footer.remove(footer)
            // 
            // return lxml.etree.tostring(tree, encoding='utf-8').decode()
            */
            return default;
        }

        public async Task<TEntity> CloseDialogAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def close_dialog(self):
            // return {'type': 'ir.actions.act_window_close'}
            */
            return default;
        }

        public async Task<TEntity> ComputeAbandonedCartsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
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

        public async Task<TEntity> ComputeAccessInstructionMessageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_access_instruction_message(self):
            // for project in self:
            //     if project.privacy_visibility == 'portal':
            //         project.access_instruction_message = _('Grant portal users access to your project by adding them as followers (the tasks of the project are not included). To grant access to tasks to a portal user, add them as followers for these tasks.')
            //     elif project.privacy_visibility == 'followers':
            //         project.access_instruction_message = _('Grant employees access to your project or tasks by adding them as followers. Employees automatically get access to the tasks they are assigned to.')
            //     else:
            //         project.access_instruction_message = ''
            */
            return default;
        }

        public async Task<TEntity> ComputeAccessUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_access_url(self):
            // super(Project, self)._compute_access_url()
            // for project in self:
            //     project.access_url = f'/my/projects/{project.id}'
            */
            return default;
        }

        public async Task<TEntity> ComputeAccessWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_access_warning(self):
            // super(Project, self)._compute_access_warning()
            // for project in self.filtered(lambda x: x.privacy_visibility != 'portal'):
            //     project.access_warning = _(
            //         "This project is currently restricted to \"Invited internal users\". The project's visibility will be changed to \"invited portal users and all internal users (public)\" in order to make it accessible to the recipients.")
            */
            return default;
        }

        public async Task<TEntity> ComputeActivitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _compute_activities(self):
            // self.env.cr.execute("""
            //     SELECT
            //         app.job_id,
            //         COUNT(*) AS act_count,
            //         CASE
            //             WHEN %(today)s::date - act.date_deadline::date = 0 THEN 'today'
            //             WHEN %(today)s::date - act.date_deadline::date > 0 THEN 'overdue'
            //         END AS act_state
            //      FROM mail_activity act
            //      JOIN hr_applicant app ON app.id = act.res_id
            //      JOIN hr_recruitment_stage sta ON app.stage_id = sta.id
            //     WHERE act.user_id = %(user_id)s AND act.res_model = 'hr.applicant'
            //       AND act.date_deadline <= %(today)s::date AND app.active
            //       AND app.job_id IN %(job_ids)s
            //       AND sta.hired_stage IS NOT TRUE
            //     GROUP BY app.job_id, act_state
            // """, {
            //     'today': fields.Date.context_today(self),
            //     'user_id': self.env.uid,
            //     'job_ids': tuple(self.ids),
            // })
            // job_activities = defaultdict(dict)
            // for activity in self.env.cr.dictfetchall():
            //     job_activities[activity['job_id']][activity['act_state']] = activity['act_count']
            // for job in self:
            //     job.activities_overdue = job_activities[job.id].get('overdue', 0)
            //     job.activities_today = job_activities[job.id].get('today', 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeAllApplicationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _compute_all_application_count(self):
            // read_group_result = self.env['hr.applicant'].with_context(active_test=False)._read_group([
            //     ('job_id', 'in', self.ids),
            //     '|',
            //         ('active', '=', True),
            //         '&',
            //         ('active', '=', False), ('refuse_reason_id', '!=', False),
            // ], ['job_id'], ['__count'])
            // result = {job.id: count for job, count in read_group_result}
            // for job in self:
            //     job.all_application_count = result.get(job.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicantHiredInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _compute_applicant_hired(self):
            // hired_stages = self.env['hr.recruitment.stage'].search([('hired_stage', '=', True)])
            // hired_data = self.env['hr.applicant']._read_group([
            //     ('job_id', 'in', self.ids),
            //     ('stage_id', 'in', hired_stages.ids),
            // ], ['job_id'], ['__count'])
            // job_hires = {job.id: count for job, count in hired_data}
            // for job in self:
            //     job.applicant_hired = job_hires.get(job.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeApplicationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _compute_application_count(self):
            // read_group_result = self.env['hr.applicant']._read_group([('job_id', 'in', self.ids)], ['job_id'], ['__count'])
            // result = {job.id: count for job, count in read_group_result}
            // for job in self:
            //     job.application_count = result.get(job.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeAssignmentEnabledInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
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

        public async Task<TEntity> ComputeAssignmentMaxInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_team.py) ---
            // def _compute_assignment_max(self):
            // for team in self:
            //     team.assignment_max = sum(member.assignment_max for member in team.crm_team_member_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeCanManageGroupInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def _compute_can_manage_group(self):
            // is_admin = self.env.user.has_group('mail_group.group_mail_group_manager') or self.env.su
            // for group in self:
            //     group.can_manage_group = is_admin or group.is_moderator
            */
            return default;
        }

        public async Task<TEntity> ComputeClosedTaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_closed_task_count(self):
            // self.__compute_task_count(
            //     count_field='closed_task_count',
            //     additional_domain=[('state', 'in', [*CLOSED_STATES])],
            // )
            */
            return default;
        }

        public async Task<TEntity> ComputeCollaboratorCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_collaborator_count(self):
            // project_sharings = self.filtered(lambda project: project.privacy_visibility == 'portal')
            // collaborator_read_group = self.env['project.collaborator']._read_group(
            //     [('project_id', 'in', project_sharings.ids)],
            //     ['project_id'],
            //     ['__count'],
            // )
            // collaborator_count_by_project = {project.id: count for project, count in collaborator_read_group}
            // for project in self:
            //     project.collaborator_count = collaborator_count_by_project.get(project.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_company_id(self):
            // for project in self:
            //     # if a new restriction is put on the account or the customer, the restriction on the project is updated.
            //     if project.account_id.company_id:
            //         project.company_id = project.account_id.company_id
            //     if not project.company_id and project.partner_id.company_id:
            //         project.company_id = project.partner_id.company_id
            */
            return default;
        }

        public async Task<TEntity> ComputeCurrencyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_currency_id(self):
            // default_currency_id = self.env.company.currency_id
            // for project in self:
            //     project.currency_id = project.company_id.currency_id or default_currency_id
            */
            return default;
        }

        public async Task<TEntity> ComputeDashboardButtonNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_team.py) ---
            // def _compute_dashboard_button_name(self):
            // super(Team, self)._compute_dashboard_button_name()
            // team_with_pipelines = self.filtered(lambda el: el.use_opportunities)
            // team_with_pipelines.update({'dashboard_button_name': _("Pipeline")})
            */
            return default;
        }

        public async Task<TEntity> ComputeDashboardGraphInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py) ---
            // def _compute_dashboard_graph(self):
            // for team in self:
            //     team.dashboard_graph_data = json.dumps(team._get_dashboard_graph_data())
            */
            return default;
        }

        public async Task<TEntity> ComputeDocumentIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _compute_document_ids(self):
            // applicants = self.mapped('application_ids').filtered(lambda self: not self.employee_id)
            // app_to_job = dict((applicant.id, applicant.job_id.id) for applicant in applicants)
            // attachments = self.env['ir.attachment'].search([
            //     '|',
            //     '&', ('res_model', '=', 'hr.job'), ('res_id', 'in', self.ids),
            //     '&', ('res_model', '=', 'hr.applicant'), ('res_id', 'in', applicants.ids)])
            // result = dict.fromkeys(self.ids, self.env['ir.attachment'])
            // for attachment in attachments:
            //     if attachment.res_model == 'hr.applicant':
            //         result[app_to_job[attachment.res_id]] |= attachment
            //     else:
            //         result[attachment.res_id] |= attachment
            // 
            // for job in self:
            //     job.document_ids = result.get(job.id, False)
            //     job.documents_count = len(job.document_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeEmployeesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_job.py) ---
            // def _compute_employees(self):
            // employee_data = self.env['hr.employee']._read_group([('job_id', 'in', self.ids)], ['job_id'], ['__count'])
            // result = {job.id: count for job, count in employee_data}
            // for job in self:
            //     job.no_of_employee = result.get(job.id, 0)
            //     job.expected_employees = result.get(job.id, 0) + job.no_of_recruitment
            */
            return default;
        }

        public async Task<TEntity> ComputeEquipmentCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py) ---
            // def _compute_equipment_count(self):
            // equipment_data = self.env['maintenance.equipment']._read_group([('category_id', 'in', self.ids)], ['category_id'], ['__count'])
            // mapped_data = {category.id: count for category, count in equipment_data}
            // for category in self:
            //     category.equipment_count = mapped_data.get(category.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeExtendedInterviewerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _compute_extended_interviewer_ids(self):
            // # Use SUPERUSER_ID as the search_read is protected in hr_referral
            // results_raw = self.env['hr.applicant'].with_user(SUPERUSER_ID).search_read([
            //     ('job_id', 'in', self.ids),
            //     ('interviewer_ids', '!=', False)
            // ], ['interviewer_ids', 'job_id'])
            // interviewers_by_job = defaultdict(set)
            // for result_raw in results_raw:
            //     interviewers_by_job[result_raw['job_id'][0]] |= set(result_raw['interviewer_ids'])
            // for job in self:
            //     job.extended_interviewer_ids = [(6, 0, list(interviewers_by_job[job.id]))]
            */
            return default;
        }

        public async Task<TEntity> ComputeFoldInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py) ---
            // def _compute_fold(self):
            // # fix mutual dependency: 'fold' depends on 'equipment_count', which is
            // # computed with a read_group(), which retrieves 'fold'!
            // self.fold = False
            // for category in self:
            //     category.fold = False if category.equipment_count else True
            */
            return default;
        }

        public async Task<TEntity> ComputeFullUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py) ---
            // def _compute_full_url(self):
            // for job in self:
            //     job.full_url = url_join(job.get_base_url(), (job.website_url or '/jobs'))
            */
            return default;
        }

        public async Task<TEntity> ComputeInvoicedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
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

        public async Task<TEntity> ComputeIsFavoriteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _compute_is_favorite(self):
            // for job in self:
            //     job.is_favorite = self.env.user in job.favorite_user_ids
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_is_favorite(self):
            // for project in self:
            //     project.is_favorite = self.env.user in project.favorite_user_ids
            */
            return default;
        }

        public async Task<TEntity> ComputeIsMemberInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def _compute_is_member(self):
            // if not self or self.env.user._is_public():
            //     self.is_member = False
            //     return
            // 
            // # SUDO to bypass the ACL rules
            // members = self.env['mail.group.member'].sudo().search([
            //     ('partner_id', '=', self.env.user.partner_id.id),
            //     ('mail_group_id', 'in', self.ids),
            // ])
            // is_member = {member.mail_group_id.id: True for member in members}
            // 
            // for group in self:
            //     group.is_member = is_member.get(group.id, False)
            */
            return default;
        }

        public async Task<TEntity> ComputeIsMembershipMultiInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py) ---
            // def _compute_is_membership_multi(self):
            // multi_enabled = self.env['ir.config_parameter'].sudo().get_param('sales_team.membership_multi', False)
            // self.is_membership_multi = multi_enabled
            */
            return default;
        }

        public async Task<TEntity> ComputeIsMilestoneExceededInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_is_milestone_exceeded(self):
            // today = fields.Date.context_today(self)
            // read_group = self.env['project.milestone']._read_group([
            //     ('project_id', 'in', self.filtered('allow_milestones').ids),
            //     ('is_reached', '=', False),
            //     ('deadline', '<=', today)], ['project_id'], ['__count'])
            // mapped_count = {project.id: count for project, count in read_group}
            // for project in self:
            //     project.is_milestone_exceeded = bool(mapped_count.get(project.id, 0))
            */
            return default;
        }

        public async Task<TEntity> ComputeIsModeratorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def _compute_is_moderator(self):
            // for group in self:
            //     group.is_moderator = self.env.user.id in group.moderator_ids.ids
            */
            return default;
        }

        public async Task<TEntity> ComputeLastUpdateColorInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_last_update_color(self):
            // for project in self:
            //     project.last_update_color = STATUS_COLOR[project.last_update_status]
            */
            return default;
        }

        public async Task<TEntity> ComputeLastUpdateStatusInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_last_update_status(self):
            // for project in self:
            //     project.last_update_status = project.last_update_id.status or 'to_define'
            */
            return default;
        }

        public async Task<TEntity> ComputeLeadAllAssignedMonthCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
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

        public async Task<TEntity> ComputeLeadUnassignedCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
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

        public async Task<TEntity> ComputeMailGroupMessageCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def _compute_mail_group_message_count(self):
            // if not self:
            //     self.mail_group_message_count = 0
            //     return
            // 
            // results = self.env['mail.group.message']._read_group(
            //     [('mail_group_id', 'in', self.ids)],
            //     ['mail_group_id'],
            //     ['__count'],
            // )
            // result_per_group = {
            //     mail_group.id: count
            //     for mail_group, count in results
            // }
            // for group in self:
            //     group.mail_group_message_count = result_per_group.get(group.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeMailGroupMessageLastMonthCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def _compute_mail_group_message_last_month_count(self):
            // month_date = datetime.today() - relativedelta.relativedelta(months=1)
            // messages_data = self.env['mail.group.message']._read_group([
            //     ('mail_group_id', 'in', self.ids),
            //     ('create_date', '>=', fields.Datetime.to_string(month_date)),
            //     ('moderation_status', '=', 'accepted'),
            // ], ['mail_group_id'], ['__count'])
            // 
            // # { mail_discusison_id: number_of_mail_group_message_last_month_count }
            // messages_data = {
            //     mail_group.id: count
            //     for mail_group, count in messages_data
            // }
            // 
            // for group in self:
            //     group.mail_group_message_last_month_count = messages_data.get(group.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeMailGroupMessageModerationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def _compute_mail_group_message_moderation_count(self):
            // results = self.env['mail.group.message']._read_group(
            //     [('mail_group_id', 'in', self.ids), ('moderation_status', '=', 'pending_moderation')],
            //     ['mail_group_id'],
            //     ['__count'],
            // )
            // result_per_group = {
            //     mail_group.id: count
            //     for mail_group, count in results
            // }
            // 
            // for group in self:
            //     group.mail_group_message_moderation_count = result_per_group.get(group.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeMaintenanceCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py) ---
            // def _compute_maintenance_count(self):
            // maintenance_data = self.env['maintenance.request']._read_group([('category_id', 'in', self.ids)], ['category_id', 'archive'], ['__count'])
            // mapped_data = {(category.id, archive): count for category, archive, count in maintenance_data}
            // for category in self:
            //     category.maintenance_open_count = mapped_data.get((category.id, False), 0)
            //     category.maintenance_count = category.maintenance_open_count + mapped_data.get((category.id, True), 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeMemberCompanyIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
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

        public async Task<TEntity> ComputeMemberCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def _compute_member_count(self):
            // for group in self:
            //     group.member_count = len(group.member_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeMemberIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py) ---
            // def _compute_member_ids(self):
            // for team in self:
            //     team.member_ids = team.crm_team_member_ids.user_id
            */
            return default;
        }

        public async Task<TEntity> ComputeMemberPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def _compute_member_partner_ids(self):
            // for group in self:
            //     group.member_partner_ids = group.member_ids.partner_id
            */
            return default;
        }

        public async Task<TEntity> ComputeMemberWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
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

        public async Task<TEntity> ComputeMilestoneCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_milestone_count(self):
            // read_group = self.env['project.milestone']._read_group([('project_id', 'in', self.ids)], ['project_id'], ['__count'])
            // mapped_count = {project.id: count for project, count in read_group}
            // for project in self:
            //     project.milestone_count = mapped_count.get(project.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeMilestoneReachedCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_milestone_reached_count(self):
            // read_group = self.env['project.milestone']._read_group(
            //     [('project_id', 'in', self.ids), ('is_reached', '=', True)],
            //     ['project_id'],
            //     ['__count'],
            // )
            // mapped_count = {project.id: count for project, count in read_group}
            // for project in self:
            //     project.milestone_count_reached = mapped_count.get(project.id, 0)
            //     project.milestone_progress = project.milestone_count and project.milestone_count_reached * 100 // project.milestone_count
            */
            return default;
        }

        public async Task<TEntity> ComputeModerationRuleCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def _compute_moderation_rule_count(self):
            // for group in self:
            //     group.moderation_rule_count = len(group.moderation_rule_ids)
            */
            return default;
        }

        public async Task<TEntity> ComputeNewApplicationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _compute_new_application_count(self):
            // self.env.cr.execute(
            //     """
            //         WITH job_stage AS (
            //             SELECT DISTINCT ON (j.id) j.id AS job_id, s.id AS stage_id, s.sequence AS sequence
            //               FROM hr_job j
            //          LEFT JOIN hr_job_hr_recruitment_stage_rel rel
            //                 ON rel.hr_job_id = j.id
            //               JOIN hr_recruitment_stage s
            //                 ON s.id = rel.hr_recruitment_stage_id
            //                 OR s.id NOT IN (
            //                                 SELECT "hr_recruitment_stage_id"
            //                                   FROM "hr_job_hr_recruitment_stage_rel"
            //                                  WHERE "hr_recruitment_stage_id" IS NOT NULL
            //                                 )
            //              WHERE j.id in %s
            //           ORDER BY 1, 3 asc
            //         )
            //         SELECT s.job_id, COUNT(a.id) AS new_applicant
            //           FROM hr_applicant a
            //           JOIN job_stage s
            //             ON s.job_id = a.job_id
            //            AND a.stage_id = s.stage_id
            //            AND a.active IS TRUE
            //          WHERE a.company_id in %s
            //             OR a.company_id is NULL
            //       GROUP BY s.job_id
            //     """, [tuple(self.ids), tuple(self.env.companies.ids)]
            // )
            // 
            // new_applicant_count = dict(self.env.cr.fetchall())
            // for job in self:
            //     job.new_application_count = new_applicant_count.get(job.id, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeNextMilestoneIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_next_milestone_id(self):
            // milestone_ids_per_project_id = {
            //     project.id: milestone_ids
            //     for project, milestone_ids in self.env['project.milestone']._read_group(
            //         [('project_id', 'in', self.ids), ('is_reached', '=', False)],
            //         ['project_id'],
            //         ['id:recordset'],
            //     )
            // }
            // for project in self:
            //     milestone = milestone_ids_per_project_id.get(project.id, self.env['project.milestone'])[:1]
            //     project.next_milestone_id = milestone
            //     project.can_mark_milestone_as_done = milestone.can_be_marked_as_done
            //     project.is_milestone_deadline_exceeded = milestone.is_deadline_exceeded
            */
            return default;
        }

        public async Task<TEntity> ComputeNoOfHiredEmployeeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _compute_no_of_hired_employee(self):
            // counts = dict(self.env['hr.applicant']._read_group(
            //     domain=[
            //         ('job_id', 'in', self.ids),
            //         ('date_closed', '!=', False),
            //         '|',
            //             ('active', '=', False),
            //             ('active', '=', True),
            //     ],
            //     groupby=['job_id'],
            //     aggregates=['__count']))
            // for job in self:
            //     job.no_of_hired_employee = counts.get(job, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeOldApplicationCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _compute_old_application_count(self):
            // for job in self:
            //     job.old_application_count = job.application_count - job.new_application_count
            */
            return default;
        }

        public async Task<TEntity> ComputeOpenTaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_open_task_count(self):
            // self.__compute_task_count(
            //     count_field='open_task_count',
            //     additional_domain=[('state', 'in', self.env['project.task'].OPEN_STATES)],
            // )
            */
            return default;
        }

        public async Task<TEntity> ComputeOpportunitiesDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
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

        public async Task<TEntity> ComputeOpportunitiesOverdueDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
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

        public async Task<TEntity> ComputePosOrderAmountTotalInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
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

        public async Task<TEntity> ComputePosSessionsOpenCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_sale, FILE: crm_team.py) ---
            // def _compute_pos_sessions_open_count(self):
            // for team in self:
            //     team.pos_sessions_open_count = self.env['pos.session'].search_count([('config_id.crm_team_id', '=', team.id), ('state', '=', 'opened')])
            */
            return default;
        }

        public async Task<TEntity> ComputePrivacyVisibilityWarningInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_privacy_visibility_warning(self):
            // for project in self:
            //     if not project.ids:
            //         project.privacy_visibility_warning = ''
            //     elif project.privacy_visibility == 'portal' and project._origin.privacy_visibility != 'portal':
            //         project.privacy_visibility_warning = _('Customers will be added to the followers of their project and tasks.')
            //     elif project.privacy_visibility != 'portal' and project._origin.privacy_visibility == 'portal':
            //         project.privacy_visibility_warning = _('Portal users will be removed from the followers of the project and its tasks.')
            //     else:
            //         project.privacy_visibility_warning = ''
            */
            return default;
        }

        public async Task<TEntity> ComputePublishedDateInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py) ---
            // def _compute_published_date(self):
            // for job in self:
            //     job.published_date = job.website_published and fields.Date.today()
            */
            return default;
        }

        public async Task<TEntity> ComputeQuotationsToInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
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

        public async Task<TEntity> ComputeRatingRequestDeadlineInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_rating_request_deadline(self):
            // periods = {'daily': 1, 'weekly': 7, 'bimonthly': 15, 'monthly': 30, 'quarterly': 90, 'yearly': 365}
            // for project in self:
            //     project.rating_request_deadline = fields.datetime.now() + timedelta(days=periods.get(project.rating_status_period, 0))
            */
            return default;
        }

        public async Task<TEntity> ComputeResourceCalendarIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_resource_calendar_id(self):
            // for project in self:
            //     project.resource_calendar_id = project.company_id.resource_calendar_id or self.env.company.resource_calendar_id
            */
            return default;
        }

        public async Task<TEntity> ComputeSaleOrderCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
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

        public async Task<TEntity> ComputeSalesToInvoiceInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
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

        public async Task<TEntity> ComputeTaskCompletionPercentageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_task_completion_percentage(self):
            // for task in self:
            //     task.task_completion_percentage = task.task_count and 1 - task.open_task_count / task.task_count
            */
            return default;
        }

        public async Task<TEntity> ComputeTaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_task_count(self):
            // self.__compute_task_count()
            */
            return default;
        }

        public async Task<TEntity> ComputeTotalUpdateIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _compute_total_update_ids(self):
            // update_count_per_project = dict(
            //     self.env['project.update']._read_group(
            //         [('project_id', 'in', self.ids)],
            //         ['project_id'],
            //         ['id:count'],
            //     )
            // )
            // for project in self:
            //     project.update_count = update_count_per_project.get(project, 0)
            */
            return default;
        }

        public async Task<TEntity> ComputeWebsiteUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py) ---
            // def _compute_website_url(self):
            // super(Job, self)._compute_website_url()
            // for job in self:
            //     job.website_url = f'/jobs/{self.env["ir.http"]._slug(job)}'
            */
            return default;
        }

        public async Task<TEntity> ConstrainsAssignmentDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
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

        public async Task<TEntity> CopyAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def copy(self, default=None):
            // default = dict(default or {})
            // # Since we dont want to copy the milestones if the original project has the feature disabled, we set the milestones to False by default.
            // default['milestone_ids'] = False
            // copy_context = dict(
            //      self.env.context,
            //      mail_auto_subscribe_no_notify=True,
            //      mail_create_nosubscribe=True,
            //  )
            // copy_context.pop("default_stage_id", None)
            // new_projects = super(Project, self.with_context(copy_context)).copy(default=default)
            // if 'milestone_mapping' not in self.env.context:
            //     self = self.with_context(milestone_mapping={})
            // actions_per_project = dict(self.env['ir.embedded.actions']._read_group(
            //     domain=[
            //         ('parent_res_id', 'in', self.ids),
            //         ('parent_res_model', '=', 'project.project'),
            //         ('user_id', '=', False),
            //     ],
            //     groupby=['parent_res_id'],
            //     aggregates=['id:recordset'],
            // ))
            // for old_project, new_project in zip(self, new_projects):
            //     for follower in old_project.message_follower_ids:
            //         new_project.message_subscribe(partner_ids=follower.partner_id.ids, subtype_ids=follower.subtype_ids.ids)
            //     if old_project.allow_milestones:
            //         new_project.milestone_ids = self.milestone_ids.copy().ids
            //     if 'tasks' not in default:
            //         old_project.map_tasks(new_project.id)
            //     if not old_project.active:
            //         new_project.with_context(active_test=False).tasks.active = True
            //     # Copy the shared embedded actions in the new project
            //     shared_embedded_actions = actions_per_project.get(old_project.id)
            //     if shared_embedded_actions:
            //         copy_shared_embedded_actions = shared_embedded_actions.copy({'parent_res_id': new_project.id})
            //         for original_action, copied_action in zip(shared_embedded_actions, copy_shared_embedded_actions):
            //             copied_action.filter_ids = original_action.filter_ids.copy({'embedded_parent_res_id': new_project.id})
            // return new_projects
            */
            return default;
        }

        public async Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // if default and 'name' in default:
            //     return vals_list
            // return [dict(vals, name=self.env._("%s (copy)", project.name)) for project, vals in zip(self, vals_list)]
            */
            return default;
        }

        public async Task<TEntity> CreateAnalyticAccountInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _create_analytic_account(self):
            // analytic_accounts_values = self._get_values_analytic_account_batch(self._read_format(['name', 'company_id', 'partner_id'], None))
            // analytic_accounts = self.env['account.analytic.account'].create(analytic_accounts_values)
            // for project, analytic_account in zip(self, analytic_accounts):
            //     project.account_id = analytic_account
            */
            return default;
        }

        public async Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     vals["favorite_user_ids"] = vals.get("favorite_user_ids", [])
            // jobs = super().create(vals_list)
            // utm_linkedin = self.env.ref("utm.utm_source_linkedin", raise_if_not_found=False)
            // if utm_linkedin:
            //     source_vals = [{
            //         'source_id': utm_linkedin.id,
            //         'job_id': job.id,
            //     } for job in jobs]
            //     self.env['hr.recruitment.source'].create(source_vals)
            // jobs.sudo().interviewer_ids._create_recruitment_interviewers()
            // # Automatically subscribe the department manager and the recruiter to a job position.
            // for job in jobs:
            //     job.message_subscribe(
            //         job.manager_id._get_related_partners().ids + job.user_id.partner_id.ids
            //     )
            // 
            // return jobs
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def create(self, vals_list):
            // # Prevent double project creation
            // self = self.with_context(mail_create_nosubscribe=True)
            // if any('label_tasks' in vals and not vals['label_tasks'] for vals in vals_list):
            //     task_label = _("Tasks")
            //     for vals in vals_list:
            //         if 'label_tasks' in vals and not vals['label_tasks']:
            //             vals['label_tasks'] = task_label
            // if self.env.user.has_group('project.group_project_stages'):
            //     if 'default_stage_id' in self._context:
            //         stage = self.env['project.project.stage'].browse(self._context['default_stage_id'])
            //         # The project's company_id must be the same as the stage's company_id
            //         if stage.company_id:
            //             for vals in vals_list:
            //                 if vals.get('stage_id'):
            //                     continue
            //                 vals['company_id'] = stage.company_id.id
            //     else:
            //         companies_ids = [vals.get('company_id', False) for vals in vals_list] + [False]
            //         stages = self.env['project.project.stage'].search([('company_id', 'in', companies_ids)])
            //         for vals in vals_list:
            //             if vals.get('stage_id'):
            //                 continue
            //             # Pick the stage with the lowest sequence with no company or project's company
            //             stage_domain = [False] if 'company_id' not in vals else [False, vals.get('company_id')]
            //             stage = stages.filtered(lambda s: s.company_id.id in stage_domain)[:1]
            //             vals['stage_id'] = stage.id
            // 
            // for vals in vals_list:
            //     if vals.pop('is_favorite', False):
            //         vals['favorite_user_ids'] = [self.env.uid]
            // projects = super().create(vals_list)
            // return projects
            */
            return default;
        }

        public async Task<TEntity> CreationSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _creation_subtype(self):
            // return self.env.ref('hr_recruitment.mt_job_new')
            */
            return default;
        }

        public async Task<TEntity> CronAssignLeadsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object force_quota, object creation_delta_days) where TEntity : IEntity<Guid>, IMailAliasMixinable
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

        public async Task<TEntity> CronNotifyModeratorsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def _cron_notify_moderators(self):
            // moderated_groups = self.env['mail.group'].search([('moderation', '=', True)])
            // return moderated_groups._notify_moderators()
            */
            return default;
        }

        public async Task<TEntity> DefaultAddressIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _default_address_id(self):
            // last_used_address = self.env['hr.job'].search([('company_id', 'in', self.env.companies.ids)], order='id desc', limit=1)
            // if last_used_address:
            //     return last_used_address.address_id
            // else:
            //     return self.env.company.partner_id
            */
            return default;
        }

        public async Task<TEntity> DefaultGetAsync<TEntity>(IEnumerable<TEntity> entities, object fields) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def default_get(self, fields):
            // res = super().default_get(fields)
            // if 'alias_contact' in fields and not res.get('alias_contact'):
            //     res['alias_contact'] = 'everyone' if res.get('access_mode') == 'public' else 'followers'
            // return res
            */
            return default;
        }

        public async Task<TEntity> DefaultStageIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _default_stage_id(self):
            // # Since project stages are order by sequence first, this should fetch the one with the lowest sequence number.
            // return self.env['project.project.stage'].search([], limit=1)
            */
            return default;
        }

        public async Task<TEntity> EditDialogAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def edit_dialog(self):
            // form_view = self.env.ref('hr.view_hr_job_form')
            // return {
            //     'name': _('Job'),
            //     'res_model': 'hr.job',
            //     'res_id': self.id,
            //     'views': [(form_view.id, 'form')],
            //     'type': 'ir.actions.act_window',
            //     'target': 'inline'
            // }
            */
            return default;
        }

        public async Task<TEntity> EnsureStageHasSameCompanyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _ensure_stage_has_same_company(self):
            // for project in self:
            //     if project.stage_id.company_id and project.stage_id.company_id != project.company_id:
            //         raise UserError(
            //             _('This project is associated with %(project_company)s, whereas the selected stage belongs to %(stage_company)s. '
            //             'There are a couple of options to consider: either remove the company designation '
            //             'from the project or from the stage. Alternatively, you can update the company '
            //             'information for these records to align them under the same company.', project_company=project.company_id.name, stage_company=project.stage_id.company_id.name)
            //             if project.company_id else
            //             _('This project is not associated with any company, while the stage is associated with %s. '
            //             'There are a couple of options to consider: either change the project\'s company '
            //             'to align with the stage\'s company or remove the company designation from the stage', project.stage_id.company_id.name)
            //         )
            */
            return default;
        }

        public async Task<TEntity> ExtraSqlConditionsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_team.py) ---
            // def _extra_sql_conditions(self):
            // if self.use_opportunities:
            //     return SQL("type LIKE 'opportunity'")
            // return super(Team,self)._extra_sql_conditions()
            */
            return default;
        }

        public async Task<TEntity> FindMemberInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email, Guid partner_id) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def _find_member(self, email, partner_id=None):
            // """Return the <mail.group.member> corresponding to the given email address."""
            // self.ensure_one()
            // 
            // result = self._find_members(email, partner_id)
            // return result.get(self.id)
            */
            return default;
        }

        public async Task<TEntity> FindMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email, Guid partner_id) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def _find_members(self, email, partner_id):
            // """Get all the members record corresponding to the email / partner_id.
            // 
            // Can be called in batch and return a dictionary
            //     {'group_id': <mail.group.member>}
            // 
            // Multiple members might have the same email address, but with different partner
            // because there's no unique constraint on the email field of the <res.partner>
            // model.
            // 
            // When a partner is given for the search, return in priority
            // - The member whose partner match the given partner
            // - The member without partner but whose email match the given email
            // 
            // When no partner is given for the search, return in priority
            // - A member whose email match the given email and has no partner
            // - A member whose email match the given email and has partner
            // """
            // order = 'partner_id ASC'
            // if not email_normalize(email):
            //     # empty email should match nobody
            //     return {}
            // 
            // domain = [('email_normalized', '=', email_normalize(email))]
            // if partner_id:
            //     domain = expression.OR([
            //         expression.AND([
            //             [('partner_id', '=', False)],
            //             domain,
            //         ]),
            //         [('partner_id', '=', partner_id)],
            //     ])
            //     order = 'partner_id DESC'
            // 
            // domain = expression.AND([domain, [('mail_group_id', 'in', self.ids)]])
            // members_data = self.env['mail.group.member'].sudo().search(domain, order=order)
            // return {
            //     member.mail_group_id.id: member
            //     for member in members_data
            // }
            */
            return default;
        }

        public async Task<TEntity> GenerateActionTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email, object action) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def _generate_action_token(self, email, action):
            // """Generate an action token to be able to subscribe / unsubscribe from the mailing list."""
            // if action not in ['subscribe', 'unsubscribe']:
            //     raise ValueError(_('Invalid action for URL generation (%s)', action))
            // self.ensure_one()
            // 
            // email_normalized = email_normalize(email)
            // if not email_normalized:
            //     raise UserError(_('Email %s is invalid', email))
            // 
            // data = (self.id, email_normalized, action)
            // return hmac(self.env(su=True), 'mail_group-email-subscription', data)
            */
            return default;
        }

        public async Task<TEntity> GenerateActionUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email, object action) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def _generate_action_url(self, email, action):
            // """Generate the confirmation URL to subscribe / unsubscribe from the mailing list."""
            // if action not in ['subscribe', 'unsubscribe']:
            //     raise ValueError(_('Invalid action for URL generation (%s)', action))
            // self.ensure_one()
            // 
            // confirm_action_url = '/group/%s-confirm?%s' % (
            //     action,
            //     urls.url_encode({
            //         'group_id': self.id,
            //         'email': email,
            //         'token': self._generate_action_token(email, action),
            //     })
            // )
            // base_url = self.get_base_url()
            // confirm_action_url = urls.url_join(base_url, confirm_action_url)
            // return confirm_action_url
            */
            return default;
        }

        public async Task<TEntity> GenerateEmailAccessTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def _generate_email_access_token(self, email):
            // """Generate an action token to be able to unsubscribe from the mailing
            // list, while hashing the target email to avoid spoofind other emails.
            // 
            // :param str email: email included in hash, should be normalized
            // """
            // return tools.hmac(self.env(su=True), 'mail_group-access-token-portal-email', (self.id, email))
            */
            return default;
        }

        public async Task<TEntity> GenerateGroupAccessTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def _generate_group_access_token(self):
            // """Generate an action token to be able to subscribe / unsubscribe from the mailing list."""
            // self.ensure_one()
            // return hmac(self.env(su=True), 'mail_group-access-token-portal', self.id)
            */
            return default;
        }

        public async Task<TEntity> GetAbandonedCartsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
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
            return default;
        }

        public async Task<TEntity> GetAccountNodeContextInternalAsync<TEntity>(IEnumerable<TEntity> entities, object plan) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_account_node_context(self, plan):
            // return {
            //     **super()._get_account_node_context(plan),
            //     'default_company_id': unquote('company_id'),
            // }
            */
            return default;
        }

        public async Task<TEntity> GetAlreadyIncludedProfitabilityInvoiceLineIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_already_included_profitability_invoice_line_ids(self):
            // # To be extended to avoid account.move.line overlap between
            // # profitability reports.
            // return []
            */
            return default;
        }

        public async Task<TEntity> GetBackendMenuIdAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py) ---
            // def get_backend_menu_id(self):
            // return self.env.ref('hr_recruitment.menu_hr_recruitment_root').id
            */
            return default;
        }

        public async Task<TEntity> GetDashboardGraphDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
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

        public async Task<TEntity> GetDefaultFavoriteUserIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _get_default_favorite_user_ids(self):
            // return [(6, 0, [self.env.uid])]
            */
            return default;
        }

        public async Task<TEntity> GetDefaultJobDetailsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py) ---
            // def _get_default_job_details(self):
            // return _("""
            //     <span class="text-muted small">Time to Answer</span>
            //     <h6>2 open days</h6>
            //     <span class="text-muted small">Process</span>
            //     <h6>1 Phone Call</h6>
            //     <h6>1 Onsite Interview</h6>
            //     <span class="text-muted small">Days to get an Offer</span>
            //     <h6>4 Days after Interview</h6>
            // """)
            */
            return default;
        }

        public async Task<TEntity> GetDefaultTeamIdInternalAsync<TEntity>(IEnumerable<TEntity> entities, Guid user_id, object domain) where TEntity : IEntity<Guid>, IMailAliasMixinable
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

        public async Task<TEntity> GetDefaultWebsiteDescriptionInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py) ---
            // def _get_default_website_description(self):
            // return self.env['ir.qweb']._render("website_hr_recruitment.default_website_description", raise_if_not_found=False)
            */
            return default;
        }

        public async Task<TEntity> GetEmailUnsubscribeUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email_to) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def _get_email_unsubscribe_url(self, email_to):
            // params = urls.url_encode({
            //     'email': email_to,
            //     'token': self._generate_email_access_token(email_to),
            // })
            // return urls.url_join(
            //     self.get_base_url(),
            //     f'group/{self.id}/unsubscribe_oneclick?{params}'
            // )
            */
            return default;
        }

        public async Task<TEntity> GetFirstStageInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _get_first_stage(self):
            // self.ensure_one()
            // return self.env['hr.recruitment.stage'].search([
            //     '|',
            //     ('job_ids', '=', False),
            //     ('job_ids', '=', self.id)], order='sequence asc', limit=1)
            */
            return default;
        }

        public async Task<TEntity> GetHidePartnerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_hide_partner(self):
            // return False
            */
            return default;
        }

        public async Task<TEntity> GetItemsFromAalInternalAsync<TEntity>(IEnumerable<TEntity> entities, object with_action) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_items_from_aal(self, with_action=True):
            // return {
            //     'revenues': {'data': [], 'total': {'invoiced': 0.0, 'to_invoice': 0.0}},
            //     'costs': {'data': [], 'total': {'billed': 0.0, 'to_bill': 0.0}},
            // }
            */
            return default;
        }

        public async Task<TEntity> GetLastUpdateOrDefaultAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def get_last_update_or_default(self):
            // self.ensure_one()
            // labels = dict(self._fields['last_update_status']._description_selection(self.env))
            // return {
            //     'status': labels.get(self.last_update_status, _('Set Status')),
            //     'color': self.last_update_color,
            // }
            */
            return default;
        }

        public async Task<TEntity> GetLeadToAssignDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
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

        public async Task<TEntity> GetListViewAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_get_list_view(self):
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _("%(name)s's Milestones", name=self.name),
            //     'domain': [('project_id', '=', self.id)],
            //     'res_model': 'project.milestone',
            //     'views': [(self.env.ref('project.project_milestone_view_tree').id, 'list')],
            //     'view_mode': 'list',
            //     'help': _("""
            //         <p class="o_view_nocontent_smiling_face">
            //             No milestones found. Let's create one!
            //         </p><p>
            //             Track major progress points that must be reached to achieve success.
            //         </p>
            //     """),
            //     'context': {
            //         'default_project_id': self.id,
            //         **self.env.context
            //     }
            // }
            */
            return default;
        }

        public async Task<TEntity> GetMilestonesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def get_milestones(self):
            // if self.env.user.has_group('project.group_project_user'):
            //     return self._get_milestones()
            // return {}
            */
            return default;
        }

        public async Task<TEntity> GetMilestonesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_milestones(self):
            // self.ensure_one()
            // return {
            //     'data': self.milestone_ids._get_data_list(),
            // }
            */
            return default;
        }

        public async Task<TEntity> GetNewCollaboratorsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object partners) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_new_collaborators(self, partners):
            // self.ensure_one()
            // return partners.filtered(
            //     lambda partner:
            //         partner not in self.collaborator_ids.partner_id
            //         and partner.partner_share
            // )
            */
            return default;
        }

        public async Task<TEntity> GetPanelDataAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def get_panel_data(self):
            // self.ensure_one()
            // if not self.env.user.has_group('project.group_project_user'):
            //     return {}
            // show_profitability = self._show_profitability()
            // panel_data = {
            //     'user': self._get_user_values(),
            //     'buttons': sorted(self._get_stat_buttons(), key=lambda k: k['sequence']),
            //     'currency_id': self.currency_id.id,
            //     'show_project_profitability_helper': show_profitability and self._show_profitability_helper(),
            //     'show_milestones': self.allow_milestones,
            // }
            // if self.allow_milestones:
            //     panel_data['milestones'] = self._get_milestones()
            // if show_profitability:
            //     profitability_items = self.with_context(active_test=False)._get_profitability_items()
            //     if self._get_profitability_sequence_per_invoice_type() and profitability_items and 'revenues' in profitability_items and 'costs' in profitability_items:  # sort the data values
            //         profitability_items['revenues']['data'] = sorted(profitability_items['revenues']['data'], key=lambda k: k['sequence'])
            //         profitability_items['costs']['data'] = sorted(profitability_items['costs']['data'], key=lambda k: k['sequence'])
            //     panel_data['profitability_items'] = profitability_items
            //     panel_data['profitability_labels'] = self._get_profitability_labels()
            // return panel_data
            */
            return default;
        }

        public async Task<TEntity> GetPlanDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object plan) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_plan_domain(self, plan):
            // return AND([super()._get_plan_domain(plan), ['|', ('company_id', '=', False), ('company_id', '=?', unquote('company_id'))]])
            */
            return default;
        }

        public async Task<TEntity> GetProfitabilityAalDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_profitability_aal_domain(self):
            // return [('account_id', 'in', self.account_id.ids)]
            */
            return default;
        }

        public async Task<TEntity> GetProfitabilityItemsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object with_action) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_profitability_items(self, with_action=True):
            // return self._get_items_from_aal(with_action)
            */
            return default;
        }

        public async Task<TEntity> GetProfitabilityLabelsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_profitability_labels(self):
            // return {}
            */
            return default;
        }

        public async Task<TEntity> GetProfitabilitySequencePerInvoiceTypeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_profitability_sequence_per_invoice_type(self):
            // return {}
            */
            return default;
        }

        public async Task<TEntity> GetProjectsToMakeBillableDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_projects_to_make_billable_domain(self):
            // return [('partner_id', '!=', False)]
            */
            return default;
        }

        public async Task<TEntity> GetStatButtonsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_stat_buttons(self):
            // self.ensure_one()
            // closed_task_count = self.task_count - self.open_task_count
            // if self.task_count:
            //     number = self.env._(
            //         "%(closed_task_count)s / %(task_count)s (%(closed_rate)s%%)",
            //         closed_task_count=closed_task_count,
            //         task_count=self.task_count,
            //         closed_rate=round(100 * closed_task_count / self.task_count),
            //     )
            // else:
            //     number = self.env._(
            //         "%(closed_task_count)s / %(task_count)s",
            //         closed_task_count=closed_task_count,
            //         task_count=self.task_count,
            //     )
            // buttons = [{
            //     'icon': 'check',
            //     'text': self.env._('Tasks'),
            //     'number': number,
            //     'action_type': 'object',
            //     'action': 'action_view_tasks',
            //     'show': True,
            //     'sequence': 1,
            // }]
            // if self.rating_count != 0 and self.env.user.has_group('project.group_project_rating'):
            //     if self.rating_avg >= rating_data.RATING_AVG_TOP:
            //         icon = 'smile-o text-success'
            //     elif self.rating_avg >= rating_data.RATING_AVG_OK:
            //         icon = 'meh-o text-warning'
            //     else:
            //         icon = 'frown-o text-danger'
            //     buttons.append({
            //         'icon': icon,
            //         'text': self.env._('Average Rating'),
            //         'number': f'{int(self.rating_avg) if self.rating_avg.is_integer() else round(self.rating_avg, 1)} / 5',
            //         'action_type': 'object',
            //         'action': 'action_view_all_rating',
            //         'show': self.rating_active,
            //         'sequence': 15,
            //     })
            // if self.env.user.has_group('project.group_project_user'):
            //     buttons.append({
            //         'icon': 'area-chart',
            //         'text': self.env._('Burndown Chart'),
            //         'action_type': 'action',
            //         'action': 'project.action_project_task_burndown_chart_report',
            //         'additional_context': json.dumps({
            //             'active_id': self.id,
            //             'stage_name_and_sequence_per_id': {
            //                 stage.id: {
            //                     'sequence': stage.sequence,
            //                     'name': stage.name
            //                 } for stage in self.type_ids
            //             },
            //         }),
            //         'show': True,
            //         'sequence': 60,
            //     })
            // return buttons
            */
            return default;
        }

        public async Task<TEntity> GetUserValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_user_values(self):
            // return {
            //     'is_project_user': self.env.user.has_group('project.group_project_user'),
            // }
            */
            return default;
        }

        public async Task<TEntity> GetValuesAnalyticAccountBatchInternalAsync<TEntity>(IEnumerable<TEntity> entities, object project_vals_list) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _get_values_analytic_account_batch(self, project_vals_list):
            // project_plan, _other_plans = self.env['account.analytic.plan']._get_all_plans()
            // return [{
            //     'name': project_vals.get('name', self.env._('Unknown Analytic Account')),
            //     'company_id': project_vals.get('company_id', False),
            //     'partner_id': project_vals.get('partner_id', False),
            //     'plan_id': project_plan.id,
            // } for project_vals in project_vals_list]
            */
            return default;
        }

        public async Task<TEntity> GraphDataInternalAsync<TEntity>(IEnumerable<TEntity> entities, object start_date, object end_date) where TEntity : IEntity<Guid>, IMailAliasMixinable
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

        public async Task<TEntity> GraphDateColumnInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_team.py) ---
            // def _graph_date_column(self):
            // if self.use_opportunities:
            //     return SQL('create_date')
            // return super(Team,self)._graph_date_column()
            */
            return default;
        }

        public async Task<TEntity> GraphGetDatesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object today) where TEntity : IEntity<Guid>, IMailAliasMixinable
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

        public async Task<TEntity> GraphGetModelInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_team.py) ---
            // def _graph_get_model(self):
            // if self.use_opportunities:
            //     return 'crm.lead'
            // return super(Team,self)._graph_get_model()
            */
            return default;
        }

        public async Task<object> GraphGetTableInternalAsync<TEntity>(IEnumerable<TEntity> entities, object GraphModel) where TEntity : IEntity<Guid>, IMailAliasMixinable
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

        public async Task<TEntity> GraphTitleAndKeyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_team.py) ---
            // def _graph_title_and_key(self):
            // if self.use_opportunities:
            //     return ['', _('New Opportunities')] # no more title
            // return super(Team, self)._graph_title_and_key()
            */
            return default;
        }

        public async Task<object> GraphXQueryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py) ---
            // def _graph_x_query(self) -> SQL:
            // return SQL('EXTRACT(WEEK FROM %s)', self._graph_date_column())
            */
            return default;
        }

        public async Task<TEntity> GraphYQueryInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_team.py) ---
            // def _graph_y_query(self):
            // if self.use_opportunities:
            //     return SQL('count(*)')
            // return super(Team,self)._graph_y_query()
            */
            return default;
        }

        public async Task<TEntity> InSaleScopeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: crm_team.py) ---
            // def _in_sale_scope(self):
            // return self.env.context.get('in_sales_app')
            */
            return default;
        }

        public async Task<TEntity> InitColumnAliasIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_alias_mixin.py) ---
            // def _init_column_alias_id(self):
            // # both self and the alias model must be present in 'ir.model'
            // child_ctx = {
            //     'active_test': False,       # retrieve all records
            //     'prefetch_fields': False,   # do not prefetch fields on records
            // }
            // child_model = self.sudo().with_context(child_ctx)
            // 
            // for record in child_model.search([('alias_id', '=', False)]):
            //     # create the alias, and link it to the current record
            //     alias = self.env['mail.alias'].sudo().create(record._alias_get_creation_values())
            //     record.with_context(mail_notrack=True).alias_id = alias
            //     _logger.info('Mail alias created for %s %s (id %s)',
            //                  record._name, record.display_name, record.id)
            */
            return default;
        }

        public async Task<TEntity> InitColumnInternalAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_alias_mixin.py) ---
            // def _init_column(self, name):
            // """ Create aliases for existing rows. """
            // super()._init_column(name)
            // if name == 'alias_id':
            //     # as 'mail.alias' records refer to 'ir.model' records, create
            //     # aliases after the reflection of models
            //     self.pool.post_init(self._init_column_alias_id)
            */
            return default;
        }

        public async Task<TEntity> InverseAllowTaskDependenciesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _inverse_allow_task_dependencies(self):
            // """ Reset state for waiting tasks in the project if the feature is disabled
            //     or recompute the tasks with dependencies if the project has the feature enabled again
            // """
            // project_with_task_dependencies_feature = self.filtered('allow_task_dependencies')
            // projects_without_task_dependencies_feature = self - project_with_task_dependencies_feature
            // ProjectTask = self.env['project.task']
            // if (
            //     project_with_task_dependencies_feature
            //     and (
            //         open_tasks_with_dependencies := ProjectTask.search([
            //             ('project_id', 'in', project_with_task_dependencies_feature.ids),
            //             ('depend_on_ids.state', 'in', ProjectTask.OPEN_STATES),
            //             ('state', 'in', ProjectTask.OPEN_STATES),
            //         ])
            //     )
            // ):
            //     open_tasks_with_dependencies.state = '04_waiting_normal'
            // if (
            //     projects_without_task_dependencies_feature
            //     and (
            //         waiting_tasks := ProjectTask.search([
            //             ('project_id', 'in', projects_without_task_dependencies_feature.ids),
            //             ('state', '=', '04_waiting_normal'),
            //         ])
            //     )
            // ):
            //     waiting_tasks.state = '01_in_progress'
            */
            return default;
        }

        public async Task<TEntity> InverseCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _inverse_company_id(self):
            // """
            // Ensures that the new company of the project is valid for the account. If not set back the previous company, and raise a user Error.
            // Ensures that the new company of the project is valid for the partner
            // """
            // for project in self:
            //     account = project.account_id
            //     if project.partner_id and project.partner_id.company_id and project.company_id != project.partner_id.company_id:
            //         raise UserError(_('The project and the associated partner must be linked to the same company.'))
            //     if not account or not account.company_id:
            //         continue
            //     # if the account of the project has more than one company linked to it, or if it has aal, do not update the account, and set back the old company on the project.
            //     if (account.project_count > 1 or account.line_ids) and project.company_id != account.company_id:
            //         raise UserError(
            //             _("The project's company cannot be changed if its analytic account has analytic lines or if more than one project is linked to it."))
            //     account.company_id = project.company_id
            */
            return default;
        }

        public async Task<TEntity> InverseIsFavoriteInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _inverse_is_favorite(self):
            // unfavorited_jobs = favorited_jobs = self.env['hr.job']
            // for job in self:
            //     if self.env.user in job.favorite_user_ids:
            //         unfavorited_jobs |= job
            //     else:
            //         favorited_jobs |= job
            // favorited_jobs.write({'favorite_user_ids': [(4, self.env.uid)]})
            // unfavorited_jobs.write({'favorite_user_ids': [(3, self.env.uid)]})
            */
            return default;
        }

        public async Task<TEntity> InverseMemberIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
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

        public async Task<TEntity> JoinAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def action_join(self):
            // self.check_access('read')
            // partner = self.env.user.partner_id
            // self.sudo()._join_group(partner.email, partner.id)
            // 
            // _logger.info('"%s" (#%s) joined mail.group "%s" (#%s)', partner.name, partner.id, self.name, self.id)
            */
            return default;
        }

        public async Task<TEntity> JoinGroupInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email, Guid partner_id) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def _join_group(self, email, partner_id=None):
            // self.ensure_one()
            // 
            // if partner_id:
            //     partner = self.env['res.partner'].browse(partner_id).exists()
            //     if not partner:
            //         raise ValidationError(_('The partner can not be found.'))
            //     email = partner.email
            // 
            // existing_member = self._find_member(email, partner_id)
            // if existing_member:
            //     # Update the information of the partner to force the synchronization
            //     # If one the value is not up to date (e.g. if our email is subscribed
            //     # but our partner was not set)
            //     existing_member.write({
            //         'email': email,
            //         'partner_id': partner_id,
            //     })
            //     return
            // 
            // member = self.env['mail.group.member'].create({
            //     'partner_id': partner_id,
            //     'email': email,
            //     'mail_group_id': self.id,
            // })
            // 
            // if self.moderation_guidelines:
            //     # Automatically send the guidelines to the new member
            //     self.action_send_guidelines(member)
            */
            return default;
        }

        public async Task<TEntity> LeaveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def action_leave(self):
            // self.check_access('read')
            // partner = self.env.user.partner_id
            // self.sudo()._leave_group(partner.email, partner.id)
            // 
            // _logger.info('"%s" (#%s) leaved mail.group "%s" (#%s)', partner.name, partner.id, self.name, self.id)
            */
            return default;
        }

        public async Task<TEntity> LeaveGroupInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email, Guid partner_id, object all_members) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def _leave_group(self, email, partner_id=None, all_members=False):
            // """Remove the given email / partner from the group.
            // 
            // If the "all_members" parameter is set to True, remove all members with the given
            // email address (multiple members might have the same email address).
            // 
            // Otherwise, remove the most appropriate.
            // """
            // self.ensure_one()
            // if all_members and not partner_id:
            //     self.env['mail.group.member'].search([
            //         ('mail_group_id', '=', self.id),
            //         ('email_normalized', '=', email_normalize(email)),
            //     ]).unlink()
            // else:
            //     member = self._find_member(email, partner_id)
            //     if member:
            //         member.unlink()
            */
            return default;
        }

        public async Task<TEntity> MailGetMessageSubtypesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _mail_get_message_subtypes(self):
            // res = super()._mail_get_message_subtypes()
            // if not self.rating_active:
            //     res -= self.env.ref('project.mt_project_task_rating')
            // if len(self) == 1:
            //     waiting_subtype = self.env.ref('project.mt_project_task_waiting')
            //     if not self.allow_task_dependencies and waiting_subtype in res:
            //         res -= waiting_subtype
            // return res
            */
            return default;
        }

        public async Task<TEntity> MailGetPartnerFieldsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object introspect_fields) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: test_mail, FILE: test_mail_models.py) ---
            // def _mail_get_partner_fields(self, introspect_fields=False):
            // return ['customer_id']
            --- ODOO METHOD SOURCE (MODULE: test_mail, FILE: test_mail_models.py) ---
            // def _mail_get_partner_fields(self, introspect_fields=False):
            // return ['customer_id']
            */
            return default;
        }

        public async Task<TEntity> MapTasksAsync<TEntity>(IEnumerable<TEntity> entities, Guid new_project_id) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def map_tasks(self, new_project_id):
            // """ copy and map tasks from old to new project """
            // project = self.browse(new_project_id)
            // new_tasks = self.env['project.task']
            // # We want to copy archived task, but do not propagate an active_test context key
            // tasks = self.env['project.task'].with_context(active_test=False).search([('project_id', '=', self.id), ('parent_id', '=', False)])
            // if self.allow_task_dependencies and 'task_mapping' not in self.env.context:
            //     self = self.with_context(task_mapping=dict())
            // # preserve task name and stage, normally altered during copy
            // defaults = self._map_tasks_default_values(project)
            // new_tasks = tasks.with_context(copy_project=True).copy(defaults)
            // all_subtasks = new_tasks._get_all_subtasks()
            // project.write({'tasks': [Command.set(new_tasks.ids)]})
            // subtasks_not_displayed = all_subtasks.filtered(
            //     lambda task: not task.display_in_project
            // )
            // all_subtasks.filtered(
            //     lambda child: child.project_id == self
            // ).write({
            //     'project_id': project.id
            // })
            // subtasks_not_displayed.write({
            //     'display_in_project': False
            // })
            // return True
            */
            return default;
        }

        public async Task<TEntity> MapTasksDefaultValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object project) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _map_tasks_default_values(self, project):
            // """ get the default value for the copied task on project duplication.
            // The stage_id, name field will be set for each task in the overwritten copy_data function in project.task """
            // return {
            //     'state': '01_in_progress',
            //     'company_id': project.company_id.id,
            //     'project_id': project.id,
            // }
            */
            return default;
        }

        public async Task<TEntity> MessageGetDefaultRecipientsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: test_mail, FILE: test_mail_models.py) ---
            // def _message_get_default_recipients(self):
            // return dict(
            //     (record.id, {
            //         'email_cc': False,
            //         'email_to': record.email_from if not record.customer_id.ids else False,
            //         'partner_ids': record.customer_id.ids,
            //     })
            //     for record in self
            // )
            --- ODOO METHOD SOURCE (MODULE: test_mail, FILE: test_mail_models.py) ---
            // def _message_get_default_recipients(self):
            // return dict(
            //     (record.id, {
            //         'email_cc': False,
            //         'email_to': False,
            //         'partner_ids': record.customer_id.ids,
            //     })
            //     for record in self
            // )
            */
            return default;
        }

        public async Task<TEntity> MessageNewAsync<TEntity>(IEnumerable<TEntity> entities, object msg_dict, object custom_values) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def message_new(self, msg_dict, custom_values=None):
            // """Add the method to make the mail gateway flow work with this model."""
            // return
            */
            return default;
        }

        public async Task<TEntity> MessagePostAsync<TEntity>(IEnumerable<TEntity> entities, object body, object subject, object email_from, Guid author_id) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def message_post(self, body='', subject=None, email_from=None, author_id=None, **kwargs):
            // """ Custom posting process. This model does not inherit from ``mail.thread``
            // but uses the mail gateway so few methods should be defined.
            // 
            // This custom posting process works as follow
            // 
            //   * create a ``mail.message`` based on incoming email;
            //   * create linked ``mail.group.message`` that encapsulates message in a
            //     format used in mail groups;
            //   * apply moderation rules;
            // 
            // :return message: newly-created mail.message
            // """
            // self.ensure_one()
            // # First create the <mail.message>
            // Mailthread = self.env['mail.thread']
            // values = dict((key, val) for key, val in kwargs.items() if key in self.env['mail.message']._fields)
            // author_id, email_from = Mailthread._message_compute_author(author_id, email_from, raise_on_email=True)
            // 
            // values.update({
            //     'author_id': author_id,
            //     # sanitize then make valid Markup, notably for '_process_attachments_for_post'
            //     'body': Markup(self._clean_email_body(body)),
            //     'email_from': email_from,
            //     'model': self._name,
            //     'partner_ids': [],
            //     'res_id': self.id,
            //     'subject': subject,
            // })
            // 
            // # Force the "reply-to" to make the mail group flow work
            // values['reply_to'] = self.env['mail.message']._get_reply_to(values)
            // 
            // # ensure message ID so that replies go to the right thread
            // if not values.get('message_id'):
            //     values['message_id'] = generate_tracking_message_id('%s-mail.group' % self.id)
            // 
            // values.update(Mailthread._process_attachments_for_post(
            //     kwargs.get('attachments') or [],
            //     kwargs.get('attachment_ids') or [],
            //     values
            // ))
            // 
            // mail_message = Mailthread._message_create([values])
            // 
            // # Find the <mail.group.message> parent
            // group_message_parent_id = False
            // if mail_message.parent_id:
            //     group_message_parent = self.env['mail.group.message'].search(
            //         [('mail_message_id', '=', mail_message.parent_id.id)])
            //     group_message_parent_id = group_message_parent.id if group_message_parent else False
            // 
            // moderation_status = 'pending_moderation' if self.moderation else 'accepted'
            // 
            // # Create the group message associated
            // group_message = self.env['mail.group.message'].create({
            //     'mail_group_id': self.id,
            //     'mail_message_id': mail_message.id,
            //     'moderation_status': moderation_status,
            //     'group_message_parent_id': group_message_parent_id,
            // })
            // 
            // # Check the moderation rule to determine if we should accept or reject the email
            // email_normalized = email_normalize(email_from)
            // moderation_rule = self.env['mail.group.moderation'].search([
            //     ('mail_group_id', '=', self.id),
            //     ('email', '=', email_normalized),
            // ], limit=1)
            // 
            // if not self.moderation:
            //     self._notify_members(group_message)
            // 
            // elif moderation_rule and moderation_rule.status == 'allow':
            //     group_message.action_moderate_accept()
            // 
            // elif moderation_rule and moderation_rule.status == 'ban':
            //     group_message.action_moderate_reject()
            // 
            // elif self.moderation_notify:
            //     self.env['mail.mail'].sudo().create({
            //         'author_id': self.env.user.partner_id.id,
            //         'auto_delete': True,
            //         'body_html': group_message.mail_group_id.moderation_notify_msg,
            //         'email_from': self.env.user.company_id.catchall_formatted or self.env.user.company_id.email_formatted,
            //         'email_to': email_from,
            //         'subject': 'Re: %s' % (subject or ''),
            //         'state': 'outgoing'
            //     })
            // 
            // return mail_message
            */
            return default;
        }

        public async Task<TEntity> MessageSubscribeAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids, List<Guid> subtype_ids) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def message_subscribe(self, partner_ids=None, subtype_ids=None):
            // """
            // Subscribe to newly created task but not all existing active task when subscribing to a project.
            // User update notification preference of project its propagated to all the tasks that the user is
            // currently following.
            // """
            // res = super(Project, self).message_subscribe(partner_ids=partner_ids, subtype_ids=subtype_ids)
            // if subtype_ids:
            //     project_subtypes = self.env['mail.message.subtype'].browse(subtype_ids)
            //     task_subtypes = (project_subtypes.mapped('parent_id') | project_subtypes.filtered(lambda sub: sub.internal or sub.default)).ids
            //     if task_subtypes:
            //         for task in self.task_ids:
            //             partners = set(task.message_partner_ids.ids) & set(partner_ids)
            //             if partners:
            //                 task.message_subscribe(partner_ids=list(partners), subtype_ids=task_subtypes)
            //         self.update_ids.message_subscribe(partner_ids=partner_ids, subtype_ids=subtype_ids)
            // return res
            */
            return default;
        }

        public async Task<TEntity> MessageUnsubscribeAsync<TEntity>(IEnumerable<TEntity> entities, List<Guid> partner_ids) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def message_unsubscribe(self, partner_ids=None):
            // super().message_unsubscribe(partner_ids=partner_ids)
            // if partner_ids:
            //     self.env['project.collaborator'].search([('partner_id', 'in', partner_ids), ('project_id', 'in', self.ids)]).unlink()
            */
            return default;
        }

        public async Task<TEntity> MessageUpdateAsync<TEntity>(IEnumerable<TEntity> entities, object msg_dict, object update_vals) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def message_update(self, msg_dict, update_vals=None):
            // """Add the method to make the mail gateway flow work with this model."""
            // return
            */
            return default;
        }

        public async Task<TEntity> NameCreateAsync<TEntity>(IEnumerable<TEntity> entities, object name) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def name_create(self, name):
            // res = super().name_create(name)
            // if res:
            //     # We create a default stage `new` for projects created on the fly.
            //     self.browse(res[0]).type_ids += self.env['project.task.type'].sudo().create({'name': _('New')})
            // return res
            */
            return default;
        }

        public async Task<TEntity> NewSurveyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment_survey, FILE: hr_job.py) ---
            // def action_new_survey(self):
            // self.ensure_one()
            // survey = self.env['survey.survey'].create({
            //     'title': _("Interview Form: %s", self.name),
            // })
            // self.write({'survey_id': survey.id})
            // 
            // action = {
            //         'name': _('Survey'),
            //         'view_mode': 'form,list',
            //         'res_model': 'survey.survey',
            //         'type': 'ir.actions.act_window',
            //         'res_id': survey.id,
            //     }
            // 
            // return action
            */
            return default;
        }

        public async Task<TEntity> NotifyGetRecipientsGroupsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message, object model_description, object msg_vals) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _notify_get_recipients_groups(self, message, model_description, msg_vals=None):
            // """ Give access to the portal user/customer if the project visibility is portal. """
            // groups = super()._notify_get_recipients_groups(message, model_description, msg_vals=msg_vals)
            // if not self:
            //     return groups
            // 
            // self.ensure_one()
            // portal_privacy = self.privacy_visibility == 'portal'
            // for group_name, _group_method, group_data in groups:
            //     if group_name in ['portal', 'portal_customer'] and not portal_privacy:
            //         group_data['has_button_access'] = False
            // return groups
            --- ODOO METHOD SOURCE (MODULE: test_mail, FILE: test_mail_models.py) ---
            // def _notify_get_recipients_groups(self, message, model_description, msg_vals=None):
            // """ Activate more groups to test query counters notably (and be backward
            // compatible for tests). """
            // groups = super()._notify_get_recipients_groups(
            //     message, model_description, msg_vals=msg_vals
            // )
            // for group_name, _group_method, group_data in groups:
            //     if group_name == 'portal':
            //         group_data['active'] = True
            // 
            // return groups
            */
            return default;
        }

        public async Task<TEntity> NotifyMembersInternalAsync<TEntity>(IEnumerable<TEntity> entities, object message) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def _notify_members(self, message):
            // """Send the given message to all members of the mail group (except the author)."""
            // self.ensure_one()
            // 
            // if message.mail_group_id != self:
            //     raise UserError(_('The group of the message do not match.'))
            // 
            // if not message.mail_message_id.reply_to:
            //     _logger.error('The alias or the catchall domain is missing, group might not work properly.')
            // 
            // base_url = self.get_base_url()
            // body = self.env['mail.render.mixin']._replace_local_links(message.body)
            // 
            // # Email added in a dict to be sure to send only once the email to each address
            // member_emails = {
            //     email_normalize(member.email): member.email
            //     for member in self.member_ids
            // }
            // 
            // batch_size = int(self.env['ir.config_parameter'].sudo().get_param('mail.session.batch.size', GROUP_SEND_BATCH_SIZE))
            // for batch_email_member in tools.split_every(batch_size, member_emails.items()):
            //     mail_values = []
            //     for email_member_normalized, email_member in batch_email_member:
            //         if email_member_normalized == message.email_from_normalized:
            //             # Do not send the email to their author
            //             continue
            // 
            //         # SMTP headers related to the subscription
            //         email_url_encoded = urls.url_quote(email_member)
            //         unsubscribe_url = self._get_email_unsubscribe_url(email_member_normalized)
            // 
            //         headers = {
            //             ** self._notify_by_email_get_headers(),
            //             'List-Archive': f'<{base_url}/groups/{self.env["ir.http"]._slug(self)}>',
            //             'List-Subscribe': f'<{base_url}/groups?email={email_url_encoded}>',
            //             'List-Unsubscribe': f'<{unsubscribe_url}>',
            //             'List-Unsubscribe-Post': 'List-Unsubscribe=One-Click',
            //             'Precedence': 'list',
            //             'X-Auto-Response-Suppress': 'OOF',  # avoid out-of-office replies from MS Exchange
            //         }
            //         if self.alias_email:
            //             headers.update({
            //                 'List-Id': f'<{self.alias_email}>',
            //                 'List-Post': f'<mailto:{self.alias_email}>',
            //                 'X-Forge-To': f'"{self.name}" <{self.alias_email}>',
            //             })
            // 
            //         if message.mail_message_id.parent_id:
            //             headers['In-Reply-To'] = message.mail_message_id.parent_id.message_id
            // 
            //         # Add the footer (member specific) in the body
            //         template_values = {
            //             'mailto': f'{self.alias_email}',
            //             'group_url': f'{base_url}/groups/{self.env["ir.http"]._slug(self)}',
            //             'unsub_label': f'{base_url}/groups?unsubscribe',
            //             'unsub_url':  unsubscribe_url,
            //         }
            //         footer = self.env['ir.qweb']._render('mail_group.mail_group_footer', template_values, minimal_qcontext=True)
            //         member_body = append_content_to_html(body, footer, plaintext=False)
            // 
            //         mail_values.append({
            //             'auto_delete': True,
            //             'attachment_ids': message.attachment_ids.ids,
            //             'body_html': member_body,
            //             'email_from': message.email_from,
            //             'email_to': email_member,
            //             'headers': json.dumps(headers),
            //             'mail_message_id': message.mail_message_id.id,
            //             'message_id': message.mail_message_id.message_id,
            //             'model': 'mail.group',
            //             'reply_to': message.mail_message_id.reply_to,
            //             'res_id': self.id,
            //             'subject': message.subject,
            //         })
            // 
            //     if mail_values:
            //         self.env['mail.mail'].sudo().create(mail_values)
            */
            return default;
        }

        public async Task<TEntity> NotifyModeratorsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def _notify_moderators(self):
            // """Push a notification (Inbox / Email) to the moderators whose an action is waiting."""
            // template = self.env.ref('mail_group.mail_group_notify_moderation', raise_if_not_found=False)
            // if not template:
            //     _logger.warning('Template "mail_group.mail_group_notify_moderation" was not found. Cannot send reminder notifications.')
            //     return
            // 
            // results = self.env['mail.group.message']._read_group(
            //     [('mail_group_id', 'in', self.ids), ('moderation_status', '=', 'pending_moderation')],
            //     ['mail_group_id'],
            // )
            // groups = self.browse([mail_group.id for [mail_group] in results])
            // 
            // for group in groups:
            //     moderators_to_notify = group.moderator_ids
            //     MailThread = self.env['mail.thread']
            //     for moderator in moderators_to_notify:
            //         body = self.env['ir.qweb']._render('mail_group.mail_group_notify_moderation', {
            //             'moderator': moderator,
            //             'group': group,
            //             }, minimal_qcontext=True)
            //         email_from = moderator.company_id.catchall_formatted or moderator.company_id.email_formatted
            //         MailThread.message_notify(
            //             partner_ids=moderator.partner_id.ids,
            //             subject=_('Messages are pending moderation'),
            //             body=body,
            //             email_from=email_from,
            //             model='mail.group',
            //             notify_author=True,
            //             res_id=group.id,
            //         )
            */
            return default;
        }

        public async Task<TEntity> OnchangeAccessModeInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def _onchange_access_mode(self):
            // if self.access_mode == 'public':
            //     self.alias_contact = 'everyone'
            // else:
            //     self.alias_contact = 'followers'
            */
            return default;
        }

        public async Task<TEntity> OnchangeCompanyIdInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _onchange_company_id(self):
            // if (self.env.user.has_group('project.group_project_stages') and self.stage_id.company_id
            //         and self.stage_id.company_id != self.company_id):
            //     self.stage_id = self.env['project.project.stage'].search(
            //         [('company_id', 'in', [self.company_id.id, False])],
            //         order=f"sequence asc, {self.env['project.project.stage']._order}",
            //         limit=1,
            //     ).id
            */
            return default;
        }

        public async Task<TEntity> OnchangeModerationInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def _onchange_moderation(self):
            // if self.moderation and self.env.user not in self.moderator_ids:
            //     self.moderator_ids |= self.env.user
            */
            return default;
        }

        public async Task<TEntity> OnchangeUseLeadsOpportunitiesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_team.py) ---
            // def _onchange_use_leads_opportunities(self):
            // if not self.use_leads and not self.use_opportunities:
            //     self.alias_name = False
            */
            return default;
        }

        public async Task<TEntity> OnchangeWebsitePublishedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py) ---
            // def _onchange_website_published(self):
            // if self.website_published:
            //     self.is_published = True
            // else:
            //     self.is_published = False
            */
            return default;
        }

        public async Task<TEntity> OpenActivitiesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def action_open_activities(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("hr_recruitment.action_hr_job_applications")
            // views = ['activity'] + [view for view in action['view_mode'].split(',') if view != 'activity']
            // action['view_mode'] = ','.join(views)
            // action['views'] = [(False, view) for view in views]
            // return action
            */
            return default;
        }

        public async Task<TEntity> OpenAttachmentsAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def action_open_attachments(self):
            // return {
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'ir.attachment',
            //     'name': _('Documents'),
            //     'context': {
            //         'default_res_model': self._name,
            //         'default_res_id': self.ids[0],
            //         'show_partner_name': 1,
            //     },
            //     'view_mode': 'list',
            //     'views': [
            //         (self.env.ref('hr_recruitment.ir_attachment_hr_recruitment_list_view').id, 'list')
            //     ],
            //     'search_view_id': self.env.ref('hr_recruitment.ir_attachment_view_search_inherit_hr_recruitment').ids,
            //     'domain': ['|',
            //         '&', ('res_model', '=', 'hr.job'), ('res_id', 'in', self.ids),
            //         '&', ('res_model', '=', 'hr.applicant'), ('res_id', 'in', self.application_ids.ids),
            //     ],
            // }
            */
            return default;
        }

        public async Task<TEntity> OpenLateActivitiesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def action_open_late_activities(self):
            // action = self.action_open_activities()
            // action['context'] = {
            //     'default_job_id': self.id,
            //     'search_default_job_id': self.id,
            //     'search_default_activities_overdue': True,
            //     'search_default_running_applicant_activities': True,
            // }
            // return action
            */
            return default;
        }

        public async Task<TEntity> OpenShareProjectWizardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_open_share_project_wizard(self):
            // template = self.env.ref('project.mail_template_project_sharing', raise_if_not_found=False)
            // 
            // local_context = self.env.context | {
            //     'default_template_id': template.id if template else False,
            //     'default_email_layout_xmlid': 'mail.mail_notification_light',
            //     'active_id': self.id,
            //     'active_model': 'project.project',
            // }
            // action = self.env["ir.actions.actions"]._for_xml_id("project.project_share_wizard_action")
            // if self.env.context.get('default_access_mode'):
            //     action['name'] = _("Share Project")
            // action['context'] = local_context
            // return action
            */
            return default;
        }

        public async Task<TEntity> OpenTodayActivitiesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def action_open_today_activities(self):
            // action = self.action_open_activities()
            // action['context'] = {
            //     'default_job_id': self.id,
            //     'search_default_job_id': self.id,
            //     'search_default_activities_today': True,
            // }
            // return action
            */
            return default;
        }

        public async Task<TEntity> OpportunityForecastAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_team.py) ---
            // def action_opportunity_forecast(self):
            // action = self.env['ir.actions.actions']._for_xml_id('crm.crm_lead_action_forecast')
            // return self._action_update_to_pipeline(action)
            */
            return default;
        }

        public async Task<TEntity> OrderFieldToSqlInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @alias, object field_name, object direction, object nulls, object query) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _order_field_to_sql(self, alias, field_name, direction, nulls, query):
            // if field_name == 'is_favorite':
            //     sql_field = SQL(
            //         "%s IN (SELECT job_id FROM job_favorite_user_rel WHERE user_id = %s)",
            //         SQL.identifier(alias, 'id'), self.env.uid,
            //     )
            //     return SQL("%s %s %s", sql_field, direction, nulls)
            // 
            // return super()._order_field_to_sql(alias, field_name, direction, nulls, query)
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _order_field_to_sql(self, alias, field_name, direction, nulls, query):
            // if field_name == 'is_favorite':
            //     sql_field = SQL(
            //         "%s IN (SELECT project_id FROM project_favorite_user_rel WHERE user_id = %s)",
            //         SQL.identifier(alias, 'id'), self.env.uid,
            //     )
            //     return SQL("%s %s %s", sql_field, direction, nulls)
            // 
            // return super()._order_field_to_sql(alias, field_name, direction, nulls, query)
            */
            return default;
        }

        public async Task<TEntity> PrimaryChannelButtonAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
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
            */
            return default;
        }

        public async Task<TEntity> ProfitabilityItemsAsync<TEntity>(IEnumerable<TEntity> entities, object section_name, object domain, Guid res_id) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_profitability_items(self, section_name, domain=None, res_id=False):
            // return {}
            */
            return default;
        }

        public async Task<TEntity> ProjectTaskBurndownChartReportAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_project_task_burndown_chart_report(self):
            // action = self.env['ir.actions.act_window']._for_xml_id('project.action_project_task_burndown_chart_report')
            // action['display_name'] = _("%(name)s's Burndown Chart", name=self.name)
            // context = action['context'].replace('active_id', str(self.id))
            // context = ast.literal_eval(context)
            // context.update({
            //     'stage_name_and_sequence_per_id': {
            //         stage.id: {
            //             'sequence': stage.sequence,
            //             'name': stage.name
            //         } for stage in self.type_ids
            //     }
            // })
            // action['context'] = context
            // return action
            */
            return default;
        }

        public async Task<TEntity> ProjectUpdateAllActionAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def project_update_all_action(self):
            // action = self.env['ir.actions.act_window']._for_xml_id('project.project_update_all_action')
            // action['display_name'] = _("%(name)s Dashboard", name=self.name)
            // return action
            */
            return default;
        }

        public async Task<TEntity> RequireNewAliasInternalAsync<TEntity>(IEnumerable<TEntity> entities, object record_vals) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail, FILE: mail_alias_mixin.py) ---
            // def _require_new_alias(self, record_vals):
            // """ alias_id field is always required, due to inherits """
            // return not record_vals.get('alias_id')
            */
            return default;
        }

        public async Task<TEntity> SearchGetDetailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object website, object order, object options) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py) ---
            // def _search_get_detail(self, website, order, options):
            // requires_sudo = False
            // with_description = options['displayDescription']
            // country_id = options.get('country_id')
            // department_id = options.get('department_id')
            // office_id = options.get('office_id')
            // contract_type_id = options.get('contract_type_id')
            // is_remote = options.get('is_remote')
            // is_other_department = options.get('is_other_department')
            // is_untyped = options.get('is_untyped')
            // 
            // domain = [website.website_domain()]
            // if country_id:
            //     domain.append([('address_id.country_id', '=', int(country_id))])
            //     requires_sudo = True
            // if department_id:
            //     domain.append([('department_id', '=', int(department_id))])
            // elif is_other_department:
            //     domain.append([('department_id', '=', None)])
            // if office_id:
            //     domain.append([('address_id', '=', int(office_id))])
            // elif is_remote:
            //     domain.append([('address_id', '=', None)])
            // if contract_type_id:
            //     domain.append([('contract_type_id', '=', int(contract_type_id))])
            // elif is_untyped:
            //     domain.append([('contract_type_id', '=', None)])
            // 
            // if requires_sudo and not self.env.user.has_group('hr_recruitment.group_hr_recruitment_user'):
            //     # Rule must be reinforced because of sudo.
            //     domain.append([('website_published', '=', True)])
            // 
            // 
            // search_fields = ['name']
            // fetch_fields = ['name', 'website_url']
            // mapping = {
            //     'name': {'name': 'name', 'type': 'text', 'match': True},
            //     'website_url': {'name': 'website_url', 'type': 'text', 'truncate':  False},
            // }
            // if with_description:
            //     search_fields.append('description')
            //     fetch_fields.append('description')
            //     mapping['description'] = {'name': 'description', 'type': 'text', 'html': True, 'match': True}
            // return {
            //     'model': 'hr.job',
            //     'requires_sudo': requires_sudo,
            //     'base_domain': domain,
            //     'search_fields': search_fields,
            //     'fetch_fields': fetch_fields,
            //     'mapping': mapping,
            //     'icon': 'fa-briefcase',
            // }
            */
            return default;
        }

        public async Task<TEntity> SearchIsFavoriteInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _search_is_favorite(self, operator, value):
            // if operator not in ['=', '!='] or not isinstance(value, bool):
            //     raise NotImplementedError(_('Operation not supported'))
            // return [('favorite_user_ids', 'in' if (operator == '=') == value else 'not in', self.env.uid)]
            */
            return default;
        }

        public async Task<TEntity> SearchIsMilestoneExceededInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _search_is_milestone_exceeded(self, operator, value):
            // if not isinstance(value, bool):
            //     raise ValueError(_('Invalid value: %s', value))
            // if operator not in ['=', '!=']:
            //     raise ValueError(_('Invalid operator: %s', operator))
            // 
            // sql = SQL("""(
            //     SELECT P.id
            //       FROM project_project P
            //  LEFT JOIN project_milestone M ON P.id = M.project_id
            //      WHERE M.is_reached IS false
            //        AND P.allow_milestones IS true
            //        AND M.deadline <= CAST(now() AS date)
            // )""")
            // if (operator == '=' and value is True) or (operator == '!=' and value is False):
            //     operator_new = 'in'
            // else:
            //     operator_new = 'not in'
            // return [('id', operator_new, sql)]
            */
            return default;
        }

        public async Task<TEntity> SearchMatchingCandidatesAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment_skills, FILE: hr_job.py) ---
            // def action_search_matching_candidates(self):
            // self.ensure_one()
            // help_message_1 = _("No Matching Candidates")
            // help_message_2 = _("We do not have any candidates who meet the skill requirements for this job position in the database at the moment.")
            // action = self.env['ir.actions.actions']._for_xml_id('hr_recruitment.action_hr_candidate')
            // context = literal_eval(action['context'])
            // context['active_id'] = self.id
            // matching_candidates = self.env['hr.candidate'].search([('skill_ids', 'in', self.skill_ids.ids)]).filtered(lambda c: self.id not in c.applicant_ids.job_id.ids)
            // action.update({
            //     'name': _("Matching Candidates"),
            //     'views': [
            //         (self.env.ref('hr_recruitment_skills.hr_candidate_view_tree').id, 'list'),
            //         (False, 'form'),
            //     ],
            //     'context': context,
            //     'domain': [('id', 'in', matching_candidates.ids)],
            //     'help': Markup("<p class='o_view_nocontent_empty_folder'>%s</p><p>%s</p>") % (help_message_1, help_message_2),
            // })
            // return action
            */
            return default;
        }

        public async Task<TEntity> SearchMemberIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object @value) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sales_team, FILE: crm_team.py) ---
            // def _search_member_ids(self, operator, value):
            // return [('crm_team_member_ids.user_id', operator, value)]
            */
            return default;
        }

        public async Task<TEntity> SearchMemberPartnerIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object @operator, object operand) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def _search_member_partner_ids(self, operator, operand):
            // return [(
            //     'member_ids',
            //     'in',
            //     self.env['mail.group.member'].sudo()._search([
            //         ('partner_id', operator, operand)
            //     ])
            // )]
            */
            return default;
        }

        public async Task<TEntity> SendGuidelinesAsync<TEntity>(IEnumerable<TEntity> entities, object members) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def action_send_guidelines(self, members=None):
            // """ Send guidelines to given members. """
            // self.ensure_one()
            // 
            // if not self.env.is_admin() and not self.is_moderator:
            //     raise UserError(_('Only an administrator or a moderator can send guidelines to group members.'))
            // 
            // if not self.moderation_guidelines_msg:
            //     raise UserError(_('The guidelines description is empty.'))
            // 
            // template = self.env.ref('mail_group.mail_template_guidelines', raise_if_not_found=False)
            // if not template:
            //     raise UserError(_('Template "mail_group.mail_template_guidelines" was not found. No email has been sent. Please contact an administrator to fix this issue.'))
            // 
            // banned_emails = self.env['mail.group.moderation'].sudo().search([
            //     ('status', '=', 'ban'),
            //     ('mail_group_id', '=', self.id),
            // ]).mapped('email')
            // 
            // if members is None:
            //     members = self.member_ids
            // members = members.filtered(lambda member: member.email_normalized not in banned_emails)
            // 
            // for member in members:
            //     company = member.partner_id.company_id or self.env.company
            //     template.send_mail(
            //         member.id,
            //         email_values={
            //             'author_id': self.env.user.partner_id.id,
            //             'email_from': company.email_formatted or company.catchall_formatted,
            //             'reply_to': company.email_formatted or company.catchall_formatted,
            //         },
            //     )
            // 
            // _logger.info('Send guidelines to %i members', len(members))
            */
            return default;
        }

        public async Task<TEntity> SendRatingAllInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _send_rating_all(self):
            // projects = self.search([
            //     ('rating_active', '=', True),
            //     ('rating_status', '=', 'periodic'),
            //     ('rating_request_deadline', '<=', fields.Datetime.now())
            // ])
            // for project in projects:
            //     project.task_ids._send_task_rating_mail()
            //     project._compute_rating_request_deadline()
            //     self.env.cr.commit()
            */
            return default;
        }

        public async Task<TEntity> SendSubscribeConfirmationEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def _send_subscribe_confirmation_email(self, email):
            // """Send an email to the given address to subscribe / unsubscribe to the mailing list."""
            // self.ensure_one()
            // confirm_action_url = self._generate_action_url(email, 'subscribe')
            // 
            // template = self.env.ref('mail_group.mail_template_list_subscribe')
            // template.with_context(token_url=confirm_action_url).send_mail(
            //     self.id,
            //     email_layout_xmlid='mail.mail_notification_light',
            //     email_values={
            //         'author_id': self.create_uid.partner_id.id,
            //         'auto_delete': True,
            //         'email_from': self.env.company.email_formatted,
            //         'email_to': email,
            //         'message_type': 'user_notification',
            //     },
            //     force_send=True,
            // )
            // _logger.info('Subscription email sent to %s.', email)
            */
            return default;
        }

        public async Task<TEntity> SendUnsubscribeConfirmationEmailInternalAsync<TEntity>(IEnumerable<TEntity> entities, object email) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mail_group, FILE: mail_group.py) ---
            // def _send_unsubscribe_confirmation_email(self, email):
            // """Send an email to the given address to subscribe / unsubscribe to the mailing list."""
            // self.ensure_one()
            // confirm_action_url = self._generate_action_url(email, 'unsubscribe')
            // 
            // template = self.env.ref('mail_group.mail_template_list_unsubscribe')
            // template.with_context(token_url=confirm_action_url).send_mail(
            //     self.id,
            //     email_layout_xmlid='mail.mail_notification_light',
            //     email_values={
            //         'author_id': self.create_uid.partner_id.id,
            //         'auto_delete': True,
            //         'email_from': self.env.company.email_formatted,
            //         'email_to': email,
            //         'message_type': 'user_notification',
            //     },
            //     force_send=True,
            // )
            // _logger.info('Unsubscription email sent to %s.', email)
            */
            return default;
        }

        public async Task<TEntity> SetFavoriteUserIdsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object is_favorite) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _set_favorite_user_ids(self, is_favorite):
            // self_sudo = self.sudo() # To allow project users to set projects as favorite
            // if is_favorite:
            //     self_sudo.favorite_user_ids = [Command.link(self.env.uid)]
            // else:
            //     self_sudo.favorite_user_ids = [Command.unlink(self.env.uid)]
            */
            return default;
        }

        public async Task<TEntity> SetOpenAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py) ---
            // def set_open(self):
            // self.write({'website_published': False})
            // return super(Job, self).set_open()
            */
            return default;
        }

        public async Task<TEntity> ShowProfitabilityHelperInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _show_profitability_helper(self):
            // return self.env.user.has_group('analytic.group_analytic_accounting')
            */
            return default;
        }

        public async Task<TEntity> ShowProfitabilityInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _show_profitability(self):
            // self.ensure_one()
            // return True
            */
            return default;
        }

        public async Task<TEntity> TestSurveyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment_survey, FILE: hr_job.py) ---
            // def action_test_survey(self):
            // self.ensure_one()
            // action = self.survey_id.action_test_survey()
            // return action
            */
            return default;
        }

        protected async Task<object> ThreadToStoreInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _thread_to_store(self, store: Store, /, *, request_list=None, **kwargs):
            // super()._thread_to_store(store, request_list=request_list, **kwargs)
            // if request_list and "followers" in request_list:
            //     store.add(
            //         self,
            //         {"collaborator_ids": Store.many(self.collaborator_ids.partner_id, only_id=True)},
            //         as_thread=True,
            //     )
            */
            return default;
        }

        public async Task<TEntity> ToggleActiveAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py) ---
            // def toggle_active(self):
            // self.filtered('active').website_published = False
            // return super().toggle_active()
            */
            return default;
        }

        public async Task<TEntity> ToggleFavoriteAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def toggle_favorite(self):
            // favorite_projects = not_fav_projects = self.env['project.project'].sudo()
            // for project in self:
            //     if self.env.user in project.favorite_user_ids:
            //         favorite_projects |= project
            //     else:
            //         not_fav_projects |= project
            // 
            // # Project User has no write access for project.
            // not_fav_projects.write({'favorite_user_ids': [(4, self.env.uid)]})
            // favorite_projects.write({'favorite_user_ids': [(3, self.env.uid)]})
            */
            return default;
        }

        public async Task<TEntity> TrackSubtypeInternalAsync<TEntity>(IEnumerable<TEntity> entities, object init_values) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _track_subtype(self, init_values):
            // self.ensure_one()
            // if 'stage_id' in init_values:
            //     return self.env.ref('project.mt_project_stage_change')
            // return super()._track_subtype(init_values)
            */
            return default;
        }

        public async Task<TEntity> TrackTemplateInternalAsync<TEntity>(IEnumerable<TEntity> entities, object changes) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def _track_template(self, changes):
            // res = super()._track_template(changes)
            // project = self[0]
            // if self.env.user.has_group('project.group_project_stages') and 'stage_id' in changes and project.stage_id.mail_template_id:
            //     res['stage_id'] = (project.stage_id.mail_template_id, {
            //         'auto_delete_keep_log': False,
            //         'subtype_id': self.env['ir.model.data']._xmlid_to_res_id('mail.mt_note'),
            //         'email_layout_xmlid': 'mail.mail_notification_light',
            //     })
            // return res
            */
            return default;
        }

        public async Task<TEntity> UnlinkAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
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
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def unlink(self):
            // # Delete the empty related analytic account
            // analytic_accounts_to_delete = self.env['account.analytic.account']
            // for project in self:
            //     if project.account_id and not project.account_id.line_ids:
            //         analytic_accounts_to_delete |= project.account_id
            // self.with_context(active_test=False).tasks.unlink()
            // result = super(Project, self).unlink()
            // analytic_accounts_to_delete.unlink()
            // return result
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptContainsMaintenanceRequestsInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: maintenance, FILE: maintenance.py) ---
            // def _unlink_except_contains_maintenance_requests(self):
            // for category in self:
            //     if category.equipment_ids or category.maintenance_ids:
            //         raise UserError(_("You cannot delete an equipment category containing equipment or maintenance requests."))
            */
            return default;
        }

        public async Task<TEntity> UnlinkExceptDefaultInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
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

        public async Task<TEntity> UnlinkExceptUsedForSalesInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
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

        public async Task<TEntity> UpdateInvoicedTargetAsync<TEntity>(IEnumerable<TEntity> entities, object @value) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sale, FILE: crm_team.py) ---
            // def update_invoiced_target(self, value):
            // return self.write({'invoiced_target': round(float(value or 0))})
            */
            return default;
        }

        public async Task<TEntity> ViewAllRatingAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_view_all_rating(self):
            // """ return the action to see all the rating of the project and activate default filters"""
            // action = self.env['ir.actions.act_window']._for_xml_id('project.rating_rating_action_view_project_rating')
            // action['display_name'] = _("%(name)s's Rating", name=self.name)
            // action_context = ast.literal_eval(action['context']) if action['context'] else {}
            // action_context.update(self._context)
            // action_context['search_default_filter_write_date'] = 'custom_write_date_last_30_days'
            // action_context.pop('group_by', None)
            // action['domain'] = [('consumed', '=', True), ('parent_res_model', '=', 'project.project'), ('parent_res_id', '=', self.id)]
            // if self.rating_count == 1:
            //     action.update({
            //         'view_mode': 'form',
            //         'views': [(view_id, view_type) for view_id, view_type in action['views'] if view_type == 'form'],
            //         'res_id': self.rating_ids[0].id, # [0] since rating_ids might be > then rating_count
            //     })
            // return dict(action, context=action_context)
            */
            return default;
        }

        public async Task<TEntity> ViewTasksAnalysisAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_view_tasks_analysis(self):
            // """ return the action to see the tasks analysis report of the project """
            // action = self.env['ir.actions.act_window']._for_xml_id('project.action_project_task_user_tree')
            // action['display_name'] = _("%(name)s's Tasks Analysis", name=self.name)
            // action_context = ast.literal_eval(action['context']) if action['context'] else {}
            // action_context['search_default_project_id'] = self.id
            // return dict(action, context=action_context)
            */
            return default;
        }

        public async Task<TEntity> ViewTasksAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def action_view_tasks(self):
            // action = self.env['ir.actions.act_window'].with_context(active_id=self.id)._for_xml_id('project.act_project_project_2_project_task_all')
            // action['display_name'] = self.name
            // context = action['context'].replace('active_id', str(self.id))
            // context = ast.literal_eval(context)
            // context.update({
            //     'create': self.active,
            //     'active_test': self.active
            //     })
            // action['context'] = context
            // return action
            */
            return default;
        }

        public async Task<TEntity> WriteAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, IMailAliasMixinable
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
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def write(self, vals):
            // old_interviewers = self.interviewer_ids
            // old_managers = {}
            // old_recruiters = {}
            // for job in self:
            //     old_managers[job] = job.manager_id
            //     old_recruiters[job] = job.user_id
            // if 'active' in vals and not vals['active']:
            //     self.application_ids.active = False
            // res = super().write(vals)
            // if 'interviewer_ids' in vals:
            //     interviewers_to_clean = old_interviewers - self.interviewer_ids
            //     interviewers_to_clean._remove_recruitment_interviewers()
            //     self.sudo().interviewer_ids._create_recruitment_interviewers()
            // 
            // # Subscribe the department manager if the department has changed
            // if "department_id" in vals:
            //     for job in self:
            //         to_unsubscribe = [
            //             partner
            //             for partner in old_managers[job]._get_related_partners().ids
            //             if partner not in job.user_id.partner_id.ids
            //         ]
            //         job.message_unsubscribe(to_unsubscribe)
            //         job.message_subscribe(job.manager_id._get_related_partners().ids)
            // 
            // # Subscribe the recruiter if it has changed.
            // if "user_id" in vals:
            //     for job in self:
            //         to_unsubscribe = [
            //             partner
            //             for partner in old_recruiters[job].partner_id.ids
            //             if partner not in job.manager_id._get_related_partners().ids
            //         ]
            //         job.message_unsubscribe(to_unsubscribe)
            //         job.message_subscribe(job.user_id.partner_id.ids)
            // 
            // # Update the availability on all hired candidates if the mission end date is changed
            // if "date_to" in vals:
            //     for job in self:
            //         hired_candidates = job.application_ids.filtered(lambda a: a.application_status == 'hired')
            //         for candidate in hired_candidates:
            //             candidate.availability = job.date_to + relativedelta(days=1)
            // 
            // # Since the alias is created upon record creation, the default values do not reflect the current values unless
            // # specifically rewritten
            // # List of fields to keep synched with the alias
            // alias_fields = {'department_id', 'user_id'}
            // if any(field for field in alias_fields if field in vals):
            //     for job in self:
            //         alias_default_vals = job._alias_get_creation_values().get('alias_defaults', '{}')
            //         job.alias_defaults = alias_default_vals
            // return res
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def write(self, vals):
            // if vals.get('access_token'):
            //     self.ensure_one()  # We are not supposed to add a single access token to multiple project
            //     if self.privacy_visibility != 'portal':
            //         vals['access_token'] = ''
            // 
            // # Here we modify the project's stage according to the selected company (selecting the first
            // # stage in sequence that is linked to the company).
            // company_id = vals.get('company_id')
            // if self.env.user.has_group('project.group_project_stages') and company_id:
            //     projects_already_with_company = self.filtered(lambda p: p.company_id.id == company_id)
            //     if projects_already_with_company:
            //         projects_already_with_company.write({key: value for key, value in vals.items() if key != 'company_id'})
            //         self -= projects_already_with_company
            //     if company_id not in (None, *self.company_id.ids) and self.stage_id.company_id:
            //         ProjectStage = self.env['project.project.stage']
            //         vals["stage_id"] = ProjectStage.search(
            //             [('company_id', 'in', (company_id, False))],
            //             order=f"sequence asc, {ProjectStage._order}",
            //             limit=1,
            //         ).id
            // 
            // # directly compute is_favorite to dodge allow write access right
            // if 'is_favorite' in vals:
            //     self._set_favorite_user_ids(vals.pop('is_favorite'))
            // 
            // if 'last_update_status' in vals and vals['last_update_status'] != 'to_define':
            //     for project in self:
            //         # This does not benefit from multi create, this is to allow the default description from being built.
            //         # This does seem ok since last_update_status should only be updated on one record at once.
            //         self.env['project.update'].with_context(default_project_id=project.id).create({
            //             'name': _('Status Update - %(date)s', date=fields.Date.today().strftime(get_lang(self.env).date_format)),
            //             'status': vals.get('last_update_status'),
            //         })
            //     vals.pop('last_update_status')
            // if vals.get('privacy_visibility'):
            //     self._change_privacy_visibility(vals['privacy_visibility'])
            // 
            // date_start = vals.get('date_start', True)
            // date_end = vals.get('date', True)
            // if not date_start or not date_end:
            //     vals['date_start'] = False
            //     vals['date'] = False
            // else:
            //     no_current_date_begin = not all(project.date_start for project in self)
            //     no_current_date_end = not all(project.date for project in self)
            //     date_start_update = 'date_start' in vals
            //     date_end_update = 'date' in vals
            //     if (date_start_update and no_current_date_end and not date_end_update):
            //         del vals['date_start']
            //     elif (date_end_update and no_current_date_begin and not date_start_update):
            //         del vals['date']
            // 
            // res = super(Project, self).write(vals) if vals else True
            // 
            // if 'allow_task_dependencies' in vals and not vals.get('allow_task_dependencies'):
            //     self.env['project.task'].search([('project_id', 'in', self.ids), ('state', '=', '04_waiting_normal')]).write({'state': '01_in_progress'})
            // 
            // if 'active' in vals:
            //     # archiving/unarchiving a project does it on its tasks, too
            //     self.with_context(active_test=False).mapped('tasks').write({'active': vals['active']})
            // if 'name' in vals and self.account_id:
            //     projects_read_group = self.env['project.project']._read_group(
            //         [('account_id', 'in', self.account_id.ids)],
            //         ['account_id'],
            //         having=[('__count', '=', 1)],
            //     )
            //     analytic_account_to_update = self.env['account.analytic.account'].browse([
            //         analytic_account.id for [analytic_account] in projects_read_group
            //     ])
            //     analytic_account_to_update.write({'name': self.name})
            // return res
            */
            return default;
        }

        public async Task<TEntity> YourPipelineAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: crm, FILE: crm_team.py) ---
            // def action_your_pipeline(self):
            // action = self.env["ir.actions.actions"]._for_xml_id("crm.crm_lead_action_pipeline")
            // return self._action_update_to_pipeline(action)
            */
            return default;
        }

        public async Task<TEntity> _ComputeTaskCountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object count_field, object additional_domain) where TEntity : IEntity<Guid>, IMailAliasMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: project, FILE: project_project.py) ---
            // def __compute_task_count(self, count_field='task_count', additional_domain=None):
            // count_fields = {fname for fname in self._fields if 'count' in fname}
            // if count_field not in count_fields:
            //     raise ValueError(f"Parameter 'count_field' can only be one of {count_fields}, got {count_field} instead.")
            // domain = [('project_id', 'in', self.ids), ('display_in_project', '=', True)]
            // if additional_domain:
            //     domain = AND([domain, additional_domain])
            // tasks_count_by_project = dict(self.env['project.task'].with_context(
            //     active_test=any(project.active for project in self)
            // )._read_group(domain, ['project_id'], ['__count']))
            // for project in self:
            //     project.update({count_field: tasks_count_by_project.get(project, 0)})
            */
            return default;
        }
    }
}