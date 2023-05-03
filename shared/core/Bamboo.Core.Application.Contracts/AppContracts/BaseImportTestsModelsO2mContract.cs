
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Bamboo.Core.Models;

namespace Bamboo.Core.Services;
public interface IBaseImportTestsModelsO2mAppService :
    ICrudAppService<
        BaseImportTestsModelsO2m,
        Guid,
        PagedAndSortedResultRequestDto>
{
}
