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
    public interface IWebsitePageAppService : IGenericApplicationService<WebsitePage>
    {
        Task<WebsitePage> ClonePageAsync(Guid id, WebsitePageClonePageRequestDto input);
        Task<WebsitePage> CopyDataAsync(Guid id, WebsitePageCopyDataRequestDto input);
        Task<WebsitePage> GetWebsiteMetaAsync(Guid id);
        Task<WebsitePage> PageDebugViewAsync(Guid id);
    }
}