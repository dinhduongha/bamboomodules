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
    public interface IEventTrackAppService : IGenericApplicationService<EventTrack>
    {
        Task<EventTrack> AddQuizAsync(Guid id);
        Task<EventTrack> GetBackendMenuIdAsync(Guid id);
        Task<EventTrack> OpenTrackSpeakersListAsync(Guid id);
        Task<EventTrack> ViewQuizAsync(Guid id);
    }
}