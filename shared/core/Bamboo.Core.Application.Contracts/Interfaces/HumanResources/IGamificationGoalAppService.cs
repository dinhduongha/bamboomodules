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
    public interface IGamificationGoalAppService : IGenericApplicationService<GamificationGoal>
    {
        Task<GamificationGoal> CancelAsync(Guid id);
        Task<GamificationGoal> FailAsync(Guid id);
        Task<GamificationGoal> GetActionAsync(Guid id);
        Task<GamificationGoal> ReachAsync(Guid id);
        Task<GamificationGoal> StartAsync(Guid id);
        Task<GamificationGoal> UpdateGoalAsync(Guid id);
    }
}