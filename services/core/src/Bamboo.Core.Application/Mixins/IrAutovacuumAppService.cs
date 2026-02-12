using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;
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
    public partial class IrAutovacuumAppService : ApplicationService, IIrAutovacuumAppService
    {

        public IrAutovacuumAppService() 
        {

        }

        public async Task<TEntity> GcOrmSignalingInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrAutovacuumable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_autovacuum.py, METHOD: _gc_orm_signaling) ---
            */
            return default;
        }

        public async Task<TEntity> RunVacuumCleanerInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IIrAutovacuumable
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: ir_autovacuum.py, METHOD: _run_vacuum_cleaner) ---
            */
            return default;
        }
    }
}