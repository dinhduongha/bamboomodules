using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("base", Category = "Base")]
    public class IrAutovacuumAppService : ApplicationService, IIrAutovacuumAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public IrAutovacuumAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> GcOrmSignalingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrAutovacuumable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_autovacuum.py) ---
            // def _gc_orm_signaling(self):
            // for signal in ['registry', *_CACHES_BY_KEY]:
            //     table = f'orm_signaling_{signal}'
            //     # keep the last 10 entries for each signal, and all entries from the last
            //     # hour. This keeps the signaling tables small enough for performance, but
            //     # also gives a useful glimpse into the recent signaling history, including
            //     # the timestamps of the increments.
            //     self.env.cr.execute(SQL(
            //         "DELETE FROM %s WHERE id < (SELECT max(id)-9 FROM %s) AND date < NOW() - interval '1 hours'",
            //         SQL.identifier(table), SQL.identifier(table)
            //     ))
            */
            return default;
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
            // if not self.env.is_admin() or not self.env.context.get('cron_id'):
            //     raise AccessDenied()
            // 
            // all_methods = [
            //     (model, attr, func)
            //     for model in self.env.values()
            //     for attr, func in inspect.getmembers(model.__class__, is_autovacuum)
            // ]
            // # shuffle methods at each run, prevents one blocking method from always
            // # starving the following ones
            // random.shuffle(all_methods)
            // queue = collections.deque(all_methods)
            // while queue and self.env['ir.cron']._commit_progress(remaining=len(queue)):
            //     model, attr, func = queue.pop()
            //     _logger.debug('Calling %s.%s()', model, attr)
            //     try:
            //         start_time = time.monotonic()
            //         result = func(model)
            //         self.env['ir.cron']._commit_progress(1)
            //         if isinstance(result, tuple) and len(result) == 2:
            //             func_done, func_remaining = result
            //             _logger.debug(
            //                 '%s.%s  vacuumed %r records, remaining %r',
            //                 model, attr, func_done, func_remaining,
            //             )
            //             if func_remaining:
            //                 queue.appendleft((model, attr, func))
            //         _logger.debug("%s.%s  took %.2fs", model, attr, time.monotonic() - start_time)
            //     except Exception:
            //         _logger.exception("Failed %s.%s()", model, attr)
            //         self.env.cr.rollback()
            */
            return default;
        }
    }
}