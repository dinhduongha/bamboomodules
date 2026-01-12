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
    [Module("AuthTotpMailEnforce", Category = "ExtraTools", Depends = new[] { "auth_totp", "mail" })]
    public class AuthTotpRateLimitLogAppService : GenericApplicationService<AuthTotpRateLimitLog>, IAuthTotpRateLimitLogAppService
    {

        public AuthTotpRateLimitLogAppService(IRepository<AuthTotpRateLimitLog, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public async Task<AuthTotpRateLimitLog> InitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: auth_totp_mail_enforce, FILE: auth_totp_rate_limit_log.py) ---
            // def init(self):
            // self.env.cr.execute("""
            //     CREATE INDEX IF NOT EXISTS auth_totp_rate_limit_log_user_id_limit_type_create_date_idx
            //     ON auth_totp_rate_limit_log(user_id, limit_type, create_date);
            // """)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}