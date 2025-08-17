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
    [Module("base")]
    public class IrQwebFieldQwebAppService : ApplicationService, IIrQwebFieldQwebAppService
    {

        public IrQwebFieldQwebAppService() 
        {

        }

        public async Task<TEntity> RecordToHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object record, object field_name, object options) where TEntity : IEntity<Guid>, IIrQwebFieldQwebable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb_fields.py) ---
            // def record_to_html(self, record, field_name, options):
            // view = record[field_name]
            // if not view:
            //     return ''
            // 
            // if view._name != "ir.ui.view":
            //     _logger.warning("%s.%s must be a 'ir.ui.view', got %r.", record, field_name, view._name)
            //     return ''
            // 
            // return self.env['ir.qweb']._render(view.id, options.get('values', {}))
            */
            return default;
        }
    }
}