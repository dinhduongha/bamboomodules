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
    public interface IResUsersSettingsAppService : IGenericApplicationService<ResUsersSettings>
    {
        Task<ResUsersSettings> GetEmbeddedActionsSettingsAsync(Guid id);
        Task<ResUsersSettings> SetEmbeddedActionsSettingAsync(Guid id, ResUsersSettingsSetEmbeddedActionsSettingRequestDto input);
        Task<ResUsersSettings> SetResUsersSettingsAsync(Guid id, ResUsersSettingsSetResUsersSettingsRequestDto input);
        Task<ResUsersSettings> SetVolumeSettingAsync(Guid id, ResUsersSettingsSetVolumeSettingRequestDto input);
    }
}