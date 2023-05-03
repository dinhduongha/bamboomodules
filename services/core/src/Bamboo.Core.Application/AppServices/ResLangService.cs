
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
public partial class ResLangAppService :
    CrudAppService<ResLang, ResLang, long, PagedAndSortedResultRequestDto>,
    IResLangAppService
{
    private readonly IDataFilter _dataFilter;

    public ResLangAppService(IDataFilter dataFilter, IRepository<ResLang, long> repository)
        : base(repository)
    {
        _dataFilter = dataFilter;
    }
}
