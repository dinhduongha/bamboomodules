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
    [Module("Event", Depends = new[] { "barcodes", "base_setup", "mail", "phone_validation", "portal", "utm" })]
    public class EventEventAppService : GenericApplicationService<EventEvent>, IEventEventAppService
    {
        private readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        private readonly IMailThreadAppService _mailThreadAppService;
        private readonly IPosLoadMixinAppService _posLoadMixinAppService;
        private readonly IWebsiteCoverPropertiesMixinAppService _websiteCoverPropertiesMixinAppService;
        private readonly IWebsitePublishedMultiMixinAppService _websitePublishedMultiMixinAppService;
        private readonly IWebsiteSearchableMixinAppService _websiteSearchableMixinAppService;
        private readonly IWebsiteSeoMetadataAppService _websiteSeoMetadataAppService;
        public EventEventAppService(IRepository<EventEvent, Guid> repository, IServiceProvider serviceProvider, AuthorizationService authorizationService, DomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IDataFilter dataFilter, IObjectMapper objectMapper, IMemoryCache memoryCache, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService, IPosLoadMixinAppService posLoadMixinAppService, IWebsiteCoverPropertiesMixinAppService websiteCoverPropertiesMixinAppService, IWebsitePublishedMultiMixinAppService websitePublishedMultiMixinAppService, IWebsiteSearchableMixinAppService websiteSearchableMixinAppService, IWebsiteSeoMetadataAppService websiteSeoMetadataAppService) : base(repository, serviceProvider, authorizationService, domainParser, modelTypeRegistry, dataFilter, objectMapper, memoryCache)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
            _posLoadMixinAppService = posLoadMixinAppService;
            _websiteCoverPropertiesMixinAppService = websiteCoverPropertiesMixinAppService;
            _websitePublishedMultiMixinAppService = websitePublishedMultiMixinAppService;
            _websiteSearchableMixinAppService = websiteSearchableMixinAppService;
            _websiteSeoMetadataAppService = websiteSeoMetadataAppService;
        }

        protected async Task<EventEvent> CheckClosingDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _check_closing_date(self):
            // for event in self:
            //     if event.date_end < event.date_begin:
            //         raise ValidationError(_('The closing date cannot be earlier than the beginning date.'))
            */
            return default;
        }

        protected async Task<EventEvent> CheckSeatsAvailabilityInternalAsync(object minimal_availability)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _check_seats_availability(self, minimal_availability=0):
            // sold_out_events = []
            // for event in self:
            //     if event.seats_limited and event.seats_max and event.seats_available < minimal_availability:
            //         sold_out_events.append(_(
            //             '- "%(event_name)s": Missing %(nb_too_many)i seats.',
            //             event_name=event.name,
            //             nb_too_many=minimal_availability - event.seats_available,
            //         ))
            // if sold_out_events:
            //     raise ValidationError(_('There are not enough seats available for:')
            //                           + '\n%s\n' % '\n'.join(sold_out_events))
            */
            return default;
        }

        protected async Task<EventEvent> CheckWebsiteIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _check_website_id(self):
            // for event in self:
            //     if event.website_id and event.website_id.company_id != event.company_id:
            //         raise ValidationError(_("The website must be from the same company as the event."))
            */
            return default;
        }

        protected async Task<EventEvent> ComputeAddressInlineInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_address_inline(self):
            // """Use venue address if available, otherwise its name, finally ''. """
            // for event in self:
            //     if (event.address_id.contact_address or '').strip():
            //         event.address_inline = ', '.join(
            //             frag.strip()
            //             for frag in event.address_id.contact_address.split('\n') if frag.strip()
            //         )
            //     else:
            //         event.address_inline = event.address_id.name or ''
            */
            return default;
        }

        protected async Task<EventEvent> ComputeAddressSearchInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_address_search(self):
            // for event in self:
            //     event.address_search = event.address_id
            */
            return default;
        }

        protected async Task<EventEvent> ComputeBoothMenuInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_booth, FILE: event_event.py) ---
            // def _compute_booth_menu(self):
            // for event in self:
            //     if event.event_type_id and event.event_type_id != event._origin.event_type_id:
            //         event.booth_menu = event.event_type_id.booth_menu
            //     elif event.website_menu and (event.website_menu != event._origin.website_menu or not event.booth_menu):
            //         event.booth_menu = True
            //     elif not event.website_menu:
            //         event.booth_menu = False
            */
            return default;
        }

        protected async Task<EventEvent> ComputeCommunityMenuInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _compute_community_menu(self):
            // """ Set False in base module. Sub modules will add their own logic
            // (meet or track_quiz). """
            // for event in self:
            //     event.community_menu = False
            --- ODOO METHOD SOURCE (MODULE: website_event_meet, FILE: event_event.py) ---
            // def _compute_community_menu(self):
            // """ At type onchange: synchronize. At website_menu update: synchronize. """
            // for event in self:
            //     if event.event_type_id and event.event_type_id != event._origin.event_type_id:
            //         event.community_menu = event.event_type_id.community_menu
            //     elif event.website_menu and (event.website_menu != event._origin.website_menu or not event.community_menu):
            //         event.community_menu = True
            //     elif not event.website_menu:
            //         event.community_menu = False
            --- ODOO METHOD SOURCE (MODULE: website_event_track_quiz, FILE: event_event.py) ---
            // def _compute_community_menu(self):
            // """ At type onchange: synchronize. At website_menu update: synchronize. """
            // for event in self:
            //     if event.event_type_id and event.event_type_id != event._origin.event_type_id:
            //         event.community_menu = event.event_type_id.community_menu
            //     elif event.website_menu and (event.website_menu != event._origin.website_menu or not event.community_menu):
            //         event.community_menu = True
            //     elif not event.website_menu:
            //         event.community_menu = False
            */
            return default;
        }

        protected async Task<EventEvent> ComputeDateBeginTzInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_date_begin_tz(self):
            // for event in self:
            //     if event.date_begin:
            //         event.date_begin_located = format_datetime(
            //             self.env, event.date_begin, tz=event.date_tz, dt_format='medium')
            //     else:
            //         event.date_begin_located = False
            */
            return default;
        }

        protected async Task<EventEvent> ComputeDateEndTzInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_date_end_tz(self):
            // for event in self:
            //     if event.date_end:
            //         event.date_end_located = format_datetime(
            //             self.env, event.date_end, tz=event.date_tz, dt_format='medium')
            //     else:
            //         event.date_end_located = False
            */
            return default;
        }

        protected async Task<EventEvent> ComputeDateTzInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_date_tz(self):
            // for event in self:
            //     if event.event_type_id.default_timezone:
            //         event.date_tz = event.event_type_id.default_timezone
            //     if not event.date_tz:
            //         event.date_tz = self.env.user.tz or 'UTC'
            */
            return default;
        }

        protected async Task<EventEvent> ComputeDisplayNameInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_display_name(self):
            // """Adds ticket seats availability if requested by context."""
            // if not self.env.context.get('name_with_seats_availability'):
            //     return super()._compute_display_name()
            // for event in self:
            //     # event or its tickets are sold out
            //     if event.event_registrations_sold_out:
            //         name = _('%(event_name)s (Sold out)', event_name=event.name)
            //     elif event.seats_limited and event.seats_max:
            //         name = _(
            //             '%(event_name)s (%(count)s seats remaining)',
            //             event_name=event.name,
            //             count=formatLang(self.env, event.seats_available, digits=0),
            //         )
            //     else:
            //         name = event.name
            //     event.display_name = name
            */
            return default;
        }

        protected async Task<EventEvent> ComputeEventBoothCategoryAvailableIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth, FILE: event_event.py) ---
            // def _compute_event_booth_category_available_ids(self):
            // for event in self:
            //     event.event_booth_category_available_ids = event.event_booth_ids.filtered(lambda booth: booth.is_available).mapped('booth_category_id')
            */
            return default;
        }

        protected async Task<EventEvent> ComputeEventBoothCategoryIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth, FILE: event_event.py) ---
            // def _compute_event_booth_category_ids(self):
            // for event in self:
            //     event.event_booth_category_ids = event.event_booth_ids.mapped('booth_category_id')
            */
            return default;
        }

        protected async Task<EventEvent> ComputeEventBoothCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth, FILE: event_event.py) ---
            // def _compute_event_booth_count(self):
            // if self.ids and all(bool(event.id) for event in self):  # no new/onchange mode -> optimized
            //     booths_available_count, booths_total_count = self._get_booth_stat_count()
            //     for event in self:
            //         event.event_booth_count_available = booths_available_count.get(event.id, 0)
            //         event.event_booth_count = booths_total_count.get(event.id, 0)
            // else:
            //     for event in self:
            //         event.event_booth_count = len(event.event_booth_ids)
            //         event.event_booth_count_available = len(event.event_booth_ids.filtered(lambda booth: booth.is_available))
            */
            return default;
        }

        protected async Task<EventEvent> ComputeEventBoothIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth, FILE: event_event.py) ---
            // def _compute_event_booth_ids(self):
            // """ Update event configuration from its event type. Depends are set only
            // on event_type_id itself, not its sub fields. Purpose is to emulate an
            // onchange: if event type is changed, update event configuration. Changing
            // event type content itself should not trigger this method.
            // 
            // When synchronizing booths:
            // 
            //   * lines that are available are removed;
            //   * template lines are added;
            // """
            // for event in self:
            //     if not event.event_type_id and not event.event_booth_ids:
            //         event.event_booth_ids = False
            //         continue
            // 
            //     # booths to keep: those that are not available
            //     booths_to_remove = event.event_booth_ids.filtered(lambda booth: booth.is_available)
            //     command = [Command.unlink(booth.id) for booth in booths_to_remove]
            //     if event.event_type_id.event_type_booth_ids:
            //         command += [
            //             Command.create({
            //                 attribute_name: line[attribute_name] if not isinstance(line[attribute_name], models.BaseModel) else line[attribute_name].id
            //                 for attribute_name in self.env['event.type.booth']._get_event_booth_fields_whitelist()
            //             }) for line in event.event_type_id.event_type_booth_ids
            //         ]
            //     event.event_booth_ids = command
            */
            return default;
        }

        protected async Task<EventEvent> ComputeEventMailIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_event_mail_ids(self):
            // """ Update event configuration from its event type. Depends are set only
            // on event_type_id itself, not its sub fields. Purpose is to emulate an
            // onchange: if event type is changed, update event configuration. Changing
            // event type content itself should not trigger this method.
            // 
            // When synchronizing mails:
            // 
            //   * lines that are not sent and have no registrations linked are remove;
            //   * type lines are added;
            // """
            // for event in self:
            //     if not event.event_type_id and not event.event_mail_ids:
            //         event.event_mail_ids = self._default_event_mail_ids()
            //         continue
            // 
            //     # lines to keep: those with already sent emails or registrations
            //     mails_to_remove = event.event_mail_ids.filtered(
            //         lambda mail: not(mail._origin.mail_done) and not(mail._origin.mail_registration_ids)
            //     )
            //     command = [Command.unlink(mail.id) for mail in mails_to_remove]
            // 
            //     # lines to add: those which do not have the exact copy available in lines to keep
            //     if event.event_type_id.event_type_mail_ids:
            //         mails_to_keep_vals = {frozendict(mail._prepare_event_mail_values()) for mail in event.event_mail_ids - mails_to_remove}
            //         for mail in event.event_type_id.event_type_mail_ids:
            //             mail_values = frozendict(mail._prepare_event_mail_values())
            //             if mail_values not in mails_to_keep_vals:
            //                 command.append(Command.create(mail_values))
            //     if command:
            //         event.event_mail_ids = command
            */
            return default;
        }

        protected async Task<EventEvent> ComputeEventRegisterUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _compute_event_register_url(self):
            // for event in self:
            //     event.event_register_url = werkzeug.urls.url_join(event.get_base_url(), f"{event.website_url}/register")
            */
            return default;
        }

        protected async Task<EventEvent> ComputeEventRegistrationsOpenInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_event_registrations_open(self):
            // """ Compute whether people may take registrations for this event
            // 
            //   * event.date_end -> if event is done, registrations are not open anymore;
            //   * event.start_sale_datetime -> lowest start date of tickets (if any; start_sale_datetime
            //     is False if no ticket are defined, see _compute_start_sale_date);
            //   * any ticket is available for sale (seats available) if any;
            //   * seats are unlimited or seats are available;
            // """
            // for event in self:
            //     event = event._set_tz_context()
            //     current_datetime = fields.Datetime.context_timestamp(event, fields.Datetime.now())
            //     date_end_tz = event.date_end.astimezone(pytz.timezone(event.date_tz or 'UTC')) if event.date_end else False
            //     event.event_registrations_open = event.event_registrations_started and \
            //         (date_end_tz >= current_datetime if date_end_tz else True) and \
            //         (not event.seats_limited or not event.seats_max or event.seats_available) and \
            //         (not event.event_ticket_ids or any(ticket.sale_available for ticket in event.event_ticket_ids))
            */
            return default;
        }

        protected async Task<EventEvent> ComputeEventRegistrationsSoldOutInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_event_registrations_sold_out(self):
            // """Note that max seats limits for events and sum of limits for all its tickets may not be
            // equal to enable flexibility.
            // E.g. max 20 seats for ticket A, 20 seats for ticket B
            //     * With max 20 seats for the event
            //     * Without limit set on the event (=40, but the customer didn't explicitly write 40)
            // """
            // for event in self:
            //     event.event_registrations_sold_out = (
            //         (event.seats_limited and event.seats_max and not event.seats_available)
            //         or (event.event_ticket_ids and all(ticket.is_sold_out for ticket in event.event_ticket_ids))
            //     )
            */
            return default;
        }

        protected async Task<EventEvent> ComputeEventRegistrationsStartedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_event_registrations_started(self):
            // for event in self:
            //     event = event._set_tz_context()
            //     if event.start_sale_datetime:
            //         current_datetime = fields.Datetime.context_timestamp(event, fields.Datetime.now())
            //         start_sale_datetime = fields.Datetime.context_timestamp(event, event.start_sale_datetime)
            //         event.event_registrations_started = (current_datetime >= start_sale_datetime)
            //     else:
            //         event.event_registrations_started = True
            */
            return default;
        }

        protected async Task<EventEvent> ComputeEventTicketIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_event_ticket_ids(self):
            // """ Update event configuration from its event type. Depends are set only
            // on event_type_id itself, not its sub fields. Purpose is to emulate an
            // onchange: if event type is changed, update event configuration. Changing
            // event type content itself should not trigger this method.
            // 
            // When synchronizing tickets:
            // 
            //   * lines that have no registrations linked are remove;
            //   * type lines are added;
            // 
            // Note that updating event_ticket_ids triggers _compute_start_sale_date
            // (start_sale_datetime computation) so ensure result to avoid cache miss.
            // """
            // for event in self:
            //     if not event.event_type_id and not event.event_ticket_ids:
            //         event.event_ticket_ids = False
            //         continue
            // 
            //     # lines to keep: those with existing registrations
            //     tickets_to_remove = event.event_ticket_ids.filtered(lambda ticket: not ticket._origin.registration_ids)
            //     command = [Command.unlink(ticket.id) for ticket in tickets_to_remove]
            //     if event.event_type_id.event_type_ticket_ids:
            //         command += [
            //             Command.create({
            //                 attribute_name: line[attribute_name] if not isinstance(line[attribute_name], models.BaseModel) else line[attribute_name].id
            //                 for attribute_name in self.env['event.type.ticket']._get_event_ticket_fields_whitelist()
            //             }) for line in event.event_type_id.event_type_ticket_ids
            //         ]
            //     event.event_ticket_ids = command
            */
            return default;
        }

        protected async Task<EventEvent> ComputeExhibitorMenuInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_event.py) ---
            // def _compute_exhibitor_menu(self):
            // for event in self:
            //     if event.event_type_id and event.event_type_id != event._origin.event_type_id:
            //         event.exhibitor_menu = event.event_type_id.exhibitor_menu
            //     elif event.website_menu and (event.website_menu != event._origin.website_menu or not event.exhibitor_menu):
            //         event.exhibitor_menu = True
            //     elif not event.website_menu:
            //         event.exhibitor_menu = False
            */
            return default;
        }

        protected async Task<EventEvent> ComputeFieldIsOneDayInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_field_is_one_day(self):
            // for event in self:
            //     # Need to localize because it could begin late and finish early in
            //     # another timezone
            //     event = event._set_tz_context()
            //     begin_tz = fields.Datetime.context_timestamp(event, event.date_begin)
            //     end_tz = fields.Datetime.context_timestamp(event, event.date_end)
            //     event.is_one_day = (begin_tz.date() == end_tz.date())
            */
            return default;
        }

        protected async Task<EventEvent> ComputeHasLeadRequestInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_crm, FILE: event_event.py) ---
            // def _compute_has_lead_request(self):
            // lead_requests_data = self.env['event.lead.request']._read_group(
            //     [('event_id', 'in', self.ids)],
            //     ['event_id'], ['__count'],
            // )
            // mapped_data = {event.id: count for event, count in lead_requests_data}
            // for event in self:
            //     event.has_lead_request = mapped_data.get(event.id, 0) != 0
            */
            return default;
        }

        protected async Task<EventEvent> ComputeIsFinishedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_is_finished(self):
            // for event in self:
            //     if not event.date_end:
            //         event.is_finished = False
            //         continue
            //     event = event._set_tz_context()
            //     current_datetime = fields.Datetime.context_timestamp(event, fields.Datetime.now())
            //     datetime_end = fields.Datetime.context_timestamp(event, event.date_end)
            //     event.is_finished = datetime_end <= current_datetime
            */
            return default;
        }

        protected async Task<EventEvent> ComputeIsOngoingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_is_ongoing(self):
            // now = fields.Datetime.now()
            // for event in self:
            //     event.is_ongoing = event.date_begin <= now < event.date_end
            */
            return default;
        }

        protected async Task<EventEvent> ComputeIsParticipatingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _compute_is_participating(self):
            // participating_events = self._fetch_is_participating_events()
            // participating_events.is_participating = True
            // (self - participating_events).is_participating = False
            */
            return default;
        }

        protected async Task<EventEvent> ComputeIsVisibleOnWebsiteInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _compute_is_visible_on_website(self):
            // if all(event.website_visibility == 'public' for event in self):
            //     self.is_visible_on_website = True
            //     return
            // for event in self:
            //     if event.website_visibility == 'public' or event.is_participating:
            //         event.is_visible_on_website = True
            //     elif not self.env.user._is_public() and event.website_visibility == 'logged_users':
            //         event.is_visible_on_website = True
            //     else:
            //         event.is_visible_on_website = False
            */
            return default;
        }

        protected async Task<EventEvent> ComputeKanbanStateLabelInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_kanban_state_label(self):
            // for event in self:
            //     if event.kanban_state == 'normal':
            //         event.kanban_state_label = event.stage_id.legend_normal
            //     elif event.kanban_state == 'blocked':
            //         event.kanban_state_label = event.stage_id.legend_blocked
            //     else:
            //         event.kanban_state_label = event.stage_id.legend_done
            */
            return default;
        }

        protected async Task<EventEvent> ComputeLeadCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_crm, FILE: event_event.py) ---
            // def _compute_lead_count(self):
            // lead_data = self.env['crm.lead']._read_group(
            //     [('event_id', 'in', self.ids)],
            //     ['event_id'], ['__count'],
            // )
            // mapped_data = {event.id: count for event, count in lead_data}
            // for event in self:
            //     event.lead_count = mapped_data.get(event.id, 0)
            */
            return default;
        }

        protected async Task<EventEvent> ComputeMeetingRoomAllowCreationInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_meet, FILE: event_event.py) ---
            // def _compute_meeting_room_allow_creation(self):
            // for event in self:
            //     if event.event_type_id and event.event_type_id != event._origin.event_type_id:
            //         event.meeting_room_allow_creation = event.event_type_id.meeting_room_allow_creation
            //     elif event.community_menu and event.community_menu != event._origin.community_menu:
            //         event.meeting_room_allow_creation = True
            //     elif not event.community_menu or not event.meeting_room_allow_creation:
            //         event.meeting_room_allow_creation = False
            */
            return default;
        }

        protected async Task<EventEvent> ComputeMeetingRoomCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_meet, FILE: event_event.py) ---
            // def _compute_meeting_room_count(self):
            // meeting_room_count = self.env["event.meeting.room"].sudo()._read_group(
            //     domain=[("event_id", "in", self.ids)],
            //     groupby=['event_id'],
            //     aggregates=['__count'],
            // )
            // 
            // meeting_room_count = {
            //     event.id: count
            //     for event, count in meeting_room_count
            // }
            // 
            // for event in self:
            //     event.meeting_room_count = meeting_room_count.get(event.id, 0)
            */
            return default;
        }

        protected async Task<EventEvent> ComputeNoteInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_note(self):
            // for event in self:
            //     if event.event_type_id and not is_html_empty(event.event_type_id.note):
            //         event.note = event.event_type_id.note
            */
            return default;
        }

        protected async Task<EventEvent> ComputeQuestionIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_question_ids(self):
            // """ Update event questions from its event type. Depends are set only on
            // event_type_id itself to emulate an onchange. Changing event type content
            // itself should not trigger this method.
            // 
            // When synchronizing questions:
            // 
            //   * lines with no registered answers are removed;
            //   * type lines are added;
            // """
            // if self._origin.question_ids:
            //     # lines to keep: those with already given answers
            //     questions_tokeep_ids = self.env['event.registration.answer'].search(
            //         [('question_id', 'in', self._origin.question_ids.ids)]
            //     ).question_id.ids
            // else:
            //     questions_tokeep_ids = []
            // for event in self:
            //     if not event.event_type_id and not event.question_ids:
            //         event.question_ids = self._default_question_ids()
            //         continue
            // 
            //     if questions_tokeep_ids:
            //         questions_toremove = event._origin.question_ids.filtered(
            //             lambda question: question.id not in questions_tokeep_ids)
            //         command = [(3, question.id) for question in questions_toremove]
            //     else:
            //         command = [(5, 0)]
            //     event.question_ids = command
            // 
            //     # copy questions so changes in the event don't affect the event type
            //     event.question_ids += event.event_type_id.question_ids.copy({
            //         'event_type_id': False,
            //     })
            */
            return default;
        }

        protected async Task<EventEvent> ComputeSalePriceSubtotalInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_sale, FILE: event_event.py) ---
            // def _compute_sale_price_subtotal(self):
            // """ Takes all the sale.order.lines related to this event and converts amounts
            // from the currency of the sale order to the currency of the event company.
            // 
            // To avoid extra overhead, we use conversion rates as of 'today'.
            // Meaning we have a number that can change over time, but using the conversion rates
            // at the time of the related sale.order would mean thousands of extra requests as we would
            // have to do one conversion per sale.order (and a sale.order is created every time
            // we sell a single event ticket). """
            // date_now = fields.Datetime.now()
            // event_subtotals = self.env['sale.order.line']._read_group(
            //     [('event_id', 'in', self.ids), ('price_subtotal', '!=', 0), ('state', '!=', 'cancel')],
            //     ['event_id', 'currency_id'],
            //     ['price_subtotal:sum'],
            // )
            // event_subtotals_mapping = dict.fromkeys(self._origin, 0)
            // for event, currency, sum_price_subtotal in event_subtotals:
            //     event_subtotals_mapping[event] += event.currency_id._convert(
            //         sum_price_subtotal,
            //         currency,
            //         event.company_id or self.env.company,
            //         date_now,
            //     )
            // 
            // for event in self:
            //     event.sale_price_subtotal = event_subtotals_mapping.get(event._origin, 0)
            */
            return default;
        }

        protected async Task<EventEvent> ComputeSeatsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_seats(self):
            // """ Determine available, reserved, used and taken seats. """
            // # initialize fields to 0
            // for event in self:
            //     event.seats_reserved = event.seats_used = event.seats_available = 0
            // # aggregate registrations by event and by state
            // state_field = {
            //     'open': 'seats_reserved',
            //     'done': 'seats_used',
            // }
            // base_vals = dict((fname, 0) for fname in state_field.values())
            // results = dict((event_id, dict(base_vals)) for event_id in self.ids)
            // if self.ids:
            //     query = """ SELECT event_id, state, count(event_id)
            //                 FROM event_registration
            //                 WHERE event_id IN %s AND state IN ('open', 'done') AND active = true
            //                 GROUP BY event_id, state
            //             """
            //     self.env['event.registration'].flush_model(['event_id', 'state', 'active'])
            //     self._cr.execute(query, (tuple(self.ids),))
            //     res = self._cr.fetchall()
            //     for event_id, state, num in res:
            //         results[event_id][state_field[state]] = num
            // 
            // # compute seats_available and expected
            // for event in self:
            //     event.update(results.get(event._origin.id or event.id, base_vals))
            //     if event.seats_max > 0:
            //         event.seats_available = event.seats_max - (event.seats_reserved + event.seats_used)
            // 
            //     event.seats_taken = event.seats_reserved + event.seats_used
            */
            return default;
        }

        protected async Task<EventEvent> ComputeSeatsLimitedInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_seats_limited(self):
            // """ Update event configuration from its event type. Depends are set only
            // on event_type_id itself, not its sub fields. Purpose is to emulate an
            // onchange: if event type is changed, update event configuration. Changing
            // event type content itself should not trigger this method. """
            // for event in self:
            //     if event.event_type_id.has_seats_limitation != event.seats_limited:
            //         event.seats_limited = event.event_type_id.has_seats_limitation
            //     if not event.seats_limited:
            //         event.seats_limited = False
            */
            return default;
        }

        protected async Task<EventEvent> ComputeSeatsMaxInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_seats_max(self):
            // """ Update event configuration from its event type. Depends are set only
            // on event_type_id itself, not its sub fields. Purpose is to emulate an
            // onchange: if event type is changed, update event configuration. Changing
            // event type content itself should not trigger this method. """
            // for event in self:
            //     if not event.event_type_id:
            //         event.seats_max = event.seats_max or 0
            //     else:
            //         event.seats_max = event.event_type_id.seats_max or 0
            */
            return default;
        }

        protected async Task<EventEvent> ComputeSponsorCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_event.py) ---
            // def _compute_sponsor_count(self):
            // data = self.env['event.sponsor']._read_group([('event_id', 'in', self.ids)], ['event_id'], ['__count'])
            // result = {event.id: count for event, count in data}
            // for event in self:
            //     event.sponsor_count = result.get(event.id, 0)
            */
            return default;
        }

        protected async Task<EventEvent> ComputeStartSaleDateInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_start_sale_date(self):
            // """ Compute the start sale date of an event. Currently lowest starting sale
            // date of tickets if they are used, of False. """
            // for event in self:
            //     start_dates = [ticket.start_sale_datetime for ticket in event.event_ticket_ids if not ticket.is_expired]
            //     event.start_sale_datetime = min(start_dates) if start_dates and all(start_dates) else False
            */
            return default;
        }

        protected async Task<EventEvent> ComputeTagIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_tag_ids(self):
            // """ Update event configuration from its event type. Depends are set only
            // on event_type_id itself, not its sub fields. Purpose is to emulate an
            // onchange: if event type is changed, update event configuration. Changing
            // event type content itself should not trigger this method. """
            // for event in self:
            //     if not event.tag_ids and event.event_type_id.tag_ids:
            //         event.tag_ids = event.event_type_id.tag_ids
            */
            return default;
        }

        protected async Task<EventEvent> ComputeTicketInstructionsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_ticket_instructions(self):
            // for event in self:
            //     if is_html_empty(event.ticket_instructions) and not \
            //        is_html_empty(event.event_type_id.ticket_instructions):
            //         event.ticket_instructions = event.event_type_id.ticket_instructions
            */
            return default;
        }

        protected async Task<EventEvent> ComputeTimeDataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _compute_time_data(self):
            // """ Compute start and remaining time. Do everything in UTC as we compute only
            // time deltas here. """
            // now_utc = utc.localize(fields.Datetime.now().replace(microsecond=0))
            // for event in self:
            //     date_begin_utc = utc.localize(event.date_begin, is_dst=False)
            //     date_end_utc = utc.localize(event.date_end, is_dst=False)
            //     event.is_ongoing = date_begin_utc <= now_utc <= date_end_utc
            //     event.is_done = now_utc > date_end_utc
            //     event.start_today = date_begin_utc.date() == now_utc.date()
            //     if date_begin_utc >= now_utc:
            //         td = date_begin_utc - now_utc
            //         event.start_remaining = int(td.total_seconds() / 60)
            //     else:
            //         event.start_remaining = 0
            */
            return default;
        }

        protected async Task<EventEvent> ComputeTrackCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py) ---
            // def _compute_track_count(self):
            // data = self.env['event.track']._read_group([('stage_id.is_cancel', '!=', True)], ['event_id'], ['__count'])
            // result = {event.id: count for event, count in data}
            // for event in self:
            //     event.track_count = result.get(event.id, 0)
            */
            return default;
        }

        protected async Task<EventEvent> ComputeTracksTagIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py) ---
            // def _compute_tracks_tag_ids(self):
            // for event in self:
            //     event.tracks_tag_ids = event.track_ids.mapped('tag_ids').filtered(lambda tag: tag.color != 0).ids
            */
            return default;
        }

        protected async Task<EventEvent> ComputeUseBarcodeInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _compute_use_barcode(self):
            // use_barcode = self.env['ir.config_parameter'].sudo().get_param('event.use_event_barcode') == 'True'
            // for record in self:
            //     record.use_barcode = use_barcode
            */
            return default;
        }

        protected async Task<EventEvent> ComputeWebsiteMenuDataInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _compute_website_menu_data(self):
            // """ Synchronize with website_menu at change and let people update them
            // at will afterwards. """
            // for event in self:
            //     event.introduction_menu = event.website_menu
            //     event.location_menu = event.website_menu
            //     event.register_menu = event.website_menu
            */
            return default;
        }

        protected async Task<EventEvent> ComputeWebsiteMenuInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _compute_website_menu(self):
            // """ Also ensure a value for website_menu as it is a trigger notably for
            // track related menus. """
            // for event in self:
            //     if event.event_type_id and event.event_type_id != event._origin.event_type_id:
            //         event.website_menu = event.event_type_id.website_menu
            //     elif not event.website_menu:
            //         event.website_menu = False
            */
            return default;
        }

        protected async Task<EventEvent> ComputeWebsiteTrackInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py) ---
            // def _compute_website_track(self):
            // """ Propagate event_type configuration (only at change); otherwise propagate
            // website_menu updated value. Also force True is track_proposal changes. """
            // for event in self:
            //     if event.event_type_id and event.event_type_id != event._origin.event_type_id:
            //         event.website_track = event.event_type_id.website_track
            //     elif event.website_menu and (event.website_menu != event._origin.website_menu or not event.website_track):
            //         event.website_track = True
            //     elif not event.website_menu:
            //         event.website_track = False
            */
            return default;
        }

        protected async Task<EventEvent> ComputeWebsiteTrackProposalInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py) ---
            // def _compute_website_track_proposal(self):
            // """ Propagate event_type configuration (only at change); otherwise propagate
            // website_track updated value (both together True or False at update). """
            // for event in self:
            //     if event.event_type_id and event.event_type_id != event._origin.event_type_id:
            //         event.website_track_proposal = event.event_type_id.website_track_proposal
            //     elif event.website_track != event._origin.website_track or not event.website_track or not event.website_track_proposal:
            //         event.website_track_proposal = event.website_track
            */
            return default;
        }

        protected async Task<EventEvent> ComputeWebsiteUrlInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _compute_website_url(self):
            // super(Event, self)._compute_website_url()
            // for event in self:
            //     if event.id:  # avoid to perform a slug on a not yet saved record in case of an onchange.
            //         event.website_url = '/event/%s' % self.env['ir.http']._slug(event)
            */
            return default;
        }

        public async Task<EventEvent> CopyDataAsync(Guid id, object @default)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def copy_data(self, default=None):
            // vals_list = super().copy_data(default=default)
            // return [dict(vals, name=self.env._("%s (copy)", event.name)) for event, vals in zip(self, vals_list)]
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<EventEvent> CreateAsync(EventEvent entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def create(self, vals_list):
            // events = super(EventEvent, self).create(vals_list)
            // for res in events:
            //     if res.organizer_id:
            //         res.message_subscribe([res.organizer_id.id])
            // self.env.flush_all()
            // return events
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def create(self, vals_list):
            // events = super().create(vals_list)
            // events._update_website_menus()
            // return events
            */
            return await base.CreateAsync(entity, fields);
        }

        protected async Task<EventEvent> CreateMenuInternalAsync(object sequence, object name, object url, Guid xml_id, object menu_type)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _create_menu(self, sequence, name, url, xml_id, menu_type):
            // """ Create a new menu for the current event.
            // 
            // If url: create a website menu. Menu leads directly to the URL that
            // should be a valid route.
            // 
            // If xml_id: create a new page using the qweb template given by its
            // xml_id. Take its url back thanks to new_page of website, then link
            // it to a menu. Template is duplicated and linked to a new url, meaning
            // each menu will have its own copy of the template. This is currently
            // limited to two menus: introduction and location.
            // 
            // :param menu_type: type of menu. Mainly used for inheritance purpose
            //   allowing more fine-grain tuning of menus.
            // """
            // self.browse().check_access('write')
            // view_id = False
            // if not url:
            //     # add_menu=False, ispage=False -> simply create a new ir.ui.view with name
            //     # and template
            //     page_result = self.env['website'].sudo().new_page(
            //         name=f'{name} {self.name}', template=xml_id,
            //         add_menu=False, ispage=False)
            //     view_id = page_result['view_id']
            //     view = self.env["ir.ui.view"].browse(view_id)
            //     url = f"/event/{self.env['ir.http']._slug(self)}/page/{view.key.split('.')[-1]}"  # url contains starting "/"
            // 
            // website_menu = self.env['website.menu'].sudo().create({
            //     'name': name,
            //     'url': url,
            //     'parent_id': self.menu_id.id,
            //     'sequence': sequence,
            //     'website_id': self.website_id.id,
            // })
            // self.env['website.event.menu'].create({
            //     'menu_id': website_menu.id,
            //     'event_id': self.id,
            //     'menu_type': menu_type,
            //     'view_id': view_id,
            // })
            // return website_menu
            */
            return default;
        }

        protected async Task<EventEvent> DefaultCoverPropertiesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _default_cover_properties(self):
            // res = super()._default_cover_properties()
            // res.update({
            //     'background-image': "url('/website_event/static/src/img/event_cover_4.jpg')",
            //     'opacity': '0.4',
            //     'resize_class': 'cover_auto'
            // })
            // return res
            */
            return default;
        }

        protected async Task<EventEvent> DefaultDescriptionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _default_description(self):
            // # avoid template branding with rendering_bundle=True
            // return self.env['ir.ui.view'].with_context(rendering_bundle=True) \
            //     ._render_template('event.event_default_descripton')
            */
            return default;
        }

        protected async Task<EventEvent> DefaultEventMailIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _default_event_mail_ids(self):
            // return self.env['event.type']._default_event_mail_type_ids()
            */
            return default;
        }

        protected async Task<EventEvent> DefaultQuestionIdsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _default_question_ids(self):
            // return self.env['event.type']._default_question_ids()
            */
            return default;
        }

        protected async Task<EventEvent> DefaultWebsiteMetaInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _default_website_meta(self):
            // res = super(Event, self)._default_website_meta()
            // event_cover_properties = json.loads(self.cover_properties)
            // # background-image might contain single quotes eg `url('/my/url')`
            // res['default_opengraph']['og:image'] = res['default_twitter']['twitter:image'] = event_cover_properties.get('background-image', 'none')[4:-1].strip("'")
            // res['default_opengraph']['og:title'] = res['default_twitter']['twitter:title'] = self.name
            // res['default_opengraph']['og:description'] = res['default_twitter']['twitter:description'] = self.subtitle
            // res['default_twitter']['twitter:card'] = 'summary'
            // res['default_meta_description'] = self.subtitle
            // return res
            */
            return default;
        }

        protected async Task<EventEvent> FetchIsParticipatingEventsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _fetch_is_participating_events(self):
            // """Heuristic
            // 
            //   * public, no visitor: not participating as we have no information;
            //   * check only confirmed and attended registrations, a draft registration
            //     does not make the attendee participating;
            //   * public and visitor: check visitor is linked to a registration. As
            //     visitors are merged on the top parent, current visitor check is
            //     sufficient even for successive visits;
            //   * logged, no visitor: check partner is linked to a registration. Do
            //     not check the email as it is not really secure;
            //   * logged as visitor: check partner or visitor are linked to a
            //     registration;
            // """
            // current_visitor = self.env['website.visitor']._get_visitor_from_request()
            // if self.env.user._is_public() and not current_visitor:
            //     return self.env['event.event']
            // 
            // base_domain = [('state', 'in', ['open', 'done'])]
            // if self:
            //     base_domain = expression.AND([[('event_id', 'in', self.ids)], base_domain])
            // 
            // visitor_domain = []
            // partner_id = self.env.user.partner_id
            // if current_visitor:
            //     visitor_domain = [('visitor_id', '=', current_visitor.id)]
            //     partner_id = current_visitor.partner_id
            // if partner_id:
            //     visitor_domain = expression.OR([visitor_domain, [('partner_id', '=', partner_id.id)]])
            // 
            // registrations_events = self.env['event.registration'].sudo()._read_group(
            //     expression.AND([visitor_domain, base_domain]),
            //     ['event_id'], ['__count'])
            // return self.env['event.event'].browse([event.id for event, _reg_count in registrations_events])
            */
            return default;
        }

        protected async Task<EventEvent> GcMarkEventsDoneInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _gc_mark_events_done(self):
            // """ move every ended events in the next 'ended stage' """
            // ended_events = self.env['event.event'].search([
            //     ('date_end', '<', fields.Datetime.now()),
            //     ('stage_id.pipe_end', '=', False),
            // ])
            // if ended_events:
            //     ended_events.action_set_done()
            */
            return default;
        }

        public async Task<EventEvent> GenerateLeadsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_crm, FILE: event_event.py) ---
            // def action_generate_leads(self):
            // """ Re-generate leads based on event.lead.rules.
            // The method is ran synchronously if there is a low amount of registrations, otherwise it
            // goes through a CRON job that runs in batches. """
            // 
            // if not self.env.user.has_group('event.group_event_manager'):
            //     raise UserError(_("Only Event Managers are allowed to re-generate all leads."))
            // 
            // self.ensure_one()
            // registrations_count = self.env['event.registration'].search_count([
            //     ('event_id', '=', self.id),
            //     ('state', 'not in', ['draft', 'cancel']),
            // ])
            // 
            // if registrations_count <= self.env['event.lead.request']._REGISTRATIONS_BATCH_SIZE:
            //     leads = self.env['event.registration'].search([
            //         ('event_id', '=', self.id),
            //         ('state', 'not in', ['draft', 'cancel']),
            //     ])._apply_lead_generation_rules()
            //     if leads:
            //         notification = _("Yee-ha, %(leads_count)s Leads have been created!", leads_count=len(leads))
            //     else:
            //         notification = _("Aww! No Leads created, check your Lead Generation Rules and try again.")
            // else:
            //     self.env['event.lead.request'].sudo().create({'event_id': self.id})
            //     self.env.ref('event_crm.ir_cron_generate_leads')._trigger()
            //     notification = _("Got it! We've noted your request. Your leads will be created soon!")
            // 
            // return {
            //     'type': 'ir.actions.client',
            //     'tag': 'display_notification',
            //     'params': {
            //         'type': 'info',
            //         'sticky': False,
            //         'message': notification,
            //         'next': {'type': 'ir.actions.act_window_close'},  # force a form reload
            //     }
            // }
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<EventEvent> GetBackendMenuIdAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def get_backend_menu_id(self):
            // return self.env.ref('event.event_main_menu').id
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<EventEvent> GetBoothStatCountInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_booth, FILE: event_event.py) ---
            // def _get_booth_stat_count(self):
            // elements = self.env['event.booth'].sudo()._read_group(
            //     [('event_id', 'in', self.ids)],
            //     ['event_id', 'state'], ['__count']
            // )
            // elements_total_count = defaultdict(int)
            // elements_available_count = dict()
            // for event, state, count in elements:
            //     if state == 'available':
            //         elements_available_count[event.id] = count
            //     elements_total_count[event.id] += count
            // return elements_available_count, elements_total_count
            */
            return default;
        }

        protected async Task<EventEvent> GetDateRangeStrInternalAsync(object lang_code)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _get_date_range_str(self, lang_code=False):
            // self.ensure_one()
            // today_tz = pytz.utc.localize(fields.Datetime.now()).astimezone(pytz.timezone(self.date_tz))
            // event_date_tz = pytz.utc.localize(self.date_begin).astimezone(pytz.timezone(self.date_tz))
            // diff = (event_date_tz.date() - today_tz.date())
            // if diff.days <= 0:
            //     return _('today')
            // if diff.days == 1:
            //     return _('tomorrow')
            // if (diff.days < 7):
            //     return _('in %d days', diff.days)
            // if (diff.days < 14):
            //     return _('next week')
            // if event_date_tz.month == (today_tz + relativedelta(months=+1)).month:
            //     return _('next month')
            // return _('on %(date)s', date=format_date(self.env, self.date_begin, lang_code=lang_code, date_format='medium'))
            */
            return default;
        }

        protected async Task<EventEvent> GetDefaultStageIdInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _get_default_stage_id(self):
            // return self.env['event.stage'].search([], limit=1)
            */
            return default;
        }

        protected async Task<EventEvent> GetEventPrintDetailsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _get_event_print_details(self):
            // self.ensure_one()
            // return {
            //     'name': self.name,
            //     'badge_image': self.badge_image,
            //     'timeframe': self._get_event_timeframe_string(),
            //     'address': self.address_id.name if self.address_id else None,
            //     'logo': self.company_id.logo,
            //     'sponsor_text': self._get_printing_sponsor_text()
            // }
            */
            return default;
        }

        protected async Task<EventEvent> GetEventResourceUrlsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _get_event_resource_urls(self):
            // url_date_start = self.date_begin.astimezone(timezone(self.date_tz)).strftime('%Y%m%dT%H%M%S')
            // url_date_stop = self.date_end.astimezone(timezone(self.date_tz)).strftime('%Y%m%dT%H%M%S')
            // params = {
            //     'action': 'TEMPLATE',
            //     'text': self.name,
            //     'dates': f'{url_date_start}/{url_date_stop}',
            //     'ctz': self.date_tz,
            //     'details': self._get_external_description(),
            // }
            // if self.address_id:
            //     params.update(location=self.address_inline)
            // encoded_params = werkzeug.urls.url_encode(params)
            // google_url = GOOGLE_CALENDAR_URL + encoded_params
            // iCal_url = f'/event/{self.id:d}/ics?{encoded_params}'
            // return {'google_url': google_url, 'iCal_url': iCal_url}
            */
            return default;
        }

        protected async Task<EventEvent> GetEventTimeframeStringInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _get_event_timeframe_string(self):
            // self.ensure_one()
            // start_datetime = format_datetime(self.env, self.date_begin, self.date_tz, "short")
            // if self.is_one_day:
            //     end_datetime = format_time(self.env, self.date_end, self.date_tz, "short")
            // else:
            //     end_datetime = format_datetime(self.env, self.date_end, self.date_tz, "short")
            // return _("%(start_date)s to %(end_date)s", start_date=start_datetime, end_date=end_datetime)
            */
            return default;
        }

        protected async Task<EventEvent> GetExternalDescriptionInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _get_external_description(self):
            // """
            // Description of the event shortened to maximum 1900 characters to
            // leave some space for addition by sub-modules, such as the even link.
            // Meant to be used for external content (ics/icalc/Gcal).
            // 
            // Reference Docs for URL limit -: https://stackoverflow.com/questions/417142/what-is-the-maximum-length-of-a-url-in-different-browsers
            // """
            // self.ensure_one()
            // description = html_to_inner_content(self.description)
            // return textwrap.shorten(description, 1900)
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _get_external_description(self):
            // """ Adding the URL of the event into the description """
            // self.ensure_one()
            // event_url = f'<a href="{self.event_register_url}">{self.name}</a>'
            // description = event_url + '\n' + super()._get_external_description()
            // return description
            */
            return default;
        }

        protected async Task<EventEvent> GetIcsFileInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _get_ics_file(self):
            // """ Returns iCalendar file for the event invitation.
            //     :returns a dict of .ics file content for each event
            // """
            // result = {}
            // if not vobject:
            //     return result
            // 
            // for event in self:
            //     cal = vobject.iCalendar()
            //     cal_event = cal.add('vevent')
            // 
            //     cal_event.add('created').value = fields.Datetime.now().replace(tzinfo=pytz.timezone('UTC'))
            //     cal_event.add('dtstart').value = event.date_begin.astimezone(pytz.timezone(event.date_tz))
            //     cal_event.add('dtend').value = event.date_end.astimezone(pytz.timezone(event.date_tz))
            //     cal_event.add('summary').value = event.name
            //     cal_event.add('description').value = event._get_external_description()
            //     if event.address_id:
            //         cal_event.add('location').value = event.address_inline
            // 
            //     result[event.id] = cal.serialize().encode('utf-8')
            // return result
            */
            return default;
        }

        public async Task<EventEvent> GetKioskUrlAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def get_kiosk_url(self):
            // return self.get_base_url() + "/odoo/registration-desk"
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<EventEvent> GetMailMessageAccessInternalAsync(List<Guid> res_ids, object operation, object model_name)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _get_mail_message_access(self, res_ids, operation, model_name=None):
            // if (
            //     operation == 'create'
            //     and self.env.user.has_group('event.group_event_registration_desk')
            //     and (not model_name or model_name == 'event.event')
            // ):
            //     # allow the registration desk users to post messages on Event
            //     # can not be done with "_mail_post_access" otherwise public user will be
            //     # able to post on published Event (see website_event)
            //     return 'read'
            // return super(EventEvent, self)._get_mail_message_access(res_ids, operation, model_name)
            */
            return default;
        }

        protected async Task<EventEvent> GetMenuTypeFieldMatchingInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _get_menu_type_field_matching(self):
            // return {
            //     'community': 'community_menu',
            //     'introduction': 'introduction_menu',
            //     'location': 'location_menu',
            //     'register': 'register_menu',
            // }
            --- ODOO METHOD SOURCE (MODULE: website_event_booth, FILE: event_event.py) ---
            // def _get_menu_type_field_matching(self):
            // res = super(Event, self)._get_menu_type_field_matching()
            // res['booth'] = 'booth_menu'
            // return res
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_event.py) ---
            // def _get_menu_type_field_matching(self):
            // res = super(EventEvent, self)._get_menu_type_field_matching()
            // res['exhibitor'] = 'exhibitor_menu'
            // return res
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py) ---
            // def _get_menu_type_field_matching(self):
            // res = super(Event, self)._get_menu_type_field_matching()
            // res['track_proposal'] = 'website_track_proposal'
            // return res
            */
            return default;
        }

        protected async Task<EventEvent> GetMenuUpdateFieldsInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _get_menu_update_fields(self):
            // """" Return a list of fields triggering a split of menu to activate /
            // menu to de-activate. Due to saas-13.3 improvement of menu management
            // this is done using side-methods to ease inheritance.
            // 
            // :return list: list of fields, each of which triggering a menu update
            //   like website_menu, website_track, ... """
            // return ['community_menu', 'introduction_menu', 'location_menu', 'register_menu']
            --- ODOO METHOD SOURCE (MODULE: website_event_booth, FILE: event_event.py) ---
            // def _get_menu_update_fields(self):
            // return super(Event, self)._get_menu_update_fields() + ['booth_menu']
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_event.py) ---
            // def _get_menu_update_fields(self):
            // return super(EventEvent, self)._get_menu_update_fields() + ['exhibitor_menu']
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py) ---
            // def _get_menu_update_fields(self):
            // return super(Event, self)._get_menu_update_fields() + ['website_track', 'website_track_proposal']
            */
            return default;
        }

        protected async Task<EventEvent> GetMenusUpdateByFieldInternalAsync(object menus_state_by_field, object force_update)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _get_menus_update_by_field(self, menus_state_by_field, force_update=None):
            // """ For each field linked to a menu, get the set of events requiring
            // this menu to be activated or de-activated based on previous recorded
            // value.
            // 
            // :param menus_state_by_field: see ``_split_menus_state_by_field``;
            // :param force_update: list of field to which we force update of menus. This
            //   is used notably when a direct write to a stored editable field messes with
            //   its pre-computed value, notably in a transient mode (aka demo for example);
            // 
            // :return dict: key = name of field triggering a website menu update, get {
            //   'activated': subset of self having its menu toggled to True
            //   'deactivated': subset of self having its menu toggled to False
            // } """
            // menus_update_by_field = dict()
            // for fname in self._get_menu_update_fields():
            //     if fname in force_update:
            //         menus_update_by_field[fname] = self
            //     else:
            //         menus_update_by_field[fname] = self.env['event.event']
            //         menus_update_by_field[fname] |= menus_state_by_field[fname]['activated'].filtered(lambda event: not event[fname])
            //         menus_update_by_field[fname] |= menus_state_by_field[fname]['deactivated'].filtered(lambda event: event[fname])
            // return menus_update_by_field
            */
            return default;
        }

        protected async Task<EventEvent> GetPrintingSponsorTextInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _get_printing_sponsor_text(self):
            // sponsor_text = self.env['ir.config_parameter'].sudo().get_param('event.badge_printing_sponsor_text')
            // return sponsor_text or "Powered by Odoo"
            */
            return default;
        }

        protected async Task<EventEvent> GetTicketsAccessHashInternalAsync(List<Guid> registration_ids)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _get_tickets_access_hash(self, registration_ids):
            // """ Returns the ground truth hash for accessing the tickets in route /event/<int:event_id>/my_tickets.
            // The dl links are always made event-dependant, hence the method linked to the record in self.
            // """
            // self.ensure_one()
            // return tools.hmac(self.env(su=True), 'event-registration-ticket-report-access', (self.id, sorted(registration_ids)))
            */
            return default;
        }

        protected async Task<EventEvent> GetWebsiteMenuEntriesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _get_website_menu_entries(self):
            // """ Method returning menu entries to display on the website view of the
            // event, possibly depending on some options in inheriting modules.
            // 
            // Each menu entry is a tuple containing :
            //   * name: menu item name
            //   * url: if set, url to a route (do not use xml_id in that case);
            //   * xml_id: template linked to the page (do not use url in that case);
            //   * sequence: specific sequence of menu entry to be set on the menu;
            //   * menu_type: type of menu entry (used in inheriting modules to ease
            //     menu management; not used in this module in 13.3 due to technical
            //     limitations);
            // """
            // self.ensure_one()
            // return [
            //     (_('Introduction'), False, 'website_event.template_intro', 1, 'introduction'),
            //     (_('Location'), False, 'website_event.template_location', 50, 'location'),
            //     (_('Info'), '/event/%s/register' % self.env['ir.http']._slug(self), False, 100, 'register'),
            //     (_('Community'), '/event/%s/community' % self.env['ir.http']._slug(self), False, 80, 'community'),
            // ]
            --- ODOO METHOD SOURCE (MODULE: website_event_booth, FILE: event_event.py) ---
            // def _get_website_menu_entries(self):
            // self.ensure_one()
            // return super(Event, self)._get_website_menu_entries() + [
            //     (_('Get A Booth'), '/event/%s/booth' % self.env['ir.http']._slug(self), False, 90, 'booth')
            // ]
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_event.py) ---
            // def _get_website_menu_entries(self):
            // self.ensure_one()
            // return super(EventEvent, self)._get_website_menu_entries() + [
            //     (_('Exhibitors'), '/event/%s/exhibitors' % self.env['ir.http']._slug(self), False, 60, 'exhibitor')
            // ]
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py) ---
            // def _get_website_menu_entries(self):
            // self.ensure_one()
            // return super(Event, self)._get_website_menu_entries() + [
            //     (_('Talks'), '/event/%s/track' % self.env['ir.http']._slug(self), False, 10, 'track'),
            //     (_('Agenda'), '/event/%s/agenda' % self.env['ir.http']._slug(self), False, 70, 'track'),
            //     (_('Talk Proposals'), '/event/%s/track_proposal' % self.env['ir.http']._slug(self), False, 15, 'track_proposal')
            // ]
            */
            return default;
        }

        public async Task<EventEvent> GoogleMapLinkAsync(Guid id, object zoom)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def google_map_link(self, zoom=8):
            // """ Temporary method for stable """
            // return self._google_map_link(zoom=zoom)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<EventEvent> GoogleMapLinkInternalAsync(object zoom)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _google_map_link(self, zoom=8):
            // self.ensure_one()
            // if self.address_id:
            //     return self.sudo().address_id.google_map_link(zoom=zoom)
            // return None
            */
            return default;
        }

        public async Task<EventEvent> InviteContactsAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_event, FILE: event_event.py) ---
            // def action_invite_contacts(self):
            // return {
            //     'name': 'Mass Mail Invitation',
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'mailing.mailing',
            //     'view_mode': 'form',
            //     'target': 'current',
            //     'context': {
            //         'default_mailing_model_id': self.env.ref('base.model_res_partner').id,
            //         'default_subject': _("Event: %s", self.name),
            //     },
            // }
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_event_sms, FILE: event.py) ---
            // def action_invite_contacts(self):
            // # Minimal override: set form view being the one mixing sms and mail (not prioritized one)
            // action = super(Event, self).action_invite_contacts()
            // action['view_id'] = self.env.ref('mass_mailing_sms.mailing_mailing_view_form_mixed').id
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<EventEvent> LangGetInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _lang_get(self):
            // return self.env['res.lang'].get_installed()
            */
            return default;
        }

        protected async Task<EventEvent> LoadPosDataDomainInternalAsync(object data)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_event, FILE: event_event.py) ---
            // def _load_pos_data_domain(self, data):
            // return [('event_ticket_ids', 'in', [ticket['id'] for ticket in data['event.event.ticket']['data']])]
            */
            return default;
        }

        protected async Task<EventEvent> LoadPosDataFieldsInternalAsync(Guid config_id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: pos_event, FILE: event_event.py) ---
            // def _load_pos_data_fields(self, config_id):
            // return ['id', 'name', 'seats_available', 'event_ticket_ids', 'registration_ids', 'seats_limited', 'write_date',
            //         'question_ids', 'general_question_ids', 'specific_question_ids', 'badge_format']
            */
            return default;
        }

        public async Task<EventEvent> MailAttendeesAsync(Guid id, Guid template_id, object force_send, object filter_func)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def mail_attendees(self, template_id, force_send=False, filter_func=lambda self: self.state not in ('cancel', 'draft')):
            // for event in self:
            //     for attendee in event.registration_ids.filtered(filter_func):
            //         self.env['mail.template'].browse(template_id).send_mail(attendee.id, force_send=force_send)
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<EventEvent> MassMailingAttendeesAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_event, FILE: event_event.py) ---
            // def action_mass_mailing_attendees(self):
            // return {
            //     'name': 'Mass Mail Attendees',
            //     'type': 'ir.actions.act_window',
            //     'res_model': 'mailing.mailing',
            //     'view_mode': 'form',
            //     'target': 'current',
            //     'context': {
            //         'default_mailing_model_id': self.env.ref('event.model_event_registration').id,
            //         'default_mailing_domain': repr([('event_id', 'in', self.ids), ('state', 'not in', ['cancel', 'draft'])]),
            //         'default_subject': _("Event: %s", self.name),
            //     },
            // }
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_event_sms, FILE: event.py) ---
            // def action_mass_mailing_attendees(self):
            // # Minimal override: set form view being the one mixing sms and mail (not prioritized one)
            // action = super(Event, self).action_mass_mailing_attendees()
            // action['view_id'] = self.env.ref('mass_mailing_sms.mailing_mailing_view_form_mixed').id
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<EventEvent> MassMailingTrackSpeakersAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_event_track, FILE: event_event.py) ---
            // def action_mass_mailing_track_speakers(self):
            // mass_mailing_action = dict(
            //     name='Mass Mail Attendees',
            //     type='ir.actions.act_window',
            //     res_model='mailing.mailing',
            //     view_mode='form',
            //     target='current',
            //     context=dict(
            //         default_mailing_model_id=self.env.ref('website_event_track.model_event_track').id,
            //         default_mailing_domain=repr([('event_id', 'in', self.ids), ('stage_id.is_cancel', '!=', True)]),
            //         default_subject=_("Event: %s", self.name),
            //     ),
            // )
            // return mass_mailing_action
            --- ODOO METHOD SOURCE (MODULE: mass_mailing_event_track_sms, FILE: event.py) ---
            // def action_mass_mailing_track_speakers(self):
            // # Minimal override: set form view being the one mixing sms and mail (not prioritized one)
            // action = super(Event, self).action_mass_mailing_track_speakers()
            // action['view_id'] = self.env.ref('mass_mailing_sms.mailing_mailing_view_form_mixed').id
            // return action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<EventEvent> SearchAddressSearchInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _search_address_search(self, operator, value):
            // if operator != 'ilike' or not isinstance(value, str):
            //     raise NotImplementedError(_('Operation not supported.'))
            // 
            // return expression.OR([
            //     [('address_id.name', 'ilike', value)],
            //     [('address_id.street', 'ilike', value)],
            //     [('address_id.street2', 'ilike', value)],
            //     [('address_id.city', 'ilike', value)],
            //     [('address_id.zip', 'ilike', value)],
            //     [('address_id.state_id', 'ilike', value)],
            //     [('address_id.country_id', 'ilike', value)],
            // ])
            */
            return default;
        }

        protected async Task<EventEvent> SearchBuildDatesInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _search_build_dates(self):
            // today = fields.Datetime.today()
            // 
            // def sdn(date):
            //     return fields.Datetime.to_string(date.replace(hour=23, minute=59, second=59))
            // 
            // def sd(date):
            //     return fields.Datetime.to_string(date)
            // 
            // def get_month_filter_domain(filter_name, months_delta):
            //     first_day_of_the_month = today.replace(day=1)
            //     filter_string = _('This month') if months_delta == 0 \
            //         else format_date(self.env, value=today + relativedelta(months=months_delta),
            //             date_format='LLLL', lang_code=get_lang(self.env).code).capitalize()
            //     return [filter_name, filter_string, [
            //         ("date_end", ">=", sd(first_day_of_the_month + relativedelta(months=months_delta))),
            //         ("date_begin", "<", sd(first_day_of_the_month + relativedelta(months=months_delta+1)))],
            //         0]
            // 
            // return [
            //     ['upcoming', _('Upcoming Events'), [("date_end", ">", sd(today))], 0],
            //     ['today', _('Today'), [
            //         ("date_end", ">", sd(today)),
            //         ("date_begin", "<", sdn(today))],
            //         0],
            //     get_month_filter_domain('month', 0),
            //     ['old', _('Past Events'), [
            //         ("date_end", "<", sd(today))],
            //         0],
            //     ['all', _('All Events'), [], 0]
            // ]
            */
            return default;
        }

        protected async Task<EventEvent> SearchGetDetailInternalAsync(object website, object order, object options)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _search_get_detail(self, website, order, options):
            // with_description = options['displayDescription']
            // with_date = options['displayDetail']
            // date = options.get('date', 'all')
            // country = options.get('country')
            // tags = options.get('tags')
            // event_type = options.get('type', 'all')
            // 
            // domain = [website.website_domain()]
            // domain.append([('is_visible_on_website', '=', True)])
            // 
            // if event_type != 'all':
            //     domain.append([("event_type_id", "=", int(event_type))])
            // search_tags = self.env['event.tag']
            // if tags:
            //     try:
            //         tag_ids = literal_eval(tags)
            //     except SyntaxError:
            //         pass
            //     else:
            //         # perform a search to filter on existing / valid tags implicitely + apply rules on color
            //         search_tags = self.env['event.tag'].search([('id', 'in', tag_ids)])
            // 
            //     # Example: You filter on age: 10-12 and activity: football.
            //     # Doing it this way allows to only get events who are tagged "age: 10-12" AND "activity: football".
            //     # Add another tag "age: 12-15" to the search and it would fetch the ones who are tagged:
            //     # ("age: 10-12" OR "age: 12-15") AND "activity: football
            //     for tags in search_tags.grouped('category_id').values():
            //         domain.append([('tag_ids', 'in', tags.ids)])
            // 
            // no_country_domain = domain.copy()
            // if country:
            //     if country == 'online':
            //         domain.append([("country_id", "=", False)])
            //     elif country != 'all':
            //         domain.append([("country_id", "=", int(country))])
            // 
            // no_date_domain = domain.copy()
            // dates = self._search_build_dates()
            // current_date = None
            // for date_details in dates:
            //     if date == date_details[0]:
            //         domain.append(date_details[2])
            //         no_country_domain.append(date_details[2])
            //         if date_details[0] != 'upcoming':
            //             current_date = date_details[1]
            // 
            // search_fields = ['name']
            // fetch_fields = ['name', 'website_url', 'address_name']
            // mapping = {
            //     'name': {'name': 'name', 'type': 'text', 'match': True},
            //     'website_url': {'name': 'website_url', 'type': 'text', 'truncate': False},
            //     'address_name': {'name': 'address_name', 'type': 'text', 'match': True},
            // }
            // if with_description:
            //     search_fields.append('subtitle')
            //     fetch_fields.append('subtitle')
            //     mapping['description'] = {'name': 'subtitle', 'type': 'text', 'match': True}
            // if with_date:
            //     mapping['detail'] = {'name': 'range', 'type': 'html'}
            // 
            // # Bypassing the access rigths of partner to search the address.
            // def search_in_address(env, search_term):
            //     ret = env['event.event'].sudo()._search([
            //        ('address_search', 'ilike', search_term),
            //     ])
            //     return [('id', 'in', ret)]
            // 
            // return {
            //     'model': 'event.event',
            //     'base_domain': domain,
            //     'search_fields': search_fields,
            //     'search_extra': search_in_address,
            //     'fetch_fields': fetch_fields,
            //     'mapping': mapping,
            //     'icon': 'fa-ticket',
            //     # for website_event main controller:
            //     'dates': dates,
            //     'current_date': current_date,
            //     'search_tags': search_tags,
            //     'no_date_domain': no_date_domain,
            //     'no_country_domain': no_country_domain,
            // }
            */
            return default;
        }

        protected async Task<EventEvent> SearchIsFinishedInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _search_is_finished(self, operator, value):
            // if operator not in ['=', '!=']:
            //     raise ValueError(_('This operator is not supported'))
            // if not isinstance(value, bool):
            //     raise ValueError(_('Value should be True or False (not %s)'), value)
            // now = fields.Datetime.now()
            // if (operator == '=' and value) or (operator == '!=' and not value):
            //     domain = [('date_end', '<=', now)]
            // else:
            //     domain = [('date_end', '>', now)]
            // return domain
            */
            return default;
        }

        protected async Task<EventEvent> SearchIsOngoingInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _search_is_ongoing(self, operator, value):
            // if operator not in ['=', '!=']:
            //     raise UserError(_('This operator is not supported'))
            // if not isinstance(value, bool):
            //     raise UserError(_('Value should be True or False (not %s)', value))
            // now = fields.Datetime.now()
            // if (operator == '=' and value) or (operator == '!=' and not value):
            //     domain = [('date_begin', '<=', now), ('date_end', '>', now)]
            // else:
            //     domain = ['|', ('date_begin', '>', now), ('date_end', '<=', now)]
            // return domain
            */
            return default;
        }

        protected async Task<EventEvent> SearchIsParticipatingInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _search_is_participating(self, operator, value):
            // if operator not in ['=', '!=']:
            //     raise NotImplementedError(_('This operator is not supported'))
            // if not isinstance(value, bool):
            //     raise UserError(_('Value should be True or False (not %)', value))
            // check_is_participating = operator == '=' and value or operator == '!=' and not value
            // 
            // return [('id', 'in' if check_is_participating else 'not in', self._fetch_is_participating_events().ids)]
            */
            return default;
        }

        protected async Task<EventEvent> SearchIsVisibleOnWebsiteInternalAsync(object @operator, object @value)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _search_is_visible_on_website(self, operator, value):
            // if operator not in ['=', '!=']:
            //     raise NotImplementedError(_('This operator is not supported'))
            // if not isinstance(value, bool):
            //     raise UserError(_('Value should be True or False (not %)', value))
            // check_is_visible_on_website = operator == '=' and value or operator == '!=' and not value
            // user = self.env.user
            // domain = [('is_participating', '=', True)]
            // 
            // if not user._is_public():
            //     domain = expression.OR([domain, [('website_visibility', 'in', ['public', 'logged_users'])]])
            // else:
            //     domain = expression.OR([domain, [('website_visibility', '=', 'public')]])
            // 
            // event_ids = self.env['event.event']._search(domain)
            // return [('id', 'in' if check_is_visible_on_website else 'not in', event_ids)]
            */
            return default;
        }

        protected async Task<EventEvent> SearchRenderResultsInternalAsync(object fetch_fields, object mapping, object icon, object limit)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _search_render_results(self, fetch_fields, mapping, icon, limit):
            // with_date = 'detail' in mapping
            // results_data = super()._search_render_results(fetch_fields, mapping, icon, limit)
            // if with_date:
            //     for event, data in zip(self, results_data):
            //         begin = self.env['ir.qweb.field.date'].record_to_html(event, 'date_begin', {})
            //         end = self.env['ir.qweb.field.date'].record_to_html(event, 'date_end', {})
            //         data['range'] = (
            //             Markup('{} <i class="fa fa-long-arrow-right"></i> {}').format(begin, end)
            //             if begin != end else begin
            //         )
            // return results_data
            */
            return default;
        }

        public async Task<EventEvent> SetDoneAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def action_set_done(self):
            // """
            // Action which will move the events
            // into the first next (by sequence) stage defined as "Ended"
            // (if they are not already in an ended stage)
            // """
            // first_ended_stage = self.env['event.stage'].search([('pipe_end', '=', True)], limit=1, order='sequence')
            // if first_ended_stage:
            //     self.write({'stage_id': first_ended_stage.id})
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<EventEvent> SetTzContextInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def _set_tz_context(self):
            // self.ensure_one()
            // return self.with_context(tz=self.date_tz or 'UTC')
            */
            return default;
        }

        protected async Task<EventEvent> SplitMenusStateByFieldInternalAsync()
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _split_menus_state_by_field(self):
            // """ For each field linked to a menu, get the set of events having this
            // menu activated and de-activated. Purpose is to find those whose value
            // changed and update the underlying menus.
            // 
            // :return dict: key = name of field triggering a website menu update, get {
            //   'activated': subset of self having its menu currently set to True
            //   'deactivated': subset of self having its menu currently set to False
            // } """
            // menus_state_by_field = dict()
            // for fname in self._get_menu_update_fields():
            //     activated = self.filtered(lambda event: event[fname])
            //     menus_state_by_field[fname] = {
            //         'activated': activated,
            //         'deactivated': self - activated,
            //     }
            // return menus_state_by_field
            */
            return default;
        }

        public async Task<EventEvent> ToggleBoothMenuAsync(Guid id, object val)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_booth, FILE: event_event.py) ---
            // def toggle_booth_menu(self, val):
            // self.booth_menu = val
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<EventEvent> ToggleExhibitorMenuAsync(Guid id, object val)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_event.py) ---
            // def toggle_exhibitor_menu(self, val):
            // self.exhibitor_menu = val
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<EventEvent> ToggleWebsiteMenuAsync(Guid id, object val)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def toggle_website_menu(self, val):
            // self.website_menu = val
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<EventEvent> ToggleWebsiteTrackAsync(Guid id, object val)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py) ---
            // def toggle_website_track(self, val):
            // self.website_track = val
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public async Task<EventEvent> ToggleWebsiteTrackProposalAsync(Guid id, object val)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py) ---
            // def toggle_website_track_proposal(self, val):
            // self.website_track_proposal = val
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        protected async Task<EventEvent> TrackSubtypeInternalAsync(object init_values)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _track_subtype(self, init_values):
            // self.ensure_one()
            // if init_values.keys() & {'is_published', 'website_published'}:
            //     if self.is_published:
            //         return self.env.ref('website_event.mt_event_published', raise_if_not_found=False)
            //     return self.env.ref('website_event.mt_event_unpublished', raise_if_not_found=False)
            // return super(Event, self)._track_subtype(init_values)
            */
            return default;
        }

        protected async Task<EventEvent> UpdateWebsiteMenuEntryInternalAsync(object fname_bool, object fname_o2m, object fmenu_type)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _update_website_menu_entry(self, fname_bool, fname_o2m, fmenu_type):
            // """ Generic method to create menu entries based on a flag on event. This
            // method is a bit obscure, but is due to preparation of adding new menus
            // entries and pages for event in a stable version, leading to some constraints
            // while developing.
            // 
            // :param fname_bool: field name (e.g. website_track)
            // :param fname_o2m: o2m linking towards website.event.menu matching the
            //   boolean fields (normally an entry of website.event.menu with type matching
            //   the boolean field name)
            // :param method_name: method returning menu entries information: url, sequence, ...
            // """
            // self.ensure_one()
            // new_menu = None
            // 
            // menu_data = [menu_info for menu_info in self._get_website_menu_entries()
            //              if menu_info[4] == fmenu_type]
            // if self[fname_bool] and not self[fname_o2m]:
            //     # menus not found but boolean True: get menus to create
            //     for name, url, xml_id, menu_sequence, menu_type in menu_data:
            //         new_menu = self._create_menu(menu_sequence, name, url, xml_id, menu_type)
            // elif not self[fname_bool]:
            //     # will cascade delete to the website.event.menu
            //     self[fname_o2m].mapped('menu_id').sudo().unlink()
            // 
            // return new_menu
            */
            return default;
        }

        protected async Task<EventEvent> UpdateWebsiteMenusInternalAsync(object menus_update_by_field)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def _update_website_menus(self, menus_update_by_field=None):
            // """ Synchronize event configuration and its menu entries for frontend.
            // 
            // :param menus_update_by_field: see ``_get_menus_update_by_field``"""
            // for event in self:
            //     if event.menu_id and not event.website_menu:
            //         # do not rely on cascade, as it is done in SQL -> not calling override and
            //         # letting some ir.ui.views in DB
            //         (event.menu_id + event.menu_id.child_id).sudo().unlink()
            //     elif event.website_menu and not event.menu_id:
            //         root_menu = self.env['website.menu'].sudo().create({'name': event.name, 'website_id': event.website_id.id})
            //         event.menu_id = root_menu
            //     if event.menu_id and (not menus_update_by_field or event in menus_update_by_field.get('community_menu')):
            //         event._update_website_menu_entry('community_menu', 'community_menu_ids', 'community')
            //     if event.menu_id and (not menus_update_by_field or event in menus_update_by_field.get('introduction_menu')):
            //         event._update_website_menu_entry('introduction_menu', 'introduction_menu_ids', 'introduction')
            //     if event.menu_id and (not menus_update_by_field or event in menus_update_by_field.get('location_menu')):
            //         event._update_website_menu_entry('location_menu', 'location_menu_ids', 'location')
            //     if event.menu_id and (not menus_update_by_field or event in menus_update_by_field.get('register_menu')):
            //         event._update_website_menu_entry('register_menu', 'register_menu_ids', 'register')
            --- ODOO METHOD SOURCE (MODULE: website_event_booth, FILE: event_event.py) ---
            // def _update_website_menus(self, menus_update_by_field=None):
            // super(Event, self)._update_website_menus(menus_update_by_field=menus_update_by_field)
            // for event in self:
            //     if event.menu_id and (not menus_update_by_field or event in menus_update_by_field.get('booth_menu')):
            //         event._update_website_menu_entry('booth_menu', 'booth_menu_ids', 'booth')
            --- ODOO METHOD SOURCE (MODULE: website_event_exhibitor, FILE: event_event.py) ---
            // def _update_website_menus(self, menus_update_by_field=None):
            // super(EventEvent, self)._update_website_menus(menus_update_by_field=menus_update_by_field)
            // for event in self:
            //     if event.menu_id and (not menus_update_by_field or event in menus_update_by_field.get('exhibitor_menu')):
            //         event._update_website_menu_entry('exhibitor_menu', 'exhibitor_menu_ids', 'exhibitor')
            --- ODOO METHOD SOURCE (MODULE: website_event_track, FILE: event_event.py) ---
            // def _update_website_menus(self, menus_update_by_field=None):
            // super(Event, self)._update_website_menus(menus_update_by_field=menus_update_by_field)
            // for event in self:
            //     if event.menu_id and (not menus_update_by_field or event in menus_update_by_field.get('website_track')):
            //         event._update_website_menu_entry('website_track', 'track_menu_ids', 'track')
            //     if event.menu_id and (not menus_update_by_field or event in menus_update_by_field.get('website_track_proposal')):
            //         event._update_website_menu_entry('website_track_proposal', 'track_proposal_menu_ids', 'track_proposal')
            */
            return default;
        }

        public async Task<EventEvent> ViewLinkedOrdersAsync(Guid id)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event_sale, FILE: event_event.py) ---
            // def action_view_linked_orders(self):
            // """ Redirects to the orders linked to the current events """
            // sale_order_action = self.env["ir.actions.actions"]._for_xml_id("sale.action_orders")
            // sale_order_action.update({
            //     'domain': [('state', '!=', 'cancel'), ('order_line.event_id', 'in', self.ids)],
            //     'context': {'create': 0},
            // })
            // return sale_order_action
            */
            var entity = await Repository.GetAsync(id); return entity;
        }

        public override async Task<List<object>> WriteAsync(List<Guid> ids, EventEvent entity, List<string> fields)
        {
            /*
            --- ODOO METHOD SOURCE (MODULE: event, FILE: event_event.py) ---
            // def write(self, vals):
            // if 'stage_id' in vals and 'kanban_state' not in vals:
            //     # reset kanban state when changing stage
            //     vals['kanban_state'] = 'normal'
            // res = super(EventEvent, self).write(vals)
            // if vals.get('organizer_id'):
            //     self.message_subscribe([vals['organizer_id']])
            // return res
            --- ODOO METHOD SOURCE (MODULE: website_event, FILE: event_event.py) ---
            // def write(self, vals):
            // menus_state_by_field = self._split_menus_state_by_field()
            // res = super(Event, self).write(vals)
            // menus_update_by_field = self._get_menus_update_by_field(menus_state_by_field, force_update=vals.keys())
            // self._update_website_menus(menus_update_by_field=menus_update_by_field)
            // return res
            */
            return await base.WriteAsync(ids, entity, fields);
        }
    }
}