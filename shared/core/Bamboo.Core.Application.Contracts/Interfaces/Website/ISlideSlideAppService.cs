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
    public interface ISlideSlideAppService : IGenericApplicationService<SlideSlide>
    {
        Task<SlideSlide> CopyDataAsync(Guid id, SlideSlideCopyDataRequestDto input);
        Task<SlideSlide> DislikeAsync(Guid id);
        Task<SlideSlide> GetBackendMenuIdAsync(Guid id);
        Task<SlideSlide> LikeAsync(Guid id);
        Task<SlideSlide> MarkCompletedAsync(Guid id);
        Task<SlideSlide> MarkUncompletedAsync(Guid id);
        Task<SlideSlide> MessagePostAsync(Guid id);
        Task<SlideSlide> OpenWebsiteUrlAsync(Guid id);
        Task<SlideSlide> SetViewedAsync(Guid id, SlideSlideSetViewedRequestDto input);
        Task<SlideSlide> ToggleActiveAsync(Guid id);
        Task<SlideSlide> ViewEmbedsAsync(Guid id);
    }
}