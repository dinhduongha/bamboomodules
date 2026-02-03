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
    public interface ICrossoveredBudgetAppService : IGenericApplicationService<CrossoveredBudget>
    {
        Task<CrossoveredBudget> BudgetCancelAsync(Guid[] ids);
        Task<CrossoveredBudget> BudgetConfirmAsync(Guid[] ids);
        Task<CrossoveredBudget> BudgetDoneAsync(Guid[] ids);
        Task<CrossoveredBudget> BudgetDraftAsync(Guid[] ids);
        Task<CrossoveredBudget> BudgetValidateAsync(Guid[] ids);
    }
}