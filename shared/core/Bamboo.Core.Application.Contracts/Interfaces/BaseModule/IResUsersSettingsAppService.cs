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
    public interface IResUsersSettingsAppService : IGenericApplicationService<ResUsersSettings>
    {
        Task<ResUsersSettings> SetCustomNotificationsAsync(Guid id, ResUsersSettingsSetCustomNotificationsRequestDto input);
        Task<ResUsersSettings> SetResUsersSettingsAsync(Guid id, ResUsersSettingsSetResUsersSettingsRequestDto input);
        Task<ResUsersSettings> SetVolumeSettingAsync(Guid id, ResUsersSettingsSetVolumeSettingRequestDto input);
    }
}