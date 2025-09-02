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
    public interface IWebTourTourAppService : IGenericApplicationService<WebTourTour>
    {
        Task<WebTourTour> ConsumeAsync(Guid id, WebTourTourConsumeRequestDto input);
        Task<WebTourTour> ExportJsFileAsync(Guid id);
        Task<WebTourTour> GetCurrentTourAsync(Guid id);
        Task<WebTourTour> GetTourJsonByNameAsync(Guid id, WebTourTourGetTourJsonByNameRequestDto input);
    }
}