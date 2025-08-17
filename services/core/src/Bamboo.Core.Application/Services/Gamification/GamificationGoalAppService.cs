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
    [Module("Gamification", Depends = new[] { "mail" })]
    public class GamificationGoalAppService : GenericApplicationService<GamificationGoal>, IGamificationGoalAppService
    {

        public GamificationGoalAppService(IRepository<GamificationGoal, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public async Task<GamificationGoal> CancelAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_goal.py) ---
            // def action_cancel(self):
            // """Reset the completion after setting a goal as reached or failed.
            // 
            // This is only the current state, if the date and/or target criteria
            // match the conditions for a change of state, this will be applied at the
            // next goal update."""
            // return self.write({'state': 'inprogress'})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<GamificationGoal> CheckRemindDelayInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_goal.py) ---
            // def _check_remind_delay(self):
            // """Verify if a goal has not been updated for some time and send a
            // reminder message of needed.
            // 
            // :return: data to write on the goal object
            // """
            // if not (self.remind_update_delay and self.last_update):
            //     return {}
            // 
            // delta_max = timedelta(days=self.remind_update_delay)
            // last_update = fields.Date.from_string(self.last_update)
            // if date.today() - last_update < delta_max:
            //     return {}
            // 
            // # generate a reminder report
            // body_html = self.env.ref('gamification.email_template_goal_reminder')._render_field('body_html', self.ids, compute_lang=True)[self.id]
            // self.message_notify(
            //     body=body_html,
            //     partner_ids=[self.user_id.partner_id.id],
            //     subtype_xmlid='mail.mt_comment',
            //     email_layout_xmlid='mail.mail_notification_light',
            // )
            // 
            // return {'to_update': True}
            */
            return default;
        }

        protected async Task<GamificationGoal> ComputeColorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_goal.py) ---
            // def _compute_color(self):
            // """Set the color based on the goal's state and completion"""
            // for goal in self:
            //     goal.color = 0
            //     if (goal.end_date and goal.last_update):
            //         if (goal.end_date < goal.last_update) and (goal.state == 'failed'):
            //             goal.color = 2
            //         elif (goal.end_date < goal.last_update) and (goal.state == 'reached'):
            //             goal.color = 5
            */
            return default;
        }

        public async Task<GamificationGoal> FailAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_goal.py) ---
            // def action_fail(self):
            // """Set the state of the goal to failed.
            // 
            // A failed goal will be ignored in future checks."""
            // return self.write({'state': 'failed'})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<GamificationGoal> GetActionAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_goal.py) ---
            // def get_action(self):
            // """Get the ir.action related to update the goal
            // 
            // In case of a manual goal, should return a wizard to update the value
            // :return: action description in a dictionary
            // """
            // if self.definition_id.action_id:
            //     # open a the action linked to the goal
            //     action = self.definition_id.action_id.read()[0]
            // 
            //     if self.definition_id.res_id_field:
            //         current_user = self.env.user.with_user(self.env.user)
            //         action['res_id'] = safe_eval(self.definition_id.res_id_field, {
            //             'user': current_user
            //         })
            // 
            //         # if one element to display, should see it in form mode if possible
            //         action['views'] = [
            //             (view_id, mode)
            //             for (view_id, mode) in action['views']
            //             if mode == 'form'
            //         ] or action['views']
            //     return action
            // 
            // if self.computation_mode == 'manually':
            //     # open a wizard window to update the value manually
            //     action = {
            //         'name': _("Update %s", self.definition_id.name),
            //         'id': self.id,
            //         'type': 'ir.actions.act_window',
            //         'views': [[False, 'form']],
            //         'target': 'new',
            //         'context': {'default_goal_id': self.id, 'default_current': self.current},
            //         'res_model': 'gamification.goal.wizard'
            //     }
            //     return action
            // 
            // return False
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<GamificationGoal> GetCompletionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_goal.py) ---
            // def _get_completion(self):
            // """Return the percentage of completeness of the goal, between 0 and 100"""
            // for goal in self:
            //     if goal.definition_condition == 'higher':
            //         if goal.current >= goal.target_goal:
            //             goal.completeness = 100.0
            //         else:
            //             goal.completeness = round(100.0 * goal.current / goal.target_goal, 2) if goal.target_goal else 0
            //     elif goal.current < goal.target_goal:
            //         # a goal 'lower than' has only two values possible: 0 or 100%
            //         goal.completeness = 100.0
            //     else:
            //         goal.completeness = 0.0
            */
            return default;
        }

        protected async Task<GamificationGoal> GetWriteValuesInternalAsync(object new_value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_goal.py) ---
            // def _get_write_values(self, new_value):
            // """Generate values to write after recomputation of a goal score"""
            // if new_value == self.current:
            //     # avoid useless write if the new value is the same as the old one
            //     return {}
            // 
            // result = {'current': new_value}
            // if (self.definition_id.condition == 'higher' and new_value >= self.target_goal) \
            //   or (self.definition_id.condition == 'lower' and new_value <= self.target_goal):
            //     # success, do no set closed as can still change
            //     result['state'] = 'reached'
            // 
            // elif self.end_date and fields.Date.today() > self.end_date:
            //     # check goal failure
            //     result['state'] = 'failed'
            //     result['closed'] = True
            // 
            // return {self: result}
            */
            return default;
        }

        public async Task<GamificationGoal> ReachAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_goal.py) ---
            // def action_reach(self):
            // """Mark a goal as reached.
            // 
            // If the target goal condition is not met, the state will be reset to In
            // Progress at the next goal update until the end date."""
            // return self.write({'state': 'reached'})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<GamificationGoal> StartAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_goal.py) ---
            // def action_start(self):
            // """Mark a goal as started.
            // 
            // This should only be used when creating goals manually (in draft state)"""
            // self.write({'state': 'inprogress'})
            // return self.update_goal()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<GamificationGoal> UpdateGoalAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: gamification, FILE: gamification_goal.py) ---
            // def update_goal(self):
            // """Update the goals to recomputes values and change of states
            // 
            // If a manual goal is not updated for enough time, the user will be
            // reminded to do so (done only once, in 'inprogress' state).
            // If a goal reaches the target value, the status is set to reached
            // If the end date is passed (at least +1 day, time not considered) without
            // the target value being reached, the goal is set as failed."""
            // goals_by_definition = {}
            // for goal in self.with_context(prefetch_fields=False):
            //     goals_by_definition.setdefault(goal.definition_id, []).append(goal)
            // 
            // for definition, goals in goals_by_definition.items():
            //     goals_to_write = {}
            //     if definition.computation_mode == 'manually':
            //         for goal in goals:
            //             goals_to_write[goal] = goal._check_remind_delay()
            //     elif definition.computation_mode == 'python':
            //         # TODO batch execution
            //         for goal in goals:
            //             # execute the chosen method
            //             cxt = {
            //                 'object': goal,
            //                 'env': self.env,
            // 
            //                 'date': date,
            //                 'datetime': datetime,
            //                 'timedelta': timedelta,
            //                 'time': time,
            //             }
            //             code = definition.compute_code.strip()
            //             safe_eval(code, cxt, mode="exec", nocopy=True)
            //             # the result of the evaluated codeis put in the 'result' local variable, propagated to the context
            //             result = cxt.get('result')
            //             if isinstance(result, (float, int)):
            //                 goals_to_write.update(goal._get_write_values(result))
            //             else:
            //                 _logger.error(
            //                     "Invalid return content '%r' from the evaluation "
            //                     "of code for definition %s, expected a number",
            //                     result, definition.name)
            // 
            //     elif definition.computation_mode in ('count', 'sum'):  # count or sum
            //         Obj = self.env[definition.model_id.model]
            // 
            //         field_date_name = definition.field_date_id.name
            //         if definition.batch_mode:
            //             # batch mode, trying to do as much as possible in one request
            //             general_domain = ast.literal_eval(definition.domain)
            //             field_name = definition.batch_distinctive_field.name
            //             subqueries = {}
            //             for goal in goals:
            //                 start_date = field_date_name and goal.start_date or False
            //                 end_date = field_date_name and goal.end_date or False
            //                 subqueries.setdefault((start_date, end_date), {}).update({goal.id:safe_eval(definition.batch_user_expression, {'user': goal.user_id})})
            // 
            //             # the global query should be split by time periods (especially for recurrent goals)
            //             for (start_date, end_date), query_goals in subqueries.items():
            //                 subquery_domain = list(general_domain)
            //                 subquery_domain.append((field_name, 'in', list(set(query_goals.values()))))
            //                 if start_date:
            //                     subquery_domain.append((field_date_name, '>=', start_date))
            //                 if end_date:
            //                     subquery_domain.append((field_date_name, '<=', end_date))
            // 
            //                 if definition.computation_mode == 'count':
            //                     user_values = Obj._read_group(subquery_domain, groupby=[field_name], aggregates=['__count'])
            // 
            //                 else:  # sum
            //                     value_field_name = definition.field_id.name
            //                     user_values = Obj._read_group(subquery_domain, groupby=[field_name], aggregates=[f'{value_field_name}:sum'])
            // 
            //                 # user_values has format of _read_group: [(<partner>, <aggregate>), ...]
            //                 for goal in [g for g in goals if g.id in query_goals]:
            //                     for field_value, aggregate in user_values:
            //                         queried_value = field_value.id if isinstance(field_value, models.Model) else field_value
            //                         if queried_value == query_goals[goal.id]:
            //                             goals_to_write.update(goal._get_write_values(aggregate))
            // 
            //         else:
            //             field_name = definition.field_id.name
            //             field = Obj._fields.get(field_name)
            //             sum_supported = bool(field) and field.type in {'integer', 'float', 'monetary'}
            //             for goal in goals:
            //                 # eval the domain with user replaced by goal user object
            //                 domain = safe_eval(definition.domain, {'user': goal.user_id})
            // 
            //                 # add temporal clause(s) to the domain if fields are filled on the goal
            //                 if goal.start_date and field_date_name:
            //                     domain.append((field_date_name, '>=', goal.start_date))
            //                 if goal.end_date and field_date_name:
            //                     domain.append((field_date_name, '<=', goal.end_date))
            // 
            //                 if definition.computation_mode == 'sum' and sum_supported:
            //                     res = Obj._read_group(domain, [], [f'{field_name}:{definition.computation_mode}'])
            //                     new_value = res[0][0] or 0.0
            // 
            //                 else:  # computation mode = count
            //                     new_value = Obj.search_count(domain)
            // 
            //                 goals_to_write.update(goal._get_write_values(new_value))
            // 
            //     else:
            //         _logger.error(
            //             "Invalid computation mode '%s' in definition %s",
            //             definition.computation_mode, definition.name)
            // 
            //     for goal, values in goals_to_write.items():
            //         if not values:
            //             continue
            //         goal.write(values)
            //     if self.env.context.get('commit_gamification'):
            //         self.env.cr.commit()
            // return True
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}