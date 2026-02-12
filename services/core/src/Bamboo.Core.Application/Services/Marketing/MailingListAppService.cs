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
    public partial class MailingListAppService : GenericAppService<MailingList>, IMailingListAppService
    {

        public MailingListAppService(IRepository<MailingList, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {

        }

        public async Task<MailingList> CopyDataAsync(MailingListCopyDataRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_list.py, METHOD: copy_data) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingList> MergeAsync(MailingListMergeRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_list.py, METHOD: action_merge) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingList> OpenImportAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_list.py, METHOD: action_open_import) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingList> SendMailingAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_list.py, METHOD: action_send_mailing) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingList> SendMailingSmsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_list.py, METHOD: action_send_mailing_sms) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingList> ViewContactsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_list.py, METHOD: action_view_contacts) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingList> ViewContactsBlacklistedAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_list.py, METHOD: action_view_contacts_blacklisted) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingList> ViewContactsBouncingAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_list.py, METHOD: action_view_contacts_bouncing) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingList> ViewContactsEmailAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_list.py, METHOD: action_view_contacts_email) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingList> ViewContactsOptOutAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_list.py, METHOD: action_view_contacts_opt_out) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingList> ViewContactsSmsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_list.py, METHOD: action_view_contacts_sms) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<MailingList> ViewMailingsAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mass_mailing, FILE: mailing_list.py, METHOD: action_view_mailings) ---
            --- METHOD SOURCE (MODULE: mass_mailing_sms, FILE: mailing_list.py, METHOD: action_view_mailings) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}