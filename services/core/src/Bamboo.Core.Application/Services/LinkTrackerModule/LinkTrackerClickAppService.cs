using Bamboo.Core.Application.Contracts.DTOs;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Models;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Bamboo.Core.Application.Services
{
    [Module("LinkTrackerModule", Depends = new[] { "utm", "mail" })]
    public class LinkTrackerClickAppService : GenericApplicationService<LinkTrackerClick>, ILinkTrackerClickAppService
    {

        public LinkTrackerClickAppService(IRepository<LinkTrackerClick, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {

        }

        public async Task<LinkTrackerClick> AddClickAsync(Guid id, LinkTrackerClickAddClickRequestDto input)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: link_tracker, FILE: link_tracker.py) ---
            // def add_click(self, code, **route_values):
            // """ Main API to add a click on a link. """
            // tracker_code = self.env['link.tracker.code'].search([('code', '=', code)])
            // if not tracker_code:
            //     return None
            // 
            // route_values['link_id'] = tracker_code.link_id.id
            // click_values = self._prepare_click_values_from_route(**route_values)
            // 
            // return self.create(click_values)
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: link_tracker.py) ---
            // def add_click(self, code, **route_values):
            // click = super(LinkTrackerClick, self).add_click(code, **route_values)
            // 
            // if click and click.mailing_trace_id:
            //     click.mailing_trace_id.set_opened()
            //     click.mailing_trace_id.set_clicked()
            // 
            // return click
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<LinkTrackerClick> PrepareClickValuesFromRouteInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: link_tracker, FILE: link_tracker.py) ---
            // def _prepare_click_values_from_route(self, **route_values):
            // click_values = dict((fname, route_values[fname]) for fname in self._fields if fname in route_values)
            // if not click_values.get('country_id') and route_values.get('country_code'):
            //     click_values['country_id'] = self.env['res.country'].search([('code', '=', route_values['country_code'])], limit=1).id
            // return click_values
            --- ODOO METHOD SOURCE (MODULE: mass_mailing, FILE: link_tracker.py) ---
            // def _prepare_click_values_from_route(self, **route_values):
            // click_values = super(LinkTrackerClick, self)._prepare_click_values_from_route(**route_values)
            // 
            // if click_values.get('mailing_trace_id'):
            //     trace_sudo = self.env['mailing.trace'].sudo().browse(route_values['mailing_trace_id']).exists()
            //     if not trace_sudo:
            //         click_values['mailing_trace_id'] = False
            //     else:
            //         if not click_values.get('campaign_id'):
            //             click_values['campaign_id'] = trace_sudo.campaign_id.id
            //         if not click_values.get('mass_mailing_id'):
            //             click_values['mass_mailing_id'] = trace_sudo.mass_mailing_id.id
            // 
            // return click_values
            */
            return default;
        }
    }
}