using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IAccountTaxAppService : IGenericApplicationService<AccountTax>
    {
        Task<AccountTax> ComputeAllAsync(AccountTaxComputeAllRequestDto input);
        Task<AccountTax> CopyDataAsync(AccountTaxCopyDataRequestDto input);
        Task<AccountTax> FlattenTaxesHierarchyAsync(Guid[] ids);
        Task<AccountTax> GetTaxTagsAsync(AccountTaxGetTaxTagsRequestDto input);
        Task<AccountTax> OnchangeAmountAsync(Guid[] ids);
        Task<AccountTax> OnchangeAmountTypeAsync(Guid[] ids);
        Task<AccountTax> OnchangePriceIncludeAsync(Guid[] ids);
        Task<AccountTax> ValidateTaxGroupIdAsync(Guid[] ids);
    }
}