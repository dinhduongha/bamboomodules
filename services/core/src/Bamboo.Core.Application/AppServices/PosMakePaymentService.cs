
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
public partial class PosMakePaymentAppService :
    CrudAppService<PosMakePayment, PosMakePayment, Guid, PagedAndSortedResultRequestDto>,
    IPosMakePaymentAppService
{
    private readonly IDataFilter _dataFilter;

    public PosMakePaymentAppService(IDataFilter dataFilter, IRepository<PosMakePayment, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
