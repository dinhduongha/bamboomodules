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
    public interface IResGroupsAppService : IGenericApplicationService<ResGroups>
    {
        Task<ResGroups> CopyDataAsync(Guid id, ResGroupsCopyDataRequestDto input);
        Task<ResGroups> GetApplicationGroupsAsync(Guid id, ResGroupsGetApplicationGroupsRequestDto input);
        Task<ResGroups> ShowAllUsersAsync(Guid id);
    }
}