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
    public partial class EventMailAppService
    {

        protected async Task<EventMail> ComputeMailStateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_mail.py, METHOD: _compute_mail_state) ---
            */
            return default;
        }

        protected async Task<EventMail> ComputeNotificationTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_mail.py, METHOD: _compute_notification_type) ---
            --- METHOD SOURCE (MODULE: event_sms, FILE: event_mail.py, METHOD: _compute_notification_type) ---
            */
            return default;
        }

        protected async Task<EventMail> ComputeScheduledDateInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_mail.py, METHOD: _compute_scheduled_date) ---
            */
            return default;
        }

        protected async Task<EventMail> CreateMissingMailRegistrationsInternalAsync(object registrations)
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_mail.py, METHOD: _create_missing_mail_registrations) ---
            */
            return default;
        }

        protected async Task<EventMail> ExecuteAttendeeBasedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_mail.py, METHOD: _execute_attendee_based) ---
            */
            return default;
        }

        protected async Task<EventMail> ExecuteEventBasedForRegistrationsInternalAsync(object registrations)
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_mail.py, METHOD: _execute_event_based_for_registrations) ---
            --- METHOD SOURCE (MODULE: event_sms, FILE: event_mail.py, METHOD: _execute_event_based_for_registrations) ---
            */
            return default;
        }

        protected async Task<EventMail> ExecuteEventBasedInternalAsync(object mail_slot)
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_mail.py, METHOD: _execute_event_based) ---
            */
            return default;
        }

        protected async Task<EventMail> ExecuteSlotBasedInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_mail.py, METHOD: _execute_slot_based) ---
            */
            return default;
        }

        protected async Task<EventMail> FilterTemplateRefInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_mail.py, METHOD: _filter_template_ref) ---
            */
            return default;
        }

        protected async Task<EventMail> PrepareEventMailValuesInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_mail.py, METHOD: _prepare_event_mail_values) ---
            */
            return default;
        }

        protected async Task<EventMail> RefreshMailCountDoneInternalAsync(object mail_slot)
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_mail.py, METHOD: _refresh_mail_count_done) ---
            */
            return default;
        }

        protected async Task<EventMail> SendMailInternalAsync(object registrations)
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_mail.py, METHOD: _send_mail) ---
            */
            return default;
        }

        protected async Task<EventMail> SendSmsInternalAsync(object registrations)
        {
            /*
            --- METHOD SOURCE (MODULE: event_sms, FILE: event_mail.py, METHOD: _send_sms) ---
            */
            return default;
        }

        protected async Task<EventMail> TemplateModelByNotificationTypeInternalAsync()
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_mail.py, METHOD: _template_model_by_notification_type) ---
            --- METHOD SOURCE (MODULE: event_sms, FILE: event_mail.py, METHOD: _template_model_by_notification_type) ---
            */
            return default;
        }

        protected async Task<EventMail> WarnErrorInternalAsync(object exception)
        {
            /*
            --- METHOD SOURCE (MODULE: event, FILE: event_mail.py, METHOD: _warn_error) ---
            */
            return default;
        }
    }
}