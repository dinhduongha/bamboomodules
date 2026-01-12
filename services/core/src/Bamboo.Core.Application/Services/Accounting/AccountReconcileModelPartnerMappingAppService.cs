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
    [Module("Account", Category = "Accounting", Depends = new[] { "base_setup", "onboarding", "product", "analytic", "portal", "digest" })]
    public class AccountReconcileModelPartnerMappingAppService : GenericApplicationService<AccountReconcileModelPartnerMapping>, IAccountReconcileModelPartnerMappingAppService
    {

        public AccountReconcileModelPartnerMappingAppService(IRepository<AccountReconcileModelPartnerMapping, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public async Task<AccountReconcileModelPartnerMapping> ValidateRegexAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: account, FILE: account_reconcile_model.py) ---
            // def validate_regex(self):
            // for record in self:
            //     if not (record.narration_regex or record.payment_ref_regex):
            //         raise ValidationError(_("Please set at least one of the match texts to create a partner mapping."))
            //     current_regex = None
            //     try:
            //         if record.payment_ref_regex:
            //             current_regex = record.payment_ref_regex
            //             re.compile(record.payment_ref_regex)
            //         if record.narration_regex:
            //             current_regex = record.narration_regex
            //             re.compile(record.narration_regex)
            //     except re.error:
            //         raise ValidationError(_("The following regular expression is invalid to create a partner mapping: %s", current_regex))
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}