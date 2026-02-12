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
    [Module("MassMailing", Category = "Marketing", Depends = new[] { "contacts", "mail", "html_builder", "utm", "link_tracker", "social_media", "web_tour", "digest" })]
    public partial class MailingMailingAppService : GenericAppService<MailingMailing>, IMailingMailingAppService
    {
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailRenderMixinAppService _mailRenderMixinAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        protected readonly IUtmSourceMixinAppService _utmSourceMixinAppService;
        public MailingMailingAppService(IRepository<MailingMailing, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailRenderMixinAppService mailRenderMixinAppService, IMailThreadAppService mailThreadAppService, IUtmSourceMixinAppService utmSourceMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailRenderMixinAppService = mailRenderMixinAppService;
            _mailThreadAppService = mailThreadAppService;
            _utmSourceMixinAppService = utmSourceMixinAppService;
        }

        public async Task<MailingMailing> BuySmsCreditsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py, METHOD: action_buy_sms_credits) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingMailing> CancelAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_cancel) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingMailing> CompareVersionsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_compare_versions) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingMailing> ConvertLinksAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: convert_links) ---
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py, METHOD: convert_links) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingMailing> CopyDataAsync(MailingMailingCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<MailingMailing> CreateAsync(CreateRequestDto<MailingMailing> input)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        [ApiModel]
        public override async Task<MailingMailing> DefaultGetAsync(DefaultGetRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: default_get) ---
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py, METHOD: default_get) ---
            */
            return await base.DefaultGetAsync(input);
        }

        public async Task<MailingMailing> DuplicateAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_duplicate) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<MailingMailing> FetchFavoritesAsync(MailingMailingFetchFavoritesRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_fetch_favorites) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingMailing> GetSmsLinkReplacementsPlaceholdersAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py, METHOD: get_sms_link_replacements_placeholders) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingMailing> LaunchAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_launch) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingMailing> PutInQueueAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: mailing_mailing.py, METHOD: action_put_in_queue) ---
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_put_in_queue) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingMailing> RedirectToInvoicedAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_sale, FILE: mailing_mailing.py, METHOD: action_redirect_to_invoiced) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingMailing> RedirectToLeadsAndOpportunitiesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_crm, FILE: mailing_mailing.py, METHOD: action_redirect_to_leads_and_opportunities) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingMailing> RedirectToQuotationsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_sale, FILE: mailing_mailing.py, METHOD: action_redirect_to_quotations) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingMailing> ReloadAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_reload) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingMailing> RemoveFavoriteAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_remove_favorite) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingMailing> RetryFailedAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_retry_failed) ---
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py, METHOD: action_retry_failed) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingMailing> RetryFailedSmsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py, METHOD: action_retry_failed_sms) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingMailing> ScheduleAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_schedule) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingMailing> SelectAsWinnerAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_select_as_winner) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingMailing> SendMailAsync(MailingMailingSendMailRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: mailing_mailing.py, METHOD: action_send_mail) ---
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_send_mail) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingMailing> SendSmsAsync(MailingMailingSendSmsRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py, METHOD: action_send_sms) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingMailing> SendWinnerMailingAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_send_winner_mailing) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingMailing> SetFavoriteAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_set_favorite) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingMailing> TestAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_test) ---
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_mailing.py, METHOD: action_test) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingMailing> UpdateCardsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: marketing_card, FILE: mailing_mailing.py, METHOD: action_update_cards) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingMailing> ViewBouncedAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_bounced) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingMailing> ViewClickedAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_clicked) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingMailing> ViewDeliveredAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_delivered) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingMailing> ViewLinkTrackersAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_link_trackers) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingMailing> ViewMailingContactsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_mailing_contacts) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingMailing> ViewOpenedAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_opened) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingMailing> ViewRepliedAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_replied) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingMailing> ViewTracesCanceledAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_traces_canceled) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingMailing> ViewTracesFailedAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_traces_failed) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingMailing> ViewTracesProcessAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_traces_process) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingMailing> ViewTracesScheduledAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_traces_scheduled) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingMailing> ViewTracesSentAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing.py, METHOD: action_view_traces_sent) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}