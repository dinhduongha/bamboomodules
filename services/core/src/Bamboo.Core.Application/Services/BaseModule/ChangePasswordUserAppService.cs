using Bamboo.Core.Application.Contracts.DTOs;
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
    [Module("BaseModule")]
    public class ChangePasswordUserAppService : GenericApplicationService<ChangePasswordUser>, IChangePasswordUserAppService
    {

        public ChangePasswordUserAppService(IRepository<ChangePasswordUser, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public async Task<ChangePasswordUser> ChangePasswordButtonAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: res_users.py) ---
            // def change_password_button(self):
            // for line in self:
            //     if line.new_passwd:
            //         line.user_id._change_password(line.new_passwd)
            // # don't keep temporary passwords in the database longer than necessary
            // self.write({'new_passwd': False})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}