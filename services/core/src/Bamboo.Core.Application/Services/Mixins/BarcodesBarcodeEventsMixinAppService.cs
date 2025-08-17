using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Domain.Shared.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;

namespace Bamboo.Core.Application.Services.Mixins
{
    [Module("barcodes", Depends = new[] { "web" })]
    public class BarcodesBarcodeEventsMixinAppService : ApplicationService, IBarcodesBarcodeEventsMixinAppService
    {

        public BarcodesBarcodeEventsMixinAppService() 
        {

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