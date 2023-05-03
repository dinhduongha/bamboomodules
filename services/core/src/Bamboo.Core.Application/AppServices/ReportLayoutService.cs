
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
public partial class ReportLayoutAppService :
    CrudAppService<ReportLayout, ReportLayout, long, PagedAndSortedResultRequestDto>,
    IReportLayoutAppService
{
    private readonly IDataFilter _dataFilter;

    public ReportLayoutAppService(IDataFilter dataFilter, IRepository<ReportLayout, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
