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
    public interface IGamificationGoalAppService : IGenericApplicationService<GamificationGoal>
    {
        Task<GamificationGoal> CancelAsync(Guid[] ids);
        Task<GamificationGoal> FailAsync(Guid[] ids);
        Task<GamificationGoal> GetActionAsync(Guid[] ids);
        Task<GamificationGoal> ReachAsync(Guid[] ids);
        Task<GamificationGoal> StartAsync(Guid[] ids);
        Task<GamificationGoal> UpdateGoalAsync(Guid[] ids);
    }
}