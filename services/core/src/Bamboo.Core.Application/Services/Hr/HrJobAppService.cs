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
    [Module("Hr", Depends = new[] { "base_setup", "digest", "phone_validation", "resource_mail", "web" })]
    public class HrJobAppService : GenericApplicationService<HrJob>, IHrJobAppService
    {
        private readonly IMailAliasMixinAppService _mailAliasMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        private readonly IWebsitePublishedMultiMixinAppService _websitePublishedMultiMixinAppService;
        private readonly IWebsiteSearchableMixinAppService _websiteSearchableMixinAppService;
        private readonly IWebsiteSeoMetadataAppService _websiteSeoMetadataAppService;
        public HrJobAppService(IRepository<HrJob, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailAliasMixinAppService mailAliasMixinAppService, IMailThreadAppService mailThreadAppService, IWebsitePublishedMultiMixinAppService websitePublishedMultiMixinAppService, IWebsiteSearchableMixinAppService websiteSearchableMixinAppService, IWebsiteSeoMetadataAppService websiteSeoMetadataAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailAliasMixinAppService = mailAliasMixinAppService;
            _mailThreadAppService = mailThreadAppService;
            _websitePublishedMultiMixinAppService = websitePublishedMultiMixinAppService;
            _websiteSearchableMixinAppService = websiteSearchableMixinAppService;
            _websiteSeoMetadataAppService = websiteSeoMetadataAppService;
        }

        protected async Task<HrJob> ActionLoadRecruitmentScenarioInternalAsync()
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

        protected async Task<HrJob> AddressIdDomainInternalAsync()
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

        protected async Task<HrJob> AliasGetCreationValuesInternalAsync()
        {
            /*
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
            */
            return default;
        }

        public async Task<HrJob> CloseDialogAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def close_dialog(self):
            // return {'type': 'ir.actions.act_window_close'}
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrJob> ComputeActivitiesInternalAsync()
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

        protected async Task<HrJob> ComputeAllApplicationCountInternalAsync()
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

        protected async Task<HrJob> ComputeApplicantHiredInternalAsync()
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

        protected async Task<HrJob> ComputeApplicationCountInternalAsync()
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

        protected async Task<HrJob> ComputeDocumentIdsInternalAsync()
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

        protected async Task<HrJob> ComputeEmployeesInternalAsync()
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

        protected async Task<HrJob> ComputeExtendedInterviewerIdsInternalAsync()
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

        protected async Task<HrJob> ComputeFullUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py) ---
            // def _compute_full_url(self):
            // for job in self:
            //     job.full_url = url_join(job.get_base_url(), (job.website_url or '/jobs'))
            */
            return default;
        }

        protected async Task<HrJob> ComputeIsFavoriteInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _compute_is_favorite(self):
            // for job in self:
            //     job.is_favorite = self.env.user in job.favorite_user_ids
            */
            return default;
        }

        protected async Task<HrJob> ComputeNewApplicationCountInternalAsync()
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

        protected async Task<HrJob> ComputeNoOfHiredEmployeeInternalAsync()
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

        protected async Task<HrJob> ComputeOldApplicationCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _compute_old_application_count(self):
            // for job in self:
            //     job.old_application_count = job.application_count - job.new_application_count
            */
            return default;
        }

        protected async Task<HrJob> ComputePublishedDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py) ---
            // def _compute_published_date(self):
            // for job in self:
            //     job.published_date = job.website_published and fields.Date.today()
            */
            return default;
        }

        protected async Task<HrJob> ComputeWebsiteUrlInternalAsync()
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

        public async Task<HrJob> CopyDataAsync(Guid id, HrJobCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_job.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // return [dict(vals, name=self.env._("%s (copy)", job.name)) for job, vals in zip(self, vals_list)]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<HrJob> CreateAsync(HrJob entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_job.py) ---
            // def create(self, vals_list):
            // """ We don't want the current user to be follower of all created job """
            // return super(Job, self.with_context(mail_create_nosubscribe=True)).create(vals_list)
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
            */
            return await base.CreateAsync(entity, fields);
        }

        protected async Task<HrJob> CreationSubtypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _creation_subtype(self):
            // return self.env.ref('hr_recruitment.mt_job_new')
            */
            return default;
        }

        protected async Task<HrJob> DefaultAddressIdInternalAsync()
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

        public async Task<HrJob> EditDialogAsync(Guid id)
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
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrJob> GetBackendMenuIdAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py) ---
            // def get_backend_menu_id(self):
            // return self.env.ref('hr_recruitment.menu_hr_recruitment_root').id
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrJob> GetDefaultFavoriteUserIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_job.py) ---
            // def _get_default_favorite_user_ids(self):
            // return [(6, 0, [self.env.uid])]
            */
            return default;
        }

        protected async Task<HrJob> GetDefaultJobDetailsInternalAsync()
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

        protected async Task<HrJob> GetDefaultWebsiteDescriptionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py) ---
            // def _get_default_website_description(self):
            // return self.env['ir.qweb']._render("website_hr_recruitment.default_website_description", raise_if_not_found=False)
            */
            return default;
        }

        protected async Task<HrJob> GetFirstStageInternalAsync()
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

        protected async Task<HrJob> InverseIsFavoriteInternalAsync()
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

        public async Task<HrJob> NewSurveyAsync(Guid id)
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
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrJob> OnchangeWebsitePublishedInternalAsync()
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

        public async Task<HrJob> OpenActivitiesAsync(Guid id)
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
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrJob> OpenAttachmentsAsync(Guid id)
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
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrJob> OpenLateActivitiesAsync(Guid id)
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
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrJob> OpenTodayActivitiesAsync(Guid id)
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
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrJob> OrderFieldToSqlInternalAsync(object @alias, object field_name, object direction, object nulls, object query)
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
            */
            return default;
        }

        protected async Task<HrJob> SearchGetDetailInternalAsync(object website, object order, object options)
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

        public async Task<HrJob> SearchMatchingCandidatesAsync(Guid id)
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
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrJob> SetOpenAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py) ---
            // def set_open(self):
            // self.write({'website_published': False})
            // return super(Job, self).set_open()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrJob> TestSurveyAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment_survey, FILE: hr_job.py) ---
            // def action_test_survey(self):
            // self.ensure_one()
            // action = self.survey_id.action_test_survey()
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<HrJob> ToggleActiveAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_job.py) ---
            // def toggle_active(self):
            // self.filtered('active').website_published = False
            // return super().toggle_active()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, HrJob entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr, FILE: hr_job.py) ---
            // def write(self, vals):
            // if len(self) == 1:
            //     handle_history_divergence(self, 'description', vals)
            // return super(Job, self).write(vals)
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
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}