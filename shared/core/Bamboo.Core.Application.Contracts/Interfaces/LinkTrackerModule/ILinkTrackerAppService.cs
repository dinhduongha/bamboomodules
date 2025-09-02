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