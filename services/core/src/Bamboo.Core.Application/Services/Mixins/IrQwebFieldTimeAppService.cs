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
    [Module("base", Category = "Base")]
    public partial class IrQwebFieldTimeAppService : ApplicationService, IIrQwebFieldTimeAppService
    {
        private readonly IServiceProvider _serviceProvider;
        public IrQwebFieldTimeAppService(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        [ApiModel]
        public async Task<TEntity> ValueToHtmlAsync<TEntity>(IEnumerable<TEntity> entities, object @value, object options) where TEntity : IEntity<Guid>, IIrQwebFieldTimeable
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: base, FILE: ir_qweb_fields.py) ---
            // def value_to_html(self, value, options):
            // if value < 0:
            //     raise ValueError(_("The value (%s) passed should be positive", value))
            // hours, minutes = divmod(int(abs(value) * 60), 60)
            // if hours > 23:
            //     raise ValueError(_("The hour must be between 0 and 23"))
            // t = time(hour=hours, minute=minutes)
            // 
            // locale = babel_locale_parse(self.user_lang().code)
            // pattern = options.get('format', 'short')
            // 
            // return babel.dates.format_time(t, format=pattern, tzinfo=None, locale=locale)
            */
            return default;
        }
    }
}