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
    [Module("BaseModule", Category = "Base")]
    public partial class ResPartnerBankAppService : GenericAppService<ResPartnerBank>, IResPartnerBankAppService
    {
        protected readonly IMailActivityMixinAppService _mailActivityMixinAppService;
        protected readonly IMailThreadAppService _mailThreadAppService;
        public ResPartnerBankAppService(IRepository<ResPartnerBank, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IMailActivityMixinAppService mailActivityMixinAppService, IMailThreadAppService mailThreadAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _mailActivityMixinAppService = mailActivityMixinAppService;
            _mailThreadAppService = mailThreadAppService;
        }

        public async Task<ResPartnerBank> ArchiveBankAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_bank.py, METHOD: action_archive_bank) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartnerBank> BuildQrCodeBase64Async(ResPartnerBankBuildQrCodeBase64RequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: build_qr_code_base64) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartnerBank> BuildQrCodeUrlAsync(ResPartnerBankBuildQrCodeUrlRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: build_qr_code_url) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartnerBank> CheckIbanAsync(ResPartnerBankCheckIbanRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_iban, FILE: res_partner_bank.py, METHOD: check_iban) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<ResPartnerBank> CreateAsync(CreateRequestDto<ResPartnerBank> input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: base_iban, FILE: res_partner_bank.py, METHOD: create) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_bank.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        [ApiModel]
        public override async Task<ResPartnerBank> DefaultGetAsync(DefaultGetRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: default_get) ---
            */
            return await base.DefaultGetAsync(input);
        }

        [ApiModel]
        public async Task<ResPartnerBank> GetAvailableQrMethodsInSequenceAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: get_available_qr_methods_in_sequence) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartnerBank> GetBbanAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base_iban, FILE: res_partner_bank.py, METHOD: get_bban) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResPartnerBank> GetSupportedAccountTypesAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: base, FILE: res_bank.py, METHOD: get_supported_account_types) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public async Task<ResPartnerBank> OpenAllocationWizardAsync(Guid[] ids)
        {
            /*
            --- METHOD SOURCE (MODULE: hr, FILE: res_partner_bank.py, METHOD: action_open_allocation_wizard) ---
            */
            var entity = await Repository.GetAsync(ids[0]);
            await Task.CompletedTask;
            return default;
        }

        [ApiModel]
        public async Task<ResPartnerBank> RetrieveAccTypeAsync(ResPartnerBankRetrieveAccTypeRequestDto input)
        {
            /*
            --- METHOD SOURCE (MODULE: base_iban, FILE: res_partner_bank.py, METHOD: retrieve_acc_type) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_bank.py, METHOD: retrieve_acc_type) ---
            */
            var entity = await Repository.GetAsync(input.Ids[0]);
            await Task.CompletedTask;
            return default;
        }

        public override async Task<object> UnlinkAsync(List<Guid> ids)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: unlink) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_bank.py, METHOD: unlink) ---
            */
            return await base.UnlinkAsync(ids);
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<ResPartnerBank> input)
        {
            /*
            --- METHOD SOURCE (MODULE: account, FILE: res_partner_bank.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: base_iban, FILE: res_partner_bank.py, METHOD: write) ---
            --- METHOD SOURCE (MODULE: base, FILE: res_bank.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}