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
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("SmsTwilio", Category = "Misc", Depends = new[] { "sms" })]
    public class SmsTwilioNumberAppService : GenericApplicationService<SmsTwilioNumber>, ISmsTwilioNumberAppService
    {

        public SmsTwilioNumberAppService(IRepository<SmsTwilioNumber, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        protected async Task<SmsTwilioNumber> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms_twilio, FILE: sms_twilio_number.py) ---
            // def _compute_display_name(self):
            // for record in self:
            //     record.display_name = f"{record.number} ({record.country_id.name})"
            */
            return default;
        }

        public async Task<SmsTwilioNumber> UnlinkAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: sms_twilio, FILE: sms_twilio_number.py) ---
            // def action_unlink(self):
            // # First create the action while self exists as it's going to be unlink right after
            // action = self.company_id._action_open_sms_twilio_account_manage()
            // self.unlink()
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}