using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Application.Services;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.DTOs;
using Microsoft.Extensions.Caching.Memory;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;

namespace Bamboo.Core.Application.Services
{
    [Module("WebsiteEventExhibitor", Depends = new[] { "website_event_jitsi" })]
    public class EventSponsorAppService : GenericApplicationService<EventSponsor>, IEventSponsorAppService
    {
        private readonly IChatRoomMixinAppService _chatRoomMixinAppService;
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        private readonly IWebsitePublishedMixinAppService _websitePublishedMixinAppService;
        public EventSponsorAppService(IRepository<EventSponsor, Guid> repository, IServiceProvider serviceProvider, IAuthorizationService authorizationService, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IChatRoomMixinAppService chatRoomMixinAppService, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService, IWebsitePublishedMixinAppService websitePublishedMixinAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _chatRoomMixinAppService = chatRoomMixinAppService;
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
            _websitePublishedMixinAppService = websitePublishedMixinAppService;
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

        protected async Task<EventSponsor> ComputeMobileInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py) ---
            // def _compute_mobile(self):
            // self._synchronize_with_partner('mobile')
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
            // super(Sponsor, self)._compute_website_url()
            // for sponsor in self:
            //     if sponsor.id:  # avoid to perform a slug on a not yet saved record in case of an onchange.
            //         base_url = sponsor.event_id.get_base_url()
            //         sponsor.website_url = '%s/event/%s/exhibitor/%s' % (base_url, self.env["ir.http"]._slug(sponsor.event_id), self.env["ir.http"]._slug(sponsor))
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

        protected async Task<EventSponsor> MessageGetSuggestedRecipientsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py) ---
            // def _message_get_suggested_recipients(self):
            // recipients = super()._message_get_suggested_recipients()
            // if self.partner_id:
            //     self._message_add_suggested_recipient(
            //         recipients,
            //         partner=self.partner_id,
            //         reason=_('Sponsor')
            //     )
            // return recipients
            */
            return default;
        }

        protected async Task<EventSponsor> OnchangeExhibitorTypeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py) ---
            // def _onchange_exhibitor_type(self):
            // """ Keep an explicit onchange to allow configuration of room names, even
            // if this field is normally a related on chat_room_id.name. It is not a real
            // computed field, an onchange used in form view is sufficient. """
            // for sponsor in self:
            //     if sponsor.exhibitor_type == 'online' and not sponsor.room_name:
            //         if sponsor.name:
            //             room_name = "odoo-exhibitor-%s" % sponsor.name
            //         else:
            //             room_name = self.env['chat.room']._default_name(objname='exhibitor')
            //         sponsor.room_name = self._jitsi_sanitize_name(room_name)
            //     if sponsor.exhibitor_type == 'online' and not sponsor.room_max_capacity:
            //         sponsor.room_max_capacity = '8'
            */
            return default;
        }

        public async Task<EventSponsor> OpenWebsiteUrlAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_sponsor.py) ---
            // def open_website_url(self):
            // """ Overridden to use a relative URL instead of an absolute when website_id is False. """
            // if self.event_id.website_id:
            //     return super().open_website_url()
            // return self.env['website'].get_client_action(f'/event/{self.env["ir.http"]._slug(self.event_id)}/exhibitor/{self.env["ir.http"]._slug(self)}')
            */
            var entity = await Repository.GetAsync(id); return entity;
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