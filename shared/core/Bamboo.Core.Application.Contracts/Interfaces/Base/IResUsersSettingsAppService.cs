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
        Task<ResUsersSettings> GetEmbeddedActionsSettingsAsync(Guid[] ids);
        Task<ResUsersSettings> SetEmbeddedActionsSettingAsync(ResUsersSettingsSetEmbeddedActionsSettingRequestDto input);
        Task<ResUsersSettings> SetResUsersSettingsAsync(ResUsersSettingsSetResUsersSettingsRequestDto input);
        Task<ResUsersSettings> SetVolumeSettingAsync(ResUsersSettingsSetVolumeSettingRequestDto input);
    }
}