
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
public partial class PaymentIconAppService :
    CrudAppService<PaymentIcon, PaymentIcon, Guid, PagedAndSortedResultRequestDto>,
    IPaymentIconAppService
{
    private readonly IDataFilter _dataFilter;

    public PaymentIconAppService(IDataFilter dataFilter, IRepository<PaymentIcon, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
