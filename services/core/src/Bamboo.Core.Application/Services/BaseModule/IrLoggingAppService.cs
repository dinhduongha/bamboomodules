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
    public class IrLoggingAppService : GenericApplicationService<IrLogging>, IIrLoggingAppService
    {

        public IrLoggingAppService(IRepository<IrLogging, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public async Task<IrLogging> InitAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_logging.py) ---
            // def init(self):
            // super(IrLogging, self).init()
            // self._cr.execute("select 1 from information_schema.constraint_column_usage where table_name = 'ir_logging' and constraint_name = 'ir_logging_write_uid_fkey'")
            // if self._cr.rowcount:
            //     # DROP CONSTRAINT unconditionally takes an ACCESS EXCLUSIVE lock
            //     # on the table, even "IF EXISTS" is set and not matching; disabling
            //     # the relevant trigger instead acquires SHARE ROW EXCLUSIVE, which
            //     # still conflicts with the ROW EXCLUSIVE needed for an insert
            //     self._cr.execute("ALTER TABLE ir_logging DROP CONSTRAINT ir_logging_write_uid_fkey")
            */
            var entity = await Repository.GetAsync(id); return entity;
        }
    }
}