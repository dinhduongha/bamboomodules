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
        Task<FetchmailServer> FetchMailAsync(Guid id);
        Task<FetchmailServer> OnchangeServerTypeAsync(Guid id);
        Task<FetchmailServer> SetDraftAsync(Guid id);
    }
}