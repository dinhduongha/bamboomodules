using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("base")]
    public class IrAutovacuumAppService : ApplicationService, IIrAutovacuumAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public IrAutovacuumAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> RunVacuumCleanerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrAutovacuumable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_autovacuum.py) ---
            // def _run_vacuum_cleaner(self):
            // """
            // Perform a complete database cleanup by safely calling every
            // ``@api.autovacuum`` decorated method.
            // """
            // if not self.env.is_admin():
            //     raise AccessDenied()
            // 
            // for model in self.env.values():
            //     cls = self.env.registry[model._name]
            //     for attr, func in inspect.getmembers(cls, is_autovacuum):
            //         _logger.debug('Calling %s.%s()', model, attr)
            //         try:
            //             func(model)
            //             self.env.cr.commit()
            //         except Exception:
            //             _logger.exception("Failed %s.%s()", model, attr)
            //             self.env.cr.rollback()
            */
            return default;
        }
    }
}