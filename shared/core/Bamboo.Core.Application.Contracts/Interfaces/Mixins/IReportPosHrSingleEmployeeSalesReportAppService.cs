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
    public interface IReportPosHrSingleEmployeeSalesReportAppService : IMixinAppService
    {
        Task<TEntity> GetDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_start, object date_stop, List<Guid> config_ids, List<Guid> session_ids, Guid employee_id) where TEntity : IEntity<Guid>, IReportPosHrSingleEmployeeSalesReportable;
        Task<TEntity> GetSaleDetailsAsync<TEntity>(IEnumerable<TEntity> entities, object date_start, object date_stop, List<Guid> config_ids, List<Guid> session_ids, Guid employee_id) where TEntity : IEntity<Guid>, IReportPosHrSingleEmployeeSalesReportable;
        Task<TEntity> PrepareGetSaleDetailsArgsKwargsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IReportPosHrSingleEmployeeSalesReportable;
    }
}