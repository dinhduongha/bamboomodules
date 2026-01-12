using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Data;
using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;

namespace Bamboo.Core.Application.Services
{
    [Module("WebsiteEventExhibitor", Category = "Marketing", Depends = new[] { "website_event" })]
    public class EventSponsorAppService : GenericApplicationService<EventSponsor>, IEventSponsorAppService
    {
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        private readonly IWebsitePublishedMixinAppService _websitePublishedMixinAppService;
        private readonly IWebsiteSearchableMixinAppService _websiteSearchableMixinAppService;
        public EventSponsorAppService(IRepository<EventSponsor, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService, IWebsitePublishedMixinAppService websitePublishedMixinAppService, IWebsiteSearchableMixinAppService websiteSearchableMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
            _websitePublishedMixinAppService = websitePublishedMixinAppService;
            _websiteSearchableMixinAppService = websiteSearchableMixinAppService;
        }

        protected async Task<EventSponsor> ComputeCountryFlagUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py) ---
            // def _compute_country_flag_url(self):
            // for sponsor in self:
            //     if sponsor.partner_id.country_id:
            //         sponsor.country_flag_url = sponsor.partner_id.country_id.image_url
            //     else:
            //         sponsor.country_flag_url = False
            */
            return default;
        }

        protected async Task<EventSponsor> ComputeEmailInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py) ---
            // def _compute_email(self):
            // self._synchronize_with_partner('email')
            */
            return default;
        }

        protected async Task<EventSponsor> ComputeImage512InternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py) ---
            // def _compute_image_512(self):
            // self._synchronize_with_partner('image_512')
            */
            return default;
        }

        protected async Task<EventSponsor> ComputeIsInOpeningHoursInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py) ---
            // def _compute_is_in_opening_hours(self):
            // """ Opening hours: hour_from and hour_to are given within event TZ or UTC.
            // Now() must therefore be computed based on that TZ. """
            // for sponsor in self:
            //     if not sponsor.event_id.is_ongoing:
            //         sponsor.is_in_opening_hours = False
            //     elif sponsor.hour_from is False or sponsor.hour_to is False:
            //         sponsor.is_in_opening_hours = True
            //     else:
            //         event_tz = timezone(sponsor.event_id.date_tz)
            //         # localize now, begin and end datetimes in event tz
            //         dt_begin = sponsor.event_id.date_begin.astimezone(event_tz)
            //         dt_end = sponsor.event_id.date_end.astimezone(event_tz)
            //         now_utc = utc.localize(fields.Datetime.now().replace(microsecond=0))
            //         now_tz = now_utc.astimezone(event_tz)
            // 
            //         # compute opening hours
            //         opening_from_tz = event_tz.localize(datetime.combine(now_tz.date(), float_to_time(sponsor.hour_from)))
            //         opening_to_tz = event_tz.localize(datetime.combine(now_tz.date(), float_to_time(sponsor.hour_to)))
            //         if sponsor.hour_to == 0:
            //             # when closing 'at midnight', we consider it's at midnight the next day
            //             opening_to_tz = opening_to_tz + timedelta(days=1)
            // 
            //         opening_from = max([dt_begin, opening_from_tz])
            //         opening_to = min([dt_end, opening_to_tz])
            // 
            //         sponsor.is_in_opening_hours = opening_from <= now_tz < opening_to
            */
            return default;
        }

        protected async Task<EventSponsor> ComputeNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py) ---
            // def _compute_name(self):
            // self._synchronize_with_partner('name')
            */
            return default;
        }

        protected async Task<EventSponsor> ComputePhoneInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py) ---
            // def _compute_phone(self):
            // self._synchronize_with_partner('phone')
            */
            return default;
        }

        protected async Task<EventSponsor> ComputeUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py) ---
            // def _compute_url(self):
            // for sponsor in self:
            //     if sponsor.partner_id.website or not sponsor.url:
            //         sponsor.url = sponsor.partner_id.website
            */
            return default;
        }

        protected async Task<EventSponsor> ComputeWebsiteAbsoluteUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py) ---
            // def _compute_website_absolute_url(self):
            // super()._compute_website_absolute_url()
            */
            return default;
        }

        protected async Task<EventSponsor> ComputeWebsiteDescriptionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py) ---
            // def _compute_website_description(self):
            // for sponsor in self:
            //     if is_html_empty(sponsor.website_description):
            //         sponsor.website_description = sponsor.partner_id.website_description
            */
            return default;
        }

        protected async Task<EventSponsor> ComputeWebsiteImageUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py) ---
            // def _compute_website_image_url(self):
            // for sponsor in self:
            //     if sponsor.image_512:
            //         # image_512 is stored, image_256 is derived from it dynamically
            //         sponsor.website_image_url = self.env['website'].image_url(sponsor, 'image_256', size=256)
            //     elif sponsor.partner_id.image_256:
            //         sponsor.website_image_url = self.env['website'].image_url(sponsor.partner_id, 'image_256', size=256)
            //     else:
            //         sponsor.website_image_url = '/website_event_exhibitor/static/src/img/event_sponsor_default.svg'
            */
            return default;
        }

        protected async Task<EventSponsor> ComputeWebsiteUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py) ---
            // def _compute_website_url(self):
            // super()._compute_website_url()
            // for sponsor in self:
            //     if sponsor.id:  # avoid to perform a slug on a not yet saved record in case of an onchange.
            //         sponsor.website_url = f'/event/{self.env["ir.http"]._slug(sponsor.event_id)}/exhibitor/{self.env["ir.http"]._slug(sponsor)}'
            */
            return default;
        }

        protected async Task<EventSponsor> DefaultSponsorTypeIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py) ---
            // def _default_sponsor_type_id(self):
            // return self.env['event.sponsor.type'].search([], order="sequence desc", limit=1).id
            */
            return default;
        }

        public async Task<EventSponsor> GetBackendMenuIdAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py) ---
            // def get_backend_menu_id(self):
            // return self.env.ref('event.event_main_menu').id
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<EventSponsor> GetBaseUrlAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py) ---
            // def get_base_url(self):
            // """As website_id is not defined on this record, we rely on event website_id for base URL."""
            // return self.event_id.get_base_url()
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<EventSponsor> SearchGetDetailInternalAsync(object website, object order, object options)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py) ---
            // def _search_get_detail(self, website, order, options):
            // event_id = self.env['ir.http']._unslug(options['event'])[1]
            // mapping = {
            //     'name': {'name': 'name', 'type': 'text', 'match': True},
            //     'website_url': {'name': 'website_url', 'type': 'text', 'truncate': False},
            //     'description': {'name': 'website_description', 'type': 'text', 'truncate': True, 'html': True},
            // }
            // return {
            //     'model': 'event.sponsor',
            //     'base_domain': [[('event_id', '=', event_id), ('exhibitor_type', '!=', 'sponsor')]],
            //     'search_fields': ['name', 'website_description'],
            //     'fetch_fields': ['name', 'website_url', 'website_description'],
            //     'mapping': mapping,
            //     'icon': 'fa-black-tie',
            //     'order': order,
            // }
            */
            return default;
        }

        protected async Task<EventSponsor> SynchronizeWithPartnerInternalAsync(object fname)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py) ---
            // def _synchronize_with_partner(self, fname):
            // """ Synchronize with partner if not set. Setting a value does not write
            // on partner as this may be event-specific information. """
            // for sponsor in self:
            //     if not sponsor[fname]:
            //         sponsor[fname] = sponsor.partner_id[fname]
            */
            return default;
        }
    }
}