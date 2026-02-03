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
    public interface ISmsSmsAppService : IGenericAppService<SmsSms>
    {
        Task<SmsSms> ResendFailedAsync(Guid[] ids);
        Task<SmsSms> SendAsync(SmsSmsSendRequestDto input);
        Task<SmsSms> SetCanceledAsync(Guid[] ids);
        Task<SmsSms> SetErrorAsync(SmsSmsSetErrorRequestDto input);
        Task<SmsSms> SetOutgoingAsync(Guid[] ids);
    }
}