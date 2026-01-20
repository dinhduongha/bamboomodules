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
    public partial class HrTalentPoolAppService : GenericApplicationService<HrTalentPool>, IHrTalentPoolAppService
    {
        private readonly IMailThreadAppService _mailThreadAppService;
        public HrTalentPoolAppService(IRepository<HrTalentPool, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailThreadAppService mailThreadAppService) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {
            _mailThreadAppService = mailThreadAppService;
        }

        protected async Task<HrTalentPool> ComputeTalentCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_talent_pool.py) ---
            // def _compute_talent_count(self):
            // talents = self.env["hr.applicant"]._read_group(
            //     domain=[("talent_pool_ids", "in", self.ids)], groupby=["talent_pool_ids"], aggregates=["__count"]
            // )
            // talent_data = {talent_pool.id: count for talent_pool, count in talents}
            // for pool in self:
            //     pool.no_of_talents = talent_data.get(pool.id, 0)
            */
            return default;
        }

        protected async Task<HrTalentPool> GetDefaultColorInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_talent_pool.py) ---
            // def _get_default_color(self):
            // return randint(1, 11)
            */
            return default;
        }

        public async Task<HrTalentPool> TalentPoolAddTalentsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: hr_recruitment, FILE: hr_talent_pool.py) ---
            // def action_talent_pool_add_talents(self):
            // self.ensure_one()
            // return {
            //     "name": self.env._("Create Talent"),
            //     "type": "ir.actions.act_window",
            //     "res_model": "hr.applicant",
            //     "views": [[False, "form"]],
            //     "context": {
            //         "default_talent_pool_ids": [self.id],
            //     },
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}