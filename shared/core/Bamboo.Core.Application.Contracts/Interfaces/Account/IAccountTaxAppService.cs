using Bamboo.Core.Application.Contracts.DTOs;
using Volo.Abp.Application.Services;
using System.Linq;
using System.Collections.Generic;
using System;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Models;
using System.Threading.Tasks;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IAccountTaxAppService : IGenericApplicationService<AccountTax>
    {
        Task<AccountTax> ComputeAllAsync(Guid id, AccountTaxComputeAllRequestDto input);
        Task<AccountTax> CopyDataAsync(Guid id, AccountTaxCopyDataRequestDto input);
        Task<AccountTax> FlattenTaxesHierarchyAsync(Guid id);
        Task<AccountTax> GetTaxTagsAsync(Guid id, AccountTaxGetTaxTagsRequestDto input);
        Task<AccountTax> OnchangeAmountAsync(Guid id);
        Task<AccountTax> OnchangeAmountTypeAsync(Guid id);
        Task<AccountTax> OnchangePriceIncludeAsync(Guid id);
        Task<AccountTax> ValidateTaxGroupIdAsync(Guid id);
    }
}