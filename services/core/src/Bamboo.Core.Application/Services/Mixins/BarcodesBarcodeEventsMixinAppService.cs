using Volo.Abp.ObjectMapping;
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
        private readonly IServiceProvider _serviceProvider;
        public BarcodesBarcodeEventsMixinAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<TEntity> OnBarcodeScannedAsync<TEntity>(IEnumerable<TEntity> entities, object barcode) where TEntity : IEntity<Guid>, IBarcodesBarcodeEventsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: barcodes, FILE: barcode_events_mixin.py) ---
            // def on_barcode_scanned(self, barcode):
            // raise NotImplementedError(self.env._("In order to use barcodes.barcode_events_mixin, method on_barcode_scanned must be implemented"))
            */
            return default;
        }

        public async Task<TEntity> OnBarcodeScannedInternalAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : IEntity<Guid>, IBarcodesBarcodeEventsMixinable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: barcodes, FILE: barcode_events_mixin.py) ---
            // def _on_barcode_scanned(self):
            // barcode = self._barcode_scanned
            // if barcode:
            //     self._barcode_scanned = ""
            //     return self.on_barcode_scanned(barcode)
            */
            return default;
        }
    }
}