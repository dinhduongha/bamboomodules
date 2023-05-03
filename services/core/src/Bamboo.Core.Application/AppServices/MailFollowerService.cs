
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
public partial class MailFollowerAppService :
    CrudAppService<MailFollower, MailFollower, Guid, PagedAndSortedResultRequestDto>,
    IMailFollowerAppService
{
    private readonly IDataFilter _dataFilter;

    public MailFollowerAppService(IDataFilter dataFilter, IRepository<MailFollower, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
