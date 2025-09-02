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
    public interface ISpreadsheetMixinAppService : IMixinAppService
    {
        Task<TEntity> ActionGetShareUrlAsync<TEntity>(IEnumerable<TEntity> entities, object vals) where TEntity : IEntity<Guid>, ISpreadsheetMixinable;
        Task<TEntity> CheckDashboardAccessInternalAsync<TEntity>(IEnumerable<TEntity> entities, object access_token) where TEntity : IEntity<Guid>, ISpreadsheetMixinable;
        Task<TEntity> CheckSpreadsheetDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ISpreadsheetMixinable;
        Task<TEntity> CheckTokenInternalAsync<TEntity>(IEnumerable<TEntity> entities, object access_token) where TEntity : IEntity<Guid>, ISpreadsheetMixinable;
        Task<TEntity> ComputeFullUrlInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ISpreadsheetMixinable;
        Task<TEntity> ComputeSpreadsheetDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ISpreadsheetMixinable;
        Task<TEntity> ComputeSpreadsheetFileNameInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ISpreadsheetMixinable;
        Task<TEntity> CopyDataAsync<TEntity>(IEnumerable<TEntity> entities, object @default) where TEntity : IEntity<Guid>, ISpreadsheetMixinable;
        Task<TEntity> DashboardIsEmptyInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ISpreadsheetMixinable;
        Task<TEntity> EmptySpreadsheetDataBase64InternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ISpreadsheetMixinable;
        Task<TEntity> EmptySpreadsheetDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ISpreadsheetMixinable;
        Task<TEntity> GetDisplayNamesForSpreadsheetAsync<TEntity>(IEnumerable<TEntity> entities, object args) where TEntity : IEntity<Guid>, ISpreadsheetMixinable;
        Task<TEntity> GetFileContentInternalAsync<TEntity>(IEnumerable<TEntity> entities, object file_path) where TEntity : IEntity<Guid>, ISpreadsheetMixinable;
        Task<TEntity> GetReadonlyDashboardAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ISpreadsheetMixinable;
        Task<TEntity> GetSampleDashboardInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ISpreadsheetMixinable;
        Task<TEntity> InverseSpreadsheetDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ISpreadsheetMixinable;
        Task<TEntity> OnchangeDataInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, ISpreadsheetMixinable;
        Task<TEntity> ZipXslxFilesInternalAsync<TEntity>(IEnumerable<TEntity> entities, object files) where TEntity : IEntity<Guid>, ISpreadsheetMixinable;
    }
}