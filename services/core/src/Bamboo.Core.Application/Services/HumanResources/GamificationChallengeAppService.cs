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
    [Module("Gamification", Category = "HumanResources", Depends = new[] { "mail" })]
    public class GamificationChallengeAppService : GenericApplicationService<GamificationChallenge>, IGamificationChallengeAppService
    {
        private readonly IMailThreadAppService _mailThreadAppService;
        public GamificationChallengeAppService(IRepository<GamificationChallenge, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailThreadAppService mailThreadAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<GamificationChallenge> AcceptChallengeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py) ---
            // def accept_challenge(self):
            // user = self.env.user
            // sudoed = self.sudo()
            // sudoed.message_post(body=_("%s has joined the challenge", user.name))
            // sudoed.write({'invited_user_ids': [(3, user.id)], 'user_ids': [(4, user.id)]})
            // return sudoed._generate_goals_from_challenge()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<GamificationChallenge> CheckAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py) ---
            // def action_check(self):
            // """Check a challenge
            // 
            // Create goals that haven't been created yet (eg: if added users)
            // Recompute the current value for each goal related"""
            // self.env['gamification.goal'].search([
            //     ('challenge_id', 'in', self.ids),
            //     ('state', '=', 'inprogress')
            // ]).unlink()
            // 
            // return self._update_all()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<GamificationChallenge> CheckChallengeRewardInternalAsync(object force)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py) ---
            // def _check_challenge_reward(self, force=False):
            // """Actions for the end of a challenge
            // 
            // If a reward was selected, grant it to the correct users.
            // Rewards granted at:
            //     - the end date for a challenge with no periodicity
            //     - the end of a period for challenge with periodicity
            //     - when a challenge is manually closed
            // (if no end date, a running challenge is never rewarded)
            // """
            // commit = self.env.context.get('commit_gamification') and self.env.cr.commit
            // 
            // for challenge in self:
            //     (start_date, end_date) = start_end_date_for_period(challenge.period, challenge.start_date, challenge.end_date)
            //     yesterday = date.today() - timedelta(days=1)
            // 
            //     rewarded_users = self.env['res.users']
            //     challenge_ended = force or end_date == fields.Date.to_string(yesterday)
            //     if challenge.reward_id and (challenge_ended or challenge.reward_realtime):
            //         # not using start_date as intemportal goals have a start date but no end_date
            //         reached_goals = self.env['gamification.goal']._read_group([
            //             ('challenge_id', '=', challenge.id),
            //             ('end_date', '=', end_date),
            //             ('state', '=', 'reached')
            //         ], groupby=['user_id'], aggregates=['__count'])
            //         for user, count in reached_goals:
            //             if count == len(challenge.line_ids):
            //                 # the user has succeeded every assigned goal
            //                 if challenge.reward_realtime:
            //                     badges = self.env['gamification.badge.user'].search_count([
            //                         ('challenge_id', '=', challenge.id),
            //                         ('badge_id', '=', challenge.reward_id.id),
            //                         ('user_id', '=', user.id),
            //                     ])
            //                     if badges > 0:
            //                         # has already recieved the badge for this challenge
            //                         continue
            //                 challenge._reward_user(user, challenge.reward_id)
            //                 rewarded_users |= user
            //                 if commit:
            //                     commit()
            // 
            //     if challenge_ended:
            //         # open chatter message
            //         message_body = _("The challenge %s is finished.", challenge.name)
            // 
            //         if rewarded_users:
            //             message_body += Markup("<br/>") + _(
            //                 "Reward (badge %(badge_name)s) for every succeeding user was sent to %(users)s.",
            //                 badge_name=challenge.reward_id.name,
            //                 users=", ".join(rewarded_users.mapped('display_name'))
            //             )
            //         else:
            //             message_body += Markup("<br/>") + _("Nobody has succeeded to reach every goal, no badge is rewarded for this challenge.")
            // 
            //         # reward bests
            //         reward_message = Markup("<br/> %(rank)d. %(user_name)s - %(reward_name)s")
            //         if challenge.reward_first_id:
            //             (first_user, second_user, third_user) = challenge._get_topN_users(MAX_VISIBILITY_RANKING)
            //             if first_user:
            //                 challenge._reward_user(first_user, challenge.reward_first_id)
            //                 message_body += Markup("<br/>") + _("Special rewards were sent to the top competing users. The ranking for this challenge is:")
            //                 message_body += reward_message % {
            //                     'rank': 1,
            //                     'user_name': first_user.name,
            //                     'reward_name': challenge.reward_first_id.name,
            //                 }
            //             else:
            //                 message_body += _("Nobody reached the required conditions to receive special badges.")
            // 
            //             if second_user and challenge.reward_second_id:
            //                 challenge._reward_user(second_user, challenge.reward_second_id)
            //                 message_body += reward_message % {
            //                     'rank': 2,
            //                     'user_name': second_user.name,
            //                     'reward_name': challenge.reward_second_id.name,
            //                 }
            //             if third_user and challenge.reward_third_id:
            //                 challenge._reward_user(third_user, challenge.reward_third_id)
            //                 message_body += reward_message % {
            //                     'rank': 3,
            //                     'user_name': third_user.name,
            //                     'reward_name': challenge.reward_third_id.name,
            //                 }
            // 
            //         challenge.message_post(
            //             partner_ids=[user.partner_id.id for user in challenge.user_ids],
            //             body=message_body)
            //         if commit:
            //             commit()
            // 
            // return True
            */
            return default;
        }

        protected async Task<GamificationChallenge> ComputeUserCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py) ---
            // def _compute_user_count(self):
            // mapped_data = {}
            // if self.ids:
            //     query = """
            //         SELECT gamification_challenge_id, count(res_users_id)
            //           FROM gamification_challenge_users_rel rel
            //      LEFT JOIN res_users users
            //             ON users.id=rel.res_users_id AND users.active = TRUE
            //          WHERE gamification_challenge_id IN %s
            //       GROUP BY gamification_challenge_id
            //     """
            //     self.env.cr.execute(query, [tuple(self.ids)])
            //     mapped_data = dict(
            //         (challenge_id, user_count)
            //         for challenge_id, user_count in self.env.cr.fetchall()
            //     )
            // for challenge in self:
            //     challenge.user_count = mapped_data.get(challenge.id, 0)
            */
            return default;
        }

        protected async Task<GamificationChallenge> CronUpdateInternalAsync(object ids, object commit)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py) ---
            // def _cron_update(self, ids=False, commit=True):
            // """Daily cron check.
            // 
            // - Start planned challenges (in draft and with start_date = today)
            // - Create the missing goals (eg: modified the challenge to add lines)
            // - Update every running challenge
            // """
            // # in cron mode, will do intermediate commits
            // # cannot be replaced by a parameter because it is intended to impact side-effects of
            // # write operations
            // self = self.with_context(commit_gamification=commit)
            // # start scheduled challenges
            // planned_challenges = self.search([
            //     ('state', '=', 'draft'),
            //     ('start_date', '<=', fields.Date.today())
            // ])
            // if planned_challenges:
            //     planned_challenges.write({'state': 'inprogress'})
            // 
            // # close scheduled challenges
            // scheduled_challenges = self.search([
            //     ('state', '=', 'inprogress'),
            //     ('end_date', '<', fields.Date.today())
            // ])
            // if scheduled_challenges:
            //     scheduled_challenges.write({'state': 'done'})
            // 
            // records = self.browse(ids) if ids else self.search([('state', '=', 'inprogress')])
            // 
            // return records._update_all()
            */
            return default;
        }

        public async Task<GamificationChallenge> DiscardChallengeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py) ---
            // def discard_challenge(self):
            // """The user discard the suggested challenge"""
            // user = self.env.user
            // sudoed = self.sudo()
            // sudoed.message_post(body=_("%s has refused the challenge", user.name))
            // return sudoed.write({'invited_user_ids': (3, user.id)})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<GamificationChallenge> GenerateGoalsFromChallengeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py) ---
            // def _generate_goals_from_challenge(self):
            // """Generate the goals for each line and user.
            // 
            // If goals already exist for this line and user, the line is skipped. This
            // can be called after each change in the list of users or lines.
            // :param list(int) ids: the list of challenge concerned"""
            // 
            // Goals = self.env['gamification.goal']
            // for challenge in self:
            //     (start_date, end_date) = start_end_date_for_period(challenge.period, challenge.start_date, challenge.end_date)
            //     to_update = Goals.browse(())
            // 
            //     for line in challenge.line_ids:
            //         # there is potentially a lot of users
            //         # detect the ones with no goal linked to this line
            //         date_clause = ""
            //         query_params = [line.id]
            //         if start_date:
            //             date_clause += " AND g.start_date = %s"
            //             query_params.append(start_date)
            //         if end_date:
            //             date_clause += " AND g.end_date = %s"
            //             query_params.append(end_date)
            // 
            //         query = """SELECT u.id AS user_id
            //                      FROM res_users u
            //                 LEFT JOIN gamification_goal g
            //                        ON (u.id = g.user_id)
            //                     WHERE line_id = %s
            //                       {date_clause}
            //                 """.format(date_clause=date_clause)
            //         self.env.cr.execute(query, query_params)
            //         user_with_goal_ids = {it for [it] in self.env.cr._obj}
            // 
            //         participant_user_ids = set(challenge.user_ids.ids)
            //         user_squating_challenge_ids = user_with_goal_ids - participant_user_ids
            //         if user_squating_challenge_ids:
            //             # users that used to match the challenge
            //             Goals.search([
            //                 ('challenge_id', '=', challenge.id),
            //                 ('user_id', 'in', list(user_squating_challenge_ids))
            //             ]).unlink()
            // 
            //         values = {
            //             'definition_id': line.definition_id.id,
            //             'line_id': line.id,
            //             'target_goal': line.target_goal,
            //             'state': 'inprogress',
            //         }
            // 
            //         if start_date:
            //             values['start_date'] = start_date
            //         if end_date:
            //             values['end_date'] = end_date
            // 
            //         # the goal is initialised over the limit to make sure we will compute it at least once
            //         if line.condition == 'higher':
            //             values['current'] = min(line.target_goal - 1, 0)
            //         else:
            //             values['current'] = max(line.target_goal + 1, 0)
            // 
            //         if challenge.remind_update_delay:
            //             values['remind_update_delay'] = challenge.remind_update_delay
            // 
            //         for user_id in (participant_user_ids - user_with_goal_ids):
            //             values['user_id'] = user_id
            //             to_update |= Goals.create(values)
            // 
            //     to_update.update_goal()
            // 
            //     if self.env.context.get('commit_gamification'):
            //         self.env.cr.commit()
            // 
            // return True
            */
            return default;
        }

        protected async Task<GamificationChallenge> GetChallengerUsersInternalAsync(object domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py) ---
            // def _get_challenger_users(self, domain):
            // user_domain = ast.literal_eval(domain)
            // return self.env['res.users'].search(user_domain)
            */
            return default;
        }

        protected async Task<GamificationChallenge> GetNextReportDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py) ---
            // def _get_next_report_date(self):
            // """ Return the next report date based on the last report date and
            // report period.
            // """
            // for challenge in self:
            //     last = challenge.last_report_date
            //     offset = self.REPORT_OFFSETS.get(challenge.report_message_frequency)
            // 
            //     if offset:
            //         challenge.next_report_date = last + offset
            //     else:
            //         challenge.next_report_date = False
            */
            return default;
        }

        protected async Task<GamificationChallenge> GetReportTemplateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py) ---
            // def _get_report_template(self):
            // template = self.env.ref('gamification.simple_report_template', raise_if_not_found=False)
            // 
            // return template.id if template else False
            */
            return default;
        }

        protected async Task<GamificationChallenge> GetSerializedChallengeLinesInternalAsync(object user, object restrict_goals, object restrict_top)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py) ---
            // def _get_serialized_challenge_lines(self, user=(), restrict_goals=(), restrict_top=0):
            // """Return a serialised version of the goals information if the user has not completed every goal
            // 
            // :param user: user retrieving progress (False if no distinction,
            //              only for ranking challenges)
            // :param restrict_goals: compute only the results for this subset of
            //                        gamification.goal ids, if False retrieve every
            //                        goal of current running challenge
            // :param int restrict_top: for challenge lines where visibility_mode is
            //                          ``ranking``, retrieve only the best
            //                          ``restrict_top`` results and itself, if 0
            //                          retrieve all restrict_goal_ids has priority
            //                          over restrict_top
            // 
            // format list
            // # if visibility_mode == 'ranking'
            // {
            //     'name': <gamification.goal.description name>,
            //     'description': <gamification.goal.description description>,
            //     'condition': <reach condition {lower,higher}>,
            //     'computation_mode': <target computation {manually,count,sum,python}>,
            //     'monetary': <{True,False}>,
            //     'suffix': <value suffix>,
            //     'action': <{True,False}>,
            //     'display_mode': <{progress,boolean}>,
            //     'target': <challenge line target>,
            //     'own_goal_id': <gamification.goal id where user_id == uid>,
            //     'goals': [
            //         {
            //             'id': <gamification.goal id>,
            //             'rank': <user ranking>,
            //             'user_id': <res.users id>,
            //             'name': <res.users name>,
            //             'state': <gamification.goal state {draft,inprogress,reached,failed,canceled}>,
            //             'completeness': <percentage>,
            //             'current': <current value>,
            //         }
            //     ]
            // },
            // # if visibility_mode == 'personal'
            // {
            //     'id': <gamification.goal id>,
            //     'name': <gamification.goal.description name>,
            //     'description': <gamification.goal.description description>,
            //     'condition': <reach condition {lower,higher}>,
            //     'computation_mode': <target computation {manually,count,sum,python}>,
            //     'monetary': <{True,False}>,
            //     'suffix': <value suffix>,
            //     'action': <{True,False}>,
            //     'display_mode': <{progress,boolean}>,
            //     'target': <challenge line target>,
            //     'state': <gamification.goal state {draft,inprogress,reached,failed,canceled}>,
            //     'completeness': <percentage>,
            //     'current': <current value>,
            // }
            // """
            // Goals = self.env['gamification.goal']
            // (start_date, end_date) = start_end_date_for_period(self.period)
            // 
            // res_lines = []
            // for line in self.line_ids:
            //     line_data = {
            //         'name': line.definition_id.name,
            //         'description': line.definition_id.description,
            //         'condition': line.definition_id.condition,
            //         'computation_mode': line.definition_id.computation_mode,
            //         'monetary': line.definition_id.monetary,
            //         'suffix': line.definition_id.suffix,
            //         'action': True if line.definition_id.action_id else False,
            //         'display_mode': line.definition_id.display_mode,
            //         'target': line.target_goal,
            //     }
            //     domain = [
            //         ('line_id', '=', line.id),
            //         ('state', '!=', 'draft'),
            //     ]
            //     if restrict_goals:
            //         domain.append(('id', 'in', restrict_goals.ids))
            //     else:
            //         # if no subset goals, use the dates for restriction
            //         if start_date:
            //             domain.append(('start_date', '=', start_date))
            //         if end_date:
            //             domain.append(('end_date', '=', end_date))
            // 
            //     if self.visibility_mode == 'personal':
            //         if not user:
            //             raise exceptions.UserError(_("Retrieving progress for personal challenge without user information"))
            // 
            //         domain.append(('user_id', '=', user.id))
            // 
            //         goal = Goals.search_fetch(domain, ['current', 'completeness', 'state'], limit=1)
            //         if not goal:
            //             continue
            // 
            //         if goal.state != 'reached':
            //             return []
            //         line_data.update({
            //             fname: goal[fname]
            //             for fname in ['id', 'current', 'completeness', 'state']
            //         })
            //         res_lines.append(line_data)
            //         continue
            // 
            //     line_data['own_goal_id'] = False,
            //     line_data['goals'] = []
            //     goals = Goals.search(domain, order='id')
            //     if not goals:
            //         continue
            //     goals = goals.sorted(key=lambda goal: (
            //         -goal.completeness, -goal.current if line.condition == 'higher' else goal.current
            //     ))
            // 
            //     for ranking, goal in enumerate(goals):
            //         if user and goal.user_id == user:
            //             line_data['own_goal_id'] = goal.id
            //         elif restrict_top and ranking > restrict_top:
            //             # not own goal and too low to be in top
            //             continue
            // 
            //         line_data['goals'].append({
            //             'id': goal.id,
            //             'user_id': goal.user_id.id,
            //             'name': goal.user_id.name,
            //             'rank': ranking,
            //             'current': goal.current,
            //             'completeness': goal.completeness,
            //             'state': goal.state,
            //         })
            //     if len(goals) < 3:
            //         # display at least the top 3 in the results
            //         missing = 3 - len(goals)
            //         for ranking, mock_goal in enumerate([{'id': False,
            //                                               'user_id': False,
            //                                               'name': '',
            //                                               'current': 0,
            //                                               'completeness': 0,
            //                                               'state': False}] * missing,
            //                                             start=len(goals)):
            //             mock_goal['rank'] = ranking
            //             line_data['goals'].append(mock_goal)
            // 
            //     res_lines.append(line_data)
            // return res_lines
            */
            return default;
        }

        protected async Task<GamificationChallenge> GetTopNUsersInternalAsync(object n)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py) ---
            // def _get_topN_users(self, n):
            // """Get the top N users for a defined challenge
            // 
            // Ranking criterias:
            //     1. succeed every goal of the challenge
            //     2. total completeness of each goal (can be over 100)
            // 
            // Only users having reached every goal of the challenge will be returned
            // unless the challenge ``reward_failure`` is set, in which case any user
            // may be considered.
            // 
            // :returns: an iterable of exactly N records, either User objects or
            //           False if there was no user for the rank. There can be no
            //           False between two users (if users[k] = False then
            //           users[k+1] = False
            // """
            // Goals = self.env['gamification.goal']
            // (start_date, end_date) = start_end_date_for_period(self.period, self.start_date, self.end_date)
            // challengers = []
            // for user in self.user_ids:
            //     all_reached = True
            //     total_completeness = 0
            //     # every goal of the user for the running period
            //     goal_ids = Goals.search([
            //         ('challenge_id', '=', self.id),
            //         ('user_id', '=', user.id),
            //         ('start_date', '=', start_date),
            //         ('end_date', '=', end_date)
            //     ])
            //     for goal in goal_ids:
            //         if goal.state != 'reached':
            //             all_reached = False
            //         if goal.definition_condition == 'higher':
            //             # can be over 100
            //             total_completeness += (100.0 * goal.current / goal.target_goal) if goal.target_goal else 0
            //         elif goal.state == 'reached':
            //             # for lower goals, can not get percentage so 0 or 100
            //             total_completeness += 100
            // 
            //     challengers.append({'user': user, 'all_reached': all_reached, 'total_completeness': total_completeness})
            // 
            // challengers.sort(key=lambda k: (k['all_reached'], k['total_completeness']), reverse=True)
            // if not self.reward_failure:
            //     # only keep the fully successful challengers at the front, could
            //     # probably use filter since the successful ones are at the front
            //     challengers = itertools.takewhile(lambda c: c['all_reached'], challengers)
            // 
            // # append a tail of False, then keep the first N
            // challengers = itertools.islice(
            //     itertools.chain(
            //         (c['user'] for c in challengers),
            //         itertools.repeat(False),
            //     ), 0, n
            // )
            // 
            // return tuple(challengers)
            */
            return default;
        }

        protected async Task<GamificationChallenge> RecomputeChallengeUsersInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py) ---
            // def _recompute_challenge_users(self):
            // """Recompute the domain to add new users and remove the one no longer matching the domain"""
            // for challenge in self.filtered(lambda c: c.user_domain):
            //     current_users = challenge.user_ids
            //     new_users = self._get_challenger_users(challenge.user_domain)
            // 
            //     if current_users != new_users:
            //         challenge.user_ids = new_users
            // 
            // return True
            */
            return default;
        }

        public async Task<GamificationChallenge> ReportProgressAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py) ---
            // def action_report_progress(self):
            // """Manual report of a goal, does not influence automatic report frequency"""
            // for challenge in self:
            //     challenge.report_progress()
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<GamificationChallenge> ReportProgressAsync(Guid id, GamificationChallengeReportProgressRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py) ---
            // def report_progress(self, users=(), subset_goals=False):
            // """Post report about the progress of the goals
            // 
            // :param users: users that are concerned by the report. If False, will
            //               send the report to every user concerned (goal users and
            //               group that receive a copy). Only used for challenge with
            //               a visibility mode set to 'personal'.
            // :param subset_goals: goals to restrict the report
            // """
            // 
            // challenge = self
            // 
            // if challenge.visibility_mode == 'ranking':
            //     lines_boards = challenge._get_serialized_challenge_lines(restrict_goals=subset_goals)
            // 
            //     body_html = challenge.report_template_id.with_context(challenge_lines=lines_boards)._render_field('body_html', challenge.ids)[challenge.id]
            // 
            //     # send to every follower and participant of the challenge
            //     challenge.message_post(
            //         body=body_html,
            //         partner_ids=challenge.mapped('user_ids.partner_id.id'),
            //         subtype_xmlid='mail.mt_comment',
            //         email_layout_xmlid='mail.mail_notification_light',
            //         )
            //     if challenge.report_message_group_id:
            //         challenge.report_message_group_id.message_post(
            //             body=body_html,
            //             subtype_xmlid='mail.mt_comment')
            // 
            // else:
            //     # generate individual reports
            //     for user in (users or challenge.user_ids):
            //         lines = challenge._get_serialized_challenge_lines(user, restrict_goals=subset_goals)
            //         if not lines:
            //             continue
            // 
            //         body_html = challenge.report_template_id.with_user(user).with_context(challenge_lines=lines)._render_field('body_html', challenge.ids)[challenge.id]
            // 
            //         # notify message only to users, do not post on the challenge
            //         challenge.message_notify(
            //             body=body_html,
            //             partner_ids=[user.partner_id.id],
            //             subtype_xmlid='mail.mt_comment',
            //             email_layout_xmlid='mail.mail_notification_light',
            //         )
            //         if challenge.report_message_group_id:
            //             challenge.report_message_group_id.message_post(
            //                 body=body_html,
            //                 subtype_xmlid='mail.mt_comment',
            //                 email_layout_xmlid='mail.mail_notification_light',
            //             )
            // return challenge.write({'last_report_date': fields.Date.today()})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<GamificationChallenge> RewardUserInternalAsync(object user, object badge)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py) ---
            // def _reward_user(self, user, badge):
            // """Create a badge user and send the badge to him
            // 
            // :param user: the user to reward
            // :param badge: the concerned badge
            // """
            // return self.env['gamification.badge.user'].create({
            //     'user_id': user.id,
            //     'badge_id': badge.id,
            //     'challenge_id': self.id
            // })._send_badge()
            */
            return default;
        }

        public async Task<GamificationChallenge> StartAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py) ---
            // def action_start(self):
            // """Start a challenge"""
            // return self.write({'state': 'inprogress'})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<GamificationChallenge> UpdateAllInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py) ---
            // def _update_all(self):
            // """Update the challenges and related goals."""
            // if not self:
            //     return True
            // 
            // Goals = self.env['gamification.goal']
            // 
            // # include yesterday goals to update the goals that just ended
            // # exclude goals for users that have not interacted with the
            // # webclient since the last update or whose session is no longer
            // # valid.
            // yesterday = fields.Date.to_string(date.today() - timedelta(days=1))
            // self.env.cr.execute("""SELECT gg.id
            //                 FROM gamification_goal as gg
            //                 JOIN bus_presence as bp ON bp.user_id = gg.user_id
            //                WHERE gg.write_date <= bp.last_presence
            //                  AND bp.last_presence >= now() AT TIME ZONE 'UTC' - interval '%(session_lifetime)s seconds'
            //                  AND gg.closed IS NOT TRUE
            //                  AND gg.challenge_id IN %(challenge_ids)s
            //                  AND (gg.state = 'inprogress'
            //                       OR (gg.state = 'reached' AND gg.end_date >= %(yesterday)s))
            //               GROUP BY gg.id
            // """, {
            //     'session_lifetime': SESSION_LIFETIME,
            //     'challenge_ids': tuple(self.ids),
            //     'yesterday': yesterday
            // })
            // 
            // Goals.browse(goal_id for [goal_id] in self.env.cr.fetchall()).update_goal()
            // 
            // self._recompute_challenge_users()
            // self._generate_goals_from_challenge()
            // 
            // for challenge in self:
            //     if challenge.last_report_date != fields.Date.today():
            //         if challenge.next_report_date and fields.Date.today() >= challenge.next_report_date:
            //             challenge.report_progress()
            //         else:
            //             # goals closed but still opened at the last report date
            //             closed_goals_to_report = Goals.search([
            //                 ('challenge_id', '=', challenge.id),
            //                 ('start_date', '>=', challenge.last_report_date),
            //                 ('end_date', '<=', challenge.last_report_date)
            //             ])
            //             if closed_goals_to_report:
            //                 # some goals need a final report
            //                 challenge.report_progress(subset_goals=closed_goals_to_report)
            // 
            // self._check_challenge_reward()
            // return True
            */
            return default;
        }

        public async Task<GamificationChallenge> ViewUsersAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_challenge.py) ---
            // def action_view_users(self):
            // """ Redirect to the participants (users) list. """
            // action = self.env["ir.actions.actions"]._for_xml_id("base.action_res_users")
            // action['domain'] = [('id', 'in', self.user_ids.ids)]
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}