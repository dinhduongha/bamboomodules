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
    public interface IEventMailAppService : IGenericApplicationService<EventMail>
    {
        Task<EventMail> ExecuteAsync(Guid id);
        Task<EventMail> RunAsync(Guid id, EventMailRunRequestDto input);
        Task<EventMail> ScheduleCommunicationsAsync(Guid id, EventMailScheduleCommunicationsRequestDto input);
    }
}