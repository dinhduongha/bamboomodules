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
    public interface IGamificationChallengeAppService : IGenericAppService<GamificationChallenge>
    {
        Task<GamificationChallenge> AcceptChallengeAsync(Guid[] ids);
        Task<GamificationChallenge> CheckAsync(Guid[] ids);
        Task<GamificationChallenge> DiscardChallengeAsync(Guid[] ids);
        Task<GamificationChallenge> ReportProgressAsync(Guid[] ids);
        Task<GamificationChallenge> ReportProgressAsync(GamificationChallengeReportProgressRequestDto input);
        Task<GamificationChallenge> StartAsync(Guid[] ids);
        Task<GamificationChallenge> ViewUsersAsync(Guid[] ids);
    }
}