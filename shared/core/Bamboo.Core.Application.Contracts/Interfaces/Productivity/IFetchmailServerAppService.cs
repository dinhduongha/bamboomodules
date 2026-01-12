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
    public interface IFetchmailServerAppService : IGenericApplicationService<FetchmailServer>
    {
        Task<FetchmailServer> ButtonConfirmLoginAsync(Guid id);
        Task<FetchmailServer> ConnectAsync(Guid id, FetchmailServerConnectRequestDto input);
        Task<FetchmailServer> FetchMailAsync(Guid id, FetchmailServerFetchMailRequestDto input);
        Task<FetchmailServer> OnchangeServerTypeAsync(Guid id);
        Task<FetchmailServer> SetDraftAsync(Guid id);
    }
}