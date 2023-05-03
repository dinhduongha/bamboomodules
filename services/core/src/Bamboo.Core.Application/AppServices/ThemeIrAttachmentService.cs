
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
public partial class ThemeIrAttachmentAppService :
    CrudAppService<ThemeIrAttachment, ThemeIrAttachment, long, PagedAndSortedResultRequestDto>,
    IThemeIrAttachmentAppService
{
    private readonly IDataFilter _dataFilter;

    public ThemeIrAttachmentAppService(IDataFilter dataFilter, IRepository<ThemeIrAttachment, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
