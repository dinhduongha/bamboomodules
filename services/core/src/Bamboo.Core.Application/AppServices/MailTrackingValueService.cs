
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
public partial class MailTrackingValueAppService :
    CrudAppService<MailTrackingValue, MailTrackingValue, Guid, PagedAndSortedResultRequestDto>,
    IMailTrackingValueAppService
{
    private readonly IDataFilter _dataFilter;

    public MailTrackingValueAppService(IDataFilter dataFilter, IRepository<MailTrackingValue, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
