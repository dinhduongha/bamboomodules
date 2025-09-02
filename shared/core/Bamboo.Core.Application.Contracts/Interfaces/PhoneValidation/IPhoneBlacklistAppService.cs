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
    public interface IPhoneBlacklistAppService : IGenericApplicationService<PhoneBlacklist>
    {
        Task<PhoneBlacklist> AddAsync(Guid id, PhoneBlacklistAddRequestDto input);
        Task<PhoneBlacklist> AddAsync(Guid id);
        Task<PhoneBlacklist> PhoneBlacklistRemoveAsync(Guid id);
        Task<PhoneBlacklist> RemoveAsync(Guid id, PhoneBlacklistRemoveRequestDto input);
    }
}