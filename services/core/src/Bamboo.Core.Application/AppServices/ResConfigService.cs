
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
public partial class ResConfigAppService :
    CrudAppService<ResConfig, ResConfig, Guid, PagedAndSortedResultRequestDto>,
    IResConfigAppService
{
    private readonly IDataFilter _dataFilter;

    public ResConfigAppService(IDataFilter dataFilter, IRepository<ResConfig, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
