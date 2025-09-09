using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Bamboo.Core.Models;
using Bamboo.Core.Application.Contracts;
using Bamboo.Core.Application.Contracts.DTOs;
namespace Bamboo.Core.Application.Contracts.Interfaces
{
    public interface IWebsitePageAppService : IGenericApplicationService<WebsitePage>
    {
        Task<WebsitePage> ClonePageAsync(Guid id, WebsitePageClonePageRequestDto input);
        Task<WebsitePage> CopyDataAsync(Guid id, WebsitePageCopyDataRequestDto input);
        Task<WebsitePage> GetWebsiteMetaAsync(Guid id);
        Task<WebsitePage> PageDebugViewAsync(Guid id);
    }
}