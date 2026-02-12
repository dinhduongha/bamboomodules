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
    [Module("PointOfSale", Category = "Sales", Depends = new[] { "resource", "stock_account", "barcodes", "html_editor", "digest", "phone_validation", "partner_autocomplete", "iot_base", "google_address_autocomplete" })]
    public partial class PosPaymentAppService : GenericAppService<PosPayment>, IPosPaymentAppService
    {
        protected readonly IPosLoadMixinAppService _posLoadMixinAppService;
        public PosPaymentAppService(IRepository<PosPayment, Guid> repository, ICurrentTenant currentTenant, IDistributedCache cache, IDomainParser domainParser, IModelTypeRegistry modelTypeRegistry, IPosLoadMixinAppService posLoadMixinAppService) : base(repository, currentTenant, cache, domainParser, modelTypeRegistry)
        {
            _posLoadMixinAppService = posLoadMixinAppService;
        }

        public override async Task<PosPayment> CreateAsync(CreateRequestDto<PosPayment> input)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_payment.py, METHOD: create) ---
            */
            return await base.CreateAsync(input);
        }

        public override async Task<List<object>> WriteAsync(UpdateRequestDto<PosPayment> input)
        {
            /*
            --- METHOD SOURCE (MODULE: pos_online_payment, FILE: pos_payment.py, METHOD: write) ---
            */
            return await base.WriteAsync(input);
        }
    }
}