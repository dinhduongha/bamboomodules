using Volo.Abp.Domain.Entities;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
namespace Bamboo.Core.Application.Contracts.Interfaces.Mixins
{
    public interface IReportPosHrMultiEmployeeSalesReportAppService : IMixinAppService
    {
        Task<TEntity> GetReportValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object docids, object data) where TEntity : IEntity<Guid>, IReportPosHrMultiEmployeeSalesReportable;
    }
}