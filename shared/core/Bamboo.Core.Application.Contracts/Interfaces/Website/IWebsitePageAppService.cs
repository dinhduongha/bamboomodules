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
    public interface IWebsitePageAppService : IGenericAppService<WebsitePage>
    {
        Task<WebsitePage> ClonePageAsync(WebsitePageClonePageRequestDto input);
        Task<WebsitePage> CopyDataAsync(WebsitePageCopyDataRequestDto input);
        Task<WebsitePage> GetWebsiteMetaAsync(Guid[] ids);
        Task<WebsitePage> PageDebugViewAsync(Guid[] ids);
    }
}