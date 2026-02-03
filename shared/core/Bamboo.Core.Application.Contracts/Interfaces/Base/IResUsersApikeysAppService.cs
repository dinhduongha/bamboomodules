using Volo.Abp.Application.Services;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IResUsersApikeysAppService : IApplicationService
    {
        Task<ResUsersApikeys> InitAsync(Guid[] ids);
        Task<ResUsersApikeys> RemoveAsync(Guid[] ids);
    }
}