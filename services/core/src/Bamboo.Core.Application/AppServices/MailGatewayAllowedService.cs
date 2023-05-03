
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
public partial class MailGatewayAllowedAppService :
    CrudAppService<MailGatewayAllowed, MailGatewayAllowed, Guid, PagedAndSortedResultRequestDto>,
    IMailGatewayAllowedAppService
{
    private readonly IDataFilter _dataFilter;

    public MailGatewayAllowedAppService(IDataFilter dataFilter, IRepository<MailGatewayAllowed, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
