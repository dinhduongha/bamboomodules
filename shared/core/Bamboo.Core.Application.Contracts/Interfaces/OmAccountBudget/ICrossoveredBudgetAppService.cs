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
    public interface ICrossoveredBudgetAppService : IGenericApplicationService<CrossoveredBudget>
    {
        Task<CrossoveredBudget> BudgetCancelAsync(Guid id);
        Task<CrossoveredBudget> BudgetConfirmAsync(Guid id);
        Task<CrossoveredBudget> BudgetDoneAsync(Guid id);
        Task<CrossoveredBudget> BudgetDraftAsync(Guid id);
        Task<CrossoveredBudget> BudgetValidateAsync(Guid id);
    }
}