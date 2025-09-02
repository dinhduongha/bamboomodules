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
    public interface IBarcodesBarcodeEventsMixinAppService : IMixinAppService
    {
        Task<TEntity> OnBarcodeScannedAsync<TEntity>(IEnumerable<TEntity> entities, object barcode) where TEntity : IEntity<Guid>, IBarcodesBarcodeEventsMixinable;
        Task<TEntity> OnBarcodeScannedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBarcodesBarcodeEventsMixinable;
    }
}