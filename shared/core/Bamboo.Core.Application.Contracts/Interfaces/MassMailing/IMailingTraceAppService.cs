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
    public interface IMailingTraceAppService : IGenericApplicationService<MailingTrace>
    {
        Task<MailingTrace> SetBouncedAsync(Guid id, MailingTraceSetBouncedRequestDto input);
        Task<MailingTrace> SetCanceledAsync(Guid id, MailingTraceSetCanceledRequestDto input);
        Task<MailingTrace> SetClickedAsync(Guid id, MailingTraceSetClickedRequestDto input);
        Task<MailingTrace> SetFailedAsync(Guid id, MailingTraceSetFailedRequestDto input);
        Task<MailingTrace> SetOpenedAsync(Guid id, MailingTraceSetOpenedRequestDto input);
        Task<MailingTrace> SetRepliedAsync(Guid id, MailingTraceSetRepliedRequestDto input);
        Task<MailingTrace> SetSentAsync(Guid id, MailingTraceSetSentRequestDto input);
        Task<MailingTrace> ViewContactAsync(Guid id);
    }
}