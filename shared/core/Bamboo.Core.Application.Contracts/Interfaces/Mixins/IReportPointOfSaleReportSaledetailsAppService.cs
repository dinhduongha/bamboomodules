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
    public interface IReportPointOfSaleReportSaledetailsAppService : IMixinAppService
    {
        Task<TEntity> GetDateStartAndDateStopInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_start, object date_stop) where TEntity : IEntity<Guid>, IReportPointOfSaleReportSaledetailsable;
        Task<TEntity> GetDomainInternalAsync<TEntity>(IEnumerable<TEntity> entities, object date_start, object date_stop, List<Guid> config_ids, List<Guid> session_ids, Guid employee_id) where TEntity : IEntity<Guid>, IReportPointOfSaleReportSaledetailsable;
        Task<TEntity> GetProductTotalAmountInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line) where TEntity : IEntity<Guid>, IReportPointOfSaleReportSaledetailsable;
        Task<TEntity> GetProductsAndTaxesDictInternalAsync<TEntity>(IEnumerable<TEntity> entities, object line, object products, object taxes, object currency) where TEntity : IEntity<Guid>, IReportPointOfSaleReportSaledetailsable;
        Task<TEntity> GetReportValuesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object docids, object data) where TEntity : IEntity<Guid>, IReportPointOfSaleReportSaledetailsable;
        Task<TEntity> GetSaleDetailsAsync<TEntity>(IEnumerable<TEntity> entities, object date_start, object date_stop, List<Guid> config_ids, List<Guid> session_ids, Guid employee_id) where TEntity : IEntity<Guid>, IReportPointOfSaleReportSaledetailsable;
        Task<TEntity> GetTaxesInfoInternalAsync<TEntity>(IEnumerable<TEntity> entities, object taxes) where TEntity : IEntity<Guid>, IReportPointOfSaleReportSaledetailsable;
        Task<TEntity> GetTotalAndQtyPerCategoryInternalAsync<TEntity>(IEnumerable<TEntity> entities, object categories) where TEntity : IEntity<Guid>, IReportPointOfSaleReportSaledetailsable;
        Task<TEntity> PrepareGetSaleDetailsArgsKwargsInternalAsync<TEntity>(IEnumerable<TEntity> entities, object data) where TEntity : IEntity<Guid>, IReportPointOfSaleReportSaledetailsable;
    }
}