
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
public partial class ApplicantGetRefuseReasonAppService :
    CrudAppService<ApplicantGetRefuseReason, ApplicantGetRefuseReason, Guid, PagedAndSortedResultRequestDto>,
    IApplicantGetRefuseReasonAppService
{
    private readonly IDataFilter _dataFilter;

    public ApplicantGetRefuseReasonAppService(IDataFilter dataFilter, IRepository<ApplicantGetRefuseReason, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
