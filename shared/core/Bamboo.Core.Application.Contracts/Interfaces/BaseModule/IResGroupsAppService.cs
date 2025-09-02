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
    public interface IResGroupsAppService : IGenericApplicationService<ResGroups>
    {
        Task<ResGroups> CopyDataAsync(Guid id, ResGroupsCopyDataRequestDto input);
        Task<ResGroups> GetApplicationGroupsAsync(Guid id, ResGroupsGetApplicationGroupsRequestDto input);
        Task<ResGroups> GetGroupsByApplicationAsync(Guid id);
    }
}