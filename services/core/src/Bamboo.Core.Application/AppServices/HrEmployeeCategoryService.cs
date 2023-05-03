
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
public partial class HrEmployeeCategoryAppService :
    CrudAppService<HrEmployeeCategory, HrEmployeeCategory, long, PagedAndSortedResultRequestDto>,
    IHrEmployeeCategoryAppService
{
    private readonly IDataFilter _dataFilter;

    public HrEmployeeCategoryAppService(IDataFilter dataFilter, IRepository<HrEmployeeCategory, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
