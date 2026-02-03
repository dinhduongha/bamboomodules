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
        Task<FetchmailServer> ButtonConfirmLoginAsync(Guid[] ids);
        Task<FetchmailServer> FetchMailAsync(Guid[] ids);
        Task<FetchmailServer> OnchangeServerTypeAsync(Guid[] ids);
        Task<FetchmailServer> SetDraftAsync(Guid[] ids);
    }
}