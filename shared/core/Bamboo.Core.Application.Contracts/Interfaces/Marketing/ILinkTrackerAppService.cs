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
        Task<LinkTracker> ConvertLinksAsync(LinkTrackerConvertLinksRequestDto input);
        Task<LinkTracker> GetUrlFromCodeAsync(LinkTrackerGetUrlFromCodeRequestDto input);
        Task<LinkTracker> RecentLinksAsync(LinkTrackerRecentLinksRequestDto input);
        Task<LinkTracker> SearchOrCreateAsync(LinkTrackerSearchOrCreateRequestDto input);
        Task<LinkTracker> ViewStatisticsAsync(Guid[] ids);
        Task<LinkTracker> VisitPageAsync(Guid[] ids);
        Task<LinkTracker> VisitPageStatisticsAsync(Guid[] ids);
    }
}