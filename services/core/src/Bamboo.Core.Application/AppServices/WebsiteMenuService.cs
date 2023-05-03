
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
public partial class WebsiteMenuAppService :
    CrudAppService<WebsiteMenu, WebsiteMenu, Guid, PagedAndSortedResultRequestDto>,
    IWebsiteMenuAppService
{
    private readonly IDataFilter _dataFilter;

    public WebsiteMenuAppService(IDataFilter dataFilter, IRepository<WebsiteMenu, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
