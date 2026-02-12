using Volo.Abp.ObjectMapping;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Interfaces;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("barcodes", Category = "SupplyChain", Depends = new[] { "web" })]
    public partial class BarcodesBarcodeEventsMixinAppService : ApplicationService, IBarcodesBarcodeEventsMixinAppService
    {

        public BarcodesBarcodeEventsMixinAppService() 
        {

        }

        public async Task<TEntity> OnBarcodeScannedAsync<TEntity>(IEnumerable<TEntity> entities, object barcode) where TEntity : IEntity<Guid>, IBarcodesBarcodeEventsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: barcodes, FILE: barcode_events_mixin.py, METHOD: on_barcode_scanned) ---
            */
            return default;
        }

        public async Task<TEntity> OnBarcodeScannedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBarcodesBarcodeEventsMixinable
        {
            /*
            --- METHOD SOURCE (MODULE: barcodes, FILE: barcode_events_mixin.py, METHOD: _on_barcode_scanned) ---
            */
            return default;
        }
    }
}