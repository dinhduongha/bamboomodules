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
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("HrRecruitment", Category = "HumanResources", Depends = new[] { "hr", "calendar", "utm", "attachment_indexation", "web_tour", "digest" })]
    public partial class HrApplicantAppService : GenericApplicationService<HrApplicant>, IHrApplicantAppService
    {
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadBlacklistAppService _mailThreadBlacklistAppService;
        private readonly IMailThreadCcAppService _mailThreadCcAppService;
        private readonly IMailThreadMainAttachmentAppService _mailThreadMainAttachmentAppService;
        private readonly IMailThreadPhoneAppService _mailThreadPhoneAppService;
        private readonly IMailTrackingDurationMixinAppService _mailTrackingDurationMixinAppService;
        private readonly IUtmMixinAppService _utmMixinAppService;
        public HrApplicantAppService(IRepository<HrApplicant, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadBlacklistAppService mailThreadBlacklistAppService, IMailThreadCcAppService mailThreadCcAppService, IMailThreadMainAttachmentAppService mailThreadMainAttachmentAppService, IMailThreadPhoneAppService mailThreadPhoneAppService, IMailTrackingDurationMixinAppService mailTrackingDurationMixinAppService, IUtmMixinAppService utmMixinAppService) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadBlacklistAppService = mailThreadBlacklistAppService;
            _mailThreadCcAppService = mailThreadCcAppService;
            _mailThreadMainAttachmentAppService = mailThreadMainAttachmentAppService;
            _mailThreadPhoneAppService = mailThreadPhoneAppService;
            _mailTrackingDurationMixinAppService = mailTrackingDurationMixinAppService;
            _utmMixinAppService = utmMixinAppService;
        }

        public async Task<HrApplicant> AddToJobAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment_skills, FILE: hr_applicant.py) ---
            // def action_add_to_job(self):
            // self.with_context(just_moved=True).write(
            //     {
            //         "job_id": self.env["hr.job"].browse(self.env.context.get("matching_job_id")).id,
            //         "stage_id": self.env.ref("hr_recruitment.stage_job0").id,
            //     }
            // )
            // action = self.env["ir.actions.actions"]._for_xml_id("hr_recruitment.action_hr_job_applications")
            // action["context"] = literal_eval(action["context"].replace("active_id", str(self.job_id.id)))
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
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
            //     'context': {
            //         'default_applicant_ids': self.ids,
            //         'active_test': False,
            //         'hide_mail_template_management_options': True,
            //     },
            //     'views': [[False, 'form']]
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrApplicant> ArchiveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def action_archive(self):
            // return super(HrApplicant, self.with_context(just_unarchived=True)).action_archive()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrApplicant> CheckInterviewerAccessInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _check_interviewer_access(self):
            // if self.env.user.has_group('hr_recruitment.group_hr_recruitment_interviewer') and not self.env.user.has_group('hr_recruitment.group_hr_recruitment_user'):
            //     raise UserError(_('You are not allowed to perform this action.'))
            */
            return default;
        }

        protected async Task<HrApplicant> CheckTalentPoolRequiredInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _check_talent_pool_required(self):
            // for talent in self:
            //     if talent.pool_applicant_id == talent and not talent.talent_pool_ids:
            //         raise ValidationError(self.env._("Talent must belong to at least one Talent Pool."))
            */
            return default;
        }

        protected async Task<HrApplicant> ComputeApplicationCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_application_count(self):
            // """
            // This method will calculate the number of applications that are either
            // directly or indirectly linked to the current application(s)
            // - An application is considered directly linked if it shares the same
            //   pool_applicant_id
            // - An application is considered indirectly_linked if it has the same
            //   value as the current application(s) in any of the following field:
            //   email, phone number or linkedin
            // 
            // Note: If self has pool_applicant_id, email, phone number or linkedin set
            // this method will include self in the returned count
            // """
            // all_emails = {a.email_normalized for a in self if a.email_normalized}
            // all_phones = {a.partner_phone_sanitized for a in self if a.partner_phone_sanitized}
            // all_linkedins = {a.linkedin_profile for a in self if a.linkedin_profile}
            // all_pool_applicants = {a.pool_applicant_id.id for a in self if a.pool_applicant_id}
            // 
            // domain = Domain.FALSE
            // if all_emails:
            //     domain |= Domain("email_normalized", "in", list(all_emails))
            // if all_phones:
            //     domain |= Domain("partner_phone_sanitized", "in", list(all_phones))
            // if all_linkedins:
            //     domain |= Domain("linkedin_profile", "in", list(all_linkedins))
            // if all_pool_applicants:
            //     domain |= Domain("pool_applicant_id", "in", list(all_pool_applicants))
            // 
            // domain &= Domain("talent_pool_ids", "=", False)
            // matching_applicants = self.env["hr.applicant"].with_context(active_test=False).search(domain)
            // 
            // email_map = defaultdict(set)
            // phone_map = defaultdict(set)
            // linkedin_map = defaultdict(set)
            // pool_applicant_map = defaultdict(set)
            // for app in matching_applicants:
            //     if app.email_normalized:
            //         email_map[app.email_normalized].add(app.id)
            //     if app.partner_phone_sanitized:
            //         phone_map[app.partner_phone_sanitized].add(app.id)
            //     if app.linkedin_profile:
            //         linkedin_map[app.linkedin_profile].add(app.id)
            //     if app.pool_applicant_id:
            //         pool_applicant_map[app.pool_applicant_id].add(app.id)
            // 
            // for applicant in self:
            //     related_ids = set()
            //     if applicant.email_normalized:
            //         related_ids.update(email_map.get(applicant.email_normalized, set()))
            //     if applicant.partner_phone_sanitized:
            //         related_ids.update(phone_map.get(applicant.partner_phone_sanitized, set()))
            //     if applicant.linkedin_profile:
            //         related_ids.update(linkedin_map.get(applicant.linkedin_profile, set()))
            //     if applicant.pool_applicant_id:
            //         related_ids.update(pool_applicant_map.get(applicant.pool_applicant_id, set()))
            // 
            //     count = len(related_ids)
            // 
            //     applicant.application_count = max(0, count)
            */
            return default;
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

        protected async Task<HrApplicant> ComputeCurrentApplicantSkillIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment_skills, FILE: hr_applicant.py) ---
            // def _compute_current_applicant_skill_ids(self):
            // current_applicant_skill_by_applicant = self.applicant_skill_ids._get_current_skills_by_applicant()
            // for applicant in self:
            //     applicant.current_applicant_skill_ids = current_applicant_skill_by_applicant[applicant.id]
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
            //         applicant.date_closed = fields.Datetime.now()
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
            //     applicant.display_name = applicant.partner_name
            */
            return default;
        }

        protected async Task<HrApplicant> ComputeIsApplicantInPoolInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_is_applicant_in_pool(self):
            // """
            // Computes if an application is linked to a talent pool or not.
            // An application can either be directly or indirectly linked to a talent pool.
            // Direct link:
            //     - 1. Application has talent_pool_ids set, meaning this application
            //         is a talent pool application, or talent for short.
            //     - 2. Application has pool_applicant_id set, meaning this application
            //     is a copy or directly linked to a talent (scenario 1)
            // 
            // Indirect link:
            //     - 3. Application shares a phone number, email, or linkedin with a
            //         direclty linked application.
            // 
            // Note: While possible, linking an application to a pool through linking
            // it to an indirect link is currently excluded from the implementation
            // for technical reasons.
            // """
            // direct = self.filtered(lambda a: a.talent_pool_ids or a.pool_applicant_id)
            // direct.is_applicant_in_pool = True
            // indirect = self - direct
            // 
            // if not indirect:
            //     return
            // 
            // all_emails = {a.email_normalized for a in indirect if a.email_normalized}
            // all_phones = {a.partner_phone_sanitized for a in indirect if a.partner_phone_sanitized}
            // all_linkedins = {a.linkedin_profile for a in indirect if a.linkedin_profile}
            // 
            // epl_domain = Domain.FALSE
            // if all_emails:
            //     epl_domain |= Domain("email_normalized", "in", list(all_emails))
            // if all_phones:
            //     epl_domain |= Domain("partner_phone_sanitized", "in", list(all_phones))
            // if all_linkedins:
            //     epl_domain |= Domain("linkedin_profile", "in", list(all_linkedins))
            // 
            // pool_domain = Domain(["|", ("talent_pool_ids", "!=", False), ("pool_applicant_id", "!=", False)])
            // domain = pool_domain & epl_domain
            // in_pool_applicants = self.env["hr.applicant"].with_context(active_test=True).search(domain)
            // in_pool_data = {"emails": set(), "phones": set(), "linkedins": set()}
            // 
            // for applicant in in_pool_applicants:
            //     if applicant.email_normalized:
            //         in_pool_data["emails"].add(applicant.email_normalized)
            //     if applicant.partner_phone_sanitized:
            //         in_pool_data["phones"].add(applicant.partner_phone_sanitized)
            //     if applicant.linkedin_profile:
            //         in_pool_data["linkedins"].add(applicant.linkedin_profile)
            // 
            // for applicant in indirect:
            //     applicant.is_applicant_in_pool = (
            //         applicant.email_normalized in in_pool_data["emails"]
            //         or applicant.partner_phone_sanitized in in_pool_data["phones"]
            //         or applicant.linkedin_profile in in_pool_data["linkedins"]
            //     )
            */
            return default;
        }

        protected async Task<HrApplicant> ComputeIsPoolInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_is_pool(self):
            // for applicant in self:
            //     applicant.is_pool_applicant = applicant.talent_pool_ids
            */
            return default;
        }

        protected async Task<HrApplicant> ComputeMatchingSkillIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment_skills, FILE: hr_applicant.py) ---
            // def _compute_matching_skill_ids(self):
            // matching_job_id = self.env.context.get("matching_job_id")
            // matching_job = self.env["hr.job"].browse(matching_job_id)
            // for applicant in self:
            //     job = matching_job or applicant.job_id
            //     if not job or not (job.job_skill_ids or job.expected_degree):
            //         applicant.matching_skill_ids = False
            //         applicant.missing_skill_ids = False
            //         applicant.matching_score = False
            //         continue
            //     job_skills = job.job_skill_ids
            //     job_degree = job.expected_degree.sudo().score * 100
            //     job_total = sum(job_skills.mapped("level_progress")) + job_degree
            //     job_skill_map = {js.skill_id: js.level_progress for js in job_skills}
            // 
            //     matching_applicant_skills = applicant.current_applicant_skill_ids.filtered(
            //         lambda a: a.skill_id in job_skill_map,
            //     )
            //     applicant_degree = applicant.type_id.score * 100 if job_degree > 1 else 0
            //     applicant_total = (
            //         sum(min(skill.level_progress, job_skill_map[skill.skill_id] * 2) for skill in matching_applicant_skills)
            //         + applicant_degree
            //     )
            // 
            //     matching_skill_ids = matching_applicant_skills.mapped("skill_id")
            //     missing_skill_ids = job_skills.mapped("skill_id") - matching_applicant_skills.mapped("skill_id")
            //     matching_score = round(applicant_total / job_total * 100) if job_total else 0
            // 
            //     applicant.matching_skill_ids = matching_skill_ids
            //     applicant.missing_skill_ids = missing_skill_ids
            //     applicant.matching_score = matching_score
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

        protected async Task<HrApplicant> ComputePartnerPhoneEmailInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_partner_phone_email(self):
            // for applicant in self:
            //     if not applicant.partner_id:
            //         continue
            //     applicant.email_from = applicant.partner_id.email
            //     if not applicant.partner_phone:
            //         applicant.partner_phone = applicant.partner_id.phone
            */
            return default;
        }

        protected async Task<HrApplicant> ComputePartnerPhoneSanitizedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_partner_phone_sanitized(self):
            // for applicant in self:
            //     applicant.partner_phone_sanitized = (
            //         applicant._phone_format(fname="partner_phone") or applicant.partner_phone
            //     )
            */
            return default;
        }

        protected async Task<HrApplicant> ComputeSkillIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment_skills, FILE: hr_applicant.py) ---
            // def _compute_skill_ids(self):
            // for applicant in self:
            //     applicant.skill_ids = applicant.applicant_skill_ids.skill_id
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

        protected async Task<HrApplicant> ComputeTalentPoolCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _compute_talent_pool_count(self):
            // """
            // This method will find the amount of talent pools the current application is associated with.
            // An application can either be associated directly with a talent pool through talent_pool_ids
            // and/or pool_applicant_id.talent_pool_ids or indirectly by having the same email, phone
            // number or linkedin as a directly linked application.
            // """
            // pool_applicants = self.filtered("is_applicant_in_pool")
            // (self - pool_applicants).talent_pool_count = 0
            // 
            // if not pool_applicants:
            //     return
            // 
            // directly_linked = pool_applicants.filtered("pool_applicant_id")
            // for applicant in directly_linked:
            //     # All talents(applications with talent_pool_ids set) have a pool_applicant_id set to
            //     # themselves which is the reason we only look for that instead of searching for all
            //     # applications with talent_pool_ids and all applications with pool_applicant_id seperately
            //     applicant.talent_pool_count = len(applicant.pool_applicant_id.talent_pool_ids)
            // 
            // indirectly_linked = pool_applicants - directly_linked
            // if not indirectly_linked:
            //     return
            // 
            // all_emails = {a.email_normalized for a in indirectly_linked if a.email_normalized}
            // all_phones = {a.partner_phone_sanitized for a in indirectly_linked if a.partner_phone_sanitized}
            // all_linkedins = {a.linkedin_profile for a in indirectly_linked if a.linkedin_profile}
            // 
            // epl_domain = Domain.FALSE
            // if all_emails:
            //     epl_domain |= Domain("email_normalized", "in", list(all_emails))
            // if all_phones:
            //     epl_domain |= Domain("partner_phone_sanitized", "in", list(all_phones))
            // if all_linkedins:
            //     epl_domain |= Domain("linkedin_profile", "in", list(all_linkedins))
            // 
            // pool_domain = Domain(["|", ("talent_pool_ids", "!=", False), ("pool_applicant_id", "!=", False)])
            // domain = pool_domain & epl_domain
            // in_pool_applicants = self.env["hr.applicant"].with_context(active_test=True).search(domain)
            // 
            // in_pool_emails = defaultdict(int)
            // in_pool_phones = defaultdict(int)
            // in_pool_linkedins = defaultdict(int)
            // 
            // for applicant in in_pool_applicants:
            //     talent_pool_count = len(applicant.pool_applicant_id.talent_pool_ids)
            //     if applicant.email_normalized:
            //         in_pool_emails[applicant.email_normalized] = talent_pool_count
            //     if applicant.partner_phone_sanitized:
            //         in_pool_phones[applicant.partner_phone_sanitized] = talent_pool_count
            //     if applicant.linkedin_profile:
            //         in_pool_linkedins[applicant.linkedin_profile] = talent_pool_count
            // 
            // for applicant in indirectly_linked:
            //     if applicant.email_from and in_pool_emails[applicant.email_normalized]:
            //         applicant.talent_pool_count = in_pool_emails[applicant.email_normalized]
            //     elif applicant.partner_phone_sanitized and in_pool_phones[applicant.partner_phone_sanitized]:
            //         applicant.talent_pool_count = in_pool_phones[applicant.partner_phone_sanitized]
            //     elif applicant.linkedin_profile and in_pool_linkedins[applicant.linkedin_profile]:
            //         applicant.talent_pool_count = in_pool_linkedins[applicant.linkedin_profile]
            //     else:
            //         applicant.talent_pool_count = 0
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

        public async Task<HrApplicant> CopyDataAsync(Guid id, HrApplicantCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // 
            // # Avoid adding `(copy)` to partner_name when an applicant is created trough the talent pool mechanism
            // if not self.env.context.get("no_copy_in_partner_name"):
            //     vals_list = [
            //         dict(vals, partner_name=self.env._("%s (copy)", applicant.partner_name))
            //         for applicant, vals in zip(self, vals_list)
            //     ]
            // return vals_list
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<HrApplicant> CreateAsync(HrApplicant entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def create(self, vals_list):
            // for vals in vals_list:
            //     if vals.get('user_id'):
            //         vals['date_open'] = fields.Datetime.now()
            //     if vals.get('email_from'):
            //         vals['email_from'] = vals['email_from'].strip()
            // applicants = super().create(vals_list)
            // applicants.sudo().interviewer_ids._create_recruitment_interviewers()
            // 
            // for applicant in applicants:
            //     if applicant.talent_pool_ids and not applicant.pool_applicant_id:
            //         applicant.pool_applicant_id = applicant
            // 
            // if (applicants.interviewer_ids.partner_id - self.env.user.partner_id):
            //     for applicant in applicants:
            //         interviewers_to_notify = applicant.interviewer_ids.partner_id - self.env.user.partner_id
            //         notification_subject = _("You have been assigned as an interviewer for %s", applicant.display_name)
            //         notification_body = _("You have been assigned as an interviewer for the Applicant %s", applicant.partner_name)
            //         applicant.message_notify(
            //             res_id=applicant.id,
            //             model=applicant._name,
            //             partner_ids=interviewers_to_notify.ids,
            //             author_id=self.env.user.partner_id.id,
            //             email_from=self.env.user.email_formatted,
            //             subject=notification_subject,
            //             body=notification_body,
            //             email_layout_xmlid="mail.mail_notification_layout",
            //             model_description="Applicant",
            //         )
            // return applicants
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment_skills, FILE: hr_applicant.py) ---
            // def create(self, vals_list):
            // if not self:
            //     # This is required for the talent pool mechanism to work. Duplicating an hr.applicant record without this
            //     # check will cause the skills to not be duplicated or disappear randomly.
            //     for vals in vals_list:
            //         vals["applicant_skill_ids"] = vals.pop("current_applicant_skill_ids", []) + vals.get("applicant_skill_ids", [])
            // return super().create(vals_list)
            */
            return await base.CreateAsync(entity, fields);
        }

        public async Task<HrApplicant> CreateEmployeeFromApplicantAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def create_employee_from_applicant(self):
            // """ Create an employee from applicant """
            // self.ensure_one()
            // self._check_interviewer_access()
            // 
            // if not self.partner_id:
            //     if not self.partner_name:
            //         raise UserError(_('Please provide an applicant name.'))
            //     self.partner_id = self.env['res.partner'].create({
            //         'is_company': False,
            //         'name': self.partner_name,
            //         'email': self.email_from,
            //     })
            // 
            // action = self.env['ir.actions.act_window']._for_xml_id('hr.open_view_employee_list')
            // employee = self.env['hr.employee'].with_context(clean_context(self.env.context)).create(self._get_employee_create_vals())
            // action['res_id'] = employee.id
            // employee_attachments = self.env['ir.attachment'].search([('res_model', '=','hr.employee'), ('res_id', '=', employee.id)])
            // unique_attachments = self.attachment_ids.filtered(
            //     lambda attachment: attachment.datas not in employee_attachments.mapped('datas')
            // )
            // unique_attachments.copy({'res_model': 'hr.employee', 'res_id': employee.id})
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
            // self.ensure_one()
            // if self.is_pool_applicant:
            //     return self.env.ref('hr_recruitment.mt_talent_new', raise_if_not_found=False)
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

        protected async Task<HrApplicant> GetCustomerInformationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _get_customer_information(self):
            // email_keys_to_values = super()._get_customer_information()
            // 
            // for applicant in self:
            //     email_key = tools.email_normalize(applicant.email_from) or applicant.email_from
            //     # do not fill Falsy with random data, unless monorecord (= always correct)
            //     if not email_key and len(self) > 1:
            //         continue
            //     email_keys_to_values.setdefault(email_key, {}).update({
            //         'name': applicant.partner_name or tools.parse_contact_from_email(applicant.email_from)[0] or applicant.email_from,
            //         'phone': applicant.partner_phone,
            //     })
            // return email_keys_to_values
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

        protected async Task<HrApplicant> GetEmployeeCreateValsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _get_employee_create_vals(self):
            // self.ensure_one()
            // address_id = self.partner_id.address_get(['contact'])['contact']
            // address_sudo = self.env['res.partner'].sudo().browse(address_id)
            // return {
            //     'name': self.partner_name or self.partner_id.display_name,
            //     'work_contact_id': self.partner_id.id,
            //     'job_id': self.job_id.id,
            //     'job_title': self.job_id.name,
            //     'private_street': address_sudo.street,
            //     'private_street2': address_sudo.street2,
            //     'private_city': address_sudo.city,
            //     'private_state_id': address_sudo.state_id.id,
            //     'private_zip': address_sudo.zip,
            //     'private_country_id': address_sudo.country_id.id,
            //     'private_phone': address_sudo.phone,
            //     'private_email': address_sudo.email,
            //     'lang': address_sudo.lang,
            //     'department_id': self.department_id.id,
            //     'address_id': self.company_id.partner_id.id,
            //     'work_email': self.department_id.company_id.email or self.email_from,  # To have a valid email address by default
            //     'work_phone': self.department_id.company_id.phone,
            //     'applicant_ids': self.ids,
            //     'phone': self.partner_phone
            // }
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment_skills, FILE: hr_applicant.py) ---
            // def _get_employee_create_vals(self):
            // vals = super()._get_employee_create_vals()
            // vals["employee_skill_ids"] = [
            //     (
            //         0,
            //         0,
            //         {
            //             "skill_id": applicant_skill.skill_id.id,
            //             "skill_level_id": applicant_skill.skill_level_id.id,
            //             "skill_type_id": applicant_skill.skill_type_id.id,
            //         },
            //     )
            //     for applicant_skill in self.applicant_skill_ids
            // ]
            // return vals
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
            //             'help_title': _("No applications found."),
            //         }
            // 
            //         if hr_job.alias_email:
            //             nocontent_body += Markup('<p class="o_copy_paste_email oe_view_nocontent_alias">%(helper_email)s <a href="mailto:%(email)s">%(email)s</a></p>') % {
            //                 'helper_email': _("Send applications to"),
            //                 'email': hr_job.alias_email,
            //             }
            // 
            //         return super().get_empty_list_help(nocontent_body)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrApplicant> GetRottingDependsFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _get_rotting_depends_fields(self):
            // return super()._get_rotting_depends_fields() + ['application_status', 'date_closed']
            */
            return default;
        }

        protected async Task<HrApplicant> GetRottingDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _get_rotting_domain(self):
            // return super()._get_rotting_domain() & Domain([
            //     ('application_status', '=', 'ongoing'),
            //     ('date_closed', '=', False),
            // ])
            */
            return default;
        }

        protected async Task<HrApplicant> GetSimilarApplicantsDomainInternalAsync(object ignore_talent, object only_talent)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _get_similar_applicants_domain(self, ignore_talent=False, only_talent=False):
            // """
            // This method returns a domain for the applicants whitch match with the
            // current applicant according to email_from, partner_phone or linkedin_profile.
            // Thus, search on the domain will return the current applicant as well
            // if any of the following fields are filled.
            // 
            // Args:
            //     ignore_talent: if you want the domain to only include applicants not belonging to a talent pool
            //     only_talent: if you want the domain to only include applicants belonging to a talent pool
            // 
            // Returns:
            //     Domain()
            // """
            // domain = Domain.AND([
            //     Domain('company_id', 'in', self.mapped('company_id.id')),
            //     Domain.OR([
            //         Domain("id", "in", self.ids),
            //         Domain("email_normalized", "in", [email for email in self.mapped("email_normalized") if email]),
            //         Domain("partner_phone_sanitized", "in", [phone for phone in self.mapped("partner_phone_sanitized") if phone]),
            //         Domain("linkedin_profile", "in", [linkedin_profile for linkedin_profile in self.mapped("linkedin_profile") if linkedin_profile]),
            //         Domain("pool_applicant_id", "in", [pool_applicant.id for pool_applicant in self.mapped("pool_applicant_id") if pool_applicant]),
            //     ])
            // ])
            // if ignore_talent:
            //     domain &= Domain("talent_pool_ids", "=", False)
            // if only_talent:
            //     domain &= Domain("talent_pool_ids", "!=", False)
            // return domain
            */
            return default;
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

        protected async Task<HrApplicant> InversePartnerEmailInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _inverse_partner_email(self):
            // for applicant in self:
            //     email_normalized = tools.email_normalize(applicant.email_from or '')
            //     if not email_normalized:
            //         continue
            //     if not applicant.partner_id:
            //         if not applicant.partner_name:
            //             raise UserError(_("You must define a Contact Name for this applicant."))
            //         applicant.partner_id = applicant._partner_find_from_emails_single(
            //             [applicant.email_from], no_create=False,
            //             additional_values={
            //                 email_normalized: {'lang': self.env.lang}
            //             },
            //         )
            //     if applicant.partner_name and applicant.partner_name != applicant.partner_id.name:
            //         applicant.partner_id.name = applicant.partner_name
            //     if email_normalized and email_normalized != applicant.partner_id.email:
            //         applicant.partner_id.email = applicant.email_from
            //     if applicant.partner_phone and applicant.partner_phone != applicant.partner_id.phone:
            //         applicant.partner_id.phone = applicant.partner_phone
            */
            return default;
        }

        public async Task<HrApplicant> JobAddApplicantsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def action_job_add_applicants(self):
            // return {
            //     "name": _("Create Applications"),
            //     "type": "ir.actions.act_window",
            //     "res_model": "job.add.applicants",
            //     "target": "new",
            //     "views": [[False, "form"]],
            //     "context": {
            //         "is_modal": True,
            //         "dialog_size": "medium",
            //         "default_applicant_ids": self.ids
            //         or self.env.context.get("default_applicant_ids"),
            //     },
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrApplicant> LinkApplicantToTalentAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def link_applicant_to_talent(self):
            // talent = self.env["hr.applicant"].search(domain=self._get_similar_applicants_domain(only_talent=True))
            // self.pool_applicant_id = talent
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrApplicant> MapApplicantSkillIdsToTalentSkillIdsInternalAsync(object vals)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment_skills, FILE: hr_applicant.py) ---
            // def _map_applicant_skill_ids_to_talent_skill_ids(self, vals):
            // """
            // The applicant_skills_ids contains a list of ORM tuples i.e (command, record ID, {values})
            // The challenge lies in the uniqueness of the record ID in this tuple. Each skill (e.g., 'arabic')
            // has a distinct ID per applicant, i.e arabic in applicant 1 will have a different id from arabic in
            // applicant 2. This means the content of applicant_skills_ids is unique for each record and attempting
            // to pass it directly (e.g., applicant.pool_applicant_id.write(vals)) won't yield results so we must
            // update each tuple to have the correct command and record ID for the talent pool applicant
            // 
            // :param vals: list of CREATE, WRITE or UNLINK commands with skill_ids relevant to the applicant
            // :return: list of CREATE, WRITE or UNLINK commands with skill_ids relevant to the pool_applicant
            // """
            // applicant_skills = {a.id: a.skill_id.id for a in self.applicant_skill_ids}
            // applicant_skills_type = {a.id: a.skill_type_id.id for a in self.applicant_skill_ids}
            // talent_skills = {a.skill_id.id: a.id for a in self.pool_applicant_id.applicant_skill_ids}
            // mapped_commands = []
            // for command in vals.get("applicant_skill_ids"):
            //     command_number = command[0]
            //     record_id = command[1]
            //     if command_number == Command.UPDATE:
            //         values = command[2]
            //         if applicant_skills[record_id] in talent_skills:
            //             mapped_command = Command.update(talent_skills[applicant_skills[record_id]], values)
            //             mapped_commands.append(mapped_command)
            //         else:
            //             mapped_command = Command.create(
            //                 {
            //                     "skill_id": applicant_skills[record_id],
            //                     "skill_type_id": applicant_skills_type[record_id],
            //                     "skill_level_id": values["skill_level_id"],
            //                 },
            //             )
            //             mapped_commands.append(mapped_command)
            //     elif command_number == Command.DELETE:
            //         if applicant_skills[record_id] in talent_skills:
            //             mapped_command = Command.delete(talent_skills[applicant_skills[record_id]])
            //             mapped_commands.append(mapped_command)
            //     else:
            //         mapped_commands.append(command)
            // return mapped_commands
            */
            return default;
        }

        public async Task<HrApplicant> MessageNewAsync(Guid id, HrApplicantMessageNewRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def message_new(self, msg_dict, custom_values=None):
            // # Remove default author when going through the mail gateway. Indeed, we
            // # do not want to explicitly set user_id to False; however we do not
            // # want the gateway user to be responsible if no other responsible is
            // # found.
            // self = self.with_context(default_user_id=False)
            // stage = False
            // if custom_values and 'job_id' in custom_values:
            //     job = self.env['hr.job'].browse(custom_values['job_id'])
            //     stage = job._get_first_stage()
            // 
            // partner_name, email_from_normalized = tools.parse_contact_from_email(msg_dict.get('from'))
            // 
            // defaults = {
            //     'partner_name': partner_name,
            // }
            // job_platform = self.env['hr.job.platform'].search([('email', '=', email_from_normalized)], limit=1)
            // 
            // if msg_dict.get('from') and not job_platform:
            //     defaults['email_from'] = msg_dict.get('from')
            //     defaults['partner_id'] = msg_dict.get('author_id', False)
            // if msg_dict.get('email_from') and job_platform:
            //     subject_pattern = re.compile(job_platform.regex or '')
            //     regex_results = re.findall(subject_pattern, msg_dict.get('subject')) + re.findall(subject_pattern, msg_dict.get('body'))
            //     defaults['partner_name'] = regex_results[0] if regex_results else partner_name
            //     del msg_dict['email_from']
            // if msg_dict.get('priority'):
            //     defaults['priority'] = msg_dict.get('priority')
            // if stage and stage.id:
            //     defaults['stage_id'] = stage.id
            // if custom_values:
            //     defaults.update(custom_values)
            // res = super().message_new(msg_dict, custom_values=defaults)
            // res._compute_partner_phone_email()
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
            // return super()._message_post_after_hook(message, msg_vals)
            */
            return default;
        }

        protected async Task<HrApplicant> NotifyGetReplyToInternalAsync(object @default, Guid author_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _notify_get_reply_to(self, default=None, author_id=False):
            // """ Override to set alias of applicants to their job definition if any. """
            // aliases = self.mapped('job_id')._notify_get_reply_to(default=default, author_id=author_id)
            // res = {app.id: aliases.get(app.job_id.id) for app in self}
            // leftover = self.filtered(lambda rec: not rec.job_id)
            // if leftover:
            //     res.update(super(HrApplicant, leftover)._notify_get_reply_to(default=default, author_id=author_id))
            // return res
            */
            return default;
        }

        public async Task<HrApplicant> OpenApplicationsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def action_open_applications(self):
            // self.ensure_one()
            // similar_applicants = (
            //     self.env["hr.applicant"]
            //     .with_context(active_test=False)
            //     .search(
            //         self._get_similar_applicants_domain(ignore_talent=True),
            //     )
            // )
            // return {
            //     "name": _("Applications"),
            //     "type": "ir.actions.act_window",
            //     "res_model": "hr.applicant",
            //     "view_mode": "list,form",
            //     "domain": [("id", "in", similar_applicants.ids)],
            //     "context": {
            //         "active_test": False,
            //         "search_default_stage": 1,
            //         "default_applicant_ids": self.ids,
            //         "no_create_application_button": True,
            //     },
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
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
            // job_id = self.env.context.get('default_job_id')
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
            // if operator != 'in':
            //     return NotImplemented
            // 
            // domains = []
            // # Map statuses to domain filters
            // if 'refused' in value:
            //     domains.append([('active', '=', True), ('refuse_reason_id', '!=', None)])
            // if 'hired' in value:
            //     domains.append([('active', '=', True), ('date_closed', '!=', False)])
            // if 'archived' in value or False in value:
            //     domains.append([('active', '=', False)])
            // if 'ongoing' in value:
            //     domains.append([('active', '=', True), ('date_closed', '=', False)])
            // 
            // return Domain.OR(domains)
            */
            return default;
        }

        protected async Task<HrApplicant> SearchIsApplicantInPoolInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _search_is_applicant_in_pool(self, operator, value):
            // """
            // This function is needed to hide duplicates when adding applicants/talents to a talent pool.
            // All applications that have either talent_pool_ids or pool_applicant_id set are considered
            // directly in a pool. Furthermore, any application with the same phone number, email or linkedin
            // as the first applications, that are directly in the pool, are also considered to belong to
            // the same talent pool.
            // 
            // Returns:
            //     returns a domain with ids of applications that are either directly or indirectly linked to a pool
            // """
            // if operator != 'in':
            //     return NotImplemented
            // 
            // return [('id', 'in', SQL("""
            //         WITH talent_pool_applicants AS (
            //             SELECT
            //                    a.id as id,
            //                    email_normalized,
            //                    partner_phone_sanitized,
            //                    linkedin_profile
            //               FROM hr_applicant a
            //          LEFT JOIN hr_applicant_hr_talent_pool_rel rel
            //                 ON a.id = rel.hr_applicant_id
            //              WHERE pool_applicant_id IS NOT NULL
            //                 OR hr_talent_pool_id IS NOT NULL
            //         )
            //         SELECT a.id
            //         FROM hr_applicant a
            //         WHERE
            //             -- Check if directly linked to a pool
            //             (a.id IN (
            //                 SELECT DISTINCT id
            //                 from talent_pool_applicants
            //             ))
            //             OR
            //             -- Check if email matches any talent pool applicant
            //             (a.email_normalized IN (
            //                 SELECT DISTINCT email_normalized
            //                 FROM talent_pool_applicants
            //                 WHERE email_normalized IS NOT NULL
            //             ))
            //             OR
            //             -- Check if phone matches any talent pool applicant
            //             (a.partner_phone_sanitized IN (
            //                 SELECT DISTINCT partner_phone_sanitized
            //                 FROM talent_pool_applicants
            //                 WHERE partner_phone_sanitized IS NOT NULL
            //             ))
            //             OR
            //             -- Check if LinkedIn profile matches any talent pool applicant
            //             (a.linkedin_profile IN (
            //                 SELECT DISTINCT linkedin_profile
            //                 FROM talent_pool_applicants
            //                 WHERE linkedin_profile IS NOT NULL
            //             ))
            // """))]
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

        public async Task<HrApplicant> SendSmsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment_sms, FILE: hr_applicant.py) ---
            // def action_send_sms(self):
            // res = self.env['ir.actions.act_window']._for_xml_id('sms.sms_composer_action_form')
            // res['context'] = {
            //     'default_composition_mode': 'mass',
            //     'default_mass_keep_log': True,
            //     'default_res_ids': self.ids,
            // }
            // return res
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

        public async Task<HrApplicant> TalentPoolAddApplicantsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def action_talent_pool_add_applicants(self):
            // return {
            //     "name": _("Add applicant(s) to the pool"),
            //     "type": "ir.actions.act_window",
            //     "res_model": "talent.pool.add.applicants",
            //     "target": "new",
            //     "views": [[False, "form"]],
            //     "context": {
            //         "is_modal": True,
            //         "dialog_size": "medium",
            //         "default_talent_pool_ids": self.env.context.get(
            //             "default_talent_pool_ids"
            //         )
            //         or [],
            //         "default_applicant_ids": self.ids,
            //     },
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrApplicant> TalentPoolStatButtonAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def action_talent_pool_stat_button(self):
            // self.ensure_one()
            // # If the applicant has other applications linked to pool but for some
            // # reason this applicant is not linked to that account then link it
            // if not self.pool_applicant_id:
            //     self.link_applicant_to_talent()
            // return {
            //     "type": "ir.actions.act_window",
            //     "res_model": "hr.applicant",
            //     "view_mode": "form",
            //     "target": "current",
            //     "res_id": self.pool_applicant_id.id,
            // }
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
            // return super()._track_subtype(init_values)
            */
            return default;
        }

        protected async Task<HrApplicant> TrackTemplateInternalAsync(object changes)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def _track_template(self, changes):
            // res = super()._track_template(changes)
            // applicant = self[0]
            // # When applcant is unarchived, they are put back to the default stage automatically. In this case,
            // # don't post automated message related to the stage change.
            // if 'stage_id' in changes and applicant.exists()\
            //     and applicant.stage_id.template_id\
            //     and not applicant.env.context.get('just_moved')\
            //     and not applicant.env.context.get('just_unarchived'):
            //     res['stage_id'] = (applicant.stage_id.template_id, {
            //         'auto_delete_keep_log': False,
            //         'subtype_id': self.env['ir.model.data']._xmlid_to_res_id('mail.mt_note'),
            //         'email_layout_xmlid': 'hr_recruitment.mail_notification_light_without_background'
            //     })
            // return res
            */
            return default;
        }

        public async Task<HrApplicant> UnarchiveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def action_unarchive(self):
            // res = super(HrApplicant, self.with_context(just_unarchived=True)).action_unarchive()
            // self.reset_applicant()
            // return res
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrApplicant> WebsiteFormInputFilterAsync(Guid id, HrApplicantWebsiteFormInputFilterRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_applicant.py) ---
            // def website_form_input_filter(self, request, values):
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

        public override async Task<List<object>> WriteAsync(List<Guid> ids, HrApplicant entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_applicant.py) ---
            // def write(self, vals):
            // # user_id change: update date_open
            // if vals.get('user_id'):
            //     vals['date_open'] = fields.Datetime.now()
            // old_interviewers = self.interviewer_ids
            // # stage_id: track last stage before update
            // if 'stage_id' in vals:
            //     vals['date_last_stage_update'] = fields.Datetime.now()
            //     if 'kanban_state' not in vals:
            //         vals['kanban_state'] = 'normal'
            //     for applicant in self:
            //         vals['last_stage_id'] = applicant.stage_id.id
            //         new_stage = self.env['hr.recruitment.stage'].browse(vals['stage_id'])
            //         if new_stage.hired_stage and not applicant.stage_id.hired_stage:
            //             if applicant.job_id.no_of_recruitment > 0:
            //                 applicant.job_id.no_of_recruitment -= 1
            //         elif not new_stage.hired_stage and applicant.stage_id.hired_stage:
            //             applicant.job_id.no_of_recruitment += 1
            // # kanban_state: also set date_last_stage_update
            // if 'kanban_state' in vals:
            //     vals['date_last_stage_update'] = fields.Datetime.now()
            // res = super().write(vals)
            // 
            // for applicant in self:
            //     if applicant.pool_applicant_id and applicant != applicant.pool_applicant_id and (not applicant.is_pool_applicant):
            //         if 'email_from' in vals:
            //             applicant.pool_applicant_id.email_from = vals['email_from']
            //         if 'partner_phone' in vals:
            //             applicant.pool_applicant_id.partner_phone = vals['partner_phone']
            //         if 'linkedin_profile' in vals:
            //             applicant.pool_applicant_id.linkedin_profile = vals['linkedin_profile']
            //         if 'type_id' in vals:
            //             applicant.pool_applicant_id.type_id = vals['type_id']
            // 
            // if 'interviewer_ids' in vals:
            //     interviewers_to_clean = old_interviewers - self.interviewer_ids
            //     interviewers_to_clean._remove_recruitment_interviewers()
            //     self.sudo().interviewer_ids._create_recruitment_interviewers()
            // 
            //     new_interviewers = self.interviewer_ids - old_interviewers - self.env.user
            //     if new_interviewers:
            //         for applicant in self:
            //             notification_subject = _("You have been assigned as an interviewer for %s", applicant.display_name)
            //             notification_body = _("You have been assigned as an interviewer for the Applicant %s", applicant.partner_name)
            //             applicant.message_notify(
            //                 res_id=applicant.id,
            //                 model=applicant._name,
            //                 partner_ids=new_interviewers.partner_id.ids,
            //                 author_id=self.env.user.partner_id.id,
            //                 email_from=self.env.user.email_formatted,
            //                 subject=notification_subject,
            //                 body=notification_body,
            //                 email_layout_xmlid="mail.mail_notification_layout",
            //                 model_description="Applicant",
            //             )
            // return res
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment_skills, FILE: hr_applicant.py) ---
            // def write(self, vals):
            // if "current_applicant_skill_ids" in vals or "applicant_skill_ids" in vals:
            //     skills = vals.pop("current_applicant_skill_ids", []) + vals.get("applicant_skill_ids", [])
            //     original_vals = vals.copy()
            //     original_vals["applicant_skill_ids"] = skills
            //     vals["applicant_skill_ids"] = self.env["hr.applicant.skill"]._get_transformed_commands(skills, self)
            //     for applicant in self:
            //         # Modify the skill values for the talent if it exists
            //         if applicant.pool_applicant_id and (not applicant.is_pool_applicant):
            //             mapped_skills = applicant._map_applicant_skill_ids_to_talent_skill_ids(original_vals)
            //             applicant.pool_applicant_id.write({"applicant_skill_ids": mapped_skills})
            // return super().write(vals)
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}