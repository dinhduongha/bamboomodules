
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
public partial class SmsTemplatePreviewAppService :
    CrudAppService<SmsTemplatePreview, SmsTemplatePreview, Guid, PagedAndSortedResultRequestDto>,
    ISmsTemplatePreviewAppService
{
    private readonly IDataFilter _dataFilter;

    public SmsTemplatePreviewAppService(IDataFilter dataFilter, IRepository<SmsTemplatePreview, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
