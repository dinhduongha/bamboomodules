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
    public interface IAccountAnalyticPlanAppService : IGenericApplicationService<AccountAnalyticPlan>
    {
        Task<AccountAnalyticPlan> GetRelevantPlansAsync(Guid id);
        Task<AccountAnalyticPlan> ViewAnalyticalAccountsAsync(Guid id);
        Task<AccountAnalyticPlan> ViewChildrenPlansAsync(Guid id);
    }
}