
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
public partial class MailBlacklistRemoveAppService :
    CrudAppService<MailBlacklistRemove, MailBlacklistRemove, Guid, PagedAndSortedResultRequestDto>,
    IMailBlacklistRemoveAppService
{
    private readonly IDataFilter _dataFilter;

    public MailBlacklistRemoveAppService(IDataFilter dataFilter, IRepository<MailBlacklistRemove, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
