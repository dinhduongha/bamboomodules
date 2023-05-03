
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
public partial class MailActivityTypeAppService :
    CrudAppService<MailActivityType, MailActivityType, long, PagedAndSortedResultRequestDto>,
    IMailActivityTypeAppService
{
    private readonly IDataFilter _dataFilter;

    public MailActivityTypeAppService(IDataFilter dataFilter, IRepository<MailActivityType, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
