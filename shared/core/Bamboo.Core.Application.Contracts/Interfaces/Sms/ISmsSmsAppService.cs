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
    public interface ISmsSmsAppService : IGenericApplicationService<SmsSms>
    {
        Task<SmsSms> ResendFailedAsync(Guid id);
        Task<SmsSms> SendAsync(Guid id, SmsSmsSendRequestDto input);
        Task<SmsSms> SetCanceledAsync(Guid id);
        Task<SmsSms> SetErrorAsync(Guid id, SmsSmsSetErrorRequestDto input);
        Task<SmsSms> SetOutgoingAsync(Guid id);
    }
}