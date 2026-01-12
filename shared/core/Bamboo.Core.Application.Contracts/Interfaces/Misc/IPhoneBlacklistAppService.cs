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
    public interface IPhoneBlacklistAppService : IGenericApplicationService<PhoneBlacklist>
    {
        Task<PhoneBlacklist> AddAsync(Guid id, PhoneBlacklistAddRequestDto input);
        Task<PhoneBlacklist> AddAsync(Guid id);
        Task<PhoneBlacklist> PhoneBlacklistRemoveAsync(Guid id);
        Task<PhoneBlacklist> RemoveAsync(Guid id, PhoneBlacklistRemoveRequestDto input);
    }
}