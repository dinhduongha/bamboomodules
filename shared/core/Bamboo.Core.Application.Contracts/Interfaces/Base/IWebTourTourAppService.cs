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
    public interface IWebTourTourAppService : IGenericApplicationService<WebTourTour>
    {
        Task<WebTourTour> ConsumeAsync(Guid id, WebTourTourConsumeRequestDto input);
        Task<WebTourTour> ExportJsFileAsync(Guid id);
        Task<WebTourTour> GetCurrentTourAsync(Guid id);
        Task<WebTourTour> GetTourJsonByNameAsync(Guid id, WebTourTourGetTourJsonByNameRequestDto input);
    }
}