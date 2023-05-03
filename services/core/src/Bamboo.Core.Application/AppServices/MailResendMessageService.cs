
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
public partial class MailResendMessageAppService :
    CrudAppService<MailResendMessage, MailResendMessage, Guid, PagedAndSortedResultRequestDto>,
    IMailResendMessageAppService
{
    private readonly IDataFilter _dataFilter;

    public MailResendMessageAppService(IDataFilter dataFilter, IRepository<MailResendMessage, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
