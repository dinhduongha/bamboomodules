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
    [Module("Mail", Category = "Productivity", Depends = new[] { "base", "base_setup", "bus", "web_tour", "html_editor" })]
    public partial class FetchmailServerAppService : GenericAppService<FetchmailServer>, IFetchmailServerAppService
    {
        protected readonly IGoogleGmailMixinAppService _googleGmailMixinAppService;
        protected readonly IMicrosoftOutlookMixinAppService _microsoftOutlookMixinAppService;
        public FetchmailServerAppService(IRepository<FetchmailServer, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IGoogleGmailMixinAppService googleGmailMixinAppService, IMicrosoftOutlookMixinAppService microsoftOutlookMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _googleGmailMixinAppService = googleGmailMixinAppService;
            _microsoftOutlookMixinAppService = microsoftOutlookMixinAppService;
        }

        public async Task<FetchmailServer> ButtonConfirmLoginAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: fetchmail.py, METHOD: button_confirm_login) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<FetchmailServer> FetchMailAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: fetchmail.py, METHOD: fetch_mail) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<FetchmailServer> OnchangeServerTypeAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: google_gmail, FILE: fetchmail_server.py, METHOD: onchange_server_type) ---
            --- METHOD SOURCE (MODULE: mail, FILE: fetchmail.py, METHOD: onchange_server_type) ---
            --- METHOD SOURCE (MODULE: microsoft_outlook, FILE: fetchmail_server.py, METHOD: onchange_server_type) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<FetchmailServer> SetDraftAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: mail, FILE: fetchmail.py, METHOD: set_draft) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }
    }
}