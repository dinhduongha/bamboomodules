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
    public interface IBarcodesBarcodeEventsMixinAppService : IMixinAppService
    {
        Task<TEntity> OnBarcodeScannedAsync<TEntity>(IEnumerable<TEntity> entities, object barcode) where TEntity : IEntity<Guid>, IBarcodesBarcodeEventsMixinable;
        Task<TEntity> OnBarcodeScannedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBarcodesBarcodeEventsMixinable;
    }
}