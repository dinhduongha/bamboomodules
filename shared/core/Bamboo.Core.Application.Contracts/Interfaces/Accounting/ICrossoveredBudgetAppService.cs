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
    public interface ICrossoveredBudgetAppService : IGenericApplicationService<CrossoveredBudget>
    {
        Task<CrossoveredBudget> BudgetCancelAsync(Guid id);
        Task<CrossoveredBudget> BudgetConfirmAsync(Guid id);
        Task<CrossoveredBudget> BudgetDoneAsync(Guid id);
        Task<CrossoveredBudget> BudgetDraftAsync(Guid id);
        Task<CrossoveredBudget> BudgetValidateAsync(Guid id);
    }
}