using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
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