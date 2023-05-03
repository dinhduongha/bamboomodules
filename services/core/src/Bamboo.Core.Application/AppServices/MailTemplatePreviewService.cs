
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
public partial class MailTemplatePreviewAppService :
    CrudAppService<MailTemplatePreview, MailTemplatePreview, Guid, PagedAndSortedResultRequestDto>,
    IMailTemplatePreviewAppService
{
    private readonly IDataFilter _dataFilter;

    public MailTemplatePreviewAppService(IDataFilter dataFilter, IRepository<MailTemplatePreview, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
