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
    public interface IReportPosHrSingleEmployeeSalesReportAppService : IMixinAppService
    {
        Task<TEntity> GetDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_start, object date_stop, List<Guid> config_ids, List<Guid> session_ids, Guid employee_id) where TEntity : IEntity<Guid>, IReportPosHrSingleEmployeeSalesReportable;
        Task<TEntity> GetSaleDetailsAsync<TEntity>(IEnumerable<TEntity> entities, object date_start, object date_stop, List<Guid> config_ids, List<Guid> session_ids, Guid employee_id) where TEntity : IEntity<Guid>, IReportPosHrSingleEmployeeSalesReportable;
        Task<TEntity> PrepareGetSaleDetailsArgsKwargsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IReportPosHrSingleEmployeeSalesReportable;
    }
}