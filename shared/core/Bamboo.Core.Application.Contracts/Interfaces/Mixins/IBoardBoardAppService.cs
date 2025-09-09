using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
namespace Bamboo.Core.Application.Contracts.Interfaces.Mixins
{
    public interface IBoardBoardAppService : IMixinAppService
    {
        Task<TEntity> ArchPreprocessingInternalAsync<TEntity>(IEnumerable<TEntity> entities, object arch) where TEntity : IEntity<Guid>, IBoardBoardable;
        Task<TEntity> CreateAsync<TEntity>(IEnumerable<TEntity> entities, object vals_list) where TEntity : IEntity<Guid>, IBoardBoardable;
        Task<TEntity> GetViewAsync<TEntity>(IEnumerable<TEntity> entities, Guid view_id, object view_type) where TEntity : IEntity<Guid>, IBoardBoardable;
    }
}