
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
public partial class HrApplicantCategoryAppService :
    CrudAppService<HrApplicantCategory, HrApplicantCategory, long, PagedAndSortedResultRequestDto>,
    IHrApplicantCategoryAppService
{
    private readonly IDataFilter _dataFilter;

    public HrApplicantCategoryAppService(IDataFilter dataFilter, IRepository<HrApplicantCategory, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
