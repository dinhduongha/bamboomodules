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
    public interface IAuthorizationService : ITransientDependency
    {
        Task CheckAccessAsync(string modelName, string operation);
        Task<IQueryable<TEntity>> ApplyRulesAsync<TEntity>(IQueryable<TEntity> query, string modelName)
            where TEntity : class, IEntity<Guid>;
        Task<Dictionary<string, bool>>? GetFieldAccessAsync(string modelName, string operation);
    }
}