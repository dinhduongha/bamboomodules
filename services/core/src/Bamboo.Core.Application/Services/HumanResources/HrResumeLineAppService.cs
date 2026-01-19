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
    [Module("HrSkills", Category = "HumanResources", Depends = new[] { "hr" })]
    public partial class HrResumeLineAppService : GenericApplicationService<HrResumeLine>, IHrResumeLineAppService
    {

        public HrResumeLineAppService(IRepository<HrResumeLine, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<HrResumeLine> ComputeChannelIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_skills_slides, FILE: hr_resume_line.py) ---
            // def _compute_channel_id(self):
            // for resume_line in self:
            //     if resume_line.course_type != 'elearning':
            //         resume_line.channel_id = False
            */
            return default;
        }

        protected async Task<HrResumeLine> ComputeColorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_skills, FILE: hr_resume_line.py) ---
            // def _compute_color(self):
            // for resume_line in self:
            //     if resume_line.course_type == 'external':
            //         resume_line.color = '#a2a2a2'
            --- ODOO METHOD SOURCE (MODULE: hr_skills_event, FILE: hr_resume_line.py) ---
            // def _compute_color(self):
            // super()._compute_color()
            // for resume_line in self:
            //     if resume_line.course_type == 'onsite':
            //         resume_line.color = '#714a66'
            --- ODOO METHOD SOURCE (MODULE: hr_skills_slides, FILE: hr_resume_line.py) ---
            // def _compute_color(self):
            // super()._compute_color()
            // for resume_line in self:
            //     if resume_line.course_type == 'elearning':
            //         resume_line.color = '#00a5b7'
            */
            return default;
        }

        protected async Task<HrResumeLine> ComputeDurationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_skills_slides, FILE: hr_resume_line.py) ---
            // def _compute_duration(self):
            // for resume_line in self:
            //     resume_line.duration = resume_line.channel_id.total_time
            */
            return default;
        }

        protected async Task<HrResumeLine> ComputeEventIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_skills_event, FILE: hr_resume_line.py) ---
            // def _compute_event_id(self):
            // for resume_line in self:
            //     if resume_line.course_type != 'onsite':
            //         resume_line.event_id = False
            */
            return default;
        }

        protected async Task<HrResumeLine> ComputeExpirationStatusInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_skills_survey, FILE: hr_resume_line.py) ---
            // def _compute_expiration_status(self):
            // self.expiration_status = 'valid'
            // for line in self:
            //     if line.date_end:
            //         if line.date_end <= fields.Date.today():
            //             line.expiration_status = 'expired'
            //         elif line.date_end + relativedelta(months=-3) <= fields.Date.today():
            //             line.expiration_status = 'expiring'
            */
            return default;
        }

        protected async Task<HrResumeLine> ComputeExternalUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_skills, FILE: hr_resume_line.py) ---
            // def _compute_external_url(self):
            // for resume_line in self:
            //     if resume_line.course_type != 'external':
            //         resume_line.external_url = ''
            */
            return default;
        }

        public async Task<HrResumeLine> CopyDataAsync(Guid id, HrResumeLineCopyDataRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_skills_survey, FILE: hr_resume_line.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // return [dict(vals, name=self.env._("%s (copy)", resume_line.name)) for resume_line, vals in zip(self, vals_list)]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<HrResumeLine> OnchangeChannelIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_skills_slides, FILE: hr_resume_line.py) ---
            // def _onchange_channel_id(self):
            // if not self.name and self.channel_id:
            //     self.name = self.channel_id.name
            */
            return default;
        }

        protected async Task<HrResumeLine> OnchangeEventIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_skills_event, FILE: hr_resume_line.py) ---
            // def _onchange_event_id(self):
            // if not self.name and self.event_id:
            //     self.name = self.event_id.name
            */
            return default;
        }

        protected async Task<HrResumeLine> OnchangeExternalUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_skills, FILE: hr_resume_line.py) ---
            // def _onchange_external_url(self):
            // if not self.name and self.external_url:
            //     website_name_match = re.search(r'((https|http):\/\/)?(www\.)?(.*)\.', self.external_url)
            //     if website_name_match:
            //         self.name = website_name_match.group(4).capitalize()
            */
            return default;
        }
    }
}