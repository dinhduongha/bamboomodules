
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
public partial class MailMessageSubtypeAppService :
    CrudAppService<MailMessageSubtype, MailMessageSubtype, long, PagedAndSortedResultRequestDto>,
    IMailMessageSubtypeAppService
{
    private readonly IDataFilter _dataFilter;

    public MailMessageSubtypeAppService(IDataFilter dataFilter, IRepository<MailMessageSubtype, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
