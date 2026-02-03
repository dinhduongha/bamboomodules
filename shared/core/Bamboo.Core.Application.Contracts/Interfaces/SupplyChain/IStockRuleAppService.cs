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
    public interface IStockRuleAppService : IGenericAppService<StockRule>
    {
        Task<StockRule> CopyDataAsync(StockRuleCopyDataRequestDto input);
        Task<StockRule> RunAsync(StockRuleRunRequestDto input);
        Task<StockRule> RunSchedulerAsync(StockRuleRunSchedulerRequestDto input);
    }
}