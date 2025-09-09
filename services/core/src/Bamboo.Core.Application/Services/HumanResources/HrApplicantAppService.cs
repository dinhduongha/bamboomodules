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
    [Module("HrRecruitment", Depends = new[] { "hr", "calendar", "utm", "attachment_indexation", "web_tour", "digest" })]
    public class HrApplicantAppService : GenericApplicationService<HrApplicant>, IHrApplicantAppService
    {
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadCcAppService _mailThreadCcAppService;
        private readonly IMailThreadMainAttachmentAppService _mailThreadMainAttachmentAppService;
        private readonly IMailTrackingDurationMixinAppService _mailTrackingDurationMixinAppService;
        private readonly IUtmMixinAppService _utmMixinAppService;
        public HrApplicantAppService(IRepository<HrApplicant, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadCcAppService mailThreadCcAppService, IMailThreadMainAttachmentAppService mailThreadMainAttachmentAppService, IMailTrackingDurationMixinAppService mailTrackingDurationMixinAppService, IUtmMixinAppService utmMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadCcAppService = mailThreadCcAppService;
            _mailThreadMainAttachmentAppService = mailThreadMainAttachmentAppService;
            _mailTrackingDurationMixinAppService = mailTrackingDurationMixinAppService;
            _utmMixinAppService = utmMixinAppService;
        }

        public async Task<HrApplicant> ArchiveApplicantAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def archive_applicant(self):
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _('Refuse Reason'),
            //     'res_model': 'applicant.get.refuse.reason',
            //     'view_mode': 'form',
            //     'target': 'new',
            //     'context': {'default_applicant_ids': self.ids, 'active_test': False},
            //     'views': [[False, 'form']]
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrApplicant> ComputeApplicationStatusInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_application_status(self):
            // for applicant in self:
            //     if applicant.refuse_reason_id:
            //         applicant.application_status = 'refused'
            //     elif not applicant.active:
            //         applicant.application_status = 'archived'
            //     elif applicant.date_closed:
            //         applicant.application_status = 'hired'
            //     else:
            //         applicant.application_status = 'ongoing'
            */
            return default;
        }

        protected async Task<HrApplicant> ComputeCategIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_categ_ids(self):
            // for applicant in self:
            //     applicant.categ_ids = applicant.candidate_id.categ_ids.ids + applicant.categ_ids.ids
            */
            return default;
        }

        protected async Task<HrApplicant> ComputeCompanyInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_company(self):
            // for applicant in self:
            //     company_id = False
            //     if applicant.department_id:
            //         company_id = applicant.department_id.company_id.id
            //     if not company_id and applicant.job_id:
            //         company_id = applicant.job_id.company_id.id
            //     applicant.company_id = company_id or self.env.company.id
            */
            return default;
        }

        protected async Task<HrApplicant> ComputeDateClosedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_date_closed(self):
            // for applicant in self:
            //     if applicant.stage_id and applicant.stage_id.hired_stage and not applicant.date_closed:
            //         applicant.date_closed = fields.datetime.now()
            //     if not applicant.stage_id.hired_stage:
            //         applicant.date_closed = False
            */
            return default;
        }

        protected async Task<HrApplicant> ComputeDayInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_day(self):
            // for applicant in self:
            //     if applicant.date_open:
            //         date_create = applicant.create_date
            //         date_open = applicant.date_open
            //         applicant.day_open = (date_open - date_create).total_seconds() / (24.0 * 3600)
            //     else:
            //         applicant.day_open = False
            //     if applicant.date_closed:
            //         date_create = applicant.create_date
            //         date_closed = applicant.date_closed
            //         applicant.day_close = (date_closed - date_create).total_seconds() / (24.0 * 3600)
            //     else:
            //         applicant.day_close = False
            */
            return default;
        }

        protected async Task<HrApplicant> ComputeDelayInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_delay(self):
            // for applicant in self:
            //     if applicant.date_open and applicant.day_close:
            //         applicant.delay_close = applicant.day_close - applicant.day_open
            //     else:
            //         applicant.delay_close = False
            */
            return default;
        }

        protected async Task<HrApplicant> ComputeDepartmentInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_department(self):
            // for applicant in self:
            //     applicant.department_id = applicant.job_id.department_id.id
            */
            return default;
        }

        protected async Task<HrApplicant> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_display_name(self):
            // if not self.env.context.get('show_partner_name'):
            //     return super()._compute_display_name()
            // for applicant in self:
            //     applicant.display_name = applicant.partner_name or applicant.name
            */
            return default;
        }

        protected async Task<HrApplicant> ComputeMeetingDisplayInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_meeting_display(self):
            // applicant_with_meetings = self.filtered('meeting_ids')
            // (self - applicant_with_meetings).update({
            //     'meeting_display_text': _('No Meeting'),
            //     'meeting_display_date': ''
            // })
            // today = fields.Date.today()
            // for applicant in applicant_with_meetings:
            //     count = len(applicant.meeting_ids)
            //     dates = applicant.meeting_ids.mapped('start')
            //     min_date, max_date = min(dates).date(), max(dates).date()
            //     if min_date >= today:
            //         applicant.meeting_display_date = min_date
            //     else:
            //         applicant.meeting_display_date = max_date
            //     if count == 1:
            //         applicant.meeting_display_text = _('1 Meeting')
            //     elif applicant.meeting_display_date >= today:
            //         applicant.meeting_display_text = _('Next Meeting')
            //     else:
            //         applicant.meeting_display_text = _('Last Meeting')
            */
            return default;
        }

        protected async Task<HrApplicant> ComputeOtherApplicationsCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_other_applications_count(self):
            // for applicant in self:
            //     same_candidate_applications = max(len(applicant.with_context(active_test=False).candidate_id.applicant_ids) - 1, 0)
            //     if applicant.candidate_id:
            //         domain = applicant.candidate_id._get_similar_candidates_domain()
            //         similar_candidates = self.env['hr.candidate'].with_context(active_test=False).search(domain) - applicant.candidate_id
            //         similar_candidate_applications = sum(len(candidate.applicant_ids) for candidate in similar_candidates)
            //         applicant.other_applications_count = similar_candidate_applications + same_candidate_applications
            //     else:
            //         applicant.other_applications_count = same_candidate_applications
            */
            return default;
        }

        protected async Task<HrApplicant> ComputePartnerNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_partner_name(self):
            // for applicant in self:
            //     applicant.partner_name = applicant.candidate_id.partner_name
            */
            return default;
        }

        protected async Task<HrApplicant> ComputeStageInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_stage(self):
            // for applicant in self:
            //     if applicant.job_id:
            //         if not applicant.stage_id:
            //             stage_ids = self.env['hr.recruitment.stage'].search([
            //                 '|',
            //                 ('job_ids', '=', False),
            //                 ('job_ids', '=', applicant.job_id.id),
            //                 ('fold', '=', False)
            //             ], order='sequence asc', limit=1).ids
            //             applicant.stage_id = stage_ids[0] if stage_ids else False
            //     else:
            //         applicant.stage_id = False
            */
            return default;
        }

        protected async Task<HrApplicant> ComputeUserInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_user(self):
            // for applicant in self:
            //     applicant.user_id = applicant.job_id.user_id.id
            */
            return default;
        }

        public async Task<HrApplicant> CreateEmployeeFromApplicantAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def create_employee_from_applicant(self):
            // self.ensure_one()
            // action = self.candidate_id.with_context(clean_context(self.env.context)).create_employee_from_candidate()
            // employee = self.env['hr.employee'].browse(action['res_id'])
            // employee.write({
            //     'job_id': self.job_id.id,
            //     'job_title': self.job_id.name,
            //     'department_id': self.department_id.id,
            //     'work_email': self.department_id.company_id.email or self.email_from, # To have a valid email address by default
            //     'work_phone': self.department_id.company_id.phone,
            // })
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrApplicant> CreateMeetingAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def action_create_meeting(self):
            // """ This opens Meeting's calendar view to schedule meeting on current applicant
            //     @return: Dictionary value for created Meeting view
            // """
            // self.ensure_one()
            // if not self.partner_id:
            //     if not self.partner_name:
            //         raise UserError(_('You must define a Contact Name for this applicant.'))
            //     self.partner_id = self.env['res.partner'].create({
            //         'is_company': False,
            //         'name': self.partner_name,
            //         'email': self.email_from,
            //     })
            // 
            // partners = self.partner_id | self.department_id.manager_id.user_id.partner_id
            // if self.env.user.has_group('hr_recruitment.group_hr_recruitment_interviewer') and not self.env.user.has_group('hr_recruitment.group_hr_recruitment_user'):
            //     partners |= self.env.user.partner_id
            // else:
            //     partners |= self.user_id.partner_id
            // 
            // res = self.env['ir.actions.act_window']._for_xml_id('calendar.action_calendar_event')
            // # As we are redirected from the hr.applicant, calendar checks rules on "hr.applicant",
            // # in order to decide whether to allow creation of a meeting.
            // # As interviewer does not have create right on the hr.applicant, in order to allow them
            // # to create a meeting for an applicant, we pass 'create': True to the context.
            // res['context'] = {
            //     'create': True,
            //     'default_applicant_id': self.id,
            //     'default_candidate_id': self.candidate_id.id,
            //     'default_partner_ids': partners.ids,
            //     'default_user_id': self.env.uid,
            //     'default_name': self.partner_name,
            //     'attachment_ids': self.attachment_ids.ids
            // }
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrApplicant> CreationSubtypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _creation_subtype(self):
            // return self.env.ref('hr_recruitment.mt_applicant_new')
            */
            return default;
        }

        protected async Task<HrApplicant> GetAttachmentNumberInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _get_attachment_number(self):
            // read_group_res = self.env['ir.attachment']._read_group(
            //     [('res_model', '=', 'hr.applicant'), ('res_id', 'in', self.ids)],
            //     ['res_id'], ['__count'])
            // attach_data = dict(read_group_res)
            // for record in self:
            //     record.attachment_number = attach_data.get(record.id, 0)
            */
            return default;
        }

        protected async Task<HrApplicant> GetDurationFromTrackingInternalAsync(object trackings)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _get_duration_from_tracking(self, trackings):
            // json = super()._get_duration_from_tracking(trackings)
            // now = datetime.now()
            // for applicant in self:
            //     if applicant.refuse_reason_id and applicant.refuse_date:
            //         json[applicant.stage_id.id] -= (now - applicant.refuse_date).total_seconds()
            // return json
            */
            return default;
        }

        public async Task<HrApplicant> GetEmptyListHelpAsync(Guid id, HrApplicantGetEmptyListHelpRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def get_empty_list_help(self, help_message):
            //         if 'active_id' in self.env.context and self.env.context.get('active_model') == 'hr.job':
            //             hr_job = self.env['hr.job'].browse(self.env.context['active_id'])
            //         elif self.env.context.get('default_job_id'):
            //             hr_job = self.env['hr.job'].browse(self.env.context['default_job_id'])
            //         else:
            //             hr_job = self.env['hr.job']
            // 
            //         nocontent_body = Markup("""
            // <p class="o_view_nocontent_smiling_face">%(help_title)s</p>
            // """) % {
            //             'help_title': _("No application found. Let's create one !"),
            //         }
            // 
            //         if hr_job:
            //             pattern = r'(.*)<a>(.*?)<\/a>(.*)'
            //             match = re.fullmatch(pattern, _('Have you tried to <a>add skills to your job position</a> and search into the Reserve ?'))
            //             nocontent_body += Markup("""
            // <p>%(para_1)s<a href="%(link)s">%(para_2)s</a>%(para_3)s</p>""") % {
            //             'para_1': match[1],
            //             'para_2': match[2],
            //             'para_3': match[3],
            //             'link': f'/odoo/recruitment/{hr_job.id}',
            //         }
            // 
            //         if hr_job.alias_email:
            //             nocontent_body += Markup('<p class="o_copy_paste_email oe_view_nocontent_alias">%(helper_email)s <a href="mailto:%(email)s">%(email)s</a></p>') % {
            //                 'helper_email': _("Try creating an application by sending an email to"),
            //                 'email': hr_job.alias_email,
            //             }
            // 
            //         return super().get_empty_list_help(nocontent_body)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrApplicant> GetViewAsync(Guid id, HrApplicantGetViewRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def get_view(self, view_id=None, view_type='form', **options):
            // if view_type == 'form' and self.env.user.has_group('hr_recruitment.group_hr_recruitment_interviewer')\
            //     and not self.env.user.has_group('hr_recruitment.group_hr_recruitment_user'):
            //     view_id = self.env.ref('hr_recruitment.hr_applicant_view_form_interviewer').id
            // return super().get_view(view_id, view_type, **options)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrApplicant> InitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def init(self):
            // super().init()
            // self.env.cr.execute("""
            //     CREATE INDEX IF NOT EXISTS hr_applicant_job_id_stage_id_idx
            //     ON hr_applicant(job_id, stage_id)
            //     WHERE active IS TRUE
            // """)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrApplicant> InverseNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _inverse_name(self):
            // for applicant in self:
            //     if applicant.partner_name and not applicant.candidate_id:
            //         applicant.candidate_id = self.env['hr.candidate'].create({'partner_name': applicant.partner_name})
            //     else:
            //         applicant.candidate_id.partner_name = applicant.partner_name
            */
            return default;
        }

        protected async Task<HrApplicant> MessageGetSuggestedRecipientsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _message_get_suggested_recipients(self):
            // recipients = super()._message_get_suggested_recipients()
            // if self.partner_id:
            //     self._message_add_suggested_recipient(recipients, partner=self.partner_id.sudo(), reason=_('Contact'))
            // elif self.email_from:
            //     email_from = tools.email_normalize(self.email_from)
            //     if email_from and self.partner_name:
            //         email_from = tools.formataddr((self.partner_name, email_from))
            //         self._message_add_suggested_recipient(recipients, email=email_from, reason=_('Contact Email'))
            // return recipients
            */
            return default;
        }

        public async Task<HrApplicant> MessageNewAsync(Guid id, HrApplicantMessageNewRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def message_new(self, msg, custom_values=None):
            // """ Overrides mail_thread message_new that is called by the mailgateway
            //     through message_process.
            //     This override updates the document according to the email.
            // """
            // # Remove default author when going through the mail gateway. Indeed, we
            // # do not want to explicitly set user_id to False; however we do not
            // # want the gateway user to be responsible if no other responsible is
            // # found.
            // self = self.with_context(default_user_id=False, mail_notify_author=True)  # Allows sending stage updates to the author
            // stage = False
            // candidate_defaults = {}
            // partner_name, email_from_normalized = tools.parse_contact_from_email(msg.get('from'))
            // candidate_domain = [
            //     ("email_from", "=", email_from_normalized),
            // ]
            // if custom_values and 'job_id' in custom_values:
            //     job = self.env['hr.job'].browse(custom_values['job_id'])
            //     stage = job._get_first_stage()
            //     candidate_defaults['company_id'] = job.company_id.id
            //     candidate_domain = expression.AND([candidate_domain, [("company_id", "in", [job.company_id.id, False])]])
            // 
            // candidate = self.env["hr.candidate"].search(candidate_domain, limit=1)\
            //     or self.env["hr.candidate"].create({
            //         "partner_name": partner_name or email_from_normalized,
            //         **candidate_defaults,
            //     })
            // 
            // defaults = {
            //     'candidate_id': candidate.id,
            //     'partner_name': partner_name,
            // }
            // job_platform = self.env['hr.job.platform'].search([('email', '=', email_from_normalized)], limit=1)
            // if msg.get('from') and not job_platform:
            //     candidate.email_from = msg.get('from')
            //     candidate.partner_id = msg.get('author_id', False)
            // if msg.get('email_from') and job_platform:
            //     subject_pattern = re.compile(job_platform.regex or '')
            //     regex_results = re.findall(subject_pattern, msg.get('subject')) + re.findall(subject_pattern, msg.get('body'))
            //     candidate.partner_name = regex_results[0] if regex_results else partner_name
            //     defaults["partner_name"] = candidate.partner_name
            //     del msg['email_from']
            // if msg.get('priority'):
            //     defaults['priority'] = msg.get('priority')
            // if stage and stage.id:
            //     defaults['stage_id'] = stage.id
            // if custom_values:
            //     defaults.update(custom_values)
            // res = super().message_new(msg, custom_values=defaults)
            // candidate._compute_partner_phone_email()
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrApplicant> MessagePostAfterHookInternalAsync(object message, object msg_vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _message_post_after_hook(self, message, msg_vals):
            // if self.email_from and not self.partner_id:
            //     # we consider that posting a message with a specified recipient (not a follower, a specific one)
            //     # on a document without customer means that it was created through the chatter using
            //     # suggested recipients. This heuristic allows to avoid ugly hacks in JS.
            //     email_normalized = tools.email_normalize(self.email_from)
            //     new_partner = message.partner_ids.filtered(
            //         lambda partner: partner.email == self.email_from or (email_normalized and partner.email_normalized == email_normalized)
            //     )
            //     if new_partner:
            //         if new_partner[0].create_date.date() == fields.Date.today():
            //             new_partner[0].write({
            //                 'name': self.partner_name or self.email_from,
            //             })
            //         if new_partner[0].email_normalized:
            //             email_domain = ('email_from', 'in', [new_partner[0].email, new_partner[0].email_normalized])
            //         else:
            //             email_domain = ('email_from', '=', new_partner[0].email)
            //         self.search([
            //             ('partner_id', '=', False), email_domain, ('stage_id.fold', '=', False)
            //         ]).write({'partner_id': new_partner[0].id})
            // return super(Applicant, self)._message_post_after_hook(message, msg_vals)
            */
            return default;
        }

        protected async Task<HrApplicant> NotifyGetReplyToInternalAsync(object @default)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _notify_get_reply_to(self, default=None):
            // """ Override to set alias of applicants to their job definition if any. """
            // aliases = self.mapped('job_id')._notify_get_reply_to(default=default)
            // res = {app.id: aliases.get(app.job_id.id) for app in self}
            // leftover = self.filtered(lambda rec: not rec.job_id)
            // if leftover:
            //     res.update(super(Applicant, leftover)._notify_get_reply_to(default=default))
            // return res
            */
            return default;
        }

        public async Task<HrApplicant> OpenAttachmentsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def action_open_attachments(self):
            // return {
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'ir.attachment',
            //     'name': _('Documents'),
            //     'context': {
            //         'default_res_model': 'hr.applicant',
            //         'default_res_id': self.ids[0],
            //         'show_partner_name': 1,
            //     },
            //     'view_mode': 'list,form',
            //     'views': [
            //         (self.env.ref('hr_recruitment.ir_attachment_hr_recruitment_list_view').id, 'list'),
            //         (False, 'form'),
            //     ],
            //     'search_view_id': self.env.ref('hr_recruitment.ir_attachment_view_search_inherit_hr_recruitment').ids,
            //     'domain': [('res_model', '=', 'hr.applicant'), ('res_id', 'in', self.ids), ],
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrApplicant> OpenEmployeeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def action_open_employee(self):
            // self.ensure_one()
            // return self.candidate_id.action_open_employee()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrApplicant> OpenOtherApplicationsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def action_open_other_applications(self):
            // self.ensure_one()
            // similar_candidates = (
            //     self.env["hr.candidate"]
            //     .with_context(active_test=False)
            //     .search(self.candidate_id._get_similar_candidates_domain())
            //     - self.candidate_id
            // )
            // return {
            //     'name': _('Other Applications'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'hr.applicant',
            //     'view_mode': 'list,kanban,form,pivot,graph,calendar,activity',
            //     'domain': [('id', 'in', (self.candidate_id.applicant_ids + similar_candidates.applicant_ids).ids)],
            //     'context': {
            //         'active_test': False,
            //         'search_default_stage': 1,
            //     },
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrApplicant> PhoneGetNumberFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _phone_get_number_fields(self):
            // """ This method returns the fields to use to find the number to use to
            // send an SMS on a record. """
            // return ['partner_phone']
            */
            return default;
        }

        public async Task<HrApplicant> PrintSurveyAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment_survey, FILE: hr_applicant.py) ---
            // def action_print_survey(self):
            // """ If response is available then print this response otherwise print survey form (print template of the survey) """
            // self.ensure_one()
            // sorted_interviews = self.response_ids\
            //     .filtered(lambda i: i.survey_id == self.survey_id)\
            //     .sorted(lambda i: i.create_date, reverse=True)
            // if not sorted_interviews:
            //     action = self.survey_id.action_print_survey()
            //     action['target'] = 'new'
            //     return action
            // 
            // answered_interviews = sorted_interviews.filtered(lambda i: i.state == 'done')
            // if answered_interviews:
            //     action = self.survey_id.action_print_survey(answer=answered_interviews[0])
            //     action['target'] = 'new'
            //     return action
            // action = self.survey_id.action_print_survey(answer=sorted_interviews[0])
            // action['target'] = 'new'
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrApplicant> ReadGroupStageIdsInternalAsync(object stages, object domain)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _read_group_stage_ids(self, stages, domain):
            // # retrieve job_id from the context and write the domain: ids + contextual columns (job or default)
            // job_id = self._context.get('default_job_id')
            // search_domain = [('job_ids', '=', False)]
            // if job_id:
            //     search_domain = ['|', ('job_ids', '=', job_id)] + search_domain
            // if stages:
            //     search_domain = ['|', ('id', 'in', stages.ids)] + search_domain
            // 
            // stage_ids = stages.sudo()._search(search_domain, order=stages._order)
            // return stages.browse(stage_ids)
            */
            return default;
        }

        public async Task<HrApplicant> ResetApplicantAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def reset_applicant(self):
            // """ Reinsert the applicant into the recruitment pipe in the first stage"""
            // default_stage = dict()
            // for job_id in self.mapped('job_id'):
            //     default_stage[job_id.id] = self.env['hr.recruitment.stage'].search(
            //         [
            //             '|',
            //             ('job_ids', '=', False),
            //             ('job_ids', '=', job_id.id),
            //             ('fold', '=', False)
            //         ], order='sequence asc', limit=1).id
            // for applicant in self:
            //     applicant.write(
            //         {'stage_id': applicant.job_id.id and default_stage[applicant.job_id.id],
            //          'refuse_reason_id': False})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrApplicant> SearchApplicationStatusInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _search_application_status(self, operator, value):
            // supported_operators = ['=', '!=', 'in', 'not in']
            // if operator not in supported_operators:
            //     raise UserError(_('Operation not supported'))
            // 
            // # Normalize value to be a list to simplify processing
            // if isinstance(value, (str, bool)):
            //     value = [value]
            // 
            // # Ensure all values are either correct strings or False
            // valid_statuses = ['ongoing', 'hired', 'refused', 'archived']
            // if not all(v in valid_statuses or v is False for v in value):
            //     raise UserError(_('Some values do not exist in the application status'))
            // 
            // # Map statuses to domain filters
            // for status in value:
            //     if status == 'refused':
            //         domain = [('refuse_reason_id', '!=', None)]
            //     elif status == 'hired':
            //         domain = [('date_closed', '!=', False)]
            //     elif status == 'archived' or status is False:
            //         domain = [('active', '=', False)]
            //     elif status == 'ongoing':
            //         domain = ['&', ('active', '=', True), ('date_closed', '=', False)]
            // 
            // # Invert the domain for '!=' and 'not in' operators
            // if operator in expression.NEGATIVE_TERM_OPERATORS:
            //     domain.insert(0, expression.NOT_OPERATOR)
            //     domain = expression.distribute_not(domain)
            // return domain
            */
            return default;
        }

        protected async Task<HrApplicant> SearchPartnerNameInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _search_partner_name(self, operator, value):
            // return [('candidate_id.partner_name', operator, value)]
            */
            return default;
        }

        public async Task<HrApplicant> SendEmailAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def action_send_email(self):
            // return {
            //     'name': _('Send Email'),
            //     'type': 'ir.actions.act_window',
            //     'target': 'new',
            //     'view_mode': 'form',
            //     'res_model': 'applicant.send.mail',
            //     'context': {
            //         'default_applicant_ids': self.ids,
            //     }
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrApplicant> SendSurveyAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment_survey, FILE: hr_applicant.py) ---
            // def action_send_survey(self):
            // self.ensure_one()
            // 
            // # if an applicant does not already has associated partner_id create it
            // if not self.partner_id:
            //     if not self.partner_name:
            //         raise UserError(_('Please provide an applicant name.'))
            //     self.partner_id = self.env['res.partner'].sudo().create({
            //         'is_company': False,
            //         'name': self.partner_name,
            //         'email': self.email_from,
            //         'phone': self.partner_phone,
            //         'mobile': self.partner_phone
            //     })
            // 
            // self.survey_id.check_validity()
            // template = self.env.ref('hr_recruitment_survey.mail_template_applicant_interview_invite', raise_if_not_found=False)
            // local_context = dict(
            //     default_applicant_id=self.id,
            //     default_partner_ids=self.partner_id.ids,
            //     default_survey_id=self.survey_id.id,
            //     default_use_template=bool(template),
            //     default_template_id=template and template.id or False,
            //     default_email_layout_xmlid='mail.mail_notification_light',
            //     default_deadline=fields.Datetime.now() + timedelta(days=15)
            // )
            // 
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _("Send an interview"),
            //     'view_mode': 'form',
            //     'res_model': 'survey.invite',
            //     'target': 'new',
            //     'context': local_context,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrApplicant> ToggleActiveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def toggle_active(self):
            // self = self.with_context(just_unarchived=True)
            // res = super(Applicant, self).toggle_active()
            // active_applicants = self.filtered(lambda applicant: applicant.active)
            // if active_applicants:
            //     active_applicants.reset_applicant()
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrApplicant> TrackSubtypeInternalAsync(object init_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _track_subtype(self, init_values):
            // record = self[0]
            // if 'stage_id' in init_values and record.stage_id:
            //     return self.env.ref('hr_recruitment.mt_applicant_stage_changed')
            // return super(Applicant, self)._track_subtype(init_values)
            */
            return default;
        }

        protected async Task<HrApplicant> TrackTemplateInternalAsync(object changes)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _track_template(self, changes):
            // res = super(Applicant, self)._track_template(changes)
            // applicant = self[0]
            // # When applcant is unarchived, they are put back to the default stage automatically. In this case,
            // # don't post automated message related to the stage change.
            // if 'stage_id' in changes and applicant.exists()\
            //     and applicant.stage_id.template_id\
            //     and not applicant._context.get('just_moved')\
            //     and not applicant._context.get('just_unarchived'):
            //     res['stage_id'] = (applicant.stage_id.template_id, {
            //         'auto_delete_keep_log': False,
            //         'subtype_id': self.env['ir.model.data']._xmlid_to_res_id('mail.mt_note'),
            //         'email_layout_xmlid': 'hr_recruitment.mail_notification_light_without_background'
            //     })
            // return res
            */
            return default;
        }

        public async Task<HrApplicant> WebsiteFormInputFilterAsync(Guid id, HrApplicantWebsiteFormInputFilterRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_applicant.py) ---
            // def website_form_input_filter(self, request, values):
            // if 'partner_name' in values:
            //     applicant_job = self.env['hr.job'].sudo().search([('id', '=', values['job_id'])]).name if 'job_id' in values else False
            //     name = '%s - %s' % (values['partner_name'], applicant_job) if applicant_job else _("%s's Application", values['partner_name'])
            //     values.setdefault('name', name)
            // if values.get('job_id'):
            //     job = self.env['hr.job'].browse(values.get('job_id'))
            //     if not job.sudo().active:
            //         raise UserError(_("The job offer has been closed."))
            //     stage = self.env['hr.recruitment.stage'].sudo().search([
            //         ('fold', '=', False),
            //         '|', ('job_ids', '=', False), ('job_ids', '=', values['job_id']),
            //     ], order='sequence asc', limit=1)
            //     if stage:
            //         values['stage_id'] = stage.id
            // return values
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}