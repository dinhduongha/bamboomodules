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
    public interface IPhoneBlacklistAppService : IGenericApplicationService<PhoneBlacklist>
    {
        Task<PhoneBlacklist> AddAsync(Guid id, PhoneBlacklistAddRequestDto input);
        Task<PhoneBlacklist> AddAsync(Guid id);
        Task<PhoneBlacklist> PhoneBlacklistRemoveAsync(Guid id);
        Task<PhoneBlacklist> RemoveAsync(Guid id, PhoneBlacklistRemoveRequestDto input);
    }
}