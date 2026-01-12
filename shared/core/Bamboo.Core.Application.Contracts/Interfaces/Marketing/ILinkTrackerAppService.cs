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
    public interface ILinkTrackerAppService : IGenericApplicationService<LinkTracker>
    {
        Task<LinkTracker> ConvertLinksAsync(Guid id, LinkTrackerConvertLinksRequestDto input);
        Task<LinkTracker> GetUrlFromCodeAsync(Guid id, LinkTrackerGetUrlFromCodeRequestDto input);
        Task<LinkTracker> RecentLinksAsync(Guid id, LinkTrackerRecentLinksRequestDto input);
        Task<LinkTracker> SearchOrCreateAsync(Guid id, LinkTrackerSearchOrCreateRequestDto input);
        Task<LinkTracker> ViewStatisticsAsync(Guid id);
        Task<LinkTracker> VisitPageAsync(Guid id);
        Task<LinkTracker> VisitPageStatisticsAsync(Guid id);
    }
}