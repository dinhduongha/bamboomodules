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
    public interface IFetchmailServerAppService : IGenericApplicationService<FetchmailServer>
    {
        Task<FetchmailServer> ButtonConfirmLoginAsync(Guid id);
        Task<FetchmailServer> ConnectAsync(Guid id, FetchmailServerConnectRequestDto input);
        Task<FetchmailServer> FetchMailAsync(Guid id, FetchmailServerFetchMailRequestDto input);
        Task<FetchmailServer> OnchangeServerTypeAsync(Guid id);
        Task<FetchmailServer> SetDraftAsync(Guid id);
    }
}