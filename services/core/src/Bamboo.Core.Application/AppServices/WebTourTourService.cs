
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
public partial class WebTourTourAppService :
    CrudAppService<WebTourTour, WebTourTour, Guid, PagedAndSortedResultRequestDto>,
    IWebTourTourAppService
{
    private readonly IDataFilter _dataFilter;

    public WebTourTourAppService(IDataFilter dataFilter, IRepository<WebTourTour, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
