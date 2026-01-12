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
    public interface IDiscussChannelMemberAppService : IGenericApplicationService<DiscussChannelMember>
    {
        // v18
        //Task<DiscussChannelMember> InitAsync(Guid id);
        //Task<DiscussChannelMember> SetCustomNotificationsAsync(Guid id, DiscussChannelMemberSetCustomNotificationsRequestDto input);
    }
}