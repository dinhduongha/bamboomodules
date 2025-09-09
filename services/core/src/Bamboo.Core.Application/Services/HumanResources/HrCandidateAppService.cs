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
    public class HrCandidateAppService : GenericApplicationService<HrCandidate>, IHrCandidateAppService
    {
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadBlacklistAppService _mailThreadBlacklistAppService;
        private readonly IMailThreadCcAppService _mailThreadCcAppService;
        private readonly IMailThreadMainAttachmentAppService _mailThreadMainAttachmentAppService;
        private readonly IMailThreadPhoneAppService _mailThreadPhoneAppService;
        public HrCandidateAppService(IRepository<HrCandidate, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadBlacklistAppService mailThreadBlacklistAppService, IMailThreadCcAppService mailThreadCcAppService, IMailThreadMainAttachmentAppService mailThreadMainAttachmentAppService, IMailThreadPhoneAppService mailThreadPhoneAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadBlacklistAppService = mailThreadBlacklistAppService;
            _mailThreadCcAppService = mailThreadCcAppService;
            _mailThreadMainAttachmentAppService = mailThreadMainAttachmentAppService;
            _mailThreadPhoneAppService = mailThreadPhoneAppService;
        }

        protected async Task<HrCandidate> CheckInterviewerAccessInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def _check_interviewer_access(self):
            // if self.env.user.has_group('hr_recruitment.group_hr_recruitment_interviewer') and not self.env.user.has_group('hr_recruitment.group_hr_recruitment_user'):
            //     raise UserError(_('You are not allowed to perform this action.'))
            */
            return default;
        }

        protected async Task<HrCandidate> ComputeApplicationCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def _compute_application_count(self):
            // read_group_res = self.env['hr.applicant'].with_context(active_test=False)._read_group(
            //     [('candidate_id', 'in', self.ids)],
            //     ['candidate_id'], ['__count'])
            // application_data = dict(read_group_res)
            // for candidate in self:
            //     candidate.application_count = application_data.get(candidate, 0)
            */
            return default;
        }

        protected async Task<HrCandidate> ComputeApplicationsCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def _compute_applications_count(self):
            // result = defaultdict(lambda: {"total": 0, "refused": 0, "accepted": 0})
            // for applicant in self.with_context(active_test=False).applicant_ids:
            //     result[applicant.candidate_id.id]["total"] += 1
            //     if applicant.application_status == "refused":
            //         result[applicant.candidate_id.id]["refused"] += 1
            //     elif applicant.application_status == "hired":
            //         result[applicant.candidate_id.id]["accepted"] += 1
            // for candidate in self:
            //     candidate.applications_count = result[candidate.id]['total']
            //     candidate.refused_applications_count = result[candidate.id]['refused']
            //     candidate.accepted_applications_count = result[candidate.id]['accepted']
            */
            return default;
        }

        protected async Task<HrCandidate> ComputeAttachmentCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def _compute_attachment_count(self):
            // read_group_res = self.env['ir.attachment']._read_group(
            //     [('res_model', '=', 'hr.candidate'), ('res_id', 'in', self.ids)],
            //     ['res_id'], ['__count'])
            // attach_data = dict(read_group_res)
            // for candidate in self:
            //     candidate.attachment_count = attach_data.get(candidate.id, 0)
            */
            return default;
        }

        protected async Task<HrCandidate> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def _compute_display_name(self):
            // for candidate in self:
            //     candidate.display_name = candidate.partner_name or candidate.partner_id.name
            */
            return default;
        }

        protected async Task<HrCandidate> ComputeMatchingSkillIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment_skills, FILE: hr_candidate.py) ---
            // def _compute_matching_skill_ids(self):
            // job_id = self.env.context.get('active_id')
            // if not job_id:
            //     self.matching_skill_ids = False
            //     self.missing_skill_ids = False
            //     self.matching_score = 0
            // else:
            //     for candidate in self:
            //         job_skills = self.env['hr.job'].browse(job_id).skill_ids
            //         candidate.matching_skill_ids = job_skills & candidate.skill_ids
            //         candidate.missing_skill_ids = job_skills - candidate.skill_ids
            //         candidate.matching_score = (len(candidate.matching_skill_ids) / len(job_skills)) * 100 if job_skills else 0
            */
            return default;
        }

        protected async Task<HrCandidate> ComputeMeetingDisplayInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def _compute_meeting_display(self):
            // candidate_with_meetings = self.filtered('meeting_ids')
            // (self - candidate_with_meetings).update({
            //     'meeting_display_text': _('No Meeting'),
            //     'meeting_display_date': ''
            // })
            // today = fields.Date.today()
            // for candidate in candidate_with_meetings:
            //     count = len(candidate.meeting_ids)
            //     dates = candidate.meeting_ids.mapped('start')
            //     min_date, max_date = min(dates).date(), max(dates).date()
            //     if min_date >= today:
            //         candidate.meeting_display_date = min_date
            //     else:
            //         candidate.meeting_display_date = max_date
            //     if count == 1:
            //         candidate.meeting_display_text = _('1 Meeting')
            //     elif candidate.meeting_display_date >= today:
            //         candidate.meeting_display_text = _('Next Meeting')
            //     else:
            //         candidate.meeting_display_text = _('Last Meeting')
            */
            return default;
        }

        protected async Task<HrCandidate> ComputePartnerPhoneEmailInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def _compute_partner_phone_email(self):
            // for candidate in self:
            //     if not candidate.partner_id:
            //         continue
            //     candidate.email_from = candidate.partner_id.email
            //     if not candidate.partner_phone:
            //         candidate.partner_phone = candidate.partner_id.phone
            */
            return default;
        }

        protected async Task<HrCandidate> ComputePartnerPhoneSanitizedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def _compute_partner_phone_sanitized(self):
            // for candidate in self:
            //     candidate.partner_phone_sanitized = candidate._phone_format(fname='partner_phone') or candidate.partner_phone
            */
            return default;
        }

        protected async Task<HrCandidate> ComputePriorityInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def _compute_priority(self):
            // for candidate in self:
            //     if not candidate.applicant_ids:
            //         candidate.priority = "0"
            //     else:
            //         candidate.priority = str(round(sum(int(a.priority) for a in candidate.applicant_ids) / len(candidate.applicant_ids)))
            */
            return default;
        }

        protected async Task<HrCandidate> ComputeSimilarCandidatesCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def _compute_similar_candidates_count(self):
            // """
            //     The field similar_candidates_count is only used on the form view.
            //     Thus, using ORM rather then querying, should not make much
            //     difference in terms of performance, while being more readable and secure.
            // """
            // if not any(self._ids):
            //     for candidate in self:
            //         domain = candidate._get_similar_candidates_domain()
            //         if domain:
            //             candidate.similar_candidates_count = max(0, self.env["hr.candidate"].with_context(active_test=False).search_count(domain) - 1)
            //         else:
            //             candidate.similar_candidates_count = 0
            //     return
            // self.flush_recordset(['email_normalized', 'partner_phone_sanitized'])
            // self.env.cr.execute("""
            //     SELECT
            //         id,
            //         (
            //             SELECT COUNT(*)
            //             FROM hr_candidate AS sub
            //             WHERE c.id != sub.id
            //              AND ((coalesce(c.email_normalized, '') <> '' AND sub.email_normalized = c.email_normalized)
            //                OR (coalesce(c.partner_phone_sanitized, '') <> '' AND c.partner_phone_sanitized = sub.partner_phone_sanitized))
            //               AND c.company_id = sub.company_id
            //         ) AS similar_candidates
            //     FROM hr_candidate AS c
            //     WHERE id IN %(ids)s
            // """, {'ids': tuple(self._origin.ids)})
            // query_results = self.env.cr.dictfetchall()
            // mapped_data = {result['id']: result['similar_candidates'] for result in query_results}
            // for candidate in self:
            //     candidate.similar_candidates_count = mapped_data.get(candidate.id, 0)
            */
            return default;
        }

        protected async Task<HrCandidate> ComputeSkillIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment_skills, FILE: hr_candidate.py) ---
            // def _compute_skill_ids(self):
            // for candidate in self:
            //     candidate.skill_ids = candidate.candidate_skill_ids.skill_id
            */
            return default;
        }

        public async Task<HrCandidate> CreateApplicationAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment_skills, FILE: hr_candidate.py) ---
            // def action_create_application(self):
            // job = self.env['hr.job'].browse(self.env.context.get('active_id'))
            // self.env['hr.applicant'].with_context(just_moved=True).create([{
            //     'candidate_id': candidate.id,
            //     'job_id': job.id,
            // } for candidate in self])
            // action = self.env['ir.actions.actions']._for_xml_id('hr_recruitment.action_hr_job_applications')
            // action['context'] = literal_eval(action['context'].replace('active_id', str(job.id)))
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrCandidate> CreateEmployeeFromCandidateAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def create_employee_from_candidate(self):
            // self.ensure_one()
            // self._check_interviewer_access()
            // 
            // if not self.partner_id:
            //     if not self.partner_name:
            //         raise UserError(_('Please provide an candidate name.'))
            //     self.partner_id = self.env['res.partner'].create({
            //         'is_company': False,
            //         'name': self.partner_name,
            //         'email': self.email_from,
            //     })
            // 
            // action = self.env['ir.actions.act_window']._for_xml_id('hr.open_view_employee_list')
            // employee = self.env['hr.employee'].create(self._get_employee_create_vals())
            // action['res_id'] = employee.id
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrCandidate> CreateMeetingAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def action_create_meeting(self):
            // """ This opens Meeting's calendar view to schedule meeting on current candidate
            //     @return: Dictionary value for created Meeting view
            // """
            // self.ensure_one()
            // if not self.partner_id:
            //     if not self.partner_name:
            //         raise UserError(_('You must define a Contact Name for this candidate.'))
            //     self.partner_id = self.env['res.partner'].create({
            //         'is_company': False,
            //         'name': self.partner_name,
            //         'email': self.email_from,
            //     })
            // 
            // partners = self.partner_id
            // if self.env.user.has_group('hr_recruitment.group_hr_recruitment_interviewer') and not self.env.user.has_group('hr_recruitment.group_hr_recruitment_user'):
            //     partners |= self.env.user.partner_id
            // else:
            //     partners |= self.user_id.partner_id
            // 
            // res = self.env['ir.actions.act_window']._for_xml_id('calendar.action_calendar_event')
            // # As we are redirected from the hr.candidate, calendar checks rules on "hr.applicant",
            // # in order to decide whether to allow creation of a meeting.
            // # As interviewer does not have create right on the hr.applicant, in order to allow them
            // # to create a meeting for an applicant, we pass 'create': True to the context.
            // res['context'] = {
            //     'create': True,
            //     'default_candidate_id': self.id,
            //     'default_partner_ids': partners.ids,
            //     'default_user_id': self.env.uid,
            //     'default_name': self.partner_name,
            //     'attachment_ids': self.attachment_ids.ids
            // }
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrCandidate> GetEmployeeCreateValsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def _get_employee_create_vals(self):
            // self.ensure_one()
            // address_id = self.partner_id.address_get(['contact'])['contact']
            // address_sudo = self.env['res.partner'].sudo().browse(address_id)
            // return {
            //     'name': self.partner_name or self.partner_id.display_name,
            //     'work_contact_id': self.partner_id.id,
            //     'private_street': address_sudo.street,
            //     'private_street2': address_sudo.street2,
            //     'private_city': address_sudo.city,
            //     'private_state_id': address_sudo.state_id.id,
            //     'private_zip': address_sudo.zip,
            //     'private_country_id': address_sudo.country_id.id,
            //     'private_phone': address_sudo.phone,
            //     'private_email': address_sudo.email,
            //     'lang': address_sudo.lang,
            //     'address_id': self.company_id.partner_id.id,
            //     'candidate_id': self.ids,
            //     'phone': self.partner_phone
            // }
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment_skills, FILE: hr_candidate.py) ---
            // def _get_employee_create_vals(self):
            // vals = super()._get_employee_create_vals()
            // vals['employee_skill_ids'] = [(0, 0, {
            //     'skill_id': candidate_skill.skill_id.id,
            //     'skill_level_id': candidate_skill.skill_level_id.id,
            //     'skill_type_id': candidate_skill.skill_type_id.id,
            // }) for candidate_skill in self.candidate_skill_ids]
            // return vals
            */
            return default;
        }

        protected async Task<HrCandidate> GetSimilarCandidatesDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def _get_similar_candidates_domain(self):
            // """
            //     This method returns a domain for the applicants whitch match with the
            //     current candidate according to email_from, partner_phone.
            //     Thus, search on the domain will return the current candidate as well if any of
            //     the following fields are filled.
            // """
            // self.ensure_one()
            // if not self:
            //     return []
            // domain = [('id', 'in', self.ids)]
            // if self.email_normalized:
            //     domain = expression.OR([domain, [('email_normalized', '=', self.email_normalized)]])
            // if self.partner_phone_sanitized:
            //     domain = expression.OR([domain, [('partner_phone_sanitized', '=', self.partner_phone_sanitized)]])
            // domain = expression.AND([domain, [('company_id', '=', self.company_id.id)]])
            // return domain
            */
            return default;
        }

        public async Task<HrCandidate> InitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def init(self):
            // self.env.cr.execute("""
            //     CREATE INDEX IF NOT EXISTS hr_candidate_email_partner_phone_mobile
            //     ON hr_candidate(email_normalized, partner_phone_sanitized);
            // """)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrCandidate> InversePartnerEmailInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def _inverse_partner_email(self):
            // for candidate in self:
            //     if not candidate.email_from:
            //         continue
            //     if not candidate.partner_id:
            //         if not candidate.partner_name:
            //             raise UserError(_('You must define a Contact Name for this candidate.'))
            //         candidate.partner_id = self.env['res.partner'].with_context(default_lang=self.env.lang).find_or_create(candidate.email_from)
            //     if candidate.partner_name and not candidate.partner_id.name:
            //         candidate.partner_id.name = candidate.partner_name
            //     if tools.email_normalize(candidate.email_from) != tools.email_normalize(candidate.partner_id.email):
            //         # change email on a partner will trigger other heavy code, so avoid to change the email when
            //         # it is the same. E.g. "email@example.com" vs "My Email" <email@example.com>""
            //         candidate.partner_id.email = candidate.email_from
            //     if candidate.partner_phone:
            //         candidate.partner_id.phone = candidate.partner_phone
            */
            return default;
        }

        public async Task<HrCandidate> OpenApplicationsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def action_open_applications(self):
            // self.ensure_one()
            // return {
            //     'name': _('Applications'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'hr.applicant',
            //     'view_mode': 'list,kanban,form,pivot,graph,calendar,activity',
            //     'domain': [('id', 'in', self.applicant_ids.ids)],
            //     'context': {
            //         'active_test': False,
            //         'search_default_stage': 1,
            //     },
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrCandidate> OpenAttachmentsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def action_open_attachments(self):
            // return {
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'ir.attachment',
            //     'name': _('Documents'),
            //     'context': {
            //         'default_res_model': 'hr.candidate',
            //         'default_res_id': self.ids[0],
            //         'show_partner_name': 1,
            //     },
            //     'view_mode': 'list,form',
            //     'views': [
            //         (self.env.ref('hr_recruitment.ir_attachment_hr_recruitment_list_view').id, 'list'),
            //         (False, 'form'),
            //     ],
            //     'search_view_id': self.env.ref('hr_recruitment.ir_attachment_view_search_inherit_hr_recruitment').ids,
            //     'domain': [('res_model', '=', 'hr.candidate'), ('res_id', 'in', self.ids)],
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrCandidate> OpenEmployeeAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def action_open_employee(self):
            // self.ensure_one()
            // return {
            //     'name': _('Employee'),
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'hr.employee',
            //     'view_mode': 'form',
            //     'res_id': self.employee_id.id,
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrCandidate> OpenSimilarCandidatesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def action_open_similar_candidates(self):
            // self.ensure_one()
            // domain = self._get_similar_candidates_domain()
            // similar_candidates = self.env['hr.candidate'].with_context(active_test=False).search(domain)
            // return {
            //     'type': 'ir.actions.act_window',
            //     'name': _('Similar Candidates'),
            //     'res_model': self._name,
            //     'view_mode': 'list,kanban,form,activity',
            //     'domain': [('id', 'in', similar_candidates.ids)],
            //     'context': {
            //         'active_test': False,
            //     },
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrCandidate> PhoneGetNumberFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def _phone_get_number_fields(self):
            // return ['partner_phone']
            */
            return default;
        }

        public async Task<HrCandidate> SendEmailAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def action_send_email(self):
            // return {
            //     'name': _('Send Email'),
            //     'type': 'ir.actions.act_window',
            //     'target': 'new',
            //     'view_mode': 'form',
            //     'res_model': 'candidate.send.mail',
            //     'context': {
            //         'default_candidate_ids': self.ids,
            //     }
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrCandidate> UnlinkExceptLinkedEmployeeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_candidate.py) ---
            // def _unlink_except_linked_employee(self):
            // if self.employee_id:
            //     raise UserError(_("The candidate is linked to an employee, to avoid losing information, archive it instead."))
            */
            return default;
        }
    }
}