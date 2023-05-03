
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
public partial class ResUsersSettingAppService :
    CrudAppService<ResUsersSetting, ResUsersSetting, Guid, PagedAndSortedResultRequestDto>,
    IResUsersSettingAppService
{
    private readonly IDataFilter _dataFilter;

    public ResUsersSettingAppService(IDataFilter dataFilter, IRepository<ResUsersSetting, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
