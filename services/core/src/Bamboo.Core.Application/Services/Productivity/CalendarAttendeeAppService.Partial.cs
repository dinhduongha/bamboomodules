using System;
using System.Threading.Tasks;
using System.Collections.Generic;
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
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Caching.Distributed;
using Bamboo.Core.Models;
using Bamboo.Core.Domain.Shared.Attributes;
using Bamboo.Core.Application.Services.Commons;
using Bamboo.Core.Application.Contracts.Interfaces;
using Bamboo.Core.Application.Contracts.Interfaces.Mixins;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Services
{
    public partial class CalendarAttendeeAppService
    {

        protected async Task<CalendarAttendee> ComputeCommonNameInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_attendee.py, METHOD: _compute_common_name) ---
            */
            return default;
        }

        protected async Task<CalendarAttendee> ComputeMailTzInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_attendee.py, METHOD: _compute_mail_tz) ---
            */
            return default;
        }

        protected async Task<CalendarAttendee> DefaultAccessTokenInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_attendee.py, METHOD: _default_access_token) ---
            */
            return default;
        }

        [ApiModel]
        protected async Task<CalendarAttendee> MailTemplateDefaultValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_attendee.py, METHOD: _mail_template_default_values) ---
            */
            return default;
        }

        protected async Task<CalendarAttendee> MessageAddDefaultRecipientsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_attendee.py, METHOD: _message_add_default_recipients) ---
            */
            return default;
        }

        protected async Task<CalendarAttendee> MicrosoftSyncEventInternalAsync(object answer)
        {
            /*
            --- METHOD SOURCE (MODULE: microsoft_calendar, FILE: calendar_attendee.py, METHOD: _microsoft_sync_event) ---
            */
            return default;
        }

        protected async Task<CalendarAttendee> NotifyAttendeesInternalAsync(object mail_template, object notify_author, object force_send)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_attendee.py, METHOD: _notify_attendees) ---
            */
            return default;
        }

        protected async Task<CalendarAttendee> SendInvitationEmailsInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_attendee.py, METHOD: _send_invitation_emails) ---
            */
            return default;
        }

        protected async Task<CalendarAttendee> ShouldNotifyAttendeeInternalAsync(object notify_author)
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_attendee.py, METHOD: _should_notify_attendee) ---
            */
            return default;
        }

        protected async Task<CalendarAttendee> SyncEventInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: google_calendar, FILE: calendar_attendee.py, METHOD: _sync_event) ---
            */
            return default;
        }

        protected async Task<CalendarAttendee> UnsubscribePartnerInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: calendar, FILE: calendar_attendee.py, METHOD: _unsubscribe_partner) ---
            */
            return default;
        }
    }
}