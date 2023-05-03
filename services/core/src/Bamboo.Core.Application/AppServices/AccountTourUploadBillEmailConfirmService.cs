
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
public partial class AccountTourUploadBillEmailConfirmAppService :
    CrudAppService<AccountTourUploadBillEmailConfirm, AccountTourUploadBillEmailConfirm, Guid, PagedAndSortedResultRequestDto>,
    IAccountTourUploadBillEmailConfirmAppService
{
    private readonly IDataFilter _dataFilter;

    public AccountTourUploadBillEmailConfirmAppService(IDataFilter dataFilter, IRepository<AccountTourUploadBillEmailConfirm, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
