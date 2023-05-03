
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
public partial class ReportPaperformatAppService :
    CrudAppService<ReportPaperformat, ReportPaperformat, long, PagedAndSortedResultRequestDto>,
    IReportPaperformatAppService
{
    private readonly IDataFilter _dataFilter;

    public ReportPaperformatAppService(IDataFilter dataFilter, IRepository<ReportPaperformat, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
