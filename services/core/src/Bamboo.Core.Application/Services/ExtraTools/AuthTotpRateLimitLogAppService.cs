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
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("AuthTotpMailEnforce", Category = "ExtraTools", Depends = new[] { "auth_totp", "mail" })]
    public partial class AuthTotpRateLimitLogAppService : GenericAppService<AuthTotpRateLimitLog>, IAuthTotpRateLimitLogAppService
    {

        public AuthTotpRateLimitLogAppService(IRepository<AuthTotpRateLimitLog, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {

        }

        public async Task<AuthTotpRateLimitLog> InitAsync(Guid[] ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_totp_mail_enforce, FILE: auth_totp_rate_limit_log.py) ---
            // def init(self):
            // self.env.cr.execute("""
            //     CREATE INDEX IF NOT EXISTS auth_totp_rate_limit_log_user_id_limit_type_create_date_idx
            //     ON auth_totp_rate_limit_log(user_id, limit_type, create_date);
            // """)
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}