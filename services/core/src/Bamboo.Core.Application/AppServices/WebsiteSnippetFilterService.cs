
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Data;
using Volo.Abp.MultiTenancy;

using Bamboo.Core.Models;

namespace Bamboo.Core.Services;

//[Authorize]
public partial class WebsiteSnippetFilterAppService :
    CrudAppService<WebsiteSnippetFilter, WebsiteSnippetFilter, Guid, PagedAndSortedResultRequestDto>,
    IWebsiteSnippetFilterAppService
{
    private readonly IDataFilter _dataFilter;

    public WebsiteSnippetFilterAppService(IDataFilter dataFilter, IRepository<WebsiteSnippetFilter, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
