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
    public interface IWebTourTourAppService : IGenericApplicationService<WebTourTour>
    {
        Task<WebTourTour> ConsumeAsync(WebTourTourConsumeRequestDto input);
        Task<WebTourTour> ExportJsFileAsync(Guid[] ids);
        Task<WebTourTour> GetCurrentTourAsync(Guid[] ids);
        Task<WebTourTour> GetTourJsonByNameAsync(WebTourTourGetTourJsonByNameRequestDto input);
    }
}