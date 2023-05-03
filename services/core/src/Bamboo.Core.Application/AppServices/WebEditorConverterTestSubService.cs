
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
public partial class WebEditorConverterTestSubAppService :
    CrudAppService<WebEditorConverterTestSub, WebEditorConverterTestSub, Guid, PagedAndSortedResultRequestDto>,
    IWebEditorConverterTestSubAppService
{
    private readonly IDataFilter _dataFilter;

    public WebEditorConverterTestSubAppService(IDataFilter dataFilter, IRepository<WebEditorConverterTestSub, Guid> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
