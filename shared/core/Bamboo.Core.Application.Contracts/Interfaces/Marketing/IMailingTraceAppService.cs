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
    public interface IMailingTraceAppService : IGenericApplicationService<MailingTrace>
    {
        Task<MailingTrace> SetBouncedAsync(MailingTraceSetBouncedRequestDto input);
        Task<MailingTrace> SetCanceledAsync(MailingTraceSetCanceledRequestDto input);
        Task<MailingTrace> SetClickedAsync(MailingTraceSetClickedRequestDto input);
        Task<MailingTrace> SetFailedAsync(MailingTraceSetFailedRequestDto input);
        Task<MailingTrace> SetOpenedAsync(MailingTraceSetOpenedRequestDto input);
        Task<MailingTrace> SetRepliedAsync(MailingTraceSetRepliedRequestDto input);
        Task<MailingTrace> SetSentAsync(MailingTraceSetSentRequestDto input);
        Task<MailingTrace> ViewContactAsync(Guid[] ids);
    }
}