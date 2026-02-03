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
    public interface ISlideSlideAppService : IGenericAppService<SlideSlide>
    {
        Task<SlideSlide> CopyDataAsync(SlideSlideCopyDataRequestDto input);
        Task<SlideSlide> DislikeAsync(Guid[] ids);
        Task<SlideSlide> GetBackendMenuIdAsync(Guid[] ids);
        Task<SlideSlide> GetBaseUrlAsync(Guid[] ids);
        Task<SlideSlide> LikeAsync(Guid[] ids);
        Task<SlideSlide> MarkCompletedAsync(Guid[] ids);
        Task<SlideSlide> MarkUncompletedAsync(Guid[] ids);
        Task<SlideSlide> MessagePostAsync(Guid[] ids);
        Task<SlideSlide> SetViewedAsync(SlideSlideSetViewedRequestDto input);
        Task<SlideSlide> ViewEmbedsAsync(Guid[] ids);
    }
}