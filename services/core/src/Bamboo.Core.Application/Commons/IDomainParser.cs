using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text.Json;

using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities;
namespace Bamboo.Core.Application
{
    public interface IDomainParser : ITransientDependency
    {
        Task<IQueryable<TEntity>> ApplyDomain<TEntity>(IQueryable<TEntity> query, JsonElement? domain) where TEntity : class, IEntity<Guid>;
    }
}