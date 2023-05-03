
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
public partial class ChangePasswordUserAppService :
    CrudAppService<ChangePasswordUser, ChangePasswordUser, Guid, PagedAndSortedResultRequestDto>,
    IChangePasswordUserAppService
{
    private readonly IDataFilter _dataFilter;

    public ChangePasswordUserAppService(IDataFilter dataFilter, IRepository<ChangePasswordUser, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
