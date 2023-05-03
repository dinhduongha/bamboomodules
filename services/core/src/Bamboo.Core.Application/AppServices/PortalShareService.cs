
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
public partial class PortalShareAppService :
    CrudAppService<PortalShare, PortalShare, Guid, PagedAndSortedResultRequestDto>,
    IPortalShareAppService
{
    private readonly IDataFilter _dataFilter;

    public PortalShareAppService(IDataFilter dataFilter, IRepository<PortalShare, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
