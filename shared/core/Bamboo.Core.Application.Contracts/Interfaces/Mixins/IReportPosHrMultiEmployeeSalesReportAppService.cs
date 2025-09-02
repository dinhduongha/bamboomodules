using Volo.Abp.Application.Services;
using System.Linq;
using Volo.Abp.Domain.Entities;
using System.Collections.Generic;
using Bamboo.Core.Domain.Shared.Interfaces;
using System;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using System.Threading.Tasks;
namespace Bamboo.Core.Application.Contracts.Interfaces.Mixins
{
    public interface IReportPosHrMultiEmployeeSalesReportAppService : IMixinAppService
    {
        Task<TEntity> GetReportValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object docids, object data) where TEntity : IEntity<Guid>, IReportPosHrMultiEmployeeSalesReportable;
    }
}