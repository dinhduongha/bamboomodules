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
    public interface IGamificationChallengeAppService : IGenericApplicationService<GamificationChallenge>
    {
        Task<GamificationChallenge> AcceptChallengeAsync(Guid id);
        Task<GamificationChallenge> CheckAsync(Guid id);
        Task<GamificationChallenge> DiscardChallengeAsync(Guid id);
        Task<GamificationChallenge> ReportProgressAsync(Guid id);
        Task<GamificationChallenge> ReportProgressAsync(Guid id, GamificationChallengeReportProgressRequestDto input);
        Task<GamificationChallenge> StartAsync(Guid id);
        Task<GamificationChallenge> ViewUsersAsync(Guid id);
    }
}