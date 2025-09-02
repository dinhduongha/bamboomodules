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
    public interface IEventTrackAppService : IGenericApplicationService<EventTrack>
    {
        Task<EventTrack> AddQuizAsync(Guid id);
        Task<EventTrack> GetBackendMenuIdAsync(Guid id);
        Task<EventTrack> OpenTrackSpeakersListAsync(Guid id);
        Task<EventTrack> ViewQuizAsync(Guid id);
    }
}