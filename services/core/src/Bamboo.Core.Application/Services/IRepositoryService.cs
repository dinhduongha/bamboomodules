// Generic service interface
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Bamboo.Core.Application;
public interface IRepositoryService<TEntity> : ITransientDependency
        where TEntity : class, IEntity<Guid>
{
    Task InsertManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default);
    Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default);
    Task<TEntity> GetAsync(Guid id, CancellationToken cancellationToken = default);
}

// Generic service implementation
public class RepositoryService<TEntity> : IRepositoryService<TEntity>, ITransientDependency
    where TEntity : class, IEntity<Guid>
{
    private readonly IRepository<TEntity, Guid> _repository;

    public RepositoryService(IRepository<TEntity, Guid> repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    public async Task InsertManyAsync(IEnumerable<TEntity> entities, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        await _repository.InsertManyAsync(entities, autoSave, cancellationToken);
    }

    public async Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        return await _repository.UpdateAsync(entity, autoSave, cancellationToken);
    }

    public async Task<TEntity> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _repository.GetAsync(id);
    }
}