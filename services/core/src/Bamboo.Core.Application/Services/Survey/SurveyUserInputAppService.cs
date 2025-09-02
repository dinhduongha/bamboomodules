using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
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
    [Module("Survey", Depends = new[] { "auth_signup", "http_routing", "mail", "web_tour", "gamification" })]
    public class SurveyUserInputAppService : GenericApplicationService<SurveyUserInput>, ISurveyUserInputAppService
    {
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        public SurveyUserInputAppService(IRepository<SurveyUserInput, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        protected async Task<SurveyUserInput> CheckForFailedAttemptInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides_survey, FILE: survey_user.py) ---
            // def _check_for_failed_attempt(self):
            // """ If the user fails their last attempt at a course certification,
            // we remove them from the members of the course (and they have to enroll again).
            // They receive an email in the process notifying them of their failure and suggesting
            // they enroll to the course again.
            // 
            // The purpose is to have a 'certification flow' where the user can re-purchase the
            // certification when they have failed it."""
            // 
            // if self:
            //     user_inputs = self.search([
            //         ('id', 'in', self.ids),
            //         ('state', '=', 'done'),
            //         ('scoring_success', '=', False),
            //         ('slide_partner_id', '!=', False)
            //     ])
            // 
            //     if user_inputs:
            //         for user_input in user_inputs:
            //             removed_memberships_per_partner = {}
            //             if user_input.survey_id._has_attempts_left(user_input.partner_id, user_input.email, user_input.invite_token):
            //                 # skip if user still has attempts left
            //                 continue
            // 
            //             self.env.ref('website_slides_survey.mail_template_user_input_certification_failed').send_mail(
            //                 user_input.id, email_layout_xmlid="mail.mail_notification_light"
            //             )
            // 
            //             removed_memberships = removed_memberships_per_partner.get(
            //                 user_input.partner_id,
            //                 self.env['slide.channel']
            //             )
            //             removed_memberships |= user_input.slide_partner_id.channel_id
            //             removed_memberships_per_partner[user_input.partner_id] = removed_memberships
            // 
            //         for partner_id, removed_memberships in removed_memberships_per_partner.items():
            //             removed_memberships._remove_membership(partner_id.ids)
            */
            return default;
        }

        protected async Task<SurveyUserInput> ClearInactiveConditionalAnswersInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py) ---
            // def _clear_inactive_conditional_answers(self):
            // """
            // Clean eventual answers on conditional questions that should not have been displayed to user.
            // This method is used mainly for page per question survey, a similar method does the same treatment
            // at client side for the other survey layouts.
            // E.g.: if depending answer was uncheck after answering conditional question, we need to clear answers
            //       of that conditional question, for two reasons:
            //       - ensure correct scoring
            //       - if the selected answer triggers another question later in the survey, if the answer is not cleared,
            //         a question that should not be displayed to the user will be.
            // 
            // TODO DBE: Maybe this can be the only cleaning method, even for section_per_page or one_page where
            // conditional questions are, for now, cleared in JS directly. But this can be annoying if user typed a long
            // answer, changed their mind unchecking depending answer and changed again their mind by rechecking the depending
            // answer -> For now, the long answer will be lost. If we use this as the master cleaning method,
            // long answer will be cleared only during submit.
            // """
            // inactive_questions = self._get_inactive_conditional_questions()
            // 
            // # delete user.input.line on question that should not be answered.
            // answers_to_delete = self.user_input_line_ids.filtered(lambda answer: answer.question_id in inactive_questions)
            // answers_to_delete.unlink()
            */
            return default;
        }

        protected async Task<SurveyUserInput> ComputeAttemptsInfoInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py) ---
            // def _compute_attempts_info(self):
            // attempts_to_compute = self.filtered(
            //     lambda user_input: user_input.state == 'done' and not user_input.test_entry and user_input.survey_id.is_attempts_limited
            // )
            // 
            // for user_input in (self - attempts_to_compute):
            //     user_input.attempts_count = 1
            //     user_input.attempts_number = 1
            // 
            // if attempts_to_compute:
            //     self.flush_model(['email', 'invite_token', 'partner_id', 'state', 'survey_id', 'test_entry'])
            // 
            //     self.env.cr.execute("""
            //         SELECT user_input.id,
            //                COUNT(all_attempts_user_input.id) AS attempts_count,
            //                COUNT(CASE WHEN all_attempts_user_input.id < user_input.id THEN all_attempts_user_input.id END) + 1 AS attempts_number
            //         FROM survey_user_input user_input
            //         LEFT OUTER JOIN survey_user_input all_attempts_user_input
            //         ON user_input.survey_id = all_attempts_user_input.survey_id
            //         AND all_attempts_user_input.state = 'done'
            //         AND all_attempts_user_input.test_entry IS NOT TRUE
            //         AND (user_input.invite_token IS NULL OR user_input.invite_token = all_attempts_user_input.invite_token)
            //         AND (user_input.partner_id = all_attempts_user_input.partner_id OR user_input.email = all_attempts_user_input.email)
            //         WHERE user_input.id IN %s
            //         GROUP BY user_input.id;
            //     """, (tuple(attempts_to_compute.ids),))
            // 
            //     attempts_number_results = self.env.cr.dictfetchall()
            // 
            //     attempts_number_results = {
            //         attempts_number_result['id']: {
            //             'attempts_number': attempts_number_result['attempts_number'],
            //             'attempts_count': attempts_number_result['attempts_count'],
            //         }
            //         for attempts_number_result in attempts_number_results
            //     }
            // 
            //     for user_input in attempts_to_compute:
            //         attempts_number_result = attempts_number_results.get(user_input.id, {})
            //         user_input.attempts_number = attempts_number_result.get('attempts_number', 1)
            //         user_input.attempts_count = attempts_number_result.get('attempts_count', 1)
            */
            return default;
        }

        protected async Task<SurveyUserInput> ComputeQuestionTimeLimitReachedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py) ---
            // def _compute_question_time_limit_reached(self):
            // """ Checks that the user_input is not exceeding the question's time limit.
            // Only used in the context of survey sessions. """
            // for user_input in self:
            //     if user_input.is_session_answer and user_input.survey_id.session_question_start_time:
            //         start_time = user_input.survey_id.session_question_start_time
            //         time_limit = user_input.survey_id.session_question_id.time_limit
            //         user_input.question_time_limit_reached = user_input.survey_id.session_question_id.is_time_limited and \
            //             fields.Datetime.now() >= start_time + relativedelta(seconds=time_limit)
            //     else:
            //         user_input.question_time_limit_reached = False
            */
            return default;
        }

        protected async Task<SurveyUserInput> ComputeScoringSuccessInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py) ---
            // def _compute_scoring_success(self):
            // for user_input in self:
            //     user_input.scoring_success = user_input.scoring_percentage >= user_input.survey_id.scoring_success_min
            */
            return default;
        }

        protected async Task<SurveyUserInput> ComputeScoringValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py) ---
            // def _compute_scoring_values(self):
            // for user_input in self:
            //     # sum(multi-choice question scores) + sum(simple answer_type scores)
            //     total_possible_score = 0
            //     for question in user_input.predefined_question_ids:
            //         if question.question_type == 'simple_choice':
            //             total_possible_score += max([score for score in question.mapped('suggested_answer_ids.answer_score') if score > 0], default=0)
            //         elif question.question_type == 'multiple_choice':
            //             total_possible_score += sum(score for score in question.mapped('suggested_answer_ids.answer_score') if score > 0)
            //         elif question.is_scored_question:
            //             total_possible_score += question.answer_score
            // 
            //     if total_possible_score == 0:
            //         user_input.scoring_percentage = 0
            //         user_input.scoring_total = 0
            //     else:
            //         score_total = sum(user_input.user_input_line_ids.mapped('answer_score'))
            //         user_input.scoring_total = score_total
            //         score_percentage = (score_total / total_possible_score) * 100
            //         user_input.scoring_percentage = round(score_percentage, 2) if score_percentage > 0 else 0
            */
            return default;
        }

        protected async Task<SurveyUserInput> ComputeSurveyTimeLimitReachedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py) ---
            // def _compute_survey_time_limit_reached(self):
            // """ Checks that the user_input is not exceeding the survey's time limit. """
            // for user_input in self:
            //     if not user_input.is_session_answer and user_input.start_datetime:
            //         start_time = user_input.start_datetime
            //         time_limit = user_input.survey_id.time_limit
            //         user_input.survey_time_limit_reached = user_input.survey_id.is_time_limited and \
            //             fields.Datetime.now() >= start_time + relativedelta(minutes=time_limit)
            //     else:
            //         user_input.survey_time_limit_reached = False
            */
            return default;
        }

        public override async Task<SurveyUserInput> CreateAsync(SurveyUserInput entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     if 'predefined_question_ids' not in vals:
            //         suvey_id = vals.get('survey_id', self.env.context.get('default_survey_id'))
            //         survey = self.env['survey.survey'].browse(suvey_id)
            //         vals['predefined_question_ids'] = [(6, 0, survey._prepare_user_input_predefined_questions().ids)]
            // return super(SurveyUserInput, self).create(vals_list)
            --- ODOO METHOD SOURCE (MODULE: website_slides_survey, FILE: survey_user.py) ---
            // def create(self, vals_list):
            // records = super(SurveyUserInput, self).create(vals_list)
            // records._check_for_failed_attempt()
            // return records
            */
            return await base.CreateAsync(entity, fields);
        }

        protected async Task<SurveyUserInput> GenerateInviteTokenInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py) ---
            // def _generate_invite_token(self):
            // return str(uuid.uuid4())
            */
            return default;
        }

        protected async Task<SurveyUserInput> GetConditionalValuesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py) ---
            // def _get_conditional_values(self):
            // """ For survey containing conditional questions, we need a triggered_questions_by_answer map that contains
            //         {key: answer, value: the question that the answer triggers, if selected},
            //  The idea is to be able to verify, on every answer check, if this answer is triggering the display
            //  of another question.
            //  If answer is not in the conditional map:
            //     - nothing happens.
            //  If the answer is in the conditional map:
            //     - If we are in ONE PAGE survey : (handled at CLIENT side)
            //         -> display immediately the depending question
            //     - If we are in PAGE PER SECTION : (handled at CLIENT side)
            //         - If related question is on the same page :
            //             -> display immediately the depending question
            //         - If the related question is not on the same page :
            //             -> keep the answers in memory and check at next page load if the depending question is in there and
            //                display it, if so.
            //     - If we are in PAGE PER QUESTION : (handled at SERVER side)
            //         -> During submit, determine which is the next question to display getting the next question
            //            that is the next in sequence and that is either not triggered by another question's answer, or that
            //            is triggered by an already selected answer.
            //  To do all this, we need to return:
            //     - triggering_answers_by_question: dict -> for a given question, the answers that triggers it
            //         Used mainly to ease template rendering
            //     - triggered_questions_by_answer: dict -> for a given answer, list of questions triggered by this answer;
            //         Used mainly for dynamic show/hide behaviour at client side
            //     - list of all selected answers: [answer_id1, answer_id2, ...] (for survey reloading, otherwise, this list is
            //       updated at client side)
            // """
            // triggering_answers_by_question = {}
            // triggered_questions_by_answer = {}
            // # Ignore conditional configuration if randomised questions selection
            // if self.survey_id.questions_selection != 'random':
            //     triggering_answers_by_question, triggered_questions_by_answer = self.survey_id._get_conditional_maps()
            // selected_answers = self._get_selected_suggested_answers()
            // 
            // return triggering_answers_by_question, triggered_questions_by_answer, selected_answers
            */
            return default;
        }

        protected async Task<SurveyUserInput> GetInactiveConditionalQuestionsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py) ---
            // def _get_inactive_conditional_questions(self):
            // triggering_answers_by_question, _, selected_answers = self._get_conditional_values()
            // 
            // # get questions that should not be answered
            // inactive_questions = self.env['survey.question']
            // for question, triggering_answers in triggering_answers_by_question.items():
            //     if triggering_answers and not triggering_answers & selected_answers:
            //         inactive_questions |= question
            // return inactive_questions
            */
            return default;
        }

        protected async Task<SurveyUserInput> GetLineAnswerValuesInternalAsync(object question, object answer, object answer_type)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py) ---
            // def _get_line_answer_values(self, question, answer, answer_type):
            // vals = {
            //     'user_input_id': self.id,
            //     'question_id': question.id,
            //     'skipped': False,
            //     'answer_type': answer_type,
            // }
            // if not answer or (isinstance(answer, str) and not answer.strip()):
            //     vals.update(answer_type=None, skipped=True)
            //     return vals
            // 
            // if answer_type == 'suggestion':
            //     vals['suggested_answer_id'] = int(answer)
            // elif answer_type == 'numerical_box':
            //     vals['value_numerical_box'] = float(answer)
            // elif answer_type == 'scale':
            //     vals['value_scale'] = int(answer)
            // else:
            //     vals['value_%s' % answer_type] = answer
            // return vals
            */
            return default;
        }

        protected async Task<SurveyUserInput> GetLineCommentValuesInternalAsync(object question, object comment)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py) ---
            // def _get_line_comment_values(self, question, comment):
            // return {
            //     'user_input_id': self.id,
            //     'question_id': question.id,
            //     'skipped': False,
            //     'answer_type': 'char_box',
            //     'value_char_box': comment,
            // }
            */
            return default;
        }

        protected async Task<SurveyUserInput> GetNextSkippedPageOrQuestionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py) ---
            // def _get_next_skipped_page_or_question(self):
            // """Get next skipped question or page in case the option 'can_go_back' is set on the survey
            // It loops to the first skipped question or page if 'last_displayed_page_id' is the last
            // skipped question or page."""
            // self.ensure_one()
            // skipped_mandatory_answer_ids = self.user_input_line_ids.filtered(
            //     lambda answer: answer.skipped and answer.question_id.constr_mandatory)
            // 
            // if not skipped_mandatory_answer_ids:
            //     return self.env['survey.question']
            // 
            // page_or_question_key = 'page_id' if self.survey_id.questions_layout == 'page_per_section' else 'question_id'
            // page_or_question_ids = skipped_mandatory_answer_ids.mapped(page_or_question_key).sorted()
            // 
            // if self.last_displayed_page_id not in page_or_question_ids\
            //     or self.last_displayed_page_id == page_or_question_ids[-1]:
            //     return page_or_question_ids[0]
            // 
            // current_page_index = page_or_question_ids.ids.index(self.last_displayed_page_id.id)
            // return page_or_question_ids[current_page_index + 1]
            */
            return default;
        }

        protected async Task<SurveyUserInput> GetPrintQuestionsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py) ---
            // def _get_print_questions(self):
            // """ Get the questions to display : the ones that should have been answered = active questions
            //     In case of session, active questions are based on most voted answers
            // :return: active survey.question browse records
            // """
            // survey = self.survey_id
            // if self.is_session_answer:
            //     most_voted_answers = survey._get_session_most_voted_answers()
            //     inactive_questions = most_voted_answers._get_inactive_conditional_questions()
            // else:
            //     inactive_questions = self._get_inactive_conditional_questions()
            // return survey.question_ids - inactive_questions
            */
            return default;
        }

        public async Task<SurveyUserInput> GetPrintUrlAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py) ---
            // def get_print_url(self):
            // self.ensure_one()
            // return '%s?answer_token=%s' % (self.survey_id.get_print_url(), self.access_token)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<SurveyUserInput> GetSelectedSuggestedAnswersInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py) ---
            // def _get_selected_suggested_answers(self):
            // """
            // For now, only simple and multiple choices question type are handled by the conditional questions feature.
            // Mapping all the suggested answers selected by the user will also include answers from matrix question type,
            // Those ones won't be used.
            // Maybe someday, conditional questions feature will be extended to work with matrix question.
            // :return: all the suggested answer selected by the user.
            // """
            // return self.mapped('user_input_line_ids.suggested_answer_id')
            */
            return default;
        }

        protected async Task<SurveyUserInput> GetSkippedQuestionsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py) ---
            // def _get_skipped_questions(self):
            // self.ensure_one()
            // 
            // return self.user_input_line_ids.filtered(
            //     lambda answer: answer.skipped and answer.question_id.constr_mandatory).question_id
            */
            return default;
        }

        public async Task<SurveyUserInput> GetStartUrlAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py) ---
            // def get_start_url(self):
            // self.ensure_one()
            // return '%s?answer_token=%s' % (self.survey_id.get_start_url(), self.access_token)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<SurveyUserInput> IsLastSkippedPageOrQuestionInternalAsync(object page_or_question)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py) ---
            // def _is_last_skipped_page_or_question(self, page_or_question):
            // """In case of a submitted survey tells if the question or page is the last
            // skipped page or question.
            // 
            // This is used to :
            // 
            // - Display a Submit button if the actual question is the last skipped question.
            // - Avoid displaying a Submit button on the last survey question if there are
            //   still skipped questions before.
            // - Avoid displaying the next page if submitting the latest skipped question.
            // 
            // :param page_or_question: page if survey's layout is page_per_section, question if page_per_question.
            // """
            // if self.survey_id.questions_layout == 'one_page':
            //     return True
            // skipped = self._get_skipped_questions()
            // if not skipped:
            //     return True
            // if self.survey_id.questions_layout == 'page_per_section':
            //     skipped = skipped.page_id
            // return skipped == page_or_question
            */
            return default;
        }

        protected async Task<SurveyUserInput> MarkDoneInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment_survey, FILE: survey_user_input.py) ---
            // def _mark_done(self):
            // odoobot = self.env.ref('base.partner_root')
            // for user_input in self:
            //     if user_input.applicant_id:
            //         body = _('The applicant "%s" has finished the survey.', user_input.applicant_id.partner_name)
            //         user_input.applicant_id.message_post(body=body, author_id=odoobot.id)
            // return super()._mark_done()
            --- ODOO METHOD SOURCE (MODULE: hr_skills_survey, FILE: survey_user.py) ---
            // def _mark_done(self):
            // """ Will add certification to employee's resume if
            // - The survey is a certification
            // - The user is linked to an employee
            // - The user succeeded the test """
            // 
            // super(SurveyUserInput, self)._mark_done()
            // 
            // certification_user_inputs = self.filtered(lambda user_input: user_input.survey_id.certification and user_input.scoring_success)
            // user_inputs_by_partner = certification_user_inputs.grouped('partner_id')
            // employees = self.env['hr.employee'].search(
            //     [('user_id.partner_id', 'in', certification_user_inputs.partner_id.ids)])
            // resume_lines = self.env['hr.resume.line'].search(
            //     expression.OR([
            //         expression.AND([
            //             [('employee_id', '=', employee.id)],
            //             [('survey_id', 'in', user_inputs_by_partner[employee.user_id.partner_id].survey_id.ids)]])
            //         for employee in employees
            //     ]))
            // resume_survey_by_ids = resume_lines.grouped(
            //     lambda resume_line: (resume_line.employee_id, resume_line.survey_id))
            // line_type = self.env.ref('hr_skills_survey.resume_type_certification', raise_if_not_found=False)
            // 
            // lines_to_create = []
            // today = fields.Date.today()
            // for employee in employees:
            //     for user_input in user_inputs_by_partner[employee.user_id.partner_id]:
            //         survey = user_input.survey_id
            //         date_start = today
            //         validity_month = survey.certification_validity_months
            //         resume_line_vals = {
            //             'employee_id': employee.id,
            //             'name': survey.title,
            //             'date_start': date_start,
            //             'date_end': date_start + relativedelta(months=validity_month) if validity_month else False,
            //             'description': html2plaintext(survey.description) if survey.description else '',
            //             'line_type_id': line_type.id if line_type else False,
            //             'display_type': 'certification',
            //             'survey_id': survey.id,
            //         }
            //         if existing_resume_survey := resume_survey_by_ids.get((employee, survey)):
            //             existing_resume_survey.write(resume_line_vals)
            //         else:
            //             lines_to_create.append(resume_line_vals)
            // self.env['hr.resume.line'].create(lines_to_create)
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py) ---
            // def _mark_done(self):
            // """ This method will:
            // 1. mark the state as 'done'
            // 2. send the certification email with attached document if
            // - The survey is a certification
            // - It has a certification_mail_template_id set
            // - The user succeeded the test
            // 3. Notify survey subtype subscribers of the newly completed input
            // Will also run challenge Cron to give the certification badge if any."""
            // self.write({
            //     'end_datetime': fields.Datetime.now(),
            //     'state': 'done',
            // })
            // 
            // Challenge_sudo = self.env['gamification.challenge'].sudo()
            // badge_ids = []
            // self._notify_new_participation_subscribers()
            // for user_input in self:
            //     if user_input.survey_id.certification and user_input.scoring_success:
            //         if user_input.survey_id.certification_mail_template_id and not user_input.test_entry:
            //             user_input.survey_id.certification_mail_template_id.send_mail(user_input.id, email_layout_xmlid="mail.mail_notification_light")
            //         if user_input.survey_id.certification_give_badge:
            //             badge_ids.append(user_input.survey_id.certification_badge_id.id)
            // 
            //     # Update predefined_question_id to remove inactive questions
            //     user_input.predefined_question_ids -= user_input._get_inactive_conditional_questions()
            // 
            // if badge_ids:
            //     challenges = Challenge_sudo.search([('reward_id', 'in', badge_ids)])
            //     if challenges:
            //         Challenge_sudo._cron_update(ids=challenges.ids, commit=False)
            */
            return default;
        }

        protected async Task<SurveyUserInput> MarkInProgressInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py) ---
            // def _mark_in_progress(self):
            // """ marks the state as 'in_progress' and updates the start_datetime accordingly. """
            // self.write({
            //     'start_datetime': fields.Datetime.now(),
            //     'state': 'in_progress'
            // })
            */
            return default;
        }

        protected async Task<SurveyUserInput> MessageGetSuggestedRecipientsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py) ---
            // def _message_get_suggested_recipients(self):
            // recipients = super()._message_get_suggested_recipients()
            // if self.partner_id:
            //     self._message_add_suggested_recipient(
            //         recipients,
            //         partner=self.partner_id,
            //         reason=_('Survey Participant')
            //     )
            // return recipients
            */
            return default;
        }

        protected async Task<SurveyUserInput> MultipleChoiceQuestionAnswerResultInternalAsync(object user_input_lines, object question_correct_suggested_answers)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py) ---
            // def _multiple_choice_question_answer_result(self, user_input_lines, question_correct_suggested_answers):
            // correct_user_input_lines = user_input_lines.filtered(lambda line: line.answer_is_correct and not line.skipped).mapped('suggested_answer_id')
            // incorrect_user_input_lines = user_input_lines.filtered(lambda line: not line.answer_is_correct and not line.skipped)
            // if question_correct_suggested_answers and correct_user_input_lines == question_correct_suggested_answers:
            //     return 'correct'
            // elif correct_user_input_lines and correct_user_input_lines < question_correct_suggested_answers:
            //     return 'partial'
            // elif not correct_user_input_lines and incorrect_user_input_lines:
            //     return 'incorrect'
            // else:
            //     return 'skipped'
            */
            return default;
        }

        protected async Task<SurveyUserInput> NotifyNewParticipationSubscribersInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py) ---
            // def _notify_new_participation_subscribers(self):
            // subtype_id = self.env.ref('survey.mt_survey_survey_user_input_completed', raise_if_not_found=False)
            // if not self.ids or not subtype_id:
            //     return
            // author_id = self.env.ref('base.partner_root').id if self.env.user.is_public else self.env.user.partner_id.id
            // # Only post if there are any followers
            // recipients_data = self.env['mail.followers']._get_recipient_data(self.survey_id, 'notification', subtype_id.id)
            // followed_survey_ids = [survey_id for survey_id, followers in recipients_data.items() if followers]
            // for user_input in self.filtered(lambda user_input_: user_input_.survey_id.id in followed_survey_ids):
            //     survey_title = user_input.survey_id.title
            //     if user_input.partner_id:
            //         body = _(
            //             '%(participant)s just participated in "%(survey_title)s".',
            //             participant=user_input.partner_id.display_name,
            //             survey_title=survey_title,
            //         )
            //     else:
            //         body = _('Someone just participated in "%(survey_title)s".', survey_title=survey_title)
            // 
            //     user_input.message_post(author_id=author_id, body=body, subtype_xmlid='survey.mt_survey_user_input_completed')
            */
            return default;
        }

        protected async Task<SurveyUserInput> PrepareStatisticsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py) ---
            // def _prepare_statistics(self):
            // """ Prepares survey.user_input's statistics to display various charts on the frontend.
            // Returns a structure containing answers statistics "by section" and "totals" for every input in self.
            // 
            // e.g returned structure:
            // {
            //     survey.user_input(1,): {
            //         'by_section': {
            //             'Uncategorized': {
            //                 'question_count': 2,
            //                 'correct': 2,
            //                 'partial': 0,
            //                 'incorrect': 0,
            //                 'skipped': 0,
            //             },
            //             'Mathematics': {
            //                 'question_count': 3,
            //                 'correct': 1,
            //                 'partial': 1,
            //                 'incorrect': 0,
            //                 'skipped': 1,
            //             },
            //             'Geography': {
            //                 'question_count': 4,
            //                 'correct': 2,
            //                 'partial': 0,
            //                 'incorrect': 2,
            //                 'skipped': 0,
            //             }
            //         },
            //         'totals' [{
            //             'text': 'Correct',
            //             'count': 5,
            //         }, {
            //             'text': 'Partially',
            //             'count': 1,
            //         }, {
            //             'text': 'Incorrect',
            //             'count': 2,
            //         }, {
            //             'text': 'Unanswered',
            //             'count': 1,
            //         }]
            //     }
            // }"""
            // res = dict((user_input, {
            //     'by_section': {}
            // }) for user_input in self)
            // 
            // scored_questions = self.mapped('predefined_question_ids').filtered(lambda question: question.is_scored_question)
            // 
            // for question in scored_questions:
            //     if question.question_type == 'simple_choice':
            //         question_incorrect_scored_answers = question.suggested_answer_ids.filtered(lambda answer: not answer.is_correct and answer.answer_score > 0)
            // 
            //     if question.question_type in ['simple_choice', 'multiple_choice']:
            //         question_correct_suggested_answers = question.suggested_answer_ids.filtered(lambda answer: answer.is_correct)
            // 
            //     question_section = question.page_id.title or _('Uncategorized')
            //     for user_input in self:
            //         user_input_lines = user_input.user_input_line_ids.filtered(lambda line:
            //             line.question_id == question and (line.answer_type != 'char_box' or question.comment_count_as_answer))
            //         if question.question_type == 'simple_choice':
            //             answer_result_key = self._simple_choice_question_answer_result(user_input_lines, question_correct_suggested_answers, question_incorrect_scored_answers)
            //         elif question.question_type == 'multiple_choice':
            //             answer_result_key = self._multiple_choice_question_answer_result(user_input_lines, question_correct_suggested_answers)
            //         else:
            //             answer_result_key = self._simple_question_answer_result(user_input_lines)
            // 
            //         if question_section not in res[user_input]['by_section']:
            //             res[user_input]['by_section'][question_section] = {
            //                 'question_count': 0,
            //                 'correct': 0,
            //                 'partial': 0,
            //                 'incorrect': 0,
            //                 'skipped': 0,
            //             }
            // 
            //         res[user_input]['by_section'][question_section]['question_count'] += 1
            //         res[user_input]['by_section'][question_section][answer_result_key] += 1
            // 
            // for user_input in self:
            //     correct_count = 0
            //     partial_count = 0
            //     incorrect_count = 0
            //     skipped_count = 0
            // 
            //     for section_counts in res[user_input]['by_section'].values():
            //         correct_count += section_counts.get('correct', 0)
            //         partial_count += section_counts.get('partial', 0)
            //         incorrect_count += section_counts.get('incorrect', 0)
            //         skipped_count += section_counts.get('skipped', 0)
            // 
            //     res[user_input]['totals'] = [
            //         {'text': _("Correct"), 'count': correct_count},
            //         {'text': _("Partially"), 'count': partial_count},
            //         {'text': _("Incorrect"), 'count': incorrect_count},
            //         {'text': _("Unanswered"), 'count': skipped_count}
            //     ]
            // 
            // return res
            */
            return default;
        }

        public async Task<SurveyUserInput> PrintAnswersAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py) ---
            // def action_print_answers(self):
            // """ Open the website page with the survey form """
            // self.ensure_one()
            // return {
            //     'type': 'ir.actions.act_url',
            //     'name': "View Answers",
            //     'target': 'self',
            //     'url': '/survey/print/%s?answer_token=%s' % (self.survey_id.access_token, self.access_token)
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<SurveyUserInput> RedirectToAttemptsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py) ---
            // def action_redirect_to_attempts(self):
            // self.ensure_one()
            // 
            // action = self.env['ir.actions.act_window']._for_xml_id('survey.action_survey_user_input')
            // context = dict(self.env.context or {})
            // 
            // context['create'] = False
            // context['search_default_survey_id'] = self.survey_id.id
            // context['search_default_group_by_survey'] = False
            // if self.partner_id:
            //     context['search_default_partner_id'] = self.partner_id.id
            // elif self.email:
            //     context['search_default_email'] = self.email
            // 
            // action['context'] = context
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<SurveyUserInput> ResendAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py) ---
            // def action_resend(self):
            // partners = self.env['res.partner']
            // emails = []
            // for user_answer in self:
            //     if user_answer.partner_id:
            //         partners |= user_answer.partner_id
            //     elif user_answer.email:
            //         emails.append(user_answer.email)
            // 
            // return self.survey_id.with_context(
            //     default_existing_mode='resend',
            //     default_partner_ids=partners.ids,
            //     default_emails=','.join(emails)
            // ).action_send_survey()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<SurveyUserInput> SaveLineChoiceInternalAsync(object question, object old_answers, object answers, object comment)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py) ---
            // def _save_line_choice(self, question, old_answers, answers, comment):
            // if not (isinstance(answers, list)):
            //     answers = [answers]
            // 
            // if not answers:
            //     # add a False answer to force saving a skipped line
            //     # this will make this question correctly considered as skipped in statistics
            //     answers = [False]
            // 
            // vals_list = []
            // 
            // if question.question_type == 'simple_choice':
            //     if not question.comment_count_as_answer or not question.comments_allowed or not comment:
            //         vals_list = [self._get_line_answer_values(question, answer, 'suggestion') for answer in answers]
            // elif question.question_type == 'multiple_choice':
            //     vals_list = [self._get_line_answer_values(question, answer, 'suggestion') for answer in answers]
            // 
            // if comment:
            //     vals_list.append(self._get_line_comment_values(question, comment))
            // 
            // old_answers.sudo().unlink()
            // return self.env['survey.user_input.line'].create(vals_list)
            */
            return default;
        }

        protected async Task<SurveyUserInput> SaveLineMatrixInternalAsync(object question, object old_answers, object answers, object comment)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py) ---
            // def _save_line_matrix(self, question, old_answers, answers, comment):
            // vals_list = []
            // 
            // if not answers and question.matrix_row_ids:
            //     # add a False answer to force saving a skipped line
            //     # this will make this question correctly considered as skipped in statistics
            //     answers = {question.matrix_row_ids[0].id: [False]}
            // 
            // if answers:
            //     for row_key, row_answer in answers.items():
            //         for answer in row_answer:
            //             vals = self._get_line_answer_values(question, answer, 'suggestion')
            //             vals['matrix_row_id'] = int(row_key)
            //             vals_list.append(vals.copy())
            // 
            // if comment:
            //     vals_list.append(self._get_line_comment_values(question, comment))
            // 
            // old_answers.sudo().unlink()
            // return self.env['survey.user_input.line'].create(vals_list)
            */
            return default;
        }

        protected async Task<SurveyUserInput> SaveLineSimpleAnswerInternalAsync(object question, object old_answers, object answer)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py) ---
            // def _save_line_simple_answer(self, question, old_answers, answer):
            // vals = self._get_line_answer_values(question, answer, question.question_type)
            // if old_answers:
            //     old_answers.write(vals)
            //     return old_answers
            // else:
            //     return self.env['survey.user_input.line'].create(vals)
            */
            return default;
        }

        protected async Task<SurveyUserInput> SaveLinesInternalAsync(object question, object answer, object comment, object overwrite_existing)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py) ---
            // def _save_lines(self, question, answer, comment=None, overwrite_existing=True):
            // """ Save answers to questions, depending on question type.
            // 
            // :param bool overwrite_existing: if an answer already exists for question and user_input_id
            // it will be overwritten (or deleted for 'choice' questions) in order to maintain data consistency.
            // :raises UserError: if line exists and overwrite_existing is False
            // """
            // old_answers = self.env['survey.user_input.line'].search([
            //     ('user_input_id', '=', self.id),
            //     ('question_id', '=', question.id)
            // ])
            // if old_answers and not overwrite_existing:
            //     raise UserError(_("This answer cannot be overwritten."))
            // 
            // if question.question_type in ['char_box', 'text_box', 'scale', 'numerical_box', 'date', 'datetime']:
            //     self._save_line_simple_answer(question, old_answers, answer)
            //     if question.save_as_email and answer:
            //         self.write({'email': answer})
            //     if question.save_as_nickname and answer:
            //         self.write({'nickname': answer})
            // 
            // elif question.question_type in ['simple_choice', 'multiple_choice']:
            //     self._save_line_choice(question, old_answers, answer, comment)
            // elif question.question_type == 'matrix':
            //     self._save_line_matrix(question, old_answers, answer, comment)
            // else:
            //     raise AttributeError(question.question_type + ": This type of question has no saving function")
            */
            return default;
        }

        protected async Task<SurveyUserInput> SimpleChoiceQuestionAnswerResultInternalAsync(object user_input_line, object question_correct_suggested_answers, object question_incorrect_scored_answers)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py) ---
            // def _simple_choice_question_answer_result(self, user_input_line, question_correct_suggested_answers, question_incorrect_scored_answers):
            // user_answer = user_input_line.suggested_answer_id if not user_input_line.skipped else self.env['survey.question.answer']
            // if user_answer in question_correct_suggested_answers:
            //     return 'correct'
            // elif user_answer in question_incorrect_scored_answers:
            //     return 'partial'
            // elif user_answer:
            //     return 'incorrect'
            // else:
            //     return 'skipped'
            */
            return default;
        }

        protected async Task<SurveyUserInput> SimpleQuestionAnswerResultInternalAsync(object user_input_line)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: survey, FILE: survey_user_input.py) ---
            // def _simple_question_answer_result(self, user_input_line):
            // if user_input_line.skipped:
            //     return 'skipped'
            // elif user_input_line.answer_is_correct:
            //     return 'correct'
            // else:
            //     return 'incorrect'
            */
            return default;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, SurveyUserInput entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_slides_survey, FILE: survey_user.py) ---
            // def write(self, vals):
            // res = super(SurveyUserInput, self).write(vals)
            // if 'state' in vals:
            //     self._check_for_failed_attempt()
            // return res
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}