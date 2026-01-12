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
    [Module("HrRecruitment", Category = "HumanResources", Depends = new[] { "hr", "calendar", "utm", "attachment_indexation", "web_tour", "digest" })]
    public class HrRecruitmentSourceAppService : GenericApplicationService<HrRecruitmentSource>, IHrRecruitmentSourceAppService
    {
        private readonly IUtmSourceMixinAppService _utmSourceMixinAppService;
        public HrRecruitmentSourceAppService(IRepository<HrRecruitmentSource, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IUtmSourceMixinAppService utmSourceMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _utmSourceMixinAppService = utmSourceMixinAppService;
        }

        protected async Task<HrRecruitmentSource> ComputeHasDomainInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_recruitment_source.py) ---
            // def _compute_has_domain(self):
            // for source in self:
            //     if source.alias_id:
            //         source.has_domain = bool(source.alias_id.alias_domain_id)
            //     else:
            //         source.has_domain = bool(source.job_id.company_id.alias_domain_id
            //                                  or self.env.company.alias_domain_id)
            */
            return default;
        }

        protected async Task<HrRecruitmentSource> ComputeUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_hr_recruitment, FILE: hr_recruitment_source.py) ---
            // def _compute_url(self):
            // for source in self:
            //     source.url = urls.url_join(source.job_id.get_base_url(), "%s?%s" % (
            //         source.job_id.website_url,
            //         urls.url_encode({
            //             'utm_campaign': self.env.ref('hr_recruitment.utm_campaign_job').name,
            //             'utm_medium': source.medium_id.name or self.env['utm.medium']._fetch_or_create_utm_medium('website').name,
            //             'utm_source': source.source_id.name or None
            //         })
            //     ))
            */
            return default;
        }

        public async Task<HrRecruitmentSource> CreateAliasAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_recruitment_source.py) ---
            // def create_alias(self):
            // campaign = self.env.ref('hr_recruitment.utm_campaign_job')
            // medium = self.env['utm.medium']._fetch_or_create_utm_medium('email')
            // for source in self.filtered(lambda s: not s.alias_id):
            //     vals = {
            //         'alias_defaults': {
            //             'job_id': source.job_id.id,
            //             'campaign_id': campaign.id,
            //             'medium_id': medium.id,
            //             'source_id': source.source_id.id,
            //         },
            //         'alias_domain_id': source.job_id.company_id.alias_domain_id.id or self.env.company.alias_domain_id.id,
            //         'alias_model_id': self.env['ir.model']._get_id('hr.applicant'),
            //         'alias_name': f"{source.job_id.alias_name or source.job_id.name}+{source.name}",
            //         'alias_parent_thread_id': source.job_id.id,
            //         'alias_parent_model_id': self.env['ir.model']._get_id('hr.job'),
            //     }
            // 
            //     # check that you can create source before to call mail.alias in sudo with known/controlled vals
            //     source.check_access('create')
            //     source.alias_id = self.env['mail.alias'].sudo().create(vals)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}