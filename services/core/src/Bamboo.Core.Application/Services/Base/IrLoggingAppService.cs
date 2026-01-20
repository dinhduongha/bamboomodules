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
    [Module("BaseModule", Category = "Base")]
    public partial class IrLoggingAppService : GenericApplicationService<IrLogging>, IIrLoggingAppService
    {

        public IrLoggingAppService(IRepository<IrLogging, Guid> repository, IServiceProvider serviceProvider, IDataFilter dataFilter, IObjectMapper objectMapper, IDistributedCache cache, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, serviceProvider, dataFilter, objectMapper, cache, authorizationService, domainParser, modelTypeRegistry)
        {

        }

        public async Task<IrLogging> InitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_logging.py) ---
            // def init(self):
            // super(IrLogging, self).init()
            // self.env.cr.execute("select 1 from information_schema.constraint_column_usage where table_name = 'ir_logging' and constraint_name = 'ir_logging_write_uid_fkey'")
            // if self.env.cr.rowcount:
            //     # DROP CONSTRAINT unconditionally takes an ACCESS EXCLUSIVE lock
            //     # on the table, even "IF EXISTS" is set and not matching; disabling
            //     # the relevant trigger instead acquires SHARE ROW EXCLUSIVE, which
            //     # still conflicts with the ROW EXCLUSIVE needed for an insert
            //     self.env.cr.execute("ALTER TABLE ir_logging DROP CONSTRAINT ir_logging_write_uid_fkey")
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}